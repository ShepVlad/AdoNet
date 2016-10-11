using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01___dbModel.DbLayer;
using System.Data.Entity;
using _01___dbModel.Bisenes;

namespace _01___dbModel
{
    public partial class Form1 : Form
    {
        ShopAdoEntities context = new ShopAdoEntities();

        BindingSource bsGood = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<GoodExt> list = MnrExt.GetGoods(context);
            context.Goods.Load();
            context.Manufacturers.Load();
            context.Categories.Load();
            bsGood.DataSource = list; //context.Goods.Local;
            dgvGood.DataSource = bsGood.DataSource;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void EditGood()
        {
            GoodExt gext = bsGood.Current as GoodExt;
            Good good = context.Goods.Local
                .Where(g => g.GoodId == gext.GoodId)
                .FirstOrDefault();

            FormEditGood editgood = new FormEditGood();
            editgood.tbNameGood.Text = good.GoodName;
            editgood.txtCount.Text = good.GoodCount.ToString();
            editgood.txtPrice.Text = good.Price.ToString();

            editgood.cbManufacturer.DisplayMember = "ManufacturerName";
            editgood.cbManufacturer.ValueMember = "ManufacturerId";
            editgood.cbManufacturer.DataSource = context.Manufacturers.Local;
            editgood.cbManufacturer.SelectedValue = good.ManufacturerId;

            editgood.cbCategory.DisplayMember = "CategoryName";
            editgood.cbCategory.ValueMember = "CategoryId";
            editgood.cbCategory.DataSource = context.Categories.Local;
            editgood.cbCategory.SelectedValue = good.CategoryId;

            DialogResult result = editgood.ShowDialog();

            if (result == DialogResult.OK) {
                good.GoodName = editgood.tbNameGood.Text;
                good.GoodCount = Convert.ToDecimal(editgood.txtCount.Text);
                good.Price = Convert.ToDecimal(editgood.txtPrice.Text);

                good.ManufacturerId = Convert.ToInt32(editgood.cbManufacturer.SelectedValue);
                good.CategoryId = Convert.ToInt32(editgood.cbCategory.SelectedValue);

                context.SaveChanges();
            }



        }

    }
}
