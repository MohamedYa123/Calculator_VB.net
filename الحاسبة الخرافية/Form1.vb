﻿
Imports Microsoft.VisualBasic.VBMath
Imports System.Threading.Thread
Imports System.Threading
Imports System.Globalization
Imports System.IO


Public Class Form1

    Dim a, b, c As Decimal



    Private Function deq(ByVal ce As String, ByVal fe As Integer) As Object
        'إيجاد رقم مكمل القوس
        Dim test As String, ch As Char, p1, p2, p3, p4, p5 As Single
        test = ce
        test = test.Remove(0, fe + 1)
        For Each ch In test

            p1 = p1 + 1
            If ch = "("c Then
                p2 = p2 + 1
                p3 = p3 + p1
            ElseIf ch = ")"c Then
                p4 = p4 + 1
                p5 = p5 + p1
            End If
            If p4 = p2 + 1 Then
                If p3 < p5 Then
                    Exit For
                End If
            End If
        Next
        Return (p1 + fe)
    End Function

    Private Function Calc(ByVal ce As String) As String
        Dim a As String = ce
        If a.IndexOf(")^(") <> -1 Then
            Dim g, y As Decimal
            Dim rtest As String = ""
            Dim rtest2, rtest3 As String

            Do While g <> a.IndexOf(")^(")

                y = a.IndexOf("(", CInt(g))


                g = deq(a, a.IndexOf("(", CInt(g)))





            Loop
            For g = y To deq(a, y)
                rtest2 = rtest2 & a.Chars(g)

            Next
            rtest2 = Calc3(rtest2)

            For g = (a.IndexOf(")^(") + 2) To deq(a, (a.IndexOf(")^(") + 2))
                rtest = rtest & a.Chars(g)

            Next
    
            a = a.Replace((rtest2 & "^" & rtest), ((CDec(Calc(rtest2))) ^ CDec(Calc(rtest))))


            ElseIf a.IndexOf(")^") <> -1 Then
                Dim g, y As Decimal
                Dim rtest As String = ""
                Dim rtest2, rtest3 As String
                rtest2 = ""

                Do While g <> a.IndexOf(")^")

                    y = a.IndexOf("(", CInt(g))


                    g = deq(a, a.IndexOf("(", CInt(g)))

                    For g = y + 1 To deq(a, y) - 1
                        rtest2 = rtest2 & a.Chars(g)

                    Next

                    For g = (a.IndexOf(")^") + 2) To dnum1(a, (a.IndexOf(")^") + 2), 1)
                        rtest = rtest & a.Chars(g)

                    Next

                    rtest3 = Calc3(rtest2)
                    If CDec(rtest3) > 0 Then
                        Exit Do

                    End If
                a = a.Replace(("(" & rtest2 & ")^" & rtest), (CDec((Calc(rtest2))) ^ CDec(Calc((rtest)))))


                    Exit Do







                Loop
            End If
            Dim rs2 As String
            rs2 = calc2(a)
            Return rs2
    End Function

    Private Function calc2(ByVal c As String) As Decimal
        'كود الحساب الرئيسي
        Dim rs As Decimal
        'أولا التخلص من رموز التجميع

        If c.IndexOf("M") <> -1 Then


            Dim m As Decimal
            Dim xstr As String = ""
            Dim xstp As String = ""

            For m = c.IndexOf("[") + 1 To c.IndexOf(",") - 1
                xstr = xstr & c.Chars(m)

            Next
            xstr = Calc(xstr)
            For m = c.IndexOf(",") + 1 To c.IndexOf("]") - 1
                xstp = xstp & c.Chars(m)
            Next
            xstp = Calc(xstp)
            Dim stest As String = ""

            For m = c.IndexOf(("("), CInt(c.IndexOf("["))) To deq(c, c.IndexOf(("("), CInt(c.IndexOf("["))))
                stest = stest & c.Chars(m)
            Next
            Dim stest2 As String
            Dim stest3 As Decimal
            For m = xstr To xstp
                stest2 = stest
                Try

                    stest2 = stest2.Replace("x", CStr(m))


                Catch ex As Exception

                End Try
                stest3 = stest3 + Calc(stest2)


            Next
       
                rs = Calc(c.Replace(("M" & "[" & xstr & "," & xstp & "]" & stest), stest3))

            Return rs
            ' التخلص من النهايات
        ElseIf c.IndexOf("N") <> -1 Then
            Dim svalue As String = ""
            Dim m As Decimal
            For m = c.IndexOf("{") + 1 To c.IndexOf("}") - 1
                svalue = svalue & c.Chars(m)
            Next
            Dim s0 As Decimal = Calc(svalue)
            Dim s1 As String = ""
            Dim s2 As String = ""
            Dim s3 As String = ""
            s1 = s0 + 0.000000001
            s2 = s0 - 0.000000001
            For m = c.IndexOf("(", c.IndexOf("}")) + 1 To deq(c, c.IndexOf("(", c.IndexOf("}"))) - 1
                s3 = s3 & c.Chars(m)
            Next
            Dim ss5 As String = s3
            Dim s4 As String = Calc(s3.Replace("y", s1))
            s3 = Calc(s3.Replace("y", s2))
            Dim ss3 As Decimal = s3
            Dim ss4 As Decimal = s4
            rs = Calc(c.Replace(("N" & "{" & svalue & "}" & "(" & ss5 & ")"), ((ss3 + ss4) / 2)))


            'التخلص من الأقواس
        ElseIf c.IndexOf("(") <> -1 Then
            Dim stest As String = ""
            Dim stest2 As String = ""
            Dim m As Int16
            For m = c.IndexOf("(") + 1 To deq(c, c.IndexOf("(")) - 1
                stest = stest & c.Chars(m)
            Next
            For m = c.IndexOf("(") To deq(c, c.IndexOf("("))
                stest2 = stest2 & c.Chars(m)
            Next
            rs = Calc(c.Replace(stest2, Calc(stest)))
            Return rs
            'التخلص من المضاريب و التباديل و التوافيق
        ElseIf c.IndexOf("!") <> -1 Then
            Dim test As String = ""
            Dim m As Decimal
            For m = dnums(c, c.IndexOf("!")) To c.IndexOf("!") - 1
                test = test & c.Chars(m)
            Next
            rs = Calc(c.Replace((test & "!"), madroop(test)))
            Return rs
        ElseIf c.IndexOf("p") <> -1 Then
            Dim test1 As String = ""
            Dim test2 As String = ""
            Dim m As Decimal
            For m = dnums(c, c.IndexOf("p")) To c.IndexOf("p") - 1
                test1 = test1 & c.Chars(m)
            Next
            For m = dnum1(c, c.IndexOf("p"), 1) To c.IndexOf("p") + 1 Step -1
                test2 = test2 & c.Chars(m)
            Next
            rs = Calc(c.Replace((test1 & "p" & test2), (madroop(test1) / madroop(test1 - test2))))
        ElseIf c.IndexOf("C") <> -1 Then
            Dim test1 As String = ""
            Dim test2 As String = ""
            Dim m As Decimal
            For m = dnums(c, c.IndexOf("C")) To c.IndexOf("C") - 1
                test1 = test1 & c.Chars(m)
            Next
            For m = dnum1(c, c.IndexOf("C"), 1) To c.IndexOf("C") + 1 Step -1
                test2 = test2 & c.Chars(m)
            Next
            rs = Calc(c.Replace((test1 & "C" & test2), (madroop(test1) / (madroop(test2) * madroop(test1 - test2)))))

            'التخلص من الأسس
        ElseIf c.IndexOf("^") <> -1 Then
            Dim m As Decimal
            Dim xstr As String = ""
            For m = dnums(c, c.IndexOf("^")) To c.IndexOf("^") - 1
                xstr = xstr & c.Chars(m)
            Next
            Dim xstp As String = ""
            For m = c.IndexOf("^") + 1 To dnum1(c, c.IndexOf("^"), 1)
                xstp = xstp & c.Chars(m)

            Next
            rs = Calc(c.Replace((xstr & "^" & xstp), (CDec(xstr) ^ CDec(xstp))))
            ' التخلص من اللوغاريتمات
        ElseIf c.IndexOf("L") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("L") + 1 To dnum1(c, c.IndexOf("L"), 1)
                stest = stest & c.Chars(a)
            Next
            rs = Calc(c.Replace(("L" & stest), (Math.Log10(stest))))
            'التخلص من الدوال المثلثية العكسية
        ElseIf c.IndexOf("S") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("S") + 1 To dnum1(c, c.IndexOf("S"), 1)
                stest = stest & c.Chars(a)
            Next
            Dim rtest As Decimal = stest

            rs = Calc(c.Replace(("S" & stest), (Math.Asin(rtest) * (180 / 3.1415926535897931))))
        ElseIf c.IndexOf("B") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("B") + 1 To dnum1(c, c.IndexOf("B"), 1)
                stest = stest & c.Chars(a)
            Next
            Dim rtest As Decimal = stest

            rs = Calc(c.Replace(("B" & stest), (Math.Acos(rtest) * (180 / 3.1415926535897931))))
        ElseIf c.IndexOf("T") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("T") + 1 To dnum1(c, c.IndexOf("T"), 1)
                stest = stest & c.Chars(a)
            Next
         
            Dim rtest As Decimal = stest

            rs = Calc(c.Replace(("t" & stest), (Math.Tan(rtest) * (180 / 3.1415926535897931))))
            'التخلص من الدوال المثلثية 
        ElseIf c.IndexOf("s") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("s") + 1 To dnum1(c, c.IndexOf("s"), 1)
                stest = stest & c.Chars(a)
            Next
            Dim rtest As Decimal = stest * (3.1415926535897931 / 180)

            rs = Calc(c.Replace(("s" & stest), (Math.Sin(rtest))))
        ElseIf c.IndexOf("c") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("c") + 1 To dnum1(c, c.IndexOf("c"), 1)
                stest = stest & c.Chars(a)
            Next
            Dim rtest As Decimal = stest * (3.1415926535897931 / 180)

            rs = Calc(c.Replace(("c" & stest), (Math.Cos(rtest))))
        ElseIf c.IndexOf("t") <> -1 Then

            Dim stest As String = ""
            Dim a As Integer
            For a = c.IndexOf("t") + 1 To dnum1(c, c.IndexOf("t"), 1)
                stest = stest & c.Chars(a)
            Next
            Dim v As Byte
            If stest = 90 Then
                Return (1 / v)
                Exit Function
            End If
            Dim rtest As Decimal = stest * (3.1415926535897931 / 180)

            rs = Calc(c.Replace(("t" & stest), (Math.Tan(rtest))))
            'اللتخلص من العمليات الحسابية البسيطة
        ElseIf c.IndexOf("*") <> -1 Then
            Dim m As Decimal
            Dim xstr As String = ""
            For m = dnums(c, c.IndexOf("*")) To c.IndexOf("*") - 1
                xstr = xstr & c.Chars(m)
            Next
            Dim xstp As String = ""
            For m = c.IndexOf("*") + 1 To dnum1(c, c.IndexOf("*"), 1)
                xstp = xstp & c.Chars(m)

            Next
            rs = Calc(c.Replace((xstr & "*" & xstp), xstr * xstp))
        ElseIf c.IndexOf("/") <> -1 Then
            Dim m As Decimal
            Dim xstr As String = ""
            For m = dnums(c, c.IndexOf("/")) To c.IndexOf("/") - 1
                xstr = xstr & c.Chars(m)
            Next
            Dim xstp As String = ""
            For m = c.IndexOf("/") + 1 To dnum1(c, c.IndexOf("/"), 1)
                xstp = xstp & c.Chars(m)

            Next
            rs = Calc(c.Replace((xstr & "/" & xstp), xstr / xstp))

        ElseIf c.IndexOf("+") <> -1 Then
            Try
                If c.Chars(c.IndexOf("+") - 1) = "E" Then
                    rs = c
                    Return rs
                    Exit Function

                End If

            Catch ex As Exception

            End Try
            Dim m As Decimal
            Dim xstr As String = ""
            For m = dnums(c, c.IndexOf("+")) To c.IndexOf("+") - 1
                xstr = xstr & c.Chars(m)
            Next
            Dim xstp As String = ""
            For m = c.IndexOf("+") + 1 To dnum1(c, c.IndexOf("+"), 1)
                xstp = xstp & c.Chars(m)

            Next
            rs = Calc(c.Replace((xstr & "+" & xstp), (CDec(xstr) + CDec(xstp))))

        ElseIf c.IndexOf("-") <> -1 And c.IndexOf("E") = -1 Then
            Try
                If c.Chars(c.IndexOf("-") - 1) = "E" Then
                    rs = c
                    Return rs
                    Exit Function

                End If

            Catch ex As Exception

            End Try
            Dim m As Decimal
            Dim xstr As String = "0"
            For m = dnums(c, c.IndexOf("-")) To c.IndexOf("-") - 1
                xstr = xstr & c.Chars(m)
            Next
            Dim xstp As String = ""
            For m = c.IndexOf("-") + 1 To dnum1(c, c.IndexOf("-"), 1)
                xstp = xstp & c.Chars(m)

            Next
            If xstr = "0" Then
                rs = c
                Return rs
            Else
                xstr = xstr.Remove(0, 1)
                rs = Calc(c.Replace((xstr & "-" & xstp), xstr - xstp))
            End If


        Else
            rs = c
            Return rs
        End If

        Return rs
    End Function
    Private Function dnum1(ByVal c As String, ByVal s As Integer, ByVal g As Integer) As Integer
        Dim test As String = c
        test = test.Remove(0, s + g)
        Dim cs As Char
        Dim m As Decimal
        Dim b As Integer = -1
        For Each cs In test

            If cs = "-" And m = 0 Then
                b = b + 1
         
            ElseIf Char.IsDigit(cs) Or cs = "."c Or cs = "E"c Then
                b = b + 1
            ElseIf m <> 0 AndAlso ((cs = "+"c And test.Chars(m - 1) = "E") Or (cs = "-"c And test.Chars(m - 1) = "E")) Then

                b = b + 1



            Else
                Exit For



            End If
            m = m + 1
        Next
        Return (b + g + s)
    End Function
    Private Function dnums(ByVal c As String, ByVal s As Integer) As String
        Dim test As String = c
        Dim m As Integer
        Dim ch As Char
        For m = s - 1 To 0 Step -1
            ch = test.Chars(m)
            If ch = "-"c And m = 0 Then
                Return m
            End If
            If Char.IsDigit(ch) Or ch = "."c Or ch = "E"c Then
                If m = 0 Then
                    Return m
                End If

            ElseIf m <> 0 AndAlso ((ch = "+"c And test.Chars(m - 1) = "E") Or (ch = "-"c And test.Chars(m - 1) = "E")) Then
            
            Else
                Return m + 1
                Exit For
            End If
        Next
    End Function
    Private Function dnum2(ByVal c As String, ByVal s As Integer, ByVal g As Integer) As Integer
        Dim test As String = c
        test = test.Remove(0, s + g)
        Dim cs As Char
        Dim b As Integer = -1
        For Each cs In test
            If Char.IsDigit(cs) Or cs = "."c Or cs = ","c Then
                b = b + 1
                Exit For
            Else
                Exit For



            End If
        Next
        Return (b + g + s)

    End Function

    Private Function madroop(ByVal b As Decimal)
        If b < 0 Then
            Exit Function
        ElseIf b = 0 Then
            Return 1
            Exit Function

        End If
        Dim z As Decimal = 1
        Dim m As Decimal
        For m = b To 1 Step -1
            z = z * m

        Next

        Return z



    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        t1.Text = ""

    End Sub

 
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        t1.Text = t1.Text & "p"
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        a = My.Settings.sta
        b = My.Settings.stb
        c = My.Settings.stc




    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        t1.Text = t1.Text & Button6.Text

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        t1.Text = t1.Text & Button3.Text

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        t1.Text = t1.Text & Button2.Text

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        t1.Text = t1.Text & Button33.Text

    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        t1.Text = t1.Text & Button34.Text

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        t1.Text = t1.Text & Button7.Text

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        t1.Text = t1.Text & Button8.Text

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        t1.Text = t1.Text & Button9.Text

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        t1.Text = t1.Text & Button11.Text

    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        t1.Text = t1.Text & Button29.Text

    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        t1.Text = t1.Text & "("

    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        t1.Text = t1.Text & ")"

    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        t1.Text = t1.Text & Button30.Text
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        t1.Text = t1.Text & Button31.Text
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        t1.Text = t1.Text & Button32.Text
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        t1.Text = t1.Text & Button5.Text
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        t1.Text = t1.Text & Button4.Text
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        t1.Text = t1.Text & Button12.Text
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        t1.Text = t1.Text & Button10.Text
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        t1.Text = t1.Text & "C"
    End Sub

    Private Sub Button27_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        t1.Text = t1.Text & "p"
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        t1.Text = t1.Text & Button25.Text
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        t1.Text = t1.Text & Button21.Text
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
              t1.Text = t1.Text & Button20.Text
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        t1.Text = t1.Text & Button19.Text
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        t1.Text = t1.Text & Button22.Text
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        t1.Text = t1.Text & Button23.Text
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        t1.Text = t1.Text & Button14.Text
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        t1.Text = t1.Text & Button15.Text
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        t1.Text = t1.Text & Button17.Text
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        t1.Text = t1.Text & Button16.Text
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        t1.Text = t1.Text & Button24.Text
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        t1.Text = t1.Text & Button18.Text
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        t1.Text = t1.Text & Button28.Text
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        Try

            t1.Text = t1.Text.Remove(t1.Text.Length - 1)
        Catch
        End Try

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        t1.Text = ""
        tn1.Text = ""

    End Sub

    Private Sub Button13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Dim ss As Decimal = Calc(adap(t1.Text))
            tn1.Text = getter(ss)

            tn1.Tag = ss

        Catch
            tn1.Text = "خطأ!"

        End Try
        Dim v As String = My.Settings.hist
        v = v & vbCrLf & "-----------" & CStr(Now) & "-----------" & vbCrLf & t1.Text & vbCrLf & "الناتج:  " & tn1.Text & vbCrLf & "الناتج بالكامل:  " & tn1.Tag

        My.Settings.hist = v

    End Sub
    Function adap(ByVal ce As String)

        Dim bcalc As String = ""
        Dim m As Decimal
        bcalc = ce
        bcalc = bcalc.Replace("ln(", "logg(e,")
        bcalc = bcalc.Replace("π", "3.14159265358979323846")
        bcalc = bcalc.Replace("e", CStr("2.71828182846"))
        Dim s As Byte = 0
        Dim test As String = ""
        Dim vtest As String
        Do While s = 0
            Try
                If bcalc.IndexOf("√") = -1 Then
                    Exit Do
                End If
                For m = bcalc.IndexOf("(", bcalc.IndexOf("√")) + 1 To deq(bcalc, bcalc.IndexOf("(", bcalc.IndexOf("√"))) - 1
                    test = test & bcalc.Chars(m)

                Next
            Catch ex As Exception
                s = 1
            End Try
            bcalc = bcalc.Replace("√" & "(" & test & ")", "(" & test & ")^.5")
        Loop

        bcalc = bcalc.Replace("log", "L")

        Do While s = 0
            If bcalc.IndexOf("logg(") = -1 Then
                Exit Do
            End If
            Try
                Dim v As String
                v = CStr(bcalc.IndexOf("logg("))
                Dim ss As String
                ss = CStr(bcalc.IndexOf(",", bcalc.IndexOf("logg(")))
                For m = v + 4 To ss - 1
                    test = test & bcalc.Chars(m)
                    vtest = Calc(adap(test))

                Next
                Dim vv As String = ""
                vv = CStr(bcalc.IndexOf(",", CInt(v)))
                Dim test2 As String = ""
                Dim vtest2 As String = ""

                For m = vv + 1 To deq(bcalc, bcalc.IndexOf("(", CInt(v)))
                    test2 = test2 & bcalc.IndexOf(m)


                Next
                vtest = Calc(adap(test2))

                bcalc.Replace(("logg(" & test & "," & test2), ("(" & "L" & vtest2 & "/" & "L" & vtest & ")"))

            Catch
                s = 1
            End Try
        Loop
        bcalc = bcalc.Replace("x=", "")
        bcalc = bcalc.Replace("y=", "")
        bcalc = bcalc.Replace(" ", "")
        bcalc = bcalc.Replace("tan-1", "T")
        bcalc = bcalc.Replace("sin-1", "S")
        bcalc = bcalc.Replace("cos-1", "B")
        bcalc = bcalc.Replace("tan", "t")
        bcalc = bcalc.Replace("sin", "s")
        bcalc = bcalc.Replace("cos", "c")
        bcalc = bcalc.Replace("%", "*.01")

        bcalc = bcalc.Replace("×", "*")
        bcalc = bcalc.Replace("÷", "/")
        bcalc = bcalc.Replace("A", CStr("(" & a & ")"))
        bcalc = bcalc.Replace("B", CStr("(" & b & ")"))
        bcalc = bcalc.Replace("D", CStr("(" & c & ")"))
        bcalc = bcalc.Replace("lim", "N")
        bcalc = bcalc.Replace("∑", "M")
        bcalc = bcalc.Replace("C", "C")
        bcalc = bcalc.Replace("p", "p")
        bcalc = bcalc.Replace(")(", ")*(")
        bcalc = bcalc.Replace("ans", tn1.Tag)
        bcalc = bcalc.Replace("0(", "0*(")
        bcalc = bcalc.Replace("1(", "1*(")

        bcalc = bcalc.Replace("2(", "2*(")

        bcalc = bcalc.Replace("3(", "3*(")

        bcalc = bcalc.Replace("4(", "4*(")

        bcalc = bcalc.Replace("5(", "5*(")

        bcalc = bcalc.Replace("6(", "6*(")

        bcalc = bcalc.Replace("7(", "7*(")
        bcalc = bcalc.Replace("8(", "8*(")
        bcalc = bcalc.Replace("9(", "9*(")
        bcalc = bcalc.Replace("-(", "-1*(")







        Return bcalc

    End Function

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        tn1.Text = tn1.Tag

    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        Try
            Dim v As String = InputBox("أكتب متغير!")
            Select Case v.ToUpper

                Case "A"
                    a = CDec(tn1.Tag)
                    My.Settings.sta = a
                Case "B"
                    b = CDec(tn1.Tag)
                    My.Settings.stb = b
                Case "D"
                    c = CDec(tn1.Tag)
                    My.Settings.stc = c
            End Select
        Catch
        End Try
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        Form2.Show()
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        Form3.Show()
        Form3.TextBox1.Text = My.Settings.hist


    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        t1.Text = t1.Text & "ans"

    End Sub
    Private Function getter(ByVal c As Decimal)
        Thread.CurrentThread.Priority = ThreadPriority.Highest
        Dim m As Decimal
        Dim test As Decimal
        Dim val As String = c
        For m = 1 To 10
            test = c

            test = Math.Round((test * m), 9)
            If Math.Round(test, 0) = test Then
                If m <> 1 Then
                    Dim test2 As String = CStr(test)
                    If test2.IndexOf(".") <> -1 Then
                        test2 = test2.Remove(test2.IndexOf("."), test2.Length - test2.IndexOf("."))
                    End If

                    val = CStr(CStr(test2) & " / " & m)
                End If
                Exit For

            End If
        Next
        Try
            If CDec(val) = c Then
                Return Math.Round(c, 9)
            Else
                Return val
            End If
        Catch
            Return val
        End Try

    End Function

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        Form4.Show()

    End Sub

    Private Function Calc3(ByVal rtest2 As String) As String
        Return Calc(rtest2)

    End Function

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        t1.Text = t1.Text & Button46.Text
    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
                t1.Text = t1.Text & Button45.Text
    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        t1.Text = t1.Text & Button44.Text
    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        t1.Text = t1.Text & Button47.Text
    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        t1.Text = t1.Text & Button48.Text
    End Sub
End Class







