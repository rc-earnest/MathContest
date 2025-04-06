'Rudy Earnest
'RCET 2265
'Spring 2025
'Math Contest
'https://github.com/rc-earnest/MathContest.git

Option Explicit On
Option Strict On
Option Compare Text

Public Class MathContest

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearForm()
        NameTextBox.Clear()
        GradeTextBox.Clear()
        AgeTextBox.Clear()
        StudentAnswerTextBox.Clear()
        GenerateNewNumbers()
        NameTextBox.Focus()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearForm()
    End Sub

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddRadioButton.Checked = True
        ClearForm()
        ToolTip1.SetToolTip(StudentInfoGroupBox, "Enter student information")
        ToolTip1.SetToolTip(CurrentMathProblemGroupBox, "Calculation Results")
        ToolTip1.SetToolTip(SubmitButton, "Submit the answer")
        ToolTip1.SetToolTip(ClearButton, "Clear all fields")
        ToolTip1.SetToolTip(ExitButton, "Exit the application")
        ToolTip1.SetToolTip(SummaryButton, "View Summary of correct and incorrect answers")

    End Sub


    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged, SubtractRadioButton.CheckedChanged, MultiplyRadioButton.CheckedChanged, DivideRadioButton.CheckedChanged
        If AddRadioButton.Checked OrElse SubtractRadioButton.Checked OrElse MultiplyRadioButton.Checked OrElse DivideRadioButton.Checked Then
            GenerateNewNumbers()
        End If
    End Sub
    Private Sub GenerateNewNumbers()
        Randomize()
        Dim random As New Random()
        Dim numberOne As Integer = random.Next(1, 20)
        Dim numberTwo As Integer = random.Next(1, 20)

        FirstNumberTextBox.Text = numberOne.ToString()
        SecondNumberTextBox.Text = numberTwo.ToString()
    End Sub

End Class
