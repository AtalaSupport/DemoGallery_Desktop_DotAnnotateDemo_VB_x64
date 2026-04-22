' This source code is property of Atalasoft, Inc. (www.atalasoft.com)
' Permission for usage and modification of this code is only permitted 
' with the purchase of a DotImage source code license.

' Change History:


Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.Renderer

Namespace DotAnnotateDemo
	Friend Class ClassyLineDrawing
		#Region "UtilityGeometryRoutines"

		' These are utility methods for basic 2D geometry

		Private Shared Function GetLineAngle(ByVal p1 As PointF, ByVal p2 As PointF) As Double
			Dim dx As Double = p2.X - p1.X
			Dim dy As Double = p2.Y - p1.Y
			Dim angle As Double = Math.Atan2(dy, dx)
			Return angle
		End Function

		Private Shared Function GetLineLength(ByVal p1 As PointF, ByVal p2 As PointF) As Double
			Dim dx As Double = p1.X - p2.X
			Dim dy As Double = p1.Y - p2.Y
			Return Math.Sqrt(dx * dx + dy * dy)
		End Function

		Private Shared Function GetLineMidpoint(ByVal p1 As PointF, ByVal p2 As PointF) As PointF
			Return New PointF((p1.X + p2.X)/2.0f, (p1.Y + p2.Y)/2.0f)
		End Function

		Private Shared Function RadiansToDegrees(ByVal theta As Double) As Double
			Return theta * 180.0 / Math.PI
		End Function
		#End Region

		#Region "UtilityRenderingCode"
		' these routines are used to draw lines that have diamond pointed ends and an optional diamond middle part
		' when then connecting lines are "thick enough" the connecting lines are doubled

		Private Shared _diamondPoints As PointF() = New PointF(3){}
		Private Shared Sub DrawDiamond(ByVal re As RenderEnvironment, ByVal location As PointF, ByVal p As Pen, ByVal radius As Double, ByVal angle As Double)
			' Draws a diamond of the given radius, rotated at the given angle, at the given location
			' Color is derived from the pen's color

            Dim diamondMatrix As Matrix = re.Transform.Clone()
			diamondMatrix.Translate(location.X, location.Y)
			diamondMatrix.Rotate(CSng(angle))
			Dim fradius As Single = CSng(radius)

			' these four points represent the diamond
			_diamondPoints(0) = New PointF(0, -fradius)
			_diamondPoints(1) = New PointF(fradius, 0)
			_diamondPoints(2) = New PointF(0, fradius)
			_diamondPoints(3) = New PointF(-fradius, 0)
			diamondMatrix.TransformPoints(_diamondPoints)

			' draw the diamond
			Dim b As Brush = New SolidBrush(p.Color)
			re.Graphics.FillPolygon(b, _diamondPoints)
			b.Dispose()
		End Sub

		Private Shared Sub DrawLineSegments(ByVal re As RenderEnvironment, ByVal p As Pen, ByVal pts As PointF())
			' DrawLines connects segments together   I need them to remain disjoint

			If (pts.Length And 1) <> 0 Then
				Throw New ArgumentException("need an even number of points", "pts")
			End If

			Dim nPairs As Integer = pts.Length / 2
			For i As Integer = 0 To nPairs - 1
				re.Graphics.DrawLine(p, pts(2 * i), pts(2 * i + 1))
			Next i
		End Sub


		Private Shared _singleLine As PointF() = New PointF(1){}
		Private Shared _doubleLine As PointF() = New PointF(3){}
		Private Shared _quadLine As PointF() = New PointF(7){}
        Private Shared Sub DrawConnectingLines(ByVal re As RenderEnvironment, ByVal fromPoint As PointF, ByVal toPoint As PointF, ByVal p As Pen, ByVal radius As Double, ByVal lineLength As Double, ByVal angle As Double, ByVal splitLine As Boolean, ByVal drawSingleLine As Boolean)
            ' this is a utility method to draw lines that will connect two diamonds

            ' radius is the radius of a diamond
            ' lineLength is the line's length
            ' angle is the angle of the line on the page
            ' splitLine determines if there should be a space for a third diamond
            ' drawSingleLine determines if the line should a single or a double line


            ' the spacing around a diamond is 3/2 the diamond radius -- tweaking this will carry over through the
            ' rest of the code - try ranges from fradius/2 up to fradius * 4

            Dim fradius As Single = CSng(radius)
            Dim diamondSpacing As Single = (3 * fradius) / 2.0F

            ' don't bother drawing if there's nothing to draw
            If (splitLine AndAlso lineLength < 4 * diamondSpacing) OrElse ((Not splitLine) AndAlso lineLength < 2 * diamondSpacing) Then
                Return
            End If

            ' set up the transform so that all lines get drawn in an axis-aligned orientation
            Dim lineMatrix As Matrix = CType(re.Transform.Clone(), Matrix)
            lineMatrix.Translate(fromPoint.X, fromPoint.Y)
            lineMatrix.Rotate(CSng(angle))

            Dim myPen As Pen = CType(p.Clone(), Pen)
            Dim pts As PointF()

            If drawSingleLine Then
                If splitLine Then
                    ' draw a single line split in half
                    Dim segmentLength As Single = CSng((lineLength / 2) - (2 * diamondSpacing))
                    _doubleLine(0) = New PointF(diamondSpacing, 0)
                    _doubleLine(1) = New PointF(diamondSpacing + segmentLength, 0)
                    _doubleLine(2) = New PointF(CSng(lineLength / 2) + diamondSpacing, 0)
                    _doubleLine(3) = New PointF(CSng(lineLength / 2) + diamondSpacing + segmentLength, 0)
                    pts = _doubleLine
                Else
                    ' draw a single continuous line
                    _singleLine(0) = New PointF(diamondSpacing, 0)
                    _singleLine(1) = New PointF(diamondSpacing + CSng(lineLength - 2) * diamondSpacing, 0)
                    pts = _singleLine
                End If
            Else
                ' Divide the line thickness into thirds.  1/3 above is the top, 1/3 below is the bottom
                Dim lineOffset As Single = myPen.Width / 3
                ' divide the line thickness by 6 to make the total thickness be 1/3 of the total line thickness
                myPen.Width /= 6.0F

                If splitLine Then
                    ' draw a double line split in half
                    Dim segmentLength As Single = CSng((lineLength / 2) - (2 * diamondSpacing))
                    _quadLine(0) = New PointF(diamondSpacing, lineOffset)
                    _quadLine(1) = New PointF(diamondSpacing + segmentLength, lineOffset)
                    _quadLine(2) = New PointF(CSng(lineLength / 2) + diamondSpacing, lineOffset)
                    _quadLine(3) = New PointF(CSng(lineLength / 2) + diamondSpacing + segmentLength, lineOffset)
                    _quadLine(4) = New PointF(diamondSpacing, -lineOffset)
                    _quadLine(5) = New PointF(diamondSpacing + segmentLength, -lineOffset)
                    _quadLine(6) = New PointF(CSng(lineLength / 2) + diamondSpacing, -lineOffset)
                    _quadLine(7) = New PointF(CSng(lineLength / 2) + diamondSpacing + segmentLength, -lineOffset)
                    pts = _quadLine
                Else
                    ' draw a double continuous line
                    _doubleLine(0) = New PointF(diamondSpacing, lineOffset)
                    _doubleLine(1) = New PointF(diamondSpacing + CSng(lineLength - 2) * diamondSpacing, lineOffset)
                    _doubleLine(2) = New PointF(diamondSpacing, -lineOffset)
                    _doubleLine(3) = New PointF(diamondSpacing + CSng(lineLength - 2) * diamondSpacing, -lineOffset)
                    pts = _doubleLine
                End If
            End If
            lineMatrix.TransformPoints(pts)
            DrawLineSegments(re, myPen, pts)
            myPen.Dispose()
        End Sub

        Public Shared Sub DrawDiamondLines(ByVal re As RenderEnvironment, ByVal fromPoint As PointF, ByVal toPoint As PointF, ByVal drawFromDiamond As Boolean, ByVal drawToDiamond As Boolean, ByVal p As Pen)
            ' draw a diamond-adorned line between from and to
            ' drawFromDiamond determines whether or not a diamond will be drawn at the originating point (space is left if not)
            ' drawToDiamond determines whether or not a diamond will be drawn at the ending point (space is left if not)

            Dim diamondRadius As Double = p.Width / 2.0F

            ' pin the radius to 4.5  Anything smaller doesn't look like anything
            If diamondRadius < 4.5 Then
                diamondRadius = 4.5
            End If

            ' get the line angle
            Dim lineAngle As Double = RadiansToDegrees(GetLineAngle(fromPoint, toPoint))
            ' get its length
            Dim lineLength As Double = GetLineLength(fromPoint, toPoint)

            ' determine if we need a middle diamond.  Basically, the space taken up in a line with three
            ' diamonds is 4 * the diamond diameter or span, or 8 * the radius
            Dim drawMiddleDiamond As Boolean = lineLength > 8 * diamondRadius

            ' where does the middle point go?
            Dim middleDiamondLocation As PointF = GetLineMidpoint(fromPoint, toPoint)

            ' leave single line at a width < 3 - if you double up any smaller, the lines run together
            Dim drawSingleLine As Boolean = p.Width < 3.0F

            If drawFromDiamond Then
                DrawDiamond(re, fromPoint, p, diamondRadius, lineAngle)
            End If

            If drawToDiamond Then
                DrawDiamond(re, toPoint, p, diamondRadius, lineAngle)
            End If

            If drawMiddleDiamond Then
                DrawDiamond(re, middleDiamondLocation, p, diamondRadius, lineAngle)
            End If

            DrawConnectingLines(re, fromPoint, toPoint, p, diamondRadius, lineLength, lineAngle, drawMiddleDiamond, drawSingleLine)
        End Sub
