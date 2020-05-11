'제작 18.11.20
'1.4 / 18.12.04 / 설정 창 추가(경로 설정 가능)
Public Class Form1
    Private Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        End
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim setup2 As Integer
        setup2 = Shell("C:\lol\Uninstall League of Legends.exe", AppWinStyle.NormalFocus)
        Dim file_ssd_source As String = My.Computer.FileSystem.ReadAllText("lol_version\lol_version_path_ssd.txt")
        Dim file_mobilehdd_source As String = My.Computer.FileSystem.ReadAllText("lol_version\lol_version_path_hdd.txt")
        file_ssd.Text += GetFileVersionInfo(file_ssd_source).ToString
        Dim ssd_version As String = GetFileVersionInfo(file_ssd_source).ToString
        If System.IO.File.Exists(file_mobilehdd_source) = True Then
            file_mobilehdd.Text += GetFileVersionInfo(file_mobilehdd_source).ToString
            Dim hdd_version As String = GetFileVersionInfo(file_mobilehdd_source).ToString
            If ssd_version <> hdd_version Then
                status.Text += "버전 업 확인, MHDD로 시작합니다"
                MessageBox.Show("게임 클라이언트의 버전 업을 확인했습니다." & Chr(13) & "MHDD의 업데이트를 완료 후 프로그램 재가동을 추천합니다", "VersionUp Alert")
                Dim setup As Integer
                setup = Shell(file_mobilehdd_source, AppWinStyle.NormalFocus)
            ElseIf ssd_version = hdd_version Then
                status.Text += "버전 유지 확인, SSD로 시작합니다"
                Dim setup As Integer
                setup = Shell(file_ssd_source, AppWinStyle.NormalFocus)
            End If
        Else
            file_mobilehdd.Text += "현재 경로 상에 존재하지 않습니다"
            status.Text += "확인 불가능, SSD로 시작합니다"
            Dim setup As Integer
            setup = Shell(file_ssd_source, AppWinStyle.NormalFocus)
        End If
        Timer1.Enabled = True
    End Sub
    Private Sub btn_setting_Click(sender As Object, e As EventArgs) Handles btn_setting.Click
        Timer1.Enabled = False
        setting.Show()
    End Sub
End Class
