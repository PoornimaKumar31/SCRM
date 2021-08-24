@SoftwareRequirementID_5686
Feature: Software Requirement 5686
	The Customer Portal shall have a feature for displaying all devices that are available to the logged in user.

@TestCaseID_9148 @UISID_8666 @UISID_8669
Scenario: Assets List Elements
	Given the user is on Landing page
	When user clicks Facility panel for an organization
	Then Organization label is displayed
	And Organization dropdown is displayed
	And Asset type label is displayed
	And Asset type dropdown is displayed
	And Search field is displayed
	And "Type" column heading is displayed
	And "Firmware" column heading is displayed
	And "Config file" column heading is displayed
	And "Asset tag" column heading is displayed
	And "Serial number" column heading is displayed
	And "Location" column heading is displayed
	And "Last connected" column heading is displayed
	And "PM due" column heading is displayed
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

@TestCaseID_9210 @UISID_8666 @UISID_8669
Scenario: Assets List Elements Table Columns
	Given the user is on Landing page
	When user clicks Facility panel for an organization
	And "Type" label is in column 1 
	And "Status" label is in column 2
	And "Firmware" label is in column 3
	And "Config file" label is in column 4
	And "Asset tag" label is in column 5
	And "Serial number" label is in column 6
	And "Location" label is in column 7
	And "Last connected" label is in column 8
	And "PM due" label is in column 9


@TestCaseID_9149 @UISID_8666
Scenario: Asset List Sorting
	Given user is on Assets list page
	And downward arrow shows for ascending order beside Serial Number column header for default sorted column
	When user clicks "Serial number" column header
	Then upward arrow shows beside "Serial Number" column header for descending order
	And list is sorted in descending order by "Serial number"
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
	#And list is sorted in ascending order by "PM due"
	When user clicks "PM due" column header
	Then upward arrow shows beside "PM due" column header for descending order
	And list is sorted in descending order by "PM due"