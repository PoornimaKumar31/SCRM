Instructions for use "clearops.py"

Date:       2021.07.22
Author:     Steven Morrow (Hillrom)
Purpose:    'clearops.py' script clears "in progress" operations in the Cumulocity platform.
            When automated testing is executed, several "in progress" operations are created
            on the platform.  This script can be used to remove them from the platform, resetting
            the data state for future automated test executions.  This script can clear operations
            for a single device, or via an input file with a list of devices.  This script can
            also be integrated into the CICD pipeline to ensure 'clean' data state for automated
            testing.

usage: clearops\.py \[\-h\] \[\-u USER\] \[\-p PASSWORD\] \[\-i INFILE\] \[\-s SERIAL\]
                   \[\-f FRAGMENT\] \[\-d\] \[\-t TENANTURL\]

optional arguments:
  -h, --help            show this help message and exit
  -u USER, --user USER  Cumulocity username with admin privileges.
  -p PASSWORD, --password PASSWORD
                        Password for admin Cumulocity user.
  -i INFILE, --infile INFILE
                        CSV file containing \<serial>, \<fragment> to be
                        cleared.
  -s SERIAL, --serial SERIAL
                        Device serial number.
  -f FRAGMENT, --fragment FRAGMENT
                        Operation fragment type (c8y\_LogfileRequest,
                        c8y\_Firmware, or c8y\_DownloadConfigFile)
  -d, --dryrun          Dry run mode, do not delete found operations.
  -t TENANTURL, --tenanturl TENANTURL
                        Cumulocity tenant url e.g.
                        'incubator.deviot.hillrom.com'.

Example:

python clearops.py -u \<adminuser> -p \<adminpassword> -i testfilelist.csv

Sample Output:

Serial=100010000000,DeviceId=3534645
...EXECUTING c8y\_LogfileRequest id 3569496 created 2021-07-22T13:36:58.262Z
...deleting
204 success!
Serial=100010000001,DeviceId=3534646
Serial=100010000005,DeviceId=3535059
Serial=100010000004,DeviceId=3535140
...EXECUTING c8y\_LogfileRequest id 3569498 created 2021-07-22T13:37:07.750Z
...deleting
204 success!
Serial=100010000006,DeviceId=3535141
Serial=100010000007,DeviceId=3535142
...EXECUTING c8y\_LogfileRequest id 3569602 created 2021-07-22T13:39:00.401Z
...deleting
204 success!
Serial=100020000000,DeviceId=3535162
Serial=100020000001,DeviceId=3545753
Serial=100020000008,DeviceId=3545775
Serial=100020000005,DeviceId=3545779
Serial=100020000003,DeviceId=3545873
Serial=100020000004,DeviceId=3545874
...EXECUTING c8y\_LogfileRequest id 3569168 created 2021-07-22T08:51:04.280Z
...deleting
204 success!
Serial=100020000006,DeviceId=3545875
...EXECUTING c8y\_LogfileRequest id 3569122 created 2021-07-22T06:00:30.089Z
...deleting
204 success!
Serial=100020000007,DeviceId=3545876
Serial=100020000002,DeviceId=3545895
Serial=100010000000,DeviceId=3534645
Serial=100010000001,DeviceId=3534646
Serial=100010000005,DeviceId=3535059
Serial=100010000004,DeviceId=3535140
Serial=100010000006,DeviceId=3535141
Serial=100010000007,DeviceId=3535142
Serial=100020000000,DeviceId=3535162
Serial=100020000001,DeviceId=3545753
Serial=100020000008,DeviceId=3545775
Serial=100020000005,DeviceId=3545779
Serial=100020000003,DeviceId=3545873
Serial=100020000004,DeviceId=3545874
Serial=100020000006,DeviceId=3545875
Serial=100020000007,DeviceId=3545876
Serial=100020000002,DeviceId=3545895
Serial=100010000000,DeviceId=3534645
Serial=100010000001,DeviceId=3534646
Serial=100010000005,DeviceId=3535059
Serial=100010000004,DeviceId=3535140
Serial=100010000006,DeviceId=3535141
Serial=100010000007,DeviceId=3535142
Serial=100020000000,DeviceId=3535162
Serial=100020000001,DeviceId=3545753
Serial=100020000008,DeviceId=3545775
Serial=100020000005,DeviceId=3545779
Serial=100020000003,DeviceId=3545873
Serial=100020000004,DeviceId=3545874
Serial=100020000006,DeviceId=3545875
Serial=100020000007,DeviceId=3545876
Serial=100020000002,DeviceId=3545895
done!