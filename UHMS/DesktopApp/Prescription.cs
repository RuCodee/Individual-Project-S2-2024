﻿using System;
using Domain;
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
    public partial class Prescription : Form
    {
        private User currentDoctor;
        private string patientSSN;

        public Prescription(User doctor, string ssn)
        {
            InitializeComponent();
            currentDoctor = doctor;
            patientSSN = ssn;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
