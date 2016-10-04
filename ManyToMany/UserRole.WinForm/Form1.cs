using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserRole.DataLayer.DbLayer;
using UserRole.WinForm;


namespace UserRole.WinForm
{
    public partial class Form1 : Form
    {
        UserRoleContext context = new UserRoleContext();
        BindingSource bsUser = new BindingSource();
        BindingSource bsRole = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Users.Include(u => u.Roles).Load();
            context.Roles.Load();

            bsUser.DataSource = context.Users.Local;
            dataGridView1.DataSource = bsUser;
            bsRole.DataSource /*не отображается но он есть*/= context.Roles.Local;
            checkedListBox1.DataSource = bsRole;

            CheckRoleUser();
        }

        private void CheckRoleUser()
        {
            User user = bsUser.Current as User;
           for (int i = 0; i < checkedListBox1.Items.Count; i++) {

                checkedListBox1.SetItemChecked(i, false);
                foreach (var item in user.Roles) {
                    if (checkedListBox1.Items[i].ToString() == item.RoleName) {
                        checkedListBox1.SetItemChecked(i,true);
                    }
            }
    }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Случайно нажал на роли)
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            CheckRoleUser();
        }
    }
}
