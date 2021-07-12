@SoftwareRequirementID_5703
Feature: Software Requirement 5703
	The Customer Portal shall have a mechanism for editing the following device details for CSM devices: Room, Bed

@TestCaseID_ @UISID_8673
Scenario: Add CSM Device Details
	Given user has selected CSM device with details not set
	And user is on Device Details page
	When user clicks Edit button
	Then Room and Bed can be entered 
	And Saved 
	And Entered Room, Bed is displayed on Device page

@TestCaseID_ @UISID_8673
Scenario: Edit CSM Device Details
	Given user has selected CSM device with Room, Bed
	And user is on Device Details page
	When user clicks Edit button
	Then the existing Room , Bed is editable
	And Saved 
	And Updated Room, Bed is displayed on Device page

@TestCaseID_ @UISID_8673
Scenario: Remove CSM Device Details
	Given user has selected CSM device with Room, Bed details
	And user is on Device Details page
	When user clicks Edit button
	Then the existing Room , Bed can be removed
	And Saved 
	And Blank Room, Bed is displayed on Device page

@TestCaseID_ @UISID_8673
Scenario: Cancel on Add CSM Device Details
	Given user has selected CSM device with details not set
	And user is on Device Details page
	When user clicks Edit button
	And Room, Bed is entered and cancelled
	Then Entered Room, Bed is not displayed on Device page

@TestCaseID_ @UISID_8673
Scenario: Cancel on Edit CSM Device Details
	Given user has selected CSM device with Room, Bed
	And user is on Device Details page
	When user clicks Edit button
	And Room, Bed is updated and cancelled
	Then Updated Room, Bed is not displayed on Device page

@TestCaseID_ @UISID_8673
Scenario: Cancel on Removal of CSM Device Details
	Given user has selected CSM device with Room, Bed details
	And user is on Device Details page
	When user clicks Edit button
	And Room, Bed is removed and cancelled
	Then Room, Bed is not removed on Device page
