' This file contains classes used to provide an example of creating your
' own custom annotation, including the data, UI and renderer.


Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.UI

Namespace DotAnnotateDemo
    ''' <summary>
    ''' The TriangleData class is used to hold information describing the annotation.
    ''' In this case it provide a Fill property and the triangle points.
    ''' </summary>
    Public Class TriangleData : Inherits Atalasoft.Annotate.AnnotationData
        Private _fill As AnnotationBrush = Nothing

        Shared Sub New()
            ' This will automatically register the TriangleRenderingEngine
            ' when the first TriangleData is created.
            Atalasoft.Annotate.Renderer.AnnotationRenderers.Add(GetType(TriangleData), New TriangleRenderingEngine)
        End Sub

        Public Sub New()
            Me._fill = New AnnotationBrush(Color.Blue)
            MyBase.SetBrushEvents(Me._fill)
        End Sub

        ''' <summary>
        ''' This constructor is called when deserializing annotation data.
        ''' </summary>
        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            Me._fill = CType(Atalasoft.Utils.SerializationInfoHelper.GetValue(info, "Fill", New AnnotationBrush(Color.Blue)), AnnotationBrush)
            MyBase.SetBrushEvents(Me._fill)
        End Sub

        <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
        Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.GetObjectData(info, context)
            info.AddValue("Fill", Me._fill)
        End Sub

        Public Overrides Function Clone() As Object
            Dim data As TriangleData = New TriangleData
            MyBase.CloneBaseData(data)
            If Me._fill Is Nothing Then
                data._fill = (Nothing)
            Else
                data._fill = (Me._fill.Clone())
            End If
            Return data
        End Function

        Public Property Fill() As AnnotationBrush
            Get
                Return Me._fill
            End Get
            Set(ByVal Value As AnnotationBrush)
                ' If there is no change just ignore it.
                If Value Is Me._fill Then
                    Return
                End If

                ' Raise the PropertyChanging event so any derived classes are notified.
                ' If IgnoreDataChanges is true, we should not raise events.  This can
                ' happen when making internal changes that we don't want propagated.
                Dim e As AnnotationPropertyChangingEventArgs = New AnnotationPropertyChangingEventArgs(Me, "Fill", Me._fill, Value)
                If (Not Me.IgnoreDataChanges) Then
                    OnPropertyChanging(e)
                    If e.Cancel Then
                        Return
                    End If
                End If

                ' If we want this property to work with the UndoManager, we must
                ' pass in an AnnotationUndo object for this change.
                Dim undo As AnnotationUndo = New AnnotationUndo(Me, "Fill", Me._fill, "Fill Change")

                ' If dynamic changes are required for brush properties,
                ' the SetBrushEvents and RemoveBrushEvents methods should
                ' be used.  These allow the brush properties to notify
                ' the AnnotationController that a change was made.
                MyBase.RemoveBrushEvents(Me._fill)
                Me._fill = Value
                MyBase.SetBrushEvents(Me._fill)

                ' Finally, pass the undo object to the AnnotationController.
                If (Not Me.IgnoreDataChanges) Then
                    OnAnnotationControllerNotification(New AnnotationControllerNotificationEventArgs(Atalasoft.Annotate.AnnotationControllerNotification.Invalidate, undo))
                End If
            End Set
        End Property

        ''' <summary>
        ''' Returns the points for the triangle in annotation space.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetTrianglePoints() As PointF()
            Dim points As PointF() = New PointF(2) {}
            points(0) = New PointF(0, Me.Size.Height)
            points(1) = New PointF(Me.Size.Width, Me.Size.Height)
            points(2) = New PointF(Me.Size.Width / 2.0F, 0)
            Return points
        End Function

    End Class


    ''' <summary>
    ''' Here is the actual UI annotation that will be created for the viewer.
    ''' </summary>
    Public Class TriangleAnnotation : Inherits Atalasoft.Annotate.UI.AnnotationUI : Implements Atalasoft.Annotate.Formatters.ILegacyXmpSupport
        ' It's sometimes useful to hold onto a specific data object.
        Private _data As TriangleData

        Public Sub New()
            MyBase.New(New TriangleData)
            Me._data = CType(IIf(TypeOf Me.Data Is TriangleData, Me.Data, Nothing), TriangleData)
            MyBase.SetGrips(New RectangleGrips)




        End Sub

        Public Sub New(ByVal data As TriangleData)
            MyBase.New(data)
            Me._data = data
            MyBase.SetGrips(New RectangleGrips)
        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
            Me._data = CType(IIf(TypeOf Me.Data Is TriangleData, Me.Data, Nothing), TriangleData)
            MyBase.SetGrips(New RectangleGrips)




        End Sub

        Public Overrides Function Clone() As AnnotationUI
            Return New TriangleAnnotation(CType(Me._data.Clone(), TriangleData))
        End Function

        ''' <summary>
        ''' Primarily this region is used for hit testing and cursor changes.
        ''' </summary>
        ''' <param name="space">The space coordinates that should be returned.</param>
        <Obsolete("GetRegion is no longer used by DotAnnotate and may be removed in a future release.", False)> _
        Public Overrides Function GetRegion(ByVal space As AnnotateSpace) As AnnotationRegion
            Dim region As AnnotationRegion = New AnnotationRegion
            Dim size As SizeF = Me.Data.Size

            ' Specify the points in annotation space.
            region.Path.AddPolygon(Me._data.GetTrianglePoints())

            ' Be sure to add the grips to the region.
            MyBase.AddGripsToRegion(region)

            ' Apply the required transformation.
            MyBase.ApplyRegionTransform(region, space)
            Return region
        End Function

