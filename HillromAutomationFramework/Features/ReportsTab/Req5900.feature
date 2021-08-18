@SoftwareRequirementID_5900
Feature: Software Requirement 5900
    The customer portal shall provide user ability to search text from CSM Activity report table

@TestCaseID_9653 @UISID_8693
Scenario: CSM Activity Search
	Given user is on CSM ACTIVITY REPORT page
	Then Search Textbox displays "Search by Serial No. etc"

@TestCaseID_9654 @UISID_8693
Scenario: CSM Activity Serial Number Search
	Given user is on CSM ACTIVITY REPORT page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_9655 @UISID_8693
Scenario: CSM Activity Location Search
	Given user is on CSM ACTIVITY REPORT page
	When user enters "location" in Search textbox
	And presses Enter
	Then device with matching "location" is displayed
