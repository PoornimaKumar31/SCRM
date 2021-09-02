@SoftwareRequirementID_5691
Feature: Software Requirement 5691  
The Customer Portal shall have a feature for displaying a list of CVSM log files

@TestCaseID_8952 @UISID_8672 @UISID_8678
Scenario: CVSM Log Files
	Given user has selected CVSM device
	And user is on Device Details page
	When user clicks Logs tab
	Then logs for CVSM device are displayed

@TestCaseID_8954 @UISID_8678
Scenario: CVSM Log Files Empty
	Given user is on CVSM Log Files page with 0 logs
	Then no logs for CVSM device are displayed

@TestCaseID_8955 @UISID_8678
Scenario: CVSM Log Files 10 Files
	Given user is on CVSM Log Files page with 10 logs
	Then 10 logs for CVSM device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8958 @UISID_8678 @UISID_8669
Scenario: CVSM Log Files 24 Files All Pages
	Given user is on CVSM Log Files page with 24 logs
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

@TestCaseID_8961 @UISID_8678
Scenario: CVSM Log Files Sort Decreasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs are sorted by decreasing date
	And decreasing date sorting indicator is displayed

@TestCaseID_8962 @UISID_8678
Scenario: CVSM Log Files Sort Increasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs are sorted by increasing date
	And increasing date sorting indicator is displayed