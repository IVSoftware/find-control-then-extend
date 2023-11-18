namespace find_control_then_extend
{
    partial class MainForm
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
            dgvSignals = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSignals).BeginInit();
            SuspendLayout();
            // 
            // dgvSignals
            // 
            dgvSignals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSignals.Dock = DockStyle.Fill;
            dgvSignals.Location = new Point(10, 10);
            dgvSignals.Name = "dgvSignals";
            dgvSignals.RowHeadersWidth = 62;
            dgvSignals.RowTemplate.Height = 33;
            dgvSignals.Size = new Size(458, 224);
            dgvSignals.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(dgvSignals);
            Name = "MainForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)dgvSignals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSignals;
    }
}
