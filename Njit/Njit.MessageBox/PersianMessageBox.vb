Imports System
Imports System.Windows.Forms
Imports System.Runtime.Serialization.Formatters.Binary

Namespace Global
    Namespace System
        Namespace Windows
            Namespace Forms
                Public Class PersianMessageBox
                    Public Shared Function Show(text As String) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(text)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(owner, text)
                    End Function



                    Public Shared Function Show(text As String, caption As String) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(text, caption)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(owner, text, caption)
                    End Function



                    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(text, caption, buttons)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(owner, text, caption, buttons)
                    End Function



                    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(text, caption, buttons, icon)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(owner, text, caption, buttons, icon)
                    End Function



                    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(text, caption, buttons, icon, defaultButton)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As MessageBoxIcon, defaultButton As MessageBoxDefaultButton) As DialogResult
                        Return Njit.MessageBox.VDialog.Show(owner, text, caption, buttons, icon, defaultButton)
                    End Function



                    'public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, string name, string description, MessageBoxButtons notAllowToSave)
                    '{
                    '    return Show(null, text, caption, buttons, icon, defaultButton, name, description, notAllowToSave);
                    '}
                    'public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, string name, string description, MessageBoxButtons notAllowToSave)
                    '{
                    '    return Njit.MessageBox.VDialog.Show(owner, text, caption, buttons, icon, defaultButton);
                    '}

                    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, rightToLeft As RightToLeft) As DialogResult
                        Return GetResult(Show(Nothing, text, caption, GetButtons(buttons), icon, defaultButton, _
                            rightToLeft, False, Nothing, Nothing, Nothing, Nothing, _
                            Nothing))
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, _
                        rightToLeft As RightToLeft) As DialogResult
                        Return GetResult(Show(owner, text, caption, GetButtons(buttons), icon, defaultButton, _
                            rightToLeft, False, Nothing, Nothing, Nothing, Nothing, _
                            Nothing))
                    End Function



                    Public Shared Function Show(text As String, caption As String, buttons As MessageBoxButtons, icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, rightToLeft As RightToLeft, _
                        Instruction As String) As DialogResult
                        Return GetResult(Show(Nothing, text, caption, GetButtons(buttons), icon, defaultButton, _
                            rightToLeft, False, Instruction, Nothing, Nothing, Nothing, _
                            Nothing))
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As MessageBoxButtons, icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, _
                        rightToLeft As RightToLeft, Instruction As String) As DialogResult
                        Return GetResult(Show(owner, text, caption, GetButtons(buttons), icon, defaultButton, _
                            rightToLeft, False, Instruction, Nothing, Nothing, Nothing, _
                            Nothing))
                    End Function



                    Public Shared Function Show(text As String, caption As String, buttons As Njit.MessageBox.VDialogButton(), icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, rightToLeft As RightToLeft, _
                        rightToLeftLayout As Boolean, Instruction As String, footerText As String, messageBoxName As String, messageBoxDescription As String, notAllowToSaveButtons As Njit.MessageBox.VDialogButton()) As Njit.MessageBox.VDialogResult
                        Return Show(Nothing, text, caption, buttons, icon, defaultButton, _
                            rightToLeft, rightToLeftLayout, Instruction, footerText, messageBoxName, messageBoxDescription, _
                            notAllowToSaveButtons)
                    End Function


                    Public Shared Function Show(owner As IWin32Window, text As String, caption As String, buttons As Njit.MessageBox.VDialogButton(), icon As Njit.MessageBox.VDialogIcon, defaultButton As Njit.MessageBox.VDialogDefaultButton, _
                        rightToLeft As RightToLeft, rightToLeftLayout As Boolean, Instruction As String, footerText As String, messageBoxName As String, messageBoxDescription As String, _
                        notAllowToSaveButtons As Njit.MessageBox.VDialogButton()) As Njit.MessageBox.VDialogResult
                        Dim allowSave As Boolean = Not String.IsNullOrEmpty(messageBoxName)
                        If allowSave Then
                            If SavedResponses.Where(Function(t) t.Name = messageBoxName).Count() > 0 Then
                                Return SavedResponses.Where(Function(t) t.Name = messageBoxName).First().Result
                            End If
                        End If
                        Dim vd As New Njit.MessageBox.VDialog()
                        vd.Owner = owner
                        vd.Content = text
                        vd.WindowTitle = caption
                        vd.Buttons = buttons
                        vd.MainIcon = icon
                        vd.DefaultButton = defaultButton
                        vd.MainInstruction = Instruction
                        vd.RightToLeft = rightToLeft
                        vd.RightToLeftLayout = rightToLeftLayout
                        vd.FooterText = footerText
                        If allowSave Then
                            vd.VerificationText = "این پیام دیگر نمایش داده نشود"
                        End If
                        vd.Show()
                        If allowSave AndAlso vd.VerificationFlagChecked = CheckState.Checked AndAlso (notAllowToSaveButtons.Where(Function(t) t.VDialogResult = vd.Result).Count() = 0) Then
                            If SavedResponses.Where(Function(t) t.Name = messageBoxName).Count() = 1 Then
                                Dim info As Njit.MessageBox.PersianMessageBoxInfo = SavedResponses.Where(Function(t) t.Name = messageBoxName).[Single]()
                                info.Description = messageBoxDescription
                                info.Result = vd.Result
                            Else
                                SavedResponses.Add(New Njit.MessageBox.PersianMessageBoxInfo(messageBoxName, messageBoxDescription, vd.Result))
                            End If
                            Save()
                        End If
                        Return vd.Result
                    End Function



                    Public Shared Sub Save()
                        Dim datafile As String = Global.System.IO.Path.Combine(Global.System.IO.Path.GetDirectoryName(Application.ExecutablePath), "SavedResponses.data")
                        Dim bf As New BinaryFormatter()
                        Dim stream As Global.System.IO.Stream = Nothing
                        Try
                            stream = New Global.System.IO.FileStream(datafile, Global.System.IO.FileMode.Create)
                            bf.Serialize(stream, SavedResponses)
                        Catch
                        Finally
                            If stream IsNot Nothing Then
                                stream.Close()
                                stream.Dispose()
                            End If
                        End Try
                    End Sub



                    Private Shared _SavedResponses As List(Of Njit.MessageBox.PersianMessageBoxInfo)
                    Public Shared Property SavedResponses() As List(Of Njit.MessageBox.PersianMessageBoxInfo)
                        Get
                            If _SavedResponses Is Nothing Then
                                _SavedResponses = Load()
                            End If
                            Return _SavedResponses
                        End Get
                        Set(value As List(Of Njit.MessageBox.PersianMessageBoxInfo))
                            _SavedResponses = value
                        End Set
                    End Property

                    Public Shared Function Load() As List(Of Njit.MessageBox.PersianMessageBoxInfo)
                        Dim datafile As String = Global.System.IO.Path.Combine(Global.System.IO.Path.GetDirectoryName(Global.System.Windows.Forms.Application.ExecutablePath), "SavedResponses.data")
                        If Global.System.IO.File.Exists(datafile) Then
                            Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                            Dim stream As Global.System.IO.Stream = Nothing
                            Try
                                stream = New Global.System.IO.FileStream(datafile, Global.System.IO.FileMode.Open)
                                Return CType(bf.Deserialize(stream), List(Of Njit.MessageBox.PersianMessageBoxInfo))
                            Catch
                                Return New List(Of Njit.MessageBox.PersianMessageBoxInfo)()
                            Finally
                                If stream IsNot Nothing Then
                                    stream.Close()
                                    stream.Dispose()
                                End If
                            End Try
                        Else
                            Return New List(Of Njit.MessageBox.PersianMessageBoxInfo)()
                        End If
                    End Function



                    Private Shared Function GetResult(vDialogResult As Njit.MessageBox.VDialogResult) As DialogResult
                        Select Case vDialogResult
                            Case Njit.MessageBox.VDialogResult.Abort
                                Return DialogResult.Abort
                            Case Njit.MessageBox.VDialogResult.Cancel, Njit.MessageBox.VDialogResult.Close
                                Return DialogResult.Cancel
                            Case Njit.MessageBox.VDialogResult.Ignore
                                Return DialogResult.Ignore
                            Case Njit.MessageBox.VDialogResult.No, Njit.MessageBox.VDialogResult.NoToAll
                                Return DialogResult.No
                            Case Njit.MessageBox.VDialogResult.OK, Njit.MessageBox.VDialogResult.[Continue]
                                Return DialogResult.OK
                            Case Njit.MessageBox.VDialogResult.Retry
                                Return DialogResult.Retry
                            Case Njit.MessageBox.VDialogResult.Yes, Njit.MessageBox.VDialogResult.YesToAll
                                Return DialogResult.Yes
                            Case Else
                                Return DialogResult.None
                        End Select
                    End Function



                    Private Shared Function GetDefaultButton(defaultButton As MessageBoxDefaultButton) As Njit.MessageBox.VDialogDefaultButton
                        Select Case defaultButton
                            Case MessageBoxDefaultButton.Button1
                                Return Njit.MessageBox.VDialogDefaultButton.Button1
                            Case MessageBoxDefaultButton.Button2
                                Return Njit.MessageBox.VDialogDefaultButton.Button2
                            Case MessageBoxDefaultButton.Button3
                                Return Njit.MessageBox.VDialogDefaultButton.Button3
                            Case Else
                                Throw New Exception()
                        End Select
                    End Function



                    Private Shared Function GetIcon(icon As MessageBoxIcon) As Njit.MessageBox.VDialogIcon
                        Select Case icon
                            Case MessageBoxIcon.[Error]
                                Return Njit.MessageBox.VDialogIcon.[Error]
                            Case MessageBoxIcon.Information
                                Return Njit.MessageBox.VDialogIcon.Information
                            Case MessageBoxIcon.None
                                Return Njit.MessageBox.VDialogIcon.None
                            Case MessageBoxIcon.Question
                                Return Njit.MessageBox.VDialogIcon.Question
                            Case MessageBoxIcon.Warning
                                Return Njit.MessageBox.VDialogIcon.Warning
                            Case Else
                                Throw New Exception()
                        End Select
                    End Function



                    Private Shared Function GetButtons(buttons As MessageBoxButtons) As Njit.MessageBox.VDialogButton()
                        Select Case buttons
                            Case MessageBoxButtons.AbortRetryIgnore
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Abort), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Retry), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Ignore)}
                            Case MessageBoxButtons.OK
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.OK)}
                            Case MessageBoxButtons.OKCancel
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.OK), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Cancel)}
                            Case MessageBoxButtons.RetryCancel
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Retry), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Cancel)}
                            Case MessageBoxButtons.YesNo
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Yes), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.No)}
                            Case MessageBoxButtons.YesNoCancel
                                Return New Njit.MessageBox.VDialogButton() {New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Yes), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.No), New Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Cancel)}
                            Case Else
                                Throw New Exception()
                        End Select
                    End Function
                End Class
            End Namespace
        End Namespace
    End Namespace
End Namespace