#End Region
    End Class




	Public Class DiamondLineRenderingEngine
		Inherits LineRenderingEngine
		' Implementation of the LineRenderingEngine using a "stylish" line instead of the regular one

		Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As RenderEnvironment)
			' check args
			If annotation Is Nothing Then
				Throw New ArgumentNullException("annotation")
			End If

			If e Is Nothing Then
				Throw New ArgumentNullException("e")
			End If

			Dim data As LineData = CType(IIf(TypeOf annotation Is LineData, annotation, Nothing), LineData)
			If data Is Nothing Then
				Throw New ArgumentException("DashedLineRendered can't handle data of type " & annotation.GetType().Name)
			End If

			If (Not annotation.Visible) OrElse data.Outline Is Nothing Then
			Return
			End If

			MyBase.SetGraphicsTransform(annotation, e)

			Dim lockPoint As PointF = PointF.Empty

			Dim p As Pen = CreatePen(data.Outline)
			If Not p Is Nothing Then
				' draw a single line
                ClassyLineDrawing.DrawDiamondLines(e, New PointF(data.StartPoint.X, data.StartPoint.Y), New PointF(data.EndPoint.X, data.EndPoint.Y), True, True, p)

				Dim bounds As RectangleF = data.Bounds
				lockPoint = New PointF(bounds.Width / 2f, bounds.Height / 2f)
				p.Dispose()
			End If

			If e.Device = RenderDevice.Display AndAlso Not annotation.Security Is Nothing AndAlso annotation.Security.Locked AndAlso Not annotation.Security.LockedImage Is Nothing Then
				MyBase.RenderLockImage(annotation.Security.LockedImage, lockPoint, e)
			End If

			MyBase.RestoreGraphicsTransform(e)
		End Sub
	End Class

	Public Class DiamondRectangleRenderingEngine
		Inherits RectangleRenderingEngine
		' Implementation of RectangleRenderingEngine using a "stylish" appearance
		Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As RenderEnvironment)
			' check args
			If annotation Is Nothing Then
				Throw New ArgumentNullException("annotation")
			End If

			If e Is Nothing Then
				Throw New ArgumentNullException("e")
			End If

			Dim data As RectangleData = CType(IIf(TypeOf annotation Is RectangleData, annotation, Nothing), RectangleData)
			If data Is Nothing Then
				Throw New ArgumentException("Only RectangleData objects can be rendered using the RectangleRenderingEngine.", "annotation")
			End If

			If (Not annotation.Visible) Then
			Return
			End If

			MyBase.SetGraphicsTransform(annotation, e)

			Dim rect As RectangleF = CorrectRectangle(New RectangleF(0, 0, data.Size.Width, data.Size.Height))

			Dim fill As Brush = CreateBrush(data.Fill)

			' fill if need be
			If Not fill Is Nothing Then
				e.Graphics.FillRectangle(fill, rect)
			End If

			Dim p As Pen = CreatePen(data.Outline)
			If Not p Is Nothing Then
				' get the top-left, top-right, bottom-left, and bottom-right points of the rect and draw them
				Dim tl As PointF = rect.Location
				Dim tr As PointF = New PointF(rect.Right, rect.Top)
				Dim bl As PointF = New PointF(rect.Left, rect.Bottom)
				Dim br As PointF = New PointF(rect.Right, rect.Bottom)

				' end points on top and bottom
				ClassyLineDrawing.DrawDiamondLines(e, tl, tr, True, True, p)
				ClassyLineDrawing.DrawDiamondLines(e, bl, br, True, True, p)

				' no end points needed on the sides
				ClassyLineDrawing.DrawDiamondLines(e, tl, bl, False, False, p)
				ClassyLineDrawing.DrawDiamondLines(e, tr, br, False, False, p)
				p.Dispose()
			End If

			If e.Device = RenderDevice.Display AndAlso Not annotation.Security Is Nothing AndAlso annotation.Security.Locked AndAlso Not annotation.Security.LockedImage Is Nothing Then
				MyBase.RenderLockImage(annotation.Security.LockedImage, rect, e)
			End If

			MyBase.RestoreGraphicsTransform(e)

		End Sub
	End Class

	Public Class DiamondPolygonRenderingEngine
		Inherits PolygonRenderingEngine
		' Implementation of a polygon rendering engine using a "stylish" appearance
		Public Overrides Sub RenderAnnotation(ByVal annotation As AnnotationData, ByVal e As RenderEnvironment)
			' check args
			If annotation Is Nothing Then
				Throw New ArgumentNullException("annotation")
			End If

			If e Is Nothing Then
				Throw New ArgumentNullException("e")
			End If

			Dim polygon As PolygonData = CType(IIf(TypeOf annotation Is PolygonData, annotation, Nothing), PolygonData)
			If polygon Is Nothing Then
				Throw New ArgumentException("Only PolygonData objects can be rendered using the PolygonRenderingEngine.", "annotation")
			End If

			If (Not annotation.Visible) Then
			Return
			End If
			If polygon.Points Is Nothing OrElse polygon.Points.Count < 2 Then
			Return
			End If


			MyBase.SetGraphicsTransform(annotation, e)

			' get the points
            Dim pts As PointF() = polygon.Points.ToArray()
			Dim lockPoint As PointF = pts(0)


			' non-degenerate case (filled and more than two points)
			If Not polygon.Fill Is Nothing AndAlso pts.Length > 2 Then
				Dim fill As Brush = CreateBrush(polygon.Fill)
				If Not fill Is Nothing Then
					e.Graphics.FillPolygon(fill, pts)
					fill.Dispose()
				End If
			End If

			Dim p As Pen = CreatePen(polygon.Outline)
			If Not p Is Nothing Then
				' degenerate case - single line
				If pts.Length = 2 Then
					ClassyLineDrawing.DrawDiamondLines(e, pts(0), pts(1), True, True, p)
				Else
					' many lines
					For i As Integer = 0 To pts.Length - 2
						ClassyLineDrawing.DrawDiamondLines(e, pts(i), pts(i+1), True, False, p)
					Next i
					' connect last to first
					ClassyLineDrawing.DrawDiamondLines(e, pts(pts.Length-1), pts(0), True, False, p)
				End If
				p.Dispose()
			End If
			If e.Device = RenderDevice.Display AndAlso Not annotation.Security Is Nothing AndAlso annotation.Security.Locked AndAlso Not annotation.Security.LockedImage Is Nothing Then
				MyBase.RenderLockImage(annotation.Security.LockedImage, lockPoint, e)
			End If

			MyBase.RestoreGraphicsTransform(e)
		End Sub
	End Class

	Public Class ClassyAnnotationRenderers
		Public Shared Sub InstallClassyRenderers()
			AnnotationRenderers.Add(GetType(LineData), New DiamondLineRenderingEngine())
			AnnotationRenderers.Add(GetType(RectangleData), New DiamondRectangleRenderingEngine())
			AnnotationRenderers.Add(GetType(PolygonData), New DiamondPolygonRenderingEngine())
		End Sub

		Public Shared Sub InstallDefaultRenderers()
			AnnotationRenderers.Add(GetType(LineData), New LineRenderingEngine())
			AnnotationRenderers.Add(GetType(RectangleData), New RectangleRenderingEngine())
			AnnotationRenderers.Add(GetType(PolygonData), New PolygonRenderingEngine())
		End Sub
	End Class
End Namespace
