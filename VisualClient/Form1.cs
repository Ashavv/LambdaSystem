using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualClient
{
    public partial class Form1 : Form
    {
        private BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();
        private SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();
        private QueryServiceReference.IQueryService queryService = new QueryServiceReference.QueryServiceClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            SalesOrderDetail orderDetail = new SalesOrderDetail
            {
                ProductId = 557,
                Quantity = 4
            };

            SalesOrderHeader sale = new SalesOrderHeader
            {
                OrderDate = new DateTime(2024, 01, 02)
            };

            sale.OrderDetails.Add(orderDetail);
            batchService.HandleNewSale(sale);
            speedService.HandleNewSale(sale);

            int noOfSales = queryService.GetNoOfSalesByYear(2024);
            salesNoText.Text = noOfSales.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void salesNoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void batchButton_Click(object sender, EventArgs e)
        {
            batchService.ComputeSalesByYearBatchView();
            salesNoText.Text = queryService.GetNoOfSalesByYear(2024).ToString();
        }
    }
}
