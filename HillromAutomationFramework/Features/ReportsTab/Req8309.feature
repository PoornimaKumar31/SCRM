@SoftwareRequirementID_8309
Feature: Software Requirement 8309
	The Customer Portal shall support Centrella bed firmware version report

@TestCaseID_9898 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: Centrella Firmware Version Report Elements
	Given user is on Reports page
	And Centrella Asset type is selected in Asset type dropdown
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (Centrella) label is displayed
	And "Components" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Total devices" column heading is displayed

@TestCaseID_9899 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: Centrella Firmware Version Report Table Toggle
	Given user is on Centrella Firmware Version Report page
	When user clicks Total row
	Then rows below Total are displayed
	When user clicks unit row
	Then assets for unit are displayed

@TestCaseID_9900 @UISID_8684 @UISID_8687
Scenario: Centrella Firmware Version Report Print
	Given user is on Centrella Firmware Version Report page
	Then the Print button is enabled