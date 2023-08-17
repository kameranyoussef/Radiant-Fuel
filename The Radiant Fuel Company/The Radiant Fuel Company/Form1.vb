Imports System.IO.File
Public Class Form1

    'To add New customer when the add button is click and store new customers in the array 


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles add_button.Click

        If ok_tel_number And ok_tank_cap And ok_minimum_lev And ok_address And ok_full_Name = True Then
            count = count + 1
            ReDim Preserve customers(UBound(customers) + 1)
            customers(count).customer_id = TextBox1.Text
            customers(count).full_Name = TextBox2.Text
            customers(count).address = TextBox3.Text
            customers(count).tel_number = TextBox4.Text
            customers(count).mobi_number = TextBox5.Text
            customers(count).tank_cap = TextBox6.Text
            customers(count).fuel_lev = TextBox7.Text
            customers(count).minimum_lev = TextBox9.Text
            customers(count).burn_rate = TextBox10.Text

            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox9.Clear()
            TextBox10.Clear()
            TextBox11.Clear()
            TextBox1.Text = count + 1

            ok_tel_number = False
            ok_mobi_number = False
            ok_tank_cap = False
            ok_minimum_lev = False
            ok_burn_rate = False
            ok_address = False
            ok_full_Name = False
        Else
            MsgBox("Error Please Check for the missing input and Enter Customer Details.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    'this sub is for finding existing customers which they are store in the array already and display thier details 

    Private Sub find_button_Click(sender As System.Object, e As System.EventArgs) Handles find_button.Click
        Dim find, i As Integer
        Dim customers_id As Boolean

        i = 1
        find = TextBox12.Text
        TextBox1.Text = find
        While customers_id = False And i <= count
            If find = customers(i).customer_id Then
                customers_id = True
                pos = i
                TextBox2.Text = customers(i).full_Name
                TextBox3.Text = customers(i).address
                TextBox4.Text = customers(i).tel_number
                TextBox5.Text = customers(i).mobi_number
                TextBox6.Text = customers(i).tank_cap
                TextBox7.Text = customers(i).fuel_lev
                TextBox9.Text = customers(i).minimum_lev
                TextBox10.Text = customers(i).burn_rate
            End If
            i += 1
        End While
        If customers_id = False Then
            MsgBox("No customers Found.", MsgBoxStyle.Critical)
        End If
    End Sub

    'this sub is for editing and update existing customers details 
    'get customers details for me the array point and display the details 

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modify.Click
        customers(pos).full_Name = TextBox2.Text
        customers(pos).address = TextBox3.Text
        customers(pos).tel_number = TextBox4.Text
        customers(pos).mobi_number = TextBox5.Text
        customers(pos).tank_cap = TextBox6.Text
        customers(pos).fuel_lev = TextBox7.Text
        customers(pos).minimum_lev = TextBox9.Text
        customers(pos).burn_rate = TextBox10.Text
        MsgBox("It will be Saved Automatically.", MsgBoxStyle.Exclamation)
    End Sub

    'this sub is for deleteing existing which they are store in the array already 

    Private Sub delete_button_Click(sender As System.Object, e As System.EventArgs) Handles delete_button.Click

        If ok_tel_number And ok_mobi_number And ok_tank_cap And ok_minimum_lev And ok_burn_rate And ok_address And ok_full_Name = True Then

        ElseIf pos <> count Then
            customers(pos) = customers(count)

            ReDim Preserve customers(UBound(customers) - 1)
            count += -1

            ' after the customer is delete clear all the text boxs 
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox9.Clear()
            TextBox10.Clear()
            TextBox11.Clear()
        Else
            MsgBox("Find The Customer First THEN Delete The Customer.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    'the sub is to clear all the text boxs 

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox12.Text = count + 1
        TextBox1.Text = count + 1
    End Sub

    'this sub is for saving files by replacing customers.dat with new customers.dat with the new customers 

    Private Sub save_file()
        Dim i As Integer

        FileClose(1)
        Delete("customers.dat")
        If count <> 0 Then
            FileOpen(1, "customers.dat", OpenMode.Random, , , Len(customers(0)))
            For i = 1 To count
                FilePut(1, customers(i), i)
            Next i
            FileClose(1)
        End If
        MsgBox("File Saved.", MsgBoxStyle.Critical)
        End
    End Sub

    'this sub is when the form closeing show a message box if the user would like to save thier new customers 

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As Integer
        response = MsgBox("Do you really wanna close the program", MsgBoxStyle.YesNo)
        If response = MsgBoxResult.Yes Then
            response = MsgBox("Do you wish to save the file ?", MsgBoxStyle.YesNo)
            If response <> 2 Then
                If response = MsgBoxResult.Yes Then
                    Call save_file()
                ElseIf MsgBoxResult.No Then
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    'this sub is for when the proggram first start running the program checks 
    'if there is any existing customers if yes the load up else show message as no existing customers

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        If Exists("customers.dat") Then
            i = 0
            FileOpen(1, "customers.dat", OpenMode.Random, , , Len(customers(0)))
            count = FileLen("customers.dat") / Len(customers(0))
            Do While Not EOF(1)
                i += 1
                ReDim Preserve customers(UBound(customers) + 1)
                FileGet(1, customers(i), i)
            Loop
        Else
            MsgBox("No existing customers", MsgBoxStyle.Information)
            count = 0
        End If
        TextBox12.Text = count + 1
        TextBox1.Text = count + 1
        TextBox1.Select()
    End Sub

    'this sub is to Calculat the fuel and show the total price and total amount 

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brun.Click
        Dim i As Integer
        Dim total_amo As Integer
        Dim topupamount As Integer
        Dim Cus_cost As Decimal
        Dim price As Decimal
        Dim total_pri As Decimal
        Dim fuel_used As Decimal

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()


        price = 1.5

        For i = 1 To count
            fuel_used = customers(i).burn_rate * 7
            customers(i).fuel_lev = customers(i).fuel_lev - fuel_used
            If customers(i).fuel_lev <= customers(i).minimum_lev Then
                If customers(i).fuel_lev < 0 Then
                    customers(i).fuel_lev = 0
                End If
                topupamount = customers(i).tank_cap - customers(i).fuel_lev
                Cus_cost = topupamount * price
                total_amo = total_amo + topupamount
            End If
            total_pri = total_amo * price
            customers(i).fuel_lev = customers(i).tank_cap

            If total_pri = 0 Then
                TextBox11.Text = " No Customer Needs Fuel "
            Else
                TextBox11.Text += "Customer:  " & customers(i).customer_id & vbCrLf & "Full Name: " & customers(i).full_Name & vbCrLf & "Address: " & customers(i).address & vbCrLf & "Telephone Number: " & customers(i).tel_number & vbCrLf & "Mobile Number : " & customers(i).mobi_number & vbCrLf & "Total Amount: " & topupamount & vbCrLf & "Fuel Price: £" & Cus_cost & vbCrLf & "Total Fuel Price = £" & total_pri
            End If
        Next
    End Sub

    'this sub is for Validating customer full name 

    Private Sub TextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        temp_full_Name = TextBox2.Text
        If (Len(temp_full_Name) = 0) Or (Len(temp_full_Name) > 15) Or (IsNumeric(temp_full_Name)) Then
            ok_full_Name = False
            MsgBox("Error - Customer name must be 1 to 15 characters.", MsgBoxStyle.Information)
            TextBox2.Clear()
            TextBox2.Select()
        Else
            ok_full_Name = True
        End If
    End Sub

    'this sub is for Validating customers Address

    Private Sub TextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        temp_address = TextBox3.Text
        If (Len(temp_address) = 0) Or (Len(temp_address) > 30) Or (IsNumeric(temp_address)) Then
            ok_address = False
            MsgBox("Error - Customer Address must be 1 to 30 characters.", MsgBoxStyle.Information)
            TextBox3.Clear()
            TextBox3.Select()
        Else
            ok_address = True
        End If
    End Sub

    'this sub is for Validating customers Telephone number 

    Private Sub TextBox4_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox4.Validating
        temp_tel_number = Val(TextBox4.Text)
        If (temp_tel_number < 1) Or (temp_tel_number > 999999999999999) Then
            ok_tel_number = False
            MsgBox("Error - Customer Telephone Number must be in the range 1 to 15.", MsgBoxStyle.Information)
            TextBox4.Clear()
            TextBox4.Select()
        Else
            ok_tel_number = True
        End If
    End Sub

    'this sub is for Validating customers tank capacity 

    Private Sub TextBox6_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox6.Validating
        temp_tank_cap = Val(TextBox6.Text)
        If (temp_tank_cap = 0) Or (temp_tank_cap < 0) Or (temp_tank_cap > 1000) Then
            ok_tank_cap = False
            MsgBox("Error - Tank Capacity must be in the range 0 to 1000.", MsgBoxStyle.Information)
            TextBox6.Clear()
            TextBox6.Select()
        Else
            ok_tank_cap = True
        End If
    End Sub

    'this sub is for Validating customer minimum fuel level 

    Private Sub TextBox9_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox9.Validating
        temp_minimum_lev = Val(TextBox9.Text)
        If (temp_minimum_lev = 0) Or (temp_minimum_lev < 0) Or (temp_minimum_lev > 1000) Then
            ok_minimum_lev = False
            MsgBox("Error - Minimum Level must be in the range 0 to 1000.", MsgBoxStyle.Information)
            TextBox9.Clear()
            TextBox9.Select()
        Else
            ok_minimum_lev = True
        End If
    End Sub

End Class