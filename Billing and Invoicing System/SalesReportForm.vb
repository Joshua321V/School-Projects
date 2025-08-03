Imports MySql.Data.MySqlClient

Public Class SalesReportForm
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim conn As New MySqlConnection("server=localhost;userid=root;password=2121;database=cafebillingsystem")
        Dim cmd As New MySqlCommand()
        Dim adapter As New MySqlDataAdapter()
        Dim dt As New DataTable()
        Dim totalSales As Decimal = 0

        Try
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText =
                "SELECT 
                    invoices.InvoiceID,
                    invoices.InvoiceDate,
                    customers.Name,
                    invoices.TotalAmount
                FROM 
                    invoices
                JOIN 
                    customers ON invoices.CustomerID = customers.CustomerID
                WHERE 
                    InvoiceDate BETWEEN @start AND @end"
            cmd.Parameters.AddWithValue("@start", dtpStartDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@end", dtpEndDate.Value.ToString("yyyy-MM-dd"))

            adapter.SelectCommand = cmd
            adapter.Fill(dt)

            'set the DataSource
            dgvSalesReport.DataSource = dt
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If dgvSalesReport.Columns.Contains("TotalAmount") Then
                dgvSalesReport.Columns("TotalAmount").DefaultCellStyle.Format = "C2"
            End If

            ' Calculate total
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row("TotalAmount")) Then
                    totalSales += Convert.ToDecimal(row("TotalAmount"))
                End If
            Next

            lblTotalSales.Text = "₱ " & totalSales.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        MainForm.Show()
    End Sub
End Class
