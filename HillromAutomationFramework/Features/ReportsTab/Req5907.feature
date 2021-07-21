@SoftwareRequirementID_5907
Feature: Software Requirement 5907
	The customer portal shall provide information display explaining Firmware Status.

@TestCaseID_8997 @UISID_8692
Scenario: CSM Firmware Status Information
	Given user is on CSM Firmware Upgrade Status report page
	When user clicks Information button
	Then CSM Firmware Report Statuses dialog is displayed
	And CSM Firmware Report Statuses header is displayed
	And "Started" status and definition is displayed
	And "Available" status and definition is displayed
	And "Downloading" status and definition is displayed
	And "Scheduled" status and definition is displayed
	And "Updating" status and definition is displayed
	And "Applied" status and definition is displayed
	And "Cancel Requested" status and definition is displayed
	And "Canceling" status and definition is displayed
	And "Download Failed" status and definition is displayed
	And "Failed" status and definition is displayed
	And Close button is displayed

@TestCaseID_8998 @UISID_8692
Scenario: CSM Firmware Status Information Close
	Given user is on CSM Firmware Upgrade Status report page
	And CSM Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then CSM Firmware Report Statuses dialog closes
	And CSM Firmware Upgrade Status page is displayed

@TestCaseID_8999 @UISID_8692
Scenario: RV700 Firmware Status information
	Given user is on RV700 Firmware Upgrade Status report page
	When user clicks Information button
	Then RV700 Firmware Report Statuses dialog is displayed
	And RV700 Firmware Report Statuses header is displayed
	And "Started" status and definition of RV700 is displayed
	And "Available" status and definition of RV700 is displayed
	And "Failure" status and definition of RV700 is displayed
	And Close button is displayed

@TestCaseID_9000 @UISID_8692
Scenario: RV700 Firmware Status Information Close
	Given user is on RV700 Firmware Upgrade Status report page
	And RV700 Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then RV700 Firmware Report Statuses dialog closes
	And RV700 Firmware Upgrade Status page is displayed