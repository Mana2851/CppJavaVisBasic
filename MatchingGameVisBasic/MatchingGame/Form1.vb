
'Adam Ebel
Public Class Form1

    'Defualt on start up
    Dim cardBack As Color = Color.Olive
    Dim newGameCardBack As Color
    Dim newGameImgBack As Image
    Dim cardImg As Image
    Dim counter As Integer = 0
    Dim savedCard As Button
    Dim strFileName As String
    Dim isPlayersTurn As Boolean = True
    Dim maxNumOfPairs As Integer
    Dim flipper As CardFlipper


    'Saved over new game
    Const NUM_OF_COLORS As Integer = 4
    Dim newGameBlueCount As Integer
    Dim newGameRedCount As Integer
    Dim newGameGreenCount As Integer
    Dim newGameYellowCount As Integer
    Dim isGeneratedRandomly As Boolean = True

    ' --- UTILITY FUNCTIONS ---

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
        Static Generator As Random = New Random()

        Return Generator.Next(lowerBound, upperBound) 'generates a random value between lower and upper bound
    End Function

    Function getRandomExistingCell() As Point
        Dim cellPoint As Point
        Do
            cellPoint.X = getRandomValue(0, cardSpaces.RowCount)
            cellPoint.Y = getRandomValue(0, cardSpaces.ColumnCount)
        Loop While cardSpaces.GetControlFromPosition(cellPoint.Y, cellPoint.X) Is Nothing
        Return cellPoint
    End Function

    Function getRandomEmptyCell() As Point
        Dim cellPoint As Point
        Do
            cellPoint.X = getRandomValue(0, cardSpaces.RowCount)
            cellPoint.Y = getRandomValue(0, cardSpaces.ColumnCount)
        Loop Until cardSpaces.GetControlFromPosition(cellPoint.Y, cellPoint.X) Is Nothing
        Return cellPoint
    End Function

    ' --- UTILITY END ---

    Private Sub blueTextBox_TextChanged(sender As Object, e As EventArgs) Handles blueTextBox.TextChanged
        Dim testText As Boolean
        testText = isInteger(blueTextBox.Text)
        If testText = True Then
            MsgBox("Insert organic numbers only, please.", 0, "Whole Numbers Market Inc") 'yes its a joke
        End If
    End Sub

    Private Sub redTextBox_TextChanged(sender As Object, e As EventArgs) Handles redTextBox.TextChanged
        Dim testText As Boolean
        testText = isInteger(redTextBox.Text)
        If testText = True Then
            MsgBox("Insert organic numbers only, please.", 0, "Whole Numbers Market Inc") 'yes its a joke
        End If
    End Sub

    Private Sub greenTextBox_TextChanged(sender As Object, e As EventArgs) Handles greenTextBox.TextChanged
        Dim testText As Boolean
        testText = isInteger(greenTextBox.Text)
        If testText = True Then
            MsgBox("Insert organic numbers only, please.", 0, "Whole Numbers Market Inc") 'yes its a joke
        End If
    End Sub

    Private Sub yellowTextBox_TextChanged(sender As Object, e As EventArgs) Handles yellowTextBox.TextChanged
        Dim testText As Boolean
        testText = isInteger(yellowTextBox.Text)
        If testText = True Then
            MsgBox("Insert organic numbers only, please.", 0, "Whole Numbers Market Inc") 'yes its a joke
        End If
    End Sub

    Private Sub oliveRadio_CheckedChanged(sender As Object, e As EventArgs) Handles oliveRadio.CheckedChanged
        newGameImgBack = Nothing
        newGameCardBack = Color.Olive
    End Sub

    Private Sub grayRadio_CheckedChanged(sender As Object, e As EventArgs) Handles grayRadio.CheckedChanged
        newGameImgBack = Nothing
        newGameCardBack = Color.Gray
    End Sub

    Private Sub imgSelectWindow()
        Dim browseForImg As OpenFileDialog = New OpenFileDialog()
        browseForImg.Title = "Browse for an image"
        browseForImg.InitialDirectory = "C:\Users\" + Environment.UserName + "\Pictures"
        browseForImg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        browseForImg.FilterIndex = 2
        browseForImg.RestoreDirectory = True
        Dim result As DialogResult = browseForImg.ShowDialog()
        If result = DialogResult.OK Then
            strFileName = browseForImg.FileName
        ElseIf result = DialogResult.Abort Then
            strFileName = Nothing
        End If
    End Sub

    Private Sub imgRadio_CheckedChanged(sender As Object, e As EventArgs) Handles imgRadio.CheckedChanged
        Dim radio = DirectCast(sender, RadioButton)
        If radio.Checked = True Then
            imgSelectWindow()
            If strFileName = Nothing Then
                oliveRadio.Checked = True
            Else
                Dim point As Point = getRandomExistingCell()
                Dim card As Button = cardSpaces.GetControlFromPosition(point.X, point.Y)
                newGameCardBack = Nothing ' sets the card background to no colors
                newGameImgBack = Image.FromFile(strFileName).GetThumbnailImage(card.Width, card.Height, Nothing, IntPtr.Zero) ' sets the card background to an image
            End If
        End If
    End Sub

    Private Sub valueLabel_Scroll(sender As Object, e As EventArgs)
        'creates a slider to control the size of the game
        With sizeSlider
            valueLabel.Text = "Size:" + CStr(sizeSlider.Value) 'changes the label to represent the sliding variable
        End With
    End Sub

    Private Sub sizeSlider_Scroll(sender As Object, e As EventArgs) Handles sizeSlider.Scroll
        'send value to card.row to effect the size of game
        With sizeSlider
            valueLabel_Scroll(sender, e)
        End With
    End Sub

    Private Sub declareWinner()
        'Declares a winner of the game, also stops a infinite loop if the computer wins
        If Integer.Parse(playerScore.Text) > Integer.Parse(computerScore.Text) Then
            MsgBox("The player won!", 0, "Victory")
        ElseIf Integer.Parse(playerScore.Text) = Integer.Parse(computerScore.Text) Then
            MsgBox("It's a draw!", 0, "Draw")
        Else
            MsgBox("The computer wins!", 0, "Defeat")
        End If
        isPlayersTurn = True
    End Sub

    Private Sub removeFromPlay(ByRef firstCard As Button, ByRef secondCard As Button)
        'removes set of cards from play
        cardSpaces.Controls.Remove(firstCard)
        cardSpaces.Controls.Remove(secondCard)
        firstCard.Dispose()
        secondCard.Dispose()

        If cardSpaces.Controls.Count = 0 Then
            declareWinner()
        End If
    End Sub

    Private Sub decrementColorPairCount(ByVal color As Integer)
        'Gives the hidden colorVar an rgb Value
        If color = KnownColor.Blue Then 'if the random color number is 0
            blueTextBox.Text = Integer.Parse(blueTextBox.Text) - 1
        ElseIf color = KnownColor.Red Then 'if the random color number is 1
            redTextBox.Text = Integer.Parse(redTextBox.Text) - 1
        ElseIf color = KnownColor.Green Then 'if the random color number is 2
            greenTextBox.Text = Integer.Parse(greenTextBox.Text) - 1
        ElseIf color = KnownColor.Yellow Then 'if the random color number is 3
            yellowTextBox.Text = Integer.Parse(yellowTextBox.Text) - 1
        End If
    End Sub

    Private Sub addToScore()
        If isPlayersTurn = True Then
            playerScore.Text = Integer.Parse(playerScore.Text) + 1
        Else
            computerScore.Text = Integer.Parse(computerScore.Text) + 1
        End If
    End Sub

    Private Sub flipBack(ByRef firstCard As Button, ByRef secondCard As Button)
        'flips the cards back
        'Call for the animation to play here
        firstCard.Enabled = True 'Alows the card to be clicked again
        firstCard.BackColor = cardBack
        firstCard.BackgroundImage = cardImg

        secondCard.Enabled = True 'alows the card to be clicked again
        secondCard.BackColor = cardBack
        secondCard.BackgroundImage = cardImg
    End Sub

    Private Shared Sub popUpWindow(ByVal isPair As Boolean)
        If isPair = True Then
            MsgBox("You found a pair! You turn again", 0, "Success")
        Else
            MsgBox("You did not find a pair! Computer's turn", 0, "Next time")
        End If
    End Sub

    Private Sub runComputerTurn()
        Dim cardPoint As Point
        Dim cardPoint2 As Point
        Dim tempVariable
        cardPoint = getRandomExistingCell()
        tempVariable = cardSpaces.GetControlFromPosition(cardPoint.Y, cardPoint.X)
        flipCard(tempVariable, New EventArgs()) 'Computer's 1st card pick

        Do
            cardPoint2 = getRandomExistingCell()
        Loop While cardPoint2.X = cardPoint.X AndAlso cardPoint2.Y = cardPoint.Y
        tempVariable = cardSpaces.GetControlFromPosition(cardPoint2.Y, cardPoint2.X)
        flipCard(tempVariable, New EventArgs()) 'Computer's 2nd card pick
    End Sub

    Private Sub switchCurrentPlayer()
        'Dictates whose turn it is
        isPlayersTurn = Not isPlayersTurn

        While isPlayersTurn = False
            runComputerTurn()
        End While
    End Sub

    Private Async Function flipAnimation(card As Button) As Task
        flipper.assignButton(card)
        flipper.StartShrinking()
        Await Task.Delay(flipper.howLongToWait())
    End Function

    Private Async Sub flipCard(sender As Object, e As EventArgs)
        Dim card As Button = DirectCast(sender, Button)
        card.Enabled = False 'prevents button from being clicked
        Await flipAnimation(card)
        'card.BackColor = Color.FromKnownColor(card.Tag)
        'card.BackgroundImage = Nothing
        counter += 1

        If counter Mod 2 = 0 Then
            Dim isPair As Boolean = (card.Tag = savedCard.Tag)
            popUpWindow(isPair)
            If isPair = True Then
                addToScore()
                decrementColorPairCount(card.Tag)
                removeFromPlay(card, savedCard)
            Else
                flipBack(card, savedCard)
                switchCurrentPlayer()
            End If
            savedCard = Nothing
        Else
            savedCard = card
        End If
    End Sub

    Function colorSelect(ByVal colorVar As Integer) As KnownColor
        'Gives the hidden colorVar an rgb Value
        If colorVar = 0 Then 'if the random color number is 0
            blueTextBox.Text = Integer.Parse(blueTextBox.Text) + 1
            Return KnownColor.Blue  'Return the rgb value for blue
        End If
        If colorVar = 1 Then 'if the random color number is 1
            redTextBox.Text = Integer.Parse(redTextBox.Text) + 1
            Return KnownColor.Red  'return the rgb value for red
        End If
        If colorVar = 2 Then 'if the random color number is 2
            greenTextBox.Text = Integer.Parse(greenTextBox.Text) + 1
            Return KnownColor.Green  'return the rgb value for green
        End If
        If colorVar = 3 Then 'if the random color number is 3
            yellowTextBox.Text = Integer.Parse(yellowTextBox.Text) + 1
            Return KnownColor.Yellow 'return the rgb value for yellow
        End If
        Return -1
    End Function

    Private Sub createButton(ByVal row As Integer, ByVal column As Integer, ByVal colour As Integer)
        Dim card As New Button
        With card
            Dim hiddenColor As Integer
            .Anchor = AnchorStyles.Bottom AndAlso AnchorStyles.Top AndAlso AnchorStyles.Left AndAlso AnchorStyles.Right
            .BackColor = cardBack 'Sets the background color as cardBack from
            .BackgroundImage = cardImg 'Sets the background image for the button as nothing
            hiddenColor = colour
            .Tag = hiddenColor
        End With
        AddHandler card.Click, AddressOf flipCard

        cardSpaces.Controls.Add(card, column, row)
    End Sub

    Private Sub generateTableWithFixedValues(ByVal maxNumOfPairs As Integer)
        'Generates the play field for the cards when newGame is clicked
        For pairNumber As Integer = 0 To maxNumOfPairs - 1
            Dim coords As Point
            Dim colour As Integer
            If pairNumber < newGameBlueCount Then
                colour = colorSelect(0)
            ElseIf pairNumber < newGameBlueCount + newGameRedCount Then
                colour = colorSelect(1)
            ElseIf pairNumber < newGameBlueCount + newGameRedCount + newGameGreenCount Then
                colour = colorSelect(2)
            Else
                colour = colorSelect(3)
            End If
            coords = getRandomEmptyCell()
            createButton(coords.X, coords.Y, colour)
            coords = getRandomEmptyCell()
            createButton(coords.X, coords.Y, colour)
        Next
    End Sub

    Private Sub generateTableRandomly(ByVal maxNumOfPairs As Integer)
        'on start up generate a defualt game ready to play
        For pairNumber As Integer = 0 To maxNumOfPairs - 1
            Dim coords As Point
            Dim colour As Integer = colorSelect(getRandomValue(0, NUM_OF_COLORS))

            coords = getRandomEmptyCell()
            createButton(coords.X, coords.Y, colour)
            coords = getRandomEmptyCell()
            createButton(coords.X, coords.Y, colour)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        maxNumOfPairs = (cardSpaces.RowCount * cardSpaces.ColumnCount) / 2
        flipper = New CardFlipper()

        If isGeneratedRandomly = True Then
            generateTableRandomly(maxNumOfPairs)
        Else
            generateTableWithFixedValues(maxNumOfPairs)
        End If
    End Sub

    Private Sub resizeTable()
        cardSpaces.RowStyles.Clear()
        cardSpaces.ColumnStyles.Clear()
        cardSpaces.RowCount = sizeSlider.Value
        cardSpaces.ColumnCount = sizeSlider.Value - 1

        For i As Integer = 0 To cardSpaces.RowCount
            cardSpaces.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
            cardSpaces.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        Next
    End Sub

    Private Sub resetValues()
        'reset values for new game
        cardBack = newGameCardBack
        cardImg = newGameImgBack
        newGameBlueCount = blueTextBox.Text
        newGameRedCount = redTextBox.Text
        newGameGreenCount = greenTextBox.Text
        newGameYellowCount = yellowTextBox.Text
        blueTextBox.Text = 0
        redTextBox.Text = 0
        greenTextBox.Text = 0
        yellowTextBox.Text = 0
        playerScore.Text = 0
        computerScore.Text = 0
        blueTextBox.BackColor = Color.White
        redTextBox.BackColor = Color.White
        yellowTextBox.BackColor = Color.White
        greenTextBox.BackColor = Color.White
    End Sub

    Function canStartNewGame() As Boolean
        Dim totalPairs As Integer = Integer.Parse(blueTextBox.Text) + Integer.Parse(redTextBox.Text) + Integer.Parse(greenTextBox.Text) + Integer.Parse(yellowTextBox.Text)
        Dim temp As Integer = (sizeSlider.Value * (sizeSlider.Value - 1)) / 2

        If totalPairs = 0 Then
            isGeneratedRandomly = True
            Return True
        ElseIf totalPairs = temp Then
            isGeneratedRandomly = False
            Return True
        Else
            blueTextBox.BackColor = Color.Pink
            redTextBox.BackColor = Color.Pink
            yellowTextBox.BackColor = Color.Pink
            greenTextBox.BackColor = Color.Pink
            Return False
        End If
    End Function

    Private Sub newGameButton_Click(sender As Object, e As EventArgs) Handles buttonOfNewGame.Click
        Dim aCheck = canStartNewGame()
        If aCheck = True Then ''''''
            cardSpaces.Controls.Clear()
            resetValues()
            resizeTable()
            Form1_Load(sender, e)
        Else
            MsgBox("Not a valid selection of pairs.", 0, "Error") 'allows the new game button to be attempted again
        End If
    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles buttonOfExit.Click
        Application.Exit()
    End Sub
    End ClassEnd Class