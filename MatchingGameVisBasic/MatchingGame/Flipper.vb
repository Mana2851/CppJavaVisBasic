Public Class CardFlipper
    Private button As Button

    Private wasShowingFront As Boolean
    Private isFlipping As Boolean

    Private shrinkTimer As Timer
    Private growTimer As Timer

    Private initWidth As Integer
    Private initHeight As Integer

    Private cardBack As Color
    Private cardBackImg As Image
    Private cardFront As Color

    Public Sub New()
        shrinkTimer = New Timer()
        shrinkTimer.Interval = 100
        shrinkTimer.Enabled = False
        AddHandler shrinkTimer.Tick, AddressOf shrinkABit

        growTimer = New Timer()
        growTimer.Interval = 100
        growTimer.Enabled = False
        AddHandler growTimer.Tick, AddressOf growABit
    End Sub

    'Public Sub New(width As Integer, height As Integer)

    '    frontShowing = False

    '    Me.Width = width
    '    Me.Height = height
    '    initWidth = width
    '    initHeight = height

    '    Me.BackColor = Color.Blue

    '    shrinkTimer = New Timer()
    '    shrinkTimer.Interval = 100
    '    shrinkTimer.Enabled = False
    '    AddHandler shrinkTimer.Tick, AddressOf shrinkABit

    '    growTimer = New Timer()
    '    growTimer.Interval = 100
    '    growTimer.Enabled = False
    '    AddHandler growTimer.Tick, AddressOf growABit


    '    AddHandler Me.MouseClick, AddressOf StartShrinking

    'End Sub

    Public Sub assignButton(ByRef nButton As Button)
        button = nButton
        initWidth = nButton.Width
        initHeight = nButton.Height

        cardBack = button.BackColor
        cardBackImg = button.BackgroundImage
        cardFront = Color.FromKnownColor(button.Tag)

        button.Anchor = AnchorStyles.None
        button.Width = initWidth
        button.Height = initHeight
    End Sub

    Public Function howLongToWait()
        Return shrinkTimer.Interval * initWidth + growTimer.Interval * initWidth
    End Function

    Public Sub StartShrinking()
        shrinkTimer.Enabled = True

        'If Not (shrinkTimer.Enabled Or growTimer.Enabled) Then
        '    shrinkTimer.Enabled = True
        'End If
    End Sub

    Private Sub shrinkABit()

        If button.Width <= 0 Or button.Height <= 0 Then
            shrinkTimer.Enabled = False
            growTimer.Enabled = True



            If wasShowingFront Then
                If cardBackImg Is Nothing Then
                    button.BackColor = cardBack
                    button.BackgroundImage = Nothing
                Else
                    button.BackColor = Nothing
                    button.BackgroundImage = cardBackImg
                End If
            Else
                button.BackColor = cardFront
            End If

            wasShowingFront = Not wasShowingFront

            Return
        End If

        button.Width -= 10
        button.Height -= 10

    End Sub

    Private Sub growABit()

        If button.Width = initWidth Or button.Height = initHeight Then
            growTimer.Enabled = False
            Return
        End If

        button.Width += 10
        button.Height += 10

    End Sub
End Class

