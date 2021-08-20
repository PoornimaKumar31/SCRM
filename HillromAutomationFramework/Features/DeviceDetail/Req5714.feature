@SoftwareRequirementID_5714
Feature: Software Requirement 5714
	  The customer portal shall have a mechanism for displaying RV700 device details.

@TestCaseID_9702 @UISID_8672 @UISID_8677 @UISID_8681
Scenario: RV700 General Layout
	Given user is on Asset List page with more than one RV700
	When user clicks any RV700
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection with Edit button is displayed
	And Component Information tab is displayed
	And Logs tab is displayed
	And Asset Detail subsection is displayed

@TestCaseID_9704 @UISID_8672 @UISID_8681
Scenario: RV700 Asset Data Summary
	Given user is on Component details page for RV700 Serial number "700090000023"
	Then RV700 image is displayed
	And summary "Asset name" label is displayed
	And summary "Asset name" is "RV700"
	And summary "Asset tag" label is displayed
	And summary "Asset tag" is blank
	And summary "Serial number" label is displayed
	And summary "Serial number" is "700090000023"
	And summary "IP address" label is displayed
	And summary "IP address" is "172.18.26.110"
	And summary "Model" label is displayed
	And summary "Model" is "N/A"
	And summary "Radio MAC address" label is displayed
	And summary "Radio MAC address" is "00:17:23:ef:9e:0b"
	And summary "Facility" label is displayed
	And summary "Facility" is "Test1"
	And summary "Radio IP address" label is displayed
	And summary "Radio IP address" is blank
	And summary "Location" label is displayed
	And summary "Location" is "(not set)"
	And summary "Connection status" label is displayed
	#And summary "Connection status" is "Last connected on: 11 Jul 2021, 10:04 PM"
	And summary "Room/Bed" label is displayed
	And summary "Room/Bed" is "/"
	And summary "Last firmware deployed" label is displayed
	And summary "Last firmware deployed" is blank
	And summary "Last configuration deployed" label is displayed
	And summary "Last configuration deployed" is blank

@TestCaseID_9705 @UISID_8672 @UISID_8677 @UISID_8681
Scenario: RV700 Asset Details Connex Device
	Given user is on Component details page for RV700 Serial number "700090000023"
	Then "Name" is "RV 700"
	And "Firmware version" is "1.20.01-A0004"
	And "Serial number" is "700090000023"

@TestCaseID_9706 @UISID_8672 @UISID_8677 @UISID_8681
Scenario: RV700 Asset Details Radio Newmar
	Given user is on Component details page for RV700 Serial number "700090000023"
	Then Radio "Name" is "Newmar"
	Then Radio "Firmware version" is "2.00.02 A0001"
	And Radio "Serial number" is "NA"
	When user clicks Newmar toggle arrow
	Then Radio "GUID" label is displayed
	And Radio "GUID" is "NA"
	And Radio "MAC Address" label is displayed
	And Radio "MAC Address" is "00:17:23:ef:9e:0b"
	And Radio "IP Address" label is displayed
	And Radio "IP Address" is "172.18.26.110"
	#And Radio "Model Number" label is displayed
	#And Radio "Model Number" is "ABN_REF"
	And Radio "RSSI" label is displayed
	And Radio "RSSI" is "-49"