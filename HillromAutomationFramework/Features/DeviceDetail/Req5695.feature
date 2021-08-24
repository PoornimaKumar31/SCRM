@SoftwareRequirementID_5695
Feature: Software Requirement 5695
 The Customer Portal shall have a feature for displaying CVSM/CIWS device details.

@TestCaseID_9474 @UISID_8672 @UISID_8679
Scenario: CVSM General Layout
	Given user is on Asset List page with more than one CVSM
	When user clicks any CVSM
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection with Edit button is displayed
	And Preventive Maintenance tab is displayed
	And Component Information tab is displayed
	And Logs tab is displayed
	And Asset Detail subsection is displayed

@TestCaseID_9475 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Battery
	Given user is on Component details page for CVSM Serial number "103001220212"
	Then Battery "Name" is "Battery-SANYO"
	And Battery "Manufacture Date" is "2010/01/--"
	And Battery "Serial number" is "21"
	And Battery "Cycle count" is displayed in "Usage" column
	And Battery "Cycle Count" is "Cycle count: 2"
	When user clicks battery toggle arrow
	Then Battery "Temperature" label is displayed
	And Battery "Temperature" is "78.8 F"
	And Battery "Remaining Capacity" label is displayed
	And Battery "Remaining Capacity" is "99%"
	And Battery "Voltage" label is displayed
	And Battery "Voltage" is "12.467 Volts"
	And Battery "Full Charge Capacity" label is displayed
	And Battery "Full Charge Capacity" is "3.271 Ah"
	And Battery "Current" label is displayed
	And Battery "Current" is "0.584 A"
	And Battery "Avg. time to empty" label is displayed
	And Battery "Avg time to empty" is "65530 min"
	And Battery "Designed Capacity" label is displayed
	And Battery "Designed Capacity" is "4 Ah"
	And Battery "Avg. time to full charge" label is displayed
	And Battery "Avg. time to full charge" is "79 min"
	And Battery "Chemistry" label is displayed
	And Battery "Chemistry" is "LION"
	And Battery "DeviceName" label is displayed
	And Battery "DeviceName" is "WELCH"
	And Battery "Model name" label is displayed
	And Battery "Model name" is "Battery_REF"

@TestCaseID_9476 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Braun4000
	Given user is on Component details page for CVSM Serial number "103001220213"
	Then Braun4000 "Name" is "Braun Pro 4000 Thermometer"
	And Braun4000 "Firmware version" is "1.00.03"
	And Braun4000 "Hardware version" is "1"
	And Braun4000 "Serial number" is "103000413311"
	And Braun4000 "Cycle count" is displayed in "Usage" column
	And Braun4000 "Cycle Count" is "120"
	When user clicks Braun Pro 4000 toggle arrow
	Then Braun4000 "Model number" label is displayed
	And Braun4000 "Model number" is "407362"
	And Braun4000 "Dock cycle count" label is displayed
	And Braun4000 "Dock cycle count" is "44"

@TestCaseID_9477 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details CO2
	Given user is on Component details page for CVSM Serial number "103002311813"
	Then CO2 "Name" is "CO2 Sensor"
	And CO2 "Firmware version" is "1.10.02 103013"
	And CO2 "Hardware version" is "A01.01"
	And CO2 "Serial number" is "00121813BV"
	And CO2 "Run time" is displayed in "Usage" column
	And CO2 "Run time" is "232"
	When user clicks CO2 sensor toggle arrow
	Then CO2 "Hours to service" label is displayed
	And CO2 "Hours to service" is "29768"
	And CO2 "Max hours to calibration" label is displayed
	And CO2 "Max hours to calibration" is "971"
	And CO2 "Model number" label is displayed
	And CO2 "Model number" is "408259"
	And CO2 "OEM device name" label is displayed
	And CO2 "OEM device label" is "Oridion MicroMediCO2"
	And CO2 "OEM serial number" label is displayed
	And CO2 "OEM serial number" is "34548"

@TestCaseID_9478 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Deluxe Comms
	Given user is on Component details page for CVSM Serial number "100085374016"
	Then Deluxe Comms "Firmware version" is "1.00.00 A0003"
	And Deluxe Comms "Serial number" is "Comms_SERIAL"
	When user clicks Delux comms module toggle arrow
	Then Deluxe Comms "Model number" label is displayed
	And Deluxe Comms "Model number" is "Comms_REF"

@TestCaseID_9479 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details NIBP
	Given user is on Component details page for CVSM Serial number "103002311813"
	Then NIBP "Name" is "NIBP Sensor"
	And NIBP "Firmware version" is "2.05"
	And NIBP "Hardware version" is "Rev A"
	And NIBP "Serial number" is "05571213TJ"
	And NIBP "Cycle Count" label is displayed
	And NIBP "Cycle count" is displayed in "Usage" column
	And NIBP "Cycle Count" is "Cycle count:24"
	When user clicks NIBP sensor toggle arrow
	Then NIBP "Bootloader version" label is displayed
	And NIBP "Bootloader version" is "1.02"
	And NIBP "Model number" label is displayed
	And NIBP "Model number" is "405672"
	And NIBP "Safety version" label is displayed
	And NIBP "Safety version" is "1.03"

