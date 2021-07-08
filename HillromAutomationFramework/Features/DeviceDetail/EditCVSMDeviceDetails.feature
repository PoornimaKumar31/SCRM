@SoftwareRequirementID_5696
Feature: EditCVSMDeviceDetails
	The Customer Portal shall have a feature for editing the following device details for CVSM/CIWS devices

@TestCaseID_ @UISID_8673
Scenario: Edit CVSM Asset Details Static Elements
	Given user is on CVSM Asset Details page
	When user clicks Edit button
	Then Edit Asset Details dialog will display
	And user can see Edit Asset Details title
	And user can see Facility label
	And user can see Location Label
	And user can see Room entry field
	And user can see Bed entry field
	And user can see Save button
	And user can see Cancel button

@TestCaseID_ @UISID_8673
Scenario: Edit CVSM Asset Details Save
	Given user is on CVSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Save button
	Then changed Room and Bed are displayed on the CVSM Asset Details page

@TestCaseID_ @UISID_8673
Scenario: Edit CVSM Asset Details Cancel
	Given user is on CVSM Edit Asset Details dialog
	When user changes Room and Bed fields
	And user clicks Cancel button
	Then original Room and Bed are displayed on the CVSM Asset Details page

@TestCaseID_ @UISID_8673 @UISID_8721
Scenario: Edit CVSM Asset Details Bed Entry Field Empty
	Given user is on CVSM Edit Asset Details dialog
	When Bed field is blank
	Then Bed field contains hint text

@TestCaseID_ @UISID_8673 @UISID_8721
Scenario: Edit CVSM Asset Details Room Entry Field Empty
	Given user is on CVSM Edit Asset Details dialog
	When Room field is blank
	Then Room field contains hint text

@TestCaseID_ @UISID_8673 @UISID_8721
Scenario: CVSM Asset Details Read Only
	Given user is on CVSM Edit Asset Details dialog
	Then the Asset Tag value is displayed
	And the Asset Tag value is read only
	And the Facility value is displayed
	And the Facility value is read only
	And the Location ID value is displayed
	And the Location ID value is read only
