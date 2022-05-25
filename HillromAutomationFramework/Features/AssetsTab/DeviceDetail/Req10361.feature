@SoftwareRequirementID_10361
Feature: Software Requirement 10361
	The Customer Portal shall display errors reported from Progressa bed.

@TestCaseID_10888 @UISID_9817
Scenario: Progressa Error Pop-up Dialog
	Given user is on device details page for Progressa Serial number "PY685008"
	When user clicks Error codes tab
	And clicks expansion arrow on a row in Error codes table
	Then Progressa error code pop-up dialog is displayed
	And "Error code title" label and value is displayed
	And "Error code" label is displayed
	And "Error code" value is displayed
	And "Description" label is displayed
	And "Description" value is displayed
	And "Solution" label is displayed
	And "Solution" value is displayed
	And Reference link is displayed
	And Close button is displayed

@TestCaseID_10889 @UISID_9817
Scenario: Progressa Error Pop-up Dialog Reference Close
	Given user is on device details page for Progressa Serial number "PY685008"
	When user clicks Error codes tab
	And clicks expansion arrow on a row in Error codes table
	Then Progressa error code pop-up dialog is displayed
	When user clicks Reference link
	Then Service manual opens in a new tab
	When user clicks Close button
	Then device details page for Progressa Serial number "PY685008" is displayed

@TestCaseID_10890 @UISID_9817
Scenario: Progressa Asset Details Error Tab Reference
	Given user is on device details page for Progressa Serial number "PY685008"
	When user clicks Error codes tab
	And clicks Reference button
	Then Service manual opens in a new tab