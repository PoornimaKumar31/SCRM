@SoftwareRequirementID_5703
Feature: Software Requirement 5703
	The Customer Portal shall have a mechanism for editing the following device details for CSM devices: Room, Bed.

@TestCaseID_9322 @UISID_8673
Scenario: Edit CSM Asset Details Save
	Given user is on CSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Save button
	Then changed Room and Bed are displayed on the CSM Asset Details page

@TestCaseID_9325 @UISID_8673
Scenario: Edit CSM Asset Details Cancel
	Given user is on CSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Cancel button
	Then original Room and Bed are displayed on the CSM Asset Details page

@TestCaseID_9326 @UISID_8673 @UISID_8721
Scenario: Edit CSM Asset Details Bed Field Empty
	Given user is on CSM Edit Asset Details dialog
	When user clears Bed field
	Then Bed field contains hint text

@TestCaseID_9327 @UISID_8673 @UISID_8721
Scenario: Edit CSM Asset Details Room Field Empty
	Given user is on CSM Edit Asset Details dialog
	When user clears Room field
	Then Room field contains hint text

@TestCaseID_9329 @UISID_8673
Scenario: CSM Asset Details Read Only
	Given user is on CSM Edit Asset Details dialog
	Then Asset Tag value is displayed
	And Asset Tag value is read only
	And Facility value is displayed
	And Facility value is read only
	And Location ID value is displayed
	And Location ID value is read only