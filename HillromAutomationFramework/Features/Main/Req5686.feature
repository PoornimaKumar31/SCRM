@SoftwareRequirementID_5686
Feature: Software Requirement 5686
	The Customer Portal shall have a feature for displaying all devices that are available to the logged in user.

@TestCaseID_9148 @UISID_8666 @UISID_8669
Scenario: Assets List Elements
	Given the user is on Landing page
	When user clicks Facility panel for an organization
	Then Organization label is displayed
	Then Organization dropdown is displayed
	Then Asset type label is displayed
	Then Asset type dropdown is displayed
	Then Search field is displayed
	Then "Type" column heading is displayed
	Then "Firware" column heading is displayed
	Then "Config file" column heading is displayed
	Then "Asset tag" column heading is displayed
	Then "Serial number" column heading is displayed
	Then "Location" column heading is displayed
	Then "Last conected" column heading is displayed
	Then "PM due" column heading is displayed
	Then Page x of y label is displayed
	Then Displaying x to y of z results label is displayed