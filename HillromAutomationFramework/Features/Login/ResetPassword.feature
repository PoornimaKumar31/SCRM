@Software_Requirement_ID_5684
Feature: Reset Password
	The Customer Portal shall have a mechanism for users to reset their password using the email address registered with the customer portal.


@TestCaseID_6213	
Scenario: Resetting the password with valid email-id
    Given user is in login page
    When user click on forgot password
	And enters a valid email
	And click on submit button
    Then update message will displayed in login page

@ExtraTestCase_ForgotPassword_1	
Scenario: Resetting the password with invalid email-id
    Given user is in login page
    When user click on forgot password
	And enter invalid email in forgot password page
	Then submit button is disabled

@ExtraTestCase_ForgotPassword_2		
Scenario: Resetting the password without email-id
    Given user is in login page
    When user click on forgot password
	And click on submit button
    Then invalid email error message is displayed

@ExtraTestCase_ForgotPassword_3		
Scenario: Returning to the login page from reset password page
    Given user is in login page
    When user click on forgot password
	And click on Login button in forgot password page
    Then redirect to the login page
