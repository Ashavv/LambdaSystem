using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void yearTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void getSalesButton_Click(object sender, EventArgs e)
        {
            QueryServiceReference.IQueryService queryService = new QueryServiceReference.QueryServiceClient();

            int year = Int32.Parse(yearTextBox.Text);

            var count = queryService.GetNoOfSalesByYear(year);

            resultLabel.Text = count.ToString() + " salg i år " + year;

        }

        private void resultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
