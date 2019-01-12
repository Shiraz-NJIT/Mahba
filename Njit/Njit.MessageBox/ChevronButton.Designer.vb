<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChevronButton
    Inherits Global.System.Windows.Forms.Button

    'Control overrides dispose to clean up the component list.
    <Global.System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Control Designer
    Private components As Global.System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <Global.System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'ChevronButton
        '
        Me.BackColor = Global.System.Drawing.Color.Transparent
        Me.FlatAppearance.BorderColor = Global.System.Drawing.SystemColors.Control
        Me.FlatAppearance.BorderSize = 0
        Me.FlatAppearance.MouseDownBackColor = Global.System.Drawing.Color.Transparent
        Me.FlatAppearance.MouseOverBackColor = Global.System.Drawing.Color.Transparent
        Me.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
        Me.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
        Me.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
        Me.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Visible = False
        Me.ResumeLayout(False)

    End Sub

End Class

