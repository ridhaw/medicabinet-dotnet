using MediCabinet.Controllers;
using MediCabinet.Models;
using System;
using System.Windows.Forms;

namespace MediCabinet.Views.Forms
{
    public partial class frmDetailPrescription : Form
    {
        private readonly PrescriptionController _prescriptionController;
        private Prescription _prescription;
        private int _prescriptionId;

        public frmDetailPrescription(int prescriptionId)
        {
            InitializeComponent();
            _prescriptionController = new PrescriptionController();
            _prescriptionId = prescriptionId;
            ChargerPrescription();
        }

        private void ChargerPrescription()
        {
            // Pour l'instant, afficher simplement les informations
            // Vous pouvez implémenter la récupération complète plus tard
            lblId.Text = $"ID: {_prescriptionId}";
            lblInfo.Text = "Détails de la prescription à implémenter";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Impression à implémenter", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}