Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text
Imports System.Diagnostics

Public Class Form1
    Private submissions As List(Of Submission)
    Private currentIndex As Integer
    Private stopwatch As Stopwatch

    Public Sub New()
        InitializeComponent()
        submissions = New List(Of Submission)()
        currentIndex = 0
        stopwatch = New Stopwatch()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Ashutosh Tripathy SSlidelyAI Task-2"
        Me.Size = New Size(800, 600) ' Adjusted form size

        ' Create New Submission button
        Dim btnCreateNewSubmission As New Button()
        btnCreateNewSubmission.Text = "Create New Submission"
        btnCreateNewSubmission.Location = New Point(50, 50)
        btnCreateNewSubmission.BackColor = Color.LightBlue ' Blue background
        btnCreateNewSubmission.ForeColor = Color.Black ' White text
        btnCreateNewSubmission.Font = New Font("Arial", 12, FontStyle.Bold) ' Larger font
        btnCreateNewSubmission.Size = New Size(400, 70) ' Larger size
        AddHandler btnCreateNewSubmission.Click, AddressOf btnCreateNewSubmission_Click
        Me.Controls.Add(btnCreateNewSubmission)

        ' View Submissions button
        Dim btnViewSubmissions As New Button()
        btnViewSubmissions.Text = "View Submissions"
        btnViewSubmissions.Location = New Point(50, 150) ' Increased vertical spacing
        btnViewSubmissions.BackColor = Color.Yellow ' Yellow background
        btnViewSubmissions.ForeColor = Color.Black ' Black text
        btnViewSubmissions.Font = New Font("Arial", 12, FontStyle.Bold) ' Larger font
        btnViewSubmissions.Size = New Size(400, 70) ' Larger size
        AddHandler btnViewSubmissions.Click, AddressOf btnViewSubmissions_Click
        Me.Controls.Add(btnViewSubmissions)

        ' Set up other form elements as needed
    End Sub

    ' Function to style text boxes
    Private Sub StyleTextBox(txtBox As TextBox, isReadOnly As Boolean)
        txtBox.ReadOnly = isReadOnly
        If isReadOnly Then
            txtBox.BackColor = Color.LightGray ' Light gray background for read-only text boxes
        Else
            txtBox.BackColor = SystemColors.Window ' Default background for editable text boxes
        End If
        txtBox.Font = New Font("Arial", 10) ' Larger font
    End Sub

    Private Sub btnCreateNewSubmission_Click(sender As Object, e As EventArgs)
        Dim createSubmissionForm As New Form()
        createSubmissionForm.Text = "Ashutosh Tripathy Slidely Task-2 Create New Submission"
        createSubmissionForm.Size = New Size(600, 500) ' Increased form size

        Dim lblName As New Label()
        lblName.Text = "Name:"
        lblName.Location = New Point(20, 20)
        createSubmissionForm.Controls.Add(lblName)

        Dim txtName As New TextBox()
        txtName.Location = New Point(150, 20)
        StyleTextBox(txtName, False) ' Apply styled text box
        createSubmissionForm.Controls.Add(txtName)

        Dim lblEmail As New Label()
        lblEmail.Text = "Email:"
        lblEmail.Location = New Point(20, 60)
        createSubmissionForm.Controls.Add(lblEmail)

        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(150, 60)
        StyleTextBox(txtEmail, False) ' Apply styled text box
        createSubmissionForm.Controls.Add(txtEmail)

        Dim lblPhoneNum As New Label()
        lblPhoneNum.Text = "Phone Number:"
        lblPhoneNum.Location = New Point(20, 100)
        createSubmissionForm.Controls.Add(lblPhoneNum)

        Dim txtPhoneNum As New TextBox()
        txtPhoneNum.Location = New Point(150, 100)
        StyleTextBox(txtPhoneNum, False) ' Apply styled text box
        createSubmissionForm.Controls.Add(txtPhoneNum)

        Dim lblGithubLink As New Label()
        lblGithubLink.Text = "GitHub Link:"
        lblGithubLink.Location = New Point(20, 140)
        createSubmissionForm.Controls.Add(lblGithubLink)

        Dim txtGithubLink As New TextBox()
        txtGithubLink.Location = New Point(150, 140)
        StyleTextBox(txtGithubLink, False) ' Apply styled text box
        createSubmissionForm.Controls.Add(txtGithubLink)

        Dim lblStopwatchTime As New Label()
        lblStopwatchTime.Text = "Stopwatch Time:"
        lblStopwatchTime.Location = New Point(20, 180)
        createSubmissionForm.Controls.Add(lblStopwatchTime)

        Dim txtStopwatchTime As New TextBox()
        txtStopwatchTime.Location = New Point(200, 180)
        txtStopwatchTime.ReadOnly = True
        txtStopwatchTime.BackColor = Color.LightGray ' Light gray background for read-only text boxes
        txtStopwatchTime.Font = New Font("Arial", 10) ' Larger font
        createSubmissionForm.Controls.Add(txtStopwatchTime)

        Dim btnToggleStopwatchInForm As New Button()
        btnToggleStopwatchInForm.Text = "Toggle Stopwatch"
        btnToggleStopwatchInForm.Location = New Point(150, 220)
        btnToggleStopwatchInForm.BackColor = Color.Yellow ' Yellow background
        btnToggleStopwatchInForm.ForeColor = Color.Black ' Black text
        btnToggleStopwatchInForm.Font = New Font("Arial", 12, FontStyle.Bold) ' Larger font
        btnToggleStopwatchInForm.Size = New Size(200, 50) ' Larger size
        AddHandler btnToggleStopwatchInForm.Click, Sub()
                                                       If stopwatch.IsRunning Then
                                                           stopwatch.Stop()
                                                           btnToggleStopwatchInForm.Text = "Start Stopwatch"
                                                       Else
                                                           stopwatch.Start()
                                                           btnToggleStopwatchInForm.Text = "Stop Stopwatch"
                                                       End If
                                                   End Sub
        createSubmissionForm.Controls.Add(btnToggleStopwatchInForm)

        Dim btnSubmit As New Button()
        btnSubmit.Text = "Submit"
        btnSubmit.Location = New Point(400, 220)
        btnSubmit.BackColor = Color.Blue ' Blue background for submit button
        btnSubmit.ForeColor = Color.White ' White text
        btnSubmit.Font = New Font("Arial", 12, FontStyle.Bold) ' Larger font
        btnSubmit.Size = New Size(150, 50) ' Larger size
        AddHandler btnSubmit.Click, Sub()
                                        If String.IsNullOrEmpty(txtName.Text) OrElse
                                           String.IsNullOrEmpty(txtEmail.Text) OrElse
                                           String.IsNullOrEmpty(txtPhoneNum.Text) OrElse
                                           String.IsNullOrEmpty(txtGithubLink.Text) Then
                                            MessageBox.Show("Please fill in all fields.")
                                            Return
                                        End If

                                        ' Check if stopwatch is running before submitting
                                        If Not stopwatch.IsRunning Then
                                            MessageBox.Show("Please start the stopwatch before submitting.")
                                            Return
                                        End If

                                        ' Stop the stopwatch before submission
                                        stopwatch.Stop()

                                        Dim newSubmission As New Submission() With {
                                            .Name = txtName.Text,
                                            .Email = txtEmail.Text,
                                            .PhoneNum = txtPhoneNum.Text,
                                            .GithubLink = txtGithubLink.Text,
                                            .StopwatchTime = stopwatch.Elapsed.ToString("hh\:mm\:ss")
                                        }

                                        Try
                                            Using client As New HttpClient()
                                                Dim json As String = JsonConvert.SerializeObject(newSubmission)
                                                Dim content As New StringContent(json, Encoding.UTF8, "application/json")
                                                Dim response As HttpResponseMessage = client.PostAsync("http://localhost:3000/submit", content).Result
                                                If response.IsSuccessStatusCode Then
                                                    MessageBox.Show("Submission saved successfully!")
                                                    txtName.Clear()
                                                    txtEmail.Clear()
                                                    txtPhoneNum.Clear()
                                                    txtGithubLink.Clear()
                                                    txtStopwatchTime.Clear()
                                                Else
                                                    MessageBox.Show("Error saving submission.")
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            MessageBox.Show("Error: " & ex.Message)
                                        End Try
                                    End Sub
        createSubmissionForm.Controls.Add(btnSubmit)

        ' Start the stopwatch when the form is shown
        stopwatch.Start()

        createSubmissionForm.ShowDialog()
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs)
        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = client.GetAsync("http://localhost:3000/read").Result
                If response.IsSuccessStatusCode Then
                    Dim jsonResponse As String = response.Content.ReadAsStringAsync().Result
                    submissions = JsonConvert.DeserializeObject(Of List(Of Submission))(jsonResponse)
                    currentIndex = 0
                    ShowSubmission()
                Else
                    MessageBox.Show("Error: " & response.StatusCode.ToString())
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowSubmission()
        If submissions.Count = 0 Then
            MessageBox.Show("No submissions available.")
            Return
        End If

        Dim viewSubmissionForm As New Form()
        viewSubmissionForm.Text = "Ashutosh Tripathy Slidely Task-2 View Submission"
        viewSubmissionForm.Size = New Size(600, 400) ' Increased form size

        Dim lblName As New Label()
        lblName.Text = "Name:"
        lblName.Location = New Point(20, 20)
        viewSubmissionForm.Controls.Add(lblName)

        Dim txtName As New TextBox()
        txtName.Location = New Point(150, 20)
        StyleTextBox(txtName, True) ' Apply styled read-only text box
        viewSubmissionForm.Controls.Add(txtName)

        Dim lblEmail As New Label()
        lblEmail.Text = "Email:"
        lblEmail.Location = New Point(20, 60)
        viewSubmissionForm.Controls.Add(lblEmail)

        Dim txtEmail As New TextBox()
        txtEmail.Location = New Point(150, 60)
        StyleTextBox(txtEmail, True) ' Apply styled read-only text box
        viewSubmissionForm.Controls.Add(txtEmail)

        Dim lblPhoneNum As New Label()
        lblPhoneNum.Text = "Phone Number:"
        lblPhoneNum.Location = New Point(20, 100)
        viewSubmissionForm.Controls.Add(lblPhoneNum)

        Dim txtPhoneNum As New TextBox()
        txtPhoneNum.Location = New Point(150, 100)
        StyleTextBox(txtPhoneNum, True) ' Apply styled read-only text box
        viewSubmissionForm.Controls.Add(txtPhoneNum)

        Dim lblGithubLink As New Label()
        lblGithubLink.Text = "GitHub Link:"
        lblGithubLink.Location = New Point(20, 140)
        viewSubmissionForm.Controls.Add(lblGithubLink)

        Dim txtGithubLink As New TextBox()
        txtGithubLink.Location = New Point(150, 140)
        StyleTextBox(txtGithubLink, True) ' Apply styled read-only text box
        viewSubmissionForm.Controls.Add(txtGithubLink)

        Dim lblStopwatchTime As New Label()
        lblStopwatchTime.Text = "Stopwatch Time:"
        lblStopwatchTime.Location = New Point(20, 180)
        viewSubmissionForm.Controls.Add(lblStopwatchTime)

        Dim txtStopwatchTime As New TextBox()
        txtStopwatchTime.Location = New Point(150, 180)
        txtStopwatchTime.ReadOnly = True
        txtStopwatchTime.BackColor = Color.LightGray ' Light gray background for read-only text boxes
        txtStopwatchTime.Font = New Font("Arial", 10) ' Larger font
        viewSubmissionForm.Controls.Add(txtStopwatchTime)

        Dim btnPrevious As New Button()
        btnPrevious.Text = "Previous"
        btnPrevious.Location = New Point(50, 220)
        btnPrevious.BackColor = Color.Yellow ' Yellow background for navigation buttons
        btnPrevious.ForeColor = Color.Black ' Black text
        btnPrevious.Font = New Font("Arial", 10, FontStyle.Bold) ' Larger font
        btnPrevious.Size = New Size(100, 30) ' Larger size
        AddHandler btnPrevious.Click, Sub()
                                          If currentIndex > 0 Then
                                              currentIndex -= 1
                                              ShowSubmission()
                                          Else
                                              MessageBox.Show("No previous submission.")
                                          End If
                                      End Sub
        viewSubmissionForm.Controls.Add(btnPrevious)

        Dim btnNext As New Button()
        btnNext.Text = "Next"
        btnNext.Location = New Point(200, 220)
        btnNext.BackColor = Color.LightBlue ' Yellow background for navigation buttons
        btnNext.ForeColor = Color.Black ' Black text
        btnNext.Font = New Font("Arial", 10, FontStyle.Bold) ' Larger font
        btnNext.Size = New Size(100, 30) ' Larger size
        AddHandler btnNext.Click, Sub()
                                      If currentIndex < submissions.Count - 1 Then
                                          currentIndex += 1
                                          ShowSubmission()
                                      Else
                                          MessageBox.Show("No next submission.")
                                      End If
                                  End Sub
        viewSubmissionForm.Controls.Add(btnNext)

        ' Display current submission data
        If currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            txtName.Text = submissions(currentIndex).Name
            txtEmail.Text = submissions(currentIndex).Email
            txtPhoneNum.Text = submissions(currentIndex).PhoneNum
            txtGithubLink.Text = submissions(currentIndex).GithubLink
            txtStopwatchTime.Text = submissions(currentIndex).StopwatchTime
        End If

        viewSubmissionForm.ShowDialog()
    End Sub

    Public Class Submission
        Public Property Name As String
        Public Property Email As String
        Public Property PhoneNum As String
        Public Property GithubLink As String
        Public Property StopwatchTime As String
    End Class

End Class
