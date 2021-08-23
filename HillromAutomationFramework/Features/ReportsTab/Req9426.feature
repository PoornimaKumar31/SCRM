@SoftwareRequirementID_9426
Feature: Software Requirement 9426
   The Customer Portal shall download Centrella bed firmware upgrade status report in csv format.

@TestCaseID_ @UISID_8685
Scenario: Centrella Firmware Status Report Download
	Given user is on "Centrella Firmware Upgrade Status" page
	When user clicks Download button
	Then "Firmware Status" Report is downloaded as csv file