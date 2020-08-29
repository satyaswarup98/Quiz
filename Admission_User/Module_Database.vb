Imports MySql.Data.MySqlClient
Module Module_DataBase

    Public Serv As String = "127.0.0.1"
    Public use As String = "root"

    'Public con As New MySqlConnection(" Server =" & Serv & " ; Port = 3306 ; Database=quiz_db ; User =" & use & " ; Password = ; SslMode=none ")
    Public con As New MySqlConnection(" Server = 119.18.54.11 ; Port = 3306 ; Database=knowyfnk_quiz_db; User =knowyfnk_knowyfnk; Password =Daisy@210312#; SslMode=none; Convert Zero Datetime=True")

    Public com As New MySqlCommand
    Public reader As MySqlDataReader

    Public Sub ds()
        con = New MySqlConnection(" Server =" & Serv & " ; Port = 3306 ; Database=quiz_db; User =" & use & " ; Password =; SslMode=none; Convert Zero Datetime=True")
    End Sub

    Public str As String
    Public dtt, dtt2 As String

    Public ds_rank, ds_details, ds_reservation, ds_marks, ds_login, ds_weightage, ds_marks10, ds_pay As New DataSet
    Public sqlda_rank, sqlda_details, sqlda_reservation, sqlda_marks, sqlda_login, sqlda_marks10, sqlda_weightage, sqlda_pay As MySqlDataAdapter

End Module