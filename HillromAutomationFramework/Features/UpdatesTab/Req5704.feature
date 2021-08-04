@SoftwareRequirementID_5704
Feature: Software Requirement 5704
	 The Customer Portal shall have a mechanism for delivering a configuration to one or more CSM devices.

@TestCaseID_9083 @UISID_8696
Scenario: Select CSM Asset Type
	Given user is on Updates page
	When user selects CSM Asset type
	Then CSM displays as Asset type
	And Update type drop down contains Upgrade and Configuration entries

@TestCaseID_9084 @UISID_8696 @UISID_8669
Scenario: Select CSM Configuration Update Type
	Given user is on CSM Updates page
	And CSM Asset type is selected
	When user selects Configuration Update type
	Then Configuration displays as Update type
	And CSM configuration list is displayed
	And Name column heading is displayed
	And Date created column heading is displayed
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z label is displayed

@TestCaseID_9085 @UISID_8696
Scenario: CSM Configuration Update Default Sort Order
	Given user is on CSM Updates page
	And CSM Asset type is selected
	And Configuration Update type is selected
	And Configuration list is not empty
	Then configuration files are sorted in ascending alphabetical order

@TestCaseID_9086 @UISID_8696 @UISID_8669
Scenario: CSM Configuration Less Than or Equal to 50
	Given user is on CSM Updates page with "<=50" entries
	Then Previous page icon is disabled
	And Next page icon is disabled

@TestCaseID_9087 @UISID_8696 @UISID_8669
Scenario: CSM Configuration Files Greater Than 50
	Given user is on CSM Updates page with ">50" entries
	And user is on page 1
	Then Previous page icon is disabled
	And Next page icon is enabled

@TestCaseID_9088 @UISID_8696 @UISID_8669
Scenario: CSM Configuration Files Greater Than 50 and Less Than or Equal to 100
	Given user is on CSM Updates page with ">50 and <=100" entries
	And user is on page 1
	When user clicks Next page icon
	Then second page of entries is displayed
	And Next page icon is disabled
	And Previous page icon is enabled

@TestCaseID_9089 @UISID_8696 @UISID_8697
Scenario: CSM Configuration Selected
	Given user is on CSM Updates page
	And CSM Asset type is selected
	And Configuration Update type is selected
	And configuration file is selected
	When user clicks Next button
	Then CSM Select devices page is displayed

@TestCaseID_9090 @UISID_8697 @UISID_8669
Scenario: CSM Select Assets Elements
	Given user is on CSM Configuration Select assets page
	Then Select update indicator is not highlighted
	And Select devices indicator is highlighted
	And Review action indicator is not highlighted
	And "Item to push" label is displayed
	And "Device type" label is displayed
	And "Update type" label is displayed
	And "Config file to push" label is displayed
	And "Destinations" label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Previous button is enabled
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z label is displayed

@TestCaseID_9091 @UISID_8697
Scenario: CSM Select Assets Elements Table
	Given user is on CSM Configuration Select assets page
	Then Select all checkbox is displayed
	And "Firmware" column heading is displayed
	And "Config" column heading is displayed
	And "Asset tag" column heading is displayed
	And "Serial" column heading is displayed
	And "Location" column heading is displayed
	And "Last Files Deployed" column heading is displayed

@TestCaseID_9209 @UISID_8697
Scenario: CSM Select Assets Elements Table Columns
	Given user is on CSM Configuration Select assets page
	Then Select all checkbox is in column 1
	And "Firmware" label is in column 2
	And "Config" label is in column 3
	And "Asset tag" label is in column 4
	And "Serial" label is in column 5
	And "Location" label is in column 6
	And "Last files deployed" label is in column 7


@TestCaseID_9092 @UISID_8697
Scenario: CSM Select Assets
	Given user is on CSM Configuration Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

@TestCaseID_9093 @UISID_8697
Scenario: CSM Select Assets Previous
	Given user is on CSM Configuration Select assets page
	When user clicks Previous button
	Then user is on CSM Updates page

@TestCaseID_9094 @UISID_8698
Scenario: CSM Review Action Page
	Given user is on CSM Configuration Select assets page
	When user selects one device
	And clicks Next button
	Then CSM Review Action page is displayed

@TestCaseID_9095 @UISID_8698
Scenario: CSM Review Action Elements
	Given user is on CSM Review Action page
	Then Item to push label is displayed
	And Item to push value is displayed
	And Destinations label is displayed
	And Destinations value is displayed
	And Select update indicator is not highlighted
	And Select devices indicator is not highlighted
	And Review action indicator is highlighted
	And Previous button is enabled
	And Confirm button is enabled

@TestCaseID_9096 @UISID_8698
Scenario: CSM Review Action Confirm
	Given user is on CSM Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select devices page is displayed

@TestCaseID_9097 @UISID_8698
Scenario: CSM Review Action Previous
	Given user is on CSM Review Action page
	When user clicks Previous button
	Then Select devices page is displayed