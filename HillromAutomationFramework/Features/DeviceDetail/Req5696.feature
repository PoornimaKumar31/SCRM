@SoftwareRequirementID_5696
Feature: Software Requirement 5696
	The Customer Portal shall have a feature for editing the following device details for CVSM/CIWS devices

@TestCaseID_9001 @UISID_8673
Scenario: Edit CVSM Asset Details Static Elements
	Given user is on CVSM Asset Details page
	When user clicks Edit button
	Then Edit Asset Details dialog will display
	And user can see Edit Asset Details title
	And user can see Facility label
	And user can see Location label
	And user can see Room entry field
	And user can see Bed entry field
	And user can see Save button
	And user can see Cancel button

@TestCaseID_9002 @UISID_8673
Scenario: Edit CVSM Asset Details Save
	Given user is on CVSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Save button
	Then changed Room and Bed are displayed on the CVSM Asset Details page

@TestCaseID_9003 @UISID_8673
Scenario: Edit CVSM Asset Details Cancel
	Given user is on CVSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Cancel button
	Then original Room and Bed are displayed on the CVSM Asset Details page

@TestCaseID_9004 @UISID_8673 @UISID_8721
Scenario: Edit CVSM Asset Details Bed Field Empty
	Given user is on CVSM Edit Asset Details dialog
	When Bed field is blank
	Then Bed field contains hint text

@TestCaseID_9005 @UISID_8673 @UISID_8721
Scenario: Edit CVSM Asset Details Room Field Empty
	Given user is on CVSM Edit Asset Details dialog
	When Room field is blank
	Then Room field contains hint text

@TestCaseID_9006 @UISID_8673
Scenario: CVSM Asset Details Read Only
	Given user is on CVSM Edit Asset Details dialog
	Then Asset Tag value is displayed
	And Asset Tag value is read only
	And Facility value is displayed
	And Facility value is read only
	And Location ID value is displayed
	And Location ID value is read only
