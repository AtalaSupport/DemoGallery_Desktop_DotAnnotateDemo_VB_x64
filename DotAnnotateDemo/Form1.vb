Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO

Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Annotate
Imports Atalasoft.Annotate.UI
Imports Atalasoft.Annotate.Icons
Imports System.Reflection
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace DotAnnotateDemo
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1 : Inherits System.Windows.Forms.Form
        Private _appSettings As ApplicationPreferences
        Private _lastOpenDirectory As String = ""
        Private _templates As TemplateManager
        Private _lastPdfAnnotation As Atalasoft.Annotate.Pdf.PdfMarkupAnnotation
        Private _pdfAnnotationSupport As Boolean

        Private _layerMenus As System.Windows.Forms.MenuItem()
        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private menuItem4 As System.Windows.Forms.MenuItem
        Private menuItem7 As System.Windows.Forms.MenuItem
        Private menuItem9 As System.Windows.Forms.MenuItem
        Private menuItem17 As System.Windows.Forms.MenuItem
        Private menuItem22 As System.Windows.Forms.MenuItem
        Private menuFile As System.Windows.Forms.MenuItem
        Private WithEvents menuFileOpen As System.Windows.Forms.MenuItem
        Private WithEvents menuFileSave As System.Windows.Forms.MenuItem
        Private WithEvents menuFileNextPage As System.Windows.Forms.MenuItem
        Private WithEvents menuFilePreviousPage As System.Windows.Forms.MenuItem
        Private WithEvents menuFilePrint As System.Windows.Forms.MenuItem
        Private WithEvents menuExit As System.Windows.Forms.MenuItem
        Private menuAnnotations As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsLoad As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsSave As System.Windows.Forms.MenuItem
        Private menuAnnotationsAdd As System.Windows.Forms.MenuItem
        Private menuHelp As System.Windows.Forms.MenuItem
        Private WithEvents menuHelpAbout As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsRemove As System.Windows.Forms.MenuItem
        Private menuLayers As System.Windows.Forms.MenuItem
        Private statusBar1 As System.Windows.Forms.StatusBar
        Private statusPage As System.Windows.Forms.StatusBarPanel
        Private annotateViewer1 As Atalasoft.Annotate.UI.AnnotateViewer
        Private splitter1 As System.Windows.Forms.Splitter
        Private menuItem1 As System.Windows.Forms.MenuItem
        Private WithEvents menuAddEllipse As System.Windows.Forms.MenuItem
        Private WithEvents menuAddRectangle As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPolygon As System.Windows.Forms.MenuItem
        Private WithEvents menuAddLine As System.Windows.Forms.MenuItem
        Private WithEvents menuAddLines As System.Windows.Forms.MenuItem
        Private WithEvents menuAddText As System.Windows.Forms.MenuItem
        Private WithEvents menuAddRubberStamp As System.Windows.Forms.MenuItem
        Private WithEvents menuAddEmbeddedImage As System.Windows.Forms.MenuItem
        Private WithEvents menuAddReferencedImage As System.Windows.Forms.MenuItem
        Private panelRight As System.Windows.Forms.Panel
        Private panelLayer As System.Windows.Forms.Panel
        Private splitter2 As System.Windows.Forms.Splitter
        Private panelAnnotation As System.Windows.Forms.Panel
        Private propGridAnnotation As System.Windows.Forms.PropertyGrid
        Private lblActive As System.Windows.Forms.Label
        Private lblLayer As System.Windows.Forms.Label
        Private WithEvents menuLayersClear As System.Windows.Forms.MenuItem
        Private menuItem3 As System.Windows.Forms.MenuItem
        Private menuItem8 As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersClearAll As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersAdd As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersRemove As System.Windows.Forms.MenuItem
        Private WithEvents menuAddFreehand As System.Windows.Forms.MenuItem
        Private menuAnnotationsFlip As System.Windows.Forms.MenuItem
        Private WithEvents menuFlipH As System.Windows.Forms.MenuItem
        Private WithEvents menuFlipV As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsTooltips As System.Windows.Forms.MenuItem
        Private menuItem2 As System.Windows.Forms.MenuItem
        Private toolTip1 As System.Windows.Forms.ToolTip
        Private WithEvents menuFileBurn As System.Windows.Forms.MenuItem
        Private menuZoom As System.Windows.Forms.MenuItem
        Private WithEvents menuZoom25 As System.Windows.Forms.MenuItem
        Private WithEvents menuZoom50 As System.Windows.Forms.MenuItem
        Private WithEvents menuZoom100 As System.Windows.Forms.MenuItem
        Private WithEvents menuZoom200 As System.Windows.Forms.MenuItem
        Private WithEvents menuZoom500 As System.Windows.Forms.MenuItem
        Private menuItem5 As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnGroup As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnUngroup As System.Windows.Forms.MenuItem
        Private menuItem13 As System.Windows.Forms.MenuItem
        Private menuItem19 As System.Windows.Forms.MenuItem
        Private WithEvents menuEdit As System.Windows.Forms.MenuItem
        Private WithEvents menuEditUndo As System.Windows.Forms.MenuItem
        Private WithEvents menuEditRedo As System.Windows.Forms.MenuItem
        Private WithEvents menuEditCut As System.Windows.Forms.MenuItem
        Private WithEvents menuEditCopy As System.Windows.Forms.MenuItem
        Private WithEvents menuEditPaste As System.Windows.Forms.MenuItem
        Private WithEvents menuEditSelectAll As System.Windows.Forms.MenuItem
        Private menuItem6 As System.Windows.Forms.MenuItem
        Private WithEvents menuEditPreferences As System.Windows.Forms.MenuItem
        Private menuItem10 As System.Windows.Forms.MenuItem
        Private statusFile As System.Windows.Forms.StatusBarPanel
        Private statusAnnCount As System.Windows.Forms.StatusBarPanel
        Private propGridTemplate As System.Windows.Forms.PropertyGrid
        Private WithEvents menuAnnotationsMoveToFront As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsMoveUp As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsMoveBack As System.Windows.Forms.MenuItem
        Private WithEvents menuAnnotationsMoveToBack As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersMoveToFront As System.Windows.Forms.MenuItem
        Private menuItem11 As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersMoveUp As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersMoveBack As System.Windows.Forms.MenuItem
        Private WithEvents menuLayersMoveToBack As System.Windows.Forms.MenuItem
        Private WithEvents menuFileRotate As System.Windows.Forms.MenuItem
        Private WithEvents menuEnableClassyRenderers As System.Windows.Forms.MenuItem
        Private statusInfo As System.Windows.Forms.StatusBarPanel
        Private WithEvents menuAddCallout As System.Windows.Forms.MenuItem
        Private statusResolution As System.Windows.Forms.StatusBarPanel
        Private WithEvents menuAddTriangle As System.Windows.Forms.MenuItem
        Private WithEvents menuAddHotSpot As System.Windows.Forms.MenuItem
        Private WithEvents menuAddFreehandHotSpot As System.Windows.Forms.MenuItem
        Private menuItem20 As System.Windows.Forms.MenuItem
        Private menuSecurity As System.Windows.Forms.MenuItem
        Private WithEvents menuSecurityLockAnnotations As System.Windows.Forms.MenuItem
        Private WithEvents menuSecurityLockLayer As System.Windows.Forms.MenuItem
        Private WithEvents menuSecurityUnlockAnnotations As System.Windows.Forms.MenuItem
        Private WithEvents menuSecurityUnlockLayer As System.Windows.Forms.MenuItem
        Private menuItem12 As System.Windows.Forms.MenuItem
        Private WithEvents menuSecuritySelectImage As System.Windows.Forms.MenuItem
        Private WithEvents menuSecurityClearImage As System.Windows.Forms.MenuItem
        Private WithEvents menuEditClearUndos As System.Windows.Forms.MenuItem
        Private WithEvents toolBar1 As System.Windows.Forms.ToolBar
        Private tbEllipse As System.Windows.Forms.ToolBarButton
        Private tbFreehand As System.Windows.Forms.ToolBarButton
        Private tbFreehandHighlighter As System.Windows.Forms.ToolBarButton
        Private tbLine As System.Windows.Forms.ToolBarButton
        Private tbLines As System.Windows.Forms.ToolBarButton
        Private tbPolygon As System.Windows.Forms.ToolBarButton
        Private tbRetangle As System.Windows.Forms.ToolBarButton
        Private tbRectangleHighlighter As System.Windows.Forms.ToolBarButton
        Private tbRedaction As System.Windows.Forms.ToolBarButton
        Private tbStickyNote As System.Windows.Forms.ToolBarButton
        Private tbText As System.Windows.Forms.ToolBarButton
        Private toolImageList As System.Windows.Forms.ImageList
        Private tbRubberStamp As System.Windows.Forms.ToolBarButton
        Private tbCallout As System.Windows.Forms.ToolBarButton
        Private tbFreehandHotspot As System.Windows.Forms.ToolBarButton
        Private tbRectangleHotspot As System.Windows.Forms.ToolBarButton
        Private menuInteractMode As System.Windows.Forms.MenuItem
        Private WithEvents menuInteractModeView As System.Windows.Forms.MenuItem
        Private WithEvents menuInteractModeNone As System.Windows.Forms.MenuItem
        Private tbEmbeddedImage As System.Windows.Forms.ToolBarButton
        Private tbReferencedImage As System.Windows.Forms.ToolBarButton
        Private tbSep1 As System.Windows.Forms.ToolBarButton
        Private tbSep2 As System.Windows.Forms.ToolBarButton
        Private tbSep3 As System.Windows.Forms.ToolBarButton
        Private tbSep4 As System.Windows.Forms.ToolBarButton
        Private WithEvents menuInteractModeAuthor As System.Windows.Forms.MenuItem
        Private tbPdfMarkup As System.Windows.Forms.ToolBarButton
        Private tbPdfLine As System.Windows.Forms.ToolBarButton
        Private tbSep5 As System.Windows.Forms.ToolBarButton
        Private tbSpacer As System.Windows.Forms.ToolBarButton
        Private WithEvents menuPdfHighlight As System.Windows.Forms.MenuItem
        Private WithEvents menuPdfSquiggly As System.Windows.Forms.MenuItem
        Private WithEvents menuPdfStrikeOut As System.Windows.Forms.MenuItem
        Private WithEvents menuPdfUnderline As System.Windows.Forms.MenuItem
        Private contextPdf As System.Windows.Forms.ContextMenu
        Private menuItem14 As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPdfLine As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPdfHighlighter As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPdfSquiggly As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPdfUnderline As System.Windows.Forms.MenuItem
        Private WithEvents menuAddPdfStrikeout As System.Windows.Forms.MenuItem
        Private menuItem24 As System.Windows.Forms.MenuItem
        Private WithEvents menuAddTrianglePoints As System.Windows.Forms.MenuItem
        Friend WithEvents tbTriangle As System.Windows.Forms.ToolBarButton
        Friend WithEvents tbTrianglePoint As System.Windows.Forms.ToolBarButton
        Friend WithEvents tbArc As System.Windows.Forms.ToolBarButton
        Friend WithEvents tbSpacer1 As System.Windows.Forms.ToolBarButton
        Private components As System.ComponentModel.IContainer

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)

            ' SAFELY determine if we have PDF annotations
            Try
                If (HelperMethods.HaveDecoder(New Atalasoft.Imaging.Codec.Pdf.PdfDecoder())) Then
                    _pdfAnnotationSupport = True

                    ' The imports allows the annotations to automatically load with the Open method.
                    Me.annotateViewer1.DataImporters.Add(New Atalasoft.Annotate.Importers.PdfAnnotationDataImporter)
                Else
                    _pdfAnnotationSupport = False
                End If
            Catch e1 As AtalasoftLicenseException
                _pdfAnnotationSupport = False
            End Try

            AddHandler annotateViewer1.Annotations.SelectionChanged, AddressOf Annotations_SelectionChanged
            AddHandler annotateViewer1.Annotations.AnnotationCreated, AddressOf Annotations_AnnotationCreated
            AddHandler annotateViewer1.Annotations.Rotating, AddressOf Annotations_Rotating
            AddHandler annotateViewer1.Annotations.Moving, AddressOf Annotations_Moving
            AddHandler annotateViewer1.Annotations.Resizing, AddressOf Annotations_Resizing
            AddHandler annotateViewer1.Annotations.Moved, AddressOf Annotations_MovedResizedRotated
            AddHandler annotateViewer1.Annotations.Resized, AddressOf Annotations_MovedResizedRotated
            AddHandler annotateViewer1.Annotations.Rotated, AddressOf Annotations_MovedResizedRotated

            Me.annotateViewer1.Centered = False

            Me._templates = New TemplateManager
            Me.propGridTemplate.SelectedObject = Me._templates
            UpdateMenu()
            UpdateInteractModeMenu()
            ApplyAppSettings()

            AddHandler propGridAnnotation.PropertyValueChanged, AddressOf propGridAnnotation_PropertyValueChanged
            Me.annotateViewer1.Annotations.ClipToDocument = True
            PopulateToolbox()
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
            Me.components = New System.ComponentModel.Container
            Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
            Me.menuFile = New System.Windows.Forms.MenuItem
            Me.menuFileOpen = New System.Windows.Forms.MenuItem
            Me.menuFileSave = New System.Windows.Forms.MenuItem
            Me.menuItem4 = New System.Windows.Forms.MenuItem
            Me.menuFileNextPage = New System.Windows.Forms.MenuItem
            Me.menuFilePreviousPage = New System.Windows.Forms.MenuItem
            Me.menuItem7 = New System.Windows.Forms.MenuItem
            Me.menuFilePrint = New System.Windows.Forms.MenuItem
            Me.menuFileBurn = New System.Windows.Forms.MenuItem
            Me.menuItem9 = New System.Windows.Forms.MenuItem
            Me.menuFileRotate = New System.Windows.Forms.MenuItem
            Me.menuZoom = New System.Windows.Forms.MenuItem
            Me.menuZoom25 = New System.Windows.Forms.MenuItem
            Me.menuZoom50 = New System.Windows.Forms.MenuItem
            Me.menuZoom100 = New System.Windows.Forms.MenuItem
            Me.menuZoom200 = New System.Windows.Forms.MenuItem
            Me.menuZoom500 = New System.Windows.Forms.MenuItem
            Me.menuItem5 = New System.Windows.Forms.MenuItem
            Me.menuExit = New System.Windows.Forms.MenuItem
            Me.menuEdit = New System.Windows.Forms.MenuItem
            Me.menuEditUndo = New System.Windows.Forms.MenuItem
            Me.menuEditRedo = New System.Windows.Forms.MenuItem
            Me.menuEditClearUndos = New System.Windows.Forms.MenuItem
            Me.menuItem13 = New System.Windows.Forms.MenuItem
            Me.menuEditCut = New System.Windows.Forms.MenuItem
            Me.menuEditCopy = New System.Windows.Forms.MenuItem
            Me.menuEditPaste = New System.Windows.Forms.MenuItem
            Me.menuItem19 = New System.Windows.Forms.MenuItem
            Me.menuEditSelectAll = New System.Windows.Forms.MenuItem
            Me.menuItem6 = New System.Windows.Forms.MenuItem
            Me.menuEditPreferences = New System.Windows.Forms.MenuItem
            Me.menuAnnotations = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsLoad = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsSave = New System.Windows.Forms.MenuItem
            Me.menuItem17 = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsAdd = New System.Windows.Forms.MenuItem
            Me.menuAddCallout = New System.Windows.Forms.MenuItem
            Me.menuAddEllipse = New System.Windows.Forms.MenuItem
            Me.menuAddEmbeddedImage = New System.Windows.Forms.MenuItem
            Me.menuAddFreehand = New System.Windows.Forms.MenuItem
            Me.menuAddFreehandHotSpot = New System.Windows.Forms.MenuItem
            Me.menuAddHotSpot = New System.Windows.Forms.MenuItem
            Me.menuAddLine = New System.Windows.Forms.MenuItem
            Me.menuAddLines = New System.Windows.Forms.MenuItem
            Me.menuAddPolygon = New System.Windows.Forms.MenuItem
            Me.menuAddRectangle = New System.Windows.Forms.MenuItem
            Me.menuAddReferencedImage = New System.Windows.Forms.MenuItem
            Me.menuAddRubberStamp = New System.Windows.Forms.MenuItem
            Me.menuAddText = New System.Windows.Forms.MenuItem
            Me.menuItem14 = New System.Windows.Forms.MenuItem
            Me.menuAddPdfLine = New System.Windows.Forms.MenuItem
            Me.menuAddPdfHighlighter = New System.Windows.Forms.MenuItem
            Me.menuAddPdfSquiggly = New System.Windows.Forms.MenuItem
            Me.menuAddPdfStrikeout = New System.Windows.Forms.MenuItem
            Me.menuAddPdfUnderline = New System.Windows.Forms.MenuItem
            Me.menuItem24 = New System.Windows.Forms.MenuItem
            Me.menuAddTriangle = New System.Windows.Forms.MenuItem
            Me.menuAddTrianglePoints = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsRemove = New System.Windows.Forms.MenuItem
            Me.menuItem22 = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsMoveToFront = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsMoveUp = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsMoveBack = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsMoveToBack = New System.Windows.Forms.MenuItem
            Me.menuItem1 = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsFlip = New System.Windows.Forms.MenuItem
            Me.menuFlipH = New System.Windows.Forms.MenuItem
            Me.menuFlipV = New System.Windows.Forms.MenuItem
            Me.menuItem2 = New System.Windows.Forms.MenuItem
            Me.menuAnnGroup = New System.Windows.Forms.MenuItem
            Me.menuAnnUngroup = New System.Windows.Forms.MenuItem
            Me.menuItem11 = New System.Windows.Forms.MenuItem
            Me.menuEnableClassyRenderers = New System.Windows.Forms.MenuItem
            Me.menuAnnotationsTooltips = New System.Windows.Forms.MenuItem
            Me.menuInteractMode = New System.Windows.Forms.MenuItem
            Me.menuInteractModeNone = New System.Windows.Forms.MenuItem
            Me.menuInteractModeAuthor = New System.Windows.Forms.MenuItem
            Me.menuInteractModeView = New System.Windows.Forms.MenuItem
            Me.menuLayers = New System.Windows.Forms.MenuItem
            Me.menuLayersClear = New System.Windows.Forms.MenuItem
            Me.menuLayersClearAll = New System.Windows.Forms.MenuItem
            Me.menuItem3 = New System.Windows.Forms.MenuItem
            Me.menuLayersAdd = New System.Windows.Forms.MenuItem
            Me.menuLayersRemove = New System.Windows.Forms.MenuItem
            Me.menuItem8 = New System.Windows.Forms.MenuItem
            Me.menuLayersMoveToFront = New System.Windows.Forms.MenuItem
            Me.menuLayersMoveUp = New System.Windows.Forms.MenuItem
            Me.menuLayersMoveBack = New System.Windows.Forms.MenuItem
            Me.menuLayersMoveToBack = New System.Windows.Forms.MenuItem
            Me.menuItem10 = New System.Windows.Forms.MenuItem
            Me.menuSecurity = New System.Windows.Forms.MenuItem
            Me.menuSecurityLockAnnotations = New System.Windows.Forms.MenuItem
            Me.menuSecurityLockLayer = New System.Windows.Forms.MenuItem
            Me.menuItem20 = New System.Windows.Forms.MenuItem
            Me.menuSecurityUnlockAnnotations = New System.Windows.Forms.MenuItem
            Me.menuSecurityUnlockLayer = New System.Windows.Forms.MenuItem
            Me.menuItem12 = New System.Windows.Forms.MenuItem
            Me.menuSecuritySelectImage = New System.Windows.Forms.MenuItem
            Me.menuSecurityClearImage = New System.Windows.Forms.MenuItem
            Me.menuHelp = New System.Windows.Forms.MenuItem
            Me.menuHelpAbout = New System.Windows.Forms.MenuItem
            Me.statusBar1 = New System.Windows.Forms.StatusBar
            Me.statusFile = New System.Windows.Forms.StatusBarPanel
            Me.statusInfo = New System.Windows.Forms.StatusBarPanel
            Me.statusPage = New System.Windows.Forms.StatusBarPanel
            Me.statusAnnCount = New System.Windows.Forms.StatusBarPanel
            Me.statusResolution = New System.Windows.Forms.StatusBarPanel
            Me.annotateViewer1 = New Atalasoft.Annotate.UI.AnnotateViewer
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.panelRight = New System.Windows.Forms.Panel
            Me.panelAnnotation = New System.Windows.Forms.Panel
            Me.propGridAnnotation = New System.Windows.Forms.PropertyGrid
            Me.lblActive = New System.Windows.Forms.Label
            Me.splitter2 = New System.Windows.Forms.Splitter
            Me.panelLayer = New System.Windows.Forms.Panel
            Me.lblLayer = New System.Windows.Forms.Label
            Me.propGridTemplate = New System.Windows.Forms.PropertyGrid
            Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.toolBar1 = New System.Windows.Forms.ToolBar
            Me.tbEllipse = New System.Windows.Forms.ToolBarButton
            Me.tbFreehand = New System.Windows.Forms.ToolBarButton
            Me.tbLine = New System.Windows.Forms.ToolBarButton
            Me.tbLines = New System.Windows.Forms.ToolBarButton
            Me.tbPolygon = New System.Windows.Forms.ToolBarButton
            Me.tbRetangle = New System.Windows.Forms.ToolBarButton
            Me.tbTriangle = New System.Windows.Forms.ToolBarButton
            Me.tbTrianglePoint = New System.Windows.Forms.ToolBarButton
            Me.tbArc = New System.Windows.Forms.ToolBarButton
            Me.tbSep1 = New System.Windows.Forms.ToolBarButton
            Me.tbRectangleHighlighter = New System.Windows.Forms.ToolBarButton
            Me.tbFreehandHighlighter = New System.Windows.Forms.ToolBarButton
            Me.tbSep2 = New System.Windows.Forms.ToolBarButton
            Me.tbEmbeddedImage = New System.Windows.Forms.ToolBarButton
            Me.tbReferencedImage = New System.Windows.Forms.ToolBarButton
            Me.tbSep3 = New System.Windows.Forms.ToolBarButton
            Me.tbRectangleHotspot = New System.Windows.Forms.ToolBarButton
            Me.tbFreehandHotspot = New System.Windows.Forms.ToolBarButton
            Me.tbSep4 = New System.Windows.Forms.ToolBarButton
            Me.tbText = New System.Windows.Forms.ToolBarButton
            Me.tbCallout = New System.Windows.Forms.ToolBarButton
            Me.tbStickyNote = New System.Windows.Forms.ToolBarButton
            Me.tbRubberStamp = New System.Windows.Forms.ToolBarButton
            Me.tbRedaction = New System.Windows.Forms.ToolBarButton
            Me.tbSpacer = New System.Windows.Forms.ToolBarButton
            Me.tbSep5 = New System.Windows.Forms.ToolBarButton
            Me.tbPdfMarkup = New System.Windows.Forms.ToolBarButton
            Me.contextPdf = New System.Windows.Forms.ContextMenu
            Me.menuPdfHighlight = New System.Windows.Forms.MenuItem
            Me.menuPdfSquiggly = New System.Windows.Forms.MenuItem
            Me.menuPdfStrikeOut = New System.Windows.Forms.MenuItem
            Me.menuPdfUnderline = New System.Windows.Forms.MenuItem
            Me.tbPdfLine = New System.Windows.Forms.ToolBarButton
            Me.toolImageList = New System.Windows.Forms.ImageList(Me.components)
            Me.tbSpacer1 = New System.Windows.Forms.ToolBarButton
            CType(Me.statusFile, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusPage, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusAnnCount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusResolution, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelRight.SuspendLayout()
            Me.panelAnnotation.SuspendLayout()
            Me.panelLayer.SuspendLayout()
            Me.SuspendLayout()
            '
            'mainMenu1
            '
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuEdit, Me.menuAnnotations, Me.menuLayers, Me.menuSecurity, Me.menuHelp})
            '
            'menuFile
            '
            Me.menuFile.Index = 0
            Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFileOpen, Me.menuFileSave, Me.menuItem4, Me.menuFileNextPage, Me.menuFilePreviousPage, Me.menuItem7, Me.menuFilePrint, Me.menuFileBurn, Me.menuItem9, Me.menuFileRotate, Me.menuZoom, Me.menuItem5, Me.menuExit})
            Me.menuFile.Text = "&File"
            '
            'menuFileOpen
            '
            Me.menuFileOpen.Index = 0
            Me.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me.menuFileOpen.Text = "&Open"
            '
            'menuFileSave
            '
            Me.menuFileSave.Index = 1
            Me.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me.menuFileSave.Text = "&Save"
            '
            'menuItem4
            '
            Me.menuItem4.Index = 2
            Me.menuItem4.Text = "-"
            '
            'menuFileNextPage
            '
            Me.menuFileNextPage.Index = 3
            Me.menuFileNextPage.Text = "Next Page"
            '
            'menuFilePreviousPage
            '
            Me.menuFilePreviousPage.Index = 4
            Me.menuFilePreviousPage.Text = "Previous Page"
            '
            'menuItem7
            '
            Me.menuItem7.Index = 5
            Me.menuItem7.Text = "-"
            '
            'menuFilePrint
            '
            Me.menuFilePrint.Index = 6
            Me.menuFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
            Me.menuFilePrint.Text = "&Print"
            '
            'menuFileBurn
            '
            Me.menuFileBurn.Index = 7
            Me.menuFileBurn.Text = "Burn"
            '
            'menuItem9
            '
            Me.menuItem9.Index = 8
            Me.menuItem9.Text = "-"
            '
            'menuFileRotate
            '
            Me.menuFileRotate.Index = 9
            Me.menuFileRotate.Text = "Rotate Document"
            '
            'menuZoom
            '
            Me.menuZoom.Index = 10
            Me.menuZoom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuZoom25, Me.menuZoom50, Me.menuZoom100, Me.menuZoom200, Me.menuZoom500})
            Me.menuZoom.Text = "Zoom"
            '
            'menuZoom25
            '
            Me.menuZoom25.Index = 0
            Me.menuZoom25.RadioCheck = True
            Me.menuZoom25.Text = "25%"
            '
            'menuZoom50
            '
            Me.menuZoom50.Index = 1
            Me.menuZoom50.RadioCheck = True
            Me.menuZoom50.Text = "50%"
            '
            'menuZoom100
            '
            Me.menuZoom100.Checked = True
            Me.menuZoom100.Index = 2
            Me.menuZoom100.RadioCheck = True
            Me.menuZoom100.Text = "100%"
            '
            'menuZoom200
            '
            Me.menuZoom200.Index = 3
            Me.menuZoom200.RadioCheck = True
            Me.menuZoom200.Text = "200%"
            '
            'menuZoom500
            '
            Me.menuZoom500.Index = 4
            Me.menuZoom500.RadioCheck = True
            Me.menuZoom500.Text = "500%"
            '
            'menuItem5
            '
            Me.menuItem5.Index = 11
            Me.menuItem5.Text = "-"
            '
            'menuExit
            '
            Me.menuExit.Index = 12
            Me.menuExit.Text = "E&xit"
            '
            'menuEdit
            '
            Me.menuEdit.Index = 1
            Me.menuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuEditUndo, Me.menuEditRedo, Me.menuEditClearUndos, Me.menuItem13, Me.menuEditCut, Me.menuEditCopy, Me.menuEditPaste, Me.menuItem19, Me.menuEditSelectAll, Me.menuItem6, Me.menuEditPreferences})
            Me.menuEdit.Text = "&Edit"
            '
            'menuEditUndo
            '
            Me.menuEditUndo.Index = 0
            Me.menuEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
            Me.menuEditUndo.Text = "&Undo"
            '
            'menuEditRedo
            '
            Me.menuEditRedo.Index = 1
            Me.menuEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY
            Me.menuEditRedo.Text = "&Redo"
            '
            'menuEditClearUndos
            '
            Me.menuEditClearUndos.Index = 2
            Me.menuEditClearUndos.Text = "Clear Undos"
            '
            'menuItem13
            '
            Me.menuItem13.Index = 3
            Me.menuItem13.Text = "-"
            '
            'menuEditCut
            '
            Me.menuEditCut.Index = 4
            Me.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
            Me.menuEditCut.Text = "Cu&t"
            '
            'menuEditCopy
            '
            Me.menuEditCopy.Index = 5
            Me.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
            Me.menuEditCopy.Text = "&Copy"
            '
            'menuEditPaste
            '
            Me.menuEditPaste.Index = 6
            Me.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
            Me.menuEditPaste.Text = "&Paste"
            '
            'menuItem19
            '
            Me.menuItem19.Index = 7
            Me.menuItem19.Text = "-"
            '
            'menuEditSelectAll
            '
            Me.menuEditSelectAll.Index = 8
            Me.menuEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
            Me.menuEditSelectAll.Text = "Select &All"
            '
            'menuItem6
            '
            Me.menuItem6.Index = 9
            Me.menuItem6.Text = "-"
            '
            'menuEditPreferences
            '
            Me.menuEditPreferences.Index = 10
            Me.menuEditPreferences.Text = "&Preferences..."
            '
            'menuAnnotations
            '
            Me.menuAnnotations.Index = 2
            Me.menuAnnotations.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAnnotationsLoad, Me.menuAnnotationsSave, Me.menuItem17, Me.menuAnnotationsAdd, Me.menuAnnotationsRemove, Me.menuItem22, Me.menuAnnotationsMoveToFront, Me.menuAnnotationsMoveUp, Me.menuAnnotationsMoveBack, Me.menuAnnotationsMoveToBack, Me.menuItem1, Me.menuAnnotationsFlip, Me.menuItem2, Me.menuAnnGroup, Me.menuAnnUngroup, Me.menuItem11, Me.menuEnableClassyRenderers, Me.menuAnnotationsTooltips, Me.menuInteractMode})
            Me.menuAnnotations.Text = "&Annotations"
            '
            'menuAnnotationsLoad
            '
            Me.menuAnnotationsLoad.Index = 0
            Me.menuAnnotationsLoad.Text = "&Load From File"
            '
            'menuAnnotationsSave
            '
            Me.menuAnnotationsSave.Index = 1
            Me.menuAnnotationsSave.Text = "&Save To File"
            '
            'menuItem17
            '
            Me.menuItem17.Index = 2
            Me.menuItem17.Text = "-"
            '
            'menuAnnotationsAdd
            '
            Me.menuAnnotationsAdd.Index = 3
            Me.menuAnnotationsAdd.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAddCallout, Me.menuAddEllipse, Me.menuAddEmbeddedImage, Me.menuAddFreehand, Me.menuAddFreehandHotSpot, Me.menuAddHotSpot, Me.menuAddLine, Me.menuAddLines, Me.menuAddPolygon, Me.menuAddRectangle, Me.menuAddReferencedImage, Me.menuAddRubberStamp, Me.menuAddText, Me.menuItem14, Me.menuAddPdfLine, Me.menuAddPdfHighlighter, Me.menuAddPdfSquiggly, Me.menuAddPdfStrikeout, Me.menuAddPdfUnderline, Me.menuItem24, Me.menuAddTriangle, Me.menuAddTrianglePoints})
            Me.menuAnnotationsAdd.Text = "Add"
            '
            'menuAddCallout
            '
            Me.menuAddCallout.Index = 0
            Me.menuAddCallout.Text = "Callout"
            '
            'menuAddEllipse
            '
            Me.menuAddEllipse.Index = 1
            Me.menuAddEllipse.Text = "Ellipse"
            '
            'menuAddEmbeddedImage
            '
            Me.menuAddEmbeddedImage.Index = 2
            Me.menuAddEmbeddedImage.Text = "Embedded Image"
            '
            'menuAddFreehand
            '
            Me.menuAddFreehand.Index = 3
            Me.menuAddFreehand.Text = "Freehand"
            '
            'menuAddFreehandHotSpot
            '
            Me.menuAddFreehandHotSpot.Index = 4
            Me.menuAddFreehandHotSpot.Text = "Freehand Hot Spot"
            '
            'menuAddHotSpot
            '
            Me.menuAddHotSpot.Index = 5
            Me.menuAddHotSpot.Text = "Hot Spot"
            '
            'menuAddLine
            '
            Me.menuAddLine.Index = 6
            Me.menuAddLine.Text = "Line"
            '
            'menuAddLines
            '
            Me.menuAddLines.Index = 7
            Me.menuAddLines.Text = "Lines"
            '
            'menuAddPolygon
            '
            Me.menuAddPolygon.Index = 8
            Me.menuAddPolygon.Text = "Polygon"
            '
            'menuAddRectangle
            '
            Me.menuAddRectangle.Index = 9
            Me.menuAddRectangle.Text = "Rectangle"
            '
            'menuAddReferencedImage
            '
            Me.menuAddReferencedImage.Index = 10
            Me.menuAddReferencedImage.Text = "Referenced Image"
            '
            'menuAddRubberStamp
            '
            Me.menuAddRubberStamp.Index = 11
            Me.menuAddRubberStamp.Text = "Rubber Stamp"
            '
            'menuAddText
            '
            Me.menuAddText.Index = 12
            Me.menuAddText.Text = "Text"
            '
            'menuItem14
            '
            Me.menuItem14.Index = 13
            Me.menuItem14.Text = "-"
            '
            'menuAddPdfLine
            '
            Me.menuAddPdfLine.Index = 14
            Me.menuAddPdfLine.Text = "PDF Line"
            '
            'menuAddPdfHighlighter
            '
            Me.menuAddPdfHighlighter.Index = 15
            Me.menuAddPdfHighlighter.Text = "PDF Highlighter"
            '
            'menuAddPdfSquiggly
            '
            Me.menuAddPdfSquiggly.Index = 16
            Me.menuAddPdfSquiggly.Text = "PDF Squiggly"
            '
            'menuAddPdfStrikeout
            '
            Me.menuAddPdfStrikeout.Index = 17
            Me.menuAddPdfStrikeout.Text = "PDF Strikeout"
            '
            'menuAddPdfUnderline
            '
            Me.menuAddPdfUnderline.Index = 18
            Me.menuAddPdfUnderline.Text = "PDF Underline"
            '
            'menuItem24
            '
            Me.menuItem24.Index = 19
            Me.menuItem24.Text = "-"
            '
            'menuAddTriangle
            '
            Me.menuAddTriangle.Index = 20
            Me.menuAddTriangle.Text = "Triangle (Custom Example)"
            '
            'menuAddTrianglePoints
            '
            Me.menuAddTrianglePoints.Index = 21
            Me.menuAddTrianglePoints.Text = "Triangle (Custom Point Example)"
            '
            'menuAnnotationsRemove
            '
            Me.menuAnnotationsRemove.Index = 4
            Me.menuAnnotationsRemove.Shortcut = System.Windows.Forms.Shortcut.ShiftDel
            Me.menuAnnotationsRemove.Text = "Remove Selected"
            '
            'menuItem22
            '
            Me.menuItem22.Index = 5
            Me.menuItem22.Text = "-"
            '
            'menuAnnotationsMoveToFront
            '
            Me.menuAnnotationsMoveToFront.Index = 6
            Me.menuAnnotationsMoveToFront.Text = "Move To Front"
            '
            'menuAnnotationsMoveUp
            '
            Me.menuAnnotationsMoveUp.Index = 7
            Me.menuAnnotationsMoveUp.Text = "Move Up"
            '
            'menuAnnotationsMoveBack
            '
            Me.menuAnnotationsMoveBack.Index = 8
            Me.menuAnnotationsMoveBack.Text = "Move Back"
            '
            'menuAnnotationsMoveToBack
            '
            Me.menuAnnotationsMoveToBack.Index = 9
            Me.menuAnnotationsMoveToBack.Text = "Move To Back"
            '
            'menuItem1
            '
            Me.menuItem1.Index = 10
            Me.menuItem1.Text = "-"
            '
            'menuAnnotationsFlip
            '
            Me.menuAnnotationsFlip.Index = 11
            Me.menuAnnotationsFlip.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFlipH, Me.menuFlipV})
            Me.menuAnnotationsFlip.Text = "Flip"
            '
            'menuFlipH
            '
            Me.menuFlipH.Index = 0
            Me.menuFlipH.Text = "Horizontal"
            '
            'menuFlipV
            '
            Me.menuFlipV.Index = 1
            Me.menuFlipV.Text = "Vertical"
            '
            'menuItem2
            '
            Me.menuItem2.Index = 12
            Me.menuItem2.Text = "-"
            '
            'menuAnnGroup
            '
            Me.menuAnnGroup.Enabled = False
            Me.menuAnnGroup.Index = 13
            Me.menuAnnGroup.Text = "&Group"
            '
            'menuAnnUngroup
            '
            Me.menuAnnUngroup.Enabled = False
            Me.menuAnnUngroup.Index = 14
            Me.menuAnnUngroup.Text = "&Ungroup"
            '
            'menuItem11
            '
            Me.menuItem11.Index = 15
            Me.menuItem11.Text = "-"
            '
            'menuEnableClassyRenderers
            '
            Me.menuEnableClassyRenderers.Index = 16
            Me.menuEnableClassyRenderers.Text = "Enable Classy Renderers"
            '
            'menuAnnotationsTooltips
            '
            Me.menuAnnotationsTooltips.Index = 17
            Me.menuAnnotationsTooltips.Text = "Show Tooltips"
            '
            'menuInteractMode
            '
            Me.menuInteractMode.Index = 18
            Me.menuInteractMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuInteractModeNone, Me.menuInteractModeAuthor, Me.menuInteractModeView})
            Me.menuInteractMode.Text = "Interact Mode"
            '
            'menuInteractModeNone
            '
            Me.menuInteractModeNone.Index = 0
            Me.menuInteractModeNone.RadioCheck = True
            Me.menuInteractModeNone.Text = "None"
            '
            'menuInteractModeAuthor
            '
            Me.menuInteractModeAuthor.Index = 1
            Me.menuInteractModeAuthor.RadioCheck = True
            Me.menuInteractModeAuthor.Text = "Author"
            '
            'menuInteractModeView
            '
            Me.menuInteractModeView.Index = 2
            Me.menuInteractModeView.RadioCheck = True
            Me.menuInteractModeView.Text = "View"
            '
            'menuLayers
            '
            Me.menuLayers.Index = 3
            Me.menuLayers.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLayersClear, Me.menuLayersClearAll, Me.menuItem3, Me.menuLayersAdd, Me.menuLayersRemove, Me.menuItem8, Me.menuLayersMoveToFront, Me.menuLayersMoveUp, Me.menuLayersMoveBack, Me.menuLayersMoveToBack, Me.menuItem10})
            Me.menuLayers.Text = "&Layers"
            '
            'menuLayersClear
            '
            Me.menuLayersClear.Index = 0
            Me.menuLayersClear.Text = "&Clear Current Layer"
            '
            'menuLayersClearAll
            '
            Me.menuLayersClearAll.Index = 1
            Me.menuLayersClearAll.Text = "Clear All Layers"
            '
            'menuItem3
            '
            Me.menuItem3.Index = 2
            Me.menuItem3.Text = "-"
            '
            'menuLayersAdd
            '
            Me.menuLayersAdd.Index = 3
            Me.menuLayersAdd.Text = "Add"
            '
            'menuLayersRemove
            '
            Me.menuLayersRemove.Index = 4
            Me.menuLayersRemove.Text = "Remove Current"
            '
            'menuItem8
            '
            Me.menuItem8.Index = 5
            Me.menuItem8.Text = "-"
            '
            'menuLayersMoveToFront
            '
            Me.menuLayersMoveToFront.Index = 6
            Me.menuLayersMoveToFront.Text = "Move To Front"
            '
            'menuLayersMoveUp
            '
            Me.menuLayersMoveUp.Index = 7
            Me.menuLayersMoveUp.Text = "Move Up"
            '
            'menuLayersMoveBack
            '
            Me.menuLayersMoveBack.Index = 8
            Me.menuLayersMoveBack.Text = "Move Back"
            '
            'menuLayersMoveToBack
            '
            Me.menuLayersMoveToBack.Index = 9
            Me.menuLayersMoveToBack.Text = "Move To Back"
            '
            'menuItem10
            '
            Me.menuItem10.Index = 10
            Me.menuItem10.Text = "-"
            '
            'menuSecurity
            '
            Me.menuSecurity.Index = 4
            Me.menuSecurity.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSecurityLockAnnotations, Me.menuSecurityLockLayer, Me.menuItem20, Me.menuSecurityUnlockAnnotations, Me.menuSecurityUnlockLayer, Me.menuItem12, Me.menuSecuritySelectImage, Me.menuSecurityClearImage})
            Me.menuSecurity.Text = "&Security"
            '
            'menuSecurityLockAnnotations
            '
            Me.menuSecurityLockAnnotations.Index = 0
            Me.menuSecurityLockAnnotations.Text = "Lock Selected Annotations"
            '
            'menuSecurityLockLayer
            '
            Me.menuSecurityLockLayer.Index = 1
            Me.menuSecurityLockLayer.Text = "Lock Current Layer"
            '
            'menuItem20
            '
            Me.menuItem20.Index = 2
            Me.menuItem20.Text = "-"
            '
            'menuSecurityUnlockAnnotations
            '
            Me.menuSecurityUnlockAnnotations.Index = 3
            Me.menuSecurityUnlockAnnotations.Text = "Unlock Selected Annotations"
            '
            'menuSecurityUnlockLayer
            '
            Me.menuSecurityUnlockLayer.Index = 4
            Me.menuSecurityUnlockLayer.Text = "Unlock Current Layer"
            '
            'menuItem12
            '
            Me.menuItem12.Index = 5
            Me.menuItem12.Text = "-"
            '
            'menuSecuritySelectImage
            '
            Me.menuSecuritySelectImage.Index = 6
            Me.menuSecuritySelectImage.Text = "Select Locked Image"
            '
            'menuSecurityClearImage
            '
            Me.menuSecurityClearImage.Index = 7
            Me.menuSecurityClearImage.Text = "Clear Locked Image"
            '
            'menuHelp
            '
            Me.menuHelp.Index = 5
            Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuHelpAbout})
            Me.menuHelp.Text = "&Help"
            '
            'menuHelpAbout
            '
            Me.menuHelpAbout.Index = 0
            Me.menuHelpAbout.Text = "&About..."
            '
            'statusBar1
            '
            Me.statusBar1.Location = New System.Drawing.Point(80, 587)
            Me.statusBar1.Name = "statusBar1"
            Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusFile, Me.statusInfo, Me.statusPage, Me.statusAnnCount, Me.statusResolution})
            Me.statusBar1.ShowPanels = True
            Me.statusBar1.Size = New System.Drawing.Size(610, 22)
            Me.statusBar1.SizingGrip = False
            Me.statusBar1.TabIndex = 0
            Me.statusBar1.Text = "statusBar1"
            '
            'statusFile
            '
            Me.statusFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.statusFile.Name = "statusFile"
            Me.statusFile.Text = "No File"
            Me.statusFile.Width = 362
            '
            'statusInfo
            '
            Me.statusInfo.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
            Me.statusInfo.Name = "statusInfo"
            Me.statusInfo.Width = 10
            '
            'statusPage
            '
            Me.statusPage.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusPage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
            Me.statusPage.Name = "statusPage"
            Me.statusPage.Text = "Page 0 of 0"
            Me.statusPage.Width = 72
            '
            'statusAnnCount
            '
            Me.statusAnnCount.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusAnnCount.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
            Me.statusAnnCount.Name = "statusAnnCount"
            Me.statusAnnCount.Text = "Annotations:  0"
            Me.statusAnnCount.Width = 90
            '
            'statusResolution
            '
            Me.statusResolution.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusResolution.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
            Me.statusResolution.Name = "statusResolution"
            Me.statusResolution.Text = "150px / Inch"
            Me.statusResolution.Width = 76
            '
            'annotateViewer1
            '
            Me.annotateViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray
            Me.annotateViewer1.DefaultSecurity = Nothing
            Me.annotateViewer1.DisplayProfile = Nothing
            Me.annotateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.annotateViewer1.Location = New System.Drawing.Point(80, 0)
            Me.annotateViewer1.Magnifier.BackColor = System.Drawing.Color.White
            Me.annotateViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.annotateViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.annotateViewer1.Name = "annotateViewer1"
            Me.annotateViewer1.OutputProfile = Nothing
            Me.annotateViewer1.RotationSnapInterval = 0.0!
            Me.annotateViewer1.RotationSnapThreshold = 0.0!
            Me.annotateViewer1.Selection = Nothing
            Me.annotateViewer1.Size = New System.Drawing.Size(610, 587)
            Me.annotateViewer1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.[Default]
            Me.annotateViewer1.TabIndex = 1
            Me.annotateViewer1.Text = "annotateViewer1"
            Me.annotateViewer1.ToolTip = Nothing
            Me.annotateViewer1.UndoManager.Levels = 0
            '
            'splitter1
            '
            Me.splitter1.Dock = System.Windows.Forms.DockStyle.Right
            Me.splitter1.Location = New System.Drawing.Point(690, 0)
            Me.splitter1.MinExtra = 200
            Me.splitter1.MinSize = 200
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(6, 609)
            Me.splitter1.TabIndex = 2
            Me.splitter1.TabStop = False
            '
            'panelRight
            '
            Me.panelRight.Controls.Add(Me.panelAnnotation)
            Me.panelRight.Controls.Add(Me.splitter2)
            Me.panelRight.Controls.Add(Me.panelLayer)
            Me.panelRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.panelRight.Location = New System.Drawing.Point(696, 0)
            Me.panelRight.Name = "panelRight"
            Me.panelRight.Size = New System.Drawing.Size(200, 609)
            Me.panelRight.TabIndex = 3
            '
            'panelAnnotation
            '
            Me.panelAnnotation.Controls.Add(Me.propGridAnnotation)
            Me.panelAnnotation.Controls.Add(Me.lblActive)
            Me.panelAnnotation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelAnnotation.Location = New System.Drawing.Point(0, 0)
            Me.panelAnnotation.Name = "panelAnnotation"
            Me.panelAnnotation.Size = New System.Drawing.Size(200, 379)
            Me.panelAnnotation.TabIndex = 4
            '
            'propGridAnnotation
            '
            Me.propGridAnnotation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.propGridAnnotation.LineColor = System.Drawing.SystemColors.ScrollBar
            Me.propGridAnnotation.Location = New System.Drawing.Point(0, 24)
            Me.propGridAnnotation.Name = "propGridAnnotation"
            Me.propGridAnnotation.Size = New System.Drawing.Size(200, 355)
            Me.propGridAnnotation.TabIndex = 6
            '
            'lblActive
            '
            Me.lblActive.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblActive.Location = New System.Drawing.Point(0, 0)
            Me.lblActive.Name = "lblActive"
            Me.lblActive.Size = New System.Drawing.Size(200, 24)
            Me.lblActive.TabIndex = 5
            Me.lblActive.Text = "Active Annotation"
            Me.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'splitter2
            '
            Me.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.splitter2.Location = New System.Drawing.Point(0, 379)
            Me.splitter2.MinExtra = 100
            Me.splitter2.MinSize = 100
            Me.splitter2.Name = "splitter2"
            Me.splitter2.Size = New System.Drawing.Size(200, 6)
            Me.splitter2.TabIndex = 3
            Me.splitter2.TabStop = False
            '
            'panelLayer
            '
            Me.panelLayer.Controls.Add(Me.lblLayer)
            Me.panelLayer.Controls.Add(Me.propGridTemplate)
            Me.panelLayer.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panelLayer.Location = New System.Drawing.Point(0, 385)
            Me.panelLayer.Name = "panelLayer"
            Me.panelLayer.Size = New System.Drawing.Size(200, 224)
            Me.panelLayer.TabIndex = 2
            '
            'lblLayer
            '
            Me.lblLayer.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblLayer.Location = New System.Drawing.Point(0, 0)
            Me.lblLayer.Name = "lblLayer"
            Me.lblLayer.Size = New System.Drawing.Size(200, 24)
            Me.lblLayer.TabIndex = 3
            Me.lblLayer.Text = "Annotation Template"
            Me.lblLayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'propGridTemplate
            '
            Me.propGridTemplate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.propGridTemplate.LineColor = System.Drawing.SystemColors.ScrollBar
            Me.propGridTemplate.Location = New System.Drawing.Point(0, 0)
            Me.propGridTemplate.Name = "propGridTemplate"
            Me.propGridTemplate.Size = New System.Drawing.Size(200, 224)
            Me.propGridTemplate.TabIndex = 2
            '
            'toolBar1
            '
            Me.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
            Me.toolBar1.AutoSize = False
            Me.toolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbEllipse, Me.tbFreehand, Me.tbLine, Me.tbLines, Me.tbPolygon, Me.tbRetangle, Me.tbTriangle, Me.tbTrianglePoint, Me.tbArc, Me.tbSpacer1, Me.tbSep1, Me.tbRectangleHighlighter, Me.tbFreehandHighlighter, Me.tbSep2, Me.tbEmbeddedImage, Me.tbReferencedImage, Me.tbSep3, Me.tbRectangleHotspot, Me.tbFreehandHotspot, Me.tbSep4, Me.tbText, Me.tbCallout, Me.tbStickyNote, Me.tbRubberStamp, Me.tbRedaction, Me.tbSpacer, Me.tbSep5, Me.tbPdfMarkup, Me.tbPdfLine})
            Me.toolBar1.Dock = System.Windows.Forms.DockStyle.Left
            Me.toolBar1.DropDownArrows = True
            Me.toolBar1.ImageList = Me.toolImageList
            Me.toolBar1.Location = New System.Drawing.Point(0, 0)
            Me.toolBar1.Name = "toolBar1"
            Me.toolBar1.ShowToolTips = True
            Me.toolBar1.Size = New System.Drawing.Size(80, 609)
            Me.toolBar1.TabIndex = 4
            '
            'tbEllipse
            '
            Me.tbEllipse.Name = "tbEllipse"
            Me.tbEllipse.ToolTipText = "Ellipse"
            '
            'tbFreehand
            '
            Me.tbFreehand.Name = "tbFreehand"
            Me.tbFreehand.ToolTipText = "Freehand"
            '
            'tbLine
            '
            Me.tbLine.Name = "tbLine"
            Me.tbLine.ToolTipText = "Line"
            '
            'tbLines
            '
            Me.tbLines.Name = "tbLines"
            Me.tbLines.ToolTipText = "Lines"
            '
            'tbPolygon
            '
            Me.tbPolygon.Name = "tbPolygon"
            Me.tbPolygon.ToolTipText = "Polygon"
            '
            'tbRetangle
            '
            Me.tbRetangle.Name = "tbRetangle"
            Me.tbRetangle.ToolTipText = "Rectangle"
            '
            'tbTriangle
            '
            Me.tbTriangle.Name = "tbTriangle"
            Me.tbTriangle.ToolTipText = "Triangle"
            '
            'tbTrianglePoint
            '
            Me.tbTrianglePoint.Name = "tbTrianglePoint"
            Me.tbTrianglePoint.ToolTipText = "Triangle Point"
            '
            'tbArc
            '
            Me.tbArc.Name = "tbArc"
            Me.tbArc.ToolTipText = "Arc"
            '
            'tbSep1
            '
            Me.tbSep1.Name = "tbSep1"
            Me.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
            '
            'tbRectangleHighlighter
            '
            Me.tbRectangleHighlighter.Name = "tbRectangleHighlighter"
            Me.tbRectangleHighlighter.ToolTipText = "Rectangle Highlighter"
            '
            'tbFreehandHighlighter
            '
            Me.tbFreehandHighlighter.Name = "tbFreehandHighlighter"
            Me.tbFreehandHighlighter.ToolTipText = "Freehand Highlighter"
            '
            'tbSep2
            '
            Me.tbSep2.Name = "tbSep2"
            Me.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
            '
            'tbEmbeddedImage
            '
            Me.tbEmbeddedImage.Name = "tbEmbeddedImage"
            Me.tbEmbeddedImage.ToolTipText = "Embedded Image"
            '
            'tbReferencedImage
            '
            Me.tbReferencedImage.Name = "tbReferencedImage"
            Me.tbReferencedImage.ToolTipText = "Referenced Image"
            '
            'tbSep3
            '
            Me.tbSep3.Name = "tbSep3"
            Me.tbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
            '
            'tbRectangleHotspot
            '
            Me.tbRectangleHotspot.Name = "tbRectangleHotspot"
            Me.tbRectangleHotspot.ToolTipText = "Rectangle Hotspot"
            '
            'tbFreehandHotspot
            '
            Me.tbFreehandHotspot.Name = "tbFreehandHotspot"
            Me.tbFreehandHotspot.ToolTipText = "Freehand Hotspot"
            '
            'tbSep4
            '
            Me.tbSep4.Name = "tbSep4"
            Me.tbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
            '
            'tbText
            '
            Me.tbText.Name = "tbText"
            Me.tbText.ToolTipText = "Text"
            '
            'tbCallout
            '
            Me.tbCallout.Name = "tbCallout"
            Me.tbCallout.ToolTipText = "Callout"
            '
            'tbStickyNote
            '
            Me.tbStickyNote.Name = "tbStickyNote"
            Me.tbStickyNote.ToolTipText = "Sticky Note"
            '
            'tbRubberStamp
            '
            Me.tbRubberStamp.Name = "tbRubberStamp"
            Me.tbRubberStamp.ToolTipText = "Rubber Stamp"
            '
            'tbRedaction
            '
            Me.tbRedaction.Name = "tbRedaction"
            Me.tbRedaction.ToolTipText = "Redaction"
            '
            'tbSpacer
            '
            Me.tbSpacer.Enabled = False
            Me.tbSpacer.Name = "tbSpacer"
            '
            'tbSep5
            '
            Me.tbSep5.Name = "tbSep5"
            Me.tbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
            '
            'tbPdfMarkup
            '
            Me.tbPdfMarkup.DropDownMenu = Me.contextPdf
            Me.tbPdfMarkup.Name = "tbPdfMarkup"
            Me.tbPdfMarkup.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
            Me.tbPdfMarkup.ToolTipText = "PDF Markup"
            '
            'contextPdf
            '
            Me.contextPdf.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuPdfHighlight, Me.menuPdfSquiggly, Me.menuPdfStrikeOut, Me.menuPdfUnderline})
            '
            'menuPdfHighlight
            '
            Me.menuPdfHighlight.Index = 0
            Me.menuPdfHighlight.Text = "Highlight"
            '
            'menuPdfSquiggly
            '
            Me.menuPdfSquiggly.Index = 1
            Me.menuPdfSquiggly.Text = "Squiggly"
            '
            'menuPdfStrikeOut
            '
            Me.menuPdfStrikeOut.Index = 2
            Me.menuPdfStrikeOut.Text = "Strike Out"
            '
            'menuPdfUnderline
            '
            Me.menuPdfUnderline.Index = 3
            Me.menuPdfUnderline.Text = "Underline"
            '
            'tbPdfLine
            '
            Me.tbPdfLine.Name = "tbPdfLine"
            Me.tbPdfLine.ToolTipText = "PDF Line"
            '
            'toolImageList
            '
            Me.toolImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.toolImageList.ImageSize = New System.Drawing.Size(32, 32)
            Me.toolImageList.TransparentColor = System.Drawing.Color.Transparent
            '
            'tbSpacer1
            '
            Me.tbSpacer1.Enabled = False
            Me.tbSpacer1.Name = "tbSpacer1"
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(896, 609)
            Me.Controls.Add(Me.annotateViewer1)
            Me.Controls.Add(Me.statusBar1)
            Me.Controls.Add(Me.toolBar1)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.panelRight)
            Me.Menu = Me.mainMenu1
            Me.MinimumSize = New System.Drawing.Size(512, 448)
            Me.Name = "Form1"
            Me.Text = "Atalasoft DotAnnotate Demo"
            CType(Me.statusFile, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusInfo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusPage, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusAnnCount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusResolution, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelRight.ResumeLayout(False)
            Me.panelAnnotation.ResumeLayout(False)
            Me.panelLayer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1)
        End Sub

