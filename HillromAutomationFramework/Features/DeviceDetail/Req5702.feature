@SoftwareRequirementID_5702
Feature: Software Requirement 5702
The Customer Portal shall have a mechanism for displaying CSM device details.

@TestCaseID_9673 @UISID_8672 @UISID_8677
Scenario: CSM General Layout
	Given user is on Asset List page with more than one CSM
	When user clicks any CSM
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection with Edit button is displayed
	And Preventive Maintenance tab is displayed
	And Component Information tab is displayed
	And Logs tab is displayed
	And Asset Detail subsection is displayed

@TestCaseID_9674 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details Connex Device
	Given user is on Component details page for CSM Serial number "100015671718"
	Then "Name" is "Connex Spot Monitor"
	And "Serial number" is "100015671718"
	And "Device hours on" label is displayed in "Usage" column
	And "Device hours on" is "0 hrs 1 mins 8 secs"

@TestCaseID_9675 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details Battery
	Given user is on Component details page for CSM Serial number "100015671718"
	Then battery row "Name" is "Battery Panasonic"
	And battery row "Manufacture Date" is "2014-09-16"
	And battery row "Serial number" is "304"
	And battery row "Cycle count" is displayed in "Usage" column
	And battery row "Cycle Count" is "Cycle Count: 16"
	When user clicks battery row toggle arrow
	Then battery "Temperature" label is displayed
	And battery "Temperature" is "03098 K"
	And battery "Remaining Capacity" label is displayed
	And battery "Remaining Capacity" is "96 %"
	And battery "Voltage" label is displayed
	And battery "Voltage" is "08378 mV"
	And battery "Full Charge Capacity" label is displayed
	And battery "Full Charge Capacity" is "03221 mAhr"
	And battery "Current" label is displayed
	And battery "Current" is "00317 mA"
	And battery "Cycle count" label is displayed
	And battery "Cycle count" is "16"
	And battery "Designed Capacity" label is displayed
	And battery "Designed Capacity" is "03200 mAh"
	And battery "Model Number" label is displayed
	And battery "Model Number" is "F41003017"
	And battery "Manufacture Date" label is displayed
	And battery "Manufacture Date" is "2014-09-16"
	And battery "Manufacture Name" label is displayed
	And battery "Manufacture Name" is "Panasonic"
	And battery "Serial Number" label is displayed
	And battery "Serial Number" is "304"

@TestCaseID_9676 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details APM
	Given user is on Component details page for CSM Serial number "100001232114"
	#Then APM row "Name" is "Accessory Power Module"
	Then APM battery row "Name" is "Battery-SANYO"
	And APM battery row "Manufacture Date" is "2015-12-28"
	And APM battery row "Serial number" is "310"
	And APM battery row "Cycle count" is displayed in "Usage" column
	And APM battery row "Cycle Count" is "Cycle Count: 16"
	When user clicks APM battery row toggle arrow
	Then APM battery "Temperature" label is displayed
	And APM battery "Temperature" is "03066 K"
	And APM battery "Voltage" label is displayed
	And APM battery "Voltage" is "11417 mV"
	And APM battery "Current" label is displayed
	And APM battery "Current" is "01975 mA"
	And APM battery "Remaining Capacity" label is displayed
	And APM battery "Remaining Capacity" is "36 %"
	And APM battery "Full Charge Capacity" label is displayed
	And APM battery "Full Charge Capacity" is "05789 mAhr"
	And APM battery "Cycle count" label is displayed
	And APM battery "Cycle count" is "16"
	And APM battery "Battery Designed Capacity" label is displayed
	And APM battery "Battery Designed Capacity" is "06000 mAh"
	And APM battery "Manufacture Date" label is displayed
	And APM battery "Manufacture Date" is "2015-12-28"
	And APM battery "Manufacture Name" label is displayed
	And APM battery "Manufacture Name" is "SANYO"
	And APM battery "Serial Number" label is displayed
	And APM battery "Serial Number" is "310"
	And APM battery "Combined Battery Remaining Capacity" label is displayed
	And APM battery "Combined Battery Remaining Capacity" is "36 %"
	And APM battery "Model Number" label is displayed
	And APM battery "Model Number" is "WELCH"
	And APM battery "PIC Processor Firmware Version" label is displayed
	And APM battery "PIC Processor Firmware Version" is "F2.00"

@TestCaseID_9677 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details NIBP
	Given user is on Component details page for CSM Serial number "100027113318"
	Then NIBP row "Name" is "NIBP Sensor"
	And NIBP row "Firmware version" is "1.00.00.0009"
	And NIBP row "Hardware version" is "NIBP_HW"
	And NIBP row "Serial number" is "NIBP_SERIAL"
	And NIBP row "Cycle count" is displayed in "Usage" column
	And NIBP row "Cycle Count" is "Cycle Count: 90"
	When user clicks NIBP row sensor toggle arrow
	Then NIBP "Last Calibration Date" label is displayed
	And NIBP "Last Calibration Date" is "2018/08/15"
	And NIBP "NIBP Module Cycle Count" label is displayed
	And NIBP "NIBP Module Cycle Count" is "90"
	And NIBP "Calibration Signature" label is displayed
	And NIBP "Calibration Signature" is "1096041777"

