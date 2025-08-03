<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BillingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingForm))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.dgvCart = New System.Windows.Forms.DataGridView()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnResetCart = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblInvoiceID = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblCashier = New System.Windows.Forms.Label()
        Me.txtCashier = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.cmbProductList = New System.Windows.Forms.ComboBox()
        Me.lblSelectProduct = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.cmbDiscounts = New System.Windows.Forms.ComboBox()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
        Me.lblServiceCharge = New System.Windows.Forms.Label()
        Me.txtServiceCharge = New System.Windows.Forms.TextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.lblAmountPaid = New System.Windows.Forms.Label()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.btnSaveInvoice = New System.Windows.Forms.Button()
        Me.txtProductDescription = New System.Windows.Forms.TextBox()
        Me.txtProductPrice = New System.Windows.Forms.TextBox()
        Me.btnPrintInvoice = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 485)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Quantity:"
        '
        'nudQuantity
        '
        Me.nudQuantity.Location = New System.Drawing.Point(107, 477)
        Me.nudQuantity.Margin = New System.Windows.Forms.Padding(4)
        Me.nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(140, 25)
        Me.nudQuantity.TabIndex = 5
        Me.nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnAddToCart
        '
        Me.btnAddToCart.BackColor = System.Drawing.Color.Peru
        Me.btnAddToCart.Location = New System.Drawing.Point(119, 529)
        Me.btnAddToCart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(88, 32)
        Me.btnAddToCart.TabIndex = 6
        Me.btnAddToCart.Text = "Add to Cart"
        Me.btnAddToCart.UseVisualStyleBackColor = False
        '
        'dgvCart
        '
        Me.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCart.Location = New System.Drawing.Point(484, 128)
        Me.dgvCart.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvCart.Name = "dgvCart"
        Me.dgvCart.Size = New System.Drawing.Size(444, 156)
        Me.dgvCart.TabIndex = 7
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Peru
        Me.btnBack.Location = New System.Drawing.Point(773, 618)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(102, 30)
        Me.btnBack.TabIndex = 11
        Me.btnBack.Text = "Back "
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnResetCart
        '
        Me.btnResetCart.BackColor = System.Drawing.Color.Peru
        Me.btnResetCart.Location = New System.Drawing.Point(330, 618)
        Me.btnResetCart.Name = "btnResetCart"
        Me.btnResetCart.Size = New System.Drawing.Size(98, 30)
        Me.btnResetCart.TabIndex = 17
        Me.btnResetCart.Text = "Reset"
        Me.btnResetCart.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.SandyBrown
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitle.Location = New System.Drawing.Point(1, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(985, 55)
        Me.lblTitle.TabIndex = 18
        Me.lblTitle.Text = "Billing and Invoicing"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInvoiceID
        '
        Me.lblInvoiceID.AutoSize = True
        Me.lblInvoiceID.Location = New System.Drawing.Point(79, 82)
        Me.lblInvoiceID.Name = "lblInvoiceID"
        Me.lblInvoiceID.Size = New System.Drawing.Size(67, 17)
        Me.lblInvoiceID.TabIndex = 19
        Me.lblInvoiceID.Text = "Invoice ID:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(879, 82)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(38, 17)
        Me.lblDate.TabIndex = 20
        Me.lblDate.Text = "Date:"
        '
        'lblCashier
        '
        Me.lblCashier.AutoSize = True
        Me.lblCashier.Location = New System.Drawing.Point(37, 122)
        Me.lblCashier.Name = "lblCashier"
        Me.lblCashier.Size = New System.Drawing.Size(54, 17)
        Me.lblCashier.TabIndex = 21
        Me.lblCashier.Text = "Cashier:"
        '
        'txtCashier
        '
        Me.txtCashier.Location = New System.Drawing.Point(107, 122)
        Me.txtCashier.Name = "txtCashier"
        Me.txtCashier.Size = New System.Drawing.Size(100, 25)
        Me.txtCashier.TabIndex = 24
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(45, 187)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(46, 17)
        Me.lblName.TabIndex = 25
        Me.lblName.Text = "Name:"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(37, 227)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(59, 17)
        Me.lblAddress.TabIndex = 26
        Me.lblAddress.Text = "Address:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(42, 267)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 17)
        Me.lblEmail.TabIndex = 27
        Me.lblEmail.Text = "Email:"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(42, 302)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(47, 17)
        Me.lblPhone.TabIndex = 28
        Me.lblPhone.Text = "Phone:"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(107, 187)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(140, 25)
        Me.txtCustomerName.TabIndex = 29
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(107, 224)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(140, 25)
        Me.txtAddress.TabIndex = 30
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(107, 267)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(140, 25)
        Me.txtEmail.TabIndex = 31
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(107, 302)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(140, 25)
        Me.txtPhone.TabIndex = 32
        '
        'cmbProductList
        '
        Me.cmbProductList.FormattingEnabled = True
        Me.cmbProductList.Location = New System.Drawing.Point(107, 363)
        Me.cmbProductList.Name = "cmbProductList"
        Me.cmbProductList.Size = New System.Drawing.Size(331, 25)
        Me.cmbProductList.TabIndex = 33
        '
        'lblSelectProduct
        '
        Me.lblSelectProduct.AutoSize = True
        Me.lblSelectProduct.Location = New System.Drawing.Point(5, 366)
        Me.lblSelectProduct.Name = "lblSelectProduct"
        Me.lblSelectProduct.Size = New System.Drawing.Size(98, 17)
        Me.lblSelectProduct.TabIndex = 34
        Me.lblSelectProduct.Text = " Select Product:"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(19, 405)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(77, 17)
        Me.lblDescription.TabIndex = 35
        Me.lblDescription.Text = "Description:"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(45, 445)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 17)
        Me.lblPrice.TabIndex = 36
        Me.lblPrice.Text = "Price:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(456, 318)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(59, 17)
        Me.lblSubtotal.TabIndex = 37
        Me.lblSubtotal.Text = "Subtotal:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(521, 318)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 25)
        Me.txtSubtotal.TabIndex = 38
        '
        'lblDiscount
        '
        Me.lblDiscount.AutoSize = True
        Me.lblDiscount.Location = New System.Drawing.Point(459, 367)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(61, 17)
        Me.lblDiscount.TabIndex = 39
        Me.lblDiscount.Text = "Discount:"
        '
        'cmbDiscounts
        '
        Me.cmbDiscounts.FormattingEnabled = True
        Me.cmbDiscounts.Location = New System.Drawing.Point(521, 367)
        Me.cmbDiscounts.Name = "cmbDiscounts"
        Me.cmbDiscounts.Size = New System.Drawing.Size(121, 25)
        Me.cmbDiscounts.TabIndex = 40
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(710, 375)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(42, 17)
        Me.lblValue.TabIndex = 41
        Me.lblValue.Text = "Value:"
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.Location = New System.Drawing.Point(758, 372)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.Size = New System.Drawing.Size(100, 25)
        Me.txtDiscountAmount.TabIndex = 42
        '
        'lblServiceCharge
        '
        Me.lblServiceCharge.AutoSize = True
        Me.lblServiceCharge.Location = New System.Drawing.Point(443, 420)
        Me.lblServiceCharge.Name = "lblServiceCharge"
        Me.lblServiceCharge.Size = New System.Drawing.Size(98, 17)
        Me.lblServiceCharge.TabIndex = 45
        Me.lblServiceCharge.Text = "Service Charge:"
        '
        'txtServiceCharge
        '
        Me.txtServiceCharge.Location = New System.Drawing.Point(542, 420)
        Me.txtServiceCharge.Name = "txtServiceCharge"
        Me.txtServiceCharge.Size = New System.Drawing.Size(100, 25)
        Me.txtServiceCharge.TabIndex = 46
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Location = New System.Drawing.Point(449, 488)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(92, 17)
        Me.lblTotalAmount.TabIndex = 47
        Me.lblTotalAmount.Text = " Total Amount:"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Location = New System.Drawing.Point(542, 485)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 25)
        Me.txtTotalAmount.TabIndex = 48
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.AutoSize = True
        Me.lblAmountPaid.Location = New System.Drawing.Point(710, 429)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Size = New System.Drawing.Size(85, 17)
        Me.lblAmountPaid.TabIndex = 49
        Me.lblAmountPaid.Text = "Amount Paid:"
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.AutoSize = True
        Me.lblPaymentMethod.Location = New System.Drawing.Point(712, 469)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(110, 17)
        Me.lblPaymentMethod.TabIndex = 50
        Me.lblPaymentMethod.Text = "Payment Method:"
        '
        'lblChange
        '
        Me.lblChange.AutoSize = True
        Me.lblChange.Location = New System.Drawing.Point(712, 513)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(55, 17)
        Me.lblChange.TabIndex = 51
        Me.lblChange.Text = "Change:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.Location = New System.Drawing.Point(801, 421)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.Size = New System.Drawing.Size(100, 25)
        Me.txtAmountPaid.TabIndex = 52
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(773, 513)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(100, 25)
        Me.txtChange.TabIndex = 53
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(828, 461)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(121, 25)
        Me.cmbPaymentMethod.TabIndex = 54
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.BackColor = System.Drawing.Color.Peru
        Me.btnSaveInvoice.Location = New System.Drawing.Point(126, 618)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.Size = New System.Drawing.Size(100, 31)
        Me.btnSaveInvoice.TabIndex = 55
        Me.btnSaveInvoice.Text = "Save"
        Me.btnSaveInvoice.UseVisualStyleBackColor = False
        '
        'txtProductDescription
        '
        Me.txtProductDescription.Location = New System.Drawing.Point(107, 405)
        Me.txtProductDescription.Name = "txtProductDescription"
        Me.txtProductDescription.Size = New System.Drawing.Size(321, 25)
        Me.txtProductDescription.TabIndex = 56
        '
        'txtProductPrice
        '
        Me.txtProductPrice.Location = New System.Drawing.Point(107, 445)
        Me.txtProductPrice.Name = "txtProductPrice"
        Me.txtProductPrice.Size = New System.Drawing.Size(100, 25)
        Me.txtProductPrice.TabIndex = 57
        '
        'btnPrintInvoice
        '
        Me.btnPrintInvoice.BackColor = System.Drawing.Color.Peru
        Me.btnPrintInvoice.Location = New System.Drawing.Point(521, 618)
        Me.btnPrintInvoice.Name = "btnPrintInvoice"
        Me.btnPrintInvoice.Size = New System.Drawing.Size(121, 30)
        Me.btnPrintInvoice.TabIndex = 58
        Me.btnPrintInvoice.Text = "Print Invoice"
        Me.btnPrintInvoice.UseVisualStyleBackColor = False
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'BillingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.btnPrintInvoice)
        Me.Controls.Add(Me.txtProductPrice)
        Me.Controls.Add(Me.txtProductDescription)
        Me.Controls.Add(Me.btnSaveInvoice)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.txtChange)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.lblChange)
        Me.Controls.Add(Me.lblPaymentMethod)
        Me.Controls.Add(Me.lblAmountPaid)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.txtServiceCharge)
        Me.Controls.Add(Me.lblServiceCharge)
        Me.Controls.Add(Me.txtDiscountAmount)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.cmbDiscounts)
        Me.Controls.Add(Me.lblDiscount)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.lblSubtotal)
        Me.Controls.Add(Me.lblPrice)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblSelectProduct)
        Me.Controls.Add(Me.cmbProductList)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtCashier)
        Me.Controls.Add(Me.lblCashier)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblInvoiceID)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnResetCart)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dgvCart)
        Me.Controls.Add(Me.btnAddToCart)
        Me.Controls.Add(Me.nudQuantity)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "BillingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing & Invoice"
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents btnResetCart As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblInvoiceID As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblCashier As Label
    Friend WithEvents txtCashier As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents cmbProductList As ComboBox
    Friend WithEvents lblSelectProduct As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents lblDiscount As Label
    Friend WithEvents cmbDiscounts As ComboBox
    Friend WithEvents lblValue As Label
    Friend WithEvents txtDiscountAmount As TextBox
    Friend WithEvents lblServiceCharge As Label
    Friend WithEvents txtServiceCharge As TextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblAmountPaid As Label
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents txtChange As TextBox
    Friend WithEvents cmbPaymentMethod As ComboBox
    Friend WithEvents btnSaveInvoice As Button
    Friend WithEvents txtProductDescription As TextBox
    Friend WithEvents txtProductPrice As TextBox
    Friend WithEvents btnPrintInvoice As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
