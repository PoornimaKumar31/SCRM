@SoftwareRequirementID_5710
Feature: Software Requirement 5710
	The Customer Portal shall have a feature for updating the following Service Monitor configuration settings.

@TestCaseID_9081 @UISID_8699
Scenario: Service Monitor Settings Select Device and Deploy
	Given user is on Service Monitor Settings page
	And user selects a Service Monitor in the list
	When the user clicks Deploy button
	Then Update process has been established message displays