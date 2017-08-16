namespace EtsyParser
{
    class EtsyProduct
    {
        private string name;
        private string price;
        private string productURL;
        private string imageURL;

        public EtsyProduct(string name, string price, string productURL, string imageURL)
        {
            this.name = name;
            this.price = price;
            this.productURL = productURL;
            this.imageURL = imageURL;
        }

        public string GetName()
        {
            return name;
        }

        public string GetPrice()
        {
            return price;
        }

        public string GetProductURL()
        {
            return productURL;
        }

        public string GetImageURL()
        {
            return imageURL;
        }
    }
}
