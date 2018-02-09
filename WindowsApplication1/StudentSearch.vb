Imports MySql.Data.MySqlClient
Public Class StudentSearch

    Private getQuery As String
    Private getcommand As MySqlCommand
    Private getReader As MySqlDataReader

    Public sideBarStatus As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If sideBarStatus = 0 Then


            sidepanel.Location = New Point(930, 54)
            Do Until sidepanel.Location.X = 734
                sidepanel.Location = New Point(sidepanel.Location.X - 1, 54)
                Refresh()
                sideBarStatus = 1

            Loop

        ElseIf sideBarStatus = 1 Then

            sidepanel.Location = New Point(734, 54)
            Do Until sidepanel.Location.X = 930
                sidepanel.Location = New Point(sidepanel.Location.X + 1, 54)
                Refresh()
                sideBarStatus = 0
            Loop







        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles studentList.TextChanged
        Try
            getQuery = "SELECT id_number, last_name, first_name, middle_name, course, college, scholarship FROM basic_info where last_name like '%" & studentList.Text & "%' Or first_name Like '%" & studentList.Text & "%' Or id_number Like '%" & studentList.Text & "%' Or course Like '%" & studentList.Text & "%' Or college Like '%" & studentList.Text & "%'
            Or middle_name Like '%" & studentList.Text & "%' or scholarship Like '%" & studentList.Text & "%'"


            getcommand = New MySqlCommand(getQuery, conn)
            getReader = getcommand.ExecuteReader
            lvList.Items.Clear()

            Do While getReader.Read()

                id_n = (getReader("id_number").ToString)
                first = (getReader("first_name").ToString)
                middle = (getReader("middle_name").ToString)
                last = (getReader("last_name").ToString)
                coll = (getReader("college").ToString)
                cour = (getReader("course").ToString)
                schol = (getReader("scholarship").ToString)

                With lvList.Items.Add(id_n)

                    .SubItems.Add(first + " " + middle + " " + last)
                    .SubItems.Add(coll)
                    .SubItems.Add(cour)
                    .SubItems.Add(schol)
                End With

            Loop
            getReader.Close()
            getcommand.Dispose()


        Catch ex As Exception

            MsgBox("No record!")
        End Try


    End Sub
    End Sub
End Class
