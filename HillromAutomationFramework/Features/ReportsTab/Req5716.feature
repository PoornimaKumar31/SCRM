@SoftwareRequirementID_5716
Feature: Software Requirement 5716
	Simple calculator for adding two numbers

Scenario: Reports Page CVSM Usage
	Given user is on Reports page
	And Asset type is CVSM
	When user selects Usage from Report type dropdown menu
	And clicks Get report button
	Then CVSM Asset Usage Report page is displayed

Scenario: Reports Page CVSM Usage Elements
	Given user is on CVSM Asset Usage Report page
	Then Number of devices on each floor title is displayed
	And pie chart with Location ID is displayed
	And Total usage details - Components table is displayed
	And Model column header is displayed
	And Asset tag column header is displayed
	And Serial number column header is displayed
	And Battery cycle count column header is displayed
	And SureTemp thermometer cycle count column header is displayed
	And NIBP sensor cycle count column header is displayed
	And SpHb cycle count column header is displayed
	When user clicks Location ID row in the table
	Then user is able to toggle between the expanded and collapsed state
	When table is expanded
	Then all assets within that location ID are displayed
	When user hovers over the pie chart
	Then Location ID is displayed