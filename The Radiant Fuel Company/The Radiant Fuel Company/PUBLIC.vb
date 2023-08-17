Module CUS_REC
    'public variables to use with array and postions on the array 
    Public count As Integer
    Public pos As Integer
    'temporary storage variables for Validation
    Public temp_tel_number As Integer
    Public temp_mobi_number As Integer
    Public temp_tank_cap As Integer
    Public temp_minimum_lev As Integer
    Public temp_burn_rate As Integer
    Public temp_address As String
    Public temp_full_Name As String
    'the boolean point for Validation 
    Public ok_tel_number As Boolean
    Public ok_mobi_number As Boolean
    Public ok_tank_cap As Boolean
    Public ok_minimum_lev As Boolean
    Public ok_burn_rate As Boolean
    Public ok_address As Boolean
    Public ok_full_Name As Boolean
    'public struture for the program 
    Public Structure CustomersRecType
        <VBFixedString(4)> Public customer_id As Integer
        <VBFixedString(15)> Public full_Name As String
        <VBFixedString(30)> Public address As String
        <VBFixedString(15)> Public tel_number As String
        <VBFixedString(15)> Public mobi_number As String
        Public tank_cap As Integer
        Public fuel_lev As Integer
        Public minimum_lev As Integer
        Public burn_rate As Integer
    End Structure
    Public customers(0) As CustomersRecType
End Module
