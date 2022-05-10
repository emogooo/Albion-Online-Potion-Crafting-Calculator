namespace Potion_Calculator
{
    public class Result
    {
        public string name { get; set; }
        public int tier { get; set; }
        public int enchantment { get; set; }
        public string fullName { get; set; }
        public int productionCost { get; set; }
        public string formattedProductionCost { get; set; }
        public int profitPerProduction { get; set; }
        public string formattedProfitPerProduction { get; set; }
        public double percentProfitPerProduction { get; set; }
        public int totalProfit { get; set; }
        public string formattedTotalProfit { get; set; }
        public int totalProduction { get; set; }
        public string formattedTotalProduction { get; set; }
        public Product product { get; set; }
    }
}
