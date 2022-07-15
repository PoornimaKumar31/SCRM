@SoftwareRequirementID_5705
Feature: Software Requirement 5705
	The Customer Portal shall have a mechanism for delivering upgrade firmware 
	to one or more CSM devices.

@TestCaseID_9153 @UISID_8696 @UISID_8669
Scenario: CSM Upgrade Elements
	Given user is on CSM Updates page
	And CSM Asset type is selected
	When user selects Upgrade Update type
	Then Upgrade displays as Update type
	And CSM upgrade list is displayed
	And Manage Active Updates button is displayed
	And Name column heading is displayed
	And Date created column heading is displayed
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9156 @UISID_8696 @UISID_8669
Scenario: CSM Upgrade files Greater Than 50 and Less Than or Equal to 100 Next
	Given user is on CSM Updates page with ">50 and <=100" entries
	When first 50 entries are displayed
	Then Next page icon is enabled
	And Previous page icon is disabled
	When user clicks Next page button
	Then second page of entries is displayed
	And Next page icon is disabled
	And Previous page icon is enabled

@TestCaseID_9157 @UISID_8697
Scenario: CSM Upgrade Selected
	Given user is on CSM Updates page
	And CSM Asset type is selected
	And Upgrade Update type is selected
	And user has selected Upgrade file
	When user clicks Next button
	Then CSM Select assets page is displayed

@TestCaseID_9158 @UISID_8697 @UISID_8669
Scenario: CSM Select Assets Elements Upgrade
	Given user is on CSM Upgrade Select assets page
	Then Select update indicator is not highlighted
	And Select assets indicator is highlighted
	And Review action indicator is not highlighted
	And "Item to push" label is displayed
	And "Asset type" label is displayed
	And "Update type" label is displayed
	And "Upgrade file to push" label is displayed
	And "Destinations" label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Previous button is enabled
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9159 @UISID_8697
Scenario: CSM Select Assets Elements Table Upgrade
	Given user is on CSM Upgrade Select assets page
	Then Select all checkbox is unchecked
	And "Firmware" column heading is displayed
	And "Config" column heading is displayed
	And "Asset Tag" column heading is displayed
	And "Serial Number" column heading is displayed
	And "Ownership" column heading is displayed
	And "Last Files Deployed" column heading is displayed

@TestCaseID_9211 @UISID_8697
Scenario: CSM Select Assets Elements Table Columns Upgrade
	Given user is on CSM Upgrade Select assets page
	Then Select all checkbox is in column 1
	And "Firmware" label is in column 2
	And "Config" label is in column 3
	And "Asset Tag" label is in column 4
	And "Serial Number" label is in column 5
	And "Ownership" label is in column 6
	And "Last Files Deployed" label is in column 7

@TestCaseID_9160 @UISID_8697
Scenario: CSM Select Assets Upgrade
	Given user is on CSM Upgrade Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

@TestCaseID_9161 @UISID_8697
Scenario: CSM Select Assets Previous Upgrade
	Given user is on CSM Upgrade Select assets page
	When user clicks Previous button
	Then CSM Updates page is displayed

@TestCaseID_9162 @UISID_8698
Scenario: CSM Review Action Page Upgrade
	Given user is on CSM Upgrade Select assets page
	When user selects one device
	And Clicks Next button
	Then CSM Review Action page is displayed

@TestCaseID_9163 @UISID_8698
Scenario: CSM Review Action Elements Upgrade
	Given user is on CSM Review Action page
	Then Item to push label is displayed
	And Item to push value is displayed
	And Destinations label is displayed
	And Destinations value is displayed
	And Date or Time of push label is displayed
	And Immediately label is displayed
	And Radio Button is displayed for Immediately 
	And it is selected
	And Radio Button is displayed for schedule
	And Schedule label is displayed
	And Select update indicator is not highlighted
	And Select assets indicator is not highlighted
	And Review action indicator is highlighted
	And Previous button is enabled
	And Confirm button is enabled

@TestCaseID_9164 @UISID_8698
Scenario: CSM Review Action Confirm Upgrade
	Given user is on CSM Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select assets page is displayed

@TestCaseID_9165 @UISID_8698
Scenario: CSM Review Action Previous Upgrade
	Given user is on CSM Review Action page
	When user clicks Previous button
	Then Select assets page is displayed