using System;
using System.Windows.Forms;

namespace MedAllergy
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // Fungsi ini dibiarkan kosong saja.
            // Mengapa? Karena proses memuat data (Load) dan menyambungkan 
            // Crystal Report (rptDoc) sudah diselesaikan sepenuhnya oleh 
            // tombol "Cetak" yang ada di form FilterDataDiagnosiscs.
        }
    }
}