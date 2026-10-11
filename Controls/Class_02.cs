using System.Collections;
using System.Drawing;
using System.Windows.Forms;

[ToolboxBitmap(typeof(DataGridViewCheckBoxColumn))]
public class Class_02 : DataGridViewCheckBoxColumn
{
	public Class_02()
	{
		Class_04 class_ = new Class_04();
		DataGridViewColumnHeaderCell headerCell = class_;
		HeaderCell = headerCell;
		Width = 50;
		class_.event_01 += method_21;
	}

	private void method_21(int arg_01, bool arg_02)
	{
		DataGridView.RefreshEdit();
		foreach (DataGridViewRow item in (IEnumerable)DataGridView.Rows)
		{
			if (!item.Cells[arg_01].ReadOnly)
			{
				DataGridViewCell dataGridViewCell = item.Cells[arg_01];
				object value = arg_02;
				dataGridViewCell.Value = value;
			}
		}
		DataGridView.RefreshEdit();
	}
}
