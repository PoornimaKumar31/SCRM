@SoftwareRequirementID_5716
Feature: Software Requirement 5716
	Simple calculator for adding two numbers

Scenario: Reports Page CVSM Usage
	Given user is on Reports page
	And Asset type is CVSM
	When user selects Usage from Report type dropdown menu
	And clicks Get report button
	Then CVSM Asset Usage Report page is displayed