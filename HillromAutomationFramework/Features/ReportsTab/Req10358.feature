@SoftwareRequirementID_10358
Feature: Software Requirement 10358
   The Customer Portal shall download Progressa bed firmware upgrade status report in csv format.

@TestCaseID_10864 @UISID_8685
Scenario: Progressa Firmware Status Report Download
	Given user is on "Progressa Firmware Upgrade Status" page
	When user clicks Download button
	Then "Firmware Status" Report is downloaded as csv file