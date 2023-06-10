from scapy.all import *
from scapy.all import raw
import time
import json
import psutil

def findAdapter():
    addresses = psutil.net_if_addrs()
    stats = psutil.net_if_stats()
    availableNetworks = []
    for intface, addrList in addresses.items():
        if any(getattr(addr, 'address').startswith("169.254") for addr in addrList):
            continue
        elif intface in stats and getattr(stats[intface], "isup"):
            availableNetworks.append(intface)
    
    for adap in availableNetworks:
        if "Ethernet" in adap:
            adapter = adap
            break
        elif "Wi-Fi" in adap:
            adapter = adap
            break
        else:
            adapter = "NF"
    
    if adapter == "NF":
        return "Error"
    return adapter

def getPackets(packet):
    rawPacket = str(raw(packet))
    if 'ItemTypeId' in rawPacket or 'ReferenceId' in rawPacket or '"}\\' in rawPacket:
        global startTime, interruptTime, packetCounter, rawString, exitCheck, errorControl
        interruptTime = 1
        startTime = time.time()
        packetCounter += 1
        errorControl, processedPackets = getProcessedPackets(rawPacket[2:-1])
        if errorControl:
            exitCheck = True
        rawString += processedPackets
        
def stopChecker(x):
    if exitCheck or time.time() - interruptTime > startTime:
        return True
    else:
        return False

def getProcessedPackets(rawPacket):    
    i = 0
    rawData = ''
    while i < len(rawPacket):
        if rawPacket[i] == '\\':
            i = i+4
        else:
            rawData += rawPacket[i]
            i += 1
    global startParameter
    if packetCounter == 1:
        idx = rawData.find('*x0b0eyys')
        startParameter = rawData[idx - 2:idx]
        rawData = rawData[idx + 9:]
    elif packetCounter == 3:
        idx = rawData.rfind(startParameter + '08', 0, 50)
        if idx == -1:
            idx = rawData.rfind(startParameter[1] + '08', 0, 50)
            rawData = rawData[idx + 3:]
        else:
            rawData = rawData[idx + 4:]
    elif packetCounter == 4:
        idx = rawData.rfind(startParameter + '8c', 0, 50)
        if idx == -1:
            idx = rawData.rfind(startParameter[1] + '8c', 0, 50)
            rawData = rawData[idx + 3:]
        else:
            rawData = rawData[idx + 4:]
    else:
        idx = rawData.rfind(startParameter, 0, 50)
        if idx == -1:
            idx = rawData.rfind(startParameter[1], 0, 50)
            rawData = rawData[idx + 1:]
        else:
            rawData = rawData[idx + 2:]
    idxLastPacketParameter = rawData[len(rawData) - 50:].find('"}yykk')
    if idxLastPacketParameter != -1:
        idxLastPacketParameter += len(rawData) - 50
        rawData = rawData[:idxLastPacketParameter + 2]
        global exitCheck
        exitCheck = True
    return False, rawData

def getProcessedString():
    try:
        semiProcessedData = ''
        idx = rawString.find('"}')
        semiProcessedData = rawString[:idx + 2] + "*#*"
        idx2 = len(semiProcessedData) - 3
        while rawString.find('{"', idx2) != -1:
            idx = rawString.find('{"', idx2)
            idx2 = rawString.find('"}', idx)
            semiProcessedData += rawString[idx:idx2+2] + "*#*"
        semiProcessedDataList = semiProcessedData[:-3].split('*#*')
        dataList = list()
        for i in semiProcessedDataList:
            x = ''
            if i[0] != '{':
                x = '{' + i
            else:
                x = i
            if i[-1] != '}':
                x = x + '}'
            dataList.append(x)
        toSendString = ''
        for item in dataList: 
            x = json.loads(item)
            toSendString += x['ItemTypeId'] + "-" + str(x['UnitPriceSilver'])[:-4] + "|"
        return "2" + toSendString[:-1].replace(r"\r\n", r"\n")
    except:
        return "0Error"

def listenPackets():
    adapter = findAdapter()
    if adapter == "Error":
        return "1Adaptör bulunamadı."
    sniff(iface = adapter, prn=getPackets, filter = "src host 5.188", stop_filter= stopChecker)
    if errorControl:
        return "0Error"
    return getProcessedString()

def main():
    global startParameter, rawString, packetCounter, startTime, interruptTime, exitCheck, errorControl
    for i in range(10):
        startParameter = ''
        rawString = ''   
        packetCounter = 0 
        startTime = time.time()
        interruptTime = 3
        exitCheck = False 
        errorControl = False
        result = listenPackets()
        if result[0] == "1":
            print("1Adaptör hatası, yazılımcı ile iletişime geçin. cakmalegolas@windowslive.com")
            return
        elif result[0] == "2":
            print(result)
            return
    print("0Hata.")

main()