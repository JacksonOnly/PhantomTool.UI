using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

public class Class_04 : DataGridViewColumnHeaderCell
{
	private Point field_23;

	private Size field_24;

	private bool field_25 = false;

	private Point field_26 = default;

	private CheckBoxState field_27 = CheckBoxState.UncheckedNormal;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Delegate_01 field_28;

	public event Delegate_01 event_01
	{
		[CompilerGenerated]
		add
		{
			Delegate_01 delegate_ = field_28;
			Delegate_01 delegate_2;
			do
			{
				delegate_2 = delegate_;
				Delegate_01 value2 = (Delegate_01)Delegate.Combine(delegate_2, value);
				delegate_ = Interlocked.CompareExchange(ref field_28, value2, delegate_2);
			}
			while ((object)delegate_ != delegate_2);
		}
		[CompilerGenerated]
		remove
		{
			Delegate_01 delegate_ = field_28;
			Delegate_01 delegate_2;
			do
			{
				delegate_2 = delegate_;
				Delegate_01 value2 = (Delegate_01)Delegate.Remove(delegate_2, value);
				delegate_ = Interlocked.CompareExchange(ref field_28, value2, delegate_2);
			}
			while ((object)delegate_ != delegate_2);
		}
	}

	protected override void Paint(Graphics arg_01, Rectangle arg_02, Rectangle arg_03, int arg_04, DataGridViewElementStates arg_05, object arg_06, object arg_07, string arg_08, DataGridViewCellStyle arg_09, DataGridViewAdvancedBorderStyle arg_10, DataGridViewPaintParts arg_11)
	{
		Rectangle cellBounds = arg_03;
		base.Paint(arg_01, arg_02, cellBounds, arg_04, arg_05, arg_06, arg_07, arg_08, arg_09, arg_10, arg_11);
		Point point = default;
		Size glyphSize = CheckBoxRenderer.GetGlyphSize(arg_01, CheckBoxState.UncheckedNormal);
		int x = (int)((double)arg_03.Location.X + (double)arg_03.Width / 2.0 - (double)(glyphSize.Width / 2));
		point.X = x;
		int y = (int)((double)arg_03.Location.Y + (double)arg_03.Height / 2.0 - (double)(glyphSize.Height / 2));
		point.Y = y;
		field_26 = arg_03.Location;
		field_23 = point;
		field_24 = glyphSize;
		if (field_25)
		{
			field_27 = CheckBoxState.CheckedNormal;
		}
		else
		{
			field_27 = CheckBoxState.UncheckedNormal;
		}
		Point point2 = field_23;
		CheckBoxState checkBoxState = field_27;
		Point glyphLocation = point2;
		CheckBoxRenderer.DrawCheckBox(arg_01, glyphLocation, checkBoxState);
	}

	protected override void OnMouseClick(DataGridViewCellMouseEventArgs arg_01)
	{
		int num = arg_01.X + field_26.X;
		int y = arg_01.Y + field_26.Y;
		int x = num;
		Point point = new Point(x, y);
		if (point.X >= field_23.X && point.X <= field_23.X + field_24.Width && point.Y >= field_23.Y && point.Y <= field_23.Y + field_24.Height)
		{
			field_25 = !field_25;
			field_28?.Invoke(arg_01.ColumnIndex, field_25);
			DataGridView.InvalidateCell(this);
		}
		base.OnMouseClick(arg_01);
	}
}
