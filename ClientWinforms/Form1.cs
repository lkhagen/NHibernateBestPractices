using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using DataObjects.Entities;

using NHibernate;


namespace ClientWinforms
{
    public partial class Form1 : Form
    {
        private ISession session;
        
        public Form1()
        {
            session = SessionFactory.Instance.OpenSession();
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var customers = session.QueryOver<Customer>().List();

            foreach (Customer customer in customers)
            {
                // Create row
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvData);

                // Assign values to row
                row.Cells[colLastName.Index].Value = customer.LastName;
                row.Cells[colFirstName.Index].Value = customer.FirstName;
                
                // Add row to DataGridView
                dgvData.Rows.Add(row);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            session.Dispose();
        }

        
    }
}
