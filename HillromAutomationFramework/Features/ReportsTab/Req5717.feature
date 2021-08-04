@SoftwareRequirementID_5717
Feature: Software Requirement 5717
	The Customer Portal shall have a feature for generating following CSM reports:
	Usage Report
	Firmware version report
	Configuration Update report
	Firmware Status report
	Activity report

@TestCaseID_9372 @UISID_8684 @UISID_8686
Scenario: CSM Report Type Dropdown Content
	Given user is on Reports page
	And CSM Asset type is selected
	When user clicks report type dropdown
	Then Report type dropdown displays "Usage, Firmware version, CFG Update Status, Firmware status, Activity"

@TestCaseID_9373 @UISID_8684 @UISID_8686
Scenario: CSM Usage Report Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Usage Report type is selected
	When user clicks Get report button
	Then Asset Usage Report (CSM) label is displayed
	And Print button is displayed
	And Number of Devices on Each Floor label is displayed
	And pie chart with Location ID is displayed
	And Total Usage Details - Components label is displayed

@TestCaseID_9374 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CSM Usage Report Table Elements
	Given user is on CSM Usage Reports page
	Then Assets are grouped by unit
	And all the devices within that location ID is displayed
	And "Model" column heading is displayed
	And "Asset tag" column heading is displayed
	And "Serial number" column heading is displayed
	And "Battery cycle count" column heading is displayed
	And "SureTemp thermometer cycle count" column heading is displayed
	And "NIBP sensor cycle count" column heading is displayed
	And "SpHb cycle count" column heading is displayed

@TestCaseID_9375 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CSM Usage Report Table Toggle
	Given user is on CSM Usage Reports page
	When user clicks unit row
	Then assets for unit are hidden

@TestCaseID_9376 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CSM Firmware Version Report Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (CSM) label is displayed
	And Components column heading is displayed
	And Firmware version column heading is displayed
	And Total devices column heading is displayed

@TestCaseID_9377 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CSM Firmware Version Report Table Toggle
	Given user is on CSM Firmware Version Report page
	When user clicks Total row
	Then rows below Total are hidden
	#When user clicks unit row
	#Then assets for unit are hidden