#Region "File Menu"

        Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
            Me.Close()
        End Sub

        Private Sub menuFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileOpen.Click
            Dim dlg As OpenFileDialog = New OpenFileDialog
            If Me._lastOpenDirectory <> "" Then
                dlg.InitialDirectory = Me._lastOpenDirectory
            Else
                ' try to locate images folder
                Dim imagesFolder As String = Application.ExecutablePath
                ' we assume we are running under the DotImage install folder
                Dim pos As Integer = imagesFolder.IndexOf("DotImage ")
                If pos <> -1 Then
                    imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) & "\Images"
                End If

                'use this folder as starting point			
                dlg.InitialDirectory = imagesFolder
            End If

            ' We're only working with a few of the supported formats in this demo.
            'If _pdfAnnotationSupport Then
            '    dlg.Filter = "Images|*.jpg;*.tif;*.png;*.bmp;*.gif" & (";*.pdf")
            'Else
            '    dlg.Filter = "Images|*.jpg;*.tif;*.png;*.bmp;*.gif" & ("")
            'End If
            dlg.Filter = HelperMethods.CreateDialogFilter(True)

            Try
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    Me._lastOpenDirectory = Path.GetDirectoryName(dlg.FileName)
                    Me.annotateViewer1.Open(dlg.FileName, -1, True)
                    Me.statusFile.Text = dlg.FileName
                    Me.statusPage.Text = "Page 1 of " & Me.annotateViewer1.Images.Count.ToString()
                    Me.statusResolution.Text = Me.annotateViewer1.Resolution.ToString() & " / " & Me.annotateViewer1.Units.ToString()
                    UpdateMenu()
                    UpdateLayerItemMenu()
                End If
            Finally
                dlg.Dispose()
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub menuFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileSave.Click
            Dim dlg As SaveFileDialog = New SaveFileDialog
            If _pdfAnnotationSupport Then
                dlg.Filter = "TIFF (*.tif)|*.tif|JPEG (*.jpg)|*.jpg" & ("|PDF (*.pdf)|*.pdf")
            Else
                dlg.Filter = "TIFF (*.tif)|*.tif|JPEG (*.jpg)|*.jpg" & ("")
            End If

            Try
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    If dlg.FilterIndex = 3 Then
                        ' Pdf has to be handled a little differently.
                        Me.annotateViewer1.Save(dlg.FileName, New Atalasoft.Imaging.Codec.Pdf.PdfEncoder)
                        SavePdfAnnotations(dlg.FileName)
                    Else
                        Dim encoder As ImageEncoder = Nothing
                        If dlg.FilterIndex = 1 Then
                            encoder = New TiffEncoder
                        ElseIf dlg.FilterIndex = 2 Then
                            encoder = New JpegEncoder
                        End If

                        If Not encoder Is Nothing Then
                            Me.annotateViewer1.Save(dlg.FileName, CType(IIf(TypeOf encoder Is IAnnotationEncoder, encoder, Nothing), IAnnotationEncoder), -1, True)
                        End If
                    End If
                End If
            Finally
                dlg.Dispose()
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub SavePdfAnnotations(ByVal fileName As String)
            'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
            '			using (FileStream fs = New FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            Try
                Dim exp As Atalasoft.Annotate.Exporters.PdfAnnotationDataExporter = New Atalasoft.Annotate.Exporters.PdfAnnotationDataExporter

                ' added by RS 2015/08/18 to ensure proper PDF embedding/round tripping
                exp.AlwaysEmbedAnnotationData = True

                Dim pageSizes As SizeF() = New SizeF(annotateViewer1.Images.Count - 1) {}
                Dim resolutions As Dpi() = New Dpi(annotateViewer1.Images.Count - 1) {}

                Dim i As Integer = 0
                'ORIGINAL LINE: for(int i = 0; i < annotateViewer1.Images.Count; i += 1)
                'INSTANT VB NOTE: This 'for' loop was translated to a VB 'Do While' loop:
                Do While i < annotateViewer1.Images.Count
                    pageSizes(i) = New SizeF(annotateViewer1.Images(i).Size.Width, annotateViewer1.Images(i).Size.Height)
                    resolutions(i) = annotateViewer1.Images(i).Resolution
                    i += 1
                Loop

                Dim layers As LayerCollection = annotateViewer1.Annotations.Layers
                Dim units As AnnotationUnit = annotateViewer1.Units

                Dim data As New AnnotationDataCollection()
                For Each layer As LayerAnnotation In layers
                    data.Add(layer.Data)
                Next layer

                exp.ExportOver(fs, pageSizes, units, resolutions, data)
            Finally
                Dim disp As IDisposable = fs
                disp.Dispose()
            End Try
            'INSTANT VB NOTE: End of the original C# 'using' block
        End Sub

        Private Sub menuFileNextPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileNextPage.Click
            Me.annotateViewer1.Images.MoveNext()
            Dim index As Integer = Me.annotateViewer1.Images.IndexOf(Me.annotateViewer1.Image) + 1
            Me.statusPage.Text = "Page " & index.ToString() & " of " & Me.annotateViewer1.Images.Count.ToString()
            Me.statusResolution.Text = Me.annotateViewer1.Resolution.ToString() & " / " & Me.annotateViewer1.Units.ToString()

            ' Update menu items.
            index -= 1
            UpdateNextPreviousMenus(index)
            UpdateLayerMenuItemIndex(index)
        End Sub

        Private Sub menuFilePreviousPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFilePreviousPage.Click
            Me.annotateViewer1.Images.MovePrevious()
            Dim index As Integer = Me.annotateViewer1.Images.IndexOf(Me.annotateViewer1.Image) + 1
            Me.statusPage.Text = "Page " & index.ToString() & " of " & Me.annotateViewer1.Images.Count.ToString()
            Me.statusResolution.Text = Me.annotateViewer1.Resolution.ToString() & " / " & Me.annotateViewer1.Units.ToString()

            ' Update menu items.
            index -= 1
            UpdateNextPreviousMenus(index)
            UpdateLayerMenuItemIndex(index)
        End Sub

        Private Sub menuFilePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFilePrint.Click
            Dim doc As Atalasoft.Annotate.UI.AnnotatePrintDocument = New AnnotatePrintDocument(Me.annotateViewer1.Annotations, Me.annotateViewer1.Images)
            doc.ScaleMode = Atalasoft.Imaging.WinControls.PrintScaleMode.FitToMargins
            doc.Center = True
            doc.Units = Me.annotateViewer1.Units

            'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
            '			using (PrintDialog dlg = New PrintDialog())
            Dim dlg As PrintDialog = New PrintDialog
            Try
                dlg.Document = doc
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    doc.Print()
                End If
            Finally
                Dim disp As IDisposable = dlg
                disp.Dispose()
            End Try
            'INSTANT VB NOTE: End of the original C# 'using' block
            doc.Dispose()
        End Sub

        Private Sub menuFileBurn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileBurn.Click
            If Me.annotateViewer1.Image Is Nothing Then
                MessageBox.Show(Me, "An image must be loaded into the viewer before you can use the burn feature.", "No Image Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If _appSettings.BurnConvert Then
                ' We are only burning the current image.
                ' Because we can't get a Graphics object from an indexed image
                ' we may need to convert it to 24-bit.
                If Me.annotateViewer1.Image.ColorDepth < 24 Then
                    Dim cmd As Atalasoft.Imaging.ImageProcessing.ChangePixelFormatCommand = New Atalasoft.Imaging.ImageProcessing.ChangePixelFormatCommand(PixelFormat.Pixel24bppBgr)
                    Me.annotateViewer1.ApplyCommand(cmd)
                End If

                Dim bmp As Bitmap = Me.annotateViewer1.Image.ToBitmap()
                Me.annotateViewer1.Annotations.RenderAnnotations(New AnnotationImage(bmp))
                Dim img As AtalaImage = AtalaImage.FromBitmap(bmp)

                Me.annotateViewer1.Image = img
            Else
                Me.annotateViewer1.Burn()
                Me.annotateViewer1.Refresh()
            End If
        End Sub

        Private Sub menuFileRotate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileRotate.Click
            Me.annotateViewer1.RotateDocument(DocumentRotation.Rotate90)
        End Sub

        Private Sub menuZoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuZoom25.Click, menuZoom50.Click, menuZoom100.Click, menuZoom200.Click, menuZoom500.Click
            Dim item As MenuItem = CType(IIf(TypeOf sender Is MenuItem, sender, Nothing), MenuItem)
            If item Is Nothing Then
                Return
            End If

            Dim zoom As Double = Double.Parse(item.Text.Replace("%", "")) / 100.0
            Me.annotateViewer1.Zoom = zoom

            Me.menuZoom100.Checked = False
            Me.menuZoom200.Checked = False
            Me.menuZoom25.Checked = False
            Me.menuZoom50.Checked = False
            Me.menuZoom500.Checked = False
            item.Checked = True
        End Sub

#End Region

#Region "Annotations Menu"

        Private Sub menuAnnotationsLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnotationsLoad.Click
            Dim dlg As OpenFileDialog = New OpenFileDialog

            ' WNG isn't a real extension for WANG annotations but we'll use it for our demo.
            dlg.Filter = "XMP (*.xml)|*.xml|WANG (*.wng)|*.wng|Binary (*.bin)|*.bin"

            Try
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
                    '					using (FileStream fs = New FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    Dim fs As FileStream = New FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Try
                        If dlg.FilterIndex = 3 Then
                            Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            bf.Binder = New CustomDataBinder
                            Me.annotateViewer1.Annotations.Load(fs, bf)
                        Else
                            If dlg.FilterIndex = 1 Then
                                Me.annotateViewer1.Annotations.Load(fs, (AnnotationDataFormat.Xmp))
                            Else
                                Me.annotateViewer1.Annotations.Load(fs, (AnnotationDataFormat.Wang))
                            End If
                        End If
                    Finally
                        Dim disp As IDisposable = fs
                        disp.Dispose()
                    End Try
                    'INSTANT VB NOTE: End of the original C# 'using' block
                    UpdateMenu()
                    UpdateLayerItemMenu()
                End If
            Finally
                dlg.Dispose()
            End Try

        End Sub

        Private Sub menuAnnotationsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnotationsSave.Click
            Dim dlg As SaveFileDialog = New SaveFileDialog
            dlg.Filter = "XMP (*.xml)|*.xml|WANG (*.wng)|*.wng|Binary (*.bin)|*.bin"

            Try
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
                    '					using (FileStream fs = New FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    Dim fs As FileStream = New FileStream(dlg.FileName, FileMode.Create, FileAccess.Write, FileShare.None)
                    Try
                        If dlg.FilterIndex = 3 Then
                            Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                            Me.annotateViewer1.Annotations.Save(fs, bf)
                        Else
                            If dlg.FilterIndex = 1 Then
                                Me.annotateViewer1.Annotations.Save(fs, (AnnotationDataFormat.Xmp))
                            Else
                                Me.annotateViewer1.Annotations.Save(fs, (AnnotationDataFormat.Wang))
                            End If
                        End If
                    Finally
                        Dim disp As IDisposable = fs
                        disp.Dispose()
                    End Try
                    'INSTANT VB NOTE: End of the original C# 'using' block
                End If
            Finally
                dlg.Dispose()
            End Try
        End Sub

        Private Sub menuAnnotationsRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnotationsRemove.Click
            If Not Me.annotateViewer1.Annotations.ActiveAnnotation Is Nothing Then
                Me.propGridAnnotation.SelectedObject = Nothing

                Dim annotations As AnnotationUI() = Me.annotateViewer1.Annotations.SelectedAnnotations
                For Each ann As AnnotationUI In annotations
                    ann.Remove()
                Next ann

                UpdateMenu()
            End If
        End Sub

        Private Sub menuAnnotationsMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnotationsMoveToFront.Click, menuAnnotationsMoveUp.Click, menuAnnotationsMoveBack.Click, menuAnnotationsMoveToBack.Click
            Dim item As MenuItem = CType(IIf(TypeOf sender Is MenuItem, sender, Nothing), MenuItem)
            If item Is Nothing Then
                Return
            End If

            ' This will act on the activate annotation (if there is one).
            If Not Me.annotateViewer1.Annotations.ActiveAnnotation Is Nothing Then
                MoveAnnotationObject(Me.annotateViewer1.Annotations.ActiveAnnotation, item.Text)
            End If
        End Sub

        Private Sub menuFlipH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFlipH.Click
            If Not Me.annotateViewer1.Annotations.ActiveAnnotation Is Nothing Then
                Me.annotateViewer1.Annotations.ActiveAnnotation.Mirror(MirrorDirection.Horizontal, True)
            End If
        End Sub

        Private Sub menuFlipV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFlipV.Click
            If Not Me.annotateViewer1.Annotations.ActiveAnnotation Is Nothing Then
                Me.annotateViewer1.Annotations.ActiveAnnotation.Mirror(MirrorDirection.Vertical, True)
            End If
        End Sub

        Private Sub menuAnnotationsTooltips_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnotationsTooltips.Click
            Me.menuAnnotationsTooltips.Checked = Not Me.menuAnnotationsTooltips.Checked
            If Me.menuAnnotationsTooltips.Checked Then
                Me.annotateViewer1.Annotations.ToolTip = Me.toolTip1
            Else
                Me.annotateViewer1.Annotations.ToolTip = Nothing
            End If
        End Sub

        Private Sub menuAnnGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnGroup.Click
            Me.annotateViewer1.Annotations.Group()
            UpdateMenu()
        End Sub

        Private Sub menuAnnUngroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAnnUngroup.Click
            Me.annotateViewer1.Annotations.Ungroup()
            UpdateMenu()
        End Sub

        Private Sub menuEnableClassyRenderers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEnableClassyRenderers.Click
            Me.menuEnableClassyRenderers.Checked = Not Me.menuEnableClassyRenderers.Checked
            If Me.menuEnableClassyRenderers.Checked Then
                ClassyAnnotationRenderers.InstallClassyRenderers()
            Else
                ClassyAnnotationRenderers.InstallDefaultRenderers()
            End If

            Me.annotateViewer1.Refresh()
        End Sub

        Private Sub menuInteractModeNone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuInteractModeNone.Click
            Me.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.None
            UpdateInteractModeMenu()
            Me.propGridAnnotation.SelectedObject = Nothing
        End Sub

        Private Sub menuInteractModeAuthor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuInteractModeAuthor.Click
            Me.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.Author
            UpdateInteractModeMenu()
        End Sub

        Private Sub menuInteractModeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuInteractModeView.Click
            Me.annotateViewer1.Annotations.InteractMode = AnnotateInteractMode.View
            UpdateInteractModeMenu()
            Me.propGridAnnotation.SelectedObject = Nothing
        End Sub

        Private Sub UpdateInteractModeMenu()
            Me.menuInteractModeAuthor.Checked = False
            Me.menuInteractModeNone.Checked = False
            Me.menuInteractModeView.Checked = False

            Select Case Me.annotateViewer1.Annotations.InteractMode
                Case AnnotateInteractMode.None
                    Me.menuInteractModeNone.Checked = True
                Case AnnotateInteractMode.Author
                    Me.menuInteractModeAuthor.Checked = True
                Case AnnotateInteractMode.View
                    Me.menuInteractModeView.Checked = True
            End Select
        End Sub

#End Region

#Region "Add Annotations"

        Private Sub AddNewAnnotation(ByVal annotation As AnnotationUI)
            If annotation Is Nothing Then
                Return
            End If

            Me._templates.SetAnnotationDefaults(annotation)
            Me.annotateViewer1.Annotations.CreateAnnotation(annotation, CreateAnnotationMode.Default)
        End Sub

        Private Sub menuAddCallout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddCallout.Click
            AddNewAnnotation(New CalloutAnnotation("", Nothing, Nothing, 2, Nothing, Nothing, New AnnotationPen(Color.Black), 20, PointF.Empty, True))
        End Sub

        Private Sub menuAddEllipse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddEllipse.Click
            AddNewAnnotation(New EllipseAnnotation)
        End Sub

        Private Function GetImageFileName() As String
            Dim dlg As OpenFileDialog = New OpenFileDialog
            dlg.Filter = "Images|*.png;*.jpg;*.tif;*.gif;*.bmp"

            Try
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Return dlg.FileName
                End If
            Finally
                dlg.Dispose()
            End Try

            Return Nothing
        End Function

        Private Sub menuAddEmbeddedImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddEmbeddedImage.Click
            Dim file As String = GetImageFileName()
            If file Is Nothing Then
                Return
            End If

            Try
                AddNewAnnotation(New EmbeddedImageAnnotation(New AnnotationImage(file), True))
            Catch ex As Exception
                MessageBox.Show(Me, "Exception creating an EmbeddedImageAnnotation" & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub menuAddFreehand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddFreehand.Click
            AddNewAnnotation(New FreehandAnnotation)
        End Sub

        Private Sub menuAddFreehandHotSpot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddFreehandHotSpot.Click
            Dim hs As HotSpotFreehandAnnotation = New HotSpotFreehandAnnotation(New AnnotationBrush(Color.DarkRed))
            Me.annotateViewer1.Annotations.CreateAnnotation(hs)
        End Sub

        Private Sub menuAddHotSpot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddHotSpot.Click
            Dim hs As HotSpotAnnotation = New HotSpotAnnotation(RectangleF.Empty, New AnnotationBrush(Color.DarkRed))
            Me.annotateViewer1.Annotations.CreateAnnotation(hs)
        End Sub

        Private Sub menuAddLine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddLine.Click
            AddNewAnnotation(New LineAnnotation)
        End Sub

        Private Sub menuAddLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddLines.Click
            AddNewAnnotation(New LinesAnnotation)
        End Sub

        Private Sub menuAddPolygon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPolygon.Click
            AddNewAnnotation(New PolygonAnnotation)
        End Sub

        Private Sub menuAddRectangle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddRectangle.Click
            Dim rc As RectangleAnnotation = New RectangleAnnotation

            ' Uncomment the following lines to test making 
            ' the top-right grip used for rotation.
            '			rc.Grips[8].Visible = false;
            '			rc.Grips[2].Action = AnnotationGripAction.Rotating;

            AddNewAnnotation(rc)
        End Sub

        Private Sub menuAddReferencedImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddReferencedImage.Click
            Dim file As String = GetImageFileName()
            If file Is Nothing Then
                Return
            End If

            Try
                AddNewAnnotation(New ReferencedImageAnnotation(file, False))
            Catch ex As Exception
                MessageBox.Show(Me, "Exception creating a ReferencedImageAnnotation" & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub menuAddRubberStamp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddRubberStamp.Click
            Dim rs As RubberStampAnnotation = New RubberStampAnnotation
            rs.Text = "DRAFT"
            Me.annotateViewer1.Annotations.CreateAnnotation(rs, CreateAnnotationMode.Default)
        End Sub

        Private Sub menuAddText_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddText.Click
            AddNewAnnotation(New TextAnnotation)
        End Sub

        Private Sub menuAddTriangle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddTriangle.Click
            AddNewAnnotation(New TriangleAnnotation)
        End Sub

        Private Sub menuAddTrianglePoints_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddTrianglePoints.Click
            AddNewAnnotation(New TrianglePointAnnotation)
        End Sub

#End Region

#Region "Annotation Events"

        Private Sub Annotations_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            UpdatePropertyGridValues()
        End Sub

        Private Sub UpdatePropertyGridValues()
            Me.lblActive.Text = "Active Annotation"
            Me.propGridAnnotation.SelectedObject = Me.annotateViewer1.Annotations.ActiveAnnotation
            UpdateMenu()
            If Me.annotateViewer1.Annotations.CurrentLayer Is Nothing Then
                UpdateLayerMenuItemIndex(-1)
            Else
                UpdateLayerMenuItemIndex(Me.annotateViewer1.Annotations.Layers.IndexOf(Me.annotateViewer1.Annotations.CurrentLayer))
            End If
        End Sub

        Private Sub Annotations_AnnotationCreated(ByVal sender As Object, ByVal e As AnnotationEventArgs)
            UpdateMenu()
            If _layerMenus Is Nothing Then
                UpdateLayerItemMenu()
            End If

            Me.annotateViewer1.Annotations.ClearSelection()
            Me.annotateViewer1.Annotations.ActiveAnnotation = e.Annotation
            e.Annotation.Selected = True
            UpdatePropertyGridValues()
        End Sub

        Private Sub Annotations_Rotating(ByVal sender As Object, ByVal e As AnnotationEventArgs)
            Me.statusInfo.Text = "Rotating: " & e.Annotation.Data.Rotation.ToString()
        End Sub

        Private Sub Annotations_Moving(ByVal sender As Object, ByVal e As AnnotationEventArgs)
            Me.statusInfo.Text = "Moving: " & e.Annotation.Data.Location.ToString()
        End Sub

        Private Sub Annotations_Resizing(ByVal sender As Object, ByVal e As AnnotationEventArgs)
            Dim rc As RectangleF = New RectangleF(e.Annotation.Location, e.Annotation.Size)
            Me.statusInfo.Text = "Resizing: " & rc.X.ToString() & ", " & rc.Y.ToString() & ", " & rc.Width.ToString() & ", " & rc.Height.ToString()
        End Sub

        Private Sub Annotations_MovedResizedRotated(ByVal sender As Object, ByVal e As AnnotationEventArgs)
            Me.statusInfo.Text = ""
            UpdateMenu()
        End Sub

#End Region

#Region "Layers Menu"

        Private Sub menuLayersClearLayer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLayersClear.Click
            Me.annotateViewer1.Annotations.CurrentLayer.Items.Clear()
            Me.propGridAnnotation.SelectedObject = Nothing
            UpdateMenu()
        End Sub

        Private Sub menuLayersClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLayersClearAll.Click
            For Each layer As LayerAnnotation In Me.annotateViewer1.Annotations.Layers
                layer.Items.Clear()
            Next layer

            Me.propGridAnnotation.SelectedObject = Nothing
            UpdateMenu()
        End Sub

        Private Sub menuLayersMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLayersMoveToFront.Click, menuLayersMoveUp.Click, menuLayersMoveBack.Click, menuLayersMoveToBack.Click
            Dim item As MenuItem = CType(IIf(TypeOf sender Is MenuItem, sender, Nothing), MenuItem)
            If item Is Nothing Then
                Return
            End If
            MoveAnnotationObject(Me.annotateViewer1.Annotations.CurrentLayer, item.Text)
            UpdateMenu()
            UpdateLayerItemMenu()
        End Sub

        Private Sub menuLayersAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLayersAdd.Click
            Dim layer As LayerAnnotation = New LayerAnnotation

            ' If we are in multipage mode add the layer as a child
            ' of the current layer, otherwise add it as a top level layer.
            If Me.annotateViewer1.MultipageAnnotateMode Then
                Dim topLayer As LayerAnnotation = Me.annotateViewer1.Annotations.GetTopLevelLayer(Me.annotateViewer1.Annotations.CurrentLayer)
                If topLayer Is Nothing Then
                    topLayer.Items.Add(layer)
                End If
            Else
                Me.annotateViewer1.Annotations.Layers.Add(layer)
            End If

            Me.annotateViewer1.Annotations.CurrentLayer = layer

            UpdateMenu()
            UpdateLayerItemMenu()
        End Sub

        Private Sub menuLayersRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLayersRemove.Click
            If Not Me.annotateViewer1.Annotations.CurrentLayer Is Nothing Then
                ' In multipage mode, only allow child layers to be removed.
                If Me.annotateViewer1.MultipageAnnotateMode Then
                    If Not Me.annotateViewer1.Annotations.CurrentLayer.ParentLayer Is Nothing Then
                        Me.annotateViewer1.Annotations.CurrentLayer.Remove()
                    End If
                Else
                    Me.annotateViewer1.Annotations.Layers.Remove(Me.annotateViewer1.Annotations.CurrentLayer)
                End If
            End If

            UpdateMenu()
            UpdateLayerItemMenu()
        End Sub

        Private Sub OnLayerMenuItemClick(ByVal sender As Object, ByVal e As System.EventArgs)
            ' This is called when a layer name is selected from the Layers menu.
            Dim item As MenuItem = CType(IIf(TypeOf sender Is MenuItem, sender, Nothing), MenuItem)
            If item Is Nothing Then
                Return
            End If

            ' Uncheck the current layer item.
            For Each mi As MenuItem In _layerMenus
                mi.Checked = False
            Next mi

            ' Get the index from the menu text.
            Dim pos As Integer = item.Text.IndexOf(" ")
            If pos = -1 Then
                pos = item.Text.Length
            End If
            Dim index As Integer = -1

            Try
                index = Integer.Parse(item.Text.Substring(0, pos))
            Catch
                Return
            End Try

            If Me._appSettings.MultipageSupport Then
                Me.annotateViewer1.Image = Me.annotateViewer1.Images(index)
            Else
                Me.annotateViewer1.Annotations.CurrentLayer = Me.annotateViewer1.Annotations.Layers(index)
            End If

            item.Checked = True
            UpdateNextPreviousMenus(index)
        End Sub

#End Region

#Region "Help Menu"

        Private Sub menuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuHelpAbout.Click
            Dim frm As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About...", "DotAnnotate Demo")
            frm.Description = "This demo provides example code for using Atalasoft DotAnnotate, along with DotImage, to read, write and modify annotations on images."
            frm.ShowDialog(Me)
            frm.Dispose()
        End Sub

#End Region

#Region "Edit Menu"

        Private Sub menuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEdit.Popup
            If Me.annotateViewer1.Annotations.UndoManager.UndoCount = 0 Then
                Me.menuEditUndo.Text = "&Undo"
            Else
                Me.menuEditUndo.Text = "&Undo " & Me.annotateViewer1.Annotations.UndoManager.UndoDescription
            End If

            If Me.annotateViewer1.Annotations.UndoManager.RedoCount = 0 Then
                Me.menuEditRedo.Text = "&Redo"
            Else
                Me.menuEditRedo.Text = "&Redo " & Me.annotateViewer1.Annotations.UndoManager.RedoDescription
            End If
        End Sub

        Private Sub menuEditUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditUndo.Click
            Me.annotateViewer1.Annotations.UndoManager.Undo()
            UpdateMenu()
            UpdateLayerItemMenu()
        End Sub

        Private Sub menuEditRedo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditRedo.Click
            Me.annotateViewer1.Annotations.UndoManager.Redo()
            UpdateMenu()
            UpdateLayerItemMenu()
        End Sub

        Private Sub menuEditClearUndos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditClearUndos.Click
            Me.annotateViewer1.Annotations.UndoManager.Clear()
            UpdateMenu()
        End Sub

        Private Sub menuEditCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditCut.Click
            Me.annotateViewer1.Annotations.Cut()
            UpdateMenu()
        End Sub

        Private Sub menuEditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditCopy.Click
            Me.annotateViewer1.Annotations.Copy()
            UpdateMenu()
        End Sub

        Private Sub menuEditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditPaste.Click
            Me.annotateViewer1.Annotations.Paste()
            UpdateMenu()
        End Sub

        Private Sub menuEditSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditSelectAll.Click
            ' We are only selecting annotations in the current layer.
            Me.annotateViewer1.Annotations.SelectAll(False)
        End Sub

        Private Sub menuEditPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEditPreferences.Click
            Dim frm As Preferences = New Preferences(_appSettings)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                _appSettings = frm.Settings
                ApplyAppSettings()
            End If
            frm.Dispose()
        End Sub

#End Region

#Region "Security Menu"

        Private Sub menuSecurityLockAnnotations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecurityLockAnnotations.Click
            Dim selected As AnnotationUI() = Me.annotateViewer1.Annotations.SelectedAnnotations
            For Each ann As AnnotationUI In selected
                ' We'll use the basic lock class.
                ' For more control you can provide your own locking class.
                If ann.Data.Security Is Nothing Then
                    ann.Data.Security = New AnnotationLock
                End If

                ann.Data.Security.Lock("Password")
            Next ann
        End Sub

        Private Sub menuSecurityLockLayer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecurityLockLayer.Click
            Dim layer As LayerAnnotation = Me.annotateViewer1.Annotations.CurrentLayer
            If layer Is Nothing Then
                Return
            End If
            If layer.Data.Security Is Nothing Then
                layer.Data.Security = New AnnotationLock
            End If

            layer.Data.Security.Lock("Password")
        End Sub

        Private Sub menuSecurityUnlockAnnotations_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecurityUnlockAnnotations.Click
            Dim selected As AnnotationUI() = Me.annotateViewer1.Annotations.SelectedAnnotations
            For Each ann As AnnotationUI In selected
                If ann.Data.Security Is Nothing Then
                    GoTo Continue1
                End If
                ann.Data.Security.Unlock("Password")
Continue1:
            Next ann
        End Sub

        Private Sub menuSecurityUnlockLayer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecurityUnlockLayer.Click
            Dim layer As LayerAnnotation = Me.annotateViewer1.Annotations.CurrentLayer
            If layer Is Nothing Then
                Return
            End If
            If layer.Data.Security Is Nothing Then
                Return
            End If
            layer.Data.Security.Unlock("Password")
        End Sub

        Private Sub menuSecuritySelectImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecuritySelectImage.Click
            'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
            '			using (OpenFileDialog dlg = New OpenFileDialog())
            Dim dlg As OpenFileDialog = New OpenFileDialog
            Try
                dlg.Filter = "Images|*.jpg;*.gif;*.png;*.tif;*.bmp"
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Try
                        Dim img As AnnotationImage = New AnnotationImage(dlg.FileName)
                        Dim selected As AnnotationUI() = Me.annotateViewer1.Annotations.SelectedAnnotations
                        For Each ann As AnnotationUI In selected
                            If ann.Data.Security Is Nothing Then
                                ann.Data.Security = New AnnotationLock
                            End If
                            ann.Data.Security.LockedImage = img.Clone()
                        Next ann
                        img.Dispose()
                    Catch ex As Exception
                        MessageBox.Show("Error loading security image." & Constants.vbCrLf & ex.Message)
                    End Try
                End If
            Finally
                Dim disp As IDisposable = dlg
                disp.Dispose()
            End Try
            'INSTANT VB NOTE: End of the original C# 'using' block
        End Sub

        Private Sub menuSecurityClearImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSecurityClearImage.Click
            Dim selected As AnnotationUI() = Me.annotateViewer1.Annotations.SelectedAnnotations
            For Each ann As AnnotationUI In selected
                If ann.Data.Security Is Nothing Then
                    GoTo Continue1
                End If
                ann.Data.Security.LockedImage = Nothing
Continue1:
            Next ann
        End Sub

#End Region

#Region "Private Methods"

        Private Sub PopulateToolbox()
            ' Use the resource images in DotAnnotate for the tools.
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Ellipse, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Freehand, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Line, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Lines, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Polygon, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Rectangle, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(My.Resources.Triangle.ToBitmap())
            Me.toolImageList.Images.Add(My.Resources.TrianglePoint.ToBitmap())
            Me.toolImageList.Images.Add(My.Resources.Arc.ToBitmap())

            ' Separator
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.RectangleHighlighter, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.FreehandHighlighter, AnnotateIconSize.Size32))
            ' Separator
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.EmbeddedImage, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.ReferencedImage, AnnotateIconSize.Size32))
            ' Separator
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.RectangleHotspot, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.FreehandHotspot, AnnotateIconSize.Size32))
            ' Separator
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Text, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Callout, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.StickyNote, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.RubberStamp, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.Redact, AnnotateIconSize.Size32))
            ' Separator
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.PdfMarkup, AnnotateIconSize.Size32))
            Me.toolImageList.Images.Add(GetAnnotationIcon(AnnotateIcon.PdfLine, AnnotateIconSize.Size32))

            Dim imgIndex As Integer = 0

            For Each Button As ToolBarButton In Me.toolBar1.Buttons
                If Not Button.Style = ToolBarButtonStyle.Separator AndAlso Button.Enabled Then
                    Button.ImageIndex = imgIndex
                    imgIndex = imgIndex + 1
                End If
            Next
        End Sub
        Private Function GetAnnotationIcon(ByVal icon As AnnotateIcon, ByVal size As AnnotateIconSize) As System.Drawing.Image
            Dim img As Image = IconResource.ExtractAnnotationIcon(icon, size)
            If img Is Nothing Then
                Dim assm As Assembly = Assembly.LoadFrom("Atalasoft.dotImage.dll")
                If assm IsNot Nothing Then
                    Dim stream As System.IO.Stream = assm.GetManifestResourceStream("Atalasoft.Imaging.Annotate.Icons._" + size.ToString().Substring(4) + "." + icon.ToString() + ".png")
                    img = System.Drawing.Image.FromStream(stream)
                End If
            End If
            If img Is Nothing Then
                If size.ToString() = "size16" Then
                    Return New AtalaImage(16, 16, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap()
                End If
                If size.ToString() = "size24" Then
                    Return New AtalaImage(24, 24, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap()
                End If
                If size.ToString() = "size32" Then
                    Return New AtalaImage(32, 32, PixelFormat.Pixel24bppBgr, Color.White).ToBitmap()
                End If
            End If

            Return FixImageBackground(img)
        End Function

        Private Function FixImageBackground(ByVal image As System.Drawing.Image) As System.Drawing.Image
            ' Because of poor support for alpha in VS 2003 we use this workaround.
            Dim ai As Atalasoft.Imaging.AtalaImage = Atalasoft.Imaging.AtalaImage.FromBitmap(CType(IIf(TypeOf image Is System.Drawing.Bitmap, image, Nothing), System.Drawing.Bitmap))
            image.Dispose()

            Dim cmd As Atalasoft.Imaging.ImageProcessing.Channels.FlattenAlphaCommand = New Atalasoft.Imaging.ImageProcessing.Channels.FlattenAlphaCommand(Me.BackColor)
            Dim results As Atalasoft.Imaging.ImageProcessing.ImageResults = cmd.Apply(ai)
            If (Not results.IsImageSourceImage) Then
                ai.Dispose()
                ai = results.Image
            End If

            image = ai.ToBitmap()
            ai.Dispose()
            Return image
        End Function

        Private Sub ApplyAppSettings()
            If _appSettings Is Nothing Then
                Dim settingsDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Atalasoft\Demos"
                If Directory.Exists(settingsDir) = False Then
                    Directory.CreateDirectory(settingsDir)
                End If
                _appSettings = New ApplicationPreferences(settingsDir & "\Preferences.xml", _templates)
            End If

            Me.annotateViewer1.KeyBinder(_appSettings.KeyIncreaseHeight) = New AnnotationKey(AnnotationKeyAction.IncreaseHeight)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyDecreaseHeight) = New AnnotationKey(AnnotationKeyAction.DecreaseHeight)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyIncreaseWidth) = New AnnotationKey(AnnotationKeyAction.IncreaseWidth)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyDecreaseWidth) = New AnnotationKey(AnnotationKeyAction.DecreaseWidth)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyMoveUp) = New AnnotationKey(AnnotationKeyAction.MoveUp)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyMoveLeft) = New AnnotationKey(AnnotationKeyAction.MoveLeft)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyMoveRight) = New AnnotationKey(AnnotationKeyAction.MoveRight)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyMoveDown) = New AnnotationKey(AnnotationKeyAction.MoveDown)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyRotateCounterclockwise) = New AnnotationKey(AnnotationKeyAction.RotateCounterclockwise)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyRotateClockwise) = New AnnotationKey(AnnotationKeyAction.RotateClockwise)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectAbove) = New AnnotationKey(AnnotationKeyAction.SelectAbove)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectLeft) = New AnnotationKey(AnnotationKeyAction.SelectLeft)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectRight) = New AnnotationKey(AnnotationKeyAction.SelectRight)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectBelow) = New AnnotationKey(AnnotationKeyAction.SelectBelow)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectPrevious) = New AnnotationKey(AnnotationKeyAction.SelectPrevious)
            Me.annotateViewer1.KeyBinder(_appSettings.KeySelectNext) = New AnnotationKey(AnnotationKeyAction.SelectNext)
            Me.annotateViewer1.KeyBinder(_appSettings.KeyClearSelection) = New AnnotationKey(AnnotationKeyAction.ClearSelection)

            Me.annotateViewer1.AnnotationConfinement = _appSettings.Confinement
            Me.annotateViewer1.SmoothingMode = _appSettings.Smoothing
            Me.annotateViewer1.MultipageAnnotateMode = _appSettings.MultipageSupport
            Me.annotateViewer1.MultiSelectKey = _appSettings.MultiSelectKey
            Me.annotateViewer1.Units = _appSettings.Units
            Me.annotateViewer1.RotationSnapInterval = _appSettings.RotationSnapInterval
            Me.annotateViewer1.RotationSnapThreshold = _appSettings.RotationSnapThreshold

            UpdateMenu()
            Me.statusResolution.Text = Me.annotateViewer1.Resolution.ToString() & " / " & Me.annotateViewer1.Units.ToString()
        End Sub

        Private Sub MoveAnnotationObject(ByVal annotation As AnnotationUI, ByVal method As String)
            Select Case method
                Case "Move To Back"
                    Me.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveToBack)
                Case "Move Back"
                    Me.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveBack)
                Case "Move Up"
                    Me.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveUp)
                Case "Move To Front"
                    Me.annotateViewer1.Annotations.ChangeAnnotationPosition(annotation, ChangePositionMethod.MoveToFront)
            End Select

            UpdateMenu()
        End Sub

        Private Sub UpdateMenu()
            Dim fileLoaded As Boolean = (Not Me.annotateViewer1.Image Is Nothing)
            Dim count As Integer
            If fileLoaded Then
                count = (Me.annotateViewer1.Images.Count)
            Else
                count = (0)
            End If
            Me.menuFileSave.Enabled = fileLoaded
            Me.menuFileNextPage.Enabled = (fileLoaded AndAlso Me.annotateViewer1.Images.IndexOf(Me.annotateViewer1.Image) < count - 1)
            Me.menuFilePreviousPage.Enabled = (fileLoaded AndAlso Me.annotateViewer1.Images.IndexOf(Me.annotateViewer1.Image) > 0)
            Me.menuFilePrint.Enabled = fileLoaded
            Me.menuZoom.Enabled = fileLoaded
            Me.menuFileRotate.Enabled = fileLoaded

            Dim totalAnnotationCount As Integer = Me.annotateViewer1.Annotations.CountAnnotations()
            Me.statusAnnCount.Text = "Annotations: " & totalAnnotationCount.ToString()
            Me.menuFileBurn.Enabled = (fileLoaded AndAlso totalAnnotationCount > 0)
            Dim selCount As Integer = Me.annotateViewer1.Annotations.SelectedAnnotations.Length
            Me.menuAnnotationsSave.Enabled = (totalAnnotationCount > 0)

            Dim active As AnnotationUI = Me.annotateViewer1.Annotations.ActiveAnnotation
            Dim activeItem As Boolean = (Not active Is Nothing)
            Me.menuAnnotationsRemove.Enabled = activeItem
            Me.menuAnnotationsFlip.Enabled = activeItem

            Me.menuEditUndo.Enabled = (Me.annotateViewer1.Annotations.UndoManager.UndoCount > 0)
            Me.menuEditRedo.Enabled = (Me.annotateViewer1.Annotations.UndoManager.RedoCount > 0)
            Me.menuEditCopy.Enabled = activeItem
            Me.menuEditCut.Enabled = activeItem
            Me.menuEditPaste.Enabled = Me.annotateViewer1.Annotations.CanPaste()
            Me.menuEditSelectAll.Enabled = (totalAnnotationCount > 0 AndAlso selCount < totalAnnotationCount)

            Dim layer As LayerAnnotation = CType(IIf(TypeOf active Is LayerAnnotation, active, Nothing), LayerAnnotation)
            Me.menuAnnGroup.Enabled = selCount > 1
            Me.menuAnnUngroup.Enabled = (selCount = 1 AndAlso Not layer Is Nothing AndAlso layer.GroupAnnotation)

            If activeItem AndAlso Not active.ParentLayer Is Nothing Then
                Dim activeIndex As Integer = active.ParentLayer.Items.IndexOf(active)
                Dim alCount As Integer = active.ParentLayer.Items.Count
                Me.menuAnnotationsMoveToBack.Enabled = (activeIndex > 0)
                Me.menuAnnotationsMoveToFront.Enabled = (activeIndex < alCount - 1)
                Me.menuAnnotationsMoveBack.Enabled = Me.menuAnnotationsMoveToBack.Enabled
                Me.menuAnnotationsMoveUp.Enabled = Me.menuAnnotationsMoveToFront.Enabled
            Else
                Me.menuAnnotationsMoveBack.Enabled = False
                Me.menuAnnotationsMoveToBack.Enabled = False
                Me.menuAnnotationsMoveToFront.Enabled = False
                Me.menuAnnotationsMoveUp.Enabled = False
            End If

            If Me.annotateViewer1.MultipageAnnotateMode AndAlso (Me.annotateViewer1.Annotations.CurrentLayer Is Nothing OrElse Me.annotateViewer1.Annotations.CurrentLayer.ParentLayer Is Nothing) Then
                Me.menuLayersAdd.Enabled = False
                Me.menuLayersClear.Enabled = False
                Me.menuLayersClearAll.Enabled = False
                Me.menuLayersMoveBack.Enabled = False
                Me.menuLayersMoveToBack.Enabled = False
                Me.menuLayersMoveToFront.Enabled = False
                Me.menuLayersMoveUp.Enabled = False
                Me.menuLayersRemove.Enabled = False
            Else
                Dim layerCount As Integer = Me.annotateViewer1.Annotations.Layers.Count
                Dim currentLayer As LayerAnnotation = Me.annotateViewer1.Annotations.CurrentLayer
                Dim childLayer As Boolean = (Not currentLayer Is Nothing AndAlso Not currentLayer.ParentLayer Is Nothing)
                Me.menuLayersAdd.Enabled = True
                Me.menuLayersClear.Enabled = (layerCount > 0)
                Me.menuLayersClearAll.Enabled = (layerCount > 0)
                If Me.annotateViewer1.MultipageAnnotateMode Then
                    Me.menuLayersRemove.Enabled = childLayer
                Else
                    Me.menuLayersRemove.Enabled = (Not currentLayer Is Nothing)
                End If
                If layerCount < 2 OrElse currentLayer Is Nothing Then
                    Me.menuLayersMoveBack.Enabled = False
                    Me.menuLayersMoveToBack.Enabled = False
                    Me.menuLayersMoveUp.Enabled = False
                    Me.menuLayersMoveToFront.Enabled = False
                ElseIf Not currentLayer Is Nothing Then
                    Dim layerIndex As Integer = Me.annotateViewer1.Annotations.Layers.IndexOf(currentLayer)
                    Me.menuLayersMoveToFront.Enabled = (layerIndex < layerCount - 1)
                    Me.menuLayersMoveToBack.Enabled = (layerIndex > 0)
                    Me.menuLayersMoveBack.Enabled = Me.menuLayersMoveToBack.Enabled
                    Me.menuLayersMoveUp.Enabled = Me.menuLayersMoveToFront.Enabled
                End If
            End If
        End Sub

        Private Sub UpdateLayerItemMenu()
            ' Add/Remove items in the Layers menu.
            If Not _layerMenus Is Nothing Then
                For Each mi As MenuItem In _layerMenus
                    Me.menuLayers.MenuItems.Remove(mi)
                    mi.Dispose()
                Next mi

                _layerMenus = Nothing
            End If

            Dim layerCount As Integer = Me.annotateViewer1.Annotations.Layers.Count
            If layerCount > 0 Then
                _layerMenus = New MenuItem(layerCount - 1) {}
                Dim i As Integer = 0
                'ORIGINAL LINE: for (int i = 0; i < layerCount; i += 1)
                'INSTANT VB NOTE: This 'for' loop was translated to a VB 'Do While' loop:
                Do While i < layerCount
                    Dim layer As LayerAnnotation = Me.annotateViewer1.Annotations.Layers(i)
                    Dim item As MenuItem
                    If layer.Data.Name Is Nothing Then
                        item = New MenuItem(i.ToString() & (""), New EventHandler(AddressOf OnLayerMenuItemClick))
                    Else
                        item = New MenuItem(i.ToString() & (layer.Data.Name), New EventHandler(AddressOf OnLayerMenuItemClick))
                    End If
                    item.RadioCheck = True
                    If i = 0 Then
                        item.Checked = True
                    End If
                    _layerMenus(i) = item
                    i += 1
                Loop

                Me.menuLayers.MenuItems.AddRange(_layerMenus)
            End If
        End Sub

        Private Sub UpdateLayerMenuItemIndex(ByVal index As Integer)
            If index < 0 OrElse _layerMenus Is Nothing OrElse index > _layerMenus.Length - 1 Then
                Return
            End If

            For Each mi As MenuItem In _layerMenus
                mi.Checked = False
            Next mi

            _layerMenus(index).Checked = True
        End Sub

        Private Sub UpdateNextPreviousMenus(ByVal index As Integer)
            Me.menuFileNextPage.Enabled = index < Me.annotateViewer1.Images.Count - 1
            Me.menuFilePreviousPage.Enabled = index > 0
        End Sub

