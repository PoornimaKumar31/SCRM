@SoftwareRequirementID_
Feature: AdvanceTabUserListStaticElements
	Advanced tab user list static elements test

@TestCaseID_9662 @UISID_8702
Scenario: User List Elements
	Given manager user is on User List page having user entries > 2
	Then User List label is displayed
	And Create button is displayed
	And Create button is enabled
	And "Full name" column heading is displayed
	And "Role" column heading is displayed
	And "Email" column heading is displayed
	And User List Table is sorted by Email
	And Details button is displayed and enabled for all User rows
	And Delete button is displayed and enabled for all rows other than logged in user