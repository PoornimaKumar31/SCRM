@SoftwareRequirementID_5701
Feature: Software Requirement 5701
	CSM Preventive Maintenance Overdue

@TestCaseID_9887 @UISID_8675
Scenario: CSM Preventive Maintenance Overdue
	Given user is on Asset List page
	When user selects CSM device with serial number "100001954714"
	And clicks Preventive maintenance tab
	Then Preventive maintenance schedule subsection is displayed
	And Host controller graphic is displayed in "Name" column
	And "Host controller" is displayed in "Name" column
	And "Last calibration" is "30 Sep 2015" on "Host controller" row in "Last calibration" column
	And "Calibration overdue" message is displayed on "Host controller" row
	And "30 SEP 2016" message is displayed on "Host controller" row
	And left pointing red arrow is displayed on "Host controller" row