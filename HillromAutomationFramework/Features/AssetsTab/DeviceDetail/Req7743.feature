@SoftwareRequirementID_7743
Feature: Software Requirement 7743
	The customer portal shall display Centrella general service data.

@TestCaseID_9919 @UISID_8672 @UISID_9819
Scenario: Centrella General Layout
	Given user is on Asset List page with more than one Centrella
	When user clicks any Centrella
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection is displayed
	And Error codes tab is displayed
	And Preventive maintenance tab is displayed

@TestCaseID_9920 @UISID_8672 @UISID_9819
Scenario: Centrella Asset Data Summary
	Given user is on device details page for Centrella Serial number "PY673001"
	Then Summary Centrella image is displayed
	And Summary "Asset name" label is displayed
	And Summary "Asset name" is "Centrella"
	And Summary "Serial number" label is displayed
	And Summary "Serial number" is "PY673001"
	And Summary "Model" label is displayed
	And Summary "Model" is "P7900"
	And Summary "Facility" label is displayed
	And Summary "Facility" is "Batesville"
	And Summary "Connection status" label is displayed
	And Summary "Last connected on" label is displayed
	And Summary "Radio IP address" label is displayed
	And Summary "Radio IP address" is "10.0.0.13"
	And Summary "Radio SSID" label is displayed
	And Summary "Radio SSID" is "worklu2"
	And Summary "Radio MAC address" label is displayed
	And Summary "Radio MAC address" is "98:84:E3:46:4E:5B"
	And Summary "Radio RSSI" label is displayed
	And Summary "Radio RSSI" is "-68"
	And Summary "Location" label is displayed
	And Summary "Location" is "not set"
	And Summary "Room/bed/presence" label is displayed
	And Summary "Room/bed/presence" is "Room 15 / Patient Absent"
	And Summary "Firmware version" label is displayed
	And Summary "Firmware version" is "1.35.613"

@TestCaseID_9933 @UISID_9819
Scenario: Centrella Preventive Maintenance None
	Given user is on device details page for Centrella Serial number "PY9885"
	When user clicks Preventive maintenance tab
	Then "Preventive maintenance" label is displayed
	And "Recent maintenance history" label is displayed
	And "There is no maintenance history" label is displayed
	And service date picker control is displayed

@TestCaseID_9934 @UISID_9819
Scenario: Centrella Preventive Maintenance
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Preventive maintenance tab
	And clicks service date picker control
	And clicks a date other than today and not the same as the Maintenance date in the first row of the table
	Then date is displayed in Current maintenance date textbox
	And Save button is displayed
	And Cancel button is displayed
	When user clicks Save button
	Then Recently added Maintenance date is date picked
	And Recently added Modification date is today's date

@TestCaseID_9935 @UISID_9819
Scenario: Centrella Preventive Maintenance Table
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Preventive maintenance tab
	Then "Maintenance date" column is displayed
	And "User ID" column is displayed
	And "Modification date/time" column is displayed