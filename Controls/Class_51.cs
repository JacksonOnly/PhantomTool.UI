using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[ToolboxItem(false)]
public class Class_51 : ToolStripDropDown, IMessageFilter
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Control field_379;

	private ToolStripControlHost field_380;

	private Control field_381;

	private const int field_382 = 513;

	private const int field_383 = 516;

	private const int field_384 = 519;

	private const int field_385 = 161;

	private const int field_386 = 164;

	private const int field_387 = 167;

	public Control property_03
	{
		[CompilerGenerated]
		get
		{
			return field_379;
		}
		[CompilerGenerated]
		private set
		{
			field_379 = value;
		}
	}

	public Class_51(Control arg_01)
	{
		if (arg_01 == null)
		{
			throw new ArgumentNullException("content");
		}
		property_03 = arg_01;
		Control control = property_03;
		Point empty = Point.Empty;
		control.Location = empty;
		field_380 = new ToolStripControlHost(property_03);
		AutoClose = false;
		AutoSize = false;
		DoubleBuffered = true;
		ResizeRedraw = false;
		ToolStripControlHost toolStripControlHost = field_380;
		Padding empty2;
		field_380.Margin = (empty2 = Padding.Empty);
		Padding padding;
		toolStripControlHost.Padding = (padding = empty2);
		Padding padding2;
		Margin = (padding2 = padding);
		Padding = padding2;
		Size minimumSize = property_03.MinimumSize;
		MinimumSize = minimumSize;
		Size size = property_03.Size;
		arg_01.MinimumSize = size;
		Size maximumSize = property_03.MaximumSize;
		MaximumSize = maximumSize;
		Size size2 = property_03.Size;
		arg_01.MaximumSize = size2;
		Size size3 = property_03.Size;
		Size = size3;
		bool tabStop;
		property_03.TabStop = (tabStop = true);
		TabStop = tabStop;
		Items.Add(field_380);
		Application.AddMessageFilter(this);
	}

	public void method_369(Control arg_01, Size arg_02 = default(Size))
	{
		if (arg_01 == null)
		{
			throw new ArgumentNullException("opener");
		}
		field_381 = arg_01;
		int num = ((arg_02.Width == 0) ? ClientRectangle.Width : arg_02.Width);
		int num2 = ((arg_02.Height == 0) ? property_03.Height : arg_02.Height);
		num2 += Padding.Size.Height + property_03.Margin.Size.Height;
		Rectangle workingArea = Screen.FromControl(field_381).WorkingArea;
		Control control = field_381;
		int left = field_381.ClientRectangle.Left;
		int bottom = field_381.ClientRectangle.Bottom;
		int num3 = field_381.ClientRectangle.Left + num;
		int num4 = field_381.ClientRectangle.Bottom + num2;
		int num5 = num3;
		int num6 = bottom;
		Rectangle r = new Rectangle(left, num6, num5, num4);
		Rectangle rect = control.RectangleToScreen(r);
		int left2 = field_381.ClientRectangle.Left;
		int bottom2 = field_381.ClientRectangle.Bottom;
		int num7 = left2;
		Point point = new Point(num7, bottom2);
		if (!workingArea.Contains(rect))
		{
			Control control2 = field_381;
			int left3 = field_381.ClientRectangle.Left;
			int num8 = field_381.ClientRectangle.Top - num2;
			int num9 = field_381.ClientRectangle.Left + num;
			int top = field_381.ClientRectangle.Top;
			int num10 = num9;
			int num11 = num8;
			Rectangle r2 = new Rectangle(left3, num11, num10, top);
			rect = control2.RectangleToScreen(r2);
			if (workingArea.Contains(rect))
			{
				int left4 = field_381.ClientRectangle.Left;
				int num12 = field_381.ClientRectangle.Top - num2;
				int num13 = left4;
				point = new Point(num13, num12);
			}
		}
		Width = num;
		Height = num2;
		Control control3 = field_381;
		Point position = point;
		Control control4 = control3;
		Show(control4, position, ToolStripDropDownDirection.BelowRight);
	}

	protected override void Dispose(bool arg_01)
	{
		if (arg_01)
		{
			if (property_03 != null)
			{
				property_03.Dispose();
				property_03 = null;
			}
			Application.RemoveMessageFilter(this);
		}
		bool disposing = arg_01;
		base.Dispose(disposing);
	}

	protected override void OnSizeChanged(EventArgs arg_01)
	{
		if (property_03 != null)
		{
			Control control = property_03;
			Size size = Size;
			control.MinimumSize = size;
			Control control2 = property_03;
			Size size2 = Size;
			control2.MaximumSize = size2;
			Control control3 = property_03;
			Size size3 = Size;
			control3.Size = size3;
			Control control4 = property_03;
			Point empty = Point.Empty;
			control4.Location = empty;
		}
		base.OnSizeChanged(arg_01);
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "MapWindowPoints", ExactSpelling = true)]
	public static extern int method_370(IntPtr arg_01, IntPtr arg_02, [In][Out] ref Point arg_03, int arg_04);

	public bool PreFilterMessage(ref Message arg_01)
	{
		if (Visible)
		{
			switch (arg_01.Msg)
			{
			case 161:
			case 164:
			case 167:
			case 513:
			case 516:
			case 519:
			{
				IntPtr lParam = arg_01.LParam;
				int num = (int)(long)lParam;
				short num2 = (short)(num & 0xFFFF);
				short num3 = (short)((num >> 16) & 0xFFFF);
				short num4 = num2;
				int num5 = num3;
				int num6 = num4;
				Point arg_2 = new Point(num6, num5);
				IntPtr arg_3 = ((arg_01.Msg == 513 || arg_01.Msg == 516 || arg_01.Msg == 519) ? arg_01.HWnd : IntPtr.Zero);
				method_370(arg_3, Handle, ref arg_2, 1);
				Rectangle clientRectangle = ClientRectangle;
				Point pt = arg_2;
				if (!clientRectangle.Contains(pt))
				{
					short num7 = num2;
					int num8 = num3;
					int num9 = num7;
					arg_2 = new Point(num9, num8);
					method_370(arg_3, field_381.Handle, ref arg_2, 1);
					clientRectangle = field_381.ClientRectangle;
					Point pt2 = arg_2;
					if (!clientRectangle.Contains(pt2))
					{
						Close();
					}
				}
				break;
			}
			}
		}
		return false;
	}
}
