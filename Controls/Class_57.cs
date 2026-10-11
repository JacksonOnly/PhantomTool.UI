using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Class_57 : Button
{
	private int field_417 = 0;

	private int field_418 = 0;

	private Color field_419 = Color.PaleVioletRed;

	[Category("RJ Code Advance")]
	public int property_16
	{
		get
		{
			return field_417;
		}
		set
		{
			field_417 = value;
			Invalidate();
		}
	}

	[Category("RJ Code Advance")]
	public int property_17
	{
		get
		{
			return field_418;
		}
		set
		{
			field_418 = value;
			Invalidate();
		}
	}

	[Category("RJ Code Advance")]
	public Color property_18
	{
		get
		{
			return field_419;
		}
		set
		{
			field_419 = value;
			Invalidate();
		}
	}

	[Category("RJ Code Advance")]
	public Color property_19
	{
		get
		{
			return BackColor;
		}
		set
		{
			BackColor = value;
		}
	}

	[Category("RJ Code Advance")]
	public Color property_20
	{
		get
		{
			return ForeColor;
		}
		set
		{
			ForeColor = value;
		}
	}

	public Class_57()
	{
		FlatStyle = FlatStyle.Flat;
		FlatAppearance.BorderSize = 0;
		Size = new Size(150, 40);
		Color mediumSlateBlue = Color.MediumSlateBlue;
		BackColor = mediumSlateBlue;
		Color white = Color.White;
		ForeColor = white;
		Resize += method_431;
	}

	private GraphicsPath method_429(Rectangle arg_01, int arg_02)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = (float)arg_02 * 2f;
		graphicsPath.StartFigure();
		float num2 = arg_01.X;
		float num3 = arg_01.Y;
		float num4 = num2;
		graphicsPath.AddArc(num4, num3, num, num, 180f, 90f);
		float num5 = (float)arg_01.Right - num;
		float num6 = arg_01.Y;
		float num7 = num5;
		graphicsPath.AddArc(num7, num6, num, num, 270f, 90f);
		float num8 = (float)arg_01.Right - num;
		float num9 = (float)arg_01.Bottom - num;
		float num10 = num8;
		graphicsPath.AddArc(num10, num9, num, num, 0f, 90f);
		float num11 = arg_01.X;
		float num12 = (float)arg_01.Bottom - num;
		float num13 = num11;
		graphicsPath.AddArc(num13, num12, num, num, 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	protected override void OnPaint(PaintEventArgs arg_01)
	{
		base.OnPaint(arg_01);
		Rectangle clientRectangle = ClientRectangle;
		int num = -field_417;
		int num2 = -field_417;
		int num3 = num;
		Rectangle rect = clientRectangle;
		Rectangle arg_2 = Rectangle.Inflate(rect, num3, num2);
		int num4 = 2;
		if (field_417 > 0)
		{
			num4 = field_417;
		}
		if (field_418 > 2)
		{
			using (GraphicsPath path = method_429(clientRectangle, field_418))
			{
				using GraphicsPath path2 = method_429(arg_2, field_418 - field_417);
				Color backColor = Parent.BackColor;
				float num5 = num4;
				Color color = backColor;
				using Pen pen = new Pen(color, num5);
				Color color2 = field_419;
				float num6 = field_417;
				Color color3 = color2;
				using Pen pen2 = new Pen(color3, num6);
				arg_01.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				Region region = new Region(path);
				Region = region;
				arg_01.Graphics.DrawPath(pen, path);
				if (field_417 >= 1)
				{
					arg_01.Graphics.DrawPath(pen2, path2);
				}
				return;
			}
		}
		arg_01.Graphics.SmoothingMode = SmoothingMode.None;
		Region region2 = new Region(clientRectangle);
		Region = region2;
		if (field_417 >= 1)
		{
			Color color4 = field_419;
			float num7 = field_417;
			Color color5 = color4;
			using Pen pen3 = new Pen(color5, num7);
			pen3.Alignment = PenAlignment.Inset;
			Graphics graphics = arg_01.Graphics;
			int num8 = Width - 1;
			int num9 = Height - 1;
			int num10 = num8;
			int num11 = 0;
			int num12 = 0;
			Pen pen4 = pen3;
			graphics.DrawRectangle(pen4, num12, num11, num10, num9);
		}
	}

	protected override void OnHandleCreated(EventArgs arg_01)
	{
		base.OnHandleCreated(arg_01);
		Parent.BackColorChanged += method_430;
	}

	private void method_430(object arg_01, EventArgs arg_02)
	{
		Invalidate();
	}

	private void method_431(object arg_01, EventArgs arg_02)
	{
		if (field_418 > Height)
		{
			field_418 = Height;
		}
	}
}
