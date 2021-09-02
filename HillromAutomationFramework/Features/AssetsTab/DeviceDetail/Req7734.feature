@SoftwareRequirementID_7734
Feature: Software Requirement 7734
	The Customer Portal shall display errors reported from Centrella bed.

@TestCaseID_9925 @UISID_9817
Scenario: Centrella Error Pop-up Dialog
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	And clicks expansion arrow on a row in Error codes table
	Then Centrella error code pop-up dialog is displayed
	And "Error code title" label and value is displayed
	And "Error code" label is displayed
	And "Error code" value is displayed
	And "Description" label is displayed
	And "Description" value is displayed
	And "Solution" label is displayed
	And "Solution" value is displayed
	And Reference link is displayed
	And Close button is displayed

@TestCaseID_9926 @UISID_9817
Scenario: Centrella Error Pop-up Dialog Reference Close
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	And clicks expansion arrow on a row in Error codes table
	Then Centrella error code pop-up dialog is displayed
	When user clicks Reference link
	Then Service manual opens in a new tab
	When user clicks Close button
	Then device details page for Centrella Serial number "PY673002" is displayed

@TestCaseID_9927 @UISID_9817
Scenario: Centrella Asset Details Error Tab Reference
	Given user is on device details page for Centrella Serial number "PY673002"
	When user clicks Error codes tab
	And clicks Reference button
	Then Service manual opens in a new tab