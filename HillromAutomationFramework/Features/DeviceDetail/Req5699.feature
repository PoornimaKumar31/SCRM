@SoftwareRequirementID_5699
Feature: Software Requirement 5699
  The Customer Portal shall have a mechanism for displaying and downloading CSM log files.

@TestCaseID_8966 @UISID_8678
Scenario: CSM Log Files
	Given user has selected CSM device
	And user is on Device Details page
	When user clicks Logs tab
	Then logs for CSM device are displayed

@TestCaseID_8967 @UISID_8678
Scenario: CSM Log Files Empty
	Given user is on CSM Log Files page with 0 logs
	Then no logs for CSM device are displayed

@TestCaseID_8968 @UISID_8678
Scenario: CSM Log Files Download
	Given user is on CSM Log Files page with 10 logs
	When user clicks log
	Then log is downloaded to computer
	And downloaded filename matches 

@TestCaseID_8969 @UISID_8678
Scenario: CSM Log Files 10 Files
	Given user is on CSM Log Files page with 10 logs
	Then 10 logs for CSM device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8970 @UISID_8678
Scenario: CSM Log Files 10 Files Request Next 
	Given user is on CSM Log Files page with 10 logs
	When user clicks Request Logs button
	Then Received, Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8971 @UISID_8678
Scenario: CSM Log Files 10 Files Request Previous
	Given user is on CSM Log Files page with 10 logs
	And Received, Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Received, Pending or Executing message is displayed

@TestCaseID_8972 @UISID_8678 @UISID_8669
Scenario: CSM Log Files 24 Files All Pages
	Given user is on CSM Log Files page with 24 logs
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

@TestCaseID_8974 @UISID_8678
Scenario: CSM Log Files Sort Decreasing Date
	Given user is on CSM Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs are sorted by decreasing date
	And decreasing date sorting indicator is displayed

@TestCaseID_8975 @UISID_8678
Scenario: CSM Log Files Sort Increasing Date
	Given user is on CSM Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs are sorted by increasing date
	And increasing date sorting indicator is displayed