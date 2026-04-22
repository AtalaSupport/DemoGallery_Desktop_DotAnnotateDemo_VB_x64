Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Runtime.Serialization
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.UI
Imports Atalasoft.Annotate.Renderer

Namespace DotAnnotateDemo
	<Serializable> _
	Public Class TrianglePointData : Inherits PointBaseData
		Private _fill As AnnotationBrush = New AnnotationBrush(Color.Red)

		Shared Sub New()
			AnnotationRenderers.Add(GetType(TrianglePointData), New TrianglePointRenderingEngine())
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
			Set
				If Value Is _fill Then
				Return
				End If

				Dim e As AnnotationPropertyChangingEventArgs = New AnnotationPropertyChangingEventArgs(Me, "Fill", Me._fill, Value)
				If (Not Me.IgnoreDataChanges) Then
					OnPropertyChanging(e)
					If e.Cancel Then
					Return
					End If
				End If

				Dim undo As AnnotationUndo = New AnnotationUndo(Me, "Fill", Me._fill, "Triangle Fill Change")

				MyBase.RemoveBrushEvents(_fill)
				_fill = Value
				MyBase.SetBrushEvents(_fill)

				If (Not Me.IgnoreDataChanges) Then
					OnAnnotationControllerNotification(New AnnotationControllerNotificationEventArgs(Atalasoft.Annotate.AnnotationControllerNotification.Invalidate, undo))
				End If
			End Set
		End Property

		Public Overrides Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext)
			MyBase.GetObjectData (info, context)
			info.AddValue("Fill", _fill)
		End Sub


		Public Overrides Function Clone() As Object
			Dim data As TrianglePointData = New TrianglePointData()
			MyBase.CloneBaseData(data)

			If Not _fill Is Nothing Then
			data._fill = _fill.Clone()
			End If
			Return data
		End Function
	End Class

	<Serializable> _
	Public Class TrianglePointAnnotation : Inherits PointBaseAnnotation
		Private _data As TrianglePointData
		Private _pointIndex As Integer

		Public Sub New()
			Me.New(New TrianglePointData())
		End Sub

		Public Sub New(ByVal points As PointF())
			Me.New(New TrianglePointData(points))
		End Sub

		Public Sub New(ByVal data As TrianglePointData)
			MyBase.New(data)
			_data = data
		End Sub

		Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
			MyBase.New(info, context)
			_data = CType(Me.Data, TrianglePointData)
		End Sub

		Public Property Fill() As AnnotationBrush
			Get
				Return _data.Fill
			End Get
			Set
				_data.Fill = Value
			End Set
		End Property

		Public Overrides Function Clone() As AnnotationUI
			Return New TrianglePointAnnotation(CType(_data.Clone(), TrianglePointData))
		End Function

		Public Overrides Sub BeginCreate()
			_pointIndex = 0
			_data.Points.Clear()
			Me.GripMode = AnnotationGripMode.Points
			MyBase.BeginCreate ()
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
				MyBase.OnMouseDown (e)
			End If
		End Sub

		Protected Overrides Sub OnMouseMove(ByVal e As AnnotationMouseEventArgs)
			If Me.State = AnnotationState.Creating Then
				Dim pt As PointF = New PointF(e.X, e.Y)
				Dim delta As PointF
				If pt.X < Me._data.Location.X Then
					If pt.Y < Me._data.Location.Y Then
						delta = New PointF((Me._data.Location.X - pt.X), (Me._data.Location.Y - pt.Y))
					Else
						delta = New PointF((Me._data.Location.X - pt.X), (0))
					End If
				Else
					If pt.Y < Me._data.Location.Y Then
						delta = New PointF((0), (Me._data.Location.Y - pt.Y))
					Else
						delta = New PointF((0), (0))
					End If
				End If
				pt = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(Me._data, New PointF(e.X, e.Y))

				' Add an end point so it will render.
				If Me._pointIndex = 1 Then
					If Me._data.Points.Count = 1 Then
						Me._data.Points.Add(pt)
					Else
						Me._data.Points(Me._pointIndex) = pt
					End If
				Else
					Me._data.Points(Me._pointIndex) = pt
				End If
			Else
				MyBase.OnMouseMove(e)
			End If
		End Sub

		Protected Overrides Function OnMouseUp(ByVal e As AnnotationMouseEventArgs) As Boolean
			If Me.State = AnnotationState.Creating Then
				' We only want 3 points.
				If _pointIndex = 3 Then
					Me.State = AnnotationState.Idle

					Dim pts As PointF() = Me._data.Points.ToArray()
					AnnotateSpaceConverter.AnnotationSpaceToDocumentSpace(Me._data, pts)
					Dim bounds As RectangleF = GetPointBounds(pts)
					Me._data.Location = bounds.Location
					Me._data.Size = bounds.Size

					Dim pt As PointGrips = CType(IIf(TypeOf Me.Grips Is PointGrips, Me.Grips, Nothing), PointGrips)
					For i As Integer = 0 To 2
                        pt.Add(New AnnotationGrip(_data.Points(i), AnnotationGripState.Default, AnnotationGripAction.Independent))
					Next i
					Return True
				End If

				If Me._data.Points.Count = _pointIndex Then
					' Add another end point so it will draw during creation.
					Dim pt As PointF = AnnotateSpaceConverter.DocumentSpaceToAnnotationSpace(Me._data, New PointF(e.X, e.Y))
					Me._data.Points.Add(pt)
				End If

				Return False
			Else
				Return MyBase.OnMouseUp (e)
			End If
		End Function

		Private Function GetPointBounds(ByVal points As PointF()) As RectangleF
			Dim x As Single = Single.MaxValue
			Dim y As Single = Single.MaxValue
			Dim x2 As Single = Single.MinValue
			Dim y2 As Single = Single.MinValue

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
			Next pt

			Return New RectangleF(x, y, x2 - x, y2 - y)
		End Function
	End Class

	Public Class TrianglePointRenderingEngine : Inherits AnnotationRenderingEngine
		Public Sub New()
		End Sub

		Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As RenderEnvironment)
			If annotation Is Nothing Then
				Throw New ArgumentNullException("annotation")
			End If

			If e Is Nothing Then
				Throw New ArgumentNullException("e")
			End If

			Dim data As TrianglePointData = CType(IIf(TypeOf annotation Is TrianglePointData, annotation, Nothing), TrianglePointData)
			If data Is Nothing Then
				Throw New ArgumentException("The TrianglePointRenderingEngine can only be used to render a TrianglePointData class.", "annotation")
			End If

			If data.Points.Count < 2 OrElse data.Fill Is Nothing Then
			Return
			End If

			MyBase.SetGraphicsTransform(data, e)

			If data.Points.Count = 2 Then
				Dim p As Pen = CreatePen(New AnnotationPen(data.Fill, 1f / e.Resolution.X))
				e.Graphics.DrawLine(p, data.Points(0), data.Points(1))
				p.Dispose()
			Else
				Dim b As Brush = CreateBrush(data.Fill)
				e.Graphics.FillPolygon(b, data.Points.ToArray())
				b.Dispose()
			End If

			MyBase.RestoreGraphicsTransform(e)
		End Sub

	End Class
End Namespace
