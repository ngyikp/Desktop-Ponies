﻿Public Class FiltersForm
    Public Sub New()
        InitializeComponent()
        Icon = My.Resources.Twilight
    End Sub

    Private Sub FiltersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FiltersTextBox.Lines = Options.CustomTags.Select(Function(tag) tag.ToString()).ToArray()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Close()
    End Sub

    Private Sub Save_Button_Click(sender As Object, e As EventArgs) Handles Save_Button.Click
        Dim lines = FiltersTextBox.Lines.ToList()
        If lines.RemoveAll(Function(line) line.IndexOf(ControlChars.Quote) <> -1) > 0 Then
            MessageBox.Show(Me, "You cannot use the quote character in custom tags. Any tags with this character have been removed.",
                            "Invalid Tags", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Options.CustomTags = lines.Select(Function(tag) New CaseInsensitiveString(tag)).ToImmutableArray()
        Close()
    End Sub
End Class
