@SoftwareRequirementID_5694
Feature: Software Requirement 5694
	The Customer Portal shall have a feature for displaying a preventative maintenance schedule for CVSM/CIWS devices.

@TestCaseID_9890 @UISID_8675
Scenario: CVSM Preventive Maintenance Schedule Subsection
	Given user is on Asset List page
	When user selects any CVSM device
	Then CVSM Asset details landing page is displayed
	And Asset Details Summary subsection is displayed
	And Preventive Maintenance Schedule subsection is displayed

@TestCaseID_9891 @UISID_8675
Scenario: CVSM Preventive Maintenance Schedule Elements
	Given user is on the Preventive maintenance tab
	Then "Name" column heading is displayed
	And "Last calibration" column heading is displayed
	And "<" and current calendar year label is displayed
	And next calendar year and ">" is displayed
	And current month is displayed followed by the other months