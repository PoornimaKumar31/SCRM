Feature: Forgot Password Static Elements
	To verify the static elements of the Forgot password page in SCRM portal.

@TestCaseID_8928 @UISID_8662
Scenario: Forgot Password Static Elements
	Given user is on Forgot Password page
	Then Hillrom logo is displayed
	And SmartCare Remote Management title is displayed
	And reset instructions is displayed