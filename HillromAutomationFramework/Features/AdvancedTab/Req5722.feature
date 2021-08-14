@SoftwareRequirementID_5722
Feature: Software Requirement 5722
	The Customer Portal shall have a mechanism for Manager User 
	to delete existing users with a confirmation dialog.

@TestCaseID_9429 @UISID_8705
Scenario: Delete User Dialog Elements
	Given manager user is on User List page having more than 2 records
	When user clicks Delete button for user
	Then Delete User pop-up dialog is displayed
	And user full name and email address are displayed
	And "Are you sure you want to delete this user?" message is displayed
	And Yes button is displayed
	And No button is displayed

@TestCaseID_9430 @UISID_8705
Scenario: Delete User No
	Given manager user is on User List page having more than 2 records
	And user clicks Delete button for user
	And Delete User pop-up dialog is displayed
	When user clicks No button
	Then Delete User pop-up dialog closes
	And User List page is displayed
	And user is not deleted

@TestCaseID_9431 @UISID_8705
Scenario: Delete User Yes
	Given manager user is on User List page having more than 2 records
	And user clicks Delete button for user
	And Delete User pop-up dialog is displayed
	When user clicks Yes button
	Then Delete User pop-up dialog closes
	And User List page is displayed
	And user is deleted