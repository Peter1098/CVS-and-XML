namespace Program
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Consulta_SQL = new Button();
            XML = new Button();
            CVS = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(788, 342);
            dataGridView1.TabIndex = 0;
            // 
            // Consulta_SQL
            // 
            Consulta_SQL.Location = new Point(249, 28);
            Consulta_SQL.Name = "Consulta_SQL";
            Consulta_SQL.Size = new Size(177, 42);
            Consulta_SQL.TabIndex = 1;
            Consulta_SQL.Text = "Consulta_SQL";
            Consulta_SQL.UseVisualStyleBackColor = true;
            Consulta_SQL.Click += button1_Click;
            // 
            // XML
            // 
            XML.Location = new Point(432, 28);
            XML.Name = "XML";
            XML.Size = new Size(177, 42);
            XML.TabIndex = 2;
            XML.Text = "XML";
            XML.UseVisualStyleBackColor = true;
            XML.Click += button2_Click;
            // 
            // CVS
            // 
            CVS.Location = new Point(623, 28);
            CVS.Name = "CVS";
            CVS.Size = new Size(177, 42);
            CVS.TabIndex = 3;
            CVS.Text = "CVS";
            CVS.UseVisualStyleBackColor = true;
            CVS.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CVS);
            Controls.Add(XML);
            Controls.Add(Consulta_SQL);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Consulta_SQL;
        private Button XML;
        private Button CVS;
    }
}
