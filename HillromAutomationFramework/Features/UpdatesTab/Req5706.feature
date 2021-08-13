@SoftwareRequirementID_5706
Feature: Software Requirement 5706
	The Customer Portal shall have a mechanism for delivering scheduled firmware upgrade to one or more CSM devices.

@TestCaseID_9166 @UISID_8698
Scenario: CSM Review Action Schedule Elements
	Given user is on CSM Review Action page
	When user clicks Schedule radio button
	Then Date label is displayed 
	And Calendar icon is displayed
	And Time label is displayed
	And Hour dropdown is displayed
	And Minutes dropdown is displayed
	And Confirm button is displayed
	And Previous button is displayed

@TestCaseID_9167 @UISID_8698
Scenario: CSM Schedule Time Hour Elements
	Given user is on CSM Review Action page
	When user clicks Schedule radio button
	And clicks Hour dropdown
	Then Hour dropdown displays 00 to 23 

@TestCaseID_9168 @UISID_8698
Scenario: CSM Schedule Time Minutes Elements
	Given user is on CSM Review Action page
	When user clicks Schedule radio button
	And clicks Minutes dropdown
	Then Minutes dropdown displays 00, 15, 30 and 45

@TestCaseID_9169 @UISID_8698
Scenario: CSM Schedule Date and Time
	Given user is on CSM Review Action page
	When user clicks Schedule radio button
	When user selects Date from Date selector icon
	And clicks Hour dropdown
	And selects hours between 00-23
	And clicks Minutes dropdown
	And selects minutes between 00-45
	And clicks Confirm button
	Then Upgrade process has been established message is displayed
	Then Select Assets page is displayed