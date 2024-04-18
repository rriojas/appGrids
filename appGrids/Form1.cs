namespace appGrids
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      lstvData.View = View.Details;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      // Open a file dialog to open a csv file
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "CSV Files|*.csv";
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        // Read the csv file
        string[] lines = File.ReadAllLines(ofd.FileName);
        string[] headers = lines[0].Split(',');
        lstvData.Columns.Clear();
        lstvData.Items.Clear();
        foreach (string header in headers)
        {
          lstvData.Columns.Add(header);
        }
        for (int i = 1; i < lines.Length; i++)
        {
          string[] fields = lines[i].Split(',');
          ListViewItem lvi = new ListViewItem(fields);
          lstvData.Items.Add(lvi);
        }
      }
    }
  }
}
