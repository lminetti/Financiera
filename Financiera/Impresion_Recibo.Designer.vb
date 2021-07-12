<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Impresion_Recibo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Impresion_Recibo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.AJUSTESDataSet = New Financiera.AJUSTESDataSet()
        Me.AJUSTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AJUSTESTableAdapter = New Financiera.AJUSTESDataSetTableAdapters.AJUSTESTableAdapter()
        Me.TableAdapterManager = New Financiera.AJUSTESDataSetTableAdapters.TableAdapterManager()
        Me.AJUSTESDataGridView = New System.Windows.Forms.DataGridView()
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
        Me.NUMERO_OPERACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMERO_COMPTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AJUSTESDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AJUSTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AJUSTESDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Imprimiendo..."
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
        'PrintDocument1
        '
        '
        'AJUSTESDataSet
        '
        Me.AJUSTESDataSet.DataSetName = "AJUSTESDataSet"
        Me.AJUSTESDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AJUSTESBindingSource
        '
        Me.AJUSTESBindingSource.DataMember = "AJUSTES"
        Me.AJUSTESBindingSource.DataSource = Me.AJUSTESDataSet
        '
        'AJUSTESTableAdapter
        '
        Me.AJUSTESTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AJUSTESTableAdapter = Me.AJUSTESTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OPERADORESTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Financiera.AJUSTESDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AJUSTESDataGridView
        '
        Me.AJUSTESDataGridView.AllowUserToAddRows = False
        Me.AJUSTESDataGridView.AllowUserToDeleteRows = False
        Me.AJUSTESDataGridView.AutoGenerateColumns = False
        Me.AJUSTESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AJUSTESDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.NUMERO_OPERACION, Me.NUMERO_COMPTE})
        Me.AJUSTESDataGridView.DataSource = Me.AJUSTESBindingSource
        Me.AJUSTESDataGridView.Location = New System.Drawing.Point(65, 45)
        Me.AJUSTESDataGridView.Name = "AJUSTESDataGridView"
        Me.AJUSTESDataGridView.ReadOnly = True
        Me.AJUSTESDataGridView.RowHeadersVisible = False
        Me.AJUSTESDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AJUSTESDataGridView.Size = New System.Drawing.Size(45, 40)
        Me.AJUSTESDataGridView.TabIndex = 7
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
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RAZON_SOCIAL"
        Me.DataGridViewTextBoxColumn2.HeaderText = "RAZON_SOCIAL"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE_FANTASIA"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NOMBRE_FANTASIA"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DOMICILIO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DOMICILIO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CONDICION_IVA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CONDICION_IVA"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CUIT"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CUIT"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "IIBB"
        Me.DataGridViewTextBoxColumn7.HeaderText = "IIBB"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "INICIO_ACTIVIDADES"
        Me.DataGridViewTextBoxColumn8.HeaderText = "INICIO_ACTIVIDADES"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PDV"
        Me.DataGridViewTextBoxColumn9.HeaderText = "PDV"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CIUDAD"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CIUDAD"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'NUMERO_OPERACION
        '
        Me.NUMERO_OPERACION.DataPropertyName = "NUMERO_OPERACION"
        Me.NUMERO_OPERACION.HeaderText = "NUMERO_OPERACION"
        Me.NUMERO_OPERACION.Name = "NUMERO_OPERACION"
        Me.NUMERO_OPERACION.ReadOnly = True
        '
        'NUMERO_COMPTE
        '
        Me.NUMERO_COMPTE.DataPropertyName = "NUMERO_COMPTE"
        Me.NUMERO_COMPTE.HeaderText = "NUMERO_COMPTE"
        Me.NUMERO_COMPTE.Name = "NUMERO_COMPTE"
        Me.NUMERO_COMPTE.ReadOnly = True
        '
        'Impresion_Recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(165, 131)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.AJUSTESDataGridView)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Impresion_Recibo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de recibo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AJUSTESDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AJUSTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AJUSTESDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents AJUSTESDataSet As AJUSTESDataSet
    Friend WithEvents AJUSTESBindingSource As BindingSource
    Friend WithEvents AJUSTESTableAdapter As AJUSTESDataSetTableAdapters.AJUSTESTableAdapter
    Friend WithEvents TableAdapterManager As AJUSTESDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AJUSTESDataGridView As DataGridView
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
    Friend WithEvents NUMERO_OPERACION As DataGridViewTextBoxColumn
    Friend WithEvents NUMERO_COMPTE As DataGridViewTextBoxColumn
End Class
