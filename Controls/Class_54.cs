using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Class_54 : TextBox
{
	private const int field_407 = 5377;

	private string field_408;

	public string property_11
	{
		get
		{
			return field_408;
		}
		set
		{
			field_408 = value;
			method_403();
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessage")]
	private static extern int method_400(IntPtr arg_01, int arg_02, IntPtr arg_03, string arg_04);

	private void method_403()
	{
		if (IsHandleCreated && field_408 != null)
		{
			method_400(Handle, 5377, (IntPtr)1, field_408);
		}
	}

	protected override void OnHandleCreated(EventArgs arg_01)
	{
		base.OnHandleCreated(arg_01);
		method_403();
	}
}
