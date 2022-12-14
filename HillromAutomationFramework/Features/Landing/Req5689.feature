@SoftwareRequirementID_5689
Feature: Software Requirement 5689
	The Customer Portal shall display a system roll-up view based on setup configuration.

@TestCaseID_9098 @UISID_8664 @UISID_8665
Scenario: System Roll-up View
	Given user login with roll-up page
	Then Roll-up page is displayed

@TestCaseID_9235 @UISID_8664 @UISID_8665
Scenario: System No Roll-up View
	Given user login without roll-up page
	Then Roll-up page is not displayed
	And Asset list page is displayed


@TestCaseID_9099 @UISID_8664 @UISID_8665
Scenario: System Rollup View Elements
	Given user is on Landing page
	And Roll-up page is displayed
	Then Organization name is displayed
	And Facility name is displayed
	And Servers are displayed
	And Devices are displayed