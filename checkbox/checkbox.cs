using System.Windows.Forms;
using System.Drawing;
namespace checkbox_test {
  class CheckboxForm : Form {
    private FlowLayoutPanel FlowPanel;
    private CheckBox cb;
    public CheckboxForm() {
      InitUI();
      System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
      MyTimer.Interval = 4000;
      MyTimer.Tick += new EventHandler(DisableCheckbox);
      MyTimer.Start();
    }
    private void InitUI() {
      Text = "CheckBox test";
      ClientSize = new Size(300, 100);
      FlowPanel = new FlowLayoutPanel();
      cb = new CheckBox();
      cb.Margin = new Padding(5);
      cb.Parent = this;
      cb.Text = "Disabled";
      cb.AutoSize = true;
      cb.Checked = false;
      cb.Enabled = false;
      cb.CheckedChanged += new EventHandler(OnChanged);
      FlowPanel.Controls.Add(cb);
      Controls.Add(FlowPanel);
      CenterToScreen();
    }
    void OnChanged(object sender, EventArgs e) {
      if (((CheckBox )sender).Checked) {
        ((CheckBox )sender).Text = "Checked";
      } else {
        ((CheckBox )sender).Text = "Unchecked";
      }
    }
    void DisableCheckbox(object sender, EventArgs e) {
      ((System.Windows.Forms.Timer)sender).Dispose();
      cb.Enabled = true;
      if (cb.Checked) {
        cb.Text = "Checked";
      } else {
        cb.Text = "Unchecked";
      }
    }
    [STAThread]
    static void Main() {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.Run(new CheckboxForm());
    }
  }
}
