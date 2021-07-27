﻿@SoftwareRequirementID_5687
Feature: Software Requirement 5687
	The Customer Portal shall have a feature for filtering which devices are displayed to the logged in user.

@TestCaseID_9100 @UISID_8666
Scenario: Asset Type All Assets
	Given user is on Assets List page with more than one "device"
	And Asset type is All assets
	Then all organization devices are displayed

@TestCaseID_9101 @UISID_8666
Scenario: Asset Type CSM
	Given user is on Assets List page with more than one "CSM"
	When user selects "CSM" from Asset type dropdown
	Then all organization "CSM" devices are displayed

@TestCaseID_9102 @UISID_8666
Scenario: Asset Type CVSM
	Given user is on Assets List page with more than one "CVSM"
	When user selects "CVSM" from Asset type dropdown
	Then all organization "CVSM" devices are displayed

@TestCaseID_9103 @UISID_8666
Scenario: Asset Type RV700
	Given user is on Assets List page with more than one "RV700"
	When user selects "RV700" from Asset type dropdown
	Then all organization "RV700" devices are displayed