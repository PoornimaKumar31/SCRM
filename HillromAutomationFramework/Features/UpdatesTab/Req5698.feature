@SoftwareRequirementID_5698
Feature: Software Requirement 5698
	The Customer Portal shall have a mechanism for deleting CVSM/CIWS configuration file with a confirmation dialog.

@TestCaseID_9045 @UISID_8696
Scenario: CVSM Configuration File Delete
	Given user is on CVSM Updates page
	And CVSM Asset type is selected
	And Configuration Update type is selected
	When user selects CVSM configuration
	And user clicks Delete button
	Then CVSM Configuration File Delete Confirmation dialog is displayed

@TestCaseID_9046 @UISID_8696
Scenario: CVSM Configuration File Delete Dialog Elements
	Given user is on CVSM Configuration File Delete dialog
	Then selected Configuration file is displayed
	And Are you sure message is displayed
	And Yes button is displayed
	And No button is displayed


@TestCaseID_9048 @UISID_8696
Scenario: CVSM Configuration File Not Deleted
	Given user is on CVSM Configuration File Delete dialog
	When user clicks No button
	Then configuration is not deleted from Configuration list