import PCD_SIATA as PCD
import time
import pyodbc
from cloudant.client import Cloudant


def main(data, id):
    global client
    global dbname

    dbhost = "https://" + "2080e923-0239-4314-843c-505bc43a74c2-bluemix"+".cloudant.com"
    client = Cloudant("2080e923-0239-4314-843c-505bc43a74c2-bluemix",
                      "91cda9f0ff213a2bdb204dd1c5100b5e54d664b4e0175ad0ea7294b11304dd37", url=dbhost, connect=True)
    dbname = "siata"

    my_database = client[dbname]
    updateDocument(data, id)
    client.disconnect()


def updateDocument(data, id):
    global client
    global dbNameProcessed

    mydb = client[dbname]
    doc = {
        "_id": id,
        'datos': data
    }
    mydoc = mydb.create_document(doc)
    return mydoc


run = True
while(run):
    data = PCD.SIATA('https://siata.gov.co/siata_nuevo/')
    main(data, time.ctime())
    time.sleep(180)
