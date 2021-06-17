Feature: Google Test

@mytag
Scenario: Search hello on google
	Given user launched chrome browser
	And navigate to google website
	When user search for hello
	Then user will see result
	And user closes the browser