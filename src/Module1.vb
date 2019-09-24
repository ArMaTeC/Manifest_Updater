Imports System.IO
Module Module1
    Sub Main()

        Dim newmanifest As String = "resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'"
        Dim intInput As Integer = 0
        Do
            Integer.TryParse(doMenu, intInput)
            Select Case intInput
                Case 1
                    newmanifest = "resource_manifest_version '00000000-0000-0000-0000-000000000000'"
                    Exit Do
                    Exit Select
                Case 2
                    newmanifest = "resource_manifest_version '77731fab-63ca-442c-a67b-abc70f28dfa5'"
                    Exit Do
                    Exit Select
                Case 3
                    newmanifest = "resource_manifest_version 'f15e72ec-3972-4fe4-9c7d-afc5394ae207'"
                    Exit Do
                    Exit Select
                Case 4
                    newmanifest = "resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'"
                    Exit Do
                    Exit Select
                Case 5
                    newmanifest = "resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'"
                    Exit Do
                    Exit Select
                Case 6
                    Exit Do
                    Exit Sub
            End Select
        Loop
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
    Function doMenu() As Char
        Console.Clear()
        Console.WriteLine("")
        Console.WriteLine("Main Menu - Enter 1,2,3,4,5 or 6")

        Console.WriteLine("1. For Manifest Version 00000000-0000-0000-0000-000000000000 (no date)")
        Console.WriteLine("   The natives.lua file natives_21e43a33.lua will be used for client-side Lua.")
        Console.WriteLine("2. For Manifest Version 77731fab-63ca-442c-a67b-abc70f28dfa5 (2016-12) ")
        Console.WriteLine("   No changes.This Is the minimum operating level for FXServer.")
        Console.WriteLine("3. For Manifest Version f15e72ec-3972-4fe4-9c7d-afc5394ae207 (2017-04-08) ")
        Console.WriteLine("   The natives.lua file natives_0193d0af.lua will be used for client-side Lua. This represents the state of NativeDB in early April of 2017.")
        Console.WriteLine("4. For Manifest Version 44febabe-d386-4d18-afbe-5e627f4af937 (2017-06-07) ")
        Console.WriteLine("   The natives.lua file natives_universal.lua will be used For client-side Lua. This Is a universal natives.lua file, which should be able to be switched to without having to change your scripts. It also represents a more recent (2017-06-05) snapshot of NativeDB.")
        Console.WriteLine("5. For Manifest Version 05cfa83c-a124-4cfa-a768-c24a5811d8f9 (2017-06-04) ")
        Console.WriteLine("   Scripts will now be registered as a game network script. This Is required for networking entities.")
        Console.WriteLine("   CREATE_VEHICLE And similar functions behave differently When passing True, True as network object flags. See network objects for more information.")


        Console.WriteLine("6. Exit" & vbNewLine)
        Console.WriteLine("Enter your choice: ")
        Dim s As ConsoleKeyInfo = Console.ReadKey
        Return s.KeyChar
    End Function
End Module
