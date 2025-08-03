Imports MySql.Data.MySqlClient

Public Class Form1
    Public loggedInUser As String
    Public loggedInRole As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim conStr As String = "server=localhost;userid=root;password=2121;database=cafebillingsystem"


        Using con As New MySqlConnection(conStr)
            Try
                con.Open()

                Dim cmd As New MySqlCommand("SELECT Username, Role FROM users WHERE Username=@username AND Password=@password", con)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    Dim role As String = reader("Role").ToString().ToLower()
                    Dim username As String = reader("Username").ToString()

                    If role = "cashier" Then
                        Dim billingForm As New BillingForm()
                        billingForm.loggedInUser = username
                        billingForm.loggedInRole = role
                        billingForm.Show()
                    Else
                        Dim mainForm As New MainForm()
                        mainForm.loggedInUser = username
                        mainForm.loggedInRole = role
                        mainForm.Show()
                    End If
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub linkSignUp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSignUp.LinkClicked
        Dim signupForm As New UserForm()
        signupForm.IsSignUpMode = True
        signupForm.Show()
        Me.Hide()
    End Sub
End Class
