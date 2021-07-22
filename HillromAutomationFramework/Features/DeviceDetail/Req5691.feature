@SoftwareRequirementID_5691
Feature: Software Requirement 5691  
The Customer Portal shall have a feature for displaying a list of CVSM log files

@TestCaseID_8952 @UISID_8672 @UISID_8678
Scenario: CVSM Log Files
	Given user has selected CVSM device
	And user is on Device details page
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

@TestCaseID_8956 @UISID_8678 @UISID_8669
Scenario: CVSM Log Files 10 Files Request Next
	Given user is on CVSM Log Files page with 10 logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8957 @UISID_8678 @UISID_8669
Scenario: CVSM Log Files 10 Files Request Previous
	Given user is on CVSM Log Files page with 10 logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

@TestCaseID_8958 @UISID_8678 @UISID_8669
Scenario: CVSM Log Files 24 Files Next1
	Given user is on CVSM Log Files page with 24 logs
	And Log files are sorted by decreasing date
	And newest 10 logs are displayed
	When user clicks Next page button
	Then user will see next 10 logs
	And Displaying 11 to 20 of 24 results label is displayed
	And page 2 of 3 label is displayed
	When user clicks Next page button
	Then user will see next 4 older logs 
	And Displaying 21 to 24 of 24 results label is displayed
	And page 3 of 3 label is displayed

@TestCaseID_8961 @UISID_8678
Scenario: CVSM Log Files Sort Decreasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And decreasing date sorting indicator is displayed

@TestCaseID_8962 @UISID_8678
Scenario: CVSM Log Files Sort Increasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And increasing date sorting indicator is displayed