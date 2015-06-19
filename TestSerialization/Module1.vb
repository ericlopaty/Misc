Imports System.Xml.Serialization
Imports System.IO

Module Module1

    Dim pCol As Collection
    Dim p As Persist

    Sub Main()

        Dim s As String
        s = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        Console.WriteLine(s)
        'pCol = New Collection()
        'pCol.Add("one one one one", "one")
        'pCol.Add("two two two two", "two")
        'pCol.Add("three three three three", "three")
        'pCol.Add("four four four four", "four")
        'pCol.Add("five five five five", "five")
        'Serialize2()
        'Deserialize2()
        'For i As Integer = 1 To pCol.Count
        '    Console.WriteLine(pCol(i))
        'Next

    End Sub

    Sub Serialize()
        Dim writer As New StreamWriter("c:\temp\operatorstats.xml")
        Dim x As New XmlSerializer(p.GetType())
        x.Serialize(writer, p)
        writer.Close()
    End Sub

    Sub Serialize2()
        Dim writer As New StreamWriter("c:\temp\operatorstats.xml")
        Dim x As New XmlSerializer(pCol.GetType())
        x.Serialize(writer, pCol)
        writer.Close()
    End Sub

    Sub Deserialize()
        Dim xmlReader As New StreamReader("c:\temp\operatorstats.xml")
        Dim x As New XmlSerializer(p.GetType())
        p = x.Deserialize(xmlReader)
        xmlReader.Close()
    End Sub

    Sub Deserialize2()
        Dim xmlReader As New StreamReader("c:\temp\operatorstats.xml")
        Dim x As New XmlSerializer(pCol.GetType())
        pCol = x.Deserialize(xmlReader)
        xmlReader.Close()
    End Sub

End Module
