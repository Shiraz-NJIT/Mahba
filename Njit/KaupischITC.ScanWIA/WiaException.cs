using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KaupischITC.ScanWIA
{
	/// <summary>
	/// Die Ausnahme, die ausgelöst wird, wenn ein WIA-Fehler aufgetreten ist
	/// </summary>
	[Serializable]
	public class WiaException : Exception
	{
		/// <summary>
		/// Enthält die Beschreibungen der WIA-Fehler
		/// </summary>
		private static Dictionary<WiaError,string> messageMappings = new Dictionary<WiaError,string>
		{
			{ WiaError.GeneralError,"GeneralError." },
			{ WiaError.PaperJam,"PaperJam." },
			{ WiaError.PaperEmpty,"PaperEmpty." },
			{ WiaError.PaperProblem,"PaperProblem." },
			{ WiaError.Offline,"Offline." },
			{ WiaError.Busy,"Busy." },
			{ WiaError.WarmingUp,"WarmingUp." },
			{ WiaError.UserIntervention,"UserIntervention" },
			{ WiaError.ItemDeleted,"ItemDeleted." },
			{ WiaError.DeviceCommunication,"DeviceCommunication." },
			{ WiaError.InvalidCommand,"InvalidCommand." },
			{ WiaError.IncorrectHardwareSetting,"IncorrectHardwareSetting." },
			{ WiaError.DeviceLocked,"DeviceLocked." },
			{ WiaError.ExceptionInDriver,"ExceptionInDriver." },
			{ WiaError.InvalidDriverResponse,"InvalidDriverResponse." },
			{ WiaError.CoverOpen,"CoverOpen." },
			{ WiaError.LampOff,"LampOff." },
			{ WiaError.NoDeviceAvailable,"NoDeviceAvailable." },
		};


		/// <summary>
		/// Initialisiert eine neue Instanz der WiaException-Klasse mit einer angegebenen Fehlermeldung und einem Verweis auf die innere Ausnahme, die diese Ausnahme ausgelöst hat. 
		/// </summary>
		/// <param name="message">die Fehlermeldung</param>
		/// <param name="innerException">die innere Ausnahme, die diese Ausnahme ausgelöst hat</param>
		public WiaException(string message,Exception innerException) : base(message,innerException)
		{}


		/// <summary>
		/// Initialisiert eine neue Instanz der WiaException-Klasse mit COM-Ausnahme
		/// </summary>
		/// <param name="comException">die COM-Ausnahme</param>
		/// <returns>die aus der COM-Ausnahme initialisierte WIA-Ausnahme</returns>
		public static WiaException FromComException(COMException comException)
		{
			return new WiaException(WiaException.GetMessageFromComException(comException),comException);
		}

		
		/// <summary>
		/// Ermittelt für eine (WIA-)COM-Ausnahme die zugehörige Fehlermeldung
		/// </summary>
		/// <param name="ex">die (WIA-)COM-Ausnahme</param>
		/// <returns>die zur (WIA-)COM-Ausnahme gehörende Fehlermeldung</returns>
		public static string GetMessageFromComException(COMException ex)
		{
			WiaError wiaError = (WiaError)ex.ErrorCode;
			int errorCode;
			if (!Int32.TryParse(wiaError.ToString(),out errorCode))
			{				
				string message = wiaError.ToString();
				WiaException.messageMappings.TryGetValue(wiaError,out message);
				return message;
			}
			else
				return ex.Message;
		}

	}
}
