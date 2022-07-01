Imports System.Drawing
Imports System.GC




Public Class Form6
    Dim g As Byte = 1




    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Form6_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If g = 0 Then
            Exit Sub

        End If
        g = 0
        Dim gr As Graphics = e.Graphics
        gr.TranslateTransform(Me.Width \ 2, _
         Me.Height \ 2)
  

        gr.DrawLine(Pens.Black, New Point(-1000, 0), New Point(1000, 0))
        gr.DrawLine(Pens.Black, New Point(0, -1000), New Point(0, 1000))
        Dim x As String
        Dim y As String



        Dim c As Decimal
    
        Do While System.Threading.Thread.CurrentThread.IsAlive
            Try
                l1.Items.Add(Form5.l1.Items(c))
                l2.Items.Add(Form5.l2.Items(c))

                c += 1


            Catch ex As Exception
                Exit Do

            End Try
        Loop
        c = 0
        Dim xp(l2.Items.Count) As Point
        For Each y In l2.Items

            x = l1.Items(c)
            If x = "Eror" Or y = "Eror" Then
                GoTo b

            End If

            xp(c) = New Point(x, y)
            c += 1

b:


        Next
        Dim x3 As Decimal = 1 '((l1.Items(0)) + CDec(l1.Items(l1.Items.Count - 1))) / 2
        Dim y3 As Decimal = 1 '((l2.Items(0)) + CDec(l2.Items(l1.Items.Count - 1))) / 2
        If (x3 >= 0 And x3 < 100) Or (x3 <= 0 And x3 > 100) Then
           
            x3 = x3 * Form5.tr1.Tag
            x3 = Math.Round(x3, 9)
            If x3 = 0 Then
                x3 = 1

            End If
        End If


        y3 = y3 * Form5.tr1.Tag
        y3 = Math.Round(y3, 9)
        If y3 = 0 Then
            y3 = 1

        End If
        If Form5.ty1.Text <> "" Then
            y3 = Form5.ty1.Text
            y3 = y3 * Form5.tr1.Tag

        End If
        If Form5.tx1.Text <> "" Then
            x3 = Form5.tx1.Text
            x3 = x3 * Form5.tr1.Tag

        End If
        Dim a22 As Point
        For Each a22 In xp
            gr.DrawString(".", Button1.Font, Brushes.Black, New Point((a22.X / x3) - 1, (-a22.Y / y3) - 9.59))

            ' gr.DrawString(".", Button1.Font, Brushes.Black, a22)


        Next








    End Sub


  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Form5.Timer1.Start()
        Me.Close()
    End Sub
End Class