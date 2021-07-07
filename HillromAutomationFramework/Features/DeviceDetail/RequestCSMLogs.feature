@SoftwareRequirementID_5700
Feature: RequestCSMLogs
	The Customer Portal shall have a mechanism for requesting log files from registered CSM devices.

@TestCaseID_8976 @UISID_8678
Scenario: CSM Log Files Request
	Given user is on CSM Log Files page
	And Pending or Executing message is not displayed
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And Request Logs button is disabled

@TestCaseID_8977 @UISID_8678
Scenario: CSM Log Files Request Disabled
	Given user is on CSM Log Files page
	And Pending or Executing message is displayed
	Then Request Logs button is disabled
