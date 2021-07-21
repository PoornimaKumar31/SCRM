@SoftwareRequirementID_5904
Feature: Software Requirement 5904
	The customer portal shall provide information display explaining each CSM CFG status.

@TestCaseID_8995 @UISID_8688
Scenario: CSM Config Status Information
	Given user is on CSM Configuration Update Status page 
	When user clicks Information button
	Then CSM Configuration report Statuses dialog is displayed
	And CSM Configuration Report Statuses header is displayed
	And "Started" status and definition is displayed
	And "Transferred" status and definition is displayed
	And "Available" status and definition is displayed
	And "Applied" status and definition is displayed
	And "Failed" status and definition is displayed
	And Close button is displayed

@TestCaseID_8996 @UISID_8688
Scenario: CSM Config Status Information Close
	Given user is on CSM Configuration Update Status page 
	And CSM Configuration Report Statuses dialog is displayed
	When user clicks Close button
	Then CSM Configuration Report Statuses dialog closes
	And CSM Configuration Update Status page is displayed