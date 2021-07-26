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

@TestCaseID_9210 @UISID_8666 @UISID_8669
Scenario: Assets List Elements Table Columns
	Given the user is on Landing page
	When user clicks Facility panel for an organization
	And "Type" column 1 heading is displayed
	And "Firmware" column 2 heading is displayed
	And "Config file" column 3 heading is displayed
	And "Asset tag" column 4 heading is displayed
	And "Serial number" column 5 heading is displayed
	And "Location" column 6 heading is displayed
	And "Last connected" column 7 heading is displayed
	And "PM due" column 8 heading is displayed


@TestCaseID_9149 @UISID_8666
Scenario: Asset List sorting
	Given user is on Assets list page
	And downward arrow shows for ascending order beside Serial Number column header for default shorted column
	When user clicks "Serial number" column header
	Then downward arrow shows beside "Serial Number" column header for ascending order
	And list is sorted in ascending order by "Serial number"
	When user clicks "Firmware" column header
	Then downward arrow shows beside "Firmware" column header for ascending order
	And list is sorted in ascending order by "Firmware"
	When user clicks "Firmware" column header
	Then upward arrow shows beside "Firmware" column header for descending order
	And list is sorted in descending order by "Firmware"
	When user clicks "Config file" column header
	Then downward arrow shows beside "Config file" column header for ascending order
	And list is sorted in ascending order by "Config file"
	When user clicks "Config file" column header
	Then upward arrow shows beside "Config file" column header for descending order
	And list is sorted in descending order by "Config file"
	When user clicks "Asset tag" column header
	Then downward arrow shows beside "Asset tag" column header for ascending order
	And list is sorted in ascending order by "Asset tag"
	When user clicks "Asset tag" column header
	Then upward arrow shows beside "Asset tag" column header for descending order
	And list is sorted in descending order by "Asset tag"
	When user clicks "Last connected" column header
	Then downward arrow shows beside "Last connected" column header for ascending order
	And list is sorted in ascending order by "Last connected"
	When user clicks "Last connected" column header
	Then upward arrow shows beside "Last connected" column header for descending order
	And list is sorted in descending order by "Last connected"
	When user clicks "PM due" column header
	Then downward arrow shows beside "PM due" column header for ascending order
	And list is sorted in ascending order by "PM due"
	When user clicks "PM due" column header
	Then upward arrow shows beside "PM due" column header for descending order
	And list is sorted in descending order by "PM due"


