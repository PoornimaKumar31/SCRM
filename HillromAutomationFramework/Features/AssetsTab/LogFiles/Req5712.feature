@SoftwareRequirementID_5712
Feature: Software Requirement 5712
The Customer Portal shall have a mechanism for downloading the RV700 log files

@TestCaseID_8988 @UISID_8678
Scenario: RV700 Log Files Download
	Given user is on RV700 Log Files page
	And at least one log is present
	When user clicks log
	Then log is downloaded to computer
	And downloaded filename matches 