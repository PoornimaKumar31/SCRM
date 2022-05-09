@SoftwareRequirementID_5907
Feature: Software Requirement 5907
	The customer portal shall provide information display explaining Firmware Status.

@TestCaseID_8997 @UISID_8685
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

@TestCaseID_8998 @UISID_8685
Scenario: CSM Firmware Status Information Close
	Given user is on CSM Firmware Upgrade Status report page
	And CSM Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then CSM Firmware Report Statuses dialog closes
	And CSM Firmware Upgrade Status page is displayed

@TestCaseID_8999 @UISID_8685
Scenario: RV700 Firmware Status information
	Given user is on RV700 Firmware Upgrade Status report page
	When user clicks Information button
	Then RV700 Firmware Report Statuses dialog is displayed
	And RV700 Firmware Report Statuses header is displayed
	And "Started" status and definition of RV700 is displayed
	And "Available" status and definition of RV700 is displayed
	And "Failure" status and definition of RV700 is displayed
	And Close button is displayed

@TestCaseID_9000 @UISID_8685
Scenario: RV700 Firmware Status Information Close
	Given user is on RV700 Firmware Upgrade Status report page
	And RV700 Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then RV700 Firmware Report Statuses dialog closes
	And RV700 Firmware Upgrade Status page is displayed

@TestCaseID_9905 @UISID_8685
Scenario: Centrella Firmware Status Information
	Given user is on Centrella Firmware Upgrade Status report page
	When user clicks Information button
	Then Centrella Firmware Report Statuses dialog is displayed
	And Centrella Firmware Report Statuses header is displayed
	And "Started" status and definition of Centrella is displayed
	And "Downloading" status and definition of Centrella is displayed
	And "Staging" status and definition of Centrella is displayed
	And "Staging complete" status and definition of Centrella is displayed
	And "Toggling" status and definition of Centrella is displayed
	And "Toggle complete" status and definition of Centrella is displayed
	And "Upgrade Success" status and definition of Centrella is displayed
	And "Download Failure" status and definition of Centrella is displayed
	And "Staging Failure" status and definition of Centrella is displayed
	And "Staging Inconsistent" status and definition of Centrella is displayed
	And "Toggle Failure" status and definition of Centrella is displayed
	And Close button is displayed

@TestCaseID_9906 @UISID_8685
Scenario: Centrella Firmware Status Information Close
	Given user is on Centrella Firmware Upgrade Status report page
	And Centrella Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then Centrella Firmware Report Statuses dialog closes
	And Centrella Firmware Upgrade Status page is displayed

@TestCaseID_10877 @UISID_8685
Scenario: Progressa Firmware Status Information
	Given user is on Progressa Firmware Upgrade Status report page
	When user clicks Information button
	Then Progressa Firmware Report Statuses dialog is displayed
	And Progressa Firmware Report Statuses header is displayed
	And "Downloading" status and definition of Progressa is displayed
	And "Mounting" status and definition of Progressa is displayed
	And "Mounting complete" status and definition of Progressa is displayed
	And "Initializing" status and definition of Progressa is displayed
	And "Staging" status and definition of Progressa is displayed
	And "Updating WAM" status and definition of Progressa is displayed
	And "Upgrade Success" status and definition of Progressa is displayed
	And "Local Upgrade Performed" status and definition of Progressa is displayed
	And "Download Failure" status and definition of Progressa is displayed
	And "Inconsistent Software Error" status and definition of Progressa is displayed
	And "Initializing Failure" status and definition of Progressa is displayed
	And "Mounting Failure" status and definition of Progressa is displayed
	And "Staging Failure" status and definition of Progressa is displayed
	And "WAM Update Failure" status and definition of Progressa is displayed
	And Close button is displayed
	
@TestCaseID_10878 @UISID_8685
Scenario: Progressa Firmware Status Information Close
	Given user is on Progressa Firmware Upgrade Status report page
	And Progressa Firmware Report Statuses dialog is displayed
	When user clicks Close button
	Then Progressa Firmware Report Statuses dialog closes
	And Progressa Firmware Upgrade Status page is displayed	