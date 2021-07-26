@SoftwareRequirementID_5690
Feature: Software Requirement 5690
	The Customer Portal shall have a feature for searching partial character string from the device list.

@TestCaseID_9135 @UISID_8667 @UISID_8721 
Scenario: Assets Search Hint Text
	Given user is on Assets List page
	Then Search field contains hint text

@TestCaseID_9136 @UISID_8667
Scenario: Assets Search Matching String Type
	Given user is on Assets List page with more than one device
	When user enters partial Type text in Search field
	And presses Enter key
	Then results in table contain only assets with types that contain Search text

@TestCaseID_9137 @UISID_8667
Scenario: Assets Search Matching String Asset Tag
	Given user is on Assets List page with more than one device
	When user enters partial Asset tag text in Search field
	And presses Enter key
	Then results in table contain only assets with Asset tags that contain Search text

@TestCaseID_9138 @UISID_8667
Scenario: Assets Search Matching String Serial Number
	Given user is on Assets List page with more than one device
	When user enters partial Serial number text in Search field
	And presses Enter key
	Then results in table contain only assets with Serial numbers that contain Search text

@TestCaseID_9139 @UISID_8667
Scenario: Assets Search Matching String Firmware Version
	Given user is on Assets List page with more than one device
	When user enters partial Firmware version text in Search field
	And presses Enter key
	Then results in table contain only assets with Firmware versions that contain Search text

@TestCaseID_9140 @UISID_8667 @UISID_8669
Scenario: Assets Search No Results Found
	Given user is on Assets List page with more than one device
	When user enters text in Search field that does not match any asset in table
	And presses Enter key
	Then 0 results are displayed
	And Displaying 0 to 0 of 0 results is displayed

@TestCaseID_9141 @UISID_8668
Scenario: Advanced Search AP MAC Address
	Given user is on Assets List page with more than one device
	When user enters valid MAC address in advanced AP search string
	And presses Enter key
	Then results in table contain only assets with AP MAC addresses that match Search text

@TestCaseID_9142 @UISID_8667
Scenario: Assets Search Clear
	Given user has performed asset search
	When user clicks X button
	Then Search field is cleared
	And all assets are displayed

@TestCaseID_9175 @UISID_8669
Scenario: Search Result Footer
	Given user has performed asset search
	And there are devices matching the asset search
	Then Displaying x to y of z results label is displayed
	And Page x of y label is displayed
	And Next page and Previous page icons are displayed