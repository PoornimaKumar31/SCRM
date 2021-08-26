@SoftwareRequirementID_7731
Feature: Software Requirement 7731
   The Customer Portal shall have a mechanism for delivering firmware upgrade to one or more Centrella beds.

@TestCaseID_9943 @UISID_8696 @UISID_8669
Scenario: Centrella Upgrade Elements
	Given user is on Centrella Updates page
	And Centrella Asset type is selected
	When user selects Upgrade Update type
	Then Upgrade displays as Update type
	And Centrella upgrade list is displayed
	And Name column heading is displayed
	And Date created column heading is displayed
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9944 @UISID_8697
Scenario: Centrella Upgrade Selected
	Given user is on Centrella Updates page
	And Centrella Asset type is selected
	And Upgrade Update type is selected
	And user has selected Upgrade file
	When user clicks Next button
	Then Centrella Select assets page is displayed

@TestCaseID_9945 @UISID_8697 @UISID_8669
Scenario: Centrella Select Assets Elements
	Given user is on Centrella Upgrade Select assets page
	Then Select update indicator is not highlighted
	And Select assets indicator is highlighted
	And Review action indicator is not highlighted
	And "Item to push" label is displayed
	And "Device type" label is displayed
	And "Update type" label is displayed
	And "Upgrade file to push" label is displayed
	And "Destinations" label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Previous button is enabled
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9946 @UISID_8697
Scenario: Centrella Select Assets Elements Table
	Given user is on Centrella Upgrade Select assets page
	Then Select all checkbox is unchecked
	And "Firmware" column heading is displayed
	And "Config" column heading is displayed
	And "Asset Tag" column heading is displayed
	And "Serial number" column heading is displayed
	And "Location" column heading is displayed
	And "Last Files Deployed" column heading is displayed

@TestCaseID_9947 @UISID_8697
Scenario: Centrella Select Assets Elements Table Columns
	Given user is on Centrella Upgrade Select assets page
	Then Select all checkbox is in column 1
	And "Firmware" label is in column 2
	And "Config" label is in column 3
	And "Asset Tag" label is in column 4
	And "Serial number" label is in column 5
	And "Location" label is in column 6
	And "Last Files Deployed" label is in column 7

@TestCaseID_9948 @UISID_8697
Scenario: Centrella Select Assets
	Given user is on Centrella Upgrade Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

@TestCaseID_9949 @UISID_8697
Scenario: Centrella Select Assets Previous
	Given user is on Centrella Upgrade Select assets page
	When user clicks Previous button
	Then Centrella Updates page is displayed

@TestCaseID_9950 @UISID_8698
Scenario: Centrella Review Action Page
	Given user is on Centrella Upgrade Select assets page
	When user selects one device
	And clicks Next button
	Then Centrella Review Action page is displayed

@TestCaseID_9951 @UISID_8698
Scenario: Centrella Review Action Elements
	Given user is on Centrella Review Action page
	Then Item to push label is displayed
	And Item to push value is displayed
	And Destinations label is displayed
	And Destinations value is displayed
	And Date or Time of push label is displayed
	And Immediately label is displayed
	And radio button is displayed for Immediately
	And it is selected
	And radio button is displayed for schedule
	And Schedule label is displayed
	And Select update indicator is not highlighted
	And Select assets indicator is not highlighted
	And Review action indicator is highlighted
	And Previous button is enabled
	And Confirm button is enabled

@TestCaseID_9952 @UISID_8698
Scenario: Centrella Review Action Confirm
	Given user is on Centrella Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select assets page is displayed

@TestCaseID_9953 @UISID_8698
Scenario: Centrella Review Action Previous
	Given user is on Centrella Review Action page
	When user clicks Previous button
	Then Select assets page is displayed