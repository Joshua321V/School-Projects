Imports System.Transactions
Imports MySql.Data.MySqlClient

Public Class CustomerForm

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=2121;database=cafebillingsystem")
    Dim cmd As MySqlCommand
    Dim selectedCustomerID As Integer = -1

    Private Sub CustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "Customer Management Form"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        LoadCustomers()
    End Sub

    Private Sub LoadCustomers()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim adapter As New MySqlDataAdapter("SELECT * FROM Customers", conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvCustomers.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading customers: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Or txtEmail.Text = "" Or txtPhone.Text = "" Or txtAddress.Text = "" Then
            MessageBox.Show("Please fill out all fields.")
            Return
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO Customers (Name, Email, Phone, Address) VALUES (@name, @email, @phone, @address)", conn)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text)
            cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Customer added successfully.")
            LoadCustomers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error saving customer: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedCustomerID = -1 Then
            MessageBox.Show("Please select a customer to delete.")
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this customer and all their related invoices?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        Dim transaction As MySqlTransaction = Nothing

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            transaction = conn.BeginTransaction()

            Dim deletePayments = New MySqlCommand("
            DELETE FROM Payments 
            WHERE InvoiceID IN (
                SELECT InvoiceID FROM Invoices WHERE CustomerID = @custId
            );", conn, transaction)
            deletePayments.Parameters.AddWithValue("@custId", selectedCustomerID)
            deletePayments.ExecuteNonQuery()

            Dim deleteInvoiceDetails = New MySqlCommand("
            DELETE FROM InvoiceDetails
            WHERE InvoiceID IN (
                SELECT InvoiceID FROM Invoices WHERE CustomerID = @custId
            );", conn, transaction)
            deleteInvoiceDetails.Parameters.AddWithValue("@custId", selectedCustomerID)
            deleteInvoiceDetails.ExecuteNonQuery()

            Dim deleteInvoices = New MySqlCommand("
            DELETE FROM Invoices WHERE CustomerID = @custId;", conn, transaction)
            deleteInvoices.Parameters.AddWithValue("@custId", selectedCustomerID)
            deleteInvoices.ExecuteNonQuery()

            Dim deleteCustomer = New MySqlCommand("
            DELETE FROM Customers WHERE CustomerID = @custId;", conn, transaction)
            deleteCustomer.Parameters.AddWithValue("@custId", selectedCustomerID)
            deleteCustomer.ExecuteNonQuery()

            transaction.Commit()

            MessageBox.Show("Customer and related data deleted successfully.")
            LoadCustomers()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error deleting customer: " & ex.Message)

            Try
                transaction?.Rollback()
            Catch rollbackEx As Exception
                MessageBox.Show("Rollback failed: " & rollbackEx.Message)
            End Try

        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgvCustomers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCustomers.Rows(e.RowIndex)
            selectedCustomerID = Convert.ToInt32(row.Cells("CustomerID").Value)
            txtName.Text = row.Cells("Name").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtPhone.Text = row.Cells("Phone").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
        End If
    End Sub

    Private Sub ClearFields()
        txtName.Text = ""
        txtEmail.Text = ""
        txtPhone.Text = ""
        txtAddress.Text = ""
        selectedCustomerID = -1
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearFields()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        MainForm.Show()
    End Sub
End Class
