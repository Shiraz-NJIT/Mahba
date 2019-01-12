using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NjitSoftware
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //// Add the event handler for handling UI thread exceptions to the event.
            //Application.ThreadException += new ThreadExceptionEventHandler(Program.Form1_UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         
            global::Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Njit.Program.Telerik.PersianRadGridLocalizationProvider();
            Application.Run(View.Main.Instance);
        }
      
        // The thread we start up to demonstrate non-UI exception handling. 
       static void newThread_Execute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        //private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        //{
        //    DialogResult result = DialogResult.Cancel;
        //    try
        //    {
        //        result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            MessageBox.Show("خطای برنامه",
        //                "خطای برنامه");
        //        }
        //        finally
        //        {
        //            Application.Exit();
        //        }
        //    }

        //    // Exits the program when the user clicks Abort.
        //    if (result == DialogResult.Abort)
        //        Application.Exit();
        //}

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "خطای ارتباط با سرور. لطفا با مدیر سیستم تماس گرفته و خطای زیر را گزارش کنید \n";

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
           string errorMsg = "خطای ارتباط با سرور. لطفا با مدیر سیستم تماس گرفته و خطای زیر را گزارش کنید \n";

            errorMsg = errorMsg + e.Message + "\nلیست خطاها:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg.Substring(0,1000), title);
        }
    }
}
