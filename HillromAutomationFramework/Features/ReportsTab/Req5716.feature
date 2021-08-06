@SoftwareRequirementID_5716
Feature: Software Requirement 5716
	Simple calculator for adding two numbers

@TestCaseID_9364 @UISID_8684 @UISID_8686
Scenario: CVSM Report Type Dropdown Content
	Given user is on Reports page
	And CVSM Asset type is selected in Asset type dropdown
	When When user clicks report type dropdown
	Then Report type dropdown displays "Usage, Firmware V	ersion, Access Point Locations"

@TestCaseID_9365 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CVSM Usage Report Elements
	Given user is on Reports page
	And CVSM Asset type is selected in Asset type dropdown
	And Usage Report type is selected
	When user clicks Get report button
	Then CVSM Asset Usage Report label is displayed
	And Print button is displayed
	And Number of Devices on Each Floor label is displayed
	#We can't verify if Location ID is displayed or not
	And pie chart with Location ID is displayed
	And Total Usage Details - Components label is displayed

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