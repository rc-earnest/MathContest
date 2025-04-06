'Rudy Earnest
'RCET 2265
'Spring 2025
'Math Contest
'https://github.com/rc-earnest/MathContest.git

Option Explicit On
Option Strict On
Option Compare Text

Public Class MathContest
    'Closes the Program
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    'Clears the form boxes and sets the focus and resets the correct and incorrect count for the summary display
    Private Sub ClearForm()
        NameTextBox.Clear()
        GradeTextBox.Clear()
        AgeTextBox.Clear()
        StudentAnswerTextBox.Clear()
        GenerateNewNumbers()
        NameTextBox.Focus()
        correctCount = 0
        incorrectCount = 0
    End Sub
    'clears the form when clear is clicked
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearForm()
    End Sub
    'Sets tooltips and autoselects the addition radio button
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

    'Generates numbers when a radio button is selected or changes
    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged, SubtractRadioButton.CheckedChanged, MultiplyRadioButton.CheckedChanged, DivideRadioButton.CheckedChanged
        If AddRadioButton.Checked OrElse SubtractRadioButton.Checked OrElse MultiplyRadioButton.Checked OrElse DivideRadioButton.Checked Then
            GenerateNewNumbers()
        End If
    End Sub
    'Code to generate random numbers between 1 and 20
    Private Sub GenerateNewNumbers()
        Randomize()
        Dim random As New Random()
        Dim numberOne As Integer = random.Next(1, 20)
        Dim numberTwo As Integer = random.Next(1, 20)

        FirstNumberTextBox.Text = numberOne.ToString()
        SecondNumberTextBox.Text = numberTwo.ToString()
    End Sub
    Private correctCount As Integer = 0
    Private incorrectCount As Integer = 0

    'Checks to make sure that the correct information is recieved and then sets focus to whatever is incorrect  so that it can be corrected
    Private Function ValidateInput() As Boolean
        Dim errorMessage As String = ""
        Dim focusControl As Control = Nothing
        Dim grade As Integer
        Dim age As Integer


        If String.IsNullOrEmpty(NameTextBox.Text) Then
            errorMessage &= "Name is required." & Environment.NewLine
            If focusControl Is Nothing Then focusControl = NameTextBox
        End If


        If String.IsNullOrEmpty(GradeTextBox.Text) OrElse Not Integer.TryParse(GradeTextBox.Text, grade) OrElse grade < 1 OrElse grade > 4 Then
            errorMessage &= "Grade must be between 1 and 4." & Environment.NewLine
            If focusControl Is Nothing Then focusControl = GradeTextBox
        End If


        If String.IsNullOrEmpty(AgeTextBox.Text) OrElse Not Integer.TryParse(AgeTextBox.Text, age) OrElse age < 7 OrElse age > 11 Then
            errorMessage &= "Age must be between 7 and 11." & Environment.NewLine
            If focusControl Is Nothing Then focusControl = AgeTextBox
        End If


        If errorMessage <> "" Then
            MessageBox.Show(errorMessage, "Input Error")
            focusControl.Focus()
            Return False
        End If

        Return True
    End Function
    'Checks the answer to what the numbers were and whatever radio button was selected
    Private Sub PerformCalculation()
        Dim num1 As Integer = Integer.Parse(FirstNumberTextBox.Text)
        Dim num2 As Integer = Integer.Parse(SecondNumberTextBox.Text)
        Dim answer As Integer
        Dim userAnswer As Integer


        If Not Integer.TryParse(StudentAnswerTextBox.Text, userAnswer) Then
            MessageBox.Show("Please enter a valid number for the answer.", "Input Error")
            StudentAnswerTextBox.Focus()
            Return
        End If

        If AddRadioButton.Checked Then
            answer = num1 + num2
        ElseIf SubtractRadioButton.Checked Then
            answer = num1 - num2
        ElseIf MultiplyRadioButton.Checked Then
            answer = num1 * num2
        ElseIf DivideRadioButton.Checked Then
            answer = num1 \ num2
        End If


        If userAnswer = answer Then
            MessageBox.Show("Congratulations! Your answer is correct.", "Correct")
            correctCount += 1
        Else
            MessageBox.Show($"Incorrect. The correct answer is {answer}.", "Incorrect")
            incorrectCount += 1
        End If
        GenerateNewNumbers()
        StudentAnswerTextBox.Clear()
        StudentAnswerTextBox.Focus()
    End Sub
    'Makes sure the information is correct then checks the answer once the submit button is clicked
    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        If ValidateInput() Then
            PerformCalculation()
        End If
    End Sub
    'Handles the summary of incorrect to correct answers
    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        MessageBox.Show($"Correct Answers: {correctCount}{Environment.NewLine}Incorrect Answers: {incorrectCount}", "Summary")
    End Sub

End Class
