using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace find_control_then_extend
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dgvSignals.MouseClick += DgvSignals_MouseClick;
        }

        private void DgvSignals_MouseClick(object? sender, MouseEventArgs e)
        {
            if(sender is DataGridView dgv)
            {
                Debug.Assert(dgv.Name == nameof(dgvSignals), "Expecting sender name is dgvSignals");

                // FindForm control by name without ASP
                var findByName = Controls[nameof(dgvSignals)] as DataGridView;
                Debug.Assert(ReferenceEquals(findByName, dgv), "Expecting these to be the same object");

                // Call extension
                dgv.WhoAmI();
            }
            else
            {
                Debug.Assert(false, "Expecting DataGridView");
            }
        }
    }

    /// <summary>
    /// Custom functionality for any program with any DataGridView
    /// </summary>
    public static partial class DataGridViewExtensions
    {
        public static void WhoAmI(this DataGridView anyDataGridView)
        {
            var controlName =
                string.IsNullOrWhiteSpace(anyDataGridView.Name) ?
                    "Unnamed DataGridView" :
                    anyDataGridView.Name;
            MessageBox.Show($"{nameof(WhoAmI)} called by {controlName}");
        }
    }
}
