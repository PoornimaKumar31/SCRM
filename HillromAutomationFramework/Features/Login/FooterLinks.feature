@Software_Requirement_ID_5898
Feature: FooterLinks
	The customer portal shall provide URL links to Global Privacy notice and Terms of use

@TestCaseID_6314    
Scenario: Verification of Privacy Policy link
    Given user is in login page
    When User click on Privacy Policy link
    Then It will display "Global Privacy Notice" page.

@TestCaseID_6314     
Scenario: Verification of Terms of use link
    Given user is in login page
    When User click on Terms of use link
    Then It will display "Hillrom Terms and Conditions" page.
 