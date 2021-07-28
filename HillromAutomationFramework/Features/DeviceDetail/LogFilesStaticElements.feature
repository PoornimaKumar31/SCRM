Feature: Log Files Static Elements

@TestCaseID_8953 @UISID_8678 @UISID_8669
Scenario: Log Files Static Elements
	Given user has selected any device
	And user is on Device Details page
	When user clicks Logs tab
	Then Log Files label is displayed
	And Request Logs button is displayed
	And Name column heading is displayed
	And Date column heading is displayed
	And date sorting indicator is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Displaying x to y of z results label is displayed 0
	And Page x of y label is displayed 0
