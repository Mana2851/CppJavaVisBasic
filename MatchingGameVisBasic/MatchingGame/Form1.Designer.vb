<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CardFlipper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cardSpaces = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.computerScore = New System.Windows.Forms.Label()
        Me.playerScore = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.yellowTextBox = New System.Windows.Forms.TextBox()
        Me.greenTextBox = New System.Windows.Forms.TextBox()
        Me.redTextBox = New System.Windows.Forms.TextBox()
        Me.blueTextBox = New System.Windows.Forms.TextBox()
        Me.yellowPairLabel = New System.Windows.Forms.Label()
        Me.greenPairLabel = New System.Windows.Forms.Label()
        Me.redPairsLabel = New System.Windows.Forms.Label()
        Me.bluePairsLabel = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.buttonOfExit = New System.Windows.Forms.Button()
        Me.buttonOfNewGame = New System.Windows.Forms.Button()
        Me.valueLabel = New System.Windows.Forms.Label()
        Me.sizeSlider = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.oliveRadio = New System.Windows.Forms.RadioButton()
        Me.imgRadio = New System.Windows.Forms.RadioButton()
        Me.grayRadio = New System.Windows.Forms.RadioButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.sizeSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AccessibleDescription = "The field of play where the matching cards appear"
        Me.SplitContainer1.Panel1.AccessibleName = "fieldOfPlay"
        Me.SplitContainer1.Panel1.Controls.Add(Me.cardSpaces)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AccessibleDescription = "The area in which the user is given the information reguarding the game"
        Me.SplitContainer1.Panel2.AccessibleName = "gameInfoArea"
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(965, 742)
        Me.SplitContainer1.SplitterDistance = 706
        Me.SplitContainer1.TabIndex = 0
        '
        'cardSpaces
        '
        Me.cardSpaces.AccessibleName = "cardSpacesArray"
        Me.cardSpaces.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cardSpaces.ColumnCount = 3
        Me.cardSpaces.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.cardSpaces.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.cardSpaces.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.cardSpaces.Location = New System.Drawing.Point(3, 2)
        Me.cardSpaces.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cardSpaces.Name = "cardSpaces"
        Me.cardSpaces.RowCount = 4
        Me.cardSpaces.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.cardSpaces.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.cardSpaces.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.cardSpaces.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.cardSpaces.Size = New System.Drawing.Size(619, 696)
        Me.cardSpaces.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.computerScore)
        Me.GroupBox5.Controls.Add(Me.playerScore)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox5.TabIndex = 11
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Score"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Computer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Player"
        '
        'computerScore
        '
        Me.computerScore.AutoSize = True
        Me.computerScore.Location = New System.Drawing.Point(98, 62)
        Me.computerScore.Name = "computerScore"
        Me.computerScore.Size = New System.Drawing.Size(16, 17)
        Me.computerScore.TabIndex = 1
        Me.computerScore.Text = "0"
        Me.computerScore.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'playerScore
        '
        Me.playerScore.AutoSize = True
        Me.playerScore.Location = New System.Drawing.Point(98, 28)
        Me.playerScore.Name = "playerScore"
        Me.playerScore.Size = New System.Drawing.Size(16, 17)
        Me.playerScore.TabIndex = 0
        Me.playerScore.Text = "0"
        Me.playerScore.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.yellowTextBox)
        Me.GroupBox4.Controls.Add(Me.greenTextBox)
        Me.GroupBox4.Controls.Add(Me.redTextBox)
        Me.GroupBox4.Controls.Add(Me.blueTextBox)
        Me.GroupBox4.Controls.Add(Me.yellowPairLabel)
        Me.GroupBox4.Controls.Add(Me.greenPairLabel)
        Me.GroupBox4.Controls.Add(Me.redPairsLabel)
        Me.GroupBox4.Controls.Add(Me.bluePairsLabel)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 118)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 242)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pairs Avalable"
        '
        'yellowTextBox
        '
        Me.yellowTextBox.Location = New System.Drawing.Point(88, 186)
        Me.yellowTextBox.Name = "yellowTextBox"
        Me.yellowTextBox.Size = New System.Drawing.Size(44, 22)
        Me.yellowTextBox.TabIndex = 7
        Me.yellowTextBox.Text = "0"
        Me.yellowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'greenTextBox
        '
        Me.greenTextBox.Location = New System.Drawing.Point(88, 145)
        Me.greenTextBox.Name = "greenTextBox"
        Me.greenTextBox.Size = New System.Drawing.Size(44, 22)
        Me.greenTextBox.TabIndex = 6
        Me.greenTextBox.Text = "0"
        Me.greenTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'redTextBox
        '
        Me.redTextBox.Location = New System.Drawing.Point(88, 100)
        Me.redTextBox.Name = "redTextBox"
        Me.redTextBox.Size = New System.Drawing.Size(44, 22)
        Me.redTextBox.TabIndex = 5
        Me.redTextBox.Text = "0"
        Me.redTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'blueTextBox
        '
        Me.blueTextBox.Location = New System.Drawing.Point(88, 46)
        Me.blueTextBox.Name = "blueTextBox"
        Me.blueTextBox.Size = New System.Drawing.Size(44, 22)
        Me.blueTextBox.TabIndex = 4
        Me.blueTextBox.Text = "0"
        Me.blueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'yellowPairLabel
        '
        Me.yellowPairLabel.AutoSize = True
        Me.yellowPairLabel.BackColor = System.Drawing.Color.Yellow
        Me.yellowPairLabel.Location = New System.Drawing.Point(17, 186)
        Me.yellowPairLabel.Name = "yellowPairLabel"
        Me.yellowPairLabel.Size = New System.Drawing.Size(48, 17)
        Me.yellowPairLabel.TabIndex = 3
        Me.yellowPairLabel.Text = "Yellow"
        '
        'greenPairLabel
        '
        Me.greenPairLabel.AutoSize = True
        Me.greenPairLabel.BackColor = System.Drawing.Color.Green
        Me.greenPairLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.greenPairLabel.Location = New System.Drawing.Point(17, 145)
        Me.greenPairLabel.Name = "greenPairLabel"
        Me.greenPairLabel.Size = New System.Drawing.Size(48, 17)
        Me.greenPairLabel.TabIndex = 2
        Me.greenPairLabel.Text = "Green"
        '
        'redPairsLabel
        '
        Me.redPairsLabel.AutoSize = True
        Me.redPairsLabel.BackColor = System.Drawing.Color.Red
        Me.redPairsLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.redPairsLabel.Location = New System.Drawing.Point(17, 100)
        Me.redPairsLabel.Name = "redPairsLabel"
        Me.redPairsLabel.Size = New System.Drawing.Size(34, 17)
        Me.redPairsLabel.TabIndex = 1
        Me.redPairsLabel.Text = "Red"
        '
        'bluePairsLabel
        '
        Me.bluePairsLabel.AutoSize = True
        Me.bluePairsLabel.BackColor = System.Drawing.Color.Blue
        Me.bluePairsLabel.Location = New System.Drawing.Point(17, 46)
        Me.bluePairsLabel.Name = "bluePairsLabel"
        Me.bluePairsLabel.Size = New System.Drawing.Size(36, 17)
        Me.bluePairsLabel.TabIndex = 0
        Me.bluePairsLabel.Text = "Blue"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.buttonOfExit)
        Me.GroupBox2.Controls.Add(Me.buttonOfNewGame)
        Me.GroupBox2.Controls.Add(Me.valueLabel)
        Me.GroupBox2.Controls.Add(Me.sizeSlider)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 588)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(219, 110)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Game Controls"
        '
        'buttonOfExit
        '
        Me.buttonOfExit.Location = New System.Drawing.Point(120, 83)
        Me.buttonOfExit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.buttonOfExit.Name = "buttonOfExit"
        Me.buttonOfExit.Size = New System.Drawing.Size(75, 23)
        Me.buttonOfExit.TabIndex = 1
        Me.buttonOfExit.Text = "Exit"
        Me.buttonOfExit.UseVisualStyleBackColor = True
        '
        'buttonOfNewGame
        '
        Me.buttonOfNewGame.Location = New System.Drawing.Point(6, 83)
        Me.buttonOfNewGame.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.buttonOfNewGame.Name = "buttonOfNewGame"
        Me.buttonOfNewGame.Size = New System.Drawing.Size(108, 23)
        Me.buttonOfNewGame.TabIndex = 0
        Me.buttonOfNewGame.Text = "New Game"
        Me.buttonOfNewGame.UseVisualStyleBackColor = True
        '
        'valueLabel
        '
        Me.valueLabel.AutoSize = True
        Me.valueLabel.Location = New System.Drawing.Point(5, 43)
        Me.valueLabel.Name = "valueLabel"
        Me.valueLabel.Size = New System.Drawing.Size(51, 17)
        Me.valueLabel.TabIndex = 3
        Me.valueLabel.Text = "Size: 4"
        '
        'sizeSlider
        '
        Me.sizeSlider.LargeChange = 2
        Me.sizeSlider.Location = New System.Drawing.Point(53, 38)
        Me.sizeSlider.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sizeSlider.Minimum = 4
        Me.sizeSlider.Name = "sizeSlider"
        Me.sizeSlider.Size = New System.Drawing.Size(157, 56)
        Me.sizeSlider.TabIndex = 2
        Me.sizeSlider.Value = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.oliveRadio)
        Me.GroupBox1.Controls.Add(Me.imgRadio)
        Me.GroupBox1.Controls.Add(Me.grayRadio)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 365)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(164, 219)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Card Back"
        '
        'oliveRadio
        '
        Me.oliveRadio.AutoSize = True
        Me.oliveRadio.BackColor = System.Drawing.Color.Olive
        Me.oliveRadio.Checked = True
        Me.oliveRadio.Location = New System.Drawing.Point(21, 42)
        Me.oliveRadio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.oliveRadio.Name = "oliveRadio"
        Me.oliveRadio.Size = New System.Drawing.Size(61, 21)
        Me.oliveRadio.TabIndex = 4
        Me.oliveRadio.TabStop = True
        Me.oliveRadio.Text = "Olive"
        Me.oliveRadio.UseVisualStyleBackColor = False
        '
        'imgRadio
        '
        Me.imgRadio.AutoSize = True
        Me.imgRadio.Location = New System.Drawing.Point(21, 126)
        Me.imgRadio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.imgRadio.Name = "imgRadio"
        Me.imgRadio.Size = New System.Drawing.Size(67, 21)
        Me.imgRadio.TabIndex = 6
        Me.imgRadio.Text = "Image"
        Me.imgRadio.UseVisualStyleBackColor = True
        '
        'grayRadio
        '
        Me.grayRadio.AutoSize = True
        Me.grayRadio.BackColor = System.Drawing.Color.Gray
        Me.grayRadio.Location = New System.Drawing.Point(21, 82)
        Me.grayRadio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grayRadio.Name = "grayRadio"
        Me.grayRadio.Size = New System.Drawing.Size(60, 21)
        Me.grayRadio.TabIndex = 5
        Me.grayRadio.Text = "Gray"
        Me.grayRadio.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 742)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.sizeSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cardSpaces As TableLayoutPanel
    Friend WithEvents buttonOfExit As Button
    Friend WithEvents buttonOfNewGame As Button
    Friend WithEvents sizeSlider As TrackBar
    Friend WithEvents valueLabel As Label
    Friend WithEvents imgRadio As RadioButton
    Friend WithEvents grayRadio As RadioButton
    Friend WithEvents oliveRadio As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents computerScore As Label
    Friend WithEvents playerScore As Label
    Friend WithEvents yellowPairLabel As Label
    Friend WithEvents greenPairLabel As Label
    Friend WithEvents redPairsLabel As Label
    Friend WithEvents bluePairsLabel As Label
    Friend WithEvents yellowTextBox As TextBox
    Friend WithEvents greenTextBox As TextBox
    Friend WithEvents redTextBox As TextBox
    Friend WithEvents blueTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
