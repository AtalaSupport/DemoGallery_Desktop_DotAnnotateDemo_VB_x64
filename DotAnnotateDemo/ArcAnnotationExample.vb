Option Explicit On
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Runtime.Serialization
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.UI
Imports Atalasoft.Annotate.Renderer
Imports System.Collections.Generic

Namespace DotAnnotateDemo
    <Serializable()> _
    Public Class ArcData : Inherits PointBaseData
        Private _fill As AnnotationBrush = New AnnotationBrush(Color.Red)

        Shared Sub New()
            AnnotationRenderers.Add(GetType(ArcData), New ArcRenderingEngine())
        End Sub

        Public Sub New()
        End Sub

        Public Sub New(ByVal points As PointF())
            MyBase.New(New PointFCollection(points))
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            _fill = CType(info.GetValue("Fill", GetType(AnnotationBrush)), AnnotationBrush)
            MyBase.SetBrushEvents(_fill)
        End Sub

        Public Property Fill() As AnnotationBrush
            Get
                Return _fill
            End Get
            Set(ByVal value As AnnotationBrush)
                If value Is _fill Then
                    Return
                End If

                Dim e As AnnotationPropertyChangingEventArgs = New AnnotationPropertyChangingEventArgs(Me, "Fill", Me._fill, value)
                If (Not Me.IgnoreDataChanges) Then
                    OnPropertyChanging(e)
                    If e.Cancel Then
                        Return
                    End If
                End If

                Dim undo As AnnotationUndo = New AnnotationUndo(Me, "Fill", Me._fill, "Arc Fill Change")

                MyBase.RemoveBrushEvents(_fill)
                _fill = value
                MyBase.SetBrushEvents(_fill)

                If (Not Me.IgnoreDataChanges) Then
                    OnAnnotationControllerNotification(New AnnotationControllerNotificationEventArgs(Atalasoft.Annotate.AnnotationControllerNotification.Invalidate, undo))
                End If
            End Set
        End Property

        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.GetObjectData(info, context)
            info.AddValue("Fill", _fill)
        End Sub


        Public Overrides Function Clone() As Object
            Dim data As ArcData = New ArcData()
            MyBase.CloneBaseData(data)

            If Not _fill Is Nothing Then
                data._fill = _fill.Clone()
            End If
            Return data
        End Function
    End Class

    <Serializable()> _
    Public Class ArcAnnotation : Inherits PointBaseAnnotation
        Private _data As ArcData
        Private _pointIndex As Integer

        Public Sub New()
            Me.New(New ArcData())
        End Sub

        Public Sub New(ByVal points As PointF())
            Me.New(New ArcData(points))
        End Sub

        Public Sub New(ByVal data As ArcData)
            MyBase.New(data)
            _data = data
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            _data = CType(Me.Data, ArcData)
        End Sub

        Public Property Fill() As AnnotationBrush
            Get
                Return _data.Fill
            End Get
            Set(ByVal value As AnnotationBrush)
                _data.Fill = value
            End Set
        End Property

        Public Overrides Function Clone() As AnnotationUI
            Return New ArcAnnotation(CType(_data.Clone(), ArcData))
        End Function

        Public Overrides Sub BeginCreate()
            _pointIndex = 0
            _data.Points.Clear()
            Me.GripMode = AnnotationGripMode.Points
            MyBase.BeginCreate()
        End Sub

        Protected Overrides Sub OnGripPositionChanged(ByVal e As Atalasoft.Annotate.UI.AnnotationGripChangedEventArgs)
            'This updates our underlying data to the e.NewPosition as well as moving the grip.
            MyBase.OnGripPositionChanged(e)

            'Make sure the two end-points are the same distance from the center point.
            EnforceGripEquidistance(e.Grip)
        End Sub

        Protected Sub EnforceGripEquidistance(ByRef peggedGrip As AnnotationGrip)
            Dim otherGrip As AnnotationGrip
            Dim gripIndex As Integer = 0
            Dim otherGripIndex As Integer = 0

            'If we're moving Grip(1), move Grip(2) to match.
            If peggedGrip.Equals(Me.Grips(1)) Then
                otherGrip = Me.Grips(2)
                gripIndex = 1
                otherGripIndex = 2
                'If we're moving Grip(2), move Grip(1) to match.
            ElseIf peggedGrip.Equals(Me.Grips(2)) Then
                otherGrip = Me.Grips(1)
                gripIndex = 2
                otherGripIndex = 1
            Else
                'We're moving the center grip. Peg against the second grip.
                otherGrip = Me.Grips(2)
                gripIndex = 1
                otherGripIndex = 2
            End If

            Dim points As PointFCollection = Me._data.Points

            points = AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(Me._data, points)

            'We only want to adjust the radius of the 'other' grip, not the angle. 
            Dim otherGripAngle As Double = Math.Atan2((points(otherGripIndex).Y - points(0).Y), (points(otherGripIndex).X - points(0).X))
            'Get the radius we want to adjust to.
            Dim radius As Double = Math.Sqrt(Math.Pow(points(gripIndex).Y - points(0).Y, 2) + Math.Pow(points(gripIndex).X - points(0).X, 2))

            Dim newPosition As New PointF()

            newPosition.X = CSng(Math.Cos(otherGripAngle) * radius) + points(0).X
            newPosition.Y = CSng(Math.Sin(otherGripAngle) * radius) + points(0).Y

            'Move the grip and update the underlying annotation data.
            otherGrip.Position = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(Me._data, newPosition)
            Me._data.Points(otherGripIndex) = otherGrip.Position

        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As AnnotationMouseEventArgs)
            If Me.State = AnnotationState.Creating Then
                _pointIndex += 1
                If Me._pointIndex = 1 Then
                    Me._data.IgnoreDataChanges = True
                    Me._data.Location = New PointF(e.X, e.Y)
                    Me._data.IgnoreDataChanges = False
                    Me._data.Points.Add(PointF.Empty)
                End If
            Else
                MyBase.OnMouseDown(e)
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As AnnotationMouseEventArgs)
            If Me.State = AnnotationState.Creating Then
                Dim pt As New PointF(e.X, e.Y)
                pt = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(Me._data, New PointF(e.X, e.Y))

                'Add an end point so it will render.
                If Me._pointIndex = 1 Then
                    If Me._data.Points.Count = 1 Then
                        Me._data.Points.Add(pt)
                    Else
                        Me._data.Points(1) = pt
                    End If
                ElseIf Me._pointIndex = 2 AndAlso Me._data.Points.Count = 3 Then
                    Me._data.Points(2) = pt
                End If
            Else
                MyBase.OnMouseMove(e)
            End If
        End Sub

        Protected Overrides Function OnMouseUp(ByVal e As AnnotationMouseEventArgs) As Boolean
            If Me.State = AnnotationState.Creating Then
                ' We only want 3 points.
                If _pointIndex = 3 Then
                    _pointIndex = 2
                    Me.State = AnnotationState.Idle

                    Dim pts As PointF() = Me._data.Points.ToArray()
                    AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(Me._data, pts)

                    Dim pt As PointGrips = CType(IIf(TypeOf Me.Grips Is PointGrips, Me.Grips, Nothing), PointGrips)
                    For i As Integer = 0 To 2
                        pt.Add(New AnnotationGrip(_data.Points(i), AnnotationGripState.Default, AnnotationGripAction.Independent))
                    Next i

                    'When creating, make sure the first end point is set to the same radius as the final point.
                    EnforceGripEquidistance(pt(2))

                    Return True
                End If

                If Me._data.Points.Count = _pointIndex Then
                    ' Add another end point so it will draw during creation.
                    Dim pt As PointF = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(Me._data, New PointF(e.X, e.Y))
                    Me._data.Points.Add(pt)
                End If

                Return False
            Else
                Return MyBase.OnMouseUp(e)
            End If
        End Function

        Public Overrides ReadOnly Property Bounds() As System.Drawing.RectangleF
            Get
                If Me._data.Points.Count = 3 Then
                    Dim pts As PointF() = Me._data.Points.ToArray()
                    AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(Me._data, pts)

                    Return GetPointBounds(pts)
                Else
                    Return MyBase.Bounds
                End If
            End Get
        End Property

        Private Function GetPointBounds(ByVal points As PointF()) As RectangleF
            Dim x As Single = Single.MaxValue
            Dim y As Single = Single.MaxValue

            Dim x2 As Single = Single.MinValue
            Dim y2 As Single = Single.MinValue

            'If we have < 3 points, we just have a line.
            If points.Length < 3 Then
                For Each pt As PointF In points
                    If pt.X < x Then
                        x = pt.X
                    End If
                    If pt.Y < y Then
                        y = pt.Y
                    End If
                    If pt.X > x2 Then
                        x2 = pt.X
                    End If
                    If pt.Y > y2 Then
                        y2 = pt.Y
                    End If
                Next
            Else
                'In theory, the radius of the two non-center points should be equal. In practice they may differ slightly, but not enough to really worry about.
                Dim radius As Double = Math.Sqrt(Math.Pow(points(1).Y - points(0).Y, 2) + Math.Pow(points(1).X - points(0).X, 2))

                'This is a bit lazy, in theory we could figure out what quadrants the arc goes through and limit our bounds based on that
                'However, this is much faster and doesn't really cause that much more redraw.

                x = points(0).X - CSng(radius)
                y = points(0).Y - CSng(radius)

                x2 = CSng(radius) + points(0).X

                y2 = CSng(radius) + points(0).Y
            End If

            Return New RectangleF(x, y, x2 - x, y2 - y)
        End Function

    End Class

    Public Class ArcAnnotationFactory
        Implements IAnnotationUIFactory

        Public Sub New()
        End Sub

        Public Function GetAnnotationUI(ByVal data As AnnotationData) As AnnotationUI Implements Atalasoft.Annotate.UI.IAnnotationUIFactory.GetAnnotationUI
            Dim arcData As ArcData = TryCast(data, ArcData)
            If arcData Is Nothing Then
                Return Nothing
            Else
                Return New ArcAnnotation(arcData)
            End If
        End Function
    End Class


    Public Class ArcRenderingEngine : Inherits AnnotationRenderingEngine
        Public Sub New()
        End Sub

        Public Function GetAnnotationUI(ByVal data As AnnotationData) As AnnotationUI
            Dim arcData As ArcData = TryCast(data, ArcData)
            If arcData Is Nothing Then
                Return Nothing
            Else
                Return New ArcAnnotation(arcData)
            End If
        End Function

        Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As RenderEnvironment)
            If annotation Is Nothing Then
                Throw New ArgumentNullException("annotation")
            End If

            If e Is Nothing Then
                Throw New ArgumentNullException("e")
            End If

            Dim data As ArcData = CType(IIf(TypeOf annotation Is ArcData, annotation, Nothing), ArcData)
            If data Is Nothing Then
                Throw New ArgumentException("The ArcRenderingEngine can only be used to render a ArcData class.", "annotation")
            End If

            If data.Points.Count < 2 OrElse data.Fill Is Nothing Then
                Return
            End If

            MyBase.SetGraphicsTransform(data, e)

            'If we only have 2 points, we don't have an arc, we have a line.
            If data.Points.Count = 2 Then
                Dim p As Pen = CreatePen(New AnnotationPen(data.Fill, 1.0F / e.Resolution.X))
                e.Graphics.DrawLine(p, data.Points(0), data.Points(1))
                p.Dispose()
            Else
                'Get the start and end angle
                Dim startAngle As Double = Math.Atan2((data.Points(1).Y - data.Points(0).Y), (data.Points(1).X - data.Points(0).X))
                Dim endAngle As Double = Math.Atan2((data.Points(2).Y - data.Points(0).Y), (data.Points(2).X - data.Points(0).X))

                'For the sake of sanity, make sure we have one contiguous set of points.
                If endAngle < startAngle Then
                    endAngle += 2 * Math.PI
                End If

                Dim currAngle As Double = startAngle

                Dim radius As Double = Math.Sqrt(Math.Pow(data.Points(2).Y - data.Points(0).Y, 2) + Math.Pow(data.Points(2).X - data.Points(0).X, 2))

                Dim x As Double
                Dim y As Double


                'Step one angle at a time. Build an array of points defining the outline of our arc.
                Dim segmentBounds As New List(Of PointF)()
                segmentBounds.Add(data.Points(0))
                Do
                    x = (Math.Cos(currAngle) * radius) + data.Points(0).X
                    y = (Math.Sin(currAngle) * radius) + data.Points(0).Y

                    segmentBounds.Add(New PointF(CSng(x), CSng(y)))

                    'One degree (rad), feel free to alter this value to better reflect the quality/speed trade-off you desire.
                    currAngle += 0.0174532925
                Loop While currAngle < endAngle

                Dim b As Brush = CreateBrush(data.Fill)

                'Draw a filled polygon with our outline.
                e.Graphics.FillPolygon(b, segmentBounds.ToArray())
                b.Dispose()
            End If

            MyBase.RestoreGraphicsTransform(e)
        End Sub

    End Class
End Namespace
