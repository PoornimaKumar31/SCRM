@SoftwareRequirementID_5898
Feature: MainPageFooterLinks
	The customer portal shall provide URL links to the following:
	Global Service Center
	Privacy Policy
	Terms of Use
	Contact Us

@TestCaseID_ @UISID_8718
Scenario: Main Terms of Use
	Given user is on Main page
	When user clicks Terms of Use
	Then Terms and Conditions page is displayed

@TestCaseID_ @UISID_8718
Scenario: Main Global Service Center
	Given user is on Main page
	When user clicks Global Service Center
	Then Global Service Center page is displayed

@TestCaseID_ @UISID_8718
Scenario: Main Privacy Policy
	Given user is on Main page
	When user clicks Privacy Policy
	Then Privacy Policy page is displayed

@TestCaseID_ @UISID_8718
Scenario: Main Contact Us
	Given user is on Main page
	When user clicks Contact Us
	Then Contact Us page is displayed




