using System;
using System.Collections.Generic;
using System.Text;

/**
 * 商品类
 */ 
namespace GoodsStruct
{
    class cStockInfo
    {
        private string tradeCode;
        private string fullName;
        private string tradeTpye;
        private string standard;
        private string standeunit;
        private string produce;
        private float qty = 0;
        private float price = 0;
        private float averagePrice = 0;
        private float salePrice = 0;
        private float check = 0;
        private float upperLimit = 0;
        private float lowerLimit = 0;

        public string TradeCode { get => tradeCode; set => tradeCode = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string TradeTpye { get => tradeTpye; set => tradeTpye = value; }
        public string Standard { get => standard; set => standard = value; }
        public string Standeunit { get => standeunit; set => standeunit = value; }
        public string Produce { get => produce; set => produce = value; }
        public float Qty { get => qty; set => qty = value; }
        public float Price { get => price; set => price = value; }
        public float AveragePrice { get => averagePrice; set => averagePrice = value; }
        public float SalePrice { get => salePrice; set => salePrice = value; }
        public float Check { get => check; set => check = value; }
        public float UpperLimit { get => upperLimit; set => upperLimit = value; }
        public float LowerLimit { get => lowerLimit; set => lowerLimit = value; }

        public void ShowInfo()
        {
            Console.WriteLine("仓库中存有{0}型号{1}{2}台", TradeTpye, FullName, Qty);
        }
    }
}
