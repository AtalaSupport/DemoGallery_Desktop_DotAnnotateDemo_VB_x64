Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace DotAnnotateDemo
	''' <summary>
	''' Summary description for Preferences.
	''' </summary>
	Public Class Preferences
		Inherits System.Windows.Forms.Form
		Private _settings As ApplicationPreferences
		Private tabControl1 As System.Windows.Forms.TabControl
		Private btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private tabPage1 As System.Windows.Forms.TabPage
		Private tabPage2 As System.Windows.Forms.TabPage
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label12 As System.Windows.Forms.Label
		Private label13 As System.Windows.Forms.Label
		Private label14 As System.Windows.Forms.Label
		Private label15 As System.Windows.Forms.Label
		Private label16 As System.Windows.Forms.Label
		Private label17 As System.Windows.Forms.Label
		Private WithEvents textMoveUp As System.Windows.Forms.TextBox
		Private WithEvents textMoveDown As System.Windows.Forms.TextBox
		Private WithEvents textMoveLeft As System.Windows.Forms.TextBox
		Private WithEvents textMoveRight As System.Windows.Forms.TextBox
		Private WithEvents textDecreaseHeight As System.Windows.Forms.TextBox
		Private WithEvents textDecreaseWidth As System.Windows.Forms.TextBox
		Private WithEvents textIncreaseHeight As System.Windows.Forms.TextBox
		Private WithEvents textIncreaseWidth As System.Windows.Forms.TextBox
		Private WithEvents textSelectNext As System.Windows.Forms.TextBox
		Private WithEvents textSelectPrevious As System.Windows.Forms.TextBox
		Private WithEvents textSelectLeft As System.Windows.Forms.TextBox
		Private WithEvents textSelectRight As System.Windows.Forms.TextBox
		Private WithEvents textSelectAbove As System.Windows.Forms.TextBox
		Private WithEvents textSelectBelow As System.Windows.Forms.TextBox
		Private WithEvents textRotateClockwise As System.Windows.Forms.TextBox
		Private WithEvents textRotateCounterclockwise As System.Windows.Forms.TextBox
		Private WithEvents textClearSelection As System.Windows.Forms.TextBox
		Private WithEvents chkBurnConvert As System.Windows.Forms.CheckBox
		Private WithEvents chkMultipageSupport As System.Windows.Forms.CheckBox
		Private label18 As System.Windows.Forms.Label
		Private WithEvents cboConfinement As System.Windows.Forms.ComboBox
		Private label19 As System.Windows.Forms.Label
		Private WithEvents cboSmoothing As System.Windows.Forms.ComboBox
		Private label20 As System.Windows.Forms.Label
		Private WithEvents textMultiSelectKey As System.Windows.Forms.TextBox
		Private label21 As System.Windows.Forms.Label
		Private WithEvents cboUnits As System.Windows.Forms.ComboBox
		Private label22 As System.Windows.Forms.Label
		Private WithEvents textRotationSnapInterval As System.Windows.Forms.TextBox
		Private label23 As System.Windows.Forms.Label
		Private WithEvents textRotationSnapThreshold As System.Windows.Forms.TextBox
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

        Public Sub New(ByVal preferences As ApplicationPreferences)
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            _settings = preferences.Clone()
            SetControlValues()
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.tabControl1 = New System.Windows.Forms.TabControl
            Me.tabPage1 = New System.Windows.Forms.TabPage
            Me.cboUnits = New System.Windows.Forms.ComboBox
            Me.label21 = New System.Windows.Forms.Label
            Me.textMultiSelectKey = New System.Windows.Forms.TextBox
            Me.label20 = New System.Windows.Forms.Label
            Me.cboSmoothing = New System.Windows.Forms.ComboBox
            Me.label19 = New System.Windows.Forms.Label
            Me.cboConfinement = New System.Windows.Forms.ComboBox
            Me.label18 = New System.Windows.Forms.Label
            Me.chkMultipageSupport = New System.Windows.Forms.CheckBox
            Me.chkBurnConvert = New System.Windows.Forms.CheckBox
            Me.tabPage2 = New System.Windows.Forms.TabPage
            Me.textClearSelection = New System.Windows.Forms.TextBox
            Me.label17 = New System.Windows.Forms.Label
            Me.textRotateCounterclockwise = New System.Windows.Forms.TextBox
            Me.label16 = New System.Windows.Forms.Label
            Me.textIncreaseWidth = New System.Windows.Forms.TextBox
            Me.label15 = New System.Windows.Forms.Label
            Me.textRotateClockwise = New System.Windows.Forms.TextBox
            Me.label14 = New System.Windows.Forms.Label
            Me.textIncreaseHeight = New System.Windows.Forms.TextBox
            Me.label13 = New System.Windows.Forms.Label
            Me.textSelectBelow = New System.Windows.Forms.TextBox
            Me.label12 = New System.Windows.Forms.Label
            Me.textDecreaseWidth = New System.Windows.Forms.TextBox
            Me.label11 = New System.Windows.Forms.Label
            Me.textSelectAbove = New System.Windows.Forms.TextBox
            Me.label10 = New System.Windows.Forms.Label
            Me.textSelectRight = New System.Windows.Forms.TextBox
            Me.label9 = New System.Windows.Forms.Label
            Me.textSelectLeft = New System.Windows.Forms.TextBox
            Me.label8 = New System.Windows.Forms.Label
            Me.textSelectPrevious = New System.Windows.Forms.TextBox
            Me.label7 = New System.Windows.Forms.Label
            Me.textSelectNext = New System.Windows.Forms.TextBox
            Me.label6 = New System.Windows.Forms.Label
            Me.textDecreaseHeight = New System.Windows.Forms.TextBox
            Me.label5 = New System.Windows.Forms.Label
            Me.textMoveRight = New System.Windows.Forms.TextBox
            Me.label4 = New System.Windows.Forms.Label
            Me.textMoveLeft = New System.Windows.Forms.TextBox
            Me.label3 = New System.Windows.Forms.Label
            Me.textMoveDown = New System.Windows.Forms.TextBox
            Me.label2 = New System.Windows.Forms.Label
            Me.textMoveUp = New System.Windows.Forms.TextBox
            Me.label1 = New System.Windows.Forms.Label
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.label22 = New System.Windows.Forms.Label
            Me.textRotationSnapInterval = New System.Windows.Forms.TextBox
            Me.label23 = New System.Windows.Forms.Label
            Me.textRotationSnapThreshold = New System.Windows.Forms.TextBox
            Me.tabControl1.SuspendLayout()
            Me.tabPage1.SuspendLayout()
            Me.tabPage2.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' tabControl1
            ' 
            Me.tabControl1.Controls.Add(Me.tabPage1)
            Me.tabControl1.Controls.Add(Me.tabPage2)
            Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.tabControl1.Location = New System.Drawing.Point(0, 0)
            Me.tabControl1.Name = "tabControl1"
            Me.tabControl1.SelectedIndex = 0
            Me.tabControl1.Size = New System.Drawing.Size(554, 264)
            Me.tabControl1.TabIndex = 0
            ' 
            ' tabPage1
            ' 
            Me.tabPage1.Controls.Add(Me.textRotationSnapThreshold)
            Me.tabPage1.Controls.Add(Me.label23)
            Me.tabPage1.Controls.Add(Me.textRotationSnapInterval)
            Me.tabPage1.Controls.Add(Me.label22)
            Me.tabPage1.Controls.Add(Me.cboUnits)
            Me.tabPage1.Controls.Add(Me.label21)
            Me.tabPage1.Controls.Add(Me.textMultiSelectKey)
            Me.tabPage1.Controls.Add(Me.label20)
            Me.tabPage1.Controls.Add(Me.cboSmoothing)
            Me.tabPage1.Controls.Add(Me.label19)
            Me.tabPage1.Controls.Add(Me.cboConfinement)
            Me.tabPage1.Controls.Add(Me.label18)
            Me.tabPage1.Controls.Add(Me.chkMultipageSupport)
            Me.tabPage1.Controls.Add(Me.chkBurnConvert)
            Me.tabPage1.Location = New System.Drawing.Point(4, 22)
            Me.tabPage1.Name = "tabPage1"
            Me.tabPage1.Size = New System.Drawing.Size(546, 238)
            Me.tabPage1.TabIndex = 0
            Me.tabPage1.Text = "General"
            ' 
            ' cboUnits
            ' 
            Me.cboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboUnits.Items.AddRange(New Object() {"Pixel", "Inch", "Micrometer", "Centimeter", "Foot", "Yard", "Meter", "Mile", "Kilometer"})
            Me.cboUnits.Location = New System.Drawing.Point(392, 96)
            Me.cboUnits.Name = "cboUnits"
            Me.cboUnits.Size = New System.Drawing.Size(136, 21)
            Me.cboUnits.TabIndex = 9
            '			Me.cboUnits.SelectedIndexChanged += New System.EventHandler(Me.cboUnits_SelectedIndexChanged);
            ' 
            ' label21
            ' 
            Me.label21.Location = New System.Drawing.Point(264, 96)
            Me.label21.Name = "label21"
            Me.label21.Size = New System.Drawing.Size(96, 21)
            Me.label21.TabIndex = 8
            Me.label21.Text = "Units Of Measure:"
            Me.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textMultiSelectKey
            ' 
            Me.textMultiSelectKey.Location = New System.Drawing.Point(392, 72)
            Me.textMultiSelectKey.Name = "textMultiSelectKey"
            Me.textMultiSelectKey.Size = New System.Drawing.Size(136, 20)
            Me.textMultiSelectKey.TabIndex = 7
            Me.textMultiSelectKey.Text = ""
            Me.textMultiSelectKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textMultiSelectKey.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textMultiSelectKey.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label20
            ' 
            Me.label20.Location = New System.Drawing.Point(264, 72)
            Me.label20.Name = "label20"
            Me.label20.Size = New System.Drawing.Size(120, 20)
            Me.label20.TabIndex = 6
            Me.label20.Text = "Multi-select Key:"
            Me.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' cboSmoothing
            ' 
            Me.cboSmoothing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSmoothing.Items.AddRange(New Object() {"None", "AntiAlias", "Default", "HighQuality", "HighSpeed"})
            Me.cboSmoothing.Location = New System.Drawing.Point(392, 48)
            Me.cboSmoothing.Name = "cboSmoothing"
            Me.cboSmoothing.Size = New System.Drawing.Size(136, 21)
            Me.cboSmoothing.TabIndex = 5
            '			Me.cboSmoothing.SelectedIndexChanged += New System.EventHandler(Me.cboSmoothing_SelectedIndexChanged);
            ' 
            ' label19
            ' 
            Me.label19.Location = New System.Drawing.Point(264, 48)
            Me.label19.Name = "label19"
            Me.label19.Size = New System.Drawing.Size(120, 21)
            Me.label19.TabIndex = 4
            Me.label19.Text = "Smoothing Mode:"
            Me.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' cboConfinement
            ' 
            Me.cboConfinement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboConfinement.Items.AddRange(New Object() {"None", "ClientArea", "DocumentBounds"})
            Me.cboConfinement.Location = New System.Drawing.Point(392, 24)
            Me.cboConfinement.Name = "cboConfinement"
            Me.cboConfinement.Size = New System.Drawing.Size(136, 21)
            Me.cboConfinement.TabIndex = 3
            '			Me.cboConfinement.SelectedIndexChanged += New System.EventHandler(Me.cboConfinement_SelectedIndexChanged);
            ' 
            ' label18
            ' 
            Me.label18.Location = New System.Drawing.Point(264, 24)
            Me.label18.Name = "label18"
            Me.label18.Size = New System.Drawing.Size(136, 21)
            Me.label18.TabIndex = 2
            Me.label18.Text = "Annotation Confinement:"
            Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' chkMultipageSupport
            ' 
            Me.chkMultipageSupport.Location = New System.Drawing.Point(24, 48)
            Me.chkMultipageSupport.Name = "chkMultipageSupport"
            Me.chkMultipageSupport.Size = New System.Drawing.Size(168, 16)
            Me.chkMultipageSupport.TabIndex = 1
            Me.chkMultipageSupport.Text = "Multipage Annotate Support"
            '			Me.chkMultipageSupport.CheckedChanged += New System.EventHandler(Me.chkMultipageSupport_CheckedChanged);
            ' 
            ' chkBurnConvert
            ' 
            Me.chkBurnConvert.Location = New System.Drawing.Point(24, 24)
            Me.chkBurnConvert.Name = "chkBurnConvert"
            Me.chkBurnConvert.Size = New System.Drawing.Size(208, 16)
            Me.chkBurnConvert.TabIndex = 0
            Me.chkBurnConvert.Text = "Convert Pixel Format When Burning"
            '			Me.chkBurnConvert.CheckedChanged += New System.EventHandler(Me.chkBurnConvert_CheckedChanged);
            ' 
            ' tabPage2
            ' 
            Me.tabPage2.Controls.Add(Me.textClearSelection)
            Me.tabPage2.Controls.Add(Me.label17)
            Me.tabPage2.Controls.Add(Me.textRotateCounterclockwise)
            Me.tabPage2.Controls.Add(Me.label16)
            Me.tabPage2.Controls.Add(Me.textIncreaseWidth)
            Me.tabPage2.Controls.Add(Me.label15)
            Me.tabPage2.Controls.Add(Me.textRotateClockwise)
            Me.tabPage2.Controls.Add(Me.label14)
            Me.tabPage2.Controls.Add(Me.textIncreaseHeight)
            Me.tabPage2.Controls.Add(Me.label13)
            Me.tabPage2.Controls.Add(Me.textSelectBelow)
            Me.tabPage2.Controls.Add(Me.label12)
            Me.tabPage2.Controls.Add(Me.textDecreaseWidth)
            Me.tabPage2.Controls.Add(Me.label11)
            Me.tabPage2.Controls.Add(Me.textSelectAbove)
            Me.tabPage2.Controls.Add(Me.label10)
            Me.tabPage2.Controls.Add(Me.textSelectRight)
            Me.tabPage2.Controls.Add(Me.label9)
            Me.tabPage2.Controls.Add(Me.textSelectLeft)
            Me.tabPage2.Controls.Add(Me.label8)
            Me.tabPage2.Controls.Add(Me.textSelectPrevious)
            Me.tabPage2.Controls.Add(Me.label7)
            Me.tabPage2.Controls.Add(Me.textSelectNext)
            Me.tabPage2.Controls.Add(Me.label6)
            Me.tabPage2.Controls.Add(Me.textDecreaseHeight)
            Me.tabPage2.Controls.Add(Me.label5)
            Me.tabPage2.Controls.Add(Me.textMoveRight)
            Me.tabPage2.Controls.Add(Me.label4)
            Me.tabPage2.Controls.Add(Me.textMoveLeft)
            Me.tabPage2.Controls.Add(Me.label3)
            Me.tabPage2.Controls.Add(Me.textMoveDown)
            Me.tabPage2.Controls.Add(Me.label2)
            Me.tabPage2.Controls.Add(Me.textMoveUp)
            Me.tabPage2.Controls.Add(Me.label1)
            Me.tabPage2.Location = New System.Drawing.Point(4, 22)
            Me.tabPage2.Name = "tabPage2"
            Me.tabPage2.Size = New System.Drawing.Size(546, 238)
            Me.tabPage2.TabIndex = 1
            Me.tabPage2.Text = "Key Bindings"
            ' 
            ' textClearSelection
            ' 
            Me.textClearSelection.Location = New System.Drawing.Point(112, 208)
            Me.textClearSelection.Name = "textClearSelection"
            Me.textClearSelection.Size = New System.Drawing.Size(120, 20)
            Me.textClearSelection.TabIndex = 33
            Me.textClearSelection.Text = "None"
            Me.textClearSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textClearSelection.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textClearSelection.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label17
            ' 
            Me.label17.Location = New System.Drawing.Point(16, 208)
            Me.label17.Name = "label17"
            Me.label17.Size = New System.Drawing.Size(96, 20)
            Me.label17.TabIndex = 32
            Me.label17.Text = "Clear Selection:"
            Me.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textRotateCounterclockwise
            ' 
            Me.textRotateCounterclockwise.Location = New System.Drawing.Point(408, 184)
            Me.textRotateCounterclockwise.Name = "textRotateCounterclockwise"
            Me.textRotateCounterclockwise.Size = New System.Drawing.Size(120, 20)
            Me.textRotateCounterclockwise.TabIndex = 31
            Me.textRotateCounterclockwise.Text = "None"
            Me.textRotateCounterclockwise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textRotateCounterclockwise.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textRotateCounterclockwise.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label16
            ' 
            Me.label16.Location = New System.Drawing.Point(272, 184)
            Me.label16.Name = "label16"
            Me.label16.Size = New System.Drawing.Size(136, 20)
            Me.label16.TabIndex = 30
            Me.label16.Text = "Rotate Counterclockwise:"
            Me.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textIncreaseWidth
            ' 
            Me.textIncreaseWidth.Location = New System.Drawing.Point(112, 184)
            Me.textIncreaseWidth.Name = "textIncreaseWidth"
            Me.textIncreaseWidth.Size = New System.Drawing.Size(120, 20)
            Me.textIncreaseWidth.TabIndex = 29
            Me.textIncreaseWidth.Text = "None"
            Me.textIncreaseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textIncreaseWidth.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textIncreaseWidth.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label15
            ' 
            Me.label15.Location = New System.Drawing.Point(16, 184)
            Me.label15.Name = "label15"
            Me.label15.Size = New System.Drawing.Size(96, 20)
            Me.label15.TabIndex = 28
            Me.label15.Text = "Increase Width:"
            Me.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textRotateClockwise
            ' 
            Me.textRotateClockwise.Location = New System.Drawing.Point(408, 160)
            Me.textRotateClockwise.Name = "textRotateClockwise"
            Me.textRotateClockwise.Size = New System.Drawing.Size(120, 20)
            Me.textRotateClockwise.TabIndex = 27
            Me.textRotateClockwise.Text = "None"
            Me.textRotateClockwise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textRotateClockwise.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textRotateClockwise.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label14
            ' 
            Me.label14.Location = New System.Drawing.Point(272, 160)
            Me.label14.Name = "label14"
            Me.label14.Size = New System.Drawing.Size(136, 20)
            Me.label14.TabIndex = 26
            Me.label14.Text = "Rotate Clockwise:"
            Me.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textIncreaseHeight
            ' 
            Me.textIncreaseHeight.Location = New System.Drawing.Point(112, 160)
            Me.textIncreaseHeight.Name = "textIncreaseHeight"
            Me.textIncreaseHeight.Size = New System.Drawing.Size(120, 20)
            Me.textIncreaseHeight.TabIndex = 25
            Me.textIncreaseHeight.Text = "None"
            Me.textIncreaseHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textIncreaseHeight.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textIncreaseHeight.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label13
            ' 
            Me.label13.Location = New System.Drawing.Point(16, 160)
            Me.label13.Name = "label13"
            Me.label13.Size = New System.Drawing.Size(96, 20)
            Me.label13.TabIndex = 24
            Me.label13.Text = "Increase Height:"
            Me.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectBelow
            ' 
            Me.textSelectBelow.Location = New System.Drawing.Point(408, 136)
            Me.textSelectBelow.Name = "textSelectBelow"
            Me.textSelectBelow.Size = New System.Drawing.Size(120, 20)
            Me.textSelectBelow.TabIndex = 23
            Me.textSelectBelow.Text = "None"
            Me.textSelectBelow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectBelow.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectBelow.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label12
            ' 
            Me.label12.Location = New System.Drawing.Point(272, 136)
            Me.label12.Name = "label12"
            Me.label12.Size = New System.Drawing.Size(136, 20)
            Me.label12.TabIndex = 22
            Me.label12.Text = "Select Below:"
            Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textDecreaseWidth
            ' 
            Me.textDecreaseWidth.Location = New System.Drawing.Point(112, 136)
            Me.textDecreaseWidth.Name = "textDecreaseWidth"
            Me.textDecreaseWidth.Size = New System.Drawing.Size(120, 20)
            Me.textDecreaseWidth.TabIndex = 21
            Me.textDecreaseWidth.Text = "None"
            Me.textDecreaseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textDecreaseWidth.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textDecreaseWidth.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label11
            ' 
            Me.label11.Location = New System.Drawing.Point(16, 136)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(96, 20)
            Me.label11.TabIndex = 20
            Me.label11.Text = "Decrease Width:"
            Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectAbove
            ' 
            Me.textSelectAbove.Location = New System.Drawing.Point(408, 112)
            Me.textSelectAbove.Name = "textSelectAbove"
            Me.textSelectAbove.Size = New System.Drawing.Size(120, 20)
            Me.textSelectAbove.TabIndex = 19
            Me.textSelectAbove.Text = "None"
            Me.textSelectAbove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectAbove.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectAbove.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label10
            ' 
            Me.label10.Location = New System.Drawing.Point(272, 112)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(136, 20)
            Me.label10.TabIndex = 18
            Me.label10.Text = "Select Above:"
            Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectRight
            ' 
            Me.textSelectRight.Location = New System.Drawing.Point(408, 88)
            Me.textSelectRight.Name = "textSelectRight"
            Me.textSelectRight.Size = New System.Drawing.Size(120, 20)
            Me.textSelectRight.TabIndex = 17
            Me.textSelectRight.Text = "None"
            Me.textSelectRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectRight.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectRight.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label9
            ' 
            Me.label9.Location = New System.Drawing.Point(272, 88)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(136, 20)
            Me.label9.TabIndex = 16
            Me.label9.Text = "Select Right:"
            Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectLeft
            ' 
            Me.textSelectLeft.Location = New System.Drawing.Point(408, 64)
            Me.textSelectLeft.Name = "textSelectLeft"
            Me.textSelectLeft.Size = New System.Drawing.Size(120, 20)
            Me.textSelectLeft.TabIndex = 15
            Me.textSelectLeft.Text = "None"
            Me.textSelectLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectLeft.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectLeft.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label8
            ' 
            Me.label8.Location = New System.Drawing.Point(272, 64)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(136, 20)
            Me.label8.TabIndex = 14
            Me.label8.Text = "Select Left:"
            Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectPrevious
            ' 
            Me.textSelectPrevious.Location = New System.Drawing.Point(408, 40)
            Me.textSelectPrevious.Name = "textSelectPrevious"
            Me.textSelectPrevious.Size = New System.Drawing.Size(120, 20)
            Me.textSelectPrevious.TabIndex = 13
            Me.textSelectPrevious.Text = "None"
            Me.textSelectPrevious.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectPrevious.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectPrevious.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label7
            ' 
            Me.label7.Location = New System.Drawing.Point(272, 40)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(136, 20)
            Me.label7.TabIndex = 12
            Me.label7.Text = "Select Previous:"
            Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textSelectNext
            ' 
            Me.textSelectNext.Location = New System.Drawing.Point(408, 16)
            Me.textSelectNext.Name = "textSelectNext"
            Me.textSelectNext.Size = New System.Drawing.Size(120, 20)
            Me.textSelectNext.TabIndex = 11
            Me.textSelectNext.Text = "None"
            Me.textSelectNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textSelectNext.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textSelectNext.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label6
            ' 
            Me.label6.Location = New System.Drawing.Point(272, 16)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(136, 20)
            Me.label6.TabIndex = 10
            Me.label6.Text = "Select Next:"
            Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textDecreaseHeight
            ' 
            Me.textDecreaseHeight.Location = New System.Drawing.Point(112, 112)
            Me.textDecreaseHeight.Name = "textDecreaseHeight"
            Me.textDecreaseHeight.Size = New System.Drawing.Size(120, 20)
            Me.textDecreaseHeight.TabIndex = 9
            Me.textDecreaseHeight.Text = "None"
            Me.textDecreaseHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textDecreaseHeight.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textDecreaseHeight.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label5
            ' 
            Me.label5.Location = New System.Drawing.Point(16, 112)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(96, 20)
            Me.label5.TabIndex = 8
            Me.label5.Text = "Decrease Height:"
            Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textMoveRight
            ' 
            Me.textMoveRight.Location = New System.Drawing.Point(112, 88)
            Me.textMoveRight.Name = "textMoveRight"
            Me.textMoveRight.Size = New System.Drawing.Size(120, 20)
            Me.textMoveRight.TabIndex = 7
            Me.textMoveRight.Text = "None"
            Me.textMoveRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textMoveRight.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textMoveRight.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label4
            ' 
            Me.label4.Location = New System.Drawing.Point(16, 88)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(96, 20)
            Me.label4.TabIndex = 6
            Me.label4.Text = "Move Right:"
            Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textMoveLeft
            ' 
            Me.textMoveLeft.Location = New System.Drawing.Point(112, 64)
            Me.textMoveLeft.Name = "textMoveLeft"
            Me.textMoveLeft.Size = New System.Drawing.Size(120, 20)
            Me.textMoveLeft.TabIndex = 5
            Me.textMoveLeft.Text = "None"
            Me.textMoveLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textMoveLeft.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textMoveLeft.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label3
            ' 
            Me.label3.Location = New System.Drawing.Point(16, 64)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(96, 20)
            Me.label3.TabIndex = 4
            Me.label3.Text = "Move Left:"
            Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textMoveDown
            ' 
            Me.textMoveDown.Location = New System.Drawing.Point(112, 40)
            Me.textMoveDown.Name = "textMoveDown"
            Me.textMoveDown.Size = New System.Drawing.Size(120, 20)
            Me.textMoveDown.TabIndex = 3
            Me.textMoveDown.Text = "None"
            Me.textMoveDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textMoveDown.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textMoveDown.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label2
            ' 
            Me.label2.Location = New System.Drawing.Point(16, 40)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(96, 20)
            Me.label2.TabIndex = 2
            Me.label2.Text = "Move Down:"
            Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textMoveUp
            ' 
            Me.textMoveUp.Location = New System.Drawing.Point(112, 16)
            Me.textMoveUp.Name = "textMoveUp"
            Me.textMoveUp.Size = New System.Drawing.Size(120, 20)
            Me.textMoveUp.TabIndex = 1
            Me.textMoveUp.Text = "None"
            Me.textMoveUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textMoveUp.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.ProcessKeyDown);
            '			Me.textMoveUp.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.ProcessKeyPress);
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(96, 20)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Move Up:"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' btnOK
            ' 
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.Location = New System.Drawing.Point(166, 280)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(79, 24)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "OK"
            ' 
            ' btnCancel
            ' 
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(310, 280)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(79, 24)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            ' 
            ' label22
            ' 
            Me.label22.Location = New System.Drawing.Point(24, 72)
            Me.label22.Name = "label22"
            Me.label22.Size = New System.Drawing.Size(128, 21)
            Me.label22.TabIndex = 10
            Me.label22.Text = "Rotation Snap Interval:"
            Me.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textRotationSnapInterval
            ' 
            Me.textRotationSnapInterval.Location = New System.Drawing.Point(160, 72)
            Me.textRotationSnapInterval.MaxLength = 5
            Me.textRotationSnapInterval.Name = "textRotationSnapInterval"
            Me.textRotationSnapInterval.Size = New System.Drawing.Size(64, 20)
            Me.textRotationSnapInterval.TabIndex = 11
            Me.textRotationSnapInterval.Text = "0"
            Me.textRotationSnapInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textRotationSnapInterval.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.textRotationSnapThreshold_KeyPress);
            '			Me.textRotationSnapInterval.Validating += New System.ComponentModel.CancelEventHandler(Me.textRotationSnapInterval_Validating);
            ' 
            ' label23
            ' 
            Me.label23.Location = New System.Drawing.Point(24, 96)
            Me.label23.Name = "label23"
            Me.label23.Size = New System.Drawing.Size(144, 21)
            Me.label23.TabIndex = 12
            Me.label23.Text = "Rotation Snap Threshold:"
            Me.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' textRotationSnapThreshold
            ' 
            Me.textRotationSnapThreshold.Location = New System.Drawing.Point(160, 96)
            Me.textRotationSnapThreshold.MaxLength = 5
            Me.textRotationSnapThreshold.Name = "textRotationSnapThreshold"
            Me.textRotationSnapThreshold.Size = New System.Drawing.Size(64, 20)
            Me.textRotationSnapThreshold.TabIndex = 13
            Me.textRotationSnapThreshold.Text = "0"
            Me.textRotationSnapThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '			Me.textRotationSnapThreshold.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me.textRotationSnapThreshold_KeyPress);
            '			Me.textRotationSnapThreshold.Validating += New System.ComponentModel.CancelEventHandler(Me.textRotationSnapThreshold_Validating);
            ' 
            ' Preferences
            ' 
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(554, 320)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.tabControl1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Preferences"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Preferences"
            Me.tabControl1.ResumeLayout(False)
            Me.tabPage1.ResumeLayout(False)
            Me.tabPage2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region


        Public ReadOnly Property Settings() As ApplicationPreferences
            Get
                Return _settings
            End Get
        End Property

        Private Sub SetControlValues()
            Me.textClearSelection.Text = _settings.KeyClearSelection.ToString()
            Me.textDecreaseHeight.Text = _settings.KeyDecreaseHeight.ToString()
            Me.textDecreaseWidth.Text = _settings.KeyDecreaseWidth.ToString()
            Me.textIncreaseHeight.Text = _settings.KeyIncreaseHeight.ToString()
            Me.textIncreaseWidth.Text = _settings.KeyIncreaseWidth.ToString()
            Me.textMoveDown.Text = _settings.KeyMoveDown.ToString()
            Me.textMoveLeft.Text = _settings.KeyMoveLeft.ToString()
            Me.textMoveRight.Text = _settings.KeyMoveRight.ToString()
            Me.textMoveUp.Text = _settings.KeyMoveUp.ToString()
            Me.textRotateClockwise.Text = _settings.KeyRotateClockwise.ToString()
            Me.textRotateCounterclockwise.Text = _settings.KeyRotateCounterclockwise.ToString()
            Me.textSelectAbove.Text = _settings.KeySelectAbove.ToString()
            Me.textSelectBelow.Text = _settings.KeySelectBelow.ToString()
            Me.textSelectLeft.Text = _settings.KeySelectLeft.ToString()
            Me.textSelectNext.Text = _settings.KeySelectNext.ToString()
            Me.textSelectPrevious.Text = _settings.KeySelectPrevious.ToString()
            Me.textSelectRight.Text = _settings.KeySelectRight.ToString()

            Me.cboConfinement.Text = _settings.Confinement.ToString()
            Me.cboSmoothing.Text = _settings.Smoothing.ToString()
            Me.chkBurnConvert.Checked = _settings.BurnConvert
            Me.chkMultipageSupport.Checked = _settings.MultipageSupport
            Me.textMultiSelectKey.Text = _settings.MultiSelectKey.ToString()
            Me.cboUnits.Text = _settings.Units.ToString()
            Me.textRotationSnapInterval.Text = _settings.RotationSnapInterval.ToString()
            Me.textRotationSnapThreshold.Text = _settings.RotationSnapThreshold.ToString()
        End Sub

        Private Sub ProcessKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textMultiSelectKey.KeyDown, textClearSelection.KeyDown, textRotateCounterclockwise.KeyDown, textIncreaseWidth.KeyDown, textRotateClockwise.KeyDown, textIncreaseHeight.KeyDown, textSelectBelow.KeyDown, textDecreaseWidth.KeyDown, textSelectAbove.KeyDown, textSelectRight.KeyDown, textSelectLeft.KeyDown, textSelectPrevious.KeyDown, textSelectNext.KeyDown, textDecreaseHeight.KeyDown, textMoveRight.KeyDown, textMoveLeft.KeyDown, textMoveDown.KeyDown, textMoveUp.KeyDown
            Dim tb As TextBox = CType(IIf(TypeOf sender Is TextBox, sender, Nothing), TextBox)
            If tb Is Nothing Then
                Return
            End If

            Dim selectedKey As Keys = e.KeyData
            If selectedKey = (Keys.Control Or Keys.ControlKey) Then
                selectedKey = Keys.ControlKey
            ElseIf selectedKey = (Keys.Shift Or Keys.ShiftKey) Then
                selectedKey = Keys.ShiftKey
            End If

            tb.Text = selectedKey.ToString()
            e.Handled = True

            Select Case tb.Name
                Case "textMultiSelectKey"
                    _settings.MultiSelectKey = selectedKey
                Case "textClearSelection"
                    _settings.KeyClearSelection = selectedKey
                Case "textDecreaseHeight"
                    _settings.KeyDecreaseHeight = selectedKey
                Case "textDecreaseWidth"
                    _settings.KeyDecreaseWidth = selectedKey
                Case "textIncreaseHeight"
                    _settings.KeyIncreaseHeight = selectedKey
                Case "textIncreaseWidth"
                    _settings.KeyIncreaseWidth = selectedKey
                Case "textMoveDown"
                    _settings.KeyMoveDown = selectedKey
                Case "textMoveLeft"
                    _settings.KeyMoveLeft = selectedKey
                Case "textMoveRight"
                    _settings.KeyMoveRight = selectedKey
                Case "textMoveUp"
                    _settings.KeyMoveUp = selectedKey
                Case "textRotateClockwise"
                    _settings.KeyRotateClockwise = selectedKey
                Case "textRotateCounterclockwise"
                    _settings.KeyRotateCounterclockwise = selectedKey
                Case "textSelectAbove"
                    _settings.KeySelectAbove = selectedKey
                Case "textSelectBelow"
                    _settings.KeySelectBelow = selectedKey
                Case "textSelectLeft"
                    _settings.KeySelectLeft = selectedKey
                Case "textSelectNext"
                    _settings.KeySelectNext = selectedKey
                Case "textSelectPrevious"
                    _settings.KeySelectPrevious = selectedKey
                Case "textSelectRight"
                    _settings.KeySelectRight = selectedKey
            End Select
        End Sub

        Private Sub ProcessKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textMultiSelectKey.KeyPress, textClearSelection.KeyPress, textRotateCounterclockwise.KeyPress, textIncreaseWidth.KeyPress, textRotateClockwise.KeyPress, textIncreaseHeight.KeyPress, textSelectBelow.KeyPress, textDecreaseWidth.KeyPress, textSelectAbove.KeyPress, textSelectRight.KeyPress, textSelectLeft.KeyPress, textSelectPrevious.KeyPress, textSelectNext.KeyPress, textDecreaseHeight.KeyPress, textMoveRight.KeyPress, textMoveLeft.KeyPress, textMoveDown.KeyPress, textMoveUp.KeyPress
            ' This will keep the actual key stroke from displaying.
            e.Handled = True
        End Sub

        Private Sub chkBurnConvert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBurnConvert.CheckedChanged
            _settings.BurnConvert = Me.chkBurnConvert.Checked
        End Sub

        Private Sub chkMultipageSupport_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMultipageSupport.CheckedChanged
            _settings.MultipageSupport = Me.chkMultipageSupport.Checked
        End Sub

        Private Sub cboConfinement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConfinement.SelectedIndexChanged
            _settings.Confinement = CType(System.Enum.Parse(GetType(Atalasoft.Annotate.AnnotationConfinementMode), Me.cboConfinement.Text, True), Atalasoft.Annotate.AnnotationConfinementMode)
        End Sub

        Private Sub cboSmoothing_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSmoothing.SelectedIndexChanged
            _settings.Smoothing = CType(System.Enum.Parse(GetType(System.Drawing.Drawing2D.SmoothingMode), Me.cboSmoothing.Text, True), System.Drawing.Drawing2D.SmoothingMode)
        End Sub

        Private Sub cboUnits_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnits.SelectedIndexChanged
            _settings.Units = CType(System.Enum.Parse(GetType(Atalasoft.Annotate.AnnotationUnit), Me.cboUnits.Text, True), Atalasoft.Annotate.AnnotationUnit)
        End Sub

        Private Sub textRotationSnapInterval_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles textRotationSnapInterval.Validating
            Try
                ' The value must be evenly divisible into 360.
                Dim val As Single = Single.Parse(Me.textRotationSnapInterval.Text)
                If val = 360 Then
                    val = 0
                End If
                If val <> 0 Then
                    If val < 0 Then
                        val = -val
                    End If
                    If val > 180 Then
                        val = val Mod 360
                    End If
                    If 360 Mod val <> 0 Then
                        e.Cancel = True
                        MessageBox.Show("The value must be evenly divisible into 360.", "Invalid Interval")
                        Return
                    End If
                End If

                Me.textRotationSnapInterval.Text = val.ToString()
                _settings.RotationSnapInterval = val
            Catch
                e.Cancel = True
                MessageBox.Show("This should be a float (Single).", "Invalid Interval")
            End Try
        End Sub

        Private Sub textRotationSnapThreshold_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles textRotationSnapThreshold.Validating
            Try
                Dim interval As Single = Single.Parse(Me.textRotationSnapInterval.Text)
                Dim val As Single = Single.Parse(Me.textRotationSnapThreshold.Text)
                If val <> 0 Then
                    If val < 0 Then
                        val = -val
                    End If
                    If val > interval / 2.0F Then
                        e.Cancel = True
                        MessageBox.Show("The threshold value cannot be greater than half the interval.", "Invalid Threshold")
                        Return
                    End If
                End If

                Me.textRotationSnapThreshold.Text = val.ToString()
                _settings.RotationSnapThreshold = val
            Catch
                e.Cancel = True
                MessageBox.Show("This should be a float (Single).", "Invalid Threshold")
            End Try
        End Sub

        Private Sub textRotationSnapThreshold_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textRotationSnapInterval.KeyPress, textRotationSnapThreshold.KeyPress
            Dim chars As String = "0123456789."
            If chars.IndexOf(e.KeyChar) = -1 Then
                e.Handled = True
            End If
        End Sub

    End Class
End Namespace
