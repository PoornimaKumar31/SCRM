@SoftwareRequirementID_5707
Feature: Software Requiremetn 5707
	The Customer Portal shall have a mechanism for canceling scheduled firmware upgrade to one or more CSM devices.

@TestCaseID_9170 @UISID_8700
Scenario: CSM Manage Active Updates
	Given user is on Select Updates page
	And CSM Asset type is selected
	And Upgrade Update type is selected
	When user clicks Manage Active Updates button
	Then Manage Upgrades page is displayed

@TestCaseID_9171 @UISID_8700 @UISID_8669
Scenario: CSM Manage Active Updates Elements
	Given user is on Manage Upgrades page
	Then Destinations label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed
	And Cancel Upgrade button is displayed
	And Cancel Upgrade button is disabled

@TestCaseID_9172 @UISID_8700
Scenario: CSM Manage Active Updates Elements Table
	Given user is on Manage Upgrades page
	Then Select all checkbox in column 1 is unchecked
	And "Firmware" column heading is displayed
	And "Serial number" column heading is displayed
	And "New firmware" column heading is displayed
	And "Location" column heading is displayed
	And "Schedule" column heading is displayed

@TestCaseID_9173 @UISID_8700
Scenario: CSM Schedule Upgrade Cancel
	Given user is on Manage Upgrades page
	When user selects device
	And clicks Cancel upgrade button
	Then Selected Updates have been cancelled message is displayed
	And Upgrade is cancelled
	And Manage Active Updates page is displayed