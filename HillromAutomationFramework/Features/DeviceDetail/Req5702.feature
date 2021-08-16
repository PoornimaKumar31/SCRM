@SoftwareRequirementID_5702
Feature: Software Requirement 5702
The Customer Portal shall have a mechanism for displaying CSM device details.

@TestCaseID_9673 @UISID_8672 @UISID_8677
Scenario: CSM General Layout
	Given user is on Asset List page with more than one CSM
	When user clicks any CSM
	Then Asset Details landing page is displayed
	And Asset Detail summary subsection with Edit button is displayed
	And Preventive Maintenance tab is displayed
	And Component Information tab is displayed
	And Logs tab is displayed
	And Asset Detail subsection is displayed