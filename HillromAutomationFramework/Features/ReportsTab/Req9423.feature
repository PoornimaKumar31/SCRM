@SoftwareRequirementID_9423
Feature: Software Requirement 9423
	The customer portal shall display Centrella Activity report.

@TestCaseID_9894 @UISID_8684
Scenario: Centrella Report Type Dropdown Content
	Given user is on Reports page
	And Centrella Asset type is selected
	When user clicks report type dropdown
	Then Report type dropdown displays "Activity, Maintenance, Firmware Status, Firmware Version, Access Point Locations"

@TestCaseID_9895 @UISID_8684 @UISID_8693
Scenario: Centrella Activity Report Page Elements
	Given user is on Reports page
	And Centrella Asset type is selected
	And Activity Report type is selected
	When user clicks Get report button
	Then Activity Report (Centrella) label is displayed
	And Print button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9896 @UISID_8684 @UISID_8685 @UISID_8693
Scenario: Centrella Activity Report Page Table Elements
	Given user is on Centrella Activity Report page
	Then "Serial number" column heading is displayed
	And "AP location" column heading is displayed
	And "Patient present" column heading is displayed
	And "PM due" column heading is displayed

@TestCaseID_9897 @UISID_8684 @UISID_8685 @UISID_8693
Scenario: Centrella Activity Report Page Table Elements Columns
	Given user is on Centrella Activity Report page
	Then "Serial number" label is in column 1
	And "AP Location" label is in column 2
	And "Patient present" label is in column 3
	And "PM due" label is in column 4