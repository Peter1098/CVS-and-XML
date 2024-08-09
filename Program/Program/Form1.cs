using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System;



namespace Program
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public class DataGridViewExporter
        {
            public static void ExportDataGridViewToCsv(DataGridView dataGridView, string filePath)
            {
                if (dataGridView == null)
                    throw new ArgumentNullException(nameof(dataGridView));

                StringBuilder csvContent = new StringBuilder();

                // Write the column headers
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    csvContent.Append(dataGridView.Columns[i].HeaderText);
                    if (i < dataGridView.Columns.Count - 1)
                        csvContent.Append(",");
                }
                csvContent.AppendLine();

                // Write the rows
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Skip new row placeholder if it exists
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            string cellValue = row.Cells[i].Value?.ToString().Replace("\"", "\"\"") ?? string.Empty;
                            if (cellValue.Contains(",") || cellValue.Contains("\""))
                                cellValue = $"\"{cellValue}\"";

                            csvContent.Append(cellValue);
                            if (i < row.Cells.Count - 1)
                                csvContent.Append(",");
                        }
                        csvContent.AppendLine();
                    }
                }

                // Save the CSV content to a file
                File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
            }
        }

        private void CargarDatos()
        {
            // Cadena de conexión
            string connectionString = "data source = DESKTOP-3M1R1GH\\SQLEXPRESS; initial catalog = prueba; user id = sa; password = root;TrustServerCertificate=true; Trusted_Connection=True";

            // Consulta SQL
            string query = "SELECT * FROM prueba";

            // Crear una conexión y un adaptador de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                DataView dataView = new DataView(dataTable);
                dataGridView1.DataSource = dataView;
                connection.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos
            string connectionString = "data source=DESKTOP-3M1R1GH\\SQLEXPRESS;initial catalog=prueba;user id=sa;password=root;TrustServerCertificate=true;Trusted_Connection=True";

            // Consulta SQL para generar
            
            string query = "SELECT * FROM prueba as job  FOR XML AUTO, ELEMENTS, ROOT('Nombre')";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear un comando SQL
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // Ejecutar la consulta y leer el resultado
                using (XmlReader xmlReader = command.ExecuteXmlReader())
                {
                    // Mostrar un cuadro de diálogo para guardar el archivo
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "XML Files (*.xml)|*.xml",
                        Title = "Guardar archivo XML",
                        FileName = "resultado.xml"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Ruta del archivo seleccionado por el usuario
                        string xmlFilePath = saveFileDialog.FileName;

                        try
                        {
                            XmlWriterSettings settings = new XmlWriterSettings
                            {
                                Indent = true, 
                                IndentChars = "    ", 
                                NewLineChars = Environment.NewLine, 
                                NewLineHandling = NewLineHandling.Replace, 
                                Encoding = Encoding.UTF8 
                            };

                            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFilePath, settings))
                            {
                                // Escribir el XML desde el lector
                                xmlWriter.WriteNode(xmlReader, true);
                            }

                            MessageBox.Show("El archivo XML se ha guardado correctamente en: " + xmlFilePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al guardar el archivo XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Cargar Datos para no dejar en blanco el archivo cvs
            CargarDatos();
            // Abre el cuadro de diálogo para guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*", 
                Title = "Save CSV File", 
                FileName = "resultado.csv" 
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Llama al método para exportar el DataGridView a CSV
                    DataGridViewExporter.ExportDataGridViewToCsv(dataGridView1, saveFileDialog.FileName);
                    MessageBox.Show("El archivo CVS se ha guardado correctamente: ", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

