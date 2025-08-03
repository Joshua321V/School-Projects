Imports MySql.Data.MySqlClient
Public Class MainForm
    Public loggedInUser As String
    Public loggedInRole As String

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Billing & Invoicing System v1.6.666.0" & vbCrLf & "Developed by [Joshua V. Reburiano with my team]", MsgBoxStyle.Information)
    End Sub

    Private Sub BillingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingToolStripMenuItem.Click
        Dim billingForm As New BillingForm()
        billingForm.loggedInUser = Me.loggedInUser
        billingForm.loggedInRole = Me.loggedInRole
        billingForm.parentForm = Me
        billingForm.Show()
        Me.Hide()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        Dim productForm As New ProductForm()
        productForm.Show()
        Me.Hide()
    End Sub

    Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click
        Dim CustomerForm As New CustomerForm()
        CustomerForm.Show()
        Me.Hide()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        Dim UserForm As New UserForm()
        UserForm.Show()
        Me.Hide()
    End Sub

    Private Sub SALESREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALESREPORTToolStripMenuItem.Click
        Dim SalesReportForm As New SalesReportForm()
        SalesReportForm.Show()
        Me.Hide()
    End Sub
End Class