'Name Adam Ebel
Imports System
Imports System.IO
Imports System.Text

Public Class Form1
    Dim isSpaceUsed(7, 7) As Boolean ' makes the internal chess board that tells if a spot is taken or not
    Public IsImgDragging As Boolean = False
    Public IsClick As Boolean = False
    Public StartPoint, FirstPoint, LastPoint As Point

    Function isInteger(ByVal testCase As String) As Boolean
        'checks if a value from a string is an int
        Dim isNumeric As Boolean = False
        If Integer.TryParse(testCase, Nothing) Or testCase = Nothing Then
            Return isNumeric = True
        Else
            Return isNumeric = False
        End If
    End Function

    Function getRandomValue(ByVal lowerBound As Integer, ByVal upperBound As Integer) As Integer
        'generates a random value between lower and upper bound
        Static Generator As Random = New Random()
        Return Generator.Next(lowerBound, upperBound)
    End Function

    Private Sub resetValues()
        'resets values on the reset button's click
        Dim isSpaceEmpty(7, 7) As Boolean
        Dim IsImgDragging As Boolean = False
        Dim IsClick As Boolean = False
        'resets the lable for the pieces
        labelOfKingW.Text = "1"
        labelOfKingB.Text = "1"
        labelOfQueenW.Text = "1"
        labelOfQueenB.Text = "1"
        labelOfKnightW.Text = "2"
        labelOfKnightB.Text = "2"
        labelOfBishopW.Text = "2"
        labelOfBishopB.Text = "2"
        labelOfRookW.Text = "2"
        labelOfRookB.Text = "2"
        labelOfPawnW.Text = "8"
        labelOfPawnB.Text = "8"

    End Sub

    Private Sub buttonOfQuit_Click(sender As Object, e As EventArgs) Handles buttonOfQuit.Click
        'quits the application
        Application.Exit()
    End Sub

    Private Sub TableLayoutPanel1_CellPaint(sender As Object, e As TableLayoutCellPaintEventArgs) Handles TableLayoutPanel1.CellPaint
        'creates the visual chestboard by alternating the colors on the board to create a visiualy usable play board
        Dim tableSpace As Brush
        If ((e.Column + e.Row) Mod 2 = 1) Then
            tableSpace = New Drawing.SolidBrush(Color.FromArgb(105, 145, 172))
            e.Graphics.FillRectangle(tableSpace, e.CellBounds)
        Else
            tableSpace = New Drawing.SolidBrush(Color.FromArgb(241, 170, 144))
            e.Graphics.FillRectangle(tableSpace, e.CellBounds)
        End If
    End Sub

    Private Sub GenericChessPiece_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles imgBoxOfKingW.MouseDown,
        imgBoxOfKingB.MouseDown, imgBoxOfQueenW.MouseDown, imgBoxOfQueenB.MouseDown, imgBoxOfKnightW.MouseDown, imgBoxOfKnightB.MouseDown, imgBoxOfBishopW.MouseDown,
        imgBoxOfBishopB.MouseDown, imgBoxOfRookW.MouseDown, imgBoxOfRookB.MouseDown, imgBoxOfPawnW.MouseDown, imgBoxOfPawnB.MouseDown
        'handles the event for letting go of a chess piece
        Dim piece As PictureBox = DirectCast(sender, PictureBox)
        IsImgDragging = True
        StartPoint = e.Location
        If sender.Parent.Name.Equals(GroupBox1.Name) Then
            GroupBox1.Controls.Add(copier(piece))
        ElseIf sender.Parent.Name.Equals(GroupBox2.Name) Then
            GroupBox2.Controls.Add(copier(piece))
        Else
            Dim temp = TableLayoutPanel1.GetCellPosition(sender)
            createPictureBox(temp.Row, temp.Column)
        End If
        'These two lines are necessary so the control doesn't just sink under everything when it leaves its group box.
        'Ideally, I should have a way to reset its parent to either its group box Or the table when I let go
        sender.Parent = Me
        sender.BringToFront()
    End Sub

    Private Sub GenericChessPiece_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgBoxOfKingW.MouseMove,
        imgBoxOfKingB.MouseMove, imgBoxOfQueenW.MouseMove, imgBoxOfQueenB.MouseMove, imgBoxOfKnightW.MouseMove, imgBoxOfKnightB.MouseMove, imgBoxOfBishopW.MouseMove,
        imgBoxOfBishopB.MouseMove, imgBoxOfRookW.MouseMove, imgBoxOfRookB.MouseMove, imgBoxOfPawnW.MouseMove, imgBoxOfPawnB.MouseMove
        'Handles the event for moving a chess piece
        If IsImgDragging Then
            sender.Location = New Point(sender.Location.X + e.X - StartPoint.X, sender.Location.Y + e.Y - StartPoint.Y)
        End If
    End Sub

    Private Sub GenericChessPiece_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgBoxOfKingW.MouseUp,
    imgBoxOfKingB.MouseUp, imgBoxOfQueenW.MouseUp, imgBoxOfQueenB.MouseUp, imgBoxOfKnightW.MouseUp, imgBoxOfKnightB.MouseUp, imgBoxOfBishopW.MouseUp,
    imgBoxOfBishopB.MouseUp, imgBoxOfRookW.MouseUp, imgBoxOfRookB.MouseUp, imgBoxOfPawnW.MouseUp, imgBoxOfPawnB.MouseUp
        'Handles the event for letting go of the chess piece
        Dim piece = DirectCast(sender, PictureBox)
        IsImgDragging = False
        Dim correctedLocation = New Point(piece.Location.X - GroupBox3.Location.X, piece.Location.Y - GroupBox3.Location.Y)

        piece.Enabled = False 'Temporarily disable the picture box so that it isn't included in the child search.
        Dim belowPiece As Control = TableLayoutPanel1.GetChildAtPoint(correctedLocation, GetChildAtPointSkip.Disabled) 'Look for any child control that isn't disabled.
        piece.Enabled = True 'Re-enable the picture box.

        If belowPiece Is Nothing OrElse belowPiece.GetType() IsNot GetType(PictureBox) Then
            Return 'Do not continue if no child was found below the picture box, or if the child is not a button.
        End If

        Dim position As TableLayoutPanelCellPosition = TableLayoutPanel1.GetCellPosition(belowPiece)
        TableLayoutPanel1.Controls.Remove(belowPiece)
        TableLayoutPanel1.Controls.Add(piece, position.Column, position.Row)
        isSpaceUsed(position.Column, position.Row) = True

        For Each boardSpace In TableLayoutPanel1.Controls.OfType(Of PictureBox)() 'OfType() to only look for pictureBoxes
            If piece.Bounds.IntersectsWith(boardSpace.Bounds) Then
                piece.BackColor = Color.FromKnownColor(KnownColor.Transparent)
            End If
        Next

        Refresh()
    End Sub

    Private Sub boardSpace_MouseEnter(sender As Object, e As EventArgs)
        ' it takes the transparent color on the board and changes it to lightgreen when the mouse leaves the space
        Dim board = DirectCast(sender, PictureBox)

        board.BackColor = Color.LightGreen 'The color one will see that will tell the user where it is going to get placed or if it can be
    End Sub

    Private Sub boardSpace_MouseLeave(sender As Object, e As EventArgs)
        'it takes the green color on the board and changes it to transparent when the mouse leaves the space
        Dim board = DirectCast(sender, PictureBox)

        board.BackColor = Color.Transparent 'hides the color again
    End Sub

    Function alphabet(ByVal columnNumber As Integer)
        'selects the column ID for a typical chessboard
        Select Case columnNumber
            Case 0
                Return "A"
            Case 1
                Return "B"
            Case 2
                Return "C"
            Case 3
                Return "D"
            Case 4
                Return "E"
            Case 5
                Return "F"
            Case 6
                Return "G"
            Case Else
                Return "H"
        End Select
    End Function

    Function formatContent() As String
        'formats the output file in terms of <Color Code><Piece Abbreviation> <column ID><rowNumber> for every piece
        Dim content As String = ""
        For rowNumber As Integer = 0 To TableLayoutPanel1.RowCount - 1
            For column As Integer = 0 To TableLayoutPanel1.ColumnCount - 1
                If isSpaceUsed(rowNumber, column) = True Then 'checks if there is a piece set at a position on the board
                    Dim cellPosition As Control = TableLayoutPanel1.GetControlFromPosition(rowNumber, column)
                    Dim columnID = alphabet(column) 'Gets the column ID as a letter
                    content = content + vbCrLf + cellPosition.Tag + " " + columnID + rowNumber.ToString() 'formats the line to be writen 
                End If
            Next
        Next
        Return content
    End Function

    Private Sub fileManagement()
        'creates a new file to save the spaces that the chess pieces are on
        'deletes the old save file
        Dim Ifile As New FileInfo("output.txt")
        Dim filecontent As String
        filecontent = formatContent() 'gets the data to be written to the file
        Try
            If Ifile.Exists Then
                Ifile.Delete() ' Deletes the previous saved output
            End If
            Using Sfile As FileStream = Ifile.Create()
                Dim text As [Byte]() = New UTF8Encoding(True).GetBytes(filecontent)
                Sfile.Write(text, 0, text.Length())
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub buttonOfOutput_Click(sender As Object, e As EventArgs) Handles buttonOfOutput.Click
        fileManagement() 'on button click go to manage files
    End Sub

    Private Sub setUpPiece(ByVal isTurnOfWhite As Boolean, ByVal whichPiece As Integer, ByVal coordX As Integer, ByVal coordY As Integer)
        isSpaceUsed(coordX, coordY) = True 'makes note of where a piece is, does not matter which piece
        Dim belowPiece As Control = TableLayoutPanel1.GetControlFromPosition(coordX, coordY)
        Dim cellPosition As TableLayoutPanelCellPosition = TableLayoutPanel1.GetCellPosition(belowPiece)
        Dim pieceToAdd As PictureBox

        Select Case whichPiece
    'It adds either the white or black variant of the picture box depending on whose turn it is
            Case 0, 16
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfKingW, imgBoxOfKingB) 'if the piece is the king
            Case 1, 17
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfQueenW, imgBoxOfQueenB) 'if the piece is the queen
            Case 2, 3, 18, 19
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfKnightW, imgBoxOfKnightB) 'if the piece is a knight
            Case 4, 5, 20, 21
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfBishopW, imgBoxOfBishopB) 'if the piece is a bishop
            Case 6, 7, 22, 23
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfRookW, imgBoxOfRookB) 'if the piece is a rook
            Case Else
                pieceToAdd = If(isTurnOfWhite = True, imgBoxOfPawnW, imgBoxOfPawnB) 'if the piece is a pawn
        End Select

        pieceToAdd.BackColor = Color.Transparent 'Only effects the background not the image itself
        TableLayoutPanel1.Controls.Remove(belowPiece)
        TableLayoutPanel1.Controls.Add(copier(pieceToAdd), cellPosition.Column, cellPosition.Row)
    End Sub


    Function checkAvailability(ByVal coordX As Integer, ByVal coordY As Integer)
        'checks if there is already another pice on the board
        If isSpaceUsed(coordX, coordY) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub buttonOfRNG_Click(sender As Object, e As EventArgs) Handles buttonOfRNG.Click
        buttonOfReset_Click(sender, e)
        Dim isSpaceUsed(7, 7) As Boolean 'resets boolean array for every button press
        Dim check As Boolean
        Dim isWhiteTurn As Boolean = True 'white starts choosing first
        For whichPiece As Integer = 0 To 31
            Dim coordX As Integer
            Dim coordY As Integer
            Do
                coordX = getRandomValue(0, 8) ' gets a value for an x coordinate
                coordY = getRandomValue(0, 8) ' gets a value for a y coordinate
                check = checkAvailability(coordX, coordY) 'Checks the availibility on the board
            Loop While check = True
            setUpPiece(isWhiteTurn, whichPiece, coordX, coordY)

            If whichPiece = 15 Then ' when white has picked its 16 spots
                isWhiteTurn = False ' black's turn to place its pieces
            End If
        Next
    End Sub

    Public Sub createPictureBox(ByVal row As Integer, ByVal column As Integer)
        Dim boardSpace As New PictureBox
        With boardSpace
            .BackColor = Color.Transparent 'The color one will see that will tell the user where it is going to get placed or if it can be
            .Anchor = AnchorStyles.Bottom AndAlso AnchorStyles.Top AndAlso AnchorStyles.Left AndAlso AnchorStyles.Right
        End With

        'Add handelers to highlight where you can place a piece
        AddHandler boardSpace.MouseEnter, AddressOf boardSpace_MouseEnter
        AddHandler boardSpace.MouseLeave, AddressOf boardSpace_MouseLeave

        TableLayoutPanel1.Controls.Add(boardSpace, column, row)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Function on load creates the picture boxes to be refrenced many times
        For row As Integer = 0 To TableLayoutPanel1.RowCount - 1
            For column As Integer = 0 To TableLayoutPanel1.ColumnCount - 1
                createPictureBox(row, column)
            Next
        Next
    End Sub

    Private Sub resizeTable()
        TableLayoutPanel1.Controls.Clear()
        TableLayoutPanel1.RowStyles.Clear()
        TableLayoutPanel1.ColumnStyles.Clear()
        TableLayoutPanel1.RowCount = 8
        TableLayoutPanel1.ColumnCount = 8

        For i As Integer = 0 To TableLayoutPanel1.RowCount
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        Next
    End Sub

    Private Sub buttonOfReset_Click(sender As Object, e As EventArgs) Handles buttonOfReset.Click
        'resets the applicaiton
        resetValues()
        resizeTable()
        Form1_Load(sender, e)
    End Sub

    Function alterCountOfPiece(ByVal onePiece As PictureBox)
        'a count down for the amount of pieces that can be allowed on the board at once
        Select Case onePiece.Tag
            Case imgBoxOfKingW.Tag 'checks if the White King label is going to be effected 
                If Convert.ToInt32(labelOfKingW.Text) > 0 Then
                    labelOfKingW.Text = Convert.ToInt32(labelOfKingW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfQueenW.Tag 'checks if the White Queen label is going to be effected
                If Convert.ToInt32(labelOfQueenW.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfQueenW.Text = Convert.ToInt32(labelOfQueenW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfKnightW.Tag 'checks if the White Knight label is going to be effected
                If Convert.ToInt32(labelOfKnightW.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfKnightW.Text = Convert.ToInt32(labelOfKnightW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfBishopW.Tag 'checks if the White Bishop label is going to be effected
                If Convert.ToInt32(labelOfBishopW.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfBishopW.Text = Convert.ToInt32(labelOfBishopW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfRookW.Tag 'checks if the White Rook label is going to be effected
                If Convert.ToInt32(labelOfRookW.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfRookW.Text = Convert.ToInt32(labelOfRookW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfPawnW.Tag 'checks if the White Pawn label is going to be effected
                If Convert.ToInt32(labelOfPawnW.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfPawnW.Text = Convert.ToInt32(labelOfPawnW.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfKingB.Tag 'checks if the Black King label is going to be effected
                If Convert.ToInt32(labelOfKingB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfKingB.Text = Convert.ToInt32(labelOfKingB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfQueenB.Tag 'checks if the Black Queen label is going to be effected
                If Convert.ToInt32(labelOfQueenB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfQueenB.Text = Convert.ToInt32(labelOfQueenB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfKnightB.Tag 'checks if the Black Knight label is going to be effected
                If Convert.ToInt32(labelOfKnightB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfKnightB.Text = Convert.ToInt32(labelOfKnightB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfBishopB.Tag 'checks if the Black Bishop label is going to be effected
                If Convert.ToInt32(labelOfBishopB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfBishopB.Text = Convert.ToInt32(labelOfBishopB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case imgBoxOfRookB.Tag 'checks if the Black Rook label is going to be effected
                If Convert.ToInt32(labelOfRookB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfRookB.Text = Convert.ToInt32(labelOfRookB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
            Case Else 'checks if the Black Pawn label is going to be effected
                If Convert.ToInt32(labelOfPawnB.Text) > 0 Then 'once 0 no more pieces can be added
                    labelOfPawnB.Text = Convert.ToInt32(labelOfPawnB.Text) - 1 'Decrements the count of pieces left
                    Return True
                Else
                    Return False
                End If
        End Select
    End Function

    Function copier(ByVal onePiece As PictureBox)
        'Copies the piece that was picked up.
        If alterCountOfPiece(onePiece) = True Then
            Dim retPictureBox = New PictureBox
            With retPictureBox
                .Visible = True 'just an attempt to see the picture
                .BackColor = Color.Transparent
                .Cursor = onePiece.Cursor
                .Name = onePiece.Name 'sets the copy name to the original name
                .Anchor = onePiece.Anchor  'sets the copy to the original anchor
                .Image = New Bitmap(onePiece.Image) 'cets the copy's image to the original
                .SizeMode = PictureBoxSizeMode.StretchImage
                .Tag = onePiece.Tag 'Sets the copy tag to the original
                .BringToFront() 'brings thepiece to front, just in case
                .Location = onePiece.Location 'sets the copy to the original's location
                .SetBounds(onePiece.Location.X, onePiece.Location.Y, onePiece.Width, onePiece.Height) 'sets the copy to the original's bounds
            End With

            'Gives the copy pf the piece all the handelers of the original
            'Alows the copied piece to be picked up
            AddHandler retPictureBox.MouseDown, AddressOf GenericChessPiece_MouseDown
            AddHandler retPictureBox.MouseMove, AddressOf GenericChessPiece_MouseMove
            AddHandler retPictureBox.MouseUp, AddressOf GenericChessPiece_MouseUp

            Return retPictureBox
        End If
    End Function

End Class