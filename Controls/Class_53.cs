using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Class_53 : ComboBox
{
	private readonly Class_51 field_402;

	private readonly ListBox field_403;

	private Font field_404;

	private bool field_405;

	private Enum_06 field_406;

	[Category("Behavior")]
	[DefaultValue(false)]
	[Description("Specifies whether items in the list portion of the combobo are sorted.")]
	public bool property_04
	{
		get
		{
			return Sorted;
		}
		set
		{
			ListBox listBox = field_403;
			bool flag = value;
			listBox.Sorted = flag;
			bool flag2 = value;
			Sorted = flag2;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool property_05
	{
		get
		{
			return DroppedDown || field_402.Visible;
		}
		set
		{
			field_402.Visible = false;
			bool droppedDown = value;
			DroppedDown = droppedDown;
		}
	}

	[DefaultValue(Enum_06.field_409)]
	[Description("How strings are matched against the user input")]
	[Browsable(true)]
	[Category("Behavior")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public Enum_06 property_06
	{
		get
		{
			return field_406;
		}
		set
		{
			if (field_406 != value)
			{
				field_406 = value;
				if (field_402.Visible)
				{
					method_379();
				}
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public AutoCompleteSource property_07
	{
		get
		{
			return AutoCompleteSource;
		}
		set
		{
			AutoCompleteSource = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public AutoCompleteStringCollection property_08
	{
		get
		{
			return AutoCompleteCustomSource;
		}
		set
		{
			AutoCompleteCustomSource = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public AutoCompleteMode property_09
	{
		get
		{
			return AutoCompleteMode;
		}
		set
		{
			AutoCompleteMode = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ComboBoxStyle property_10
	{
		get
		{
			return DropDownStyle;
		}
		set
		{
			DropDownStyle = value;
		}
	}

	public Class_53()
	{
		field_406 = Enum_06.field_409;
		property_10 = ComboBoxStyle.DropDown;
		property_09 = AutoCompleteMode.None;
		ListBox listBox = new ListBox();
		string text = "Text";
		listBox.DisplayMember = text;
		listBox.TabStop = false;
		listBox.Dock = DockStyle.Fill;
		listBox.DrawMode = DrawMode.OwnerDrawFixed;
		listBox.IntegralHeight = true;
		bool flag = property_04;
		listBox.Sorted = flag;
		field_403 = listBox;
		field_403.Click += method_381;
		field_403.DrawItem += method_385;
		FontChanged += method_383;
		field_403.MouseMove += method_382;
		field_402 = new Class_51(field_403);
		method_383(null, null);
	}

	protected override void Dispose(bool arg_01)
	{
		if (arg_01)
		{
			if (field_404 != null)
			{
				field_404.Dispose();
			}
			field_402.Dispose();
		}
		bool disposing = arg_01;
		base.Dispose(disposing);
	}

	protected override void OnLocationChanged(EventArgs arg_01)
	{
		base.OnLocationChanged(arg_01);
		method_380();
	}

	protected override void OnSizeChanged(EventArgs arg_01)
	{
		base.OnSizeChanged(arg_01);
		Class_51 class_ = field_402;
		int num = Width;
		class_.Width = num;
	}

	public void method_379()
	{
		if (!DesignMode)
		{
			if (DroppedDown)
			{
				BeginUpdate();
				string text = Text;
				int selectionStart = SelectionStart;
				int selectionLength = SelectionLength;
				DroppedDown = false;
				Text = text;
				Select(selectionStart, selectionLength);
				EndUpdate();
			}
			int val = MaxDropDownItems;
			int count = field_403.Items.Count;
			int num = Math.Min(val, count) * field_403.ItemHeight;
			field_402.method_369(this, new Size(DropDownWidth, num));
		}
	}

	public void method_380()
	{
		if (field_402.Visible)
		{
			field_402.Close();
		}
	}

	protected override void OnLostFocus(EventArgs arg_01)
	{
		if (!field_402.Focused && !field_403.Focused)
		{
			method_380();
		}
		base.OnLostFocus(arg_01);
	}

	protected override void OnDropDown(EventArgs arg_01)
	{
		method_380();
		base.OnDropDown(arg_01);
	}

	private void method_381(object arg_01, EventArgs arg_02)
	{
		field_405 = false;
		Class_56 class_ = (Class_56)field_403.SelectedItem;
		string text = class_.property_13;
		Text = text;
		int length = Text.Length;
		int start = 0;
		Select(start, length);
		Focus();
	}

	protected override bool ProcessCmdKey(ref Message arg_01, Keys arg_02)
	{
		if (arg_02 == Keys.Tab && field_402.Visible)
		{
			if (field_403.Text.Length != 0)
			{
				string text = field_403.Text;
				Text = text;
			}
			int length = Text.Length;
			int start = 0;
			Select(start, length);
			method_380();
		}
		return base.ProcessCmdKey(ref arg_01, arg_02);
	}

	protected override void OnKeyDown(KeyEventArgs arg_01)
	{
		field_405 = true;
		if (!field_402.Visible)
		{
			base.OnKeyDown(arg_01);
			return;
		}
		switch (arg_01.KeyCode)
		{
		case Keys.Down:
			if (field_403.SelectedIndex < 0)
			{
				field_403.SelectedIndex = 0;
			}
			else if (field_403.SelectedIndex < field_403.Items.Count - 1)
			{
				ListBox listBox = field_403;
				int num = listBox.SelectedIndex;
				int num2 = num + 1;
				listBox.SelectedIndex = num2;
			}
			break;
		case Keys.Up:
			if (field_403.SelectedIndex > 0)
			{
				ListBox listBox2 = field_403;
				int num = listBox2.SelectedIndex;
				int num3 = num - 1;
				listBox2.SelectedIndex = num3;
			}
			else if (field_403.SelectedIndex < 0)
			{
				field_403.SelectedIndex = field_403.Items.Count - 1;
			}
			break;
		case Keys.Return:
		{
			if (field_403.Text.Length != 0)
			{
				Text = field_403.Text;
			}
			int length = Text.Length;
			Select(0, length);
			method_380();
			break;
		}
		case Keys.Escape:
			method_380();
			break;
		default:
			base.OnKeyDown(arg_01);
			return;
		}
		arg_01.Handled = true;
		arg_01.SuppressKeyPress = true;
	}

	protected override void OnDropDownClosed(EventArgs arg_01)
	{
		field_405 = false;
		base.OnDropDownClosed(arg_01);
	}

	protected override void OnTextChanged(EventArgs arg_01)
	{
		base.OnTextChanged(arg_01);
		if (!field_405 || !Focused)
		{
			return;
		}
		field_403.BeginUpdate();
		field_403.Items.Clear();
		Class_55 class_ = new Class_55(property_06, Text);
		foreach (object item in Items)
		{
			Class_56 class_2 = class_.property_12(GetItemText(item));
			if (class_2 != null)
			{
				field_403.Items.Add(class_2);
			}
		}
		field_403.EndUpdate();
		bool flag = field_403.Items.Count != 0;
		if (field_403.Items.Count == 1 && ((Class_56)field_403.Items[0]).property_13.Length == Text.Trim().Length)
		{
			Class_56 class_3 = (Class_56)field_403.Items[0];
			string text = class_3.property_13;
			Text = text;
			int length = Text.Length;
			int start = 0;
			Select(start, length);
			flag = false;
		}
		if (flag)
		{
			method_379();
		}
		else
		{
			method_380();
		}
		field_405 = false;
	}

	private void method_382(object arg_01, MouseEventArgs arg_02)
	{
		ListBox listBox = field_403;
		Point location = arg_02.Location;
		int num = listBox.IndexFromPoint(location);
		if (num >= 0 && num != field_403.SelectedIndex)
		{
			field_403.SelectedIndex = num;
		}
	}

	private void method_383(object arg_01, EventArgs arg_02)
	{
		if (field_404 != null)
		{
			field_404.Dispose();
		}
		ListBox listBox = field_403;
		Font font = Font;
		listBox.Font = font;
		field_404 = new Font(Font, FontStyle.Bold);
		ListBox listBox2 = field_403;
		int itemHeight = field_404.Height + 2;
		listBox2.ItemHeight = itemHeight;
	}

	private static void method_384(Graphics arg_01, Color arg_02, ref Rectangle arg_03, string arg_04, Font arg_05)
	{
		Size size = new Size(int.MaxValue, int.MaxValue);
		Size proposedSize = size;
		Size size2 = TextRenderer.MeasureText(arg_01, arg_04, arg_05, proposedSize, TextFormatFlags.NoPadding);
		Rectangle bounds = arg_03;
		TextRenderer.DrawText(arg_01, arg_04, arg_05, bounds, arg_02, TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
		int num = arg_03.X + size2.Width;
		arg_03.X = num;
		int num2 = arg_03.Width - size2.Width;
		arg_03.Width = num2;
	}

	private void method_385(object arg_01, DrawItemEventArgs arg_02)
	{
		Class_56 class_ = (Class_56)field_403.Items[arg_02.Index];
		arg_02.DrawBackground();
		bool flag = class_.property_15;
		Rectangle arg_3 = arg_02.Bounds;
		foreach (string item in class_.property_14)
		{
			Font arg_4 = (flag ? field_404 : Font);
			method_384(arg_02.Graphics, arg_02.ForeColor, ref arg_3, item, arg_4);
			flag = !flag;
		}
		arg_02.DrawFocusRectangle();
	}
}
