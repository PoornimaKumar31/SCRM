@SoftwareRequirementID_5691
Feature: Software Requirement 5691  
The Customer Portal shall have a feature for displaying a list of CVSM log files

@TestCaseID_8952
Scenario: CVSM Log Files
	Given user has selected CVSM device
	And user is on device details page
	When user clicks Logs tab
	Then logs for CVSM device are displayed

@TestCaseID_8954
Scenario: CVSM Log Files Empty
	Given user is on CVSM Log Files page with 0 logs
	Then no logs for CVSM device are displayed

@TestCaseID_8955
Scenario: CVSM Log Files Ten Files
	Given user is on CVSM Log Files page with 10 logs
	Then 10 logs for CVSM device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8956
Scenario: CVSM Log Files Ten Files Request Next
	Given user is on CVSM Log Files page with 10 logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8957
Scenario: CVSM Log Files Ten Files Request Previous
	Given user is on CVSM Log Files page with 10 logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

@TestCaseID_8958
Scenario: CVSM Log Files 24 Files Next1
	Given user is on CVSM Log Files page with 24 logs
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

@TestCaseID_8960
Scenario: CVSM Log Files 24 Files Next2 
	Given user is on CVSM Log Files page with 24 logs
	And logs are sorted by decreasing date
	And second ten logs are displayed
	When user clicks Next page button
	Then user will see next five older logs
	And user will see logs page 3 indicator

@TestCaseID_8961
Scenario: CVSM Log Files Sort Decreasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And user will see decreasing date sorting indicator

@TestCaseID_8962
Scenario: CVSM Log Files Sort Increasing Date
	Given user is on CVSM Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And user will see increasing date sorting indicator