@TestCaseID_9480 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Printer
	Given user is on Component details page for CVSM Serial number "100085374016"
	Then Printer "Name" is "Printer"
	And Printer "Firmware version" is "FTP-628DSL601"
	And Printer "Serial number" is "54321000"
	When user clicks Printer toggle arrow
	Then Printer "Model number" label is displayed
	And Printer "Model number" is "Printer_REF2"

@TestCaseID_9481 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Temp Probe
	Given user is on Component details page for CVSM Serial number "100042631718"
	Then Temp Probe "Name" is "Temperature Probe"
	And Temp Probe "serial number" is "242013"
	And Temp Probe "Usage value" is "64"
	When user clicks Temperature probe toggle arrow
	Then Temp Probe "Model number" label is displayed
	And Temp Probe "Model number" is "Probe_REF2"
	And Temp Probe "Probe type" label is displayed
	#And Temp Probe "Probe type" is "Oral"
	And Temp Probe "Last device serial number" label is displayed
	#And Temp Probe "Last device serial number" is "00651718SS"
	And Temp Probe "Number of times probe changed devices" label is displayed
	#And Temp Probe "Number of times probe changed devices" is "7"
	And Temp Probe "Part number" label is displayed
	#And Temp Probe "Part number" is "02692100"

@TestCaseID_9482 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Scale
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then Scale "Name" is "Scale"
	And Scale "Firmware version" is "1.0.26"
	And Scale "Hardware version" is "1.0.1"
	And Scale "Serial number" is "0000011"
	And Scale "Cycle count" is displayed in "Usage" column
	And Scale "Cycle count" is "Cycle count: 1674"
	When user clicks Scale toggle arrow
	Then Scale "Model number" label is displayed
	And Scale "Model number" is "Health o meter Adapter"

@TestCaseID_9483 @UISID_8672 @UISID_8677 @UISID_8679
Scenario: CVSM Asset Details SpO2 Masimo
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then spo2 "Name" is "SPO2 Sensor"
	And spo2 "Firmware version" is "7.8.0.5"

@TestCaseID_9484 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details SpO2 Masimo License Yes
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then Masimo "Name" is "Masimo"
	And Masimo "Firmware version" is "2.1.0"
	And Masimo "Hardware version" is "0x0301"
	And Masimo "Serial number" is "MASIMO_SERIAL"
	And Masimo "Usage value" is "50"
	When user clicks Masimo toggle arrow
	Then Masimo "Model number" label is displayed
	And Masimo "Model number" is "3404"
	And Masimo "RRa license" label is displayed
	And Masimo "RRa license value" is "Yes"
	And Masimo "SpHb license" label is displayed
	And Masimo "SpHb License value" is "Yes"

@TestCaseID_9485 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details SpO2 Masimo License No
	Given user is on Component details page for CVSM Serial number "103001220216"
	When user clicks Masimo toggle arrow
	#Then Masimo "RRa license" label is displayed
	#And Masimo "RRa license value" is "No"
	Then Masimo "SpHb license" label is displayed
	And Masimo "SpHb License value" is "No"

@TestCaseID_9486 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details SpO2 Nellcor1
	Given user is on Component details page for CVSM Serial number "100085374016"
	Then SPO2 Nellcor "Name" is "SPO2 Sensor"
	And SPO2 Nellcor "Firmware version" is "1.2.1.0"

@TestCaseID_9487 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details SpO2 Nellcor2
	Given user is on Component details page for CVSM Serial number "100085374016"
	Then Nellcor "Name" is "Nellcor"
	And Nellcor "Firmware version" is "1.00.14"
	And Nellcor "Hardware version" is "Nellcor_HW"
	#And Nellcor "Serial number" is "0000011"
	When user clicks Nellcor toggle arrow
	Then Nellcor "Model number" label is displayed
	And Nellcor "Model number" is "405712"

@TestCaseID_9488 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details SureTemp
Given user is on Component details page for CVSM Serial number "100042631718"
	Then SureTemp "Name" is "Sure Temp Thermometer"
	And SureTemp "Firmware version" is "2.08"
	And SureTemp "Hardware version" is "BOM A ASSY A"
	And SureTemp "Serial number" is "00651718SS"
	And SureTemp "Usage value" is "1"

