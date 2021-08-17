@SoftwareRequirementID_
Feature: AdvanceTabUserListStaticElements
	Advanced tab user list static elements test

@TestCaseID_9662 @UISID_8702
Scenario: User List Elements
	Given manager user is on USER LIST page having user entries > 2
	Then USER LIST label is displayed
	And CREATE button is displayed
	And CREATE button is enabled
	And Full name Column1 is displayed
	And Role Column2 is displayed
	And Email Column3 is displayed
	And User List Table is sorted by Email
	And Details Button is displayed and enabled for all User rows
	And Delete Button is displayed and enabled for other than logged in user for all rows
