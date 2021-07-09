@SoftwareRequirementID_5712
Feature: The Customer Portal shall have a mechanism for downloading the RV700 log files

@TestCaseID_8988
Scenario: RV700 Log Files Download
	Given user is on RV700 Log Files page
	And at least one log is present
	When user clicks log
	Then log is downloaded to computer
	And downloaded filename matches 