@SoftwareRequirementID_7732
Feature: Software Requirement 7732
	 The Customer Portal shall support Centrella bed firmware upgrade status report.

@TestCaseID_9901 @UISID_8684 @UISID_8692
Scenario: Centrella Firmware Upgrade Status Report Page Elements
	Given user is on Reports page
	And Centrella Asset type is selected
	And Firmware Status Report type is selected
	When user clicks Get report button
	Then Firmware Upgrade Status (Centrella) label is displayed
	And Print button is displayed
	And Information button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9902 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Upgrade Status Report Page Table Elements
	Given user is on Centrella Firmware Upgrade Status Report page
	Then "Serial number" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Ownership" column heading is displayed
	And "Status" column heading is displayed
	And "Last deployed" column heading is displayed
	And "Last connected" column heading is displayed

@TestCaseID_9903 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Upgrade Status Report Page Table Elements Columns
	Given user is on Centrella Firmware Upgrade Status Report page
	Then "Serial number" label is in column 1
	And "Firmware version" label is in column 2
	And "Ownership" label is in column 3
	And "Status" label is in column 4
	And "Last deployed" label is in column 5
	And "Last connected" label is in column 6

@TestCaseID_9904 @UISID_8684 @UISID_8692
Scenario: Centrella Firmware Upgrade Status Report Print
	Given user is on Centrella Firmware Upgrade Status Report page
	Then the Print button is enabled