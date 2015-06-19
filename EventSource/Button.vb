' Managed server (event source)
Option Explicit On
Option Strict On

Imports System
Imports System.Runtime.InteropServices

Namespace EventSource

    Public Delegate Sub ClickDelegate(ByVal x As Integer, ByVal y As Integer)
    Public Delegate Sub ResizeDelegate()
    Public Delegate Sub PulseDelegate()

    ' Step 1: Defines an event sink interface (ButtonEvents) to be
    ' implemented by the COM sink.
    <GuidAttribute("1A585C4D-3371-48dc-AF8A-AFFECC1B0967"), _
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch), _
        ComVisible(True)> _
    Public Interface ButtonEvents
        Sub Click(ByVal x As Integer, ByVal y As Integer)
        Sub Resize()
        Sub Pulse()
    End Interface

    ' Step 2: Connects the event sink interface to a class 
    ' by passing the namespace and event sink interface
    ' ("EventSource.ButtonEvents, EventSrc").
    <ComSourceInterfaces(GetType(ButtonEvents))> _
    Public Class Button

        Public Event Click As ClickDelegate
        Public Event Resize As ResizeDelegate
        Public Event Pulse As PulseDelegate

        Public Sub CauseClickEvent(ByVal x As Integer, ByVal y As Integer)
            RaiseEvent Click(x, y)
        End Sub

        Public Sub CauseResizeEvent()
            RaiseEvent Resize()
        End Sub

        Public Sub CausePulse()
            RaiseEvent Pulse()
        End Sub

    End Class

End Namespace



