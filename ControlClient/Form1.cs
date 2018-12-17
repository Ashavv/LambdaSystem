using DataReceiver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlClient
{
    public partial class Form1 : Form
    {
        private BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();
        FeedSimulator feed = new FeedSimulator();

        public Form1()
        {
            InitializeComponent();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            feed.FeedNewSale();
        }

        private void batchButton_Click(object sender, EventArgs e)
        {
            batchService.ComputeSalesByYearBatchView();

        }
    }
}
