using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if (args.Length > 0 && args[0] == "--gallery") { Application.Run(Gallery()); return; }
        if (args.Length > 1 && args[0] == "--view")
        {
            var type = typeof(Program).Assembly.GetType(args[1], true);
            var control = (Control)Activator.CreateInstance(type);
            Application.Run(control as Form ?? Host(control));
            return;
        }
        var main = new Form_01();
        UiNavigation.Start(main);
        if (args.Contains("--devices")) UiNavigation.ShowDevices(main);
        if (args.Contains("--account")) UiNavigation.ShowAccount(main);
        Application.Run(main);
    }
    internal static Form Host(Control control)
    {
        var host = new Form { Text = control.GetType().Name, ClientSize = control.Size, StartPosition = FormStartPosition.CenterScreen, Icon = new Form_01().Icon };
        control.Dock = DockStyle.Fill;
        host.Controls.Add(control);
        return host;
    }
    private static Form Gallery()
    {
        var form = new Form { Text = "PhantomTool — UI preview (F1)", ClientSize = new Size(400, 440), StartPosition = FormStartPosition.CenterScreen };
        var list = new ListBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11), IntegralHeight = false };
        list.Items.AddRange(new object[] { "Form_01 — Main", "Form_02 — storage selection", "Form_03 — modal overlay", "Form_04 — waiting", "Form_05 — device window", "UserControl_01 — device pages", "UserControl_02 — account", "UserControl_03 — login", "UserControl_04 — MediaTek", "UserControl_05 — Qualcomm", "UserControl_06 — custom config", "UserControl_07 — device selection", "UserControl_08 — vendor/model/chip", "UserControl_09 — MediaTek custom config" });
        list.DoubleClick += (s, e) => { if (list.SelectedItem == null) return; var name = list.SelectedItem.ToString().Split(' ')[0]; var control = (Control)Activator.CreateInstance(typeof(Program).Assembly.GetType(name)); var window = control as Form ?? Host(control); if (control is Form_01 main) UiNavigation.Start(main); window.Show(); };
        form.Controls.Add(list);
        return form;
    }
    internal static void OpenGallery() { Gallery().Show(); }
}
