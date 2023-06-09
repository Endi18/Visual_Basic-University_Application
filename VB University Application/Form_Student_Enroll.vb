﻿Public Class Form_Student_Enroll
    Inherits Form

    Private _studentID As Integer
    Private _name As String
    Private _surname As String
    Private _username As String
    Private _password As String
    Private _major As String
    Private _courses As List(Of String)

    Public Property StudentID As Integer
        Get
            Return _studentID
        End Get
        Set(value As Integer)
            _studentID = value
        End Set
    End Property

    Public Overloads Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Surname As String
        Get
            Return _surname
        End Get
        Set(value As String)
            _surname = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Major As String
        Get
            Return _major
        End Get
        Set(value As String)
            _major = value
        End Set
    End Property

    Public Property Courses As List(Of String)
        Get
            Return _courses
        End Get
        Set(value As List(Of String))
            _courses = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        For Each s As String In New Student().allCoursesExcludingStudentCourses()
            comboBoxEnroll.Items.Add(s)
        Next
    End Sub

    Public Sub New(studentID As Integer, name As String, surname As String, username As String, password As String, major As String, courses As List(Of String))
        InitializeComponent()
        Me.StudentID = studentID
        Me.Name = name
        Me.Surname = surname
        Me.Username = username
        Me.Password = password
        Me.Major = major
        Me.Courses = courses

        For Each s As String In New Student(studentID, name, surname, username, password, major, courses).allCoursesExcludingStudentCourses()
            comboBoxEnroll.Items.Add(s)
        Next
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim student As New Form_Student(StudentID, Name, Surname, Username, Password, Major, Courses)
        Hide()
        student.Show()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If comboBoxEnroll.SelectedIndex = -1 Then
            MessageBox.Show("Select a Course!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Else
            Form_Welcome.CopyDatabaseToMainFolder()
            Dim student = New Student(StudentID, Name, Surname, Username, Password, Major)
            student.enroll(comboBoxEnroll.Text, StudentID)
            MessageBox.Show("The Course is Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Dim form_Student As New Form_Student(Username, Password)
            Close()
            form_Student.Show()
        End If
    End Sub
End Class
