@SoftwareRequirementID_5684
Feature: Software Requirement 5684
	 The Customer Portal shall have a mechanism for users to reset their password using the email address registered with the Customer Portal.

@TestCaseID_8909 @UISID_8660 @UISID_8662	
Scenario: Forgot Password
    Given user is on Login page
    When user clicks forgot password
    Then Forgot Password page is displayed

@TestCaseID_8910 @UISID_8721 @UISID_8662	
Scenario: Field Entry Email Empty
    Given user is on Forgot Password page
    When email field is blank
    Then email field contains hint text

@TestCaseID_8911 @UISID_8660 @UISID_8662	
Scenario: Forgot Password Invalid Email
    Given user is on Forgot Password page
    When user enters invalid email address
    Then Submit button is disabled
    And forgot invalid error message is displayed

@TestCaseID_8912 @UISID_8660 @UISID_8662	
Scenario: Forgot Password Valid Email
    Given user is on Forgot Password page
    When user enters valid email address
    And user clicks Submit button
    Then Login page is displayed
    And notification message is displayed
    And notification message disappears after a few seconds

@TestCaseID_8913 @UISID_8660 @UISID_8662	
Scenario: Forgot Password No Email
    Given user is on Forgot Password page
    Then Submit button is disabled

@TestCaseID_8914 @UISID_8660 @UISID_8662	
Scenario: Forgot Password Login
    Given user is on Forgot Password page
    When user clicks Login
    Then Login page is displayed