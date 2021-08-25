@SoftwareRequirementID_7734
Feature: Software Requirement 7734
	The Customer Portal shall display errors reported from Centrella bed.

@TestCaseID_9925 @UISID_9817
Scenario: Centrella Error Pop-up Dialog
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	And clicks expension arrow on a row in Error codes table
	Then Centrella error code pop-up dialog is displayed
	And "Error code:" title label is displayed
	And error code title value is displayed
	And "Error code:" label is displayed
	And error code value is displayed
	And "Description:" label is displayed
	And description is displayed
	And "Solution:" label is displayed
	And solution is displayed
	And Reference link is displayed
	And Close button is displayed