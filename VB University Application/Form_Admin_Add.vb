﻿Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Reflection.Emit
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports VB_University_Application.University_Application

Public Class Form_Admin_Add
    Inherits Form

    Private admin As Admin
    Private index As Integer

    Public Sub New(ByVal index As Integer, ByRef admin As Admin)
        InitializeComponent()
        Me.admin = admin
        Me.index = index

        If index = 1 Then
            lblWelcome.Text = "Add Professor"
            label6.Hide()
            comboBox1.Hide()
            lblFirstName.Text = "First Name:"
            lblLast_Name.Text = "Last Name:"
            lbl3.Text = "Username:"
            lbl4.Text = "Password:"
        End If

        If index = 2 Then
            lblWelcome.Text = "Add Student"
            lblFirstName.Text = "First Name:"
            lblLast_Name.Text = "Last Name:"
            lbl3.Text = "Username:"
            lbl4.Text = "Password:"
            label6.Text = "Major:"
            comboBox1.Text = "Select a Major"
        End If

        If index = 3 Then
            lblWelcome.Text = "Add Course"
            lblFirstName.Text = "Course Name:"
            lblLast_Name.Text = "Credits:"
            lbl3.Text = "Hours:"
            lbl4.Hide()
            label6.Text = "Professor:"
            textBox4.Hide()
            comboBox1.Items.Clear()
            comboBox1.Text = "Select a Professor"

            For i As Integer = 0 To admin.professorList.Count - 1
                comboBox1.Items.Add(admin.professorList.ElementAt(i).Id & " " + admin.professorList.ElementAt(i).Username)
            Next
        End If
    End Sub

    Public Sub addProfessor()
        Dim professor As Professor = New Professor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text)
        admin.addProfessor(professor)
    End Sub

    Public Sub addStudent()
        Dim student As Student = New Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.SelectedItem.ToString())
        admin.addStudent(student)
    End Sub

    Public Sub addCourse()
        Dim course As Courses = New Courses(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text))
        admin.addCourse(course, Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(" "c)(0)))
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        If index = 1 Then

            If textBox1.Text = "" OrElse textBox2.Text = "" OrElse textBox3.Text = "" OrElse textBox4.Text = "" Then
                MessageBox.Show("Enter All Data!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Else
                Me.addProfessor()
                MessageBox.Show("Professor Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Dim admin As Form_Admin = New Form_Admin()
                Me.Close()
                admin.Show()
            End If
        End If

        If index = 2 Then

            If textBox1.Text = "" OrElse textBox2.Text = "" OrElse textBox3.Text = "" OrElse textBox4.Text = "" OrElse comboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Enter All Data!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Else
                Me.addStudent()
                MessageBox.Show("Student Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Dim admin As Form_Admin = New Form_Admin()
                Me.Close()
                admin.Show()
            End If
        End If

        If index = 3 Then

            If textBox1.Text = "" OrElse textBox2.Text = "" OrElse textBox3.Text = "" OrElse comboBox1.SelectedItem Is Nothing Then
                MessageBox.Show("Enter All Data!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Else
                Me.addCourse()
                MessageBox.Show("Course Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Dim admin As Form_Admin = New Form_Admin()
                Me.Close()
                admin.Show()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        Dim admin As Form_Admin = New Form_Admin()
        Me.Hide()
        admin.Show()
    End Sub

End Class