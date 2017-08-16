using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EtsyParser
{
    public partial class Form1 : Form
    {
        List<EtsyProduct> products;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string shopName = this.txtInput1.Text;
            Parser parser = new Parser();
            products = parser.Parse(shopName);
            textBox1.Text = createOutput(products);
            btnDownloadImg.Enabled = products.Count > 0;
            btnExportXML.Enabled = products.Count > 0;
        }

        private void btnDownloadImg_Click(object sender, EventArgs e)
        {
            List<string> imageURLs = new List<string>();
            foreach (EtsyProduct product in products)
            {
                imageURLs.Add(product.GetImageURL());
            }
            Parser parser = new Parser();
            parser.downLoadProductImages(imageURLs);           
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            Parser parser = new Parser();
            parser.ExportXML(products, @"d:\myXml.xml");
        }

        private string createOutput(List<EtsyProduct> products)
        {
            StringBuilder builder = new StringBuilder();
            foreach (EtsyProduct product in products)
            {
                string name = product.GetName();
                string price = product.GetPrice();
                string url = product.GetProductURL();
                builder = builder.Append(url).AppendLine().Append(name).Append(" ").Append(price).AppendLine().AppendLine();
            }
            return builder.ToString();
        }

    }
}
