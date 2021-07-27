@SoftwareRequirementID_5693
Feature: Software Requirement 5693
The Customer Portal shall have a mechanism for requesting log files from registered CVSM/CIWS devices.

@TestCaseID_8964 @UISID_8678
Scenario: CVSM Log Files Request
	Given user is on CVSM Log Files page
	And Received, Pending or Executing message is not displayed
	When user clicks Request Logs button
	Then Received, Pending or Executing message is displayed

@TestCaseID_8965 @UISID_8678
Scenario: CVSM Log Files Request Disabled
	Given user is on CVSM Log Files page
	And Received, Pending or Executing message is displayed
	Then Request Logs button is disabled
