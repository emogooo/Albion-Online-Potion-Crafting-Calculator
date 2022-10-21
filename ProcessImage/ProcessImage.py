import matplotlib.pyplot as plt
import numpy as np
import pyautogui
import cv2
import sys
from win32.win32gui import FindWindow, GetWindowRect
import pytesseract as ts

def show(x):
    plt.imshow(x)
    plt.show()

def drawAndShow(img, coordinates):
    cv2.rectangle(img, (coordinates[0][0], coordinates[0][1]), (coordinates[1][0], coordinates[1][1]), (255,0,0), 1)
    show(img)

def getUniqueList(nList):
    nList = np.unique(nList)
    #print(nList)
    uniqueList = []
    for x in nList:
         if x - 1 not in nList and x - 2 not in nList and x - 3 not in nList:
            uniqueList.append(x)
    return uniqueList

def findAllMatches(img, templatePath, topAccuracy, botAccuracy):
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    template = cv2.imread(templatePath, 0)
    templateX, templateY = template.shape[::-1]   
    res = cv2.matchTemplate(imgRGB, template, cv2.TM_CCOEFF_NORMED)
    for accuracy in range (topAccuracy, botAccuracy - 1, -1):
        loc = np.where(res >= float(accuracy) / 100)
        yPos = getUniqueList(loc[0])
        #print(yPos)
        #print(accuracy)
        if len(yPos) > 5 and len(yPos) < 8:
            #for i in range(len(yPos)):
                 #drawAndShow(img, ((min(loc[1]), yPos[i]),(min(loc[1]) + templateX, yPos[i] + templateY)))
            return yPos, templateY
        elif len(yPos) > 7:
            return [], -1
    return [], -1

def findTemplate(img, templatePath, botAccuracy = 90):
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    imgX, imgY = imgRGB.shape[::-1]
    template = cv2.imread(templatePath, 0)
    templateX, templateY = template.shape[::-1]
    res = cv2.matchTemplate(imgRGB, template, cv2.TM_CCOEFF_NORMED)
    for accuracy in range (100, botAccuracy - 1, -1):
        loc = np.where(res >= float(accuracy) / 100)
        if len(loc[0]) > 0:
            averageOfXDimensions = int(sum(loc[1]) / len(loc[1]))
            averageOfYDimensions = int(sum(loc[0]) / len(loc[0]))
            if abs(averageOfXDimensions - min(loc[1])) > (imgX * 5 / 100) or abs(averageOfYDimensions - min(loc[0])) > (imgY * 5 / 100):
                return False, ((0, 0),(0, 0))
            startX = min(loc[1])
            startY = min(loc[0])
            #print(accuracy)
            return True, ((startX, startY),(startX + templateX, startY + templateY))

    return False, ((0, 0),(0, 0))

