@SoftwareRequirementID_5726
Feature: Software Requirement 5726
	The Customer portal shall allow the Manage User to create additional Regular user account.

@TestCaseID_9435 @UISID_8703
Scenario: User List Create Regular User
Given Manager user is on Add User page
When user enters valid Username
And enters valid Full name
And unchecks User Manager checkbox
And clicks Save button
Then User List page is displayed
And newly added regular user is displayed