Public Class Form1
    Private OnAGirilmedi As Boolean = False
    Dim N1 As Decimal
    Dim N2 As Decimal
    Dim H1 As String
    Dim H2 As String
    Dim H3 As String
    Dim V As ULong


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = "0"

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'İlk Boolean değeri "False" olarak atıyoruz
        OnAGirilmedi = False

        ' Girilen sayı klavyenin üstündeki sayılardan farklı mı 0-9
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Girilen sayı klavyenin sağındaki sayılardan farklı mı 0-9
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Kullanıcı Backspaceden farklı bir tuşa mı bastı
                If e.KeyCode <> Keys.Back Then
                    'Kullanıcı A-F dışında bir karaktere mi bastı
                    If e.KeyCode < Keys.A OrElse e.KeyCode > Keys.F Then
                        'Demekki kullancı 0-9 ve A-F dışında bir tuşa başmış 
                        'O zaman bayrak yazmacını "True" olarak ayarlayalım
                        OnAGirilmedi = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'OnAGirilmedi değişkeni doğruysa
        If OnAGirilmedi = True Then
            'textkutusuna basılan değeri yazma sadece onaltılık karakterleri yaz
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        On Error GoTo Hata
        H1 = TextBox1.Text
        N1 = CDec("&H" & H1)
        Label3.Text = N1 & "d"
        H2 = TextBox2.Text
        N2 = CDec("&H" & TextBox2.Text)
        V = Decimal.Multiply(N1, N2)
        TextBox3.Text = Conversion.Hex(V)
        H3 = Conversion.Hex(V)
        TextBox4.Text = Mid(H3, 9)
        TextBox5.Text = StrReverse(Mid(StrReverse(H3), 9))
        Exit Sub
Hata:
        TextBox2.Text = "0"

    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        On Error GoTo Hata
        H1 = TextBox1.Text
        N1 = CDec("&H" & H1)
        H2 = TextBox2.Text
        N2 = CDec("&H" & H2)
        Label4.Text = N2 & "d"
        V = Decimal.Multiply(N1, N2)
        TextBox3.Text = Conversion.Hex(V)
        H3 = Conversion.Hex(V)
        TextBox4.Text = Mid(H3, 9)
        TextBox5.Text = StrReverse(Mid(StrReverse(H3), 9))
        Exit Sub
Hata:
        TextBox1.Text = "0"
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        OnAGirilmedi = False
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                If e.KeyCode <> Keys.Back Then
                    If e.KeyCode < Keys.A OrElse e.KeyCode > Keys.F Then
                        OnAGirilmedi = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If OnAGirilmedi = True Then
            e.Handled = True
        End If

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Programlamada işlem yaparken kullandığımız değişken türlerine dikkat etmeliyiz." + Chr(13) + _
                "Serkan için hazırladığım bu örnekte değişkenleri inceleyin. 32bitlik bir sayı olan" + Chr(13) + _
                "FFFFFFFF ile FFFFFFFFnin çarpımı bize 64bitlik bir sayı verecektir." + Chr(13) + _
                "Bu program için kullandığım" + Chr(13) & Chr(13) + _
                "DECIMAL" + Chr(9) + ":0 through +/-79,228,162,514,264,337,593,543,950,335 (+/-7.9...E+28)" + Chr(13) + _
                "ULONG" + Chr(9) + ":0 through 18,446,744,073,709,551,615 (1.8...E+19 †) (unsigned)" + Chr(13) & Chr(13) + _
                "değişkenlerinin sınırlarına dikkat edin. Eğer değişkene atamak istediğiniz değer" + Chr(13) + _
                "kendi sınırından büyük ya da küçük ise hata verecektir." + Chr(13) & Chr(13) + _
                "Blue DeviL // SCT" + Chr(13) + _
                "2011", _
               MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    End Sub
End Class
