Imports System.IO
Module Module1
    Sub Main()
        Dim newmanifest As String = "resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'"
        Dim list As String()
        Dim dataDirectory As String = String.Format("{0}\", Environment.CurrentDirectory)
        list = Directory.GetFiles(dataDirectory, "__resource.lua", SearchOption.AllDirectories)
        For Each file As String In list
            Dim sb As New Text.StringBuilder()
            Dim myFilePath As String = file
            Dim mySearchToken As String = "resource_manifest_version"
            For Each line As String In IO.File.ReadLines(myFilePath)
                If (String.Compare(Left(line, mySearchToken.Length), mySearchToken, True) <> 0) Then
                    'keep other lines
                    sb.AppendLine(line)
                End If
            Next
            sb.Insert(0, newmanifest + vbNewLine)
            IO.File.WriteAllText(myFilePath, sb.ToString())
        Next
    End Sub
End Module
