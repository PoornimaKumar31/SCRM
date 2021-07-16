@SoftwareRequirementID_5699
Feature: Software Requirement 5699
  The Customer Portal shall have a mechanism for displaying and downloading CSM log files.

@TestCaseID_8966 @UISID_8678
Scenario: CSM Log Files
	Given user has selected CSM device
	And user is on Device Details page
	When user clicks Logs tab
	Then logs for CSM device are displayed

@TestCaseID_8967 @UISID_8678 @UISID_8669
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
Scenario: CSM Log Files Ten Files
	Given user is on CSM Log Files page with 10 logs
	Then 10 logs for CSM device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8970 @UISID_8678
Scenario: CSM Log Files Ten Files Request Next 
	Given user is on CSM Log Files page with 10 logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8971 @UISID_8678
Scenario: CSM Log Files Ten Files Request Previous
	Given user is on CSM Log Files page with 10 logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

@TestCaseID_8972 @UISID_8678
Scenario: CSM Log Files 25 Files Next1
	Given user is on CSM Log Files page with 24 logs
	And Log files are sorted by decreasing date	
	And newest 10 logs are displayed
	When user clicks Next page button
	Then user will see next 10 older logs
	And Displaying 11 to 20 of 24 results label is displayed
	And page 2 of 3 label is displayed
	When user clicks Next page button
	Then user will see next 4 older logs
	And Displaying 21 to 24 of 24 results label is displayed
	And page 3 of 3 label is displayed

@TestCaseID_8974 @UISID_8678
Scenario: CSM Log Files Sort Decreasing Date
	Given user is on CSM Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And user will see decreasing date sorting indicator

@TestCaseID_8975 @UISID_8678
Scenario: CSM Log Files Sort Increasing Date
	Given user is on CSM Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And user will see increasing date sorting indicator