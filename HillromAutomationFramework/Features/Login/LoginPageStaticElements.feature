Feature: Login page Static Elements
	To verify the static elements of the login page in SCRM portal.

@TestCaseID_8927 @UISID_8660
Scenario: Login Static Elements
	Given user is on Login page
	Then Hillrom logo is displayed
	And SmartCare Remote Management title is displayed
	And login instructions is displayed
	And Ready to Get Started message is displayed
	And copyright message is displayed
