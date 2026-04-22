Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.UI

Namespace DotAnnotateDemo
	Public Class TemplateManager
		Private _fill As AnnotationBrush = New AnnotationBrush(Color.White)
		Private _outline As AnnotationPen = New AnnotationPen(Color.Black, 1)
		Private _font As AnnotationFont = New AnnotationFont()
		Private _shadow As AnnotationBrush = Nothing
		Private _text As String = "Atalasoft DotAnnotate"
		Private _shadowOffset As PointF = New PointF(6, 6)
		Private _fontBrush As AnnotationBrush = New AnnotationBrush(Color.Black)

		Public Sub New()
		End Sub

		Public Sub SaveSettings(ByVal writer As XmlTextWriter)
			writer.WriteStartElement("Template")

			If Not _fill Is Nothing Then
			SerializeObject(writer, "Fill", _fill)
			End If
			If Not _outline Is Nothing Then
			SerializeObject(writer, "Outline", _outline)
			End If
			If Not _font Is Nothing Then
			SerializeObject(writer, "Font", _font)
			End If
			If Not _shadow Is Nothing Then
			SerializeObject(writer, "Shadow", _shadow)
			End If
			If Not _fontBrush Is Nothing Then
			SerializeObject(writer, "FontBrush", _fontBrush)
			End If

			writer.WriteElementString("Text", _text)
			writer.WriteElementString("ShadowOffset", _shadowOffset.X.ToString() & "," & _shadowOffset.Y.ToString())

			writer.WriteEndElement()
		End Sub

		Private Sub SerializeObject(ByVal writer As XmlTextWriter, ByVal element As String, ByVal obj As Object)
			Dim formatter As BinaryFormatter = New BinaryFormatter()
			Dim ms As MemoryStream = New MemoryStream()
			Try
				formatter.Serialize(ms, obj)
				Dim data As Byte() = ms.ToArray()

				writer.WriteStartElement(element)
				writer.WriteBinHex(data, 0, data.Length)
				writer.WriteEndElement()
			Finally
				ms.Close()
			End Try
		End Sub

		Private Function DeserializeObject(ByVal reader As XmlTextReader) As Object
			Dim formatter As BinaryFormatter = New BinaryFormatter()
			formatter.Binder = New CustomDataBinder()
			Dim ms As MemoryStream = New MemoryStream()
			Try
				' It's a shame that you have to guess at the size.
				Dim len As Integer = 4096
				Dim buffer As Byte() = New Byte(len - 1){}
				Do
					len = reader.ReadBinHex(buffer, 0, len)
					ms.Write(buffer, 0, len)
				Loop While len = 4096

				If ms.Length > 0 Then
					ms.Seek(0, SeekOrigin.Begin)
					Return formatter.Deserialize(ms)
				Else
					Return Nothing
				End If
			Finally
				ms.Close()
			End Try
		End Function

		Public Sub LoadSettings(ByVal reader As XmlTextReader)
			Dim working As Boolean = True
			Do While reader.Read()
				Select Case reader.LocalName
					Case "Template"
						If (Not reader.IsStartElement()) Then
						working = False
						End If

					Case "Fill"
						_fill = CType(DeserializeObject(reader), AnnotationBrush)

					Case "Outline"
						_outline = CType(DeserializeObject(reader), AnnotationPen)

					Case "Font"
						_font = CType(DeserializeObject(reader), AnnotationFont)

					Case "Shadow"
						_shadow = CType(DeserializeObject(reader), AnnotationBrush)

					Case "FontBrush"
						_fontBrush = CType(DeserializeObject(reader), AnnotationBrush)

					Case "Text"
						_text = reader.ReadString()

					Case "ShadowOffset"
						Dim p As String = reader.ReadString()
						Dim pos As Integer = p.IndexOf(",")
						If pos > -1 Then
							_shadowOffset = New PointF(Single.Parse(p.Substring(0, pos)), Single.Parse(p.Substring(pos + 1)))
						End If
				End Select

				If (Not working) Then
				Exit Do
				End If
			Loop
		End Sub

		<Description("The default fill for annotations.")> _
		Public Property Fill() As AnnotationBrush
			Get
				Return Me._fill
			End Get
			Set
				Me._fill = Value
			End Set
		End Property

		<Description("The default outline for annotations.")> _
		Public Property Outline() As AnnotationPen
			Get
				Return Me._outline
			End Get
			Set
				Me._outline = Value
			End Set
		End Property

		<Description("The default shadow for annotations.")> _
		Public Property Shadow() As AnnotationBrush
			Get
				Return Me._shadow
			End Get
			Set
				Me._shadow = Value
			End Set
		End Property

		<Description("The default font for Text Annotations.")> _
		Public Property Font() As AnnotationFont
			Get
				Return Me._font
			End Get
			Set
				Me._font = Value
			End Set
		End Property

		<Description("The default text for Text Annotations.")> _
		Public Property Text() As String
			Get
				Return Me._text
			End Get
			Set
				Me._text = Value
			End Set
		End Property

		<Description("The default brush used for text.")> _
		Public Property FontBrush() As AnnotationBrush
			Get
				Return Me._fontBrush
			End Get
			Set
				Me._fontBrush = Value
			End Set
		End Property

		<Description("The distance to offset the shadow from the annotation."), TypeConverter(GetType(Atalasoft.Converters.PointFTypeConverter))> _
		Public Property ShadowOffset() As PointF
			Get
				Return Me._shadowOffset
			End Get
			Set
				Me._shadowOffset = Value
			End Set
		End Property

		Public Sub SetAnnotationDefaults(ByVal annotation As AnnotationUI)
			' There are probably several ways to handle this.
			' We're just going to use reflection to search for
			' specific property names and types.
			Dim t As Type = annotation.GetType()

			If Me._fill Is Nothing Then
				SetProperty(t, "Fill", annotation, GetType(AnnotationBrush), (Nothing))
			Else
				SetProperty(t, "Fill", annotation, GetType(AnnotationBrush), (Me._fill.Clone()))
			End If
			If Me._outline Is Nothing Then
				SetProperty(t, "Outline", annotation, GetType(AnnotationPen), (Nothing))
			Else
				SetProperty(t, "Outline", annotation, GetType(AnnotationPen), (Me._outline.Clone()))
			End If
			If Me._shadow Is Nothing Then
				SetProperty(t, "Shadow", annotation, GetType(AnnotationBrush), (Nothing))
			Else
				SetProperty(t, "Shadow", annotation, GetType(AnnotationBrush), (Me._shadow.Clone()))
			End If
			SetProperty(t, "ShadowOffset", annotation, GetType(PointF), Me._shadowOffset)
			If Me._font Is Nothing Then
				SetProperty(t, "Font", annotation, GetType(AnnotationFont), (Nothing))
			Else
				SetProperty(t, "Font", annotation, GetType(AnnotationFont), (Me._font.Clone()))
			End If
			SetProperty(t, "Text", annotation, GetType(String), Me._text)
			If Me._fontBrush Is Nothing Then
				SetProperty(t, "FontBrush", annotation, GetType(AnnotationBrush), (Nothing))
			Else
				SetProperty(t, "FontBrush", annotation, GetType(AnnotationBrush), (Me._fontBrush.Clone()))
			End If
		End Sub

		Private Sub SetProperty(ByVal annType As Type, ByVal propertyName As String, ByVal annotation As AnnotationUI, ByVal valueType As Type, ByVal value As Object)
			Dim info As PropertyInfo = annType.GetProperty(propertyName)
			If Not info Is Nothing AndAlso info.CanWrite Then
				If info.PropertyType Is valueType Then
					info.SetValue(annotation, value, Nothing)
				End If
			End If
		End Sub
	End Class

	' This is used to keep the BinaryFormatter from crying about any version change.
	Public Class CustomDataBinder
		Inherits SerializationBinder
		Public Sub New()
		End Sub

		Public Overrides Function BindToType(ByVal assemblyName As String, ByVal typeName As String) As Type
			' We will just ignore the version.
			Dim pos As Integer = assemblyName.IndexOf(",")
			If pos = -1 Then
			Return Nothing
			End If

            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load(assemblyName.Substring(0, pos))
			If asm Is Nothing Then
			Return Nothing
			End If

			Return asm.GetType(typeName)
		End Function

	End Class
End Namespace
