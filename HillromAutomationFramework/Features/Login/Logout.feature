@Software_Requirement_ID_5680
Feature: Logout
The Customer Portal shall have a feature for users to log out while logged in.

@TestCaseID_6207
Scenario: sucessfull logout
    Given user is in login page
    When user enters a valid email id and password
	And click on login button
    And click on profile icon
    And  click on logout button
    Then user will logout successfully