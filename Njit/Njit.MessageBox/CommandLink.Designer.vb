﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommandLink
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
        Me.components = New Global.System.ComponentModel.Container
        Me.Timer = New Global.System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer
        '
        Me.Timer.Interval = 50
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer As Global.System.Windows.Forms.Timer
End Class
