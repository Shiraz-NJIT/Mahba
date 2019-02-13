using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class SearchBoxSettingController
    {
        #region Default
        public static Model.Common.SearchBoxSetting GetDefault()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int userCode = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;

            int ArchiveId = (int)EnumArchives.Student;
            try
            {
                ArchiveId = Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID);
            }
            catch
            {
                ArchiveId = (int)EnumArchives.Student;
            }
            Model.Common.SearchBoxSetting sbs = dc.SearchBoxSettings.Where(q => q.UserCode == userCode && q.ArchiveSelected == ArchiveId).FirstOrDefault();
            if (sbs != null)
            {
                return sbs;
            }
            else
            {

                if (ArchiveId == (int)EnumArchives.Student)
                {
                    sbs = new Model.Common.SearchBoxSetting();
                    sbs.ArchiveSelected = (int)EnumArchives.Student;
                    sbs.UserCode = userCode;
                    sbs.ArchiveFieldSelectedIndex = (int)EnumArchiveField.شماره_دانشجویی_کارمندی_اساتید;
                    sbs.ConditionIdSelectedIndex = 1;
                    return sbs;
                }
                else
                {
                    sbs = new Model.Common.SearchBoxSetting();
                    sbs.ArchiveSelected = ArchiveId;
                    sbs.UserCode = userCode;
                    sbs.ArchiveFieldSelectedIndex = (int)EnumArchiveField.نام_خانوادگی;
                    sbs.ConditionIdSelectedIndex = 0;
                    return sbs;

                }

            }



        }
        enum EnumArchives
        {
            Student = 10,
            Teacher = 11,
            Personel = 12
        }
        enum EnumArchiveField
        {
            شماره_دانشجویی_کارمندی_اساتید = 0,
            نام_خانوادگی = 3,

        }
        #endregion

        #region Edit

        internal static bool Update(Model.Common.SearchBoxSetting s)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var sbs = db.SearchBoxSettings.Where(a => a.ID == s.ID).FirstOrDefault();
                sbs.ArchiveSelected = s.ArchiveSelected;
                sbs.ArchiveFieldSelectedIndex = s.ArchiveFieldSelectedIndex;
                sbs.ConditionIdSelectedIndex = s.ConditionIdSelectedIndex;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region insert


        internal static bool Insert(int archivefieldselectedindex, int conditionselectedindex)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                int userCode = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;

                int ArchiveId = (int)EnumArchives.Student;
                try
                {
                    ArchiveId = Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID);
                }
                catch
                {
                    ArchiveId = (int)EnumArchives.Student;
                }
                Model.Common.SearchBoxSetting sbs = db.SearchBoxSettings.Where(q => q.UserCode == userCode && q.ArchiveSelected == ArchiveId).FirstOrDefault();
                if (sbs == null)
                {
                    sbs = new Model.Common.SearchBoxSetting();
                    sbs.ArchiveSelected = ArchiveId;
                    sbs.UserCode = userCode;
                    sbs.ArchiveFieldSelectedIndex = archivefieldselectedindex;
                    sbs.ConditionIdSelectedIndex = conditionselectedindex;
                    db.SearchBoxSettings.InsertOnSubmit(sbs);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    sbs.ArchiveSelected = ArchiveId;
                    sbs.ArchiveFieldSelectedIndex = archivefieldselectedindex;
                    sbs.ConditionIdSelectedIndex = conditionselectedindex;
                    return Update(sbs);
                }
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}
