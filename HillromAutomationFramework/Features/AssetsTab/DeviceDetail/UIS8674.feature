@SoftwareRequirementID_
Feature: Software Requirement
	The customer portal shall display Centrella general service data.

#Need to update the gherkin because label and values are not separate elements
@TestCaseID_9936 @UISID_8674
Scenario: AP Mapping List Elements Manager User No AP
	Given manager user is on device details page for Centrella Serial number "PY673001"
	When user clicks Locate Asset button
	Then Locate Asset pop-up dialog is displayed
	And "Source" label and value is "Source : Access Point"
	And "MAC address" label and value is "MAC address : 28:c6:8e:78:18:2d"
	And "RSSI" label and value is "RSSI : -61 "
	And Add AP Mapping button is displayed
	And Close button is displayed

@TestCaseID_9937 @UISID_8674
Scenario: AP Mapping List Elements Manager User
	Given manager user is on device details page for Centrella Serial number "PY673002"
	When user clicks Locate Asset button
	Then Locate Asset pop-up dialog is displayed
	And "Source" label and value is "Source : Access Point"
	And "MAC address" label and value is "MAC address : 28:c6:8e:78:18:2c"
	And "RSSI" label and value is "RSSI : -66 "
	And Edit AP Mapping button is displayed
	And Close button is displayed

@TestCaseID_9938 @UISID_8674
Scenario: AP Mapping List Elements Regular User
	Given regular user is on device details page for Centrella Serial number "PY673002"
	When user clicks Locate Asset button
	Then Edit AP Mapping button is not displayed
	And Add AP Mapping button is not displayed

@TestCaseID_9939 @UISID_8674
Scenario: AP Mapping List Table
	Given manager user is on Locate Asset pop-up dialog for Centrella Serial number "PY673002"
	Then "Campus" column heading is displayed
	And "Building" column heading is displayed
	And "Floor" column heading is displayed
	And "AP Location" column heading is displayed

@TestCaseID_9940 @UISID_8674
Scenario: AP Mapping List Table No Match
	Given manager user is on Locate Asset pop-up dialog for Centrella Serial number "PY673001"
	Then  value in "Campus" column is "N/A"
	And value in "Building" column is "N/A"
	And value in "Floor" column is "N/A"
	And value in "AP Location" column is "N/A"

@TestCaseID_9941 @UISID_8674
Scenario: AP Mapping List Table Add
	Given manager user is on Locate Asset pop-up dialog for Centrella Serial number "PY673001"
	When user clicks Add AP mapping button	
	Then "Campus" entry field with "Campus" hint text is displayed
	And "Building" entry field with "Building" hint text is displayed
	And "Floor" entry field with "Floor" hint text is displayed
	And "AP Location" entry field with "AP Location" hint text is displayed
	And Save button is displayed
	And Close button is displayed

@TestCaseID_9942 @UISID_8674
Scenario: AP Mapping List Table Edit
	Given manager user is on Locate Asset pop-up dialog for Centrella Serial number "PY673002"
	When user clicks Edit AP mapping button
	Then "Campus" entry field with "Cleveland" value is displayed
	And "Building" entry field with "North" value is displayed
	And "Floor" entry field with "1st" value is displayed
	And "AP Location" entry field with "Near nurse station" value is displayed
	And Save button is displayed
	And Close button is displayed