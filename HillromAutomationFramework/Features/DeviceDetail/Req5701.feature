@SoftwareRequirementID_5701
Feature: Software Requirement 5701
	The Customer Portal shall have a mechanism for displaying a preventative maintenance schedule for CSM device.

#@TestCaseID_ @UISID_8675
#Scenario: CSM Preventive Maintenance Schedule
#	Given user is on Asset List page
#	When user selects any CSM device
#	Then CSM Asset details landing page is displayed
#	And Asset Details Summary subsection is displayed
#	And Preventive Maintenance Schedule subsection is displayed

@TestCaseID_ @UISID_8675
Scenario: CSM Preventive Maintenance Schedule Elements
	Given user is on the CSM Preventive Maintenance Schedule tab
	Then Name column heading is displayed
	And Last calibration column heading is displayed
	And timeline column is displayed
	And components are displayed
	And last calibration date is displayed
	And calibration overdue with date and arrow is displayed


