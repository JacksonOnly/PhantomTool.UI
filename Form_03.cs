using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form_03
{
    public Form_03() { InitializeComponent(); }
    public Form_03(Form owner, Form content) : this() { ConfigureOverlay(owner); }
    public Form_03(Form owner, UserControl content) : this() { ConfigureOverlay(owner); }
    private void ConfigureOverlay(Form owner)
    {
        FormBorderStyle = FormBorderStyle.None;
        BackColor = Color.Black;
        Opacity = 0.5;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        ClientSize = owner.ClientSize;
        Location = owner.PointToScreen(Point.Empty);
        EventHandler follow = (s, e) => { ClientSize = owner.ClientSize; Location = owner.PointToScreen(Point.Empty); };
        owner.Move += follow;
        owner.SizeChanged += follow;
        FormClosed += (s, e) => { owner.Move -= follow; owner.SizeChanged -= follow; };
    }
    public static DialogResult ShowModal(Form owner, Form content)
    {
        using (var overlay = new Form_03(owner, content))
        {
            overlay.Show(owner);
            content.StartPosition = FormStartPosition.CenterParent;
            return content.ShowDialog(overlay);
        }
    }
    public static DialogResult ShowPage(Form owner, UserControl page)
    {
        using (var overlay = new Form_03(owner, page))
        using (var host = new Form { ClientSize = page.Size, FormBorderStyle = FormBorderStyle.None, ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen })
        {
            host.Controls.Add(page);
            overlay.Show(owner);
            return host.ShowDialog(overlay);
        }
    }
}
