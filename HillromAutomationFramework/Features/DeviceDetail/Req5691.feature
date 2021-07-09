@SoftwareRequirementID_5691
Feature:  The Customer Portal shall have a feature for displaying a list of CVSM log files

@TestCaseID_8954
Scenario: CVSM Log Files Empty
	Given user is on CVSM Log Files page
	And CVSM has no logs
	Then no logs for CVSM device are displayed

@TestCaseID_8955
Scenario: CVSM Log Files Ten Files
	Given user is on CVSM Log Files page
	And CVSM has 10 logs
	Then ten logs for CVSM device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8956
Scenario: CVSM Log Files Ten Files Request Next
	Given user is on CVSM Log Files page
	And CVSM has 10 logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8957
Scenario: CVSM Log Files Ten Files Request Previous
	Given user is on CVSM Log Files page
	And CVSM has 10 logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

@TestCaseID_8958
Scenario: CVSM Log Files 25 Files Next1
	Given user is on CVSM Log Files page
	And Log files are sorted by decreasing date
	And CVSM has 25 logs
	And newest ten logs are displayed
	When user clicks Next page button
	Then user will see next ten older logs
	And user will see logs page 2 indicator

@TestCaseID_8960
Scenario: CVSM Log Files 25 Files Next2
	Given user is on CVSM Log Files page
	And logs are sorted by decreasing date
	And CVSM has 25 logs
	And second ten logs are displayed
	When user clicks Next page button
	Then user will see next five older logs
	And user will see logs page 3 indicator

@TestCaseID_8961
Scenario: CVSM Log Files Sort Decreasing Date
	Given user is on CVSM Log Files page
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And user will see decreasing date sorting indicator

@TestCaseID_8962
Scenario: CVSM Log Files Sort Increasing Date
	Given user is on CVSM Log Files page
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And user will see increasing date sorting indicator