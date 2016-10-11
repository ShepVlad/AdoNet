using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _02__HR.NewFolder1;
using System.Data.Entity;

namespace _02__HR
{
    public partial class Form1 : Form
    {
        HrContext context = new HrContext();
        BindingSource bsHuman = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Employees.Load();
            context.EmpPromotions.Load();
            context.JobTitles.Load();
            bsHuman.DataSource = context.Employees.Local;
            dataGridView1.DataSource = bsHuman.DataSource;
            //context.Employees.Include(emp => emp.EmpPromotions).Load();
            //context.JobTitles.Load();
        }
    }
}
