using System.Windows.Forms;
using System.Drawing;
namespace tabs_test {
  class TabsForm : Form {
    private TabControl tabControl;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    public TabsForm() {
      InitUI();
    }
    private void InitUI() {
      Text = "Tabs test";
      ClientSize = new Size(300, 200);
      tabPage1 = new System.Windows.Forms.TabPage();
      tabPage2 = new System.Windows.Forms.TabPage();
      tabPage1.Text = "Tab 1";
      tabPage2.Text = "Tab 2";
      tabControl = new TabControl();
      tabControl.Controls.AddRange(new Control[] {tabPage1,tabPage2});
      tabControl.Location = new Point(5, 5);
      tabControl.Size = new Size(290, 190);
      Controls.AddRange(new Control[] {tabControl});
      CenterToScreen();
    }
    [STAThread]
    static void Main() {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.Run(new TabsForm());
    }
  }
}