#End Region

        Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            If Not _appSettings Is Nothing Then
                _appSettings.Save()
            End If
        End Sub

        Private Sub propGridAnnotation_PropertyValueChanged(ByVal s As Object, ByVal e As PropertyValueChangedEventArgs)
            UpdateMenu()
        End Sub

        Private Sub toolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles toolBar1.ButtonClick
            Select Case e.Button.ToolTipText
                Case "Callout"
                    AddNewAnnotation(New CalloutAnnotation)
                Case "Ellipse"
                    AddNewAnnotation(New EllipseAnnotation)
                Case "Freehand"
                    AddNewAnnotation(New FreehandAnnotation)
                Case "Freehand Highlighter"
                    Dim fa As FreehandAnnotation = New FreehandAnnotation(New AnnotationPen(Color.Yellow, 10))
                    fa.Translucent = True
                    Me.annotateViewer1.Annotations.CreateAnnotation(fa)
                Case "Line"
                    AddNewAnnotation(New LineAnnotation)
                Case "Lines"
                    AddNewAnnotation(New LinesAnnotation)
                Case "Polygon"
                    AddNewAnnotation(New PolygonAnnotation)
                Case "Rectangle"
                    AddNewAnnotation(New RectangleAnnotation)
                Case "Rectangle Highlighter"
                    Dim ra As RectangleAnnotation = New RectangleAnnotation(New AnnotationBrush(Color.Yellow), Nothing)
                    ra.Translucent = True
                    Me.annotateViewer1.Annotations.CreateAnnotation(ra)
                Case "Redaction"
                    Dim red As RectangleAnnotation = New RectangleAnnotation(New AnnotationBrush(Color.Black), Nothing)
                    Me.annotateViewer1.Annotations.CreateAnnotation(red)
                Case "Rubber Stamp"
                    Dim rub As RubberStampAnnotation = New RubberStampAnnotation("DRAFT")
                    rub.Size = New SizeF(300, 100)
                    rub.Data.Rotation = 326
                    Me.annotateViewer1.Annotations.CreateAnnotation(rub, CreateAnnotationMode.SingleClickCenter)
                Case "Sticky Note"
                    Dim ta As TextAnnotation = New TextAnnotation("Sticky Note: ", Me._templates.Font, New AnnotationBrush(Color.Black), New AnnotationBrush(Color.Yellow), New AnnotationPen(Color.Black), New AnnotationBrush(Color.FromArgb(128, Color.Silver)), New PointF(8, 8), ShadowMode.Annotation)
                    ta.Size = New SizeF(200, 140)
                    Me.annotateViewer1.Annotations.CreateAnnotation(ta, CreateAnnotationMode.SingleClickCenter)
                Case "Text"
                    AddNewAnnotation(New TextAnnotation)
                Case "Rectangle Hotspot"
                    Dim hs As HotSpotAnnotation = New HotSpotAnnotation(RectangleF.Empty, New AnnotationBrush(Color.DarkRed))
                    Me.annotateViewer1.Annotations.CreateAnnotation(hs)
                Case "Freehand Hotspot"
                    Dim fhs As HotSpotFreehandAnnotation = New HotSpotFreehandAnnotation(New AnnotationBrush(Color.DarkRed))
                    Me.annotateViewer1.Annotations.CreateAnnotation(fhs)
                Case "Embedded Image", "Referenced Image"
                    Dim file As String = GetImageFileName()
                    If file Is Nothing Then
                        Return
                    End If

                    Try
                        If e.Button.ToolTipText = "Embedded Image" Then
                            AddNewAnnotation(New EmbeddedImageAnnotation(New AnnotationImage(file), True))
                        Else
                            AddNewAnnotation(New ReferencedImageAnnotation(file, False))
                        End If
                    Catch ex As Exception
                        MessageBox.Show(Me, "Exception creating a ReferencedImageAnnotation" & Constants.vbCrLf & Constants.vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try

                Case "PDF Markup"
                    ' Use the last PDF annotation created, or underline.
                    If _lastPdfAnnotation Is Nothing Then
                        AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Underline)
                    ElseIf _lastPdfAnnotation.MarkupType = Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight Then
                        Me.annotateViewer1.Annotations.CreateAnnotation(_lastPdfAnnotation.Clone(), CreateAnnotationMode.Default)
                    Else
                        AddNewAnnotation(_lastPdfAnnotation.Clone())
                    End If
                Case "PDF Line"
                    AddNewAnnotation(New Atalasoft.Annotate.Pdf.PdfLineAnnotation)
                Case "Triangle"
                    AddNewAnnotation(New TriangleAnnotation)
                Case "Triangle Point"
                    AddNewAnnotation(New TrianglePointAnnotation)
                Case "Arc"
                    AddNewAnnotation(New ArcAnnotation)
            End Select
        End Sub

