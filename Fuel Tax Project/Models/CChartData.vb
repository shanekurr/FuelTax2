﻿Imports System
Imports System.Collections.Generic

Public Class CChartData
    Public Property Year As Integer
    Public Property Year2 As Integer
    Public Property ValueS1 As Integer
    Public Property ValueS2 As Integer
    Public Property ValueString As String
    Public Property ValueString2 As String
    Public Property newSize As Integer
    Public Property size As Integer
    Public Property newVal As Double
    Public Property oldVal As Nullable(Of Double)
    Public Property ValueDbl As Double
    Public Property ValueLong As Long

End Class

Public Class DropDownData
    Public Property endDD As Integer
    Public Property startDD As Integer
    Public Property RadioValue As Integer
    Public Property county As String
    Public Property month As String


End Class

Public Class FileData
    Public Property FilePath As String
    Public Property fName As String
    Public Property months As String
    Public Property years As Integer
    Public Property report As String
    Public Property radio As Integer

End Class