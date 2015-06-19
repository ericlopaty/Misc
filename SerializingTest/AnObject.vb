Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Xml

<Serializable()> _
Public Class AnObject

    Public pol_num As String
    Public CmdKey As String
    Public NodeId As String
    Public Params As Dictionary(Of String, Object)

    Public ASSEMBLE_PKG_PKG_TYPE As String
    Public ASSEMBLE_PKG_POL_NUM As String
    Public AUTOCHANGECASE_XML_INPUT_DATA_STREAM As String
    Public AUTOCLEARFROMDESKTOP_ID As String
    Public AUTODISPLAYPAGES_DOMAIN As String
    Public AUTODISPLAYPAGES_HANDLE As String
    Public AUTODISPLAYPAGES_ID As String
    Public AUTODISPLAYPAGES_PAGE As String
    Public AUTOQUERY3_ARCHIVE As Boolean
    Public AUTOQUERY3_ARCHIVELOWERCASE As Boolean
    Public AUTOQUERY3_DEBIT As Boolean
    Public AUTOQUERY3_DOCUMENT As Boolean
    Public AUTOQUERY3_FOLDER As Boolean
    Public AUTOQUERY3_POLICY_NUMBER As String
    Public AUTOQUERY_ARCHIVE As Boolean
    Public AUTOQUERY_DOCUMENT As Boolean
    Public AUTOQUERY_FOLDER As Boolean
    Public AUTOQUERY_NAME As String
    Public AUTORETRIEVE_DOMAIN As String
    Public AUTORETRIEVE_ID As String
    Public AUTORETRIEVE_ON_PAGE_VIEWER_CLOSE_ACTION As Integer
    Public AUTORETRIEVE_PAGE_VIEWER_OPEN_POSITION As Integer
    Public AUTORETRIEVE_RETRIEVAL_TYPE As Integer
    Public AUTORETRIEVE_ROUTE_TO_QUEUE As String
    Public CALL_SCHEDULE_APPOINT_CSO As String
    Public CALL_SCHEDULE_APPOINT_PLC As Boolean
    Public CALL_SCHEDULE_APPOINT_SERVICEDESC As String
    Public CALL_SCHEDULE_DISPLAY_TIMEZONE As String
    Public CALL_SCHEDULE_RETURN_TIME As Boolean
    Public DOCEXPORTIMAGEPAGES_DIRECTORY As String
    Public DOCEXPORTIMAGEPAGES_DOMAIN As String
    Public DOCEXPORTIMAGEPAGES_FORMAT As Integer
    Public DOCEXPORTIMAGEPAGES_ID As String

    Public Sub New()
        Params = New Dictionary(Of String, Object)
    End Sub

    Public Sub FromXML(ByVal xml As String)
        Params = New Dictionary(Of String, Object)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.LoadXml(xml)
        Dim nodeList As XmlNodeList
        nodeList = xmlDoc.SelectNodes("//AppConnector/Params/*")
        For Each node As XmlNode In nodeList
            MessageBox.Show(node.Name + ": " + node.InnerText)
            If node.Name = "KEY_NUM" Then
                MessageBox.Show(String.Format("{0}", CType(node.InnerText, Integer)))
            End If
        Next
    End Sub

    Public Function ToXML() As String
        Dim xmlDoc As New XmlDocument()
        Dim xmlDecl As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        Dim rootNode As XmlElement = xmlDoc.CreateElement("AppConnector")
        xmlDoc.InsertBefore(xmlDecl, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(rootNode)
        '// Create a new <Category> element and add it to the root node
        Dim parentNode As XmlElement = xmlDoc.CreateElement("Params")
        '// Set attribute name and value!
        'parentNode.SetAttribute("ID", "01");
        xmlDoc.DocumentElement.PrependChild(parentNode)
        For Each key As String In Params.Keys
            Dim node As XmlElement = xmlDoc.CreateElement(key)
            Dim text As XmlText = xmlDoc.CreateTextNode(Params(key).ToString())
            parentNode.AppendChild(node)
            node.AppendChild(text)
        Next
        Return xmlDoc.OuterXml
    End Function



End Class