#Region "ILegacyXmpSupport Members"

        Public Sub FromXmp(ByVal reader As System.Xml.XmlTextReader) Implements Atalasoft.Annotate.Formatters.ILegacyXmpSupport.FromXmp
            ' The reader will only contain custom tags.
            Do While reader.Read()
                If reader.LocalName = "Fill" Then
                    Me._data.Fill = Atalasoft.Annotate.Formatters.LegacyXmpFormatter.DeserializeBrush(reader)
                    Exit Do
                End If
            Loop
        End Sub

        Public Sub ToXmp(ByVal writer As System.Xml.XmlTextWriter) Implements Atalasoft.Annotate.Formatters.ILegacyXmpSupport.ToXmp
            ' The CustomAnnotation tag and base have already been written
            ' by the formatter.  We only have to add custom properties.
            Atalasoft.Annotate.Formatters.LegacyXmpFormatter.SerializeBrush(writer, Me._data.Fill, "ann:Fill")
        End Sub

#End Region

    End Class


    ''' <summary>
    ''' This is the rendering engine for the triangle.
    ''' By deriving from the AnnotationRenderingEngine we are
    ''' able to simplify the rendering code.
    ''' </summary>
    Public Class TriangleRenderingEngine : Inherits Atalasoft.Annotate.Renderer.AnnotationRenderingEngine
        Public Sub New()
            ' We will use our own custom grip renderer.
            ' We could simply override the RenderGrips method as well.
            'this.GripRenderer = new MyCustomGripRenderer();
        End Sub

        Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As Atalasoft.Annotate.Renderer.RenderEnvironment)
            ' Perform a basic check.
            Dim data As TriangleData = CType(IIf(TypeOf annotation Is TriangleData, annotation, Nothing), TriangleData)






            If data Is Nothing Then
                Return
            End If

            If data.Fill Is Nothing Then
                Return
            End If

            ' SetGraphicsTransform handles combining multiple
            ' transformation matrix objects so you can render normally.
            MyBase.SetGraphicsTransform(annotation, e)

            Dim b As Brush = CreateBrush(data.Fill)
            If Not b Is Nothing Then
                Dim points As PointF() = data.GetTrianglePoints()
                e.Graphics.FillPolygon(b, points)
                b.Dispose()
            End If

            ' If you call SetGraphicsTransform you must also
            ' call RestoreGraphicsTransform when finished.
            MyBase.RestoreGraphicsTransform(e)
        End Sub

        Protected Overloads Overrides Sub RenderGrips(ByVal grips As IAnnotationGrips, ByVal annotation As AnnotationData, ByVal e As Atalasoft.Annotate.Renderer.RenderEnvironment, ByVal scale As PointF)
            ' Create the brush and pen objects.
            Dim brush As brush = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.Fill)
            Dim pen As pen = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.Outline)
            Dim rotateBrush As brush
            If grips.RotationFill Is Nothing Then
                rotateBrush = (brush)
            Else
                rotateBrush = (Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.RotationFill))
            End If
            Dim rotatePen As pen
            If grips.RotationOutline Is Nothing Then
                rotatePen = (pen)
            Else
                rotatePen = (Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.RotationOutline))
            End If

            Dim size As SizeF = grips.Size
            Dim w2 As Single = size.Width / 2.0F
            Dim h2 As Single = size.Height / 2.0F

            For Each grip As AnnotationGrip In grips
                ' Ignore grips that should not be drawn.
                If (Not grip.Visible) Then
                    GoTo Continue1
                End If
                If grip.Action = AnnotationGripAction.Rotating AndAlso (Not annotation.CanRotate) Then
                    GoTo Continue1
                End If

                ' While the grip size does not scale, the position of the grip does.
                Dim rc As RectangleF = New RectangleF(Convert.ToInt32(grip.Position.X * scale.X - w2), Convert.ToInt32(grip.Position.Y * scale.Y - h2), size.Width, size.Height)

                If grip.Action = AnnotationGripAction.Rotating AndAlso Not rotateBrush Is Nothing Then
                    e.Graphics.FillRectangle(rotateBrush, rc)
                ElseIf Not brush Is Nothing Then
                    e.Graphics.FillEllipse(brush, rc)
                End If

                If grip.Action = AnnotationGripAction.Rotating AndAlso Not rotatePen Is Nothing Then
                    e.Graphics.DrawRectangle(rotatePen, rc.X, rc.Y, rc.Width, rc.Height)
                ElseIf Not pen Is Nothing Then
                    e.Graphics.DrawEllipse(pen, rc)
                End If
Continue1:
            Next grip

            ' Clean up
            If Not rotateBrush Is Nothing AndAlso Not rotateBrush Is brush Then
                rotateBrush.Dispose()
            End If

            If Not rotatePen Is Nothing AndAlso Not rotatePen Is pen Then
                rotatePen.Dispose()
            End If

            If Not brush Is Nothing Then
                brush.Dispose()
            End If

            If Not pen Is Nothing Then
                pen.Dispose()
            End If
        End Sub

    End Class

    Public Class MyCustomGripRenderer : Implements Atalasoft.Annotate.Renderer.IAnnotationGripRenderer
        Public Sub New()
        End Sub

#Region "IAnnotationGripRenderer Members"

        Public Sub RenderGrips(ByVal grips As IAnnotationGrips, ByVal annotation As AnnotationData, ByVal e As Atalasoft.Annotate.Renderer.RenderEnvironment) Implements Atalasoft.Annotate.Renderer.IAnnotationGripRenderer.RenderGrips
            ' For a simple example, we will draw circles instead of rectangles
            ' for normal grips and rectangles for rotation grips.

            ' Just in case...
            If annotation Is Nothing OrElse grips Is Nothing OrElse e Is Nothing Then
                Return
            End If

            ' Multiple the annotation transform to the viewer matrix.
            Dim vm As System.Drawing.Drawing2D.Matrix = Nothing
            If Not e.Transform Is Nothing Then
                vm = e.Transform.Clone()
            ElseIf Not e.Graphics.Transform Is Nothing Then
                vm = e.Graphics.Transform.Clone()
            End If

            Dim scaleX As Single = vm.Elements(0)
            Dim scaleY As Single = vm.Elements(3)

            ' The annotation transform.
            Dim m As System.Drawing.Drawing2D.Matrix = annotation.GetRenderTransform()
            If Not vm Is Nothing Then
                vm.Multiply(m)
                m.Dispose()
            Else
                vm = m
            End If

            ' This will undo the scaling the transformation
            ' matrix wants to perform, since grips don't scale.
            vm.Scale(1.0F / scaleX, 1.0F / scaleY)

            Dim state As System.Drawing.Drawing2D.GraphicsState = e.Graphics.Save()
            e.Graphics.Transform = vm

            ' Create the brush and pen objects.
            Dim brush As brush = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.Fill)
            Dim pen As pen = Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.Outline)
            Dim rotateBrush As brush
            If grips.RotationFill Is Nothing Then
                rotateBrush = (brush)
            Else
                rotateBrush = (Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreateBrush(grips.RotationFill))
            End If
            Dim rotatePen As pen
            If grips.RotationOutline Is Nothing Then
                rotatePen = (pen)
            Else
                rotatePen = (Atalasoft.Annotate.Renderer.AnnotationRenderingEngine.CreatePen(grips.RotationOutline))
            End If

            Dim size As SizeF = grips.Size
            Dim w2 As Single = size.Width / 2.0F
            Dim h2 As Single = size.Height / 2.0F

            For Each grip As AnnotationGrip In grips
                ' Ignore grips that should not be drawn.
                If (Not grip.Visible) Then
                    GoTo Continue1
                End If
                If grip.Action = AnnotationGripAction.Rotating AndAlso (Not annotation.CanRotate) Then
                    GoTo Continue1
                End If

                ' While the grip size does not scale, the position of the grip does.
                Dim rc As RectangleF = New RectangleF(Convert.ToInt32(grip.Position.X * scaleX - w2), Convert.ToInt32(grip.Position.Y * scaleY - h2), size.Width, size.Height)

                If grip.Action = AnnotationGripAction.Rotating AndAlso Not rotateBrush Is Nothing Then
                    e.Graphics.FillRectangle(rotateBrush, rc)
                ElseIf Not brush Is Nothing Then
                    e.Graphics.FillEllipse(brush, rc)
                End If

                If grip.Action = AnnotationGripAction.Rotating AndAlso Not rotatePen Is Nothing Then
                    e.Graphics.DrawRectangle(rotatePen, rc.X, rc.Y, rc.Width, rc.Height)
                ElseIf Not pen Is Nothing Then
                    e.Graphics.DrawEllipse(pen, rc)
                End If
Continue1:
            Next grip

            ' Clean up
            If Not rotateBrush Is Nothing AndAlso Not rotateBrush Is brush Then
                rotateBrush.Dispose()
            End If

            If Not rotatePen Is Nothing AndAlso Not rotatePen Is pen Then
                rotatePen.Dispose()
            End If

            If Not brush Is Nothing Then
                brush.Dispose()
            End If

            If Not pen Is Nothing Then
                pen.Dispose()
            End If

            e.Graphics.Restore(state)
            vm.Dispose()
        End Sub

#End Region

    End Class

End Namespace
