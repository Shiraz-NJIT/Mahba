using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WIA;

namespace KaupischITC.ScanWIA
{
	/// <summary>
	/// Stellt Methoden Bereit, um auf ein WIA-Scanner-Gerät zuzugreifen
	/// </summary>
	public class ScannerDevice
	{
		public Device Device { get; private set; }
		public ScannerDeviceSettings DeviceSettings { get; private set; }
		public ScannerPictureSettings PictureSettings { get; private set; }

		public ScannerDevice(Device device)
		{
			this.Device = device;
			this.DeviceSettings = new ScannerDeviceSettings(device.Properties);
			this.PictureSettings = new ScannerPictureSettings(device.Items[1].Properties);
		}



		/// <summary>
		/// Führt den für angegebene Gerät konfigurierten Scan-Job aus und liest die gescannten Bilder aus
		/// </summary>
		/// <param name="scannerDevice"></param>
		/// <returns></returns>
		public IEnumerable<Image> PerformScan(string formatID = FormatID.wiaFormatTIFF)
		{
			ImageFile imageFile = (ImageFile)this.Device.Items[1].Transfer(formatID);
			return ScannerDevice.ExtractImages(imageFile);
		}


		/// <summary>
		/// Liest alle Bilder aus dem angegebenen ImageFile-Objekt aus 
		/// </summary>
		/// <param name="imageFile">das ImageFile-Objekt, dessen enthaltene Bilder ausgelesen werden sollen</param>
		/// <returns>eine Auflistung der Bilder, die das ImageFile-Objekt enthält</returns>
		private static IEnumerable<Image> ExtractImages(ImageFile imageFile)
		{
			for (int frame = 1;frame<=imageFile.FrameCount;frame++)
			{
				imageFile.ActiveFrame = frame;
				ImageFile argbImage = imageFile.ARGBData.get_ImageFile(imageFile.Width,imageFile.Height);

				Image result = Image.FromStream(new MemoryStream((byte[])argbImage.FileData.get_BinaryData()));
				yield return result;
			}
		}
	}
}
