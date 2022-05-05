using System.Text;
using Newtonsoft.Json;

namespace Potion_Calculator
{
    public class JSONOperations
    {
        public static string dataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\AlbionOnlinePCC";
        public static string productionMaterialsJSONPath = dataFolderPath + "\\production-materials.json";
        public static void createLocalJSONDatabase() // AppData/Local konumunda, yoksa json dosyalarını oluşturur.
        {
            Directory.CreateDirectory(dataFolderPath);

            if (!File.Exists(productionMaterialsJSONPath))
            {
                using (FileStream fs = File.Create(productionMaterialsJSONPath))
                {
                    ProductionMaterial[] productionMaterials = new ProductionMaterial[22];
                    productionMaterials[0] = new ProductionMaterial() { name = "Brightleaf Comfrey", price = 0 };
                    productionMaterials[1] = new ProductionMaterial() { name = "Crenellated Burdock", price = 0 };
                    productionMaterials[2] = new ProductionMaterial() { name = "Dragon Teasel", price = 0 };
                    productionMaterials[3] = new ProductionMaterial() { name = "Elusive Foxglove", price = 0 };
                    productionMaterials[4] = new ProductionMaterial() { name = "Firetouched Mullein", price = 0 };
                    productionMaterials[5] = new ProductionMaterial() { name = "Ghoul Yarrow", price = 0 };
                    productionMaterials[6] = new ProductionMaterial() { name = "Hen Eggs", price = 0 };
                    productionMaterials[7] = new ProductionMaterial() { name = "Goose Eggs", price = 0 };
                    productionMaterials[8] = new ProductionMaterial() { name = "Goat's Milk", price = 0 };
                    productionMaterials[9] = new ProductionMaterial() { name = "Sheep's Milk", price = 0 };
                    productionMaterials[10] = new ProductionMaterial() { name = "Cow's Milk", price = 0 };
                    productionMaterials[11] = new ProductionMaterial() { name = "Potato Schnapps", price = 0 };
                    productionMaterials[12] = new ProductionMaterial() { name = "Corn Hooch", price = 0 };
                    productionMaterials[13] = new ProductionMaterial() { name = "Pumpkin Moonshine", price = 0 };
                    productionMaterials[14] = new ProductionMaterial() { name = "Potatoes", price = 0 };
                    productionMaterials[15] = new ProductionMaterial() { name = "Bundle of Corn", price = 0 };
                    productionMaterials[16] = new ProductionMaterial() { name = "Pumpkin", price = 0 };
                    productionMaterials[17] = new ProductionMaterial() { name = "Adept's Arcane Essence", price = 0 };
                    productionMaterials[18] = new ProductionMaterial() { name = "Expert's Arcane Essence", price = 0 };
                    productionMaterials[19] = new ProductionMaterial() { name = "Master's Arcane Essence", price = 0 };
                    productionMaterials[20] = new ProductionMaterial() { name = "Grandmaster's Arcane Essence", price = 0 };
                    productionMaterials[21] = new ProductionMaterial() { name = "Elder's Arcane Essence", price = 0 };
                    string jsonString = JsonConvert.SerializeObject(productionMaterials);
                    byte[] jsonBytes = new UTF8Encoding(true).GetBytes(jsonString);
                    fs.Write(jsonBytes);
                    fs.Close();
                };
            }
            if (!File.Exists(dataFolderPath + "\\products.json"))
            {
                using (File.Create(dataFolderPath + "\\products.json")) ;
            }
        }
    }
}
