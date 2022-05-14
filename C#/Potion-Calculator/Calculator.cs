namespace Potion_Calculator
{
    public static class Calculator
    {
        private static List<Product> products;
        private static List<ProductionMaterial> productionMaterials;
        private static List<Settings> settings;
        private static List<Result> results;

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
            getResults();
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
                        focus = focus % result.product.focus;
                        break;
                    }
                }
                percentageResults.Add(new ProductionPercentageResult() {productionPercentage = productionPercentage, 
                    focusUsage = settings[0].focus - focus, formattedFocusUsage = getFormattedInteger(settings[0].focus - focus),
                    totalProfit = totalProfit, formattedTotalProfit = getFormattedInteger(totalProfit)});
            }
            return percentageResults;
        }

        private static void getResults()
        {
            results = new List<Result>();
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
                    productionCost = Convert.ToInt32(Math.Floor(productionCost)),
                    formattedProductionCost = getFormattedInteger(Convert.ToInt32(Math.Floor(productionCost))),
                    profitPerProduction = Convert.ToInt32(Math.Floor(profitPerProduction)),
                    formattedProfitPerProduction = getFormattedInteger(Convert.ToInt32(Math.Floor(profitPerProduction))),
                    totalProfit = Convert.ToInt32(Math.Floor(totalProfit)),
                    formattedTotalProfit = getFormattedInteger(Convert.ToInt32(Math.Floor(totalProfit))),
                    product = product});
            }
            results = results.OrderByDescending(o => o.totalProfit).ToList();
        }

        public static List<Result> getResult(int productionPercentage)
        {
            List<Result> percentResult = new List<Result>();
            int focus = settings[0].focus;
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
                    int profit = getTotalProfit(result, expectedQuantityToBeProduced, 0);

                    percentResult.Add(new Result
                    {
                        name = result.name,
                        tier = result.tier,
                        enchantment = result.enchantment,
                        fullName = result.fullName,
                        productionCost = result.productionCost,
                        formattedProductionCost = result.formattedProductionCost,
                        profitPerProduction = result.profitPerProduction,
                        formattedProfitPerProduction = result.formattedProfitPerProduction,
                        totalProfit = profit,
                        formattedTotalProfit = getFormattedInteger(profit),
                        productionAmount = expectedQuantityToBeProduced,
                        formattedProductionAmount = getFormattedInteger(expectedQuantityToBeProduced),
                        focusUsageAmount = amountOfFocusRequiredForProduction,
                        formattedFocusUsageAmount = getFormattedInteger(amountOfFocusRequiredForProduction),
                        product = result.product
                    });
                }
                else
                {
                    expectedQuantityToBeProduced = getExpectedQuantityToBeProducedLast(result.product, focus);
                    int profit = getTotalProfit(result, expectedQuantityToBeProduced, 0);
                    focus -= focus % result.product.focus;
                    percentResult.Add(new Result
                    {
                        name = result.name,
                        tier = result.tier,
                        enchantment = result.enchantment,
                        fullName = result.fullName,
                        productionCost = result.productionCost,
                        formattedProductionCost = result.formattedProductionCost,
                        profitPerProduction = result.profitPerProduction,
                        formattedProfitPerProduction = result.formattedProfitPerProduction,
                        totalProfit = profit,
                        formattedTotalProfit = getFormattedInteger(profit),
                        productionAmount = expectedQuantityToBeProduced,
                        formattedProductionAmount = getFormattedInteger(expectedQuantityToBeProduced),
                        focusUsageAmount = focus,
                        formattedFocusUsageAmount = getFormattedInteger(focus),
                        product = result.product
                    });
                    break;
                }
            }

            int totalProductionCost = 0;
            int totalProfitPerProduciton = 0;
            int totalProfit = 0;
            int totalProductionAmount = 0;
            int totalFocusUsageAmount = 0;
            foreach (Result result in percentResult)
            {
                totalProductionCost += result.productionCost;
                totalProfitPerProduciton += result.profitPerProduction;
                totalProfit += result.totalProfit;
                totalProductionAmount += result.productionAmount;
                totalFocusUsageAmount += result.focusUsageAmount;
            }
            percentResult.Add(new Result
            {
                fullName = "Toplam",
                productionCost = totalProductionCost,
                formattedProductionCost = getFormattedInteger(totalProductionCost),
                profitPerProduction = totalProfitPerProduciton,
                formattedProfitPerProduction = getFormattedInteger(totalProfitPerProduciton),
                totalProfit = totalProfit,
                formattedTotalProfit = getFormattedInteger(totalProfit),
                productionAmount = totalProductionAmount,
                formattedProductionAmount = getFormattedInteger(totalProductionAmount),
                focusUsageAmount = totalFocusUsageAmount,
                formattedFocusUsageAmount = getFormattedInteger(totalFocusUsageAmount)
            });

            return percentResult;
        }

        public static List<string> getProductionList(Product product, int productionAmount)
        {
            List<string> productionList = new List<string>();
            if (!(Equals(product.name, "Potato Schnapps") || Equals(product.name, "Corn Hooch") || Equals(product.name, "Pumpkin Moonshine")))
            {
                productionAmount /= 5;
            }
            foreach (ProductionMaterialForProducts item in product.productionMaterials)
            {
                int purchasePercentage = getPurchasePercentage(item, productionAmount);
                int itemAmount = getItemAmount(purchasePercentage, item.amount, productionAmount);
                productionList.Add(item.name + " - " + getFormattedInteger(itemAmount) + " adet");
            }

            return productionList;
        }

        public static List<string> getTotalProductionList(List<Result> results)
        {
            List<string> productionList = new List<string>();
            Dictionary<string, int> productionListDictionary = new Dictionary<string, int>();
            foreach (Result result in results)
            {
                if (!Equals(result.fullName, "Toplam"))
                {
                    foreach (ProductionMaterialForProducts productionMaterial in result.product.productionMaterials)
                    {
                        int productionAmount = result.productionAmount;
                        if (!(Equals(productionMaterial.name, "Potato Schnapps") || Equals(productionMaterial.name, "Corn Hooch") || Equals(productionMaterial.name, "Pumpkin Moonshine")))
                        {
                            productionAmount /= 5;
                        }
                        int purchasePercentage = getPurchasePercentage(productionMaterial, productionAmount);
                        int itemAmount = getItemAmount(purchasePercentage, productionMaterial.amount, productionAmount);
                        bool flag = true;
                        foreach (KeyValuePair<string, int> item in productionListDictionary)
                        {
                            if (Equals(item.Key, productionMaterial.name))
                            {
                                productionListDictionary[item.Key] += itemAmount;
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            productionListDictionary.Add(productionMaterial.name, itemAmount);
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, int> item in productionListDictionary)
            {
                productionList.Add(item.Key + " - " + getFormattedInteger(item.Value) + " adet");
            }
            return productionList;
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
                expectedQuantityToBeProduced = Convert.ToInt32(Math.Floor((product.dailySalesAmount / 100.0) * productionPercentage));
            }
            else
            {
                expectedQuantityToBeProduced = Convert.ToInt32(Math.Floor((product.dailySalesAmount / 100.0) * productionPercentage));
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

        private static int getPurchasePercentage(ProductionMaterialForProducts productionMaterial, int productionAmount)
        {
            int max = productionMaterial.amount;
            int purchasePercentage = 0;
            double returnRate = settings[0].returnRate;
            int goal = max * productionAmount;
            bool flag = false;
            for (int i = Convert.ToInt32(Math.Floor(100 - returnRate)); i < 100; i++)
            {
                int itemAmount = Convert.ToInt32(Math.Floor((goal * i) / 100.0));
                int totalItemAmount = 0;
                double remainingNumber = 0;
                while (true)
                {
                    if (itemAmount < max)
                    {
                        if (itemAmount + totalItemAmount >= goal)
                        {
                            purchasePercentage = i;
                            flag = true;
                            break;
                        }
                        break;
                    }

                    totalItemAmount += itemAmount;
                    remainingNumber += (itemAmount * (returnRate / 100.0)) % 1;
                    itemAmount = Convert.ToInt32(Math.Floor(itemAmount * (returnRate / 100.0)));
                    if (remainingNumber >= 1)
                    {
                        itemAmount += Convert.ToInt32(Math.Floor(remainingNumber));
                        remainingNumber %= 1;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            return purchasePercentage;
        }

        private static int getItemAmount(int purchasePercentage, int itemAmount, int productionAmount)
        {
            return Convert.ToInt32(Math.Ceiling((purchasePercentage * (itemAmount * productionAmount)) / 100.0));
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