@TestCaseID_9489 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Radio Lamarr
	Given user is on Component details page for CVSM Serial number "100073764115"
	Then Radio Lamarr "Name" is "Radio-Lamarr"
	Then Radio Lamarr "Serial number" is "987654321"
	And Radio Lamarr "Usage value" is "N/A"
	When user clicks Radio-Lamarr toggle arrow
	Then Radio Lamarr "Access point MAC address" label is displayed
	And Radio Lamarr "Access point MAC address" is "78:BC:1A:B4:2A:24"
	And Radio Lamarr "Radio IP Address" label is displayed
	And Radio Lamarr "Radio IP Address" is "172.21.33.52"
	Then Radio Lamarr "MAC Address" label is displayed
	And Radio Lamarr "MAC Address" is "00:1A:FA:02:78:6A"
	And Radio Lamarr "Model Number" label is displayed
	And Radio Lamarr "Model Number" is "Lamarr_REF2"
	And Radio Lamarr "RSSI" label is displayed
	And Radio Lamarr "RSSI" is "61"
	And Radio Lamarr "Server Version" label is displayed
	And Radio Lamarr "Server Version" is "3.00.03"
	And Radio Lamarr "SSID" label is displayed
	And Radio Lamarr "SSID" is "c2-wpa2-aes.psk"

@TestCaseID_9490 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Details Radio Newmar
	Given user is on Component details page for CVSM Serial number "103001220213"
	Then Radio Newmar "Name" is "Radio-Newmar"
	And Radio Newmar "Firmware version" is "2.00.00"
	And Radio Newmar "Serial number" is "ABN_SERIALNUMBER"
	When user clicks Radio-Newmar toggle arrow
	Then Radio Newmar "Access point MAC address" label is displayed
	And Radio Newmar "Access point MAC address" is "78:BC:1A:9F:FD:C1"
	And Radio Newmar "Radio IP Address" label is displayed
	And Radio Newmar "Radio IP Address" is "172.21.34.53"
	Then Radio Newmar "MAC Address" label is displayed
	And Radio Newmar "MAC Address" is "00:17:23:E1:20:56"
	And Radio Newmar "Model Number" label is displayed
	And Radio Newmar "Model Number" is "ABN_REF"
	And Radio Newmar "RSSI" label is displayed
	And Radio Newmar "RSSI" is "50"
	And Radio Newmar "Server Version" label is displayed
	And Radio Newmar "Server Version" is "ABN_SVRVER"
	And Radio Newmar "SSID" label is displayed
	And Radio Newmar "SSID" is "c2-swtest.psk"

@TestCaseID_9491 @UISID_8672 @UISID_8677 @UISID_8679
Scenario: CVSM Asset Details Connex Device
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then Connex Device "Name" is "Welch Allyn Connex Device"
	And Connex Device "Serial number" is "103001220215"
	And Connex Device "Device hours on" label is displayed in "Usage" column
	And Connex Device "Device hours on" is "148 hrs 37 mins 0 secs"

@TestCaseID_9492 @UISID_8672 @UISID_8677 @UISID_8679
Scenario: CVSM Asset Details Host Controller
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then Host Controller "Name" is "Host Controller"
	And Host Controller "Firmware version" is "2.44.00 C0001"
	And Host Controller "hardware version" is "P5"
	And Host Controller "Serial number" is "103001220215"

@TestCaseID_9493 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Data Summary1
	Given user is on Component details page for CVSM Serial number "103001220215"
	Then Details Summary CVSM image is displayed
	And Details Summary "Asset name" label is displayed
	And Details Summary "Asset name" is "CVSM"
	And Details Summary "Serial number" label is displayed
	And Details Summary "Serial number" is "103001220215"
	And Details Summary "Model" label is displayed
	And Details Summary "Model" is "68MCTP"
	And Details Summary "Facility" label is displayed
	And Details Summary "Facility" is "Test1"
	And Details Summary "Location" label is displayed
	And Details Summary "Location" is "Andy's Desk"
	And Details Summary "Room/Bed" label is displayed
	And Details Summary "Room/Bed" is "/"
	And Details Summary "Asset tag" label is displayed
	And Details Summary "Asset tag" is "Andy's CVSM"
	And Details Summary "IP address" label is displayed
	And Details Summary "IP address" is "172.18.0.99"
	And Details Summary "Ethernet MAC address" label is displayed
	And Details Summary "Ethernet MAC address" is "00:1A:FA:21:05:90"
	And Details Summary "Radio IP address" label is displayed
	And Details Summary "Radio IP address" is "172.21.34.53"
	And Details Summary "Connection status" label is displayed

@TestCaseID_9494 @UISID_8672 @UISID_8679
Scenario: CVSM Asset Data Summary2
	Given user is on Component details page for CVSM Serial number "100020000000"
	Then Details Summary "Last configuration deployed" label is displayed
	And Details Summary "Last configuration deployed" is "PMP-100020000002-20210707-163030_CONFIG.PMP.settings"
	And Details Summary "Last customization deployed" label is displayed
	And Details Summary "Last customization deployed" is blank

@TestCaseID_9652 @UISID_8672 
Scenario: Locate Asset Button
	Given user is on Component details page for CVSM Serial number "100042631718"
	Then Locate Asset button is displayed