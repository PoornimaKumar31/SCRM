Feature: Google

@mytag
Scenario: Add two numbers
	Given user launch chrome browser
	And navigate to google search page
	When search hello 
	Then result will be displayed