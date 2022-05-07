using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Potion_Calculator
{
    public class JSONOperations
    {
        public static string dataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\AlbionOnlinePCC";
        public static string productionMaterialsJSONPath = dataFolderPath + "\\production-materials.json";
        public static string productsJSONPath = dataFolderPath + "\\products.json";
        public static void createLocalJSONDatabase() // AppData/Local konumunda, yoksa json dosyalarını oluşturur.
        {
            Directory.CreateDirectory(dataFolderPath);

            if (!File.Exists(productionMaterialsJSONPath))
            {
                using (FileStream fs = File.Create(productionMaterialsJSONPath))
                {
                    List<ProductionMaterial> productionMaterials = new List<ProductionMaterial>();
                    productionMaterials.Add(new ProductionMaterial() { name = "Brightleaf Comfrey", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Crenellated Burdock", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Dragon Teasel", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Elusive Foxglove", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Firetouched Mullein", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Ghoul Yarrow", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Hen Eggs", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Goose Eggs", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Goat's Milk", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Sheep's Milk", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Cow's Milk", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Potato Schnapps", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Corn Hooch", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Pumpkin Moonshine", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Potatoes", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Bundle of Corn", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Pumpkin", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Adept's Arcane Essence", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Expert's Arcane Essence", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Master's Arcane Essence", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Grandmaster's Arcane Essence", price = 0 });
                    productionMaterials.Add(new ProductionMaterial() { name = "Elder's Arcane Essence", price = 0 });
                    string jsonString = getItemsAsString<ProductionMaterial>(productionMaterials);
                    byte[] jsonBytes = new UTF8Encoding(true).GetBytes(jsonString);
                    fs.Write(jsonBytes);
                    fs.Close();
                };
            }
            if (!File.Exists(dataFolderPath + "\\products.json"))
            {
                using (FileStream fs = File.Create(productsJSONPath))
                {
                    List<Product> products = new List<Product>();
                    #region Energy Potions
                    List<ProductionMaterialForProducts> energy40PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> energy41PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> energy60PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> energy61PML = new List<ProductionMaterialForProducts>();

                    energy40PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 24 });
                    energy40PML.Add(new ProductionMaterialForProducts() { name = "Goat's Milk", amount = 6 });

                    energy41PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 24 });
                    energy41PML.Add(new ProductionMaterialForProducts() { name = "Goat's Milk", amount = 6 });
                    energy41PML.Add(new ProductionMaterialForProducts() { name = "Adept's Arcane Essence", amount = 9 });

                    energy60PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 72 });
                    energy60PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 18 });
                    energy60PML.Add(new ProductionMaterialForProducts() { name = "Potato Schnapps", amount = 18 });

                    energy61PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 72 });
                    energy61PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 18 });
                    energy61PML.Add(new ProductionMaterialForProducts() { name = "Potato Schnapps", amount = 18 });
                    energy61PML.Add(new ProductionMaterialForProducts() { name = "Master's Arcane Essence", amount = 5 });

                    products.Add(new Product() { name = "Energy Potion", tier = 4, enchantment = 0, feeFactor = 1.35, productionMaterials = energy40PML });
                    products.Add(new Product() { name = "Energy Potion", tier = 4, enchantment = 1, feeFactor = 1.35, productionMaterials = energy41PML });

                    products.Add(new Product() { name = "Energy Potion", tier = 6, enchantment = 0, feeFactor = 4.86, productionMaterials = energy60PML });
                    products.Add(new Product() { name = "Energy Potion", tier = 6, enchantment = 1, feeFactor = 4.86, productionMaterials = energy61PML });
                    #endregion
                    #region Sticky Potions
                    List<ProductionMaterialForProducts> sticky50PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> sticky51PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> sticky70PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> sticky71PML = new List<ProductionMaterialForProducts>();

                    sticky50PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    sticky50PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    sticky50PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 6 });

                    sticky51PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    sticky51PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    sticky51PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 6 });
                    sticky51PML.Add(new ProductionMaterialForProducts() { name = "Expert's Arcane Essence", amount = 5 });

                    sticky70PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    sticky70PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    sticky70PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 36 });
                    sticky70PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    sticky70PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });

                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 36 });
                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });
                    sticky71PML.Add(new ProductionMaterialForProducts() { name = "Grandmaster's Arcane Essence", amount = 3 });

                    products.Add(new Product() { name = "Sticky Potion", tier = 5, enchantment = 0, feeFactor = 1.89, productionMaterials = sticky50PML });
                    products.Add(new Product() { name = "Sticky Potion", tier = 5, enchantment = 1, feeFactor = 1.89, productionMaterials = sticky51PML });

                    products.Add(new Product() { name = "Sticky Potion", tier = 7, enchantment = 0, feeFactor = 8.1, productionMaterials = sticky70PML });
                    products.Add(new Product() { name = "Sticky Potion", tier = 7, enchantment = 1, feeFactor = 8.1, productionMaterials = sticky71PML });
                    #endregion
                    #region Invisibility Potion
                    List<ProductionMaterialForProducts> invis80PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> invis81PML = new List<ProductionMaterialForProducts>();

                    invis80PML.Add(new ProductionMaterialForProducts() { name = "Ghoul Yarrow", amount = 72 });
                    invis80PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 36 });
                    invis80PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 36 });
                    invis80PML.Add(new ProductionMaterialForProducts() { name = "Cow's Milk", amount = 18 });
                    invis80PML.Add(new ProductionMaterialForProducts() { name = "Pumpkin Moonshine", amount = 18 });

                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Ghoul Yarrow", amount = 72 });
                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 36 });
                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 36 });
                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Cow's Milk", amount = 18 });
                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Pumpkin Moonshine", amount = 18 });
                    invis81PML.Add(new ProductionMaterialForProducts() { name = "Elder's Arcane Essence", amount = 1 });

                    products.Add(new Product() { name = "Invisibility Potion", tier = 8, enchantment = 0, feeFactor = 8.1, productionMaterials = invis80PML });
                    products.Add(new Product() { name = "Invisibility Potion", tier = 8, enchantment = 1, feeFactor = 8.1, productionMaterials = invis81PML });

                    #endregion
                    #region Healing Potion
                    List<ProductionMaterialForProducts> heal40PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> heal41PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> heal60PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> heal61PML = new List<ProductionMaterialForProducts>();

                    heal40PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 24 });
                    heal40PML.Add(new ProductionMaterialForProducts() { name = "Hen Eggs", amount = 6 });

                    heal41PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 24 });
                    heal41PML.Add(new ProductionMaterialForProducts() { name = "Hen Eggs", amount = 6 });
                    heal41PML.Add(new ProductionMaterialForProducts() { name = "Adept's Arcane Essence", amount = 9 });

                    heal60PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 72});
                    heal60PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    heal60PML.Add(new ProductionMaterialForProducts() { name = "Potato Schnapps", amount = 18 });

                    heal61PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 72 });
                    heal61PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    heal61PML.Add(new ProductionMaterialForProducts() { name = "Potato Schnapps", amount = 18 });
                    heal61PML.Add(new ProductionMaterialForProducts() { name = "Master's Arcane Essence", amount = 5 });

                    products.Add(new Product() { name = "Healing Potion", tier = 4, enchantment = 0, feeFactor = 1.35, productionMaterials = heal40PML });
                    products.Add(new Product() { name = "Healing Potion", tier = 4, enchantment = 1, feeFactor = 1.35, productionMaterials = heal41PML });

                    products.Add(new Product() { name = "Healing Potion", tier = 6, enchantment = 0, feeFactor = 4.86, productionMaterials = heal60PML });
                    products.Add(new Product() { name = "Healing Potion", tier = 6, enchantment = 1, feeFactor = 4.86, productionMaterials = heal61PML });

                    #endregion
                    #region Gigantify Potion
                    List<ProductionMaterialForProducts> giga50PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> giga51PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> giga70PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> giga71PML = new List<ProductionMaterialForProducts>();

                    giga50PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    giga50PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    giga50PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 6 });

                    giga51PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    giga51PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    giga51PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 6 });
                    giga51PML.Add(new ProductionMaterialForProducts() { name = "Expert's Arcane Essence", amount = 4 });

                    giga70PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    giga70PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    giga70PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    giga70PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });

                    giga71PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    giga71PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    giga71PML.Add(new ProductionMaterialForProducts() { name = "Goose Eggs", amount = 18 });
                    giga71PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });
                    giga71PML.Add(new ProductionMaterialForProducts() { name = "Grandmaster's Arcane Essence", amount = 2 });

                    products.Add(new Product() { name = "Gigantify Potion", tier = 5, enchantment = 0, feeFactor = 1.89, productionMaterials = giga50PML });
                    products.Add(new Product() { name = "Gigantify Potion", tier = 5, enchantment = 1, feeFactor = 1.89, productionMaterials = giga51PML });

                    products.Add(new Product() { name = "Gigantify Potion", tier = 7, enchantment = 0, feeFactor = 6.48, productionMaterials = giga70PML });
                    products.Add(new Product() { name = "Gigantify Potion", tier = 7, enchantment = 1, feeFactor = 6.48, productionMaterials = giga71PML });

                    #endregion
                    #region Resistance Potion
                    List<ProductionMaterialForProducts> resis50PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> resis51PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> resis70PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> resis71PML = new List<ProductionMaterialForProducts>();

                    resis50PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    resis50PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    resis50PML.Add(new ProductionMaterialForProducts() { name = "Goat's Milk", amount = 6 });

                    resis51PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 24 });
                    resis51PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 12 });
                    resis51PML.Add(new ProductionMaterialForProducts() { name = "Goat's Milk", amount = 6 });
                    resis51PML.Add(new ProductionMaterialForProducts() { name = "Expert's Arcane Essence", amount = 5 });

                    resis70PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    resis70PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    resis70PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 36 });
                    resis70PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 18 });
                    resis70PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });

                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 72 });
                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 36 });
                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 36 });
                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 18 });
                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Corn Hooch", amount = 18 });
                    resis71PML.Add(new ProductionMaterialForProducts() { name = "Grandmaster's Arcane Essence", amount = 3 });

                    products.Add(new Product() { name = "Resistance Potion", tier = 5, enchantment = 0, feeFactor = 1.89, productionMaterials = resis50PML });
                    products.Add(new Product() { name = "Resistance Potion", tier = 5, enchantment = 1, feeFactor = 1.89, productionMaterials = resis51PML });

                    products.Add(new Product() { name = "Resistance Potion", tier = 7, enchantment = 0, feeFactor = 8.1, productionMaterials = resis70PML });
                    products.Add(new Product() { name = "Resistance Potion", tier = 7, enchantment = 1, feeFactor = 8.1, productionMaterials = resis71PML });

                    #endregion
                    #region Poison Potion
                    List<ProductionMaterialForProducts> poi40PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> poi41PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> poi60PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> poi61PML = new List<ProductionMaterialForProducts>();

                    List<ProductionMaterialForProducts> poi80PML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> poi81PML = new List<ProductionMaterialForProducts>();

                    poi40PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 8 });
                    poi40PML.Add(new ProductionMaterialForProducts() { name = "Brightleaf Comfrey", amount = 4 });

                    poi41PML.Add(new ProductionMaterialForProducts() { name = "Crenellated Burdock", amount = 8 });
                    poi41PML.Add(new ProductionMaterialForProducts() { name = "Brightleaf Comfrey", amount = 4 });
                    poi41PML.Add(new ProductionMaterialForProducts() { name = "Adept's Arcane Essence", amount = 5 });

                    poi60PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 24 });
                    poi60PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 12 });
                    poi60PML.Add(new ProductionMaterialForProducts() { name = "Brightleaf Comfrey", amount = 12 });
                    poi60PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 6 });

                    poi61PML.Add(new ProductionMaterialForProducts() { name = "Elusive Foxglove", amount = 24 });
                    poi61PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 12 });
                    poi61PML.Add(new ProductionMaterialForProducts() { name = "Brightleaf Comfrey", amount = 12 });
                    poi61PML.Add(new ProductionMaterialForProducts() { name = "Sheep's Milk", amount = 6 });
                    poi61PML.Add(new ProductionMaterialForProducts() { name = "Master's Arcane Essence", amount = 2 });

                    poi80PML.Add(new ProductionMaterialForProducts() { name = "Ghoul Yarrow", amount = 72 });
                    poi80PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 36 });
                    poi80PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 36 });
                    poi80PML.Add(new ProductionMaterialForProducts() { name = "Cow's Milk", amount = 18 });
                    poi80PML.Add(new ProductionMaterialForProducts() { name = "Pumpkin Moonshine", amount = 18 });

                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Ghoul Yarrow", amount = 72 });
                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Firetouched Mullein", amount = 36 });
                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Dragon Teasel", amount = 36 });
                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Cow's Milk", amount = 18 });
                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Pumpkin Moonshine", amount = 18 });
                    poi81PML.Add(new ProductionMaterialForProducts() { name = "Elder's Arcane Essence", amount = 1 });

                    products.Add(new Product() { name = "Poison Potion", tier = 4, enchantment = 0, feeFactor = 0.54, productionMaterials = poi40PML });
                    products.Add(new Product() { name = "Poison Potion", tier = 4, enchantment = 1, feeFactor = 0.54, productionMaterials = poi41PML });

                    products.Add(new Product() { name = "Poison Potion", tier = 6, enchantment = 0, feeFactor = 2.43, productionMaterials = poi60PML });
                    products.Add(new Product() { name = "Poison Potion", tier = 6, enchantment = 1, feeFactor = 2.43, productionMaterials = poi61PML });

                    products.Add(new Product() { name = "Poison Potion", tier = 8, enchantment = 0, feeFactor = 8.1, productionMaterials = poi80PML });
                    products.Add(new Product() { name = "Poison Potion", tier = 8, enchantment = 1, feeFactor = 8.1, productionMaterials = poi81PML });

                    #endregion
                    #region Juices
                    List<ProductionMaterialForProducts> potatoPML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> cornPML = new List<ProductionMaterialForProducts>();
                    List<ProductionMaterialForProducts> pumpkinPML = new List<ProductionMaterialForProducts>();

                    potatoPML.Add(new ProductionMaterialForProducts() { name = " Potatoes", amount = 1 });

                    cornPML.Add(new ProductionMaterialForProducts() { name = "Bundle of Corn", amount = 1 });

                    pumpkinPML.Add(new ProductionMaterialForProducts() { name = "Pumpkin", amount = 1 });

                    products.Add(new Product() { name = "Potato Schnapps", tier = 6, enchantment = 0, feeFactor = 0.04666, productionMaterials = potatoPML });
                    products.Add(new Product() { name = "Corn Hooch", tier = 7, enchantment = 0, feeFactor = 0.04666, productionMaterials = cornPML });
                    products.Add(new Product() { name = "Pumpkin Moonshine", tier = 8, enchantment = 0, feeFactor = 0.04666, productionMaterials = pumpkinPML });

                    #endregion
                    string jsonString = getItemsAsString<Product>(products);
                    byte[] jsonBytes = new UTF8Encoding(true).GetBytes(jsonString);
                    fs.Write(jsonBytes);
                    fs.Close();
                }; 
            }
        }

        public static List<T> getItemsAsClass<T>(string items)
        {
            return JsonConvert.DeserializeObject<List<T>>(items);
        }

        public static string getItemsAsString<T>(List<T> items)
        {
            return JsonConvert.SerializeObject(items);
        }

    }
}
