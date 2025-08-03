Imports MySql.Data.MySqlClient

Public Class ProductForm

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=2121;database=cafebillingsystem")
    Dim cmd As MySqlCommand
    Dim selectedProductID As Integer = -1



    Private Sub ProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "Product Management Form"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            conn.Open()
            Dim adapter As New MySqlDataAdapter("SELECT * FROM Products", conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvProducts.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Or txtPrice.Text = "" Then
            MessageBox.Show("Please enter all required fields.")
            Return
        End If

        Try
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO Products (ProductName, Description, Price) VALUES (@name, @desc, @price)", conn)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@desc", txtDescription.Text)
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product added successfully.")
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message)
        Finally
            conn.Close()
        End Try

        LoadProducts()
    End Sub

    Private Sub ClearFields()
        txtName.Text = ""
        txtDescription.Text = ""
        txtPrice.Text = ""
        selectedProductID = -1
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedProductID = -1 Then
            MessageBox.Show("Please select a product to delete.")
            Return
        End If

        Try
            conn.Open()
            cmd = New MySqlCommand("DELETE FROM Products WHERE ProductID=@id", conn)
            cmd.Parameters.AddWithValue("@id", selectedProductID)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product deleted successfully.")
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error deleting product: " & ex.Message)
        Finally
            conn.Close()
        End Try

        LoadProducts()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearFields()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            selectedProductID = Convert.ToInt32(row.Cells("ProductID").Value)
            txtName.Text = row.Cells("ProductName").Value.ToString()
            txtDescription.Text = row.Cells("Description").Value.ToString()
            txtPrice.Text = row.Cells("Price").Value.ToString()
        End If
    End Sub
End Class