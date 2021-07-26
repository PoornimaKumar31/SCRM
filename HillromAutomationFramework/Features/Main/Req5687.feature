@SoftwareRequirementID_5687
Feature: Software Requirement 5687
	The Customer Portal shall have a feature for filtering which devices are displayed to the logged in user.

@TestCaseID_9100
Scenario: Asset Type All Assets
	Given user is on Assets List page with more than one device
	And Asset type is All assets
	Then all organization devices are displayed

@TestCaseID_9101
Scenario: Asset Type CSM
	Given user is on Assets List page with more than one device
	When user selects CSM from Asset type dropdown
	Then all orgnaization CSM devices are displayed

@TestCaseID_9102
Scenario: Asset Type CVSM
	Given user is on Assets List page with more than one device
	When user selects CVSM from Asset type dropdown
	Then all orgnaization CVSM devices are displayed

@TestCaseID_9103
Scenario: Asset Type RV700
	Given user is on Assets List page with more than one device
	When user selects RV700 from Asset type dropdown
	Then all orgnaization RV700 devices are displayed
