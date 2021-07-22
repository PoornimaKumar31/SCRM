###
# Clear test data
###
# <task> Use options for:
#       user
#       password
#       <opt>input file     <serial>,<fragmentType>
#       <opt>serial number  (name)
#       <opt>operation type (fragmentType)
#       <opt>dryrun         Just prints report, no delete issued
#
# <task> Start with an array of serial numbers
# <task> Get deviceId for each serial number
#       https://incubator.deviot.hillrom.com/inventory/managedObjects?query=name%20eq%20'100020000000'
# <NOTE> Issuing a GET for the cleanup tasks returns the operations
# <NOTE> Issuing a DELETE for the cleanup tasks will delete the operations
# <task> Clean up Log Requests
#       https://incubator.deviot.hillrom.com/devicecontrol/operations?deviceId=3534645&fragmentType=c8y_LogfileRequest&status=PENDING
# <task> Clean up Firmware upgrades 
#       https://incubator.deviot.hillrom.com/devicecontrol/operations?deviceId=3535059&fragmentType=c8y_Firmware&status=EXECUTING
# 


import json
import csv
import argparse
import requests
from requests.auth import HTTPBasicAuth

defaultTenantUrl = "incubator.deviot.hillrom.com"

managedObjectQuery = "/inventory/managedObjects?query=name%20eq%20'{serial}'"
operationQuery = "/devicecontrol/operations?deviceId={deviceId}&fragmentType={fragmentType}&status={status}"

statuses = {"PENDING", "EXECUTING"}
# fragments = {"c8y_LogfileRequest", "c8y_Firmware", "c8y_DownloadConfigFile"}

# Initialize parser
parser = argparse.ArgumentParser()
 
# Adding optional argument
parser.add_argument("-u", "--user", help = "Cumulocity username with admin privileges.")
parser.add_argument("-p", "--password", help = "Password for admin Cumulocity user.")
parser.add_argument("-i", "--infile", help = "CSV file containing <serial>, <fragment> to be cleared.")
parser.add_argument("-s", "--serial", help = "Device serial number.")
parser.add_argument("-f", "--fragment", help = "Operation fragment type (c8y_LogfileRequest, c8y_Firmware, or c8y_DownloadConfigFile)")
parser.add_argument("-d", "--dryrun", action='store_true', help = "Dry run mode, do not delete found operations.")
parser.add_argument("-t", "--tenanturl", help = "Cumulocity tenant url e.g. 'incubator.deviot.hillrom.com'.")
 
# Read arguments from command line
args = parser.parse_args()

# TODO: Validate passed parameters
# TODO: Create processing queue
queue = [[args.serial, args.fragment]]

# If infile is passed load processing queue from file
if (args.infile):
    with open(args.infile, newline='') as csvfile:
        queue = list(csv.reader(csvfile))

# Create the query from tenant url
if (args.tenanturl):
    managedObjectQuery = "https://" + args.tenanturl + managedObjectQuery
    operationQuery = "https://" + args.tenanturl + operationQuery
else:
    managedObjectQuery = "https://" + defaultTenantUrl + managedObjectQuery
    operationQuery = "https://" + defaultTenantUrl + operationQuery

# TODO: Validate infile

# Process the queue
for item in queue:
    # print(item)

    # Extract item
    serial = item[0]
    fragment = item[1]

    # Get device id from serial number
    response = requests.get(managedObjectQuery.format(serial=serial), auth=HTTPBasicAuth(args.user, args.password))     

    if response.ok == False:
        print(response)
        print("Request failed, cannot continue.")
        exit(0)

    res = response.json()

    moCount = len(res['managedObjects'])
    
    # if moCount 0, no devices found report and skip
    if moCount == 0:
        print("Serial number {serial} not found, skipping.".format(serial=serial))
        continue

    # if moCount > 1 then report and skip
    if moCount > 1:
        print("Serial number {serial} produced {count} devices, cannot automatically clear operations, skipping.".format(serial=serial, count=moCount))
        continue

    # Extract the device id
    deviceId = res['managedObjects'][0]['id']

    print("Serial=" + serial + ",DeviceId=" + deviceId)

    # Foreach status
    for status in statuses:

        response = requests.get(operationQuery.format(deviceId=deviceId, fragmentType=fragment, status=status), auth=HTTPBasicAuth(args.user, args.password))
        
        if response.ok == False:
            print(response)
            print("Request failed, skipping.")
            continue

        res = response.json()
        
        # print(json.dumps(res, indent=4, sort_keys=True))

        opCount = len(res['operations'])
        if opCount > 0:
            for op in res['operations']:
                print("...{status} {fragment} id {opid} created {timestamp}".format(status=status, fragment=fragment, opid=op['id'], timestamp=op['creationTime']))
            
            if(args.dryrun == True):
                print("...dry run report only")
            else:
                # If not dry run mode, issue delete on the operation request
                print("...deleting")
                response = requests.delete(operationQuery.format(deviceId=deviceId, fragmentType=fragment, status=status), auth=HTTPBasicAuth(args.user, args.password))
                
                if response.ok:
                    print(str(response.status_code) + " success!")
                else:
                    print(str(response.status_code) + " delete failed!")

print("done!")