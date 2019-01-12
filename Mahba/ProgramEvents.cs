using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    internal class ProgramEvents
    {
        public static event EventHandler<EventArgs> UserRolesChanged;
        public static void OnUserRolesChanged()
        {
            if (UserRolesChanged != null)
                UserRolesChanged(null, EventArgs.Empty);
        }

        public static event EventHandler UserLogsChanged;
        public static void OnUserLogsChanged()
        {
            if (UserLogsChanged != null)
                UserLogsChanged(null, EventArgs.Empty);
        }

        public static event EventHandler ProgramSettingsChanged;
        public static void OnProgramSettingsChanged()
        {
            if (ProgramSettingsChanged != null)
                ProgramSettingsChanged(null, EventArgs.Empty);
        }

        public static event EventHandler LendingsChanged;
        public static void OnLendingsChanged()
        {
            if (LendingsChanged != null)
                LendingsChanged(null, EventArgs.Empty);
        }

        public static event EventHandler PersonsChanged;
        public static void OnPersonsChanged()
        {
            if (PersonsChanged != null)
                PersonsChanged(null, EventArgs.Empty);
        }

        public static event EventHandler DocumentsChanged;
        public static void OnDocumentsChanged()
        {
            if (DocumentsChanged != null)
                DocumentsChanged(null, EventArgs.Empty);
        }
    }
}
