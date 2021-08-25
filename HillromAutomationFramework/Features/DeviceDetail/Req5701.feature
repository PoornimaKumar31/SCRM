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

@TestCaseID_9888 @UISID_8675
Scenario: CSM Preventive Maintenance OK
	Given user is on Asset List page
	When user selects CSM device with serial number "100055940720"
	And clicks Preventive maintenance tab
	Then Preventive maintenance schedule subsection is displayed
	And Host controller graphic is displayed in "Name" column
	And "Host controller" is displayed in "Name" column
	And "Last calibration" is "12 Feb 2021" on "Host controller" row in "Last calibration" column
	And "Calibration due" message is displayed on "Host controller" row
	And "12 FEB 2022" message is displayed on "Host controller" row
	And upward pointing black arrow is displayed on "Host controller" row

@TestCaseID_9889 @UISID_8675
Scenario: CSM Preventive Maintenance Schedule Elements
	Given user is on the Preventive maintenance tab
	Then "Name" column heading is displayed
	And "Last calibration" column heading is displayed
	And "<" and current calendar year label is displayed
	And next calendar year and ">" is displayed
	And current month is displayed followed by the other months