using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace datagridview_test {
  public partial class DataGridViewDemo : Form  {
    private IContainer components = new Container();
    private Button changeItemBtn = new Button();
    private DataGridView myDataGridView = new DataGridView();
    private BindingSource rowsBindingSource = new BindingSource();
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    public DataGridViewDemo()  {
      InitUI();
      System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
      MyTimer.Interval = 2000;
      MyTimer.Tick += new EventHandler(AddEntries);
      MyTimer.Start();
    }
    private void InitUI() {
      AutoScaleMode = AutoScaleMode.Font;
      Text = "DataGridView test";
      // ClientSize = new Size(500, 200);
      Size = new Size(350, 200);
      myDataGridView.Dock = DockStyle.Fill;
      myDataGridView.Name = "DataGridView";
      myDataGridView.RowHeadersVisible = false;
      myDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      myDataGridView.AllowUserToAddRows = false;
      myDataGridView.AllowUserToResizeRows = false;
      myDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      myDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(CellDoubleClick);
      BindingList<DemoRow> rowList = new BindingList<DemoRow>();
      rowsBindingSource.DataSource = rowList;
      myDataGridView.DataSource = rowsBindingSource;
      Controls.Add(myDataGridView);
      CenterToScreen();
    }
    private void CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
      try {
        BindingList<DemoRow> rowList = rowsBindingSource.DataSource as BindingList<DemoRow>;
        var result = MessageBox.Show("test " + (e.RowIndex + 1), "DataGridView test dialog", MessageBoxButtons.OK);
        if (result == System.Windows.Forms.DialogResult.OK) {
          rowList[e.RowIndex].State = "done " + (e.RowIndex + 1);
        }
      } catch (Exception ex) {
        MessageBox.Show("exception " + ex, "err", MessageBoxButtons.OK);
      }
    }
    private void AddEntries(object sender, EventArgs e) {
      ((System.Windows.Forms.Timer)sender).Dispose();
      BindingList<DemoRow> rowList = rowsBindingSource.DataSource as BindingList<DemoRow>;
      for (var i=1; i < 10; i++) {
        rowList.Add(DemoRow.CreateNewRow(i));
      }
    }
    [STAThread]
    static void Main() {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.Run(new DataGridViewDemo());
    }
  }

  public class DemoRow : INotifyPropertyChanged  {
    private string rowStateValue = String.Empty;
    private Guid idValue = Guid.NewGuid();
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  {
      if (PropertyChanged != null) {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    private DemoRow(int i)  {
      rowStateValue = "todo " + i;
    }
    public static DemoRow CreateNewRow(int i)  {
      return new DemoRow(i);
    }
    public string State  {
      get  {  return this.rowStateValue;  }
      set  {
        if (value != this.rowStateValue)  {
          this.rowStateValue = value;
          NotifyPropertyChanged();
        }
      }
    }
    public Guid ID  {
      get  {  return this.idValue;  }
    }
  }
}
