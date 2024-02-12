Imports System.Text.RegularExpressions

Public Class Robot
    Public Const TableSize As Integer = 4
    Public MsgError As String = "Please Input PLACE x,y,f Command"
    Public Success As Boolean
    Public XPosition As Integer = -1
    Public YPosition As Integer = -1
    Public Facing As String = ""
    Public Sub PLACE(input As String)
        Dim x As Integer = -1
        Dim y As Integer = -1
        Dim f As String = ""
        Dim inputArray() As String = input.Split(",")
        MsgError = "Please Input PLACE x,y,f Command"
        ResetPlace()
        If inputArray.Length >= 3 Then

            Dim tmpXPosition As String = Mid(inputArray(0), 7, inputArray(0).Length)
            Dim tmpYPosition As String = inputArray(1)

            If Not IsLetter(tmpXPosition) AndAlso tmpXPosition.Length = 1 Then
                x = Val(tmpXPosition)
            Else
                MsgError = "Input X Position Error"
            End If

            If Not IsLetter(tmpYPosition) AndAlso inputArray(1).Length = 1 Then
                y = Val(inputArray(1))
            Else
                MsgError = "Input Y Position Error"
            End If

            f = inputArray(2)
            If Not ValidateFacing(f) Then
                MsgError = "Input Facing Error"
            End If
        End If

        If ValidatePosition(x, y) AndAlso ValidateFacing(f) Then
            XPosition = x
            YPosition = y
            Facing = f
            Success = True
        Else
            MsgError += " Not Found The Toy Robot"
            Success = False
            Console.WriteLine($"Output: {MsgError}")
        End If

    End Sub
    Public Sub MOVE()
        Select Case Facing
            Case "NORTH"
                If ValidatePosition(XPosition, YPosition + 1) Then
                    YPosition += 1
                End If
            Case "SOUTH"
                If ValidatePosition(XPosition, YPosition - 1) Then
                    YPosition -= 1
                End If
            Case "EAST"
                If ValidatePosition(XPosition + 1, YPosition) Then
                    XPosition += 1
                End If
            Case "WEST"
                If ValidatePosition(XPosition - 1, YPosition) Then
                    XPosition -= 1
                End If
            Case Else
                Console.WriteLine($"Output: Error can not MOVE")
        End Select
    End Sub
    Public Sub LEFT()
        Select Case Facing
            Case "NORTH"
                Facing = "WEST"
            Case "SOUTH"
                Facing = "EAST"
            Case "EAST"
                Facing = "NORTH"
            Case "WEST"
                Facing = "SOUTH"
            Case Else
                Console.WriteLine($"Output: Error can not LEFT")
        End Select
    End Sub
    Public Sub RIGHT()
        Select Case Facing
            Case "NORTH"
                Facing = "EAST"
            Case "SOUTH"
                Facing = "WEST"
            Case "EAST"
                Facing = "SOUTH"
            Case "WEST"
                Facing = "NORTH"
            Case Else
                Console.WriteLine($"Output: Error can not RIGHT")
        End Select
    End Sub
    Public Sub REPORT()
        If ValidateFacing(Facing) Then
            Console.WriteLine($"Output: {XPosition},{YPosition},{Facing}")
        Else
            Console.WriteLine($"Output: Error can not show REPORT")
        End If
    End Sub
    Private Function ValidatePosition(x As Integer, y As Integer) As Boolean
        If x >= 0 AndAlso x <= TableSize AndAlso
            y >= 0 AndAlso y <= TableSize Then
            Return True
        Else

            Return False
        End If
    End Function
    Private Function IsLetter(input As String) As Boolean
        Dim pattern As String = "\D"
        Dim regex As New Regex(pattern)
        If regex.IsMatch(input) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function ValidateFacing(f As String) As Boolean
        If f = "NORTH" OrElse f = "SOUTH" OrElse f = "EAST" OrElse f = "WEST" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ResetPlace()
        XPosition = -1
        YPosition = -1
        Facing = ""
    End Sub
End Class
