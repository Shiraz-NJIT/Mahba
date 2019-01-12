Imports System.Windows.Forms

''' <summary>
''' Helper methods…
''' </summary>
<HideModuleName()> _
Friend Module Extensions

    Public Function [If](Of T)(ByVal Expression As Boolean, ByVal TruePart As T, ByVal FalsePart As T) As T
        If Expression Then
            Return TruePart
        End If
        Return FalsePart
    End Function

    Public Function GetButtonName(ByVal button As VDialogResult) As String

        Select Case button

            Case VDialogResult.Abort
                Return My.Resources.AbortText

            Case VDialogResult.Cancel
                Return My.Resources.CancelText

            Case VDialogResult.Close
                Return My.Resources.CloseText

            Case VDialogResult.Continue
                Return My.Resources.ContinueText

            Case VDialogResult.Ignore
                Return My.Resources.IgnoreText

            Case VDialogResult.No
                Return My.Resources.NoText

            Case VDialogResult.NoToAll
                Return My.Resources.NoToAllText

            Case VDialogResult.OK
                Return My.Resources.OKText

            Case VDialogResult.Retry
                Return My.Resources.RetryText

            Case VDialogResult.Yes
                Return My.Resources.YesText

            Case VDialogResult.YesToAll
                Return My.Resources.YesToAllText

            Case Else
                Return My.Resources.NoneText
        End Select

    End Function

    Public Function MakeDialogResult(ByVal Result As VDialogResult) As DialogResult
        Select Case Result
            Case VDialogResult.Abort
                Return DialogResult.Abort
            Case VDialogResult.Cancel, VDialogResult.Close
                Return DialogResult.Cancel
            Case VDialogResult.Ignore
                Return DialogResult.Ignore
            Case VDialogResult.No, VDialogResult.NoToAll
                Return DialogResult.No
            Case VDialogResult.OK, VDialogResult.Continue
                Return DialogResult.OK
            Case VDialogResult.Retry
                Return DialogResult.Retry
            Case VDialogResult.Yes, VDialogResult.YesToAll
                Return DialogResult.Yes
            Case Else
                Return DialogResult.None
        End Select
    End Function

    Public Function MakeVDialogDefaultButton(ByVal DefaultButton As MessageBoxDefaultButton) As VDialogDefaultButton
        Select Case DefaultButton
            Case MessageBoxDefaultButton.Button1
                Return VDialogDefaultButton.Button1
            Case MessageBoxDefaultButton.Button2
                Return VDialogDefaultButton.Button2
            Case MessageBoxDefaultButton.Button3
                Return VDialogDefaultButton.Button3
            Case Else
                Return VDialogDefaultButton.None
        End Select
    End Function
End Module
