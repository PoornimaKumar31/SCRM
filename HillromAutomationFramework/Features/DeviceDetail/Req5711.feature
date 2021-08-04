﻿@SoftwareRequirementID_5711
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

@TestCaseID_8981 @UISID_8678
Scenario: RV700 Log Files 10 Files Request Next
	Given user is on RV700 Log Files page with 10 logs
	When user clicks Request Logs button
	Then Received, Pending or Executing message is displayed
	And user can navigate to next logs page

@TestCaseID_8982 @UISID_8678
Scenario: RV700 Log Files 10 Files Request Previous
	Given user is on RV700 Log Files page with 10 logs
	And Received, Pending or Executing message is displayed
	When user navigates to next logs page
	And user navigates to previous logs page
	Then Received, Pending or Executing message is displayed

@TestCaseID_8983 @UISID_8678 @UISID_8669
Scenario: RV700 Log Files 24 Files All Pages
	Given user is on RV700 Log Files page with 24 logs
	And logs are sorted by decreasing date
	Then 10 newest logs are displayed
	And "Page 1" pagination label is displayed
	When user clicks Next page button
	Then next 10 older logs are displayed
	And "Page 2" pagination label is displayed
	When user clicks Next page button
	Then next 4 older logs are displayed
	And "Page 3" pagination label is displayed

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