@SoftwareRequirementID_5904
Feature: Software Requirement 5904
	The customer portal shall provide information display explaining each CSM CFG status.

@TestCaseID_8995 @UISID_8688
Scenario: CSM Config Status Information
	Given user is on CSM Configuration Update Status page 
	When user clicks Information button
	Then CSM Configuration report Statuses dialog is displayed
	And user can see CSM Configuration Report Statuses header
	And user can see "Started" status and definition
	And user can see "Transferred" status and definition
	And user can see "Available" status and definition
	And user can see "Applied" status and definition
	And user can see "Failed" status and definition
	And user can see Close button

@TestCaseID_8996 @UISID_8688
Scenario: CSM Config Status Information Close
	Given user is on CSM Configuration Update Status page 
	And CSM Configuration Report Statuses dialog is displayed
	When user clicks Close button
	Then CSM Configuration Report Statuses dialog closes
	And user is on CSM Configuration Update Status page