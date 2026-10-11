using System;
using System.Drawing;
using System.Windows.Forms;

// UI-only interactions. No original VM, device operations, network or account logic.
public static class UiNavigation
{
    public static bool ValidationMode;
    private static void Mount(Control parent, Control child)
    {
        while (parent.Controls.Count != 0) parent.Controls[0].Dispose();
        parent.Controls.Clear(); child.Dock = DockStyle.Fill; parent.Controls.Add(child);
    }
    public static void Attach(Control control)
    {
        if (ValidationMode) return;
        if (control is Form_01 main)
        {
            main.field_42.Click += (s, e) => main.Close();
            main.field_41.Click += (s, e) => main.WindowState = FormWindowState.Minimized;
            main.field_40.Click += (s, e) => main.WindowState = main.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            main.field_45.Click += (s, e) => ShowLogin(main);
            main.KeyPreview = true;
            main.KeyDown += (s, e) => { if (e.KeyCode == Keys.F1) Program.OpenGallery(); if (e.KeyCode == Keys.F2) ShowDevices(main); if (e.KeyCode == Keys.F3) ShowAccount(main); if (e.KeyCode == Keys.F4) ShowLogin(main); };
            Point start = Point.Empty; bool dragging = false;
            foreach (var c in new Control[] { main.field_39, main.field_43, main.field_46 })
            {
                c.MouseDown += (s, e) => { if (e.Button != MouseButtons.Left) return; start = Cursor.Position; dragging = true; };
                c.MouseMove += (s, e) => { if (!dragging) return; var now = Cursor.Position; main.Location = new Point(main.Left + now.X - start.X, main.Top + now.Y - start.Y); start = now; };
                c.MouseUp += (s, e) => dragging = false;
            }
        }
        if (control is Form_02 storage)
        {
            storage.Load += (s, e) => { if (storage.field_56.Items.Count != 0) storage.field_56.SelectedIndex = 0; };
            storage.field_54.Click += (s, e) => { storage.DialogResult = DialogResult.OK; storage.Close(); };
        }
        if (control is UserControl_01 devices)
        {
            devices.Load += (s, e) => { if (devices.field_84.Controls.Count == 0) Mount(devices.field_84, new UserControl_04()); };
            devices.field_83.Click += (s, e) => Mount(devices.field_84, new UserControl_04());
            devices.field_85.Click += (s, e) => Mount(devices.field_84, new UserControl_05());
        }
        if (control is UserControl_03 login)
            login.field_110.Click += (s, e) => { if (login.FindForm() is Form_01 m) ShowDevices(m); };
        if (control is UserControl_04 mediatek)
        {
            Action update = () => { Mount(mediatek.field_200, mediatek.field_199.Checked ? (Control)new UserControl_09() : new UserControl_08()); mediatek.field_197.Size = mediatek.field_199.Checked ? new Size(548, 171) : new Size(548, 137); };
            mediatek.field_199.CheckedChanged += (s, e) => update();
            mediatek.Load += (s, e) => { if (mediatek.field_200.Controls.Count == 0) update(); };
        }
        if (control is UserControl_05 qualcomm)
        {
            Action update = () => { Mount(qualcomm.field_311, qualcomm.field_308.Checked ? (Control)new UserControl_07() : new UserControl_06()); qualcomm.field_302.Size = new Size(560, 121); };
            qualcomm.field_308.CheckedChanged += (s, e) => { if (qualcomm.field_308.Checked) update(); };
            qualcomm.field_309.CheckedChanged += (s, e) => { if (qualcomm.field_309.Checked) update(); };
            qualcomm.field_310.CheckedChanged += (s, e) => { if (qualcomm.field_310.Checked) { foreach(Control c in qualcomm.field_311.Controls)c.Dispose(); qualcomm.field_311.Controls.Clear(); } };
            qualcomm.Load += (s, e) => { if (qualcomm.field_311.Controls.Count == 0 && !qualcomm.field_310.Checked) update(); };
        }
        if(control is UserControl_06 custom) custom.Load += (s,e) => { if(custom.field_340.Items.Count>0)custom.field_340.SelectedIndex=0; };
    }
    public static void Start(Form_01 main) { ShowLogin(main); new Class_52().method_378(main); }
    public static void ShowLogin(Form_01 main) { Mount(main.field_44, new UserControl_03()); main.field_45.Visible = false; }
    public static void ShowDevices(Form_01 main) { Mount(main.field_44, new UserControl_01()); main.field_45.Visible = true; }
    public static void ShowAccount(Form_01 main) { Mount(main.field_44, new UserControl_02()); main.field_45.Visible = true; }
}
