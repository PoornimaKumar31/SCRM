@SoftwareRequirementID_5721
Feature: Software Requirement 5721
	The Customer Portal shall have a mechanism for Manage User to edit existing users.

@TestCaseID_9330 @UISID_8704
Scenario: Edit User Elements
	Given manager user is on User Management page having user entries list > 2
	When user clicks Details button for other User record
	Then Edit Users page is displayed
	And User information label is displayed
	And Username textbox is displayed
	And Username textbox is read only
	And checkbox with label User manager is displayed
	And checkbox is unchecked
	And Full name textbox is displayed
	And Phone number textbox is displayed
	And Log history label is displayed
	And Date column heading is displayed
	And Details column heading is displayed
	And Save and Cancel buttons are displayed
	And Save button is enabled
	And Cancel button is enabled
	

@TestCaseID_9332 @UISID_8704
Scenario: Edit User Full Name Validity Check
	Given manager user is on Edit User page
	When user enters Full name with ">50" characters
	And presses Tab
	Then full name error message is displayed
	And Save button is disabled
	When user clears Full name field
	And presses Tab
	Then full name error message is displayed
	And Save button is disabled
	When user enters Full name with "<=50" characters
	And presses Tab
	Then full name error message is not displayed 
	And Save button is enabled
	When user clicks Save button
	Then updated Full name is displayed on User List

@TestCaseID_9333 @UISID_8704
Scenario: Edit User Cancel Blank Full Name
	Given manager user is on Edit User page
	When user enters blank Full name
	And clicks Cancel button
	Then user list page is displayed
	And user is not edited

@TestCaseID_9334 @UISID_8704
Scenario: Edit User Phone Number
	Given manager user is on Edit User page
	When user enters phone number "1234567890"
	Then phone number error message is displayed
	And Save button is disabled
	When user enters a plus sign and a random 11-digit Phone number
	Then phone number error message is not displayed
	And Save button is enabled
	When user clicks Save button
	And clicks Details button for same user
	Then Phone number is entered number

@TestCaseID_9335 @UISID_8704
Scenario: Edit User Blank Phone Number
    Given manager user is on User List page
    When user clicks Details button for user with a phone number
    And user enters blank Phone number
    Then phone number error message is not displayed
    And Save button is enabled
    When user clicks Save button
    And clicks Details button for same user
    Then Phone number is blank

@TestCaseID_9336 @UISID_8704
Scenario: Cancel Edit User Invalid Phone Number
	Given manager user is on User List page
	When user clicks Details button for user with a phone number
	And user enters invalid phone number "123"
	And clicks Cancel button
	Then user list page is displayed
	When clicks Details button for same user
	Then Phone number is unchanged

@TestCaseID_9337 @UISID_8704
Scenario: Edit User Manager 
	Given manager user is on User List page
	When user clicks Details button for user with Administrator role
	And user deselects the User Manager checkbox
	And user clicks Save button
	Then Regular is displayed in Role column in user list
	When clicks Details button for same user
	And user selects the User Manager checkbox
	And user clicks Save button
	Then Administrator is displayed in Role column in User List

@TestCaseID_9339 @UISID_8704
Scenario: Cancel Edit User
	Given manager user is on Edit User page
	When user changes Full name, Phone number and Role
	And clicks Cancel button
	Then Full name, Phone number, and Role are not changed on User List page

@TestCaseID_9344 @UISID_8704
Scenario: Edit User Log History
	Given manager user is on Edit User page with log entries > 2
	Then Log History table is sorted by descending date sort order
