using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using HtmlAgilityPack;

namespace EtsyParser
{
    class Parser
    {
        public List<EtsyProduct> Parse(string etsyShop)
        {
            HtmlDocument doc = new HtmlDocument();
            string shopUrl = "https://www.etsy.com/shop/"+ etsyShop + "/items";
            doc.LoadHtml(getRequest(shopUrl));
            HtmlNodeCollection products = doc.DocumentNode.SelectNodes("//div[@data-listings-container]//div[contains (@class, 'js-merch-stash-check-listing')]");

            List<EtsyProduct> result = new List<EtsyProduct>();
            if (products != null)
            {
                foreach (HtmlNode product in products)
                {
                    string name = "";
                    string price = "";
                    string productURL = "";
                    string imageURL = "";

                    HtmlNodeCollection nameNode = product.SelectNodes(".//div[contains(@class, 'card-meta')]//div[contains(@class, 'card-title')]");
                    if (nameNode != null)
                    {
                        name = nameNode[0].InnerText.Trim();
                    }

                    HtmlNodeCollection priceNodes = product.SelectNodes(".//div[contains(@class, 'card-meta')]//div[contains(@class, 'card-price')]");
                    if (priceNodes != null)
                    {
                        price = priceNodes[0].InnerText.Trim();
                    }

                    HtmlNodeCollection productURLNodes = product.SelectNodes(".//a[contains(@class, 'buyer-card')]");
                    if (productURLNodes != null)
                    {
                        productURL = productURLNodes[0].GetAttributeValue("href", "");
                    }

                    HtmlNodeCollection imageURLNodes = product.SelectNodes(".//div[@class='placeholder-content ']//img");

                    if (imageURLNodes != null)
                    {
                        imageURL = imageURLNodes[0].GetAttributeValue("src", "");
                    }

                    result.Add(new EtsyProduct(name, price, productURL, imageURL));
                }
            }
            return result;
        }

        public void downLoadProductImages(List <string> urls)
        {
                foreach (string url in urls)
                {
                    char[] delimiterChars = { '/'};
                    string[] strings = url.Split(delimiterChars);
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(url), @"c:\temp\" + strings[strings.Length - 1]);
                    }
                }
        }

        public void ExportXML(List <EtsyProduct> products, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement element1 = doc.CreateElement(string.Empty, "body", string.Empty);
            doc.AppendChild(element1);

            foreach (EtsyProduct procuct in products)
            {
                XmlElement etsyProduct = doc.CreateElement(string.Empty, "EtsyProduct", string.Empty);
                element1.AppendChild(etsyProduct);

                XmlElement productName = doc.CreateElement(string.Empty, "Name", string.Empty);
                XmlText text1 = doc.CreateTextNode(procuct.GetName());
                productName.AppendChild(text1);
                etsyProduct.AppendChild(productName);

                XmlElement productPrice = doc.CreateElement(string.Empty, "Price", string.Empty);
                XmlText text2 = doc.CreateTextNode(procuct.GetPrice());
                productPrice.AppendChild(text2);
                etsyProduct.AppendChild(productPrice);

                XmlElement productURL = doc.CreateElement(string.Empty, "URL", string.Empty);
                XmlText text3 = doc.CreateTextNode(procuct.GetProductURL());
                productURL.AppendChild(text3);
                etsyProduct.AppendChild(productURL);
            }
            doc.Save(filePath);
        }

        static string getRequest(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = url;
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
