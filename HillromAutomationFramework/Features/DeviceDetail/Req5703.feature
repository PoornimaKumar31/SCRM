@SoftwareRequirementID_5703
Feature: Software Requirement 5703

@TestCaseID_9322 @UISID_8673
Scenario: Edit CSM Asset Details Save
Given user has selected CSM device with Room and Bed
And user is on Device Details page
When user clicks Edit button
And updates Room and Bed details
And clicks save button 
Then Updated Room and Bed is displayed on Device details page


@TestCaseID_9325 @UISID_8673
Scenario: Edit CSM Asset Details Cancel
Given user has selected CSM device with Room and Bed
And user is on Device Details page
When user clicks Edit button
And updates Room and Bed details 
And clicks cancel button
Then Updated Room and Bed is not displayed on Device details page

@TestCaseID_9326 @UISID_8673
Scenario: Edit CSM Asset Details Bed Field Empty
Given user is on CSM Edit Asset Details dialog
When user clears Bed field
Then Bed field contains hint text

@TestCaseID_9327 @UISID_8673
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