def main():
    try:
        windowHandle = FindWindow(None, "Albion Online Client")
        rect   = GetWindowRect(windowHandle)
    except:
        print("0Oyun açık gözükmüyor.")
        return
    startX = rect[0]
    startY = rect[1]
    if startX < -2000 or startY < -2000:
        print("0Oyun penceresi bulunamadı. Pencereyi ana ekrana taşıyıp tekrar deneyin.")
        return
    endX = rect[2]
    endY = rect[3]
    windowSizeX = endX - startX
    windowSizeY = endY - startY
    gameRes = "0x0"
    if windowSizeX > 1000 and windowSizeX < 1050 and windowSizeY > 760 and windowSizeY < 820:
        gameRes = "1024x768"
        buttonsCoordinateYEnd = 395
        buttonsCoordinateXStart = 635
        buttonsCoordinateXEnd = 680
        enchantPicCoordinateXStart = 10
        enchantPicCoordinateXEnd = 60
        enchantPicControlNumber = 40
        enchantX = 13
        enchantY = 39
        namePicCoordinateXStart = 85
        namePicCoordinateXEnd = 270
        pricePicCoordinateXStart = 347
        pricePicCoordinateXEnd = 460
    elif windowSizeX > 1900 and windowSizeX < 1950 and windowSizeY > 1050 and windowSizeY < 1100:
        gameRes = "1920x1080"
        buttonsCoordinateYEnd = 445
        buttonsCoordinateXStart = 715
        buttonsCoordinateXEnd = 765
        enchantPicCoordinateXStart = 5
        enchantPicCoordinateXEnd = 70
        enchantPicControlNumber = 55
        enchantX = 19
        enchantY = 44
        namePicCoordinateXStart = 90
        namePicCoordinateXEnd = 300
        pricePicCoordinateXStart = 388
        pricePicCoordinateXEnd = 510
    else:
        print("0Oyun çözünürlük ayarlarınız 1024x768 veya 1920x1080 olmalıdır. Eğer çözünürlük ayarlarınız bunlardan biri ise Windows görüntü ayarlarından uygulama ve metin ölçek ayarınızı %100'e çekin.")
        return

    img = pyautogui.screenshot()
    img = cv2.cvtColor(np.array(img), cv2.NORMAL_CLONE)
    img = img[startY:endY, startX:endX]
    templatePath = sys.argv[1] # C:/Users/HP/Desktop/Process Image/templates/
    topControl, topCoordinates = findTemplate(img, templatePath + "/topBar/" + gameRes + ".jpg", 90)
    if topControl:
        botControl, botCoordinates = findTemplate(img, templatePath + "/botBar/"+ gameRes + ".jpg", 90)
        if botControl:
            img = img[topCoordinates[1][1]:botCoordinates[0][1], topCoordinates[0][0]:botCoordinates[1][0]]
            resultList = list()
            ocrPath = sys.argv[2] # C:/Program Files/Tesseract-OCR/tesseract.exe
            windowName = sys.argv[3]
            ts.pytesseract.tesseract_cmd = ocrPath
            buttonImages = img[0:buttonsCoordinateYEnd, buttonsCoordinateXStart:buttonsCoordinateXEnd]
            yPos, templateY = findAllMatches(buttonImages, templatePath + "/button/" + gameRes + ".jpg", 79, 50)
            if templateY == -1:
                print("0Seçim butonları açık ve seçili şekilde görülmelidir.")
                return
            for y in yPos:
                if windowName == "product":
                    enchantPic = img[y:y + templateY + 20, enchantPicCoordinateXStart:enchantPicCoordinateXEnd]
                    _, _, encPicY = enchantPic.shape[::-1]
                    if encPicY < enchantPicControlNumber:
                        continue
                    enchantPic = cv2.cvtColor(enchantPic, cv2.COLOR_RGB2GRAY)
                    enchantPic = cv2.cvtColor(enchantPic, cv2.COLOR_GRAY2RGB)
                    enchantPic = cv2.threshold(enchantPic, 128, 255, cv2.THRESH_BINARY)[1]
                    if enchantPic[enchantY,enchantX][0] == 0:
                        enc = "0"
                    elif enchantPic[enchantY,enchantX][0] == 255:
                        enc = "1"
                namePic = img[y + 5:y + templateY + 8, namePicCoordinateXStart:namePicCoordinateXEnd]
                pricePic = img[y:y+templateY, pricePicCoordinateXStart:pricePicCoordinateXEnd]
                try:
                    name = ts.image_to_string(namePic)
                    price = ts.image_to_string(pricePic)
                except:
                    print("0Tesseract OCR Engine bulunamadı.")
                    return
                try:
                    price = price.replace('\n', '')
                    price = price.replace(',', '')            
                    int(price)
                except:
                    continue
                result = ""
                if windowName == "product":
                    result = name.replace('\n', '') + "-" + enc + "-" + price
                elif windowName == "productionMaterial":
                    result = name.replace('\n', '') + "-" + price
                else:
                    print("0Hatalı parametre gönderimi. Yazılımcı ile iletişime geçin. cakmalegolas@windowslive.com")
                    return
                resultList.append(result)
            if not resultList:
                print("0Görüntü yakalanamadı.")
                return
            else:
                resultStr = "1"
                for item in resultList:
                    resultStr = resultStr + item + "|"
                print(resultStr[:-1])
                return
        else:
            print("0Oyun HUD ölçek ayarınız %80 olmayabilir (1024x768 için %100 olmalıdır) veya doğru panelde olmayabilirsiniz. Hangi panelde olmanız gerektiğini bilmiyorsanız yazılımcı ile iletişime geçin. cakmalegolas@windowslive.com")
            return
    else:
        print("0Oyun HUD ölçek ayarınız %80 olmayabilir (1024x768 için %100 olmalıdır) veya doğru panelde olmayabilirsiniz. Hangi panelde olmanız gerektiğini bilmiyorsanız yazılımcı ile iletişime geçin. cakmalegolas@windowslive.com")
        return

main()