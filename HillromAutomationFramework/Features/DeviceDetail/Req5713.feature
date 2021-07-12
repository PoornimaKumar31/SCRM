@SoftwareRequirementID_5713
Feature: Software Requirement 5713
The customer portal shall have a mechanism for requesting log files from a RV700 device.

@TestCaseID_8989
Scenario: RV700 Log Files Request
	Given user is on RV700 Log Files page
	And Pending or Executing message is not displayed
	When user clicks Request Logs button
	Then Pending or Executing message is displayed

@TestCaseID_8990
Scenario: RV700 Log Files Request Disabled
	Given user is on RV700 Log Files page
	And Pending or Executing message is displayed
	Then Request Logs button is disabled