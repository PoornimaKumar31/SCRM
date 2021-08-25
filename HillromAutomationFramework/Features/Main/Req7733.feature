@SoftwareRequirementID_7733
Feature: Software Requirement 7733
	The Customer Portal shall display errors reported from Centrella bed.

@TestCaseID_9921 @UISID_8666
Scenario: Centrella Asset List Status Column
	Given user is on Asset List for an organization with Centrella devices
	Then an error icon is displayed in the "Status" column for bed with serial number "PY673002"
	And an error icon is not displayed in the "Status" column for bed with serial number "PY673001"

@TestCaseID_9922 @UISID_9816
Scenario: Centrella Asset Details Error Tab No Errors
	Given user is on device details page for Centrella Serial number "PY673001"
	Then "No errors reported." is displayed in Error codes tab

@TestCaseID_9923 @UISID_9816
Scenario: Centrella Asset Details Error Tab Table
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	Then Reference button is displayed
	And "Severity" column heading is displayed
	And "Timestamp" column heading is displayed
	And "Code" column heading is displayed
	And "Description" column heading is displayed

@TestCaseID_9924 @UISID_9816
Scenario: Centrella Asset Details Error Tab Table Columns
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	Then "Severity" label is in column 1
	And "Timestamp" label is in column 2
	And "Code" label is in column 3
	And "Description" label is in column 4