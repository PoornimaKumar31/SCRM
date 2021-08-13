@SoftwareRequirementID_5724
Feature: Software Requirement 5724
	The Customer Portal shall support Regular and Manage User roles.

@TestCaseID_9432 @UISID_8703
Scenario: Manager User Role
	Given user login as Manager role
	Then Main page is displayed
	And Advanced tab is displayed

@TestCaseID_9433 @UISID_8703
Scenario: Regular User Role
	Given user login as Regular role
	Then Main page is displayed
	And Advanced tab is not displayed