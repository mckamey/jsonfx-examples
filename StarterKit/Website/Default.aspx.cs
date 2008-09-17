using System;

public partial class _Default : System.Web.UI.Page
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);

#if DEBUG
		// Pretty-Print rendering helps when debugging through script
		this.StyleImport.IsDebug = true;
		this.ScriptInclude.IsDebug = true;
#else
		// improve the Yslow rating
		JsonFx.Handlers.CompiledBuildResult.EnableStreamCompression(this.Context);
#endif
	}
}
