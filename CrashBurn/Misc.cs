using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Imports System
//Imports System.Management
//Imports System.Collections.Generic
//Imports System.Linq
//Imports System.Text
//Imports System.Data.SqlClient
//Imports System.Windows.Forms
//Imports System.Runtime.CompilerServices

namespace CommonLib
{
    public static class Misc
    {

        //''' <summary>
        //''' Miscellaneous tools and helper methods.
        //''' </summary>
        //Public Module Toolbox

        //    ''' <summary>
        //    ''' Returns a list of installed printers.
        //    ''' </summary>
        //    ''' <returns></returns>
        //    Public Function GetPrinters() As String()
        //        Try
        //            Dim printers As List(Of String) = New List(Of String)
        //            Dim queryString As String = "SELECT Name FROM Win32_Printer"
        //            Using query As ManagementObjectSearcher = New ManagementObjectSearcher(queryString)
        //                Using results As ManagementObjectCollection = query.Get()
        //                    For Each mo As ManagementObject In results
        //                        printers.Add(CType(mo("Name"), String))
        //                    Next
        //                End Using
        //            End Using
        //            Return printers.ToArray()
        //        Catch ex As Exception
        //            Throw ex
        //        End Try
        //    End Function

        //    ''' <summary>
        //    ''' Returns the driver and port for a specified printer.
        //    ''' </summary>
        //    ''' <param name="printerName"></param>
        //    ''' <param name="printerDriver"></param>
        //    ''' <param name="printerPort"></param>
        //    Public Sub GetPrinterInfo(ByVal printerName As String, ByRef printerDriver As String, ByRef printerPort As String)
        //        Try
        //            printerDriver = ""
        //            printerPort = ""
        //            Dim queryString As String = String.Format("SELECT Name, DriverName, PortName FROM Win32_Printer")
        //            Using query As ManagementObjectSearcher = New ManagementObjectSearcher(queryString)
        //                Using results As ManagementObjectCollection = query.Get()
        //                    For Each mo As ManagementObject In results
        //                        If String.Compare(CType(mo("Name"), String), printerName, True) = 0 Then
        //                            printerDriver = CType(mo("DriverName"), String)
        //                            printerPort = CType(mo("PortName"), String)
        //                            Return
        //                        End If
        //                    Next
        //                End Using
        //            End Using
        //        Catch ex As Exception
        //            Throw ex
        //        End Try
        //    End Sub

        //    ''' <summary>
        //    ''' Returns a flattened list of all controls in a controlcollection.
        //    ''' </summary>
        //    ''' <param name="controls"></param>
        //    ''' <returns></returns>
        //    Public Function GetControls(ByVal controls As System.Windows.Forms.Control.ControlCollection) As List(Of Control)
        //        Dim ctrlList As List(Of Control) = New List(Of Control)
        //        Try
        //            For Each c As Control In controls
        //                ctrlList.Add(c)
        //                If c.Controls.Count > 0 Then
        //                    ctrlList.AddRange(GetControls(c.Controls))
        //                End If
        //            Next
        //        Catch ex As Exception

        //        End Try
        //        Return ctrlList
        //    End Function
    }
}
