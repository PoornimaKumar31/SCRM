@SoftwareRequirementID_5720
Feature: Software Requirement 5720
	The Customer Portal shall have a mechanism for Manage User to create new users.

@TestCaseID_9345 @UISID_8703
Scenario: Add User Elements
	Given manager user is on User List page
	When user clicks Create button
	Then Add User page is displayed
	And User information label is displayed
	And Username textbox is displayed
	And unchecked checkbox with User manager label is displayed
	And Full name textbox is displayed
	And Phone number textbox is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed

	#failing, now working
@TestCaseID_9346 @UISID_8703
Scenario: Add User Maximum Length Username
	Given manager user is on Add User page
	When user enters Full name Test
	And clicks Username textbox
	And enters valid Username 12345678901234567890123456789012345678901@test.com
	And presses Tab key
	Then no username error message is displayed
	And enabled Save button is displayed
	And enabled Cancel button is displayed

	#failing, now working
@TestCaseID_9347 @UISID_8703
Scenario: Add User Invalid Username Length
	Given manager user is on Add User page
	When user enters Full name Test
	And clicks Username textbox
	And presses Tab key
	Then username error message is displayed
	When user enters invalid Username abc
	And presses Tab key
	Then username error message is displayed
	When user enters invalid Username 123456789012345678901234567890123456789012@test.com
	And presses Tab key
	Then username error message is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed
	When user clicks Cancel button
	Then User List page is displayed
	And no user is created

	#failing, now working
@TestCaseID_9348 @UISID_8703
Scenario: Add User Invalid Username Format
	Given manager user is on Add User page
	When user enters Full name "Test"
	And clicks Username textbox
	And presses Tab key
	Then username error message is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed
	When user enters invalid Username "abc"
	And presses Tab key
	Then username error message is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed
	When user clicks Cancel button
	Then User List page is displayed
	And no user is created

	#failing, just removed double quotes from input username. Now it is working fine
@TestCaseID_9350 @UISID_8703
Scenario: Add User Maximum Name
	Given manager user is on Add User page
	When user enters Username Test@test.com
	And clicks Full name textbox
	And enters 50-character Full name
	And presses Tab key
	Then no name error message is displayed
	And enabled Save button is displayed
	And enabled Cancel button is displayed

@TestCaseID_9351 @UISID_8703
Scenario: Add User Invalid Name Length
	Given manager user is on Add User page
	When user enters Username test9352@testing.com
	And clicks Full name textbox
	And enters 51-character Full name
	And presses Tab key
	Then name error message is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed
	When user clicks Cancel button
	Then User List page is displayed
	And no user is created

@TestCaseID_9352 @UISID_8703
Scenario: Add User Role Manager User
	Given manager user is on Add User page
	When user enters valid Username
	And enters valid Full name
	And enters Phone number
	And clicks User Manager checkbox
	And clicks Save
	Then User List page is displayed
	And new user is created
	And new user role is Administrator
	And Username, Name, and Phone number match

@TestCaseID_9353 @UISID_8703
Scenario: Add User Role Regular User
	Given manager user is on Add User page
	When user enters valid Username
	And enters valid Full name
	And unchecked User Manager checkbox
	And clicks Save
	Then User List page is displayed
	And new user is created
	And new user role is Regular
	And Username and Name match
	And Phone number is blank


@TestCaseID_9354 @UISID_8703
Scenario: Add User Invalid Phone Number
	Given manager user is on Add User page
	When user enters Phone number "123"
	Then phone number error message is displayed
	And disabled Save button is displayed
	And enabled Cancel button is displayed

@TestCaseID_9355 @UISID_8703
Scenario: Add User Cancel Data
	Given manager user is on Add User page
	When enters valid email address, Name, Phone
	And user clicks Cancel button
	Then User List page is displayed
	And no user is created
	When user clicks Create button
	And user clicks Cancel button
	Then User List page is displayed
	And no user is created