namespace KaupischITC.ScanWIA
{
	/// <summary>
	/// Transparency Adapter Capabilities
	/// </summary>
	[WiaPropertyId(3106)]
	public enum TransparencyCapabilities  /*WIA_DPS_TRANSPARENCY_CAPABILITIES*/
	{
		DynamicFrameSupport=0x01,
		StaticFrameSupport=0x02
	}
}