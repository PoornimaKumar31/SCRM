@SoftwareRequirementID_5699
Feature: Downloading CSM Log File

@mytag
Scenario: CSM Log Files Display
	Given user has selected CSM device
	And user is on Main page
	When user clicks Logs tab
	Then logs for CSM device are displayed

Scenario: CSM Log Files Download
	Given user is on CSM Log Files page
	And at least one log is present
	When user clicks log
	Then log is downloaded to computer
	And downloaded filename matches 

Scenario: CSM Log Files Ten Files
	Given user is on CSM Log Files page
	And CSM has ten logs
	Then ten logs for CSM device are displayed
	And user cannot navigate to next logs page

Scenario: CSM Log Files Ten Files Request Next 
	Given user is on CSM Log Files page
	And CSM has ten logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

Scenario: CSM Log Files Ten Files Request Previous
	Given user is on CSM Log Files page
	And CSM has ten logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

Scenario: CSM Log Files 25 Files Next1
	Given user is on CSM Log Files page
	And Log files are sorted by decreasing date
	And CSM has 25 logs
	And newest ten logs are displayed
	When user clicks Next page button
	Then user will see next ten older logs
	And user will see logs page 2 indicator

Scenario: CSM Log Files 25 Files Next2 
	Given user is on CSM Log Files page
	And logs are sorted by decreasing date
	And CSM has 25 logs
	And second ten logs are displayed
	When user clicks Next page button
	Then user will see next five older logs
	And user will see logs page 3 indicator

Scenario: CSM Log Files Sort Decreasing Date
	Given user is on CSM Log Files page
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And user will see decreasing date sorting indicator

Scenario: CSM Log Files Sort Increasing Date
	Given user is on CSM Log Files page
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And user will see increasing date sorting indicator

Scenario: CSM Log Files Request
	Given user is on CSM Log Files page
	And Pending or Executing message is not displayed
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And Request Logs button is disabled

