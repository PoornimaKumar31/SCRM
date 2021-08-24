@SoftwareRequirementID_6118
Feature: Software Requirement 6118
	The Customer Portal shall have a feature for generating following RV700 reports:
	Firmware version report
	Firmware Status report

@TestCaseID_9417 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: RV700 Firmware Version Report Elements
	Given user is on Reports page
	And RV700 Asset type is selected
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (RV700) label is displayed
	And Components column heading is displayed
	And Firmware version column heading is displayed
	And Total devices column heading is displayed

@TestCaseID_9418 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: RV700 Firmware Version Report Table Toggle
	Given user is on RV700 Firmware Version Report page
	When user clicks Total row
	Then rows below Total are displayed
	When user clicks unit row
	Then assets for unit are displayed

@TestCaseID_9419 @UISID_8684 @UISID_8687
Scenario: RV700 Firmware Version Report Print
	Given user is on RV700 Firmware Version Report page
	Then the Print button is enabled

@TestCaseID_9420 @UISID_8684 @UISID_8687
Scenario: RV700 Firmware Upgrade Status Report Page Elements
	Given user is on Reports page
	And RV700 Asset type is selected
	And Firmware Status Report type is selected
	When user clicks Get report button
	Then Firmware Upgrade Status Report (RV700) label is displayed
	And Print button is displayed
	And Information button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9421 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: RV700 Firmware Upgrade Status Report Page Table Elements
	Given user is on RV700 Firmware Upgrade Status Report page
	Then "Serial number" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Location" column heading is displayed
	And "Status" column heading is displayed
	And "Last deployed" column heading is displayed
	And "Last connected" column heading is displayed

@TestCaseID_9451 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: RV700 Firmware Upgrade Status Report Page Table Elements Columns
	Given user is on RV700 Firmware Upgrade Status Report page
	Then "Serial number" label is in column 1
	And "Firmware version" label is in column 2
	And "Location" label is in column 3
	And "Status" label is in column 4
	And "Last deployed" label is in column 5
	And "Last connected" label is in column 6

@TestCaseID_9422 @UISID_8684 @UISID_8692
Scenario: RV700 Firmware Upgrade Status Report Print
	Given user is on RV700 Firmware Upgrade Status Report page
	Then the Print button is enabled