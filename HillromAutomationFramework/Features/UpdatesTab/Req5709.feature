@SoftwareRequirementID_5709
Feature: Software Requirement 5709 
	The Customer Portal shall have a feature for displaying the following Service Monitor configurable settings:
Call home interval
Deployment mode

@TestCaseID_9068 @UISID_8699
Scenario: Select Service Monitor Asset Type
	Given user is on Main page
	When user clicks Updates
	And user selects Service Monitor
	Then Service Monitor Settings page displays

@TestCaseID_9069 @UISID_8699
Scenario: Service Monitor Call Home Period Elements
	Given user is on Service Monitor Settings page
	When user clicks Call home period drop-down
	Then drop down displays P1D (24 HOURS), PT8H (8 HOURS), PT4H (4 HOURS), PT15M (15 MINUTES)

@TestCaseID_9070 @UISID_8699
Scenario: Service Monitor Deployment Mode Elements
	Given user is on Service Monitor Settings page
	When user clicks Deployment mode drop-down
	Then drop down displays FALSE, TRUE

@TestCaseID_9071 @UISID_8699
Scenario: Service Monitor Settings Previous
	Given user is on Service Monitor Settings page
	When user clicks Previous button
	Then Updates page is displayed

@TestCaseID_9072 @UISID_8699
Scenario: Service Monitor Settings Elements
	Given user is on Service Monitor Settings page
	And no devices are selected
	Then Service Monitor Settings label is displayed
	And Call home period label is displayed
	And Call home period dropdown is displayed
	And Deployment mode label is displayed
	And Deployment mode drop down is displayed
	And Destinations label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And count of selected locations is displayed
	And Previous button is enabled
	And Deploy button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9073 @UISID_8699
Scenario: Service Monitor Settings Elements Table
	Given user is on Service Monitor Settings page
	Then Select all checkbox in column 1 is unchecked
	And "Serial Number" in column 2 heading is displayed
	And "Call home period" in column 3 heading is displayed
	And "Deployment mode" in column 4 heading is displayed
	And "Location" in column 5 heading is displayed
	And "Last files deployed" in column 6 heading is displayed

@TestCaseID_9074 @UISID_8699 @UISID_8669
Scenario: Service Monitor Settings <= 50
	Given user is on Service Monitor Settings page with "<=50" entries
	Then Previous page button is disabled
	And Next page button is disabled

@TestCaseID_9075 @UISID_8699 @UISID_8669
Scenario: Service Monitor Settings > 50 entries
	Given user is on Service Monitor Settings page with ">50" entries
	Then Previous page button is disabled
	And Next page button is enabled

@TestCaseID_9076 @UISID_8699 @UISID_8669
Scenario: Service Monitor Settings > 50 and <= 100 Next
	Given user is on Service Monitor Settings page with ">50 and <=100" entries
	And first 50 entries are displayed
	When user clicks Next page button
	Then second page of entries is displayed
	And Next page button is disabled
	And Previous page button is disabled

@TestCaseID_9077 @UISID_8699
Scenario: Service Monitor Settings Select Device
	Given user is on Service Monitor Settings page with "<=50" entries
	And user selects Call home period as P1D (24 HOURS) and Deployment mode as FALSE
	When user selects checkbox for first data row in table
	Then Upgrade count label updated with selection of row
	And Deploy button is enabled
	When user clicks Deploy button
	Then Update process has been established message will display
	And software navigates to Select Update page