
Imports System.Transactions
Imports Billing_and_Invoicing_System.Models
Imports MySql.Data.MySqlClient
Public Class BillingForm
    Public loggedInUser As String
    Public loggedInRole As String

    Public parentForm As Form

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=2121;database=cafebillingsystem")
    Dim cartTable As New DataTable()
    Dim subtotal As Decimal = 0
    Dim discountRate As Decimal = 0
    Dim serviceRate As Decimal = 0.05D

    Private Sub BillingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cartTable.Columns.Add("ProductID", GetType(Integer))
        cartTable.Columns.Add("Product", GetType(String))
        cartTable.Columns.Add("Qty", GetType(Integer))
        cartTable.Columns.Add("Price", GetType(Decimal))
        cartTable.Columns.Add("LineTotal", GetType(Decimal))

        dgvCart.DataSource = cartTable

        'Add to ensure proper display:
        dgvCart.AutoGenerateColumns = True
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCart.DefaultCellStyle.ForeColor = Color.Black
        dgvCart.DefaultCellStyle.BackColor = Color.White

        LoadProducts()
        LoadDiscounts()
        LoadPaymentMethods()

        ' Set Invoice ID and Date
        lblInvoiceID.Text = GenerateInvoiceID()
        lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy")
        txtCashier.Text = Form1.txtUsername.Text
        dgvCart.AllowUserToAddRows = False
        dgvCart.ReadOnly = True

    End Sub

    Public Class ProductItem
        Public Property ID As Integer
        Public Property Name As String
        Public Property Description As String
        Public Property Price As Decimal

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Private Sub LoadProducts()
        cmbProductList.Items.Clear()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT ProductID, ProductName, Description, Price FROM Products", conn)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                Dim product As New ProductItem With {
                .ID = CInt(reader("ProductID")),
                .Name = reader("ProductName").ToString(),
                .Description = reader("Description").ToString(),
                .Price = CDec(reader("Price"))
            }
                cmbProductList.Items.Add(product)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
        cmbProductList.DisplayMember = "Name"

        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub GenerateNewInvoiceID()
        Try
            conn.Open()
            Dim query As String = "SELECT MAX(InvoiceID) FROM invoices"
            Dim cmd As New MySqlCommand(query, conn)
            Dim result = cmd.ExecuteScalar()

            If result IsNot DBNull.Value Then
                lblInvoiceID.Text = (Convert.ToInt32(result) + 1).ToString()
            Else
                lblInvoiceID.Text = "1"
            End If

        Catch ex As Exception
            MessageBox.Show("Error generating invoice ID: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadDiscounts()
        cmbDiscounts.Items.Clear()
        cmbDiscounts.Items.Add(New DiscountItem With {.Name = "None", .Value = 0D})
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT DiscountName, DiscountValue FROM Discounts", conn)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                Dim discount As New DiscountItem With {
                .Name = reader("DiscountName").ToString(),
                .Value = Convert.ToDecimal(reader("DiscountValue"))
            }
                cmbDiscounts.Items.Add(discount)
            End While
        Catch ex As Exception
            MessageBox.Show("Error loading discounts: " & ex.Message)
        Finally
            conn.Close()
        End Try
        cmbDiscounts.SelectedIndex = 0

        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Private Sub cmbProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductList.SelectedIndexChanged
        Dim selectedProduct As ProductItem = TryCast(cmbProductList.SelectedItem, ProductItem)
        If selectedProduct IsNot Nothing Then
            txtProductDescription.Text = selectedProduct.Description
            txtProductPrice.Text = selectedProduct.Price.ToString("F2")
        End If
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If cmbProductList.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a product.")
            Return
        End If

        Dim selectedProduct As ProductItem = TryCast(cmbProductList.SelectedItem, ProductItem)
        Dim qty As Integer = Convert.ToInt32(nudQuantity.Value)
        Dim price As Decimal = selectedProduct.Price
        Dim lineTotal As Decimal = qty * price

        cartTable.Rows.Add(selectedProduct.ID, selectedProduct.Name, qty, price, lineTotal)

        subtotal += lineTotal
        CalculateTotals()

        dgvCart.DataSource = Nothing
        dgvCart.DataSource = cartTable
    End Sub

    Private Sub cmbDiscounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscounts.SelectedIndexChanged
        Dim discount As DiscountItem = TryCast(cmbDiscounts.SelectedItem, DiscountItem)
        If discount IsNot Nothing Then
            txtDiscountAmount.Text = (discount.Value * 100).ToString("F0") & "%"
        End If
        CalculateTotals()
    End Sub

    Private Sub CalculateTotals()
        Dim discount As DiscountItem = TryCast(cmbDiscounts.SelectedItem, DiscountItem)
        Dim discountRate As Decimal = If(discount IsNot Nothing, discount.Value, 0)

        Dim discountAmount As Decimal = subtotal * discountRate
        Dim service = subtotal * serviceRate
        Dim total = subtotal + service - discountAmount

        txtDiscountAmount.Text = discountAmount.ToString("F2")
        txtSubtotal.Text = subtotal.ToString("F2")
        txtServiceCharge.Text = service.ToString("F2")
        txtTotalAmount.Text = total.ToString("F2")
    End Sub

    Private Sub LoadPaymentMethods()
        cmbPaymentMethod.Items.Clear()
        cmbPaymentMethod.Items.Add("Cash")
        cmbPaymentMethod.Items.Add("GCash")

        cmbPaymentMethod.SelectedIndex = 0
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        If Decimal.TryParse(txtTotalAmount.Text, Nothing) = False Then Return

        Dim paid As Decimal
        If Not Decimal.TryParse(txtAmountPaid.Text, paid) Then
            txtChange.Text = "0.00"
            Return
        End If

        Dim total As Decimal = Convert.ToDecimal(txtTotalAmount.Text)
        Dim change As Decimal = paid - total
        txtChange.Text = change.ToString("F2")
    End Sub

    Private Function GenerateInvoiceID() As String
        Return "INV" & DateTime.Now.ToString("yyyyMMddHHmmss")
    End Function

    Private selectedCustomerID As Integer = -1

    Private Sub btnSaveInvoice_Click(sender As Object, e As EventArgs) Handles btnSaveInvoice.Click
        If dgvCart.Rows.Count = 0 OrElse String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
            MessageBox.Show("Please enter customer name and add at least one product.")
            Return
        End If

        Dim discountAmount, serviceAmount, totalAmount, paymentReceived, changeDue As Decimal

        If Not Decimal.TryParse(txtDiscountAmount.Text.Replace("%", "").Trim(), discountAmount) Then
            discountAmount = 0
        End If

        If Not Decimal.TryParse(txtServiceCharge.Text, serviceAmount) Then
            serviceAmount = 0
        End If

        If Not Decimal.TryParse(txtTotalAmount.Text, totalAmount) Then
            totalAmount = 0
        End If

        If Not Decimal.TryParse(txtAmountPaid.Text, paymentReceived) Then
            paymentReceived = 0
        End If

        If Not Decimal.TryParse(txtChange.Text, changeDue) Then
            changeDue = 0
        End If

        If paymentReceived < totalAmount Then
            MessageBox.Show("Amount paid is less than total amount.")
            Return
        End If

        Try
            conn.Open()
            Dim transaction = conn.BeginTransaction()

            ' Insert Customer
            Dim cmdCustomer As New MySqlCommand("
            INSERT INTO Customers (Name, Address, Email, Phone)
            VALUES (@Name, @Address, @Email, @Phone);
            SELECT LAST_INSERT_ID();", conn, transaction)

            cmdCustomer.Parameters.AddWithValue("@Name", txtCustomerName.Text)
            cmdCustomer.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmdCustomer.Parameters.AddWithValue("@Email", txtEmail.Text)
            cmdCustomer.Parameters.AddWithValue("@Phone", txtPhone.Text)

            selectedCustomerID = Convert.ToInt32(cmdCustomer.ExecuteScalar())

            ' Insert Invoice
            Dim cmdInvoice As New MySqlCommand("
            INSERT INTO Invoices (CustomerID, ServiceCharge, DiscountAmount,
            TotalAmount, PaymentReceived, ChangeDue, InvoiceDate)
            VALUES (@CustomerID, @ServiceCharge, @DiscountAmount, @TotalAmount,
            @PaymentReceived, @ChangeDue, NOW());
            SELECT LAST_INSERT_ID();", conn, transaction)

            cmdInvoice.Parameters.AddWithValue("@CustomerID", selectedCustomerID)
            cmdInvoice.Parameters.AddWithValue("@ServiceCharge", serviceAmount)
            cmdInvoice.Parameters.AddWithValue("@DiscountAmount", discountAmount)
            cmdInvoice.Parameters.AddWithValue("@TotalAmount", totalAmount)
            cmdInvoice.Parameters.AddWithValue("@PaymentReceived", paymentReceived)
            cmdInvoice.Parameters.AddWithValue("@ChangeDue", changeDue)

            Dim invoiceID As Integer = Convert.ToInt32(cmdInvoice.ExecuteScalar())

            ' Insert InvoiceDetails
            For Each row As DataGridViewRow In dgvCart.Rows
                If row.IsNewRow Then Continue For

                Dim productId As Integer = Convert.ToInt32(row.Cells("ProductID").Value)

                Dim quantity As Integer
                If Not Integer.TryParse(row.Cells("Qty").Value?.ToString(), quantity) Then
                    Throw New Exception($"Invalid quantity value for product.")
                End If

                Dim lineTotal As Decimal
                If Not Decimal.TryParse(row.Cells("LineTotal").Value?.ToString(), lineTotal) Then
                    Throw New Exception($"Invalid line total value.")
                End If

                Dim cmdDetail As New MySqlCommand("
                INSERT INTO InvoiceDetails (InvoiceID, ProductID, Quantity, LineTotal)
                VALUES (@InvoiceID, @ProductID, @Quantity, @LineTotal);", conn, transaction)

                cmdDetail.Parameters.AddWithValue("@InvoiceID", invoiceID)
                cmdDetail.Parameters.AddWithValue("@ProductID", productId)
                cmdDetail.Parameters.AddWithValue("@Quantity", quantity)
                cmdDetail.Parameters.AddWithValue("@LineTotal", lineTotal)

                cmdDetail.ExecuteNonQuery()
            Next
            transaction.Commit()
            MessageBox.Show("Transaction saved successfully.")
            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Error saving transaction: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ClearForm()
        txtCustomerName.Clear()
        cmbProductList.SelectedIndex = -1
        txtProductDescription.Clear()
        txtProductPrice.Clear()

        cartTable.Clear()

        subtotal = 0
        txtSubtotal.Clear()
        txtServiceCharge.Clear()
        txtDiscountAmount.Clear()
        txtTotalAmount.Clear()
        txtAmountPaid.Clear()
        txtChange.Clear()
    End Sub

    Private Sub btnResetCart_Click(sender As Object, e As EventArgs) Handles btnResetCart.Click
        ResetForm()
    End Sub

    Private Sub ResetForm()
        txtCustomerName.Clear()
        txtAddress.Clear()
        txtEmail.Clear()
        txtPhone.Clear()

        ' Reset product ComboBox
        cmbProductList.Items.Clear()
        LoadProducts()
        cmbProductList.SelectedIndex = -1

        nudQuantity.Value = 1

        cartTable.Clear()

        subtotal = 0
        txtSubtotal.Text = "0.00"
        txtServiceCharge.Text = "0.00"
        txtDiscountAmount.Text = "0.00"
        txtTotalAmount.Text = "0.00"
        txtAmountPaid.Clear()
        txtChange.Text = "0.00"

        ' Reset discounts ComboBox
        cmbDiscounts.Items.Clear()
        LoadDiscounts()

        ' Reset payment method ComboBox
        cmbPaymentMethod.Items.Clear()
        LoadPaymentMethods()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()

        If String.IsNullOrEmpty(loggedInRole) Then
            MainForm.Show() ' fallback to mainform
            Return
        End If

        Select Case loggedInRole.ToLower()
            Case "admin"
                MainForm.Show()
            Case "cashier"
                If parentForm IsNot Nothing Then
                    parentForm.Show()
                Else
                    Form1.Show() ' fallback to login
                End If
            Case Else
                Form1.Show() ' fallback to login
        End Select
    End Sub

    Private Function GetProductIDByName(productName As String, conn As MySqlConnection, transaction As MySqlTransaction) As Integer
        Dim id As Integer = -1
        Try
            Dim cmd As New MySqlCommand("SELECT ProductID FROM Products WHERE ProductName = @name LIMIT 1", conn, transaction)
            cmd.Parameters.AddWithValue("@name", productName)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                id = Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving ProductID: " & ex.Message)
        End Try
        Return id
    End Function

    Private Sub btnPrintInvoice_Click(sender As Object, e As EventArgs) Handles btnPrintInvoice.Click

        Dim ps As New System.Drawing.Printing.PaperSize("Receipt", 300, 1000)

        PrintDocument1.DefaultPageSettings.PaperSize = ps
        PrintDocument1.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 10, 10)

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Consolas", 8)
        Dim boldFont As New Font("Consolas", 9, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim y As Integer = 10
        Dim leftMargin As Integer = 10

        Dim centerX As Integer = e.MarginBounds.Width \ 2
        Dim title As String = "Coffee Shop"
        Dim titleSize As SizeF = e.Graphics.MeasureString(title, boldFont)
        e.Graphics.DrawString(title, boldFont, brush, centerX - (titleSize.Width / 2), y)


        e.Graphics.DrawString("Coffee Shop", boldFont, brush, leftMargin, y)
        y += 20
        e.Graphics.DrawString("INVOICE", boldFont, brush, leftMargin, y)
        y += 20

        e.Graphics.DrawString("Invoice: " & lblInvoiceID.Text, font, brush, leftMargin, y) : y += 15
        e.Graphics.DrawString("Date: " & lblDate.Text, font, brush, leftMargin, y) : y += 15
        e.Graphics.DrawString("Cashier: " & txtCashier.Text, font, brush, leftMargin, y) : y += 15

        y += 10
        e.Graphics.DrawString("Customer: " & txtCustomerName.Text, font, brush, leftMargin, y) : y += 15

        y += 10
        e.Graphics.DrawString("Item         Qty   Price    Total", font, brush, leftMargin, y)
        y += 15
        e.Graphics.DrawString("--------------------------------", font, brush, leftMargin, y)
        y += 15

        For Each row As DataGridViewRow In dgvCart.Rows
            If row.IsNewRow Then Continue For

            ' values from the DataGridView row
            Dim name As String = row.Cells("Product").Value.ToString()
            Dim qty As String = row.Cells("Qty").Value.ToString()
            Dim price As String = row.Cells("Price").Value.ToString()
            Dim total As String = row.Cells("LineTotal").Value.ToString()

            '  This is the format and pad strings for receipt alignment
            Dim nameFixed = name.PadRight(12).Substring(0, 12)
            Dim qtyFixed = qty.PadLeft(3)
            Dim priceFixed = Format(CDec(price), "0.00").PadLeft(8)
            Dim totalFixed = Format(CDec(total), "0.00").PadLeft(10)

            ' Combine into one aligned line
            Dim line = String.Format("{0}{1}{2}{3}", nameFixed, qtyFixed, priceFixed, totalFixed)
            e.Graphics.DrawString(line, font, brush, leftMargin, y)
            y += 15
        Next

        y += 10
        e.Graphics.DrawString("--------------------------------", font, brush, leftMargin, y)
        y += 15
        Dim amountX As Integer = 180

        e.Graphics.DrawString("Subtotal:", font, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtSubtotal.Text), 2).PadLeft(10), font, brush, amountX, y)
        y += 15

        e.Graphics.DrawString("Service Fee:", font, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtServiceCharge.Text), 2).PadLeft(10), font, brush, amountX, y)
        y += 15

        e.Graphics.DrawString("Discount:", font, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtDiscountAmount.Text), 2).PadLeft(10), font, brush, amountX, y)
        y += 15

        e.Graphics.DrawString("Total:", boldFont, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtTotalAmount.Text), 2).PadLeft(10), boldFont, brush, amountX, y)
        y += 20

        e.Graphics.DrawString("Paid:", font, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtAmountPaid.Text), 2).PadLeft(10), font, brush, amountX, y)
        y += 15

        e.Graphics.DrawString("Change:", font, brush, leftMargin, y)
        e.Graphics.DrawString(FormatNumber(CDec(txtChange.Text), 2).PadLeft(10), font, brush, amountX, y)
        y += 20

        e.Graphics.DrawString("Thank you for your purchase!", font, brush, leftMargin, y)
    End Sub
End Class

