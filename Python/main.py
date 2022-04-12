from decimal import DivisionByZero
from pstats import SortKey
from tkinter import *
from tkinter import messagebox
import os
import json
from tkinter import font

class App():
    def __init__(self) -> None:
        global root
        global entProductionMaterialList
        global entProductList
        global entNeededFocusList
        global entFee
        global entFocus
        global entReturnRate
        global productionMaterials
        global products
        global path
        try:
            path = os.path.expanduser("~\AlbionOnlinePCC")
            os.makedirs(path)
        except FileExistsError:
            pass
        if not "data.json" in os.listdir(path):
            with open(path + "\\data.json", 'w') as f:
                data = {
                    'productionMaterials' : [
                                    {
                                        'name' : 'Brightleaf Comfrey',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Crenellated Burdock',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Dragon Teasel',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Elusive Foxglove',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Firetouched Mullein',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Ghoul Yarrow',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Hen Eggs',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Goose Eggs',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Goat\'s Milk',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Sheep\'s Milk',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Cow\'s Milk',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Potato Schnapps',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Corn Hooch',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Pumpkin Moonshine',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Potatoes',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Bundle of Corn',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Pumpkin',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Adept\'s Arcane Essence',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Expert\'s Arcane Essence',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Master\'s Arcane Essence',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Grandmaster\'s Arcane Essence',
                                        'price' : 0,
                                    },
                                    {
                                        'name' : 'Elder\'s Arcane Essence',
                                        'price' : 0,
                                    }
                                 ],
                                 'products' : [
                                    {
                                        'name' : 'Energy Potion 4.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Energy Potion 4.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Energy Potion 6.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Energy Potion 6.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Sticky Potion 5.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Sticky Potion 5.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Sticky Potion 7.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Sticky Potion 7.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Invisibility Potion 8.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Invisibility Potion 8.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Healing Potion 4.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Healing Potion 4.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Healing Potion 6.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Healing Potion 6.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Gigantify Potion 5.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Gigantify Potion 5.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Gigantify Potion 7.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Gigantify Potion 7.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Resistance Potion 5.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Resistance Potion 5.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Resistance Potion 7.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Resistance Potion 7.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 4.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 4.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 6.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 6.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 8.0',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Poison Potion 8.1',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Potato Schnapps',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Corn Hooch',
                                        'price' : 0,
                                        'focus' : 0
                                    },
                                    {
                                        'name' : 'Pumpkin Moonshine',
                                        'price' : 0,
                                        'focus' : 0
                                    }
                                 ]
                        }
                json_string = json.dumps(data)
                f.write(json_string)
        
        productionMaterials = []
        products = []
        with open(path + "\\data.json") as datas:
            data = json.load(datas)
            productionMaterials += data.get("productionMaterials", [])
            products += data.get("products", [])

        root = Tk()
        root.title("Potion Crafting Calculator")
        root.geometry("880x800")

        lbProductionMaterialList = list()
        for productionMaterial in productionMaterials:
            lbProductionMaterialList.append(Label(root, text = productionMaterial["name"]))
        
        lbProductList = list()
        for product in products:
            lbProductList.append(Label(root, text = product["name"]))

        lbNeededFocusList = list()
        for product in products:
            lbNeededFocusList.append(Label(root, text = "NF " + product["name"]))
            
        lbRow = 0
        for lb in lbProductionMaterialList:
            lb.grid(row = lbRow, column = 0, padx=15, pady = 2)
            lbRow += 1
        
        lbRow = 0
        for lb in lbProductList:
            lb.grid(row = lbRow, column = 2, padx=15, pady = 2)
            lbRow += 1

        lbRow = 0
        for lb in lbNeededFocusList:
            lb.grid(row = lbRow, column = 5, padx=15, pady = 2)
            lbRow += 1

        entProductionMaterialList = list()
        for i in range(len(lbProductionMaterialList)):
            entProductionMaterialList.append(Entry(root, width=10))
        
        entProductList = list()
        for i in range(len(lbProductList)):
            entProductList.append(Entry(root, width=10))
        
        entNeededFocusList = list()
        for i in range(len(lbNeededFocusList)):
            entNeededFocusList.append(Entry(root, width=10))
        
        entRow = 0
        for ent in entProductionMaterialList:
            ent.grid(row = entRow, column=1)
            entRow += 1

        entRow = 0
        for ent in entProductList:
            ent.grid(row = entRow, column=3)
            entRow += 1

        entRow = 0
        for ent in entNeededFocusList:
            ent.grid(row = entRow, column=6)
            entRow += 1
 
        i = 0
        for productionMaterial in productionMaterials:
            entProductionMaterialList[i].insert(0, int(productionMaterial["price"]))
            i += 1

        i = 0
        for product in products:
            entProductList[i].insert(0, int(product["price"]))
            i += 1
        
        i = 0
        for product in products:
            entNeededFocusList[i].insert(0, int(product["focus"]))
            i += 1

        lbFee = Label(root, text = "Usage Fee")
        lbFocus= Label(root, text = "Focus Point")
        lbReturnRate = Label(root, text = "Return Rate")

        lbFee.grid(row = 0, column = 7, padx=15)
        lbFocus.grid(row = 1, column = 7, padx=15)
        lbReturnRate.grid(row = 2, column = 7, padx=15)

        entFee = Entry(root, width=10)
        entFocus = Entry(root, width=10)
        entReturnRate = Entry(root, width=10)

        entFee.grid(row = 0, column=8)
        entFocus.grid(row = 1, column=8)
        entReturnRate.grid(row = 2, column=8)

        entFee.insert(0, 300)
        entFocus.insert(0, 30000)
        entReturnRate.insert(0, 47.9)

        btSave = Button(root, text="Kaydet", command=self.save)
        btSave.grid(row=25, column=1)
        btCalculate= Button(root, text="Hesapla", command=lambda: self.calculate(entFee.get(), entFocus.get(), entReturnRate.get()))
        btCalculate.grid(row=25, column=0)
      
    def run(self):
        root.mainloop()
    
    def save(self):
        try:
            i = 0
            for ent in entProductionMaterialList:
                productionMaterials[i]["price"] = int(ent.get())
                i +=1
            i = 0
            for ent in entProductList:
                products[i]["price"] = int(ent.get())
                i +=1
            i = 0
            for ent in entNeededFocusList:
                products[i]["focus"] = int(ent.get())
                i +=1
            
            a = { "productionMaterials" : productionMaterials }
            b = { "products" : products }
            merged = {**a, **b}
            with open(path + "\\data.json", 'w') as outfile:
                json.dump(merged, outfile)
        except:
            messagebox.showerror("Hata", "Girdiler sadece rakamlardan oluşmalıdır.")

    def calculate(self, fee, focus, rr):
        try:
            fee = int(fee)
            focus = int(focus)
            rr = float(rr)
            productionMaterials = []
            products = []
            with open(path + "\\data.json") as datas:
                data = json.load(datas)
                productionMaterials += data.get("productionMaterials", [])
                products += data.get("products", [])
            
            dproductionMaterialPrices = {}
            for item in productionMaterials:
                dproductionMaterialPrices[item["name"]] = item["price"]

            dproductPrices = {}
            for item in products:
                dproductPrices[item["name"]] = item["price"]
            
            dproductFocuses = {}
            for item in products:
                dproductFocuses[item["name"]] = item["focus"]

            results = list()
            t40energyPrice = (((24 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Hen Eggs"])) * (100 - rr) / 100) + (1.35 * fee)
            t41energyPrice = (((24 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Hen Eggs"]) + (9 * dproductionMaterialPrices["Adept's Arcane Essence"])) * (100 - rr) / 100) + (1.35 * fee)
            t60energyPrice = (((72 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Potato Schnapps"])) * (100 - rr) / 100) + (4.86 * fee)
            t61energyPrice = (((72 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Potato Schnapps"]) + (5 * dproductionMaterialPrices["Master's Arcane Essence"]))  * (100 - rr) / 100) + (4.86 * fee)
            
            t50stickyPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goose Eggs"])) * (100 - rr) / 100) + (1.89 * fee)
            t51stickyPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goose Eggs"]) + (5 * dproductionMaterialPrices["Expert's Arcane Essence"])) * (100 - rr) / 100) + (1.89 * fee)
            t70stickyPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (36 * dproductionMaterialPrices["Crenellated Burdock"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Corn Hooch"])) * (100 - rr) / 100) + (8.1 * fee)
            t71stickyPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (36 * dproductionMaterialPrices["Crenellated Burdock"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Corn Hooch"]) + (3 * dproductionMaterialPrices["Grandmaster's Arcane Essence"])) * (100 - rr) / 100) + (8.1 * fee)
            
            t80invisPrice = (((72 * dproductionMaterialPrices["Ghoul Yarrow"]) + (36 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Dragon Teasel"]) + (18 * dproductionMaterialPrices["Cow's Milk"]) + (18 * dproductionMaterialPrices["Pumpkin Moonshine"])) * (100 - rr) / 100) + (8.1 * fee)
            t81invisPrice = (((72 * dproductionMaterialPrices["Ghoul Yarrow"]) + (36 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Dragon Teasel"]) + (18 * dproductionMaterialPrices["Cow's Milk"]) + (18 * dproductionMaterialPrices["Pumpkin Moonshine"]) + (1 * dproductionMaterialPrices["Elder's Arcane Essence"])) * (100 - rr) / 100) + (8.1 * fee)

            t40healPrice = (((24 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goat's Milk"])) * (100 - rr) / 100) + (1.35 * fee)
            t41healPrice = (((24 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goat's Milk"]) + (9 * dproductionMaterialPrices["Adept's Arcane Essence"])) * (100 - rr) / 100) + (1.35 * fee)
            t60healPrice = (((72 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Potato Schnapps"])) * (100 - rr) / 100) + (4.86 * fee)
            t61healPrice = (((72 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Potato Schnapps"]) + (5 * dproductionMaterialPrices["Master's Arcane Essence"]))  * (100 - rr) / 100) + (4.86 * fee)
            
            t50gigaPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goose Eggs"])) * (100 - rr) / 100) + (1.89 * fee)
            t51gigaPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goose Eggs"]) + (4 * dproductionMaterialPrices["Expert's Arcane Essence"])) * (100 - rr) / 100) + (1.89 * fee)
            t70gigaPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Corn Hooch"])) * (100 - rr) / 100) + (6.48 * fee)
            t71gigaPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (18 * dproductionMaterialPrices["Goose Eggs"]) + (18 * dproductionMaterialPrices["Corn Hooch"]) + (2 * dproductionMaterialPrices["Grandmaster's Arcane Essence"])) * (100 - rr) / 100) + (6.48 * fee)
            
            t50resisPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goat's Milk"])) * (100 - rr) / 100) + (1.89 * fee)
            t51resisPrice = (((24 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Crenellated Burdock"]) + (6 * dproductionMaterialPrices["Goat's Milk"]) + (5 * dproductionMaterialPrices["Expert's Arcane Essence"])) * (100 - rr) / 100) + (1.89 * fee)
            t70resisPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (36 * dproductionMaterialPrices["Crenellated Burdock"]) + (18 * dproductionMaterialPrices["Sheep's Milk"]) + (18 * dproductionMaterialPrices["Corn Hooch"])) * (100 - rr) / 100) + (8.1 * fee)
            t71resisPrice = (((72 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Elusive Foxglove"]) + (36 * dproductionMaterialPrices["Crenellated Burdock"]) + (18 * dproductionMaterialPrices["Sheep's Milk"]) + (18 * dproductionMaterialPrices["Corn Hooch"]) + (3 * dproductionMaterialPrices["Grandmaster's Arcane Essence"])) * (100 - rr) / 100) + (8.1 * fee)

            t40poiPrice = (((8 * dproductionMaterialPrices["Crenellated Burdock"]) + (4 * dproductionMaterialPrices["Brightleaf Comfrey"])) * (100 - rr) / 100) + (0.54 * fee)
            t41poiPrice = (((8 * dproductionMaterialPrices["Crenellated Burdock"]) + (4 * dproductionMaterialPrices["Brightleaf Comfrey"]) + (5 * dproductionMaterialPrices["Adept's Arcane Essence"])) * (100 - rr) / 100) + (0.54 * fee) 
            t60poiPrice = (((24 * dproductionMaterialPrices["Elusive Foxglove"]) + (12 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Brightleaf Comfrey"]) + (6 * dproductionMaterialPrices["Sheep's Milk"])) * (100 - rr) / 100) + (2.43 * fee)
            t61poiPrice = (((24 * dproductionMaterialPrices["Elusive Foxglove"]) + (12 * dproductionMaterialPrices["Dragon Teasel"]) + (12 * dproductionMaterialPrices["Brightleaf Comfrey"])+ (6 * dproductionMaterialPrices["Sheep's Milk"]) + (2 * dproductionMaterialPrices["Master's Arcane Essence"]))  * (100 - rr) / 100) + (2.43 * fee)
            t80poiPrice = (((72 * dproductionMaterialPrices["Ghoul Yarrow"]) + (36 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Dragon Teasel"]) + (18 * dproductionMaterialPrices["Cow's Milk"]) + (18 * dproductionMaterialPrices["Pumpkin Moonshine"])) * (100 - rr) / 100) + (8.1 * fee)
            t81poiPrice = (((72 * dproductionMaterialPrices["Ghoul Yarrow"]) + (36 * dproductionMaterialPrices["Firetouched Mullein"]) + (36 * dproductionMaterialPrices["Dragon Teasel"]) + (18 * dproductionMaterialPrices["Cow's Milk"]) + (18 * dproductionMaterialPrices["Pumpkin Moonshine"]) + (1 * dproductionMaterialPrices["Elder's Arcane Essence"])) * (100 - rr) / 100) + (8.1 * fee)

            t6juice = ((1 * dproductionMaterialPrices["Potatoes"]) * (100 - rr) / 100) + (0.046666 * fee)
            t7juice = ((1 * dproductionMaterialPrices["Bundle of Corn"]) * (100 - rr) / 100) + (0.046666 * fee)
            t8juice = ((1 * dproductionMaterialPrices["Pumpkin"]) * (100 - rr) / 100) + (0.046666 * fee)
            
            results.append({"name":"Energy Potion 4.0", "productionPrice" : t40energyPrice, "profitPerProduct": (((5 * dproductPrices["Energy Potion 4.0"]) * 95.5 / 100) - t40energyPrice), "profitPercent" : (((((5 * dproductPrices["Energy Potion 4.0"]) * 95.5 / 100) - t40energyPrice) / t40energyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Energy Potion 4.0"]) * 95.5 / 100) - t40energyPrice) * (focus / dproductFocuses["Energy Potion 4.0"])), "productionQuantity":(focus / dproductFocuses["Energy Potion 4.0"])})
            results.append({"name":"Energy Potion 4.1", "productionPrice" : t41energyPrice, "profitPerProduct": (((5 * dproductPrices["Energy Potion 4.1"]) * 95.5 / 100) - t41energyPrice), "profitPercent" : (((((5 * dproductPrices["Energy Potion 4.1"]) * 95.5 / 100) - t41energyPrice) / t41energyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Energy Potion 4.1"]) * 95.5 / 100) - t41energyPrice) * (focus / dproductFocuses["Energy Potion 4.1"])), "productionQuantity":(focus / dproductFocuses["Energy Potion 4.1"])})
            results.append({"name":"Energy Potion 6.0", "productionPrice" : t60energyPrice, "profitPerProduct": (((5 * dproductPrices["Energy Potion 6.0"]) * 95.5 / 100) - t60energyPrice), "profitPercent" : (((((5 * dproductPrices["Energy Potion 6.0"]) * 95.5 / 100) - t60energyPrice) / t60energyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Energy Potion 6.0"]) * 95.5 / 100) - t60energyPrice) * (focus / dproductFocuses["Energy Potion 6.0"])), "productionQuantity":(focus / dproductFocuses["Energy Potion 6.0"])})
            results.append({"name":"Energy Potion 6.1", "productionPrice" : t61energyPrice, "profitPerProduct": (((5 * dproductPrices["Energy Potion 6.1"]) * 95.5 / 100) - t61energyPrice), "profitPercent" : (((((5 * dproductPrices["Energy Potion 6.1"]) * 95.5 / 100) - t61energyPrice) / t61energyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Energy Potion 6.1"]) * 95.5 / 100) - t61energyPrice) * (focus / dproductFocuses["Energy Potion 6.1"])), "productionQuantity":(focus / dproductFocuses["Energy Potion 6.1"])})

            results.append({"name":"Sticky Potion 5.0", "productionPrice" : t50stickyPrice, "profitPerProduct": (((5 * dproductPrices["Sticky Potion 5.0"]) * 95.5 / 100) - t50stickyPrice), "profitPercent" : (((((5 * dproductPrices["Sticky Potion 5.0"]) * 95.5 / 100) - t50stickyPrice) / t50stickyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Sticky Potion 5.0"]) * 95.5 / 100) - t50stickyPrice) * (focus / dproductFocuses["Sticky Potion 5.0"])), "productionQuantity":(focus / dproductFocuses["Sticky Potion 5.0"])})
            results.append({"name":"Sticky Potion 5.1", "productionPrice" : t51stickyPrice, "profitPerProduct": (((5 * dproductPrices["Sticky Potion 5.1"]) * 95.5 / 100) - t51stickyPrice), "profitPercent" : (((((5 * dproductPrices["Sticky Potion 5.1"]) * 95.5 / 100) - t51stickyPrice) / t51stickyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Sticky Potion 5.1"]) * 95.5 / 100) - t51stickyPrice) * (focus / dproductFocuses["Sticky Potion 5.1"])), "productionQuantity":(focus / dproductFocuses["Sticky Potion 5.1"])})
            results.append({"name":"Sticky Potion 7.0", "productionPrice" : t70stickyPrice, "profitPerProduct": (((5 * dproductPrices["Sticky Potion 7.0"]) * 95.5 / 100) - t70stickyPrice), "profitPercent" : (((((5 * dproductPrices["Sticky Potion 7.0"]) * 95.5 / 100) - t70stickyPrice) / t70stickyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Sticky Potion 7.0"]) * 95.5 / 100) - t70stickyPrice) * (focus / dproductFocuses["Sticky Potion 7.0"])), "productionQuantity":(focus / dproductFocuses["Sticky Potion 7.0"])})
            results.append({"name":"Sticky Potion 7.1", "productionPrice" : t71stickyPrice, "profitPerProduct": (((5 * dproductPrices["Sticky Potion 7.1"]) * 95.5 / 100) - t71stickyPrice), "profitPercent" : (((((5 * dproductPrices["Sticky Potion 7.1"]) * 95.5 / 100) - t71stickyPrice) / t71stickyPrice) * 100), "totalProfit": ((((5 * dproductPrices["Sticky Potion 7.1"]) * 95.5 / 100) - t71stickyPrice) * (focus / dproductFocuses["Sticky Potion 7.1"])), "productionQuantity":(focus / dproductFocuses["Sticky Potion 7.1"])})

            results.append({"name":"Invisibility Potion 8.0", "productionPrice" : t80invisPrice, "profitPerProduct": (((5 * dproductPrices["Invisibility Potion 8.0"]) * 95.5 / 100) - t80invisPrice), "profitPercent" : (((((5 * dproductPrices["Invisibility Potion 8.0"]) * 95.5 / 100) - t80invisPrice) / t80invisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Invisibility Potion 8.0"]) * 95.5 / 100) - t80invisPrice) * (focus / dproductFocuses["Invisibility Potion 8.0"])), "productionQuantity":(focus / dproductFocuses["Invisibility Potion 8.0"])})
            results.append({"name":"Invisibility Potion 8.1", "productionPrice" : t81invisPrice, "profitPerProduct": (((5 * dproductPrices["Invisibility Potion 8.1"]) * 95.5 / 100) - t81invisPrice), "profitPercent" : (((((5 * dproductPrices["Invisibility Potion 8.1"]) * 95.5 / 100) - t81invisPrice) / t81invisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Invisibility Potion 8.1"]) * 95.5 / 100) - t81invisPrice) * (focus / dproductFocuses["Invisibility Potion 8.1"])), "productionQuantity":(focus / dproductFocuses["Invisibility Potion 8.1"])})

            results.append({"name":"Healing Potion 4.0", "productionPrice" : t40healPrice, "profitPerProduct": (((5 * dproductPrices["Healing Potion 4.0"]) * 95.5 / 100) - t40healPrice), "profitPercent" : (((((5 * dproductPrices["Healing Potion 4.0"]) * 95.5 / 100) - t40healPrice) / t40healPrice) * 100), "totalProfit": ((((5 * dproductPrices["Healing Potion 4.0"]) * 95.5 / 100) - t40healPrice) * (focus / dproductFocuses["Healing Potion 4.0"])), "productionQuantity":(focus / dproductFocuses["Healing Potion 4.0"])})
            results.append({"name":"Healing Potion 4.1", "productionPrice" : t41healPrice, "profitPerProduct": (((5 * dproductPrices["Healing Potion 4.1"]) * 95.5 / 100) - t41healPrice), "profitPercent" : (((((5 * dproductPrices["Healing Potion 4.1"]) * 95.5 / 100) - t41healPrice) / t41healPrice) * 100), "totalProfit": ((((5 * dproductPrices["Healing Potion 4.1"]) * 95.5 / 100) - t41healPrice) * (focus / dproductFocuses["Healing Potion 4.1"])), "productionQuantity":(focus / dproductFocuses["Healing Potion 4.1"])})
            results.append({"name":"Healing Potion 6.0", "productionPrice" : t60healPrice, "profitPerProduct": (((5 * dproductPrices["Healing Potion 6.0"]) * 95.5 / 100) - t60healPrice), "profitPercent" : (((((5 * dproductPrices["Healing Potion 6.0"]) * 95.5 / 100) - t60healPrice) / t60healPrice) * 100), "totalProfit": ((((5 * dproductPrices["Healing Potion 6.0"]) * 95.5 / 100) - t60healPrice) * (focus / dproductFocuses["Healing Potion 6.0"])), "productionQuantity":(focus / dproductFocuses["Healing Potion 6.0"])})
            results.append({"name":"Healing Potion 6.1", "productionPrice" : t61healPrice, "profitPerProduct": (((5 * dproductPrices["Healing Potion 6.1"]) * 95.5 / 100) - t61healPrice), "profitPercent" : (((((5 * dproductPrices["Healing Potion 6.1"]) * 95.5 / 100) - t61healPrice) / t61healPrice) * 100), "totalProfit": ((((5 * dproductPrices["Healing Potion 6.1"]) * 95.5 / 100) - t61healPrice) * (focus / dproductFocuses["Healing Potion 6.1"])), "productionQuantity":(focus / dproductFocuses["Healing Potion 6.1"])})

            results.append({"name":"Gigantify Potion 5.0", "productionPrice" : t50gigaPrice, "profitPerProduct": (((5 * dproductPrices["Gigantify Potion 5.0"]) * 95.5 / 100) - t50gigaPrice), "profitPercent" : (((((5 * dproductPrices["Gigantify Potion 5.0"]) * 95.5 / 100) - t50gigaPrice) / t50gigaPrice) * 100), "totalProfit": ((((5 * dproductPrices["Gigantify Potion 5.0"]) * 95.5 / 100) - t50gigaPrice) * (focus / dproductFocuses["Gigantify Potion 5.0"])), "productionQuantity":(focus / dproductFocuses["Gigantify Potion 5.0"])})
            results.append({"name":"Gigantify Potion 5.1", "productionPrice" : t51gigaPrice, "profitPerProduct": (((5 * dproductPrices["Gigantify Potion 5.1"]) * 95.5 / 100) - t51gigaPrice), "profitPercent" : (((((5 * dproductPrices["Gigantify Potion 5.1"]) * 95.5 / 100) - t51gigaPrice) / t51gigaPrice) * 100), "totalProfit": ((((5 * dproductPrices["Gigantify Potion 5.1"]) * 95.5 / 100) - t51gigaPrice) * (focus / dproductFocuses["Gigantify Potion 5.1"])), "productionQuantity":(focus / dproductFocuses["Gigantify Potion 5.1"])})
            results.append({"name":"Gigantify Potion 7.0", "productionPrice" : t70gigaPrice, "profitPerProduct": (((5 * dproductPrices["Gigantify Potion 7.0"]) * 95.5 / 100) - t70gigaPrice), "profitPercent" : (((((5 * dproductPrices["Gigantify Potion 7.0"]) * 95.5 / 100) - t70gigaPrice) / t70gigaPrice) * 100), "totalProfit": ((((5 * dproductPrices["Gigantify Potion 7.0"]) * 95.5 / 100) - t70gigaPrice) * (focus / dproductFocuses["Gigantify Potion 7.0"])), "productionQuantity":(focus / dproductFocuses["Gigantify Potion 7.0"])})
            results.append({"name":"Gigantify Potion 7.1", "productionPrice" : t71gigaPrice, "profitPerProduct": (((5 * dproductPrices["Gigantify Potion 7.1"]) * 95.5 / 100) - t71gigaPrice), "profitPercent" : (((((5 * dproductPrices["Gigantify Potion 7.1"]) * 95.5 / 100) - t71gigaPrice) / t71gigaPrice) * 100), "totalProfit": ((((5 * dproductPrices["Gigantify Potion 7.1"]) * 95.5 / 100) - t71gigaPrice) * (focus / dproductFocuses["Gigantify Potion 7.1"])), "productionQuantity":(focus / dproductFocuses["Gigantify Potion 7.1"])})

            results.append({"name":"Resistance Potion 5.0", "productionPrice" : t50resisPrice, "profitPerProduct": (((5 * dproductPrices["Resistance Potion 5.0"]) * 95.5 / 100) - t50resisPrice), "profitPercent" : (((((5 * dproductPrices["Resistance Potion 5.0"]) * 95.5 / 100) - t50resisPrice) / t50resisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Resistance Potion 5.0"]) * 95.5 / 100) - t50resisPrice) * (focus / dproductFocuses["Resistance Potion 5.0"])), "productionQuantity":(focus / dproductFocuses["Resistance Potion 5.0"])})
            results.append({"name":"Resistance Potion 5.1", "productionPrice" : t51resisPrice, "profitPerProduct": (((5 * dproductPrices["Resistance Potion 5.1"]) * 95.5 / 100) - t51resisPrice), "profitPercent" : (((((5 * dproductPrices["Resistance Potion 5.1"]) * 95.5 / 100) - t51resisPrice) / t51resisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Resistance Potion 5.1"]) * 95.5 / 100) - t51resisPrice) * (focus / dproductFocuses["Resistance Potion 5.1"])), "productionQuantity":(focus / dproductFocuses["Resistance Potion 5.1"])})
            results.append({"name":"Resistance Potion 7.0", "productionPrice" : t70resisPrice, "profitPerProduct": (((5 * dproductPrices["Resistance Potion 7.0"]) * 95.5 / 100) - t70resisPrice), "profitPercent" : (((((5 * dproductPrices["Resistance Potion 7.0"]) * 95.5 / 100) - t70resisPrice) / t70resisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Resistance Potion 7.0"]) * 95.5 / 100) - t70resisPrice) * (focus / dproductFocuses["Resistance Potion 7.0"])), "productionQuantity":(focus / dproductFocuses["Resistance Potion 7.0"])})
            results.append({"name":"Resistance Potion 7.1", "productionPrice" : t71resisPrice, "profitPerProduct": (((5 * dproductPrices["Resistance Potion 7.1"]) * 95.5 / 100) - t71resisPrice), "profitPercent" : (((((5 * dproductPrices["Resistance Potion 7.1"]) * 95.5 / 100) - t71resisPrice) / t71resisPrice) * 100), "totalProfit": ((((5 * dproductPrices["Resistance Potion 7.1"]) * 95.5 / 100) - t71resisPrice) * (focus / dproductFocuses["Resistance Potion 7.1"])), "productionQuantity":(focus / dproductFocuses["Resistance Potion 7.1"])})

            results.append({"name":"Poison Potion 4.0", "productionPrice" : t40poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 4.0"]) * 95.5 / 100) - t40poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 4.0"]) * 95.5 / 100) - t40poiPrice) / t40poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 4.0"]) * 95.5 / 100) - t40poiPrice) * (focus / dproductFocuses["Poison Potion 4.0"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 4.0"])})
            results.append({"name":"Poison Potion 4.1", "productionPrice" : t41poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 4.1"]) * 95.5 / 100) - t41poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 4.1"]) * 95.5 / 100) - t41poiPrice) / t41poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 4.1"]) * 95.5 / 100) - t41poiPrice) * (focus / dproductFocuses["Poison Potion 4.1"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 4.1"])})
            results.append({"name":"Poison Potion 6.0", "productionPrice" : t60poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 6.0"]) * 95.5 / 100) - t60poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 6.0"]) * 95.5 / 100) - t60poiPrice) / t60poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 6.0"]) * 95.5 / 100) - t60poiPrice) * (focus / dproductFocuses["Poison Potion 6.0"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 6.0"])})
            results.append({"name":"Poison Potion 6.1", "productionPrice" : t61poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 6.1"]) * 95.5 / 100) - t61poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 6.1"]) * 95.5 / 100) - t61poiPrice) / t61poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 6.1"]) * 95.5 / 100) - t61poiPrice) * (focus / dproductFocuses["Poison Potion 6.1"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 6.1"])})
            results.append({"name":"Poison Potion 8.0", "productionPrice" : t80poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 8.0"]) * 95.5 / 100) - t80poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 8.0"]) * 95.5 / 100) - t80poiPrice) / t80poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 8.0"]) * 95.5 / 100) - t80poiPrice) * (focus / dproductFocuses["Poison Potion 8.0"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 8.0"])})
            results.append({"name":"Poison Potion 8.1", "productionPrice" : t81poiPrice, "profitPerProduct": (((5 * dproductPrices["Poison Potion 8.1"]) * 95.5 / 100) - t81poiPrice), "profitPercent" : (((((5 * dproductPrices["Poison Potion 8.1"]) * 95.5 / 100) - t81poiPrice) / t81poiPrice) * 100), "totalProfit": ((((5 * dproductPrices["Poison Potion 8.1"]) * 95.5 / 100) - t81poiPrice) * (focus / dproductFocuses["Poison Potion 8.1"])), "productionQuantity":(focus / dproductFocuses["Poison Potion 8.1"])})

            results.append({"name":"Potato Schnapps", "productionPrice" : t6juice, "profitPerProduct": ((dproductPrices["Potato Schnapps"] * 95.5 / 100) - t6juice), "profitPercent" : ((((dproductPrices["Potato Schnapps"] * 95.5 / 100) - t6juice) / t6juice) * 100), "totalProfit": (((dproductPrices["Potato Schnapps"] * 95.5 / 100) - t6juice) * (focus / dproductFocuses["Potato Schnapps"])), "productionQuantity":(focus / dproductFocuses["Potato Schnapps"])})
            results.append({"name":"Corn Hooch", "productionPrice" : t7juice, "profitPerProduct": ((dproductPrices["Corn Hooch"] * 95.5 / 100) - t7juice), "profitPercent" : ((((dproductPrices["Corn Hooch"] * 95.5 / 100) - t7juice) / t7juice) * 100), "totalProfit": (((dproductPrices["Corn Hooch"] * 95.5 / 100) - t7juice) * (focus / dproductFocuses["Corn Hooch"])), "productionQuantity":(focus / dproductFocuses["Corn Hooch"])})
            results.append({"name":"Pumpkin Moonshine", "productionPrice" : t8juice, "profitPerProduct": ((dproductPrices["Pumpkin Moonshine"] * 95.5 / 100) - t8juice), "profitPercent" : ((((dproductPrices["Pumpkin Moonshine"] * 95.5 / 100) - t8juice) / t8juice) * 100), "totalProfit": (((dproductPrices["Pumpkin Moonshine"] * 95.5 / 100) - t8juice) * (focus / dproductFocuses["Pumpkin Moonshine"])), "productionQuantity":(focus / dproductFocuses["Pumpkin Moonshine"])})

            results.sort(key=sortFunction, reverse=True)
            resultWindow = Toplevel()
            resultWindow.configure(background="gray")
            resultWindow.geometry("1050x750")

            Label(resultWindow, text = "İsim", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=0, padx=10, pady=10)
            Label(resultWindow, text = "Üretim Maliyeti (Silver)", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=1, padx=10, pady=10)
            Label(resultWindow, text = "Üretim Başına Kâr (Silver)", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=2, padx=10, pady=10)
            Label(resultWindow, text = "Üretim Başına Yüzde Kâr", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=3, padx=10, pady=10)
            Label(resultWindow, text = "Toplam Kâr (Silver)", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=4, padx=10, pady=10)
            Label(resultWindow, text = "Üretim Adedi (x5)", bg="gray", font="none 11 bold", fg = "orange").grid(row=0,column=5, padx=10, pady=10)
            
            i = 1
            for r in results:
                if i % 2 == 0:
                    fontColor = "purple"
                else:
                    fontColor = "blue"
                Label(resultWindow, text = r["name"], bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=0)
                Label(resultWindow, text = splitThreeDigits(round(r["productionPrice"])), bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=1)
                Label(resultWindow, text = splitThreeDigits(round(r["profitPerProduct"])), bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=2)
                Label(resultWindow, text = "% " + "{:.2f}".format(round(r["profitPercent"], 2)), bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=3)
                Label(resultWindow, text = splitThreeDigits(round(r["totalProfit"])), bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=4)
                Label(resultWindow, text = splitThreeDigits(round(r["productionQuantity"])), bg="gray", font="none 10 bold", fg = fontColor).grid(row=i,column=5)
                i += 1

        except DivisionByZero:
            messagebox.showerror("Hata", "Hiçbir şey 0'a bölünemez.")
        except:
            messagebox.showerror("Hata", "Hata")


def splitThreeDigits(num):
        if num == 0:
            return "0"
        x = 0
        if num < 0:
            x = -1 * num
        else:
            x = num
        a = str(x)
        if len(a) < 4 and num > 0:
            return a
        elif len(a) < 4 and num < 0:
            return "-" + a
        b = ""
        if len(a) % 3 == 1:
            b = a[0]
            a = a[1:]
        if len(a) % 3 == 2:
            b = a[0:2]
            a = a[2:]
        i = 0
        for i in range(len(a)):
            if(i % 3 == 0):
                b += "." + a[i]
            else:
                b += a[i]
            i += 1
        if b[0] == '.':
            b = b[1:]
        if num < 0:
            b = "-" + b
        return b

def sortFunction(e):
  return e["totalProfit"]

app = App()
app.run()