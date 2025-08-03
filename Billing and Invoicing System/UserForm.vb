Imports MySql.Data.MySqlClient
Public Class UserForm
    Public Property IsSignUpMode As Boolean = False

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=2121;database=cafebillingsystem")
    Dim cmd As MySqlCommand
    Dim selectedUserID As Integer = -1

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsSignUpMode Then
            dgvUsers.Visible = False
            btnDelete.Visible = False

            Me.Text = "Sign Up - Create Your Account"
        Else
            LoadUsers()
        End If

        lblTitle.Text = "User Management Form"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.TextAlign = ContentAlignment.MiddleCenter

        cboRole.Items.Clear()
        cboRole.Items.Add("Admin")
        cboRole.Items.Add("Cashier")

        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim adapter As New MySqlDataAdapter("SELECT UserID, Username, Role FROM Users", conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvUsers.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Or cboRole.SelectedItem Is Nothing Then
            MessageBox.Show("Please fill all fields.")
            Return
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New MySqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)", conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)
            cmd.Parameters.AddWithValue("@role", cboRole.SelectedItem.ToString())
            cmd.ExecuteNonQuery()
            MessageBox.Show("User added successfully.")
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error saving user: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Please select a user to delete.")
            Return
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd = New MySqlCommand("DELETE FROM Users WHERE UserID=@id", conn)
            cmd.Parameters.AddWithValue("@id", selectedUserID)
            cmd.ExecuteNonQuery()
            MessageBox.Show("User deleted successfully.")
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            selectedUserID = Convert.ToInt32(row.Cells("UserID").Value)
            txtUsername.Text = row.Cells("Username").Value.ToString()
            cboRole.SelectedItem = row.Cells("Role").Value.ToString()
        End If
    End Sub
    Private Sub ClearFields()
        txtUsername.Text = ""
        txtPassword.Text = ""
        cboRole.SelectedIndex = -1
        selectedUserID = -1
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearFields()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If IsSignUpMode Then
            Dim Form1 As New Form1()
            Form1.Show()
        Else
            Dim mainForm As New MainForm()
            mainForm.Show()
        End If

        Me.Close()
    End Sub


End Class