Imports System.IO

Module Program
    Sub Main()
        Dim robot As New Robot()
#Region "Input From File"
        Dim inputFile As String = "D:\SS&C\Robot\Robot\input.txt"
        If File.Exists(inputFile) Then
            Dim lines() As String = File.ReadAllLines(inputFile)
            For Each line As String In lines
                Select Case Left(line, 6).Trim
                    Case "PLACE"
                        robot.PLACE(line)
                    Case "MOVE"
                        robot.MOVE()
                    Case "LEFT"
                        robot.LEFT()
                    Case "RIGHT"
                        robot.RIGHT()
                    Case "REPORT"
                        robot.REPORT()
                    Case String.Empty

                    Case Else
                        Console.WriteLine($"Output: Error Invalid command. {Left(line, 6)}")
                End Select
            Next
        Else
            Console.WriteLine("Output: Error Input file not found: " & inputFile)
        End If
#End Region

#Region "Input From cmd"
        'Dim input As String
        'robot = New Robot()
        'Console.WriteLine("Input (PLACE X,Y,F, MOVE, LEFT, RIGHT, REPORT AND EXIT):")
        'Do
        '    input = Console.ReadLine
        '    input = input
        '    Select Case Left(input, 6).Trim
        '        Case "PLACE"
        '            robot.PLACE(input)
        '        Case "MOVE"
        '            robot.MOVE()
        '        Case "LEFT"
        '            robot.LEFT()
        '        Case "RIGHT"
        '            robot.RIGHT()
        '        Case "REPORT"
        '            robot.REPORT()
        '        Case "EXIT"
        '            Exit Do
        '        Case Else
        '            Console.WriteLine($"Invalid command. {Left(input, 6)}")
        '    End Select
        'Loop
#End Region

    End Sub
End Module
