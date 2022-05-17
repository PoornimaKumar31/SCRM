@SoftwareRequirementID_10362
Feature: Software Requirement 10362
	The customer portal shall display Progressa general service data.

@TestCaseID_10879 @UISID_8672 @UISID_9819
Scenario: Progressa General Layout
	Given user is on Asset List page with more than one Progressa
	When user clicks any Progressa
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection is displayed
	And Error codes tab is displayed
	And Preventive maintenance tab is displayed

@TestCaseID_10880 @UISID_8672 @UISID_9819
Scenario: Progressa Asset Data Summary
	Given user is on device details page for Progressa Serial number "PY685010"
	Then Summary Progressa image is displayed
	And Summary "Asset name" label is displayed
	And Summary "Asset name" is "Progressa"
	And Summary "Serial number" label is displayed
	And Summary "Serial number" is "PY685010"
	And Summary "Model" label is displayed
	And Summary "Model" is "P7500"
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
	And Summary "Radio RSSI" is "-66"
	And Summary "Facility" label is displayed
	And Summary "Facility" is "Batesville"
	And Summary "Room/bed/presence" label is displayed
	And Summary "Room/bed/presence" is "Room 16 / Patient Absent"
	And Summary "Firmware version" label is displayed
	And Summary "Firmware version" is "1.35.613"

@TestCaseID_10881 @UISID_9819
Scenario: Progressa Preventive Maintenance None
	Given user is on device details page for Progressa Serial number "PY685010"
	When user clicks Preventive maintenance tab
	Then "Preventive maintenance" label is displayed
	And "Recent maintenance history" label is displayed
	And "There is no maintenance history." label is displayed
	And service date picker control is displayed

@TestCaseID_10882 @UISID_9819
Scenario: Progressa Preventive Maintenance
	Given user is on device details page for Progressa Serial number "PY685009"
	When user clicks Preventive maintenance tab
	And clicks service date picker control
	And clicks a date other than today and not the same as the Maintenance date in the first row of the table
	Then date is displayed in Current maintenance date textbox
	And Save button is displayed
	And Cancel button is displayed
	When user clicks Save button
	Then Recently added Maintenance date is date picked
	And Recently added Modification date is today's date

@TestCaseID_10883 @UISID_9819
Scenario: Progressa Preventive Maintenance Table
	Given user is on device details page for Progressa Serial number "PY685009"
	When user clicks Preventive maintenance tab
	Then "Maintenance date" column is displayed
	And "User ID" column is displayed
	And "Modification date/time" column is displayed