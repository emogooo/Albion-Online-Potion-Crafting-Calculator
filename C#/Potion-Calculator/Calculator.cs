namespace Potion_Calculator
{
    public static class Calculator
    {
        private static List<Product> products;
        private static List<ProductionMaterial> productionMaterials;
        private static List<Settings> settings;

        private static void getItems()
        {
            using (StreamReader r = new StreamReader(JSONOperations.productsJSONPath))
            {
                string json = r.ReadToEnd();
                products = JSONOperations.getItemsAsClass<Product>(json);
            }

            using (StreamReader r = new StreamReader(JSONOperations.productionMaterialsJSONPath))
            {
                string json = r.ReadToEnd();
                productionMaterials = JSONOperations.getItemsAsClass<ProductionMaterial>(json);
            }

            using (StreamReader r = new StreamReader(JSONOperations.settingsJSONPath))
            {
                string json = r.ReadToEnd();
                settings = JSONOperations.getItemsAsClass<Settings>(json);
            }
        }

        private static void updateProducts()
        {
            foreach (Product product in products)
            {
                foreach (ProductionMaterialForProducts productionMaterialinProducts in product.productionMaterials)
                {
                    foreach (ProductionMaterial productionMaterial in productionMaterials)
                    {
                        if (String.Equals(productionMaterialinProducts.name, productionMaterial.name))
                        {
                            productionMaterialinProducts.price = productionMaterial.price;
                            break;
                        }
                    }
                }
            }
            string jsonString = JSONOperations.getItemsAsString(products);
            File.WriteAllText(JSONOperations.productsJSONPath, jsonString);
        }

        public static List<ProductionPercentageResult> getPercentageResults()
        {
            getItems();
            updateProducts();
            List<Result> results = getResults();
            List<ProductionPercentageResult> percentageResults = new List<ProductionPercentageResult>();
            for (int productionPercentage = settings[0].minProductionPercent; productionPercentage <= settings[0].maxProductionPercent; productionPercentage++)
            {
                int focus = settings[0].focus;
                int totalProfit = 0;
                foreach (Result result in results)
                {
                    int expectedQuantityToBeProduced = getExpectedQuantityToBeProduced(result.product, productionPercentage);
                    if (expectedQuantityToBeProduced < settings[0].minProductionQuantity)
                    {
                        continue;
                    }
                    int amountOfFocusRequiredForProduction = getAmountOfFocusRequiredForProduction(result.product, expectedQuantityToBeProduced);
                    if (focus - amountOfFocusRequiredForProduction >= 0)
                    {
                        focus -= amountOfFocusRequiredForProduction;
                        totalProfit = getTotalProfit(result, expectedQuantityToBeProduced, totalProfit);
                    }
                    else
                    {
                        expectedQuantityToBeProduced = getExpectedQuantityToBeProducedLast(result.product, focus);
                        totalProfit = getTotalProfit(result, expectedQuantityToBeProduced, totalProfit);
                        focus = 0;
                        break;
                    }
                }
                percentageResults.Add(new ProductionPercentageResult() {productionPercentage = productionPercentage, 
                    focusUsage = settings[0].focus - focus, formattedFocusUsage = getFormattedInteger(settings[0].focus - focus),
                    totalProfit = totalProfit, formattedTotalProfit = getFormattedInteger(totalProfit)});
            }
            return percentageResults;
        }

        private static List<Result> getResults()
        {
            List< Result> results = new List<Result>();
            foreach (Product product in products)
            {
                double productionCost = getProductionCost(product);
                double profitPerProduction = getProfitPerProduction(product, productionCost);
                if (profitPerProduction <= 0)
                {
                    continue;
                }
                double totalProfit = profitPerProduction * (settings[0].focus / product.focus);

                results.Add(new Result() {name = product.name, tier = product.tier, enchantment = product.enchantment,
                    fullName = getFullName(product.name, product.tier, product.enchantment),
                    productionCost = Convert.ToInt32(productionCost),
                    formattedProductionCost = getFormattedInteger(Convert.ToInt32(productionCost)),
                    profitPerProduction = Convert.ToInt32(profitPerProduction),
                    formattedProfitPerProduction = getFormattedInteger(Convert.ToInt32(profitPerProduction)),
                    totalProfit = Convert.ToInt32(totalProfit),
                    formattedTotalProfit = getFormattedInteger(Convert.ToInt32(totalProfit)),
                    product = product});
            }

            return results.OrderByDescending(o => o.totalProfit).ToList();
        }
        private static double getProductionCost(Product product)
        {
            double cost = 0;

            foreach (ProductionMaterialForProducts item in product.productionMaterials)
            {
                cost += item.amount * (item.price * 10.5 / 10);
            }

            cost *= (100 - settings[0].returnRate) / 100;
            cost += product.feeFactor * settings[0].fee;

            return cost;
        }

        private static double getProfitPerProduction(Product product, double productionCost)
        {
            double profitPerProduction;
            if (String.Equals(product.name, "Potato Schnapps") || String.Equals(product.name, "Corn Hooch") || String.Equals(product.name, "Pumpkin Moonshine"))
            {
                profitPerProduction = (product.price * 95.5 / 100) - productionCost;
            }
            else
            {
                profitPerProduction = ((5 * product.price) * 95.5 / 100) - productionCost;
            }
            return profitPerProduction;
        }

        private static int getExpectedQuantityToBeProduced(Product product, int productionPercentage)
        {
            int expectedQuantityToBeProduced;
            if (String.Equals(product.name, "Potato Schnapps") || String.Equals(product.name, "Corn Hooch") || String.Equals(product.name, "Pumpkin Moonshine"))
            {
                expectedQuantityToBeProduced = Convert.ToInt32((product.dailySalesAmount / 100.0) * productionPercentage);
            }
            else
            {
                expectedQuantityToBeProduced = Convert.ToInt32((product.dailySalesAmount / 100.0) * productionPercentage);
                if (expectedQuantityToBeProduced % 5 != 0)
                {
                    expectedQuantityToBeProduced += 5 - (expectedQuantityToBeProduced % 5);
                }              
            }
            return expectedQuantityToBeProduced;
        }

        private static int getExpectedQuantityToBeProducedLast(Product product, int lastFocus)
        {
            int expectedQuantityToBeProduced;
            if (String.Equals(product.name, "Potato Schnapps") || String.Equals(product.name, "Corn Hooch") || String.Equals(product.name, "Pumpkin Moonshine"))
            {
                expectedQuantityToBeProduced = lastFocus / product.focus;
            }
            else
            {
                expectedQuantityToBeProduced = (lastFocus / product.focus) * 5;
            }
            return expectedQuantityToBeProduced;
        }

        private static int getAmountOfFocusRequiredForProduction(Product product, int expectedQuantityToBeProduced)
        {
            int amountOfFocusRequiredForProduction;
            if (String.Equals(product.name, "Potato Schnapps") || String.Equals(product.name, "Corn Hooch") || String.Equals(product.name, "Pumpkin Moonshine"))
            {
                amountOfFocusRequiredForProduction = expectedQuantityToBeProduced * product.focus;
            }
            else
            {
                amountOfFocusRequiredForProduction = (expectedQuantityToBeProduced / 5) * product.focus;
            }
            return amountOfFocusRequiredForProduction;
        }

        private static int getTotalProfit(Result result, int expectedQuantityToBeProduced, int profit)
        {
            if (String.Equals(result.product.name, "Potato Schnapps") || String.Equals(result.product.name, "Corn Hooch") || String.Equals(result.product.name, "Pumpkin Moonshine"))
            {
                profit += result.profitPerProduction * expectedQuantityToBeProduced;
            }
            else
            {
                profit += result.profitPerProduction * (expectedQuantityToBeProduced / 5);
            }
            return profit;
        }

        private static string getFormattedInteger(int num)
        {
            if (num == 0)
            {
                return "0";
            }
            int x = Math.Abs(num);
            string a = Convert.ToString(x);
            if (a.Length < 4 && num > 0)
            {
                return a;
            }
            else if (a.Length < 4 && num < 0)
            {
                return "-" + a;
            }
            string b = "";
            if (a.Length % 3 == 1)
            {
                b = Convert.ToString(a[0]);
                a = a.Substring(1, a.Length - 1);
            }
            else if (a.Length % 3 == 2)
            {
                b = a.Substring(0, 2);
                a = a.Substring(2, a.Length - 2);
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 3 == 0)
                {
                    b += "." + a[i];
                }
                else
                {
                    b += a[i];
                }
            }
            if (Char.Equals(b[0], '.'))
            {
                b = b.Substring(1, b.Length - 1);
            }
            if (num < 0)
            {
                b = '-' + b;
            }
            return b;
        }

        private static double getFormattedDouble(double num)
        {
            return Math.Truncate(num * 100) / 100;
        }

        private static string getFullName(string name, int tier, int enc)
        {
            if (String.Equals(name, "Potato Schnapps"))
            {
                return "Potato Schnapps";
            }
            else if (String.Equals(name, "Corn Hooch"))
            {
                return "Corn Hooch";
            }
            else if (String.Equals(name, "Pumpkin Moonshine"))
            {
                return "Pumpkin Moonshine";
            }
            else
            {
                return name + " " + tier + "." + enc;
            }
        }

    }
}
