@SoftwareRequirementID_5716
Feature: Software Requirement 5716
	Simple calculator for adding two numbers

@TestCaseID_9364 @UISID_8684 @UISID_8686
Scenario: CVSM Report Type Dropdown Content
	Given user is on Reports page
	And CVSM Asset type is selected in Asset type dropdown
	When user clicks report type dropdown
	Then Report type dropdown displays "Usage, Firmware Version, Access Point Locations"

@TestCaseID_9365 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CVSM Usage Report Elements
	Given user is on Reports page
	And CVSM Asset type is selected in Asset type dropdown
	And Usage Report type is selected
	When user clicks Get report button
	Then CVSM Asset Usage Report label is displayed
	And Print button is displayed
	And Number of Devices on Each Floor label is displayed
	And pie chart is displayed
	And Total Usage Details - Components label is displayed
	
@TestCaseID_9366 @UISID_8684 @UISID_8685 @UISID_8686	
Scenario: CVSM Usage Report Table Elements
	Given user is on CVSM Usage Report page
	Then assets are grouped by unit
	And all the devices within unit are displayed
	And "Model" column heading is displayed
	And "Asset tag" column heading is displayed
	And "Serial number" column heading is displayed
	And "Battery cycle count" column heading is displayed
	And "SureTemp thermometer cycle count" column heading is displayed
	And "NIBP sensor cycle count" column heading is displayed
	And "SpHb cycle count" column heading is displayed

@TestCaseID_9446 @UISID_8684 @UISID_8685 @UISID_8686	
Scenario: CVSM Usage Report Table Elements Columns
Given user is on CVSM Usage Report page
	Then "Model" label is in column 1
	And "Asset tag" label is in column 2
	And "Serial number" label is in column 3
	And "Battery cycle count" label is in column 4
	And "SureTemp thermometer cycle count" label is in column 5
	And "NIBP sensor cycle count" label is in column 6
	And "SpHb cycle count" label is in column 7

@TestCaseID_9367 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CVSM Usage Report Table Toggle
	Given user is on CVSM Usage Report page
	When user clicks unit toggle arrow
	Then assets for the unit are hidden

@TestCaseID_9368 @UISID_8684 @UISID_8686
Scenario: CVSM Usage Report Print
	Given user is on CVSM Usage Report page
	When user clicks Print button
	Then browser’s built-in print dialog is displayed

@TestCaseID_9369 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CVSM Firmware Version Report Elements
	Given user is on Reports page
	And CVSM Asset type is selected in Asset type dropdown
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (CVSM) label is displayed
	And "Components" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Total devices" column heading is displayed

@TestCaseID_9370 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CVSM Firmware Version Report Table Toggle
	Given user is on CVSM Firmware Version Report page
	When user clicks Total row
	Then rows below Total are displayed
	When user clicks unit row
	Then assets for unit are displayed

@TestCaseID_9371 @UISID_8684 @UISID_8687
Scenario: CVSM Firmware Version Report Print
	Given user is on CVSM Firmware Version Report page
	When user clicks Print button
	Then browser’s built-in print dialog is displayed