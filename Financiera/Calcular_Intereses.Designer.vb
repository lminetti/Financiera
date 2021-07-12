<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calcular_Intereses
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calcular_Intereses))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DIARIO_CUOTASDataGridView = New System.Windows.Forms.DataGridView()
        Me.INTERESESDataGridView = New System.Windows.Forms.DataGridView()
        Me.DIARIO_CREDITOSDataGridView = New System.Windows.Forms.DataGridView()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS_MORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ABM_PERSONALDataGridView = New System.Windows.Forms.DataGridView()
        Me.APELLIDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIARIO_CUOTASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DATABASEDataSet = New Financiera.DATABASEDataSet()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INTERESESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIARIO_CREDITOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ABM_PERSONALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ABMDataSet = New Financiera.ABMDataSet()
        Me.DIARIO_CUOTASTableAdapter = New Financiera.DATABASEDataSetTableAdapters.DIARIO_CUOTASTableAdapter()
        Me.TableAdapterManager = New Financiera.DATABASEDataSetTableAdapters.TableAdapterManager()
        Me.INTERESESTableAdapter = New Financiera.DATABASEDataSetTableAdapters.INTERESESTableAdapter()
        Me.DIARIO_CREDITOSTableAdapter = New Financiera.DATABASEDataSetTableAdapters.DIARIO_CREDITOSTableAdapter()
        Me.ABM_PERSONALTableAdapter = New Financiera.ABMDataSetTableAdapters.ABM_PERSONALTableAdapter()
        Me.TableAdapterManager1 = New Financiera.ABMDataSetTableAdapters.TableAdapterManager()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIARIO_CUOTASDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.INTERESESDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIARIO_CREDITOSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ABM_PERSONALDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIARIO_CUOTASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DATABASEDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.INTERESESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DIARIO_CREDITOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ABM_PERSONALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ABMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Calculando..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(141, 105)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'DIARIO_CUOTASDataGridView
        '
        Me.DIARIO_CUOTASDataGridView.AllowUserToAddRows = False
        Me.DIARIO_CUOTASDataGridView.AllowUserToDeleteRows = False
        Me.DIARIO_CUOTASDataGridView.AutoGenerateColumns = False
        Me.DIARIO_CUOTASDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DIARIO_CUOTASDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.APELLIDO})
        Me.DIARIO_CUOTASDataGridView.DataSource = Me.DIARIO_CUOTASBindingSource
        Me.DIARIO_CUOTASDataGridView.Location = New System.Drawing.Point(30, 41)
        Me.DIARIO_CUOTASDataGridView.Name = "DIARIO_CUOTASDataGridView"
        Me.DIARIO_CUOTASDataGridView.ReadOnly = True
        Me.DIARIO_CUOTASDataGridView.RowHeadersVisible = False
        Me.DIARIO_CUOTASDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DIARIO_CUOTASDataGridView.Size = New System.Drawing.Size(13, 12)
        Me.DIARIO_CUOTASDataGridView.TabIndex = 8
        '
        'INTERESESDataGridView
        '
        Me.INTERESESDataGridView.AllowUserToAddRows = False
        Me.INTERESESDataGridView.AllowUserToDeleteRows = False
        Me.INTERESESDataGridView.AutoGenerateColumns = False
        Me.INTERESESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.INTERESESDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15})
        Me.INTERESESDataGridView.DataSource = Me.INTERESESBindingSource
        Me.INTERESESDataGridView.Location = New System.Drawing.Point(67, 76)
        Me.INTERESESDataGridView.Name = "INTERESESDataGridView"
        Me.INTERESESDataGridView.ReadOnly = True
        Me.INTERESESDataGridView.RowHeadersVisible = False
        Me.INTERESESDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.INTERESESDataGridView.Size = New System.Drawing.Size(26, 21)
        Me.INTERESESDataGridView.TabIndex = 8
        '
        'DIARIO_CREDITOSDataGridView
        '
        Me.DIARIO_CREDITOSDataGridView.AllowUserToAddRows = False
        Me.DIARIO_CREDITOSDataGridView.AllowUserToDeleteRows = False
        Me.DIARIO_CREDITOSDataGridView.AutoGenerateColumns = False
        Me.DIARIO_CREDITOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DIARIO_CREDITOSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.IVA, Me.DIAS_MORA})
        Me.DIARIO_CREDITOSDataGridView.DataSource = Me.DIARIO_CREDITOSBindingSource
        Me.DIARIO_CREDITOSDataGridView.Location = New System.Drawing.Point(65, 85)
        Me.DIARIO_CREDITOSDataGridView.Name = "DIARIO_CREDITOSDataGridView"
        Me.DIARIO_CREDITOSDataGridView.ReadOnly = True
        Me.DIARIO_CREDITOSDataGridView.RowHeadersVisible = False
        Me.DIARIO_CREDITOSDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DIARIO_CREDITOSDataGridView.Size = New System.Drawing.Size(33, 29)
        Me.DIARIO_CREDITOSDataGridView.TabIndex = 8
        '
        'IVA
        '
        Me.IVA.DataPropertyName = "IVA"
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        '
        'DIAS_MORA
        '
        Me.DIAS_MORA.DataPropertyName = "DIAS_MORA"
        Me.DIAS_MORA.HeaderText = "DIAS_MORA"
        Me.DIAS_MORA.Name = "DIAS_MORA"
        Me.DIAS_MORA.ReadOnly = True
        '
        'ABM_PERSONALDataGridView
        '
        Me.ABM_PERSONALDataGridView.AllowUserToAddRows = False
        Me.ABM_PERSONALDataGridView.AllowUserToDeleteRows = False
        Me.ABM_PERSONALDataGridView.AutoGenerateColumns = False
        Me.ABM_PERSONALDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ABM_PERSONALDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn42, Me.DataGridViewTextBoxColumn43, Me.DataGridViewTextBoxColumn44})
        Me.ABM_PERSONALDataGridView.DataSource = Me.ABM_PERSONALBindingSource
        Me.ABM_PERSONALDataGridView.Location = New System.Drawing.Point(30, 90)
        Me.ABM_PERSONALDataGridView.Name = "ABM_PERSONALDataGridView"
        Me.ABM_PERSONALDataGridView.ReadOnly = True
        Me.ABM_PERSONALDataGridView.RowHeadersVisible = False
        Me.ABM_PERSONALDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ABM_PERSONALDataGridView.Size = New System.Drawing.Size(29, 24)
        Me.ABM_PERSONALDataGridView.TabIndex = 8
        '
        'APELLIDO
        '
        Me.APELLIDO.DataPropertyName = "APELLIDO"
        Me.APELLIDO.HeaderText = "APELLIDO"
        Me.APELLIDO.Name = "APELLIDO"
        Me.APELLIDO.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "OPERACION"
        Me.DataGridViewTextBoxColumn2.HeaderText = "OPERACION"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 10
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CUENTA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CUENTA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 10
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CUOTA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CUOTA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 10
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PAGARE"
        Me.DataGridViewTextBoxColumn5.HeaderText = "PAGARE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "FECHA_VENCIMIENTO"
        Me.DataGridViewTextBoxColumn6.HeaderText = "FECHA_VENCIMIENTO"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PAGADO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "PAGADO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FECHA_PAGO"
        Me.DataGridViewTextBoxColumn8.HeaderText = "FECHA_PAGO"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DIAS_MORA"
        Me.DataGridViewTextBoxColumn9.HeaderText = "DIAS_MORA"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "PUNITORIOS"
        Me.DataGridViewTextBoxColumn10.HeaderText = "PUNITORIOS"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CUOTA_INTERES"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CUOTA_INTERES"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "VALOR_CUOTA"
        Me.DataGridViewTextBoxColumn12.HeaderText = "VALOR_CUOTA"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DIARIO_CUOTASBindingSource
        '
        Me.DIARIO_CUOTASBindingSource.DataMember = "DIARIO_CUOTAS"
        Me.DIARIO_CUOTASBindingSource.DataSource = Me.DATABASEDataSet
        '
        'DATABASEDataSet
        '
        Me.DATABASEDataSet.DataSetName = "DATABASEDataSet"
        Me.DATABASEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "DIAS"
        Me.DataGridViewTextBoxColumn14.HeaderText = "DIAS"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "INTERES"
        Me.DataGridViewTextBoxColumn15.HeaderText = "INTERES"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'INTERESESBindingSource
        '
        Me.INTERESESBindingSource.DataMember = "INTERESES"
        Me.INTERESESBindingSource.DataSource = Me.DATABASEDataSet
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "OPERACION"
        Me.DataGridViewTextBoxColumn17.HeaderText = "OPERACION"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "CUENTA"
        Me.DataGridViewTextBoxColumn18.HeaderText = "CUENTA"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "NOMBRE"
        Me.DataGridViewTextBoxColumn19.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "APELLIDO"
        Me.DataGridViewTextBoxColumn20.HeaderText = "APELLIDO"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "DNI"
        Me.DataGridViewTextBoxColumn21.HeaderText = "DNI"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "CUIL"
        Me.DataGridViewTextBoxColumn22.HeaderText = "CUIL"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "CAPITAL"
        Me.DataGridViewTextBoxColumn23.HeaderText = "CAPITAL"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "CUOTA"
        Me.DataGridViewTextBoxColumn24.HeaderText = "CUOTA"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "PAGARE"
        Me.DataGridViewTextBoxColumn25.HeaderText = "PAGARE"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "FECHA"
        Me.DataGridViewTextBoxColumn26.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "DEUDA"
        Me.DataGridViewTextBoxColumn27.HeaderText = "DEUDA"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "OPERADOR"
        Me.DataGridViewTextBoxColumn28.HeaderText = "OPERADOR"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DIARIO_CREDITOSBindingSource
        '
        Me.DIARIO_CREDITOSBindingSource.DataMember = "DIARIO_CREDITOS"
        Me.DIARIO_CREDITOSBindingSource.DataSource = Me.DATABASEDataSet
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn29.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "CUENTA"
        Me.DataGridViewTextBoxColumn30.HeaderText = "CUENTA"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "NOMBRE"
        Me.DataGridViewTextBoxColumn31.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "APELLIDO"
        Me.DataGridViewTextBoxColumn32.HeaderText = "APELLIDO"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "FECHA_NACIMIENTO"
        Me.DataGridViewTextBoxColumn33.HeaderText = "FECHA_NACIMIENTO"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "ESTADO_CIVIL"
        Me.DataGridViewTextBoxColumn34.HeaderText = "ESTADO_CIVIL"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "DNI"
        Me.DataGridViewTextBoxColumn35.HeaderText = "DNI"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "CUIL"
        Me.DataGridViewTextBoxColumn36.HeaderText = "CUIL"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "DIRECCION"
        Me.DataGridViewTextBoxColumn37.HeaderText = "DIRECCION"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "LOCALIDAD"
        Me.DataGridViewTextBoxColumn38.HeaderText = "LOCALIDAD"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "C_POSTAL"
        Me.DataGridViewTextBoxColumn39.HeaderText = "C_POSTAL"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "TELEFONO1"
        Me.DataGridViewTextBoxColumn40.HeaderText = "TELEFONO1"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "TELEFONO2"
        Me.DataGridViewTextBoxColumn41.HeaderText = "TELEFONO2"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.ReadOnly = True
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "FECHA_ALTA"
        Me.DataGridViewTextBoxColumn42.HeaderText = "FECHA_ALTA"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "OPERADOR"
        Me.DataGridViewTextBoxColumn43.HeaderText = "OPERADOR"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "CALIFICACION"
        Me.DataGridViewTextBoxColumn44.HeaderText = "CALIFICACION"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        '
        'ABM_PERSONALBindingSource
        '
        Me.ABM_PERSONALBindingSource.DataMember = "ABM_PERSONAL"
        Me.ABM_PERSONALBindingSource.DataSource = Me.ABMDataSet
        '
        'ABMDataSet
        '
        Me.ABMDataSet.DataSetName = "ABMDataSet"
        Me.ABMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DIARIO_CUOTASTableAdapter
        '
        Me.DIARIO_CUOTASTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ASIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CAJASTableAdapter = Nothing
        Me.TableAdapterManager.COEFICIENTESTableAdapter = Nothing
        Me.TableAdapterManager.CONTABLETableAdapter = Nothing
        Me.TableAdapterManager.DETALLE_RECIBOSTableAdapter = Nothing
        Me.TableAdapterManager.DIARIO_CREDITOSTableAdapter = Nothing
        Me.TableAdapterManager.DIARIO_CUOTASTableAdapter = Me.DIARIO_CUOTASTableAdapter
        Me.TableAdapterManager.DIARIO_RECIBOSTableAdapter = Nothing
        Me.TableAdapterManager.INTERESESTableAdapter = Me.INTERESESTableAdapter
        Me.TableAdapterManager.UpdateOrder = Financiera.DATABASEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'INTERESESTableAdapter
        '
        Me.INTERESESTableAdapter.ClearBeforeFill = True
        '
        'DIARIO_CREDITOSTableAdapter
        '
        Me.DIARIO_CREDITOSTableAdapter.ClearBeforeFill = True
        '
        'ABM_PERSONALTableAdapter
        '
        Me.ABM_PERSONALTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.ABM_EXTRASTableAdapter = Nothing
        Me.TableAdapterManager1.ABM_LABORALTableAdapter = Nothing
        Me.TableAdapterManager1.ABM_OBSTableAdapter = Nothing
        Me.TableAdapterManager1.ABM_PERSONALTableAdapter = Me.ABM_PERSONALTableAdapter
        Me.TableAdapterManager1.ABM_SCANTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.UpdateOrder = Financiera.ABMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Calcular_Intereses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(169, 137)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DIARIO_CUOTASDataGridView)
        Me.Controls.Add(Me.INTERESESDataGridView)
        Me.Controls.Add(Me.DIARIO_CREDITOSDataGridView)
        Me.Controls.Add(Me.ABM_PERSONALDataGridView)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Calcular_Intereses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculando intereses"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIARIO_CUOTASDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.INTERESESDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIARIO_CREDITOSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ABM_PERSONALDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIARIO_CUOTASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DATABASEDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.INTERESESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DIARIO_CREDITOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ABM_PERSONALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ABMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DATABASEDataSet As DATABASEDataSet
    Friend WithEvents DIARIO_CUOTASBindingSource As BindingSource
    Friend WithEvents DIARIO_CUOTASTableAdapter As DATABASEDataSetTableAdapters.DIARIO_CUOTASTableAdapter
    Friend WithEvents TableAdapterManager As DATABASEDataSetTableAdapters.TableAdapterManager
    Friend WithEvents INTERESESTableAdapter As DATABASEDataSetTableAdapters.INTERESESTableAdapter
    Friend WithEvents DIARIO_CUOTASDataGridView As DataGridView
    Friend WithEvents INTERESESBindingSource As BindingSource
    Friend WithEvents INTERESESDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DIARIO_CREDITOSBindingSource As BindingSource
    Friend WithEvents DIARIO_CREDITOSTableAdapter As DATABASEDataSetTableAdapters.DIARIO_CREDITOSTableAdapter
    Friend WithEvents DIARIO_CREDITOSDataGridView As DataGridView
    Friend WithEvents ABMDataSet As ABMDataSet
    Friend WithEvents ABM_PERSONALBindingSource As BindingSource
    Friend WithEvents ABM_PERSONALTableAdapter As ABMDataSetTableAdapters.ABM_PERSONALTableAdapter
    Friend WithEvents TableAdapterManager1 As ABMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ABM_PERSONALDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents IVA As DataGridViewTextBoxColumn
    Friend WithEvents DIAS_MORA As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents APELLIDO As DataGridViewTextBoxColumn
End Class
