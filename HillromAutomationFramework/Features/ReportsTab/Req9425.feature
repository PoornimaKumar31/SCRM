@SoftwareRequirementID_9425
Feature: Software Requirement 9425
	 The customer portal shall download Centrella Activity report in csv format.

@TestCaseID_ @UISID_8685
Scenario: Centrella Activity Report Download
	Given user is on "Centrella Activity Report" page
	When user clicks Download button
	Then "Activity" Report is downloaded as csv file