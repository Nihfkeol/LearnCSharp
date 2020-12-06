using System;

/**
 * 进销存管理系统
 */
namespace GoodsStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("库存盘点信息如下：");
            cStockInfo csi1 = new cStockInfo();
            csi1.FullName = "空调";
            csi1.TradeTpye = "TYPE-1";
            csi1.Qty = 2000;
            csi1.ShowInfo();
            cStockInfo csi2 = new cStockInfo();
            csi2.FullName = "空调";
            csi2.TradeTpye = "TYPE-2";
            csi2.Qty = 3500;
            csi2.ShowInfo();
            Console.ReadKey();
        }
    }
}
