﻿@SoftwareRequirementID_5711
Feature: Software Requirement 5711 

The customer portal shall have a mechanism for displaying RV700 log files.

@TestCaseID_8978
Scenario: RV700 Log Files
	Given user has selected RV700 device
	And user is on Main page
	When user clicks Logs tab
	Then logs for RV700 device are displayed

@TestCaseID_8979
Scenario: RV700 Log Files Empty
	Given user is on RV700 Log Files page with 0 logs
	Then no logs for RV700 device are displayed

@TestCaseID_8980
Scenario: RV700 Log Files Ten Files
	Given user is on RV700 Log Files page with 10 logs
	Then ten logs for RV700 device are displayed
	And user cannot navigate to next logs page

@TestCaseID_8981
Scenario: RV700 Log Files Ten Files Request Next
	Given user is on RV700 Log Files page with 10 logs
	When user clicks Request Logs button
	Then Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8982
Scenario: RV700 Log Files Ten Files Request Previous
	Given user is on RV700 Log Files page with 10 logs
	And Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Pending or Executing message is displayed

@TestCaseID_8983
Scenario: RV700 Log Files 25 Files Next1
	Given user is on RV700 Log Files page with 25 logs
	And Log files are sorted by decreasing date
	And newest 10 logs are displayed
	Then user will see logs page 1 indicator
	When user clicks Next page button
	Then user will see next 10 older logs
	And user will see logs page 2 indicator
	When user clicks Next page button
	Then user will see next 5 older logs
	And user will see logs page 3 indicator

@TestCaseID_8985
Scenario: RV700 Log Files Sort Decreasing Date
	Given user is on RV700 Log Files page with 10 logs
	And logs are sorted by increasing date
	When user clicks Date column heading
	Then logs sort by decreasing date
	And user will see decreasing date sorting indicator

@TestCaseID_8986
Scenario: RV700 Log Files Sort Increasing Date
	Given user is on RV700 Log Files page with 10 logs
	And logs are sorted by decreasing date
	When user clicks Date column heading
	Then logs sort by increasing date
	And user will see increasing date sorting indicator