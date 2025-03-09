namespace WinFormExperiment
{
    public partial class Form1 : Form
    {
        // Define a delegate
        public delegate void TextChangedEventHandler(string text);

        // Define an event based on that delegate
        public event TextChangedEventHandler TextChangedEvent;
        public Form1()
        {
            InitializeComponent();


            clsDataGenerator dataGenerator = new clsDataGenerator();
            dataGridView1.DataSource = dataGenerator.GetPersonList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Save as CSV"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataGridViewExporter.ExportToCsv(dataGridView1, saveFileDialog.FileName);
                MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */

            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView1.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView1.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText("thedata.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));
            MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            // Raise the event when the text changes
            TextChangedEvent?.Invoke(txtAddress.Text);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings fs = new Settings();
            fs.ShowDialog();
        }
    }
}



/*
 
1. Define the Delegate and Event in Detail Page: First, you'll need to define a delegate and 
    an event in your detail page class.

public delegate void DataUpdatedEventHandler(object sender, DataUpdatedEventArgs e);
public class DetailPage
{
    public event DataUpdatedEventHandler DataUpdated;

    protected virtual void OnDataUpdated(DataUpdatedEventArgs e)
    {
        DataUpdated?.Invoke(this, e);
    }

    public void UpdateData()
    {
        // Your logic to update data
        var updatedData = "new data"; // Replace with actual data

        // Raise the event
        OnDataUpdated(new DataUpdatedEventArgs(updatedData));
    }
}

public class DataUpdatedEventArgs : EventArgs
{
    public string UpdatedData { get; }

    public DataUpdatedEventArgs(string updatedData)
    {
        UpdatedData = updatedData;
    }
}

    2. Subscribe to the Event in List Page: Next, you'll subscribe to the event in your list page class.
    
public class ListPage
{
    private DetailPage _detailPage;

    public ListPage(DetailPage detailPage)
    {
        _detailPage = detailPage;
        _detailPage.DataUpdated += OnDataUpdated;
    }

    private void OnDataUpdated(object sender, DataUpdatedEventArgs e)
    {
        // Your logic to update the list with the new data
        var updatedData = e.UpdatedData;
        // Update the list with updatedData
    }

    public void Unsubscribe()
    {
        _detailPage.DataUpdated -= OnDataUpdated;
    }
}

 */