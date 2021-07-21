@SoftwareRequirementID_5899
Feature: Software Requirement 5899
	The customer portal shall display Supported Browsers.

@TestCaseID_8925 @UISID_8660 
Scenario: Login Supported Browsers
    Given user is on Login page
    When user clicks Supported Browsers
    Then Supported Browsers dialog is displayed

@TestCaseID_8926 @UISID_8660 
Scenario: Login Supported Browsers Close
    Given user is on Supported Browsers dialog
    When user clicks close button
    Then Supported Browsers dialog is closed