using System;
using WIA;

namespace KaupischITC.ScanWIA
{
	/// <summary>
	/// Stellt Methoden Bereit, um auf ein WIA-Gerät zuzugreifen
	/// </summary>
	public static class WiaDevice
	{
		/// <summary>
		/// Ermittelt die Referenz auf ein WIA-Gerät
		/// </summary>
		/// <param name="deviceID">ID des Geräts</param>
		/// <returns>Referenz auf das WIA-Gerät mit der angegebenen ID</returns>
		public static Device FromDeviceId(string deviceID)
		{
			DeviceManager deviceManager = new DeviceManagerClass();
			foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
				if (deviceInfo.DeviceID == deviceID)
					return deviceInfo.Connect();
			throw new ArgumentException("Kein Device mit der ID '"+deviceID+"' gefunden.");
		}


		/// <summary>
		/// Zeigt den Dialog zur Geräteauswahl an
		/// </summary>
		/// <returns>das Gerät, das der Benutzer ausgewählt hat</returns>
		public static Device FromUserDialog(WiaDeviceType deviceType = WiaDeviceType.UnspecifiedDeviceType,bool alwaysSelectDevice = false)
		{			
			CommonDialogClass wiaDialog = new CommonDialogClass();
			return wiaDialog.ShowSelectDevice(deviceType,alwaysSelectDevice,false);
		}
		

		/// <summary>
		/// Ermittelt das erste verfügbare WIA-Gerät
		/// </summary>
		/// <returns>das erste verfügbare WIA-Gerät</returns>
		public static Device GetFirstScannerDevice()
		{
			DeviceManager deviceManager = new DeviceManagerClass();
			foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
				if (deviceInfo.Type==WiaDeviceType.ScannerDeviceType)
					return deviceInfo.Connect();
			throw new ArgumentException("Keinen Scanner gefunden.");
		}


		public static ScannerDevice AsScannerDevice(this Device device)
		{
			return new ScannerDevice(device);
		}
	}
}
