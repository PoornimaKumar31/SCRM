@SoftwareRequirementID_10360
Feature: Software Requirement 10360
	The Customer Portal shall display errors reported from Progressa bed.

@TestCaseID_10884 @UISID_8666
Scenario: Progressa Asset List Status Column
	Given user is on Asset List for an organization with Progressa devices
	Then an error icon is displayed in the "Status" column for bed with serial number "PY685008"
	And an error icon is not displayed in the "Status" column for bed with serial number "PY685010"

@TestCaseID_10885 @UISID_9816
Scenario: Progressa Asset Details Error Tab No Errors
	Given user is on device details page for Progressa Serial number "PY685010"
	Then "No errors reported." is displayed in Error codes tab

@TestCaseID_10886 @UISID_9816
Scenario: Progressa Asset Details Error Tab Table
	Given user is on device details page for Progressa Serial number "PY685008"
	When user clicks Error codes tab
	Then Reference button is displayed
	And "Severity" column heading is displayed
	And "Timestamp" column heading is displayed
	And "Code" column heading is displayed
	And "Description" column heading is displayed

@TestCaseID_10887 @UISID_9816
Scenario: Progressa Asset Details Error Tab Table Columns
	Given user is on device details page for Progressa Serial number "PY685008"
	When user clicks Error codes tab
	Then "Severity" label is in column 1
	And "Timestamp" label is in column 2
	And "Code" label is in column 3
	And "Description" label is in column 4