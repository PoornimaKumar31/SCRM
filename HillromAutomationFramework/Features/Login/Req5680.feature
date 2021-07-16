@SoftwareRequirementID_5680
Feature: Software Requirement 5680 
    The Customer Portal shall have a feature for users to log out while logged in.

@TestCaseID_8916 @UISID_8717
Scenario: Logout
    Given user is logged in
    When user clicks Logout button
    Then Login page is displayed