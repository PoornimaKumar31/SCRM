@SoftwareRequirementID_10359
Feature: Software Requirement 10359
	The Customer Portal shall support Progressa bed firmware version report

@TestCaseID_10870 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: Progressa Firmware Version Report Elements
	Given user is on Reports page
	And Progressa Asset type is selected in Asset type dropdown
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (Progressa) label is displayed
	And "Components" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Total devices" column heading is displayed

@TestCaseID_10871 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: Progressa Firmware Version Report Table Toggle
	Given user is on Progressa Firmware Version Report page
	When user clicks Total row
	Then rows below Total are displayed
	When user clicks unit row
	Then assets for unit are displayed

@TestCaseID_10872 @UISID_8684 @UISID_8687
Scenario: Progressa Firmware Version Report Print
	Given user is on Progressa Firmware Version Report page
	Then the Print button is enabled