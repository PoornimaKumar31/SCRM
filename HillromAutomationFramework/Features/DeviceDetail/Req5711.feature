@SoftwareRequirementID_5711
Feature: Software Requirement 5711 
The customer portal shall have a mechanism for displaying RV700 log files.

@TestCaseID_8978 @UISID_8678
Scenario: RV700 Log Files
	Given user has selected RV700 device
	And user is on Main page
	When user clicks Logs tab
	Then logs for RV700 device are displayed

@TestCaseID_8979 @UISID_8678
Scenario: RV700 Log Files Empty
	Given user is on RV700 Log Files page with 0 logs
	Then no logs for RV700 device are displayed

@TestCaseID_8980 @UISID_8678
Scenario: RV700 Log Files 10 Files
	Given user is on RV700 Log Files page with 10 logs
	Then 10 logs for RV700 device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8983 @UISID_8678 @UISID_8669
Scenario: RV700 Log Files 24 Files All Pages
	Given user is on RV700 Log Files page with 24 logs
	And logs are sorted by decreasing date
	Then 10 newest logs are displayed
	And "Page 1" pagination label is displayed
	And Next page icon is enabled
	And Previous page icon is disabled
	When user clicks Next page button
	Then next 10 older logs are displayed
	And "Page 2" pagination label is displayed
	And Next page icon is enabled
	And Previous page icon is enabled
	When user clicks Next page button
	Then next 4 older logs are displayed
	And "Page 3" pagination label is displayed
	And Next page icon is disabled
	And Previous page icon is enabled

@TestCaseID_8985 @UISID_8678
Scenario: RV700 Log Files Sort Decreasing Date
	Given user is on RV700 Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs are sorted by decreasing date
	And decreasing date sorting indicator is displayed

@TestCaseID_8986 @UISID_8678
Scenario: RV700 Log Files Sort Increasing Date
	Given user is on RV700 Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs are sorted by increasing date
	And increasing date sorting indicator is displayed