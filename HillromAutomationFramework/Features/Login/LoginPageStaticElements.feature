Feature: Login page Static Elements
	To verify the static elements of the login page in SCRM portal.

@TestCaseID_8927 @UISID_8660
Scenario: Login Static Elements
	Given user is on Login page
	Then user will see login Hillrom logo
	And login SmartCare Remote Management title
	And login instructions
	And a Ready to Get Started message
	And a copyright message
