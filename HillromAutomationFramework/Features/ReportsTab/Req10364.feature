@SoftwareRequirementID_10364
Feature: Software Requirement 10364
	 The customer portal shall download Progressa Activity report in csv format.

@TestCaseID_10865 @UISID_8685
Scenario: Progressa Activity Report Download
	Given user is on "Progressa Activity Report" page
	When user clicks Download button
	Then "Activity" Report is downloaded as csv file