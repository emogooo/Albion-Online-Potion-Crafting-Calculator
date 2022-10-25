"""from win32.win32gui import FindWindow, GetWindowRect
from win32.win32api import GetSystemMetrics
import pytesseract as ts
import time
import cv2
import matplotlib.pyplot as plt
import pyautogui
import numpy as np"""



"""def show(x):
    plt.imshow(x)
    plt.show()
"""
#time.sleep(2)

#print(GetSystemMetrics(0), GetSystemMetrics(1))

"""windowHandle = FindWindow(None, "Hesap Makinesi")
rect   = GetWindowRect(windowHandle)
startX = rect[0]
startY = rect[1]
endX = rect[2]
endY = rect[3]
windowSizeX = endX - startX
windowSizeY = endY - startY
print(startX,startY,endX,endY)
print(windowSizeX,windowSizeY)

gameRes = "0x0"
if windowSizeX > 1000 and windowSizeX < 1050 and windowSizeY > 760 and windowSizeY < 820:
    gameRes = "1024x768"
elif windowSizeX > 1900 and windowSizeX < 1950 and windowSizeY > 1050 and windowSizeY < 1100:
    gameRes = "1920x1080"
else:
    print("Çözünürlük ayarlarınız 1024x768 veya 1920x1080 olmalıdır.")"""

"""img = pyautogui.screenshot()
img = cv2.cvtColor(np.array(img), cv2.NORMAL_CLONE)
img = img[startY:endY, startX:endX]
show(img)"""

"""ts.pytesseract.tesseract_cmd = "C:/Program Files/Tesseract-OCR/tesseract.exe"
img = cv2.imread("C:/Users/HP/Desktop/e.png")
img = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)[1]
img = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)[1]
show(img)
text = ts.image_to_string(img)
print(text)"""


"""
Scale = 100 iken
Eğer window modundaysa x 16 y 39 pixel artıyor. Çerçeve yüzünden.

Scale = 125 iken


"""

"""image = cv2.imread('C:/Users/HP/Desktop/d1024-768.jpeg',0)
image = cv2.cvtColor(image, cv2.COLOR_GRAY2RGB)
image = cv2.threshold(image, 155, 255, cv2.THRESH_BINARY)[1]
show(image)"""
#grayscale = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
#show(grayscale)

import sys
veri1 = sys.argv[0]
veri = sys.argv[1]
print(str(veri) + "-"+ veri1)
