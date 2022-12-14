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
	Then Select all checkbox is unchecked
	And "Serial Number" column heading is displayed
	And "Call home period" column heading is displayed
	And "Deployment mode" column heading is displayed
	And "Ownership" column heading is displayed
	And "Last files deployed" column heading is displayed

@TestCaseID_9208 @UISID_8699
Scenario: Service Monitor Settings Elements Table Columns
	Given user is on Service Monitor Settings page
	Then Select all checkbox is in column 1
	And "Serial Number" label is in column 2
	And "Call home period" label is in column 3
	And "Deployment mode" label is in column 4
	And "Ownership" label is in column 5
	And "Last files deployed" label is in column 6

@TestCaseID_9074 @UISID_8699 @UISID_8669
Scenario: Service Monitor Settings Less Than or Equal to 50
	Given user is on Service Monitor Settings page with "<=50" entries
	Then Previous page icon is disabled
	And Next page icon is disabled

@TestCaseID_9077 @UISID_8699
Scenario: Service Monitor Settings Select Device
	Given user is on Service Monitor Settings page with "<=50" entries
	And user selects Call home period as P1D (24 HOURS)
	And Deployment mode as FALSE
	When user selects checkbox for first data row in table
	Then Upgrade count label updates with selection of row
	And Deploy button is enabled