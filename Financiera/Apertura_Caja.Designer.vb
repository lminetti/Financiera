<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Apertura_Caja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Apertura_Caja))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DATABASEDataSet = New Financiera.DATABASEDataSet()
        Me.CONTABLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CONTABLETableAdapter = New Financiera.DATABASEDataSetTableAdapters.CONTABLETableAdapter()
        Me.TableAdapterManager = New Financiera.DATABASEDataSetTableAdapters.TableAdapterManager()
        Me.CONTABLEDataGridView = New System.Windows.Forms.DataGridView()
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
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.AJUSTESDataSet = New Financiera.AJUSTESDataSet()
        Me.OPERADORESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OPERADORESTableAdapter = New Financiera.AJUSTESDataSetTableAdapters.OPERADORESTableAdapter()
        Me.TableAdapterManager1 = New Financiera.AJUSTESDataSetTableAdapters.TableAdapterManager()
        Me.OPERADORESDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DATABASEDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONTABLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONTABLEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AJUSTESDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPERADORESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPERADORESDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Apertura..."
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(141, 107)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'DATABASEDataSet
        '
        Me.DATABASEDataSet.DataSetName = "DATABASEDataSet"
        Me.DATABASEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CONTABLEBindingSource
        '
        Me.CONTABLEBindingSource.DataMember = "CONTABLE"
        Me.CONTABLEBindingSource.DataSource = Me.DATABASEDataSet
        '
        'CONTABLETableAdapter
        '
        Me.CONTABLETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.ASIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CAJASTableAdapter = Nothing
        Me.TableAdapterManager.COEFICIENTESTableAdapter = Nothing
        Me.TableAdapterManager.CONTABLETableAdapter = Me.CONTABLETableAdapter
        Me.TableAdapterManager.DIARIO_CREDITOSTableAdapter = Nothing
        Me.TableAdapterManager.DIARIO_CUOTASTableAdapter = Nothing
        Me.TableAdapterManager.INTERESESTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Financiera.DATABASEDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CONTABLEDataGridView
        '
        Me.CONTABLEDataGridView.AllowUserToAddRows = False
        Me.CONTABLEDataGridView.AllowUserToDeleteRows = False
        Me.CONTABLEDataGridView.AutoGenerateColumns = False
        Me.CONTABLEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CONTABLEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.CONTABLEDataGridView.DataSource = Me.CONTABLEBindingSource
        Me.CONTABLEDataGridView.Location = New System.Drawing.Point(35, 38)
        Me.CONTABLEDataGridView.Name = "CONTABLEDataGridView"
        Me.CONTABLEDataGridView.ReadOnly = True
        Me.CONTABLEDataGridView.RowHeadersVisible = False
        Me.CONTABLEDataGridView.Size = New System.Drawing.Size(73, 51)
        Me.CONTABLEDataGridView.TabIndex = 6
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CODIGO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CODIGO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CAJA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CAJA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ASIENTO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ASIENTO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DEBE"
        Me.DataGridViewTextBoxColumn5.HeaderText = "DEBE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "HABER"
        Me.DataGridViewTextBoxColumn6.HeaderText = "HABER"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "SALDO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "SALDO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "OPERADOR"
        Me.DataGridViewTextBoxColumn8.HeaderText = "OPERADOR"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "FECHA"
        Me.DataGridViewTextBoxColumn9.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CUOTA"
        Me.DataGridViewTextBoxColumn10.HeaderText = "CUOTA"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "OPERACION"
        Me.DataGridViewTextBoxColumn11.HeaderText = "OPERACION"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'PrintDocument1
        '
        '
        'AJUSTESDataSet
        '
        Me.AJUSTESDataSet.DataSetName = "AJUSTESDataSet"
        Me.AJUSTESDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OPERADORESBindingSource
        '
        Me.OPERADORESBindingSource.DataMember = "OPERADORES"
        Me.OPERADORESBindingSource.DataSource = Me.AJUSTESDataSet
        '
        'OPERADORESTableAdapter
        '
        Me.OPERADORESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.AJUSTESTableAdapter = Nothing
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.OPERADORESTableAdapter = Me.OPERADORESTableAdapter
        Me.TableAdapterManager1.UpdateOrder = Financiera.AJUSTESDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OPERADORESDataGridView
        '
        Me.OPERADORESDataGridView.AllowUserToAddRows = False
        Me.OPERADORESDataGridView.AllowUserToDeleteRows = False
        Me.OPERADORESDataGridView.AutoGenerateColumns = False
        Me.OPERADORESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OPERADORESDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17})
        Me.OPERADORESDataGridView.DataSource = Me.OPERADORESBindingSource
        Me.OPERADORESDataGridView.Location = New System.Drawing.Point(94, 20)
        Me.OPERADORESDataGridView.Name = "OPERADORESDataGridView"
        Me.OPERADORESDataGridView.ReadOnly = True
        Me.OPERADORESDataGridView.RowHeadersVisible = False
        Me.OPERADORESDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.OPERADORESDataGridView.Size = New System.Drawing.Size(39, 33)
        Me.OPERADORESDataGridView.TabIndex = 6
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "CUENTA"
        Me.DataGridViewTextBoxColumn13.HeaderText = "CUENTA"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "NOMBRE"
        Me.DataGridViewTextBoxColumn14.HeaderText = "NOMBRE"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "CLAVE"
        Me.DataGridViewTextBoxColumn15.HeaderText = "CLAVE"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "NIVEL"
        Me.DataGridViewTextBoxColumn16.HeaderText = "NIVEL"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CAJA"
        Me.DataGridViewTextBoxColumn17.HeaderText = "CAJA"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'Apertura_Caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(165, 131)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CONTABLEDataGridView)
        Me.Controls.Add(Me.OPERADORESDataGridView)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Apertura_Caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apertura de caja"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DATABASEDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONTABLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONTABLEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AJUSTESDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPERADORESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPERADORESDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DATABASEDataSet As DATABASEDataSet
    Friend WithEvents CONTABLEBindingSource As BindingSource
    Friend WithEvents CONTABLETableAdapter As DATABASEDataSetTableAdapters.CONTABLETableAdapter
    Friend WithEvents TableAdapterManager As DATABASEDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CONTABLEDataGridView As DataGridView
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
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents AJUSTESDataSet As AJUSTESDataSet
    Friend WithEvents OPERADORESBindingSource As BindingSource
    Friend WithEvents OPERADORESTableAdapter As AJUSTESDataSetTableAdapters.OPERADORESTableAdapter
    Friend WithEvents TableAdapterManager1 As AJUSTESDataSetTableAdapters.TableAdapterManager
    Friend WithEvents OPERADORESDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
End Class
