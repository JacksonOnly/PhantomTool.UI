using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public partial class Form_05 : System.Windows.Forms.Form
{
    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Location = new System.Drawing.Point(0,0);
        this.Text = "UsbUpdater";
        this.Font = System.Drawing.SystemFonts.DefaultFont;
        this.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Name = "";
        this.Padding = new System.Windows.Forms.Padding(0,0,0,0);
        this.Anchor = (System.Windows.Forms.AnchorStyles)5;
        this.Dock = (System.Windows.Forms.DockStyle)0;
        this.Size = new System.Drawing.Size(816,489);
        this.AutoScaleDimensions = new System.Drawing.SizeF(6f,12f);
        this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)1;
        this.ClientSize = new System.Drawing.Size(800,450);
        this.AutoSize = false;
        this.Enabled = true;
        this.Visible = false;
        this.ResumeLayout(false);
        // Keep the captured post-autoscale bounds; future resizes still use Dock/Anchor.
        this.SuspendLayout();
        this.Location = new System.Drawing.Point(0,0);
        this.Size = new System.Drawing.Size(816,489);
        this.ResumeLayout(false);
    }
}
