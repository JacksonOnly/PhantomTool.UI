using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Class_52
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct Struct_03
	{
		public int field_398;

		public int field_399;

		public int field_400;

		public int field_401;
	}

	private bool field_388 = false;

	private bool field_389 = false;

	private const int field_390 = 132;

	private const int field_391 = 131072;

	private const int field_392 = 1;

	private const int field_393 = 2;

	private const int field_394 = 8;

	private const int field_395 = 131072;

	private const int field_396 = 133;

	private const int field_397 = 28;

	[DllImport("dwmapi.dll", EntryPoint = "DwmExtendFrameIntoClientArea")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern int method_371(IntPtr arg_01, ref Struct_03 arg_02);

	[DllImport("dwmapi.dll", EntryPoint = "DwmSetWindowAttribute")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern int method_372(IntPtr arg_01, int arg_02, ref int arg_03, int arg_04);

	[DllImport("dwmapi.dll", EntryPoint = "DwmIsCompositionEnabled")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static extern int method_373(ref int arg_01);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool method_374()
	{
		if (Environment.OSVersion.Version.Major < 6)
		{
			return false;
		}
		method_375(out var arg_);
		return arg_;
	}

	[DllImport("dwmapi.dll", EntryPoint = "DwmIsCompositionEnabled")]
	private static extern int method_375(out bool arg_01);

	[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
	private static extern IntPtr method_376(int arg_01, int arg_02, int arg_03, int arg_04, int arg_05, int arg_06);

	private bool method_377()
	{
		if (Environment.OSVersion.Version.Major >= 6)
		{
			int arg_ = 0;
			method_373(ref arg_);
			return arg_ == 1;
		}
		return false;
	}

	public void method_378(Form arg_01)
	{
		int arg_2 = 2;
		method_372(arg_01.Handle, 2, ref arg_2, 4);
		Struct_03 arg_3 = new Struct_03
		{
			field_401 = 1,
			field_398 = 0,
			field_399 = 0,
			field_400 = 0
		};
		method_371(arg_01.Handle, ref arg_3);
	}
}
