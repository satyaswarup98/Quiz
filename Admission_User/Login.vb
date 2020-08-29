Imports System.Globalization
Imports System.IO
Imports System.Net.Sockets
Imports MySql.Data.MySqlClient

Public Class Login
    Dim start As Integer = 0
    Dim user_status As Integer = 0
    Dim user_status_answer_table As Integer = 0
    Dim user_status_subject_register_answer_table As Integer = 0

    Dim time_status As Integer = 0
    Dim mydate As DateTime
    Dim now_date As DateTime
    Dim time_count As Integer = 0
    Dim startTime As DateTime = DateTime.ParseExact("01-01-2050 12:00:00", "dd-MM-yyyy HH:mm:ss", Nothing)
    Dim expireDate As DateTime = DateTime.ParseExact("01-06-2021 12:00:00", "dd-MM-yyyy HH:mm:ss", Nothing)

    Private Sub bt_1_Click(sender As Object, e As EventArgs) Handles bt_1.Click
        If t1.Text = "" Or t2.Text = "" Then

        Else
            Serv = t1.Text
            use = t2.Text
            ds()
        End If

        check_start()

        If start = 0 Then
            Try
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                str = "select * from login where email='" & tb_1.Text & "' and pass='" & tb_2.Text & "'"
                com = New MySqlCommand(str, con)
                reader = com.ExecuteReader
                If reader.Read Then
                    Logged_Dept_id = reader("id")
                    Logged_Dept_class = reader("class")
                    Dim name As String = reader("name")
                    user_status = reader("status")
                    con.Close()
                    check_exam_time()
                    If (user_status = 0) Then
                        check_user_status_ansewer_table()
                        If user_status_subject_register_answer_table = 1 Then
                            If (user_status_answer_table = 0) Then
                                If time_status <> 1 Then
                                    fetch_time()
                                End If
                                If time_status = 1 Then
                                    If expireDate.Subtract(now_date).TotalSeconds < 0 Then
                                        Dim exits As Integer = MessageBox.Show("Your Licence Expired! Contact Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        If exits = DialogResult.OK Then
                                            Application.Exit()
                                        End If
                                    End If
                                    If (startTime.Subtract(now_date).TotalSeconds) < 1 And (startTime.Subtract(now_date).TotalSeconds) > -600 Then
                                        Home.lb_1.Text = "  " + name
                                        Home.Button1.Text = "Class " & Logged_Dept_class & " : " & Logged_Exam_name
                                        update_user_status()
                                        Home.Show()
                                        Me.Close()
                                    Else

                                        If (startTime.Subtract(now_date).TotalSeconds) < -600 Then
                                            MsgBox("Can't Login after 10 mins of Exam Start !!" & vbCrLf & "Exam for " & Logged_Exam_name & " already Started at " & startTime.ToString("dd-MMM HH:mm tt"), MessageBoxIcon.Warning)
                                        Else
                                            MsgBox("Your Next Exam is " & Logged_Exam_name & " on " & startTime.ToString("dd-MMM HH:mm tt"), MessageBoxIcon.Information)
                                        End If
                                    End If
                                End If
                            Else
                                MsgBox("User Already Appeared ", MessageBoxIcon.Error)
                            End If
                        End If
                    Else
                        MsgBox("User is Already Logged in", MessageBoxIcon.Error)
                    End If
                Else
                    MsgBox("Invalid Login Details", MessageBoxIcon.Error)
                End If
                reader.Close()
                con.Close()
            Catch ex As Exception
                MsgBox("Error in Database Connection", MessageBoxIcon.Error)
                'MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        Else
            MsgBox("Admin has not Started the Exam yet !!", MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetch_time()
        TIME_SET()
        Edit.Show()

    End Sub

    Private Sub bt_2_Click(sender As Object, e As EventArgs) Handles bt_2.Click
        tb_2.Text = ""
        tb_1.Text = ""
    End Sub

    Private Sub check_exam_time()
        startTime = DateTime.ParseExact("01-01-2050 12:00:00", "dd-MM-yyyy HH:mm:ss", Nothing)
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            str = "select * from schedule where class=" & Logged_Dept_class
            com = New MySqlCommand(str, con)
            reader = com.ExecuteReader

            If reader.Read Then
                For i = 1 To reader.FieldCount - 1
                    If reader(i).ToString <> "" Then
                        Try
                            If startTime > DateTime.ParseExact(reader(i), "dd-MM-yyyy HH:mm:ss", Nothing) Then
                                startTime = DateTime.ParseExact(reader(i), "dd-MM-yyyy HH:mm:ss", Nothing)
                                Logged_Exam_name = reader.GetName(i).ToString
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                Next

            Else
                MsgBox("Exam time Error", MessageBoxIcon.Error)
            End If
            reader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub fetch_time()
        Try
            time_status = 0
            Dim client = New TcpClient("time.nist.gov", 13)

            Using streamReader = New StreamReader(client.GetStream())
                Dim response = streamReader.ReadToEnd()
                Dim utcDateTimeString = response.Substring(7, 17)
                mydate = Date.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal)

            End Using
            time_status = 1
        Catch ex As Exception
            'MsgBox("No Internet Connection", MessageBoxIcon.Error)
            Dim exits As Integer = MessageBox.Show("No Internet Connection", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)

            If exits = DialogResult.Retry Then
                fetch_time()
            End If
        End Try
    End Sub

    Sub TIME_SET()

        Try
            'Dim s As DateTime = "13-Sep-2019 11:15:00 AM"
            'Dim secondsDiff = DateDiff(DateInterval.Second, DateTime.Now, s)
            'Dim ts As TimeSpan = TimeSpan.FromSeconds(secondsDiff)

            'Dim mydate As DateTime = New DateTime(ts.Ticks)
            now_date = mydate.AddSeconds(time_count)
            'Dim dd As Int32 = Convert.ToInt32(mydate.ToString("dd"))
            Label3.Text = now_date.ToString("dd-MMM-yyyy")
            Label2.Text = now_date.ToString("HH:mm:ss")
            'Label1.Text = secondsDiff.ToString
            'Label1.Text = TimeOfDay.ToString("hh:mm:ss")
            'Label3.Text = TimeOfDay.ToString("tt")
            time_count += 1

            'lb_7.Text = mydate.ToString()
        Catch ex As Exception
            'Label2.Text = "00:00:00"
        End Try

    End Sub

    Dim a As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TIME_SET()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Dim exits As Integer = MessageBox.Show("Do you want to Exit application ??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If exits = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub


    Private Sub BunifuCustomLabel2_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel2.Click
        Edit.Show()
    End Sub

    Sub check_start()
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            str = "select * from system where id=1"
            com = New MySqlCommand(str, con)
            reader = com.ExecuteReader
            If reader.Read Then
                start = reader("start")
            Else
                MsgBox("Error2", MessageBoxIcon.Error)
            End If
            reader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub check_user_status_ansewer_table()
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            str = "select status from a_" & Logged_Exam_name & " where id=" & Logged_Dept_id
            com = New MySqlCommand(str, con)
            reader = com.ExecuteReader
            If reader.Read Then
                user_status_answer_table = reader("status")
                user_status_subject_register_answer_table = 1
            Else
                user_status_subject_register_answer_table = 0
                MsgBox("Not Registered for this Subject", MessageBoxIcon.Error)
            End If
            reader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Sub update_user_status()
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()

            '----status update in login table ------
            str = "UPDATE login SET status =1 ,login_time='" & now_date & "' where id=" & Logged_Dept_id
            com = New MySqlCommand(str, con)
            com.ExecuteNonQuery()

            '----status update in answer table ------
            str = "UPDATE a_" & Logged_Exam_name & " SET status =1 ,login_time='" & now_date & "' where id=" & Logged_Dept_id
            com = New MySqlCommand(str, con)
            com.ExecuteNonQuery()

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub Panel2_DoubleClick(sender As Object, e As EventArgs) Handles Panel2.DoubleClick
        Dim exits As Integer = MessageBox.Show("Do you want to Restart PC ??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If exits = DialogResult.Yes Then
            If t1.Visible = False Then
                t1.Visible = True
                t2.Visible = True
                l1.Visible = True
                l2.Visible = True
            Else
                t1.Visible = False
                t2.Visible = False
                l1.Visible = False
                l2.Visible = False
            End If
        End If
    End Sub
End Class
