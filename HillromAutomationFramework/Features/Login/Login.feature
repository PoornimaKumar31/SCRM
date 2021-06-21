@Software_Requirement_ID_5682
Feature: Login
The Customer Portal shall provide users to sign in using an email formatted login ID and password.

@TestCaseID_6212
Scenario: Login with valid credentials
    Given user is in login page
    When user enters a valid email id
	And enters a valid password
	And click on login button
    Then user will login successfully

@TestCaseID_6291	
Scenario: Login with Invalid Email ID
    Given user is in login page
    When enter invalid email id
	And enters a valid password
	And click on login button
    Then username or password is invalid error message will display
	
@TestCaseID_6292	
Scenario: Login with valid Email ID and Invalid Password
    Given user is in login page
    When user enters a valid email id
	And enter invalid password
	And click on login button
    Then username or password is invalid error message will display

@ExtraTestCase_LOGIN_1	
Scenario: Login with empty Email ID and Password fields
    Given user is in login page
    When click on login button
    Then authentication error message will display

