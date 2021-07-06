@SoftwareRequirementID_5689
Feature: RollUpPage
	The Customer Portal shall display a system roll-up view based on setup configuration.

@TestCaseID_ @UISID_
Scenario: System with rollup
	Given user is logging in with rollup page configuration
	Then user will see Organization titles
	And facility panel with the titles
	And location information on each facility panel

@TestCaseID_ @UISID_
Scenario: System withot Rollup
	Given user is logged without rollup page configuration
	Then user will see the Mainpage
	And without roll up