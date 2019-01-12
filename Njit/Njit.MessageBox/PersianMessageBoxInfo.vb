<Serializable> _
Public Class PersianMessageBoxInfo
    Public Sub New(Name As String, Description As String, Result As VDialogResult)
        Me.Name = Name
        Me.Description = Description
        Me.Result = Result
    End Sub


    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
        End Set
    End Property

    Private _Result As VDialogResult
    Public Property Result() As VDialogResult
        Get
            Return _Result
        End Get
        Set(value As VDialogResult)
            _Result = value
        End Set
    End Property

    Public ReadOnly Property ResultDescription() As String
        Get
            Return GetResultDescription(Me.Result)
        End Get
    End Property

    Private Function GetResultDescription(vDialogResult As MessageBox.VDialogResult) As String
        Select Case vDialogResult
            Case vDialogResult.Abort
                Return "انصراف"
            Case vDialogResult.Cancel
                Return "انصراف"
            Case vDialogResult.Close
                Return "خروج"
            Case vDialogResult.[Continue]
                Return "ادامه"
            Case vDialogResult.Ignore
                Return "صرف نظر"
            Case vDialogResult.No
                Return "خیر"
            Case vDialogResult.NoToAll
                Return "خیر برای همه"
            Case vDialogResult.None
                Return "بی جواب"
            Case vDialogResult.OK
                Return "تایید"
            Case vDialogResult.Retry
                Return "سعی مجدد"
            Case vDialogResult.Yes
                Return "بله"
            Case vDialogResult.YesToAll
                Return "بله برای همه"
            Case Else
                Throw New Exception()
        End Select
    End Function
End Class
