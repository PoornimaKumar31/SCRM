@SoftwareRequirementID_5898
Feature: LandingPageLinks
	The customer portal shall provide URL links to the Privacy Policy and Terms of Use

@TestCaseID_8945 @UISID_8664
Scenario: Landing Terms of Use
	Given user is on Landing page
	When user clicks Terms of Use
	Then Terms and Conditions page is displayed

@TestCaseID_8946 @UISID_8664
Scenario: Landing Privacy Policy
	Given user is on Landing page
	When user clicks Privacy Policy
	Then Privacy Policy page is displayed

