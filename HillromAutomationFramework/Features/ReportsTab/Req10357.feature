@SoftwareRequirementID_10357
Feature: Software Requirement 10357
	 The Customer Portal shall support Progressa bed firmware upgrade status report.

@TestCaseID_10873 @UISID_8684 @UISID_8692
 Scenario: Progressa Firmware Upgrade Status Report Page Elements
	Given user is on Reports page
	And Progressa Asset type is selected
	And Firmware Status Report type is selected
	When user clicks Get report button
	Then Firmware Upgrade Status Report (Progressa) label is displayed
	And Print button is displayed
	And Information button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_10874 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Upgrade Status Report Page Table Elements
	Given user is on Progressa Firmware Upgrade Status Report page
	Then "Serial number" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Ownership" column heading is displayed
	And "Status" column heading is displayed
	And "Last deployed" column heading is displayed
	And "Last connected" column heading is displayed

@TestCaseID_10875 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Upgrade Status Report Page Table Elements Columns
	Given user is on Progressa Firmware Upgrade Status Report page
	Then "Serial number" label is in column 1
	And "Firmware version" label is in column 2
	And "Ownership" label is in column 3
	And "Status" label is in column 4
	And "Last deployed" label is in column 5
	And "Last connected" label is in column 6

@TestCaseID_10876 @UISID_8684 @UISID_8692
Scenario: Progressa Firmware Upgrade Status Report Print
	Given user is on Progressa Firmware Upgrade Status Report page
	Then the Print button is enabled