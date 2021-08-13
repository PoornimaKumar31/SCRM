@SoftwareRequirementID_5725
Feature: Software Requirement 5725
	The Customer Portal Manage User shall be able to create additional Manage user account.

@TestCaseID_9434 @UISID_8703
Scenario: User List Create Manage User
	Given Manager user is on Add User page
	When user enters valid Username
	And enters valid Full name
	And checks User Manager checkbox
	And clicks Save button
	Then User List page is displayed
	And newly added manager user is displayed