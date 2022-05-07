namespace Potion_Calculator
{
    public class Product
    {
        public string name { get; set; }
        public int tier { get; set; }
        public int enchantment { get; set; } 
        public int price { get; set; }
        public int focus { get; set; }
        public int dailySalesAmount { get; set; }
        public double feeFactor { get; set; }
        public List<ProductionMaterialForProducts> productionMaterials { get; set; }
    }

    public class ProductionMaterialForProducts: ProductionMaterial
    {
        public int amount { get; set; }
    }
}
