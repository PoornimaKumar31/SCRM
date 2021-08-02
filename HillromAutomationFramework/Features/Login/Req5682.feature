@SoftwareRequirementID_5682
Feature: Software Requirement 5682
 The Customer Portal shall provide users to sign in using an email formatted login ID and password.

@TestCaseID_8901 @UISID_8660
Scenario: Valid Login
    Given user is on Login page
    When user enters valid email 
    And enters valid password
    And clicks Login button
    Then user will login successfully

@TestCaseID_8902 @UISID_8660	
Scenario: Invalid Login Email Error
    Given user is on Login page
    When user enters invalid email ID
    And enters any password
    And clicks Login button
    Then login invalid error message will display
	
@TestCaseID_8903 @UISID_8660	
Scenario: Invalid Login Password Error
    Given user is on Login page
    When user enters valid email 
    And enters invalid password
    And clicks Login button
    Then login invalid error message will display

@TestCaseID_8904 @UISID_8660	
Scenario: Invalid Login Blank
    Given user is on Login page
    When clicks Login button
    Then login authentication error message will display

@TestCaseID_8905 @UISID_8660	
Scenario: Invalid Login No Email
    Given user is on Login page
    When enters any password
    And clicks Login button
    Then login authentication error message will display

@TestCaseID_8906 @UISID_8660	
Scenario: Invalid Login No Password
    Given user is on Login page
    When user enters valid email
    And clicks Login button
    Then login authentication error message will display

@TestCaseID_8907 @UISID_8660 @UISID_8721	
Scenario: Field Entry Username Empty
    Given user is on Login page
    When username field is blank
    Then username field contains hint text

@TestCaseID_8908 @UISID_8660 @UISID_8721	
Scenario: Field Entry Password Empty
    Given user is on Login page
    When password field is blank
    Then password field contains hint text