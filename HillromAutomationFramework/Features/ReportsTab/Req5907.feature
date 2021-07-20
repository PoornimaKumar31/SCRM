@SoftwareRequirementID_5907
Feature: Software Requirement 5907
	The customer portal shall provide information display explaining Firmware Status.

@TestCaseID_8997 @UISID_8692
Scenario: CSM Firmware Status Information
	Given user is on CSM Firmware Upgrade Status report page
	When user clicks Information button
	Then CSM Firmware Report Statuses dialog is displayed
	And user can see CSM Firmware Report Statuses header
	And user can see "Started" status and definition
	And user can see "Available" status and definition
	And user can see "Downloading" status and definition
	And user can see "Scheduled" status and definition
	And user can see "Updating" status and definition
	And user can see "Applied" status and definition
	And user can see "Cancel Requested" status and definition
	And user can see "Canceling" status and definition
	And user can see "Download Failed" status and definition
	And user can see "Failed" status and definition
	And user can see Close button

@TestCaseID_8998 @UISID_8692
Scenario: CSM Firmware Status Information Close
	Given user is on CSM Firmware Upgrade Status page
	And CSM Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then CSM Firmware Report Statuses dialog closes
	And user is on CSM Firmware Upgrade Status page

@TestCaseID_8999 @UISID_8692
Scenario: RV700 Firmware Status information
	Given user is on RV700 Firmware Upgrade Status report page
	When user clicks Information button
	Then RV700 Firmware Report Statuses dialog is displayed
	And user can see RV700 Firmware Report Statuses header
	And user can see "Started" status and definition of RV700
	And user can see "Available" status and definition of RV700
	And user can see "Failure" status and definition of RV700
	And user can see Close button

@TestCaseID_9000 @UISID_8692
Scenario: RV700 Firmware Status Information Close
	Given user is on RV700 Firmware Upgrade Status report page
	And RV700 Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then RV700 Firmware Report Statuses dialog closes
	And user is on RV700 Firmware Upgrade Status page