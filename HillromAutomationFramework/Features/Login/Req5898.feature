@SoftwareRequirementID_5898
Feature: Software Requirement 5898
	The customer portal shall provide URL links to Global Privacy notice and Terms of use

@TestCaseID_8923 @UISID_8661    
Scenario: Login Privacy Policy
    Given user is on Login page
    When user clicks Privacy Policy
    Then Privacy Policy page is displayed

@TestCaseID_8924 @UISID_8661     
Scenario: Login Terms of Use
    Given user is on Login page
    When user clicks Terms of Use
    Then Terms and Conditions page is displayed
 