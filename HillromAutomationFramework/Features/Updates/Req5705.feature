@SoftwareRequirementID_5705
Feature: Software Requirement 5705
	The Customer Portal shall have a mechanism for delivering upgrade firmware 
	to one or more CSM devices.

Scenario: Select CSM Upgrade Update Type
	Given user is on CSM Updates page
	And CSM Asset type is selected
	When user selects Upgrade Update type
	Then Upgrade displays as Update type
	And CSM upgrade list is displayed
	And Manage Active Updates label is displayed
	And Name column heading is displayed
	And Date created column heading is displayed
	And Next button is disabled
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

Scenario: CSM Upgrade files less than equal 50 entries
	Given user is on CSM Updates page with "<= 50" entries
	Then Previous page arrow is disabled
	And Next page arrow is disabled

Scenario: CSM Upgrade files greater than 50 entries
	Given user is on CSM Updates page with "> 50" entries
	Then Previous page button is disabled
	And Next page arrow is enabled

Scenario: CSM Upgrade files greater than 50 and smaller than equal 100 entries
	Given user is on CSM Updates page with "> 50 and <= 100" entries
	And first 50 entries are displayed
	When user clicks Next page button
	Then second page of entries is displayed
	And Next page arrow is disabled
	And Previous page arrow is disabled

Scenario: CSM Upgrade Selected
	Given user is on CSM Updates page
	And CSM Asset type is selected
	And Upgrade Update type is selected
	And Select Upgrade file
	When user clicks Next button
	Then CSM Select assets page is displayed

Scenario: CSM Select Assets Elements
	Given user is on CSM Upgrade Select assets page
	Then Select update indicator is not highlighted
	And Select assets indicator is highlighted
	And Review action indicator is not highlighted
	And "Item to push" label is displayed
	And "device type" label is displayed
	And "update type" label is displayed
	And "upgrade file to push" label is displayed
	And "Destinations" label is displayed
	And location hierarchy selectors are displayed
	And count of selected devices is displayed
	And Previous button is enabled
	And Next button is disabled in select device page
	And Page x of y label is displayed
	And Displaying x to y of z results label is displayed

Scenario: CSM Select Assets Elements Table
	Given user is on CSM Upgrade Select assets page
	Then Select all checkbox in column 1 is unchecked
	And column 2 heading "Firmware" is displayed
	And column 3 heading "Config" is displayed
	And column 4 heading "Asset Tag" is displayed
	And column 5 heading "Serial" is displayed
	And column 6 heading "Location" is displayed
	And column 7 heading "Last Files Deployed" is displayed

Scenario: CSM Select assets
	Given user is on CSM Upgrade Select assets page
	When user selects one device
	Then count of selected devices changes from 0 to 1
	And Next button is enabled

Scenario: CSM Select assets Previous
	Given user is on CSM Upgrade Select assets page
	When user clicks Previous button
	Then user is on CSM Updates page

Scenario: CSM Review Action page
	Given user is on CSM Upgrade Select assets page
	When user selects one device
	And Clicks Next button
	Then CSM Review Action page is displayed

Scenario: CSM Review Action Elements
Given user is on CSM Review Action page
Then Item to push label is displayed
And Item to push value is displayed
And Destinations label is displayed
And Destinations value is displayed
And Date or Time of push label is displayed
And Immediately label is displayed
And Immediately label is by default selected
And Checkbox is displayed for immediately and it is selected
And Checkbox is displayed for schedule
And Schedule label is displayed
And Select update indicator is not highlighted
And Select assets indicator is not highlighted
And Review action indicator is highlighted
And Previous button is enabled
And Confirm button is enabled

Scenario: CSM Review Action Confirm
	Given user is on CSM Review Action page
	When user clicks Confirm button
	Then Update process has been established message is displayed
	And Select assets page is displayed

Scenario: CSM Review Action Previous
	Given user is on CSM Review Action page
	When user clicks Previous button
	Then Select assets page is displayed