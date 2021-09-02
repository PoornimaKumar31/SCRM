@SoftwareRequirementID_5688
Feature: Software Requirement 5688
    The Customer Portal shall have a feature for displaying the devices within a selected hierarchal grouping.

@TestCaseID_9143 @UISID_8666
Scenario: Assets List Default View
    Given user without roll-up for multiple organizations is on Assets page
    Then all organizations is the default Organization filter

@TestCaseID_9144 @UISID_8666
Scenario: Assets List Filter by Organization
    Given user without roll-up for multiple organizations is on Assets page
    When user selects organization from Organization dropdown
    Then only devices in selected organization are displayed

@TestCaseID_9145 @UISID_8666
Scenario: Assets List Filter by Facility
    Given user without roll-up for multiple facilities is on Assets page
    When user selects facility from Organization dropdown
    Then only devices in selected facility are displayed

@TestCaseID_9146 @UISID_8666
Scenario: Assets List Filter by Unit
    Given user without roll-up for multiple units is on Assets page
    When user selects unit from Organization dropdown
    Then only devices in selected unit are displayed

@TestCaseID_9147 @UISID_8666
Scenario: Assets List Filter by All Organizations
    Given user without roll-up for multiple organizations is on Assets page
    When user selects All locations from Organization dropdown
    Then all devices belonging to all user organizations are displayed