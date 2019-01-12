using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Resources;

namespace Njit.Program.Controls.Design
{
    public delegate object TransactionAwareParammedMethod(IDesignerHost host, object param);
    public abstract class DesignerTransactionUtility
    {
        public static object DoInTransaction(IDesignerHost host, string transactionName, TransactionAwareParammedMethod method, object param)
        {
            DesignerTransaction tran = null;
            object retVal = null;
            try
            {
                tran = host.CreateTransaction(transactionName);
                retVal = method(host, param);
            }
            catch (CheckoutException ex)
            {
                if (ex != CheckoutException.Canceled)
                    throw ex;
            }
            catch
            {
                if (tran != null)
                {
                    tran.Cancel();
                    tran = null;
                }
                throw;
            }
            finally
            {
                if (tran != null)
                    tran.Commit();
            }
            return retVal;
        }
    }
}