using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class ViewMedicalRecord : Form
    {
        private string patientSSN;
        public ViewMedicalRecord(string ssn)
        {
            InitializeComponent();
            patientSSN = ssn;
            LoadMedicalRecords(ssn);
        }

        private void LoadMedicalRecords(string ssn)
        {

        }
    }
}
