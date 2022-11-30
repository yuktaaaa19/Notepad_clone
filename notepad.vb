Public Class Form1

    Private Sub ExiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExiToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Title = "Open"
        OpenFileDialog1.InitialDirectory = "D:\"
        OpenFileDialog1.Filter = "All files | *.*| text files | *.txt | word File | *.docx"


        If RichTextBox1.Modified Then
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you want to save the file ?", MsgBoxStyle.YesNoCancel, "Open Document")
            If ask = MsgBoxResult.No Then
                OpenFileDialog1.ShowDialog()
                RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            ElseIf ask = MsgBoxResult.Cancel Then
            ElseIf ask = MsgBoxResult.Yes Then

                RichTextBox1.Clear()

            End If
        Else
            OpenFileDialog1.ShowDialog()
            Try
                RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Catch ex As Exception

            End Try

        End If


    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If RichTextBox1.Modified Then
            Dim a As MsgBoxResult
            a = MsgBox("Do you want to save changes.....", MsgBoxStyle.YesNoCancel, "New Document")
            If a = MsgBoxResult.No Then

                RichTextBox1.Clear()
            ElseIf a = MsgBoxResult.Cancel Then
            ElseIf a = MsgBoxResult.Yes Then
                SaveFileDialog1.ShowDialog()
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, False)
                RichTextBox1.Clear()

            End If
        Else
            RichTextBox1.Clear()


        End If
       
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim inp As String
        inp = InputBox("Find What:", "Find")

        If (RichTextBox1.Text.Contains(inp)) Then
            'Windows.Forms.Cursor.Position = New Point(Me.Location.X + RichTextBox1.Location.X)


        End If
    End Sub

    Private Sub GoToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToToolStripMenuItem.Click

    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordWrapToolStripMenuItem.Click
        If WordWrapToolStripMenuItem.Checked Then
            RichTextBox1.Multiline = True
            RichTextBox1.ScrollBars = ScrollBars.Vertical

        Else
            RichTextBox1.Multiline = False

            RichTextBox1.ScrollBars = ScrollBars.Horizontal

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DeleteToolStripMenuItem.Enabled = False


    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Title = "Save As"
        SaveFileDialog1.InitialDirectory = "D:\"
        SaveFileDialog1.Filter = "All files|*.*| text files |*.txt | word file |*.docx | html file |*.html"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text)
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()

    End Sub

    Private Sub CUtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUtToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click

        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            RichTextBox1.Font = FontDialog1.Font

        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub AboutNotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutNotepadToolStripMenuItem.Click
        MsgBox("Notepad developed by " & vbCrLf & "Yukta Sharma")

    End Sub

    Private Sub FindDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindDateToolStripMenuItem.Click
        RichTextBox1.Text = System.DateTime.Now
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click
        SaveFileDialog1.ShowDialog()

        SaveFileDialog1.Title = "Save As"
        SaveFileDialog1.InitialDirectory = "D:\"
        SaveFileDialog1.Filter = "All files|*.*| text files |*.txt | word file |*.docx"
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then
            Dim a As MsgBoxResult
            MsgBox("File already exists Do you want to save changes ?", MsgBoxStyle.YesNoCancel, "File Exists")
            If a = MsgBoxResult.No Then
                SaveFileDialog1.ShowDialog()
            ElseIf a = MsgBoxResult.Yes Then

                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, False)

            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, RichTextBox1.Text, False)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If RichTextBox1.Modified Then
            DeleteToolStripMenuItem.Enabled = True


            RichTextBox1.Clear()
        End If








    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Dim i As String
        'i = InputBox("")



    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub UndoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem1.Click
        RichTextBox1.Undo()

    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()

    End Sub

    Private Sub CutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem1.Click
        RichTextBox1.Cut()

    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        RichTextBox1.Copy()


    End Sub

    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        RichTextBox1.Paste()

    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem1.Click
        RichTextBox1.SelectAll()

    End Sub
End Class
