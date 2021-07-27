@SoftwareRequirementID_5697
Feature: Software Requirement 5697 
	 The Customer Portal shall have a mechanism for distributing a selected configuration to CVSM/CIWS devices.

@TestCaseID_9031 @UISID_8696
Scenario: Select Updates Elements
	Given user is on Main page
	When user clicks Updates
	Then Select update indicator is highlighted
	And Select assets indicator is not highlighted
	And Review action indicator is not highlighted
	And Asset type label is displayed
	And Update type label is displayed
	And Asset type drop down is displayed
	And Update type drop down is displayed
	And Next button is disabled

@TestCaseID_9032 @UISID_8696
Scenario: Select CVSM Asset Type
	Given user is on Updates page
	When user selects CVSM Asset type
	Then CVSM displays as Asset type
	And Update type drop down contains Configuration entry only

@TestCaseID_9033 @UISID_8696
Scenario: Select CVSM Configuration Update Type
	Given user is on CVSM Updates page
	And CVSM Asset type is selected
	When user selects Configuration Update type
	Then Configuration displays as Update type
	And CVSM configuration list is displayed
	And "Name" column heading is displayed
	And "Date created" column heading is displayed
	And Delete button is displayed
	And Next button is disabled

@TestCaseID_9034 @UISID_8696
Scenario: CVSM Configuration Update Default Sort Order
	Given user is on CVSM Updates page
	And CVSM Asset type is selected
	And Configuration Update type is selected
	And Configuration list is not empty
	Then configuration files are sorted in ascending alphabetical order


@TestCaseID_9078 @UISID_8696 @UISID_8669
Scenario: CVSM Configuration Less Than or Equal to 50
	Given user is on CVSM Updates page with "<=50" entries
	Then Previous page icon is disabled
	And Next page icon is disabled

@TestCaseID_9079 @UISID_8696 @UISID_8669
Scenario: CVSM Configuration Greater Than 50
	Given user is on CVSM Updates page with ">50" entries
	Then Previous page icon is disabled
	And Next page icon is enabled

@TestCaseID_9080 @UISID_8696 @UISID_8669
Scenario: CVSM Configuration Greater Than 50 and Less Than or Equal to 100
	Given user is on CVSM Updates page with ">50 and <=100" entries
	And first 50 entries are displayed
	When user clicks Next page button
	Then second page of entries is displayed
	And Next page icon is disabled
	And Previous page icon is disabled

@TestCaseID_9035 @UISID_8696 @UISID_8697
Scenario: CVSM Configuration Selected
	Given user is on CVSM Updates page
	And CVSM Asset type is selected
	And Configuration Update type is selected
	When user selects CVSM configuration from the list
	Then Next button is enabled
	And user clicks Next button
	Then Select Assets page is displayed

@TestCaseID_9036 @UISID_8697 @UISID_8669
Scenario: CVSM Select Assets Elements
	Given user is on CVSM Configuration Select assets page
	Then Select update indicator is not highlighted
	And Select assets indicator is highlighted
	And Review action indicator is not highlighted
	And Item to push label is displayed
	And device type label is displayed
	And update type label is displayed
	And config file to push label is displayed
	And Destinations label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Previous button is displayed
	And Next button is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9038 @UISID_8697
Scenario: CVSM Select Assets Elements Table
	Given user is on CVSM Configuration Select assets page
	Then Select all checkbox in column is unchecked
	And "Firmware" column heading is displayed
	And "Config" column heading is displayed
	And "Asset Tag" column heading is displayed
	And "Serial" column heading is displayed
	And "Location" column heading is displayed
	And "Last Files Deployed" column heading is displayed

@TestCaseID_9207 @UISID_8697
Scenario: CVSM Select Assets Elements Table Columns
	Given user is on CVSM Configuration Select assets page
	Then Select all checkbox is in column 1
	And "Firmware" label is in column 2
	And "Config" label is in column 3
	And "Asset Tag" label is in column 4
	And "Serial" label is in column 5
	And "Location" label is in column 6
	And "Last Files Deployed" label is in column 7

@TestCaseID_9039 @UISID_8697
Scenario: CVSM Select Assets
	Given user is on CVSM Configuration Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

@TestCaseID_9040 @UISID_8697
Scenario: CVSM Select Assets Previous
	Given user is on CVSM Configuration Select assets page
	When user clicks Previous button
	Then user is on CVSM Updates page
	
@TestCaseID_9041 @UISID_8698
Scenario: CVSM Review Action page
	Given user is on CVSM Configuration Select assets page
	When user selects one device 
	And Clicks Next button
	Then CVSM Review Action page is displayed

@TestCaseID_9042 @UISID_8698
Scenario: CVSM Review Action Elements
	Given user is on CVSM Review Action page
	Then item to push label is displayed
	And Item to push value is displayed
	And Destinations label is displayed
	And Destinations value is displayed
	And Select update indicator is not highlighted
	And Select assets indicator is not highlighted
	And Review action indicator is highlighted
	And Previous button is enabled
	And Confirm button is enabled

@TestCaseID_9043 @UISID_8698
Scenario: CVSM Review Action Confirm
	Given user is on CVSM Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select devices page is displayed

@TestCaseID_9044 @UISID_8698
Scenario: CVSM Review Action Previous
	Given user is on CVSM Review Action page
	When user clicks Previous button
	Then Select devices page is displayed
