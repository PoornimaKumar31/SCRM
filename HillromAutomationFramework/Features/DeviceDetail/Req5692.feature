@SoftwareRequirementID_5692
Feature: Software Requirement 5692
The Customer Portal shall have a feature for downloading CVSM/CIWS log files.

@TestCaseID_8963
Scenario: CVSM Log Files Download
	Given user is on CVSM Log Files page
	And at least one log is present
	When user clicks log
	Then log is downloaded to computer
	And downloaded filename matches 