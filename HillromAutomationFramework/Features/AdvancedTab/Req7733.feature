@SoftwareRequirementID_7733
Feature: Software Requirement 7733
	The Customer Portal shall display errors reported from Centrella bed.

@TestCaseID_9921 @UISID_8666
Scenario: Centrella Asset List Status Column
	Given user is on Asset List for an organization with Centrella devices
	Then an error icon is displayed in the Status column for bed with serial number "PY673002"
	And an error icon is not displayed in the Status column for bed with serial number "PY673001"