@TestCaseID_9678 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details SureTemp Probe
	Given user is on Component details page for CSM Serial number "100055940720"
	Then Temperature probe row "Name" is "Temperature Probe"
	And Temperature probe row "serial number" is "582010"
	And Temperature probe row "Cycle count" is displayed in "Usage" column
	And Temperature probe row "Cycle Count" is "23"
	When user clicks Temperature probe row toggle arrow
	Then Temperature probe "Probe type" label is displayed
	And Temperature probe "Probe type" is "ORAL"
	And Temperature probe "Probe Cycle Count" label is displayed
	And Temperature probe "Probe Cycle Count" is "23"
	And Temperature probe "Part number" label is displayed
	And Temperature probe "Part number" is "02692100"
	And Temperature probe "Lot Code" label is displayed
	And Temperature probe "Lot Code" is "582010"
	And Temperature probe "Lot Sequence Number" label is displayed
	And Temperature probe "Lot Sequence Number" is "150"
	And Temperature probe "Calibration Date" label is displayed
	And Temperature probe "Calibration Date" is "2021/05/29"
	And Temperature probe "Calibration Signature" label is displayed
	And Temperature probe "Calibration Signature" is "809588560"
	And Temperature probe "Last device serial number" label is displayed
	And Temperature probe "Last device serial number" is "01003111TJ"
	And Temperature probe "Number of times probe changed devices" label is displayed
	And Temperature probe "Number of times probe changed devices" is "2"

@TestCaseID_9679 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details SureTemp
	Given user is on Component details page for CSM Serial number "100055940720"
	Then SureTemp "Name" is "SureTemp Thermometer"
	And SureTemp "Firmware version" is "1.00.00.00006"
	And SureTemp "Hardware version" is "F"
	And SureTemp "Serial number" is "100029580720"
	And SureTemp "Cycle count" is displayed in "Usage" column
	And SureTemp "Cycle count" is "Cycle Count: 0"

@TestCaseID_9680 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details SpO2 Masimo
	Given user is on Component details page for CSM Serial number "100015671718"
	Then SpO2 Masimo "Name" is "SPO2 Sensor"
	When user clicks Masimo MX-7 toggle arrow
	Then Masimo "Firmware version" is "7.12.0.7"
	And Masimo "Hardware version" is "0x0501"
	And Masimo "Serial number" is "1806650697"
	And Masimo "Model number" label is displayed
	And Masimo "Model number" is "SPO2_MODEL"
	And Masimo "Module type" label is displayed
	And Masimo "Module type" is "2"

@TestCaseID_9681 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details SpO2 Nellcor
	Given user is on Component details page for CSM Serial number "100001954714"
	Then SpO2 Nellcor "Name" is "SPO2 Sensor"
	When user clicks Nellcor toggle arrow
	Then Nellcor "Firmware version" is "SPO2_FW"
	And Nellcor "Hardware version" is "GR101357E00"
	And Nellcor "Serial number" is "541418A5854"
	And Nellcor "Model number" label is displayed
	And Nellcor "Model number" is "10046102"
	And Nellcor "Module type" label is displayed
	And Nellcor "Module type" is "3"

@TestCaseID_9682 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details SpO2 Nonin
	Given user is on Component details page for CSM Serial number "100027113318"
	Then SpO2 Nonin "Name" is "SPO2 Sensor"
	When user clicks Nonin toggle arrow
	Then Nonin "Firmware version" is "45"
	And Nonin "Hardware version" is "ABC"
	And Nonin "Serial number" is "500"
	And Nonin "Model number" label is displayed
	And Nonin "Model number" is "SPO2_MODEL"
	And Nonin "Module type" label is displayed
	And Nonin "Module type" is "1"

@TestCaseID_9683 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Details Radio Newmar
	Given user is on Component details page for CSM Serial number "100027113318"
	Then Radio Newmar row "Name" is "Radio-Newmar"
	And Radio Newmar row "Firmware version" is "2.00.02 A0001"
	And Radio Newmar row "Serial number" is "RADIO_SN"
	When user clicks Radio-Newmar toggle arrow
	Then Radio Newmar "Access point MAC address" label is displayed
	And Radio Newmar "Access point MAC address" is "02:FA:E4:33:00:21"
	And Radio Newmar "Channel" label is displayed
	And Radio Newmar "Channel" is "0"
	And Radio Newmar "Connection Mode" label is displayed
	And Radio Newmar "Connection Mode" is "PSP"
	And Radio Newmar "SSID" label is displayed
	And Radio Newmar "SSID" is "com.welchallyn"
	And Radio Newmar "RSSI" label is displayed
	And Radio Newmar "RSSI" is "50"

@TestCaseID_9684 @UISID_8672 @UISID_8677 @UISID_8680
Scenario: CSM Asset Data Summary1
	Given user is on Component details page for CSM Serial number "100015671718"
	Then Summary CSM image is displayed
	And Summary "Asset name" label is displayed
	And Summary "Asset name" is "Connex Spot Monitor"
	And Summary "Serial number" label is displayed
	And Summary "Serial number" is "100015671718"
	And Summary "Model" label is displayed
	And Summary "Model" is "75MT"
	And Summary "Facility" label is displayed
	And Summary "Facility" is "Test1"
	And Summary "Last vital sent" label is displayed
	And Summary "Last vital sent" is "28 Jul 2021, 10:43 AM"
	And Summary "Location" label is displayed
	And Summary "Location" is "Mobile HotspotId"
	And Summary "Room/Bed" label is displayed
	And Summary "Room/Bed" is "/"
	And Summary "Asset tag" label is displayed
	And Summary "Asset tag" is "Hotspot"
	And Summary "IP address" label is displayed
	And Summary "IP address" is "10.18.5.33"
	And Summary "Ethernet MAC address" label is displayed
	And Summary "Ethernet MAC address" is "00:1A:FA:2E:56:75"
	And Summary "Radio IP address" label is displayed
	And Summary "Radio IP address" is "10.0.0.5"
	And Summary "Connection status" label is displayed
	#And Summary "Connection status" is "Last connected on: 15 Aug 2021, 10:49 PM"