#Region "PDF Annotations"

        Private Sub AddPdfMarkupAnnotation(ByVal markup As Atalasoft.Annotate.Pdf.PdfMarkupType)
            Select Case markup
                Case Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight
                    _lastPdfAnnotation = New Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(Nothing, Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight)
                    _lastPdfAnnotation.Fill = New AnnotationBrush(Color.Yellow)
                    Me.annotateViewer1.Annotations.CreateAnnotation(_lastPdfAnnotation.Clone(), CreateAnnotationMode.Default)
                    Return
                Case Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly
                    _lastPdfAnnotation = New Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(Nothing, Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly)
                    If Me.annotateViewer1.Units <> AnnotationUnit.Pixel Then
                        _lastPdfAnnotation.SquigglyHeight = 4 * (1.0F / Me.annotateViewer1.Resolution.X)
                    End If
                Case Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut
                    _lastPdfAnnotation = New Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(Nothing, Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut)
                Case Atalasoft.Annotate.Pdf.PdfMarkupType.Underline
                    _lastPdfAnnotation = New Atalasoft.Annotate.Pdf.PdfMarkupAnnotation(Nothing, Atalasoft.Annotate.Pdf.PdfMarkupType.Underline)
            End Select

            AddNewAnnotation(_lastPdfAnnotation.Clone())
        End Sub

        Private Sub menuAddPdfLine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPdfLine.Click
            AddNewAnnotation(New Atalasoft.Annotate.Pdf.PdfLineAnnotation)
        End Sub

        Private Sub menuAddPdfHighlighter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPdfHighlighter.Click, menuPdfHighlight.Click
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Highlight)
        End Sub

        Private Sub menuAddPdfSquiggly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPdfSquiggly.Click, menuPdfSquiggly.Click
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Squiggly)
        End Sub

        Private Sub menuAddPdfStrikeout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPdfStrikeout.Click, menuPdfStrikeOut.Click
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.StrikeOut)
        End Sub

        Private Sub menuAddPdfUnderline_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddPdfUnderline.Click, menuPdfUnderline.Click
            AddPdfMarkupAnnotation(Atalasoft.Annotate.Pdf.PdfMarkupType.Underline)
        End Sub

#End Region

    End Class
End Namespace
