@Software_Requirement_ID_5899
Feature: SupportedBrowserList
	The customer portal shall display Supported Browsers.

@TestCaseID_6352 
Scenario: Verification of supported browsers link
    Given user is in login page
    When user click on supported Browsers
    Then popup is displayed with list of supported browsers
    And click on close button