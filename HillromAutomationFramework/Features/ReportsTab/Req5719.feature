@SoftwareRequirementID_5719
Feature: Software Requirement 5719
	The Customer Portal shall have a feature for downloading the following report as a csv formatted file:	
	CSM Configuration Status report
	CSM Firmware Status report
	CSM Activity report
	RV700 Firmware Status report

@TestCaseID_9401 @UISID_8685
Scenario: CSM Configuration Status Report Download
	Given user is on "CSM CONFIGURATION UPDATE STATUS" page
	When user clicks on Download button
	Then "Configuration Update Status" Report is downloaded as csv file

@TestCaseID_9402 @UISID_8685
Scenario: CSM Firmware Status Report Download
	Given user is on "CSM FIRMWARE UPGRADE STATUS" page
	When user clicks on Download button
	Then "Firmware Status" Report is downloaded as csv file

@TestCaseID_9403 @UISID_8685
Scenario: CSM Activity Report Download
	Given user is on "CSM ACTIVITY REPORT" page
	When user clicks on Download button
	Then "Activity" Report is downloaded as csv file

@TestCaseID_9404 @UISID_8685
Scenario: RV700 Firmware Status Report Download
	Given user is on "RV700 FIRMWARE UPGRADE STATUS" page
	When user clicks on Download button
	Then "Firmware Status" Report is downloaded as csv file