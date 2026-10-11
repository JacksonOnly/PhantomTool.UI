using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public partial class Form_03 : System.Windows.Forms.Form
{
    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Icon = UiAssets.Icon("371d04c0213fd001afc6ad2820d5d13e34415c0403481db0bbc2ed18706e4ec2.ico");
        this.Location = new System.Drawing.Point(0,0);
        this.Text = "";
        this.Font = System.Drawing.SystemFonts.DefaultFont;
        this.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Name = "MaskedDialog";
        this.Padding = new System.Windows.Forms.Padding(0,0,0,0);
        this.Anchor = (System.Windows.Forms.AnchorStyles)5;
        this.Dock = (System.Windows.Forms.DockStyle)0;
        this.Size = new System.Drawing.Size(300,300);
        this.AutoScaleDimensions = new System.Drawing.SizeF(0f,0f);
        this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode)3;
        this.ClientSize = new System.Drawing.Size(284,261);
        this.AutoSize = false;
        this.Enabled = true;
        this.Visible = false;
        this.ResumeLayout(false);
        // Keep the captured post-autoscale bounds; future resizes still use Dock/Anchor.
        this.SuspendLayout();
        this.Location = new System.Drawing.Point(0,0);
        this.Size = new System.Drawing.Size(300,300);
        this.ResumeLayout(false);
    }
}
