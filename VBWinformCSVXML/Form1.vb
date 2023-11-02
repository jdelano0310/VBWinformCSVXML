Imports System.IO
Imports System.Xml
Imports ClosedXML.Excel

Public Class Form1
    Private Sub UpdateStatusLabel(statusMsg As String)

        ' this is just a message to indicate there is stuff going on
        lblStatus.Text = statusMsg
        Application.DoEvents()

    End Sub

    Private Sub FillDictionaryFromExcelFile(dict As Dictionary(Of String, String))

        ' using ClosedXML package, read the Excel file into the dictionary
        Dim workbook As New XLWorkbook(txtExcelFile.Text)
        Dim ws1 As IXLWorksheet = workbook.Worksheet(1)
        Dim row As Int16 = 1
        Dim idValue As String = ws1.Cell(row, 1).Value.ToString()

        Do While idValue.Trim.Length > 0
            dict.Add(idValue, idValue)
            row += 1
            idValue = ws1.Cell(row, 1).Value.ToString()
        Loop

        workbook.Dispose()

    End Sub

    Private Sub FillDictionaryFromCSVFile(dict As Dictionary(Of String, String))

        ' open the id file (either Excel or CSV)
        Dim idFile As New StreamReader(txtExcelFile.Text)

        ' loop through the file and add the ID to the dictionary object
        Dim idLine As String = ""
        Do While Not idFile.EndOfStream
            idLine = idFile.ReadLine
            dict.Add(idLine, idLine)
        Loop

        idFile.Close()

    End Sub
    Private Sub btnSelectExcel_Click(sender As Object, e As EventArgs) Handles btnSelectExcel.Click

        ' display an open file dialog to pick the excel file that contains the IDs
        With ofDLG
            .Filter = "Excel Files (*.xlsx) | *.xlsx | CSV Files (*.csv) | *.csv"
            .Title = "Select ID File"
            .FileName = "*.xlsx"
        End With

        If ofDLG.ShowDialog = DialogResult.Cancel Then Exit Sub

        txtExcelFile.Text = ofDLG.FileName

    End Sub

    Private Sub btnSelectXML_Click(sender As Object, e As EventArgs) Handles btnSelectXML.Click

        ' display an open file dialog to pick the XML file to comapre the IDs to
        With ofDLG
            .Filter = "XML Files (*.xlm) | *.xml"
            .Title = "Select XML File"
            .FileName = "*.xml"
        End With

        If ofDLG.ShowDialog = DialogResult.Cancel Then Exit Sub

        txtXMLFile.Text = ofDLG.FileName
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click

        ' compare the selected file contents

        ' check the text in the textbox that displays the selected excel file for the presense of
        ' either xlsx or csv - if neither is found then this can't continue
        If txtExcelFile.Text.ToUpper.IndexOf("XLSX") = -1 And txtExcelFile.Text.ToUpper.IndexOf("CSV") = -1 Then
            MsgBox("No Excel / CSV file has been selected", MsgBoxStyle.Critical, "Missing File Selection")
            Exit Sub
        End If

        ' check the text in the textbox that displays the selected xml file for the presense of
        ' xmlm if it isn't found then this can't continue
        If txtXMLFile.Text.ToUpper.IndexOf("XML") = -1 Then
            MsgBox("No XML file has been selected", MsgBoxStyle.Critical, "Missing File Selection")
            Exit Sub
        End If

        ' open the ID file and place the contents in a dictionary object for searching
        UpdateStatusLabel("Reading ID File")
        Dim idDict As New Dictionary(Of String, String)

        If txtExcelFile.Text.ToUpper.IndexOf("XLSX") > 0 Then
            ' an Excel file was selected
            FillDictionaryFromExcelFile(idDict)
        Else
            FillDictionaryFromCSVFile(idDict)
        End If

        ' load the XML file into a document object, loop through each message element
        ' search the dictionary created above, update the XML if required
        UpdateStatusLabel("Comparing XML File")
        Dim xmlFile As New XmlDocument()
        Dim nodeList As XmlNodeList
        Dim messageID As String

        ' create a backup of the XML file, overwrite previous backup (if one exists)
        File.Copy(txtXMLFile.Text, txtXMLFile.Text.Replace(".xml", ".backup"), True)

        xmlFile.Load(txtXMLFile.Text)
        nodeList = xmlFile.SelectNodes("//Message") ' select all the message parts of the xml file

        ' loop through all the messages found in the xml file
        For Each nd As XmlElement In nodeList
            messageID = nd.ChildNodes(0).InnerText

            If idDict.ContainsKey(messageID) Then
                ' the id was found in the file loaded into the dictionary previously
                ' set the indicator to 1 if it is currently 0
                If nd.ChildNodes(1).InnerText = "0" Then nd.ChildNodes(1).InnerText = "1"
            Else
                ' the id was not found - remove it from the xml file
                nd.ParentNode.RemoveChild(nd)
            End If
        Next
        xmlFile.Save(txtXMLFile.Text)

        UpdateStatusLabel("Done")

    End Sub
End Class
