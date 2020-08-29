
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Reflection
Imports MySql.Data.MySqlClient

Public Class Home
    Dim r(4) As Boolean
    Dim bookmarks(40) As Boolean
    Dim q_answers() As Integer = Enumerable.Repeat(5, 40).ToArray



    '-------TIMER----------

    Dim a As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        a += 1
        If a = 5 Then
            PictureBox2.Visible = False
            a = 0
        Else
            PictureBox2.Visible = True
        End If

    End Sub

    Dim sec As Integer = 1800
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label2.Text = Val(sec \ 60).ToString + ":" + Val(sec Mod 60).ToString
        sec -= 1
        If sec < 0 Then
            final_submit()
            Timer2.Stop()

            Dim tq As Integer = MessageBox.Show("Your application has auto submited, Thank You !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If tq = DialogResult.OK Then
                Application.Exit()
            End If
        End If
    End Sub


    '----------PICTURE BOX-------------

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        'Dim exits As Integer = MessageBox.Show("Do you want to Exit application ??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        'If exits = DialogResult.Yes Then
        '    Application.Exit()
        'End If
    End Sub

    '-----------LOAD METHOD----------
    Dim q_no As Integer = 1

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.HorizontalScroll.Visible = False
        RadioButton5.Checked = True
        q_answers(q_no - 1) = 5
        question_Retrival()
        r(0) = True
        r(1) = True
        r(2) = True
        r(3) = True
    End Sub

    Private Sub bt_next_Click(sender As Object, e As EventArgs) Handles bt_next.Click
        color_change()
        answer_post()
        If q_no < 30 Then
            q_no += 1
        End If

        question_Retrival()

        bookmark_button_color()
        answer_record(q_answers(q_no - 1))

    End Sub

    Private Sub bt_prev_Click(sender As Object, e As EventArgs) Handles bt_prev.Click
        color_change()
        answer_post()
        If q_no > 1 Then
            q_no -= 1
        End If

        question_Retrival()

        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Sub question_Retrival()
        FlowLayoutPanel1.AutoScrollPosition = New Point(0, 0)
        Try

            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.Open()
            str = "select * from q_" & Logged_Exam_name & "_" & Logged_Dept_class & " where q_no=" + q_no.ToString
            'str = "select * from q_english_5 where q_no=" + q_no.ToString
            com = New MySqlCommand(str, con)
            reader = com.ExecuteReader
            If reader.Read Then
                question.Text = reader("q_no").ToString() + ". " + reader("question").ToString.Replace("\n", vbNewLine)
                If Not reader.IsDBNull(2) Then
                    Question_Picture.Visible = True
                    Dim lb() As Byte = reader("image")
                    Dim q_img As New System.IO.MemoryStream(lb)
                    Question_Picture.Image = Image.FromStream(q_img)
                Else
                    Question_Picture.Visible = False
                End If
                RadioButton1.Text = reader("option_1").ToString
                RadioButton2.Text = reader("option_2").ToString
                RadioButton3.Text = reader("option_3").ToString
                RadioButton4.Text = reader("option_4").ToString
                con.Close()

            Else
                MsgBox("Error Reading Question")
            End If
            reader.Close()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub answer_post()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

        Try
            con.Open()
            str = "UPDATE a_" & Logged_Exam_name & " Set q" & q_no & "=" & q_answers(q_no - 1) & " where id=" & Logged_Dept_id & " And Class = " & Logged_Dept_class
            com = New MySqlCommand(str, con)
            com = New MySqlCommand(str, con)
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub final_submit()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

        Try
            con.Open()
            '----status update in answer table ------
            str = "UPDATE a_" & Logged_Exam_name & " Set status =2 ,submit_time='" & DateTime.Now & "' ,remaining_time='" & Label2.Text & "' where id=" & Logged_Dept_id
            com = New MySqlCommand(str, con)
            com.ExecuteNonQuery()

            '----status update in login table ------
            str = "UPDATE login SET status =0  where id=" & Logged_Dept_id
            com = New MySqlCommand(str, con)
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If r(0) Then
            answer_record(1)
        Else
            answer_record(5)
        End If
    End Sub





    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        If r(1) Then
            answer_record(2)
        Else
            answer_record(5)
        End If
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        If r(2) Then
            answer_record(3)
        Else
            answer_record(5)
        End If
    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        If r(3) Then
            answer_record(4)
        Else
            answer_record(5)
        End If
    End Sub


    Sub color_change()
        Dim btn = Me.Controls.OfType(Of Button).Where(Function(x) x.Name = "q_" & q_no)
        'MsgBox(q_answers(q_no - 1) & bookmarks(q_no - 1))
        If q_answers(q_no - 1) <> 5 Then
            If bookmarks(q_no - 1) Then
                btn(0).BackColor = System.Drawing.Color.FromArgb(255, 186, 38)
            Else
                btn(0).BackColor = System.Drawing.Color.FromArgb(22, 219, 0)
            End If
        Else
            If bookmarks(q_no - 1) Then
                btn(0).BackColor = System.Drawing.Color.FromArgb(255, 31, 31)
            Else
                btn(0).BackColor = System.Drawing.Color.FromArgb(150, 149, 149)
            End If
        End If
    End Sub

    Sub answer_record(ByVal a As Integer)
        'MsgBox(a)
        q_answers(q_no - 1) = a
        RadioButton1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        RadioButton2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        RadioButton3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        RadioButton4.ForeColor = System.Drawing.Color.FromArgb(64,64,64)
        r(0) = True
        r(1) = True
        r(2) = True
        r(3) = True
        'MsgBox("RadioButton1  " & "RadioButton" & a)
        Dim btn = Panel_r.Controls.OfType(Of RadioButton).Where(Function(x) x.Name = "RadioButton" & a)
        btn(0).ForeColor = System.Drawing.Color.FromArgb(52, 173, 24)
        btn(0).Checked = True


        If a < 5 Then
            r(a - 1) = False
        End If


    End Sub

    '----------BOOKMARK BUTTON------------


    Private Sub bt_bookmark_Click(sender As Object, e As EventArgs) Handles bt_bookmark.Click
        If bookmarks(q_no - 1) = False Then
            bookmarks(q_no - 1) = True
        Else
            bookmarks(q_no - 1) = False
        End If
        bookmark_button_color()

    End Sub

    Sub bookmark_button_color()
        If bookmarks(q_no - 1) Then
            bt_bookmark.ActiveFillColor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.ActiveForecolor = System.Drawing.Color.White
            bt_bookmark.ForeColor = System.Drawing.Color.White
            bt_bookmark.IdleFillColor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.IdleForecolor = System.Drawing.Color.White
            bt_bookmark.ForeColor = System.Drawing.Color.White
            bt_bookmark.ButtonText = "BOOKMARKED"
        Else
            bt_bookmark.ActiveFillColor = System.Drawing.Color.White
            bt_bookmark.ActiveForecolor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.IdleFillColor = System.Drawing.Color.White
            bt_bookmark.IdleForecolor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
            bt_bookmark.ButtonText = "BOOKMARK FOR REVIEW"
        End If
    End Sub





    Private Sub bt_fsubmit_Click(sender As Object, e As EventArgs) Handles bt_fsubmit.Click
        Dim submit As Integer = MessageBox.Show("Confirm to Final Submit !! No changes can be made after this.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If submit = DialogResult.Yes Then
            Dim submit2 As Integer = MessageBox.Show("Final Confirmation for Final Submit !!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If submit2 = DialogResult.Yes Then
                final_submit()
                Dim tq As Integer = MessageBox.Show("Thank You !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If tq = DialogResult.OK Then
                    Application.Exit()
                End If
            End If
        End If
    End Sub








    Private Structure KBDLLHOOKSTRUCT

        Public key As Keys
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public extra As IntPtr
    End Structure

    'System level functions to be used for hook and unhook keyboard input
    Private Delegate Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(ByVal id As Integer, ByVal callback As LowLevelKeyboardProc, ByVal hMod As IntPtr, ByVal dwThreadId As UInteger) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(ByVal hook As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(ByVal hook As IntPtr, ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetModuleHandle(ByVal name As String) As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetAsyncKeyState(ByVal key As Keys) As Short
    End Function

    'Declaring Global objects
    Private ptrHook As IntPtr
    Private objKeyboardProcess As LowLevelKeyboardProc



    Public Sub New()

        Try
            Dim objCurrentModule As ProcessModule = Process.GetCurrentProcess().MainModule
            'Get Current Module
            objKeyboardProcess = New LowLevelKeyboardProc(AddressOf captureKey)
            'Assign callback function each time keyboard process
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0)
            'Setting Hook of Keyboard Process for current module
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        Catch ex As Exception

        End Try
    End Sub

    Private Function captureKey(ByVal nCode As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

        Try
            If nCode >= 0 Then
                Dim objKeyInfo As KBDLLHOOKSTRUCT = DirectCast(Marshal.PtrToStructure(lp, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT)
                If objKeyInfo.key = Keys.RWin OrElse objKeyInfo.key = Keys.LWin Then
                    ' Disabling Windows keys
                    Return CType(1, IntPtr)
                End If
                If objKeyInfo.key = Keys.ControlKey OrElse objKeyInfo.key = Keys.Escape Then
                    ' Disabling Ctrl + Esc keys
                    Return CType(1, IntPtr)
                End If
                If objKeyInfo.key = Keys.ControlKey OrElse objKeyInfo.key = Keys.Down Then
                    ' Disabling Ctrl + Esc keys
                    Return CType(1, IntPtr)
                End If
                If objKeyInfo.key = Keys.Alt OrElse objKeyInfo.key = Keys.Tab Then
                    ' Disabling Ctrl + Esc keys
                    Return CType(1, IntPtr)
                End If
                If objKeyInfo.key = Keys.F2 Then
                    ' Disabling Ctrl + Esc keys
                    Return CType(1, IntPtr)
                End If
            End If
            Return CallNextHookEx(ptrHook, nCode, wp, lp)
        Catch ex As Exception

        End Try
    End Function

    '---------QUESTION NO BUTTONS-------------


    Private Sub q_1_Click(sender As Object, e As EventArgs) Handles q_1.Click
        color_change()
        answer_post()
        q_no = 1
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub
    Private Sub q_2_Click(sender As Object, e As EventArgs) Handles q_2.Click
        color_change()
        answer_post()
        q_no = 2
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_3_Click(sender As Object, e As EventArgs) Handles q_3.Click
        color_change()
        answer_post()
        q_no = 3
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_4_Click(sender As Object, e As EventArgs) Handles q_4.Click
        color_change()
        answer_post()
        q_no = 4
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_5_Click(sender As Object, e As EventArgs) Handles q_5.Click
        color_change()
        answer_post()
        q_no = 5
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_6_Click(sender As Object, e As EventArgs) Handles q_6.Click
        color_change()
        answer_post()
        q_no = 6
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_7_Click(sender As Object, e As EventArgs) Handles q_7.Click
        color_change()
        answer_post()
        q_no = 7
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_8_Click(sender As Object, e As EventArgs) Handles q_8.Click
        color_change()
        answer_post()
        q_no = 8
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_9_Click(sender As Object, e As EventArgs) Handles q_9.Click
        color_change()
        answer_post()
        q_no = 9
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_10_Click(sender As Object, e As EventArgs) Handles q_10.Click
        color_change()
        answer_post()
        q_no = 10
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_11_Click(sender As Object, e As EventArgs) Handles q_11.Click
        color_change()
        answer_post()
        q_no = 11
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_12_Click(sender As Object, e As EventArgs) Handles q_12.Click
        color_change()
        answer_post()
        q_no = 12
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_13_Click(sender As Object, e As EventArgs) Handles q_13.Click
        color_change()
        answer_post()
        q_no = 13
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_14_Click(sender As Object, e As EventArgs) Handles q_14.Click
        color_change()
        answer_post()
        q_no = 14
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_15_Click(sender As Object, e As EventArgs) Handles q_15.Click
        color_change()
        answer_post()
        q_no = 15
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_16_Click(sender As Object, e As EventArgs) Handles q_16.Click
        color_change()
        answer_post()
        q_no = 16
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_17_Click(sender As Object, e As EventArgs) Handles q_17.Click
        color_change()
        answer_post()
        q_no = 17
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_18_Click(sender As Object, e As EventArgs) Handles q_18.Click
        color_change()
        answer_post()
        q_no = 18
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_19_Click(sender As Object, e As EventArgs) Handles q_19.Click
        color_change()
        answer_post()
        q_no = 19
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_20_Click(sender As Object, e As EventArgs) Handles q_20.Click
        color_change()
        answer_post()
        q_no = 20
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_21_Click(sender As Object, e As EventArgs) Handles q_21.Click
        color_change()
        answer_post()
        q_no = 21
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_22_Click(sender As Object, e As EventArgs) Handles q_22.Click
        color_change()
        answer_post()
        q_no = 22
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_23_Click(sender As Object, e As EventArgs) Handles q_23.Click
        color_change()
        answer_post()
        q_no = 23
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_24_Click(sender As Object, e As EventArgs) Handles q_24.Click
        color_change()
        answer_post()
        q_no = 24
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_25_Click(sender As Object, e As EventArgs) Handles q_25.Click
        color_change()
        answer_post()
        q_no = 25
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_26_Click(sender As Object, e As EventArgs) Handles q_26.Click
        color_change()
        answer_post()
        q_no = 26
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_27_Click(sender As Object, e As EventArgs) Handles q_27.Click
        color_change()
        answer_post()
        q_no = 27
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_28_Click(sender As Object, e As EventArgs) Handles q_28.Click
        color_change()
        answer_post()
        q_no = 28
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_29_Click(sender As Object, e As EventArgs) Handles q_29.Click
        color_change()
        answer_post()
        q_no = 29
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub

    Private Sub q_30_Click(sender As Object, e As EventArgs) Handles q_30.Click
        color_change()
        answer_post()
        q_no = 30
        question_Retrival()
        bookmark_button_color()
        answer_record(q_answers(q_no - 1))
    End Sub


    Private Sub bt_2_Click(sender As Object, e As EventArgs) Handles bt_2.Click
        Edit.Show()
    End Sub
End Class