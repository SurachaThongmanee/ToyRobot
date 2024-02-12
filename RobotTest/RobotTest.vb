Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class RobotTests
    <TestMethod>
    Public Sub PlaceSuccess()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 1,2,NORTH")
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(1, robot.XPosition)
        Assert.AreEqual(2, robot.YPosition)
        Assert.AreEqual("NORTH", robot.Facing)
    End Sub

    <TestMethod>
    Public Sub PlaceFailure()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 5,5,NORTH")
        Assert.IsFalse(robot.Success)
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.AreEqual("", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveSuccess()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 1,2,NORTH")
        robot.MOVE()
        Assert.AreEqual(1, robot.XPosition)
        Assert.AreEqual(3, robot.YPosition)
        Assert.AreEqual("NORTH", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveFailure()
        Dim robot As New Robot.Robot()
        robot.MOVE()
        Assert.IsFalse(robot.Success)
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableNorth()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(4, robot.YPosition)
        Assert.AreEqual("NORTH", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableSouth()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,SOUTH")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.AreEqual("SOUTH", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableEast()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,EAST")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(4, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.AreEqual("EAST", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableWest()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,WEST")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.AreEqual("WEST", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableAndLeft()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,EAST")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.LEFT()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(4, robot.XPosition)
        Assert.AreEqual(1, robot.YPosition)
        Assert.AreEqual("NORTH", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub MoveOverSizeTableAndRight()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.MOVE()
        robot.RIGHT()
        robot.MOVE()
        Assert.IsTrue(robot.Success)
        Assert.AreEqual(1, robot.XPosition)
        Assert.AreEqual(4, robot.YPosition)
        Assert.AreEqual("EAST", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub LeftSuccess()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.LEFT()
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.AreEqual("WEST", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub LeftFailure()
        Dim robot As New Robot.Robot()
        robot.LEFT()
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
    <TestMethod>
    Public Sub RightSuccess()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.RIGHT()
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.AreEqual("EAST", robot.Facing)
    End Sub
    <TestMethod>
    Public Sub RightFailure()
        Dim robot As New Robot.Robot()
        robot.RIGHT()
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
    <TestMethod>
    Public Sub InputFailure()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE   -120 ,-1,NRTH")
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
    <TestMethod>
    Public Sub InputOverCommandFailure()
        Dim robot As New Robot.Robot()
        robot.PLACE("ASDFGASD")
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
    <TestMethod>
    Public Sub IgnoreCommandPlaceFailure()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 5,5,NRTH")
        robot.MOVE()
        robot.LEFT()
        robot.RIGHT()
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
    <TestMethod>
    Public Sub PlaceDuplicateSuccess()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.MOVE()
        robot.MOVE()
        robot.LEFT()
        robot.RIGHT()
        robot.PLACE("PLACE 0,0,NORTH")
        Assert.AreEqual(0, robot.XPosition)
        Assert.AreEqual(0, robot.YPosition)
        Assert.IsTrue(robot.Success)
    End Sub
    <TestMethod>
    Public Sub PlaceDuplicateFailure()
        Dim robot As New Robot.Robot()
        robot.PLACE("PLACE 0,0,NORTH")
        robot.MOVE()
        robot.LEFT()
        robot.RIGHT()
        robot.PLACE("PLACE 5,5,NORTH")
        Assert.AreEqual(-1, robot.XPosition)
        Assert.AreEqual(-1, robot.YPosition)
        Assert.IsFalse(robot.Success)
    End Sub
End Class