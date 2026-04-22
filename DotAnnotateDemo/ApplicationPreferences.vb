Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Xml

Namespace DotAnnotateDemo
	Public Class ApplicationPreferences
		Private _template As TemplateManager
		Private _settingsPath As String
		Private _burnConvert As Boolean = True
		Private _multipageSupport As Boolean
		Private _confinement As Atalasoft.Annotate.AnnotationConfinementMode = Atalasoft.Annotate.AnnotationConfinementMode.None
        Private _smoothing As System.Drawing.Drawing2D.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
		Private _keyMoveLeft As System.Windows.Forms.Keys
		Private _keyMoveRight As System.Windows.Forms.Keys
		Private _keyMoveUp As System.Windows.Forms.Keys
		Private _keyMoveDown As System.Windows.Forms.Keys
		Private _keyIncreaseHeight As System.Windows.Forms.Keys
		Private _keyIncreaseWidth As System.Windows.Forms.Keys
		Private _keyDecreaseHeight As System.Windows.Forms.Keys
		Private _keyDecreaseWidth As System.Windows.Forms.Keys
		Private _keyClearSelection As System.Windows.Forms.Keys
		Private _keySelectNext As System.Windows.Forms.Keys
		Private _keySelectPrevious As System.Windows.Forms.Keys
		Private _keySelectLeft As System.Windows.Forms.Keys
		Private _keySelectRight As System.Windows.Forms.Keys
		Private _keySelectAbove As System.Windows.Forms.Keys
		Private _keySelectBelow As System.Windows.Forms.Keys
		Private _keyRotateClockwise As System.Windows.Forms.Keys
		Private _keyRotateCounterclockwise As System.Windows.Forms.Keys
		Private _multiSelectKey As System.Windows.Forms.Keys
        Private _units As Atalasoft.Annotate.AnnotationUnit = Atalasoft.Annotate.AnnotationUnit.Pixel
		Private _rotationSnapInterval As Single
		Private _rotationSnapThreshold As Single

		Public Sub New()
		End Sub

		Public Sub New(ByVal path As String, ByVal template As TemplateManager)
			_settingsPath = path
			_template = template
			LoadPreferences()
		End Sub

		Public Sub LoadPreferences()
			If Not _settingsPath Is Nothing AndAlso File.Exists(_settingsPath) Then
				Dim reader As XmlTextReader = New XmlTextReader(_settingsPath)
				Try
					Do While reader.Read()
						Select Case reader.LocalName
							Case "BurnConvert"
								_burnConvert = Boolean.Parse(reader.ReadString())

							Case "MultipageSupport"
								_multipageSupport = Boolean.Parse(reader.ReadString())

							Case "Confinement"
								_confinement = CType(Integer.Parse(reader.ReadString()), Atalasoft.Annotate.AnnotationConfinementMode)

							Case "Smoothing"
								_smoothing = CType(Integer.Parse(reader.ReadString()), System.Drawing.Drawing2D.SmoothingMode)

							Case "KeyMoveLeft"
								_keyMoveLeft = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyMoveRight"
								_keyMoveRight = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyMoveUp"
								_keyMoveUp = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyMoveDown"
								_keyMoveDown = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyIncreaseHeight"
								_keyIncreaseHeight = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyIncreaseWidth"
								_keyIncreaseWidth = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyDecreaseHeight"
								_keyDecreaseHeight = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyDecreaseWidth"
								_keyDecreaseWidth = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyClearSelection"
								_keyClearSelection = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectLeft"
								_keySelectLeft = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectRight"
								_keySelectRight = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectAbove"
								_keySelectAbove = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectBelow"
								_keySelectBelow = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectNext"
								_keySelectNext = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeySelectPrevious"
								_keySelectPrevious = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyRotateClockwise"
								_keyRotateClockwise = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "KeyRotateCounterclockwise"
								_keyRotateCounterclockwise = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "MultiSelectKey"
								_multiSelectKey = CType(Integer.Parse(reader.ReadString()), System.Windows.Forms.Keys)

							Case "Units"
								_units = CType(Integer.Parse(reader.ReadString()), Atalasoft.Annotate.AnnotationUnit)

							Case "RotationSnapInterval"
								_rotationSnapInterval = Single.Parse(reader.ReadString())

							Case "RotationSnapThreshold"
								_rotationSnapThreshold = Single.Parse(reader.ReadString())

							Case "Template"
								If Not _template Is Nothing Then
									_template.LoadSettings(reader)
								End If
						End Select
					Loop
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show("Error loading preferences:" & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Error")
                Finally
                    reader.Close()
                End Try
            End If
        End Sub

        Public Sub Save()
            If _settingsPath Is Nothing Then
                Return
            End If

            Dim writer As XmlTextWriter = New XmlTextWriter(_settingsPath, System.Text.Encoding.UTF8)
            writer.Formatting = Formatting.Indented

            Try
                writer.WriteStartDocument(True)
                writer.WriteStartElement("Preferences")

                writer.WriteElementString("BurnConvert", _burnConvert.ToString())
                writer.WriteElementString("MultipageSupport", _multipageSupport.ToString())
                writer.WriteElementString("Confinement", (CInt(Fix(_confinement))).ToString())
                writer.WriteElementString("Smoothing", (CInt(Fix(_smoothing))).ToString())
                writer.WriteElementString("KeyMoveLeft", (CInt(Fix(_keyMoveLeft))).ToString())
                writer.WriteElementString("KeyMoveRight", (CInt(Fix(_keyMoveRight))).ToString())
                writer.WriteElementString("KeyMoveUp", (CInt(Fix(_keyMoveUp))).ToString())
                writer.WriteElementString("KeyMoveDown", (CInt(Fix(_keyMoveDown))).ToString())
                writer.WriteElementString("KeyIncreaseHeight", (CInt(Fix(_keyIncreaseHeight))).ToString())
                writer.WriteElementString("KeyIncreaseWidth", (CInt(Fix(_keyIncreaseWidth))).ToString())
                writer.WriteElementString("KeyDecreaseHeight", (CInt(Fix(_keyDecreaseHeight))).ToString())
                writer.WriteElementString("KeyDecreaseWidth", (CInt(Fix(_keyDecreaseWidth))).ToString())
                writer.WriteElementString("KeyClearSelection", (CInt(Fix(_keyClearSelection))).ToString())
                writer.WriteElementString("KeySelectLeft", (CInt(Fix(_keySelectLeft))).ToString())
                writer.WriteElementString("KeySelectRight", (CInt(Fix(_keySelectRight))).ToString())
                writer.WriteElementString("KeySelectAbove", (CInt(Fix(_keySelectAbove))).ToString())
                writer.WriteElementString("KeySelectBelow", (CInt(Fix(_keySelectBelow))).ToString())
                writer.WriteElementString("KeySelectNext", (CInt(Fix(_keySelectNext))).ToString())
                writer.WriteElementString("KeySelectPrevious", (CInt(Fix(_keySelectPrevious))).ToString())
                writer.WriteElementString("KeyRotateClockwise", (CInt(Fix(_keyRotateClockwise))).ToString())
                writer.WriteElementString("KeyRotateCounterclockwise", (CInt(Fix(_keyRotateCounterclockwise))).ToString())
                writer.WriteElementString("MultiSelectKey", (CInt(Fix(_multiSelectKey))).ToString())
                writer.WriteElementString("Units", (CInt(Fix(_units))).ToString())
                writer.WriteElementString("RotationSnapInterval", _rotationSnapInterval.ToString())
                writer.WriteElementString("RotationSnapThreshold", _rotationSnapThreshold.ToString())

                If Not _template Is Nothing Then
                    _template.SaveSettings(writer)
                End If

                writer.WriteEndElement()
                writer.WriteEndDocument()
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show("Error saving preferences:" & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Error")
            Finally
                writer.Close()
            End Try
        End Sub

        Public Function Clone() As ApplicationPreferences
            Dim ap As ApplicationPreferences = New ApplicationPreferences

            ap._burnConvert = Me._burnConvert
            ap._confinement = Me._confinement
            ap._keyClearSelection = Me._keyClearSelection
            ap._keyDecreaseHeight = Me._keyDecreaseHeight
            ap._keyDecreaseWidth = Me._keyDecreaseWidth
            ap._keyIncreaseHeight = Me._keyIncreaseHeight
            ap._keyIncreaseWidth = Me._keyIncreaseWidth
            ap._keyMoveDown = Me._keyMoveDown
            ap._keyMoveLeft = Me._keyMoveLeft
            ap._keyMoveRight = Me._keyMoveRight
            ap._keyMoveUp = Me._keyMoveUp
            ap._keyRotateClockwise = Me._keyRotateClockwise
            ap._keyRotateCounterclockwise = Me._keyRotateCounterclockwise
            ap._keySelectAbove = Me._keySelectAbove
            ap._keySelectBelow = Me._keySelectBelow
            ap._keySelectLeft = Me._keySelectLeft
            ap._keySelectNext = Me._keySelectNext
            ap._keySelectPrevious = Me._keySelectPrevious
            ap._keySelectRight = Me._keySelectRight
            ap._multipageSupport = Me._multipageSupport
            ap._settingsPath = Me._settingsPath
            ap._smoothing = Me._smoothing
            ap._multiSelectKey = Me._multiSelectKey
            ap._units = Me._units
            ap._rotationSnapInterval = Me._rotationSnapInterval
            ap._rotationSnapThreshold = Me._rotationSnapThreshold
            ap._template = Me._template

            Return ap
        End Function

#Region "Properties"

        Public Property RotationSnapInterval() As Single
            Get
                Return _rotationSnapInterval
            End Get
            Set(ByVal Value As Single)
                _rotationSnapInterval = Value
            End Set
        End Property

        Public Property RotationSnapThreshold() As Single
            Get
                Return _rotationSnapThreshold
            End Get
            Set(ByVal Value As Single)
                _rotationSnapThreshold = Value
            End Set
        End Property

        Public Property Units() As Atalasoft.Annotate.AnnotationUnit
            Get
                Return _units
            End Get
            Set(ByVal Value As Atalasoft.Annotate.AnnotationUnit)
                _units = Value
            End Set
        End Property

        Public Property BurnConvert() As Boolean
            Get
                Return _burnConvert
            End Get
            Set(ByVal Value As Boolean)
                _burnConvert = Value
            End Set
        End Property

        Public Property MultipageSupport() As Boolean
            Get
                Return _multipageSupport
            End Get
            Set(ByVal Value As Boolean)
                _multipageSupport = Value
            End Set
        End Property

        Public Property Confinement() As Atalasoft.Annotate.AnnotationConfinementMode
            Get
                Return _confinement
            End Get
            Set(ByVal Value As Atalasoft.Annotate.AnnotationConfinementMode)
                _confinement = Value
            End Set
        End Property

        Public Property Smoothing() As System.Drawing.Drawing2D.SmoothingMode
            Get
                Return _smoothing
            End Get
            Set(ByVal Value As System.Drawing.Drawing2D.SmoothingMode)
                _smoothing = Value
            End Set
        End Property

        Public Property KeyMoveLeft() As System.Windows.Forms.Keys
            Get
                Return _keyMoveLeft
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyMoveLeft = Value
            End Set
        End Property

        Public Property KeyMoveRight() As System.Windows.Forms.Keys
            Get
                Return _keyMoveRight
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyMoveRight = Value
            End Set
        End Property

        Public Property KeyMoveUp() As System.Windows.Forms.Keys
            Get
                Return _keyMoveUp
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyMoveUp = Value
            End Set
        End Property

        Public Property KeyMoveDown() As System.Windows.Forms.Keys
            Get
                Return _keyMoveDown
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyMoveDown = Value
            End Set
        End Property

        Public Property KeyIncreaseHeight() As System.Windows.Forms.Keys
            Get
                Return _keyIncreaseHeight
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyIncreaseHeight = Value
            End Set
        End Property

        Public Property KeyIncreaseWidth() As System.Windows.Forms.Keys
            Get
                Return _keyIncreaseWidth
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyIncreaseWidth = Value
            End Set
        End Property

        Public Property KeyDecreaseHeight() As System.Windows.Forms.Keys
            Get
                Return _keyDecreaseHeight
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyDecreaseHeight = Value
            End Set
        End Property

        Public Property KeyDecreaseWidth() As System.Windows.Forms.Keys
            Get
                Return _keyDecreaseWidth
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyDecreaseWidth = Value
            End Set
        End Property

        Public Property KeyRotateClockwise() As System.Windows.Forms.Keys
            Get
                Return _keyRotateClockwise
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyRotateClockwise = Value
            End Set
        End Property

        Public Property KeyRotateCounterclockwise() As System.Windows.Forms.Keys
            Get
                Return _keyRotateCounterclockwise
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyRotateCounterclockwise = Value
            End Set
        End Property

        Public Property KeyClearSelection() As System.Windows.Forms.Keys
            Get
                Return _keyClearSelection
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keyClearSelection = Value
            End Set
        End Property

        Public Property KeySelectNext() As System.Windows.Forms.Keys
            Get
                Return _keySelectNext
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectNext = Value
            End Set
        End Property

        Public Property KeySelectPrevious() As System.Windows.Forms.Keys
            Get
                Return _keySelectPrevious
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectPrevious = Value
            End Set
        End Property

        Public Property KeySelectLeft() As System.Windows.Forms.Keys
            Get
                Return _keySelectLeft
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectLeft = Value
            End Set
        End Property

        Public Property KeySelectRight() As System.Windows.Forms.Keys
            Get
                Return _keySelectRight
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectRight = Value
            End Set
        End Property

        Public Property KeySelectAbove() As System.Windows.Forms.Keys
            Get
                Return _keySelectAbove
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectAbove = Value
            End Set
        End Property

        Public Property KeySelectBelow() As System.Windows.Forms.Keys
            Get
                Return _keySelectBelow
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _keySelectBelow = Value
            End Set
        End Property

        Public Property MultiSelectKey() As System.Windows.Forms.Keys
            Get
                Return _multiSelectKey
            End Get
            Set(ByVal Value As System.Windows.Forms.Keys)
                _multiSelectKey = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
