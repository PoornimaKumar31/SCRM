@SoftwareRequirementID_5715
Feature: Software Requirement 5715
	The Customer Portal shall have a mechanism for delivering RV700 device firmware.

@TestCaseID_9405 @UISID_8696 @UISID_8669
Scenario: RV700 Upgrade Elements
	Given user is on RV700 Updates page
	And RV700 Asset type is selected
	When user selects Upgrade Update type
	Then Upgrade displays as Update type
	And RV700 upgrade list is displayed
	And "Name" column heading is displayed
	And "Date created" column heading is displayed
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9406 @UISID_8696 @UISID_8669
Scenario: RV700 Upgrade Less Than or Equal to 50
	Given user is on RV700 Updates page with "<=50" entries
	Then Next page icon is disabled
	And Previous page icon is disabled
	

@TestCaseID_9407 @UISID_8697
Scenario: RV700 Upgrade Selected
	Given user is on RV700 Updates page
	And RV700 Asset type is selected
	And Upgrade Update type is selected
	And user has selected Upgrade file
	When user clicks Next button
	Then RV700 Select assets page is displayed

@TestCaseID_9408 @UISID_8697 @UISID_8669
Scenario: RV700 Select Assets Elements
	Given user is on RV700 Upgrade Select assets page
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

@TestCaseID_9409 @UISID_8697
Scenario: RV700 Select Assets Elements Table
	Given user is on RV700 Upgrade Select assets page
	Then Select all checkbox is unchecked
	And "Firmware" column heading is displayed
	And "Config" column heading is displayed
	And "Asset Tag" column heading is displayed
	And "Serial Number" column heading is displayed
	And "Ownership" column heading is displayed
	And "Last Files Deployed" column heading is displayed

@TestCaseID_9410 @UISID_8697
Scenario: RV700 Select Assets Elements Table Columns
	Given user is on RV700 Upgrade Select assets page
	Then Select all checkbox is in column 1
	And "Firmware" label is in column 2
	And "Config" label is in column 3
	And "Asset Tag" label is in column 4
	And "Serial Number" label is in column 5
	And "ownership" label is in column 6
	And "Last Files Deployed" label is in column 7

@TestCaseID_9411 @UISID_8697
Scenario: RV700 Select Assets
	Given user is on RV700 Upgrade Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

@TestCaseID_9412 @UISID_8697
Scenario: RV700 Select Assets Previous
	Given user is on RV700 Upgrade Select assets page
	When user clicks Previous button
	Then RV700 Updates page is displayed

@TestCaseID_9413 @UISID_8698
Scenario: RV700 Review Action Page
	Given user is on RV700 Upgrade Select assets page
	When user selects one device
	And Clicks Next button
	Then RV700 Review Action page is displayed

@TestCaseID_9414 @UISID_8698
Scenario: RV700 Review Action Elements
	Given user is on RV700 Review Action page
	Then Item to push label is displayed
	And Item to push value is displayed
	And Destinations label is displayed
	And Destinations value is displayed
	And Select update indicator is not highlighted
	And Select assets indicator is not highlighted
	And Review action indicator is highlighted
	And Previous button is enabled
	And Confirm button is enabled

@TestCaseID_9415 @UISID_8698
Scenario: RV700 Review Action Confirm
	Given user is on RV700 Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select assets page is displayed

@TestCaseID_9416 @UISID_8698
Scenario: RV700 Review Action Previous
	Given user is on RV700 Review Action page
	When user clicks Previous button
	Then Select assets page is displayed