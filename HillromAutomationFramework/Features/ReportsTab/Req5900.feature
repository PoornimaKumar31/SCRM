@SoftwareRequirementID_5900
Feature: Software Requirement 5900
    The customer portal shall provide user ability to search text from CSM Activity report table

@TestCaseID_ @UISID_8693
Scenario: Search box content
	Given user is on CSM ACTIVITY REPORT page
	Then Search Textbox displays "Search by Serial No. etc"

@TestCaseID_ @UISID_8693
Scenario: CSM Activity Serial Number Search
	Given user is on CSM ACTIVITY REPORT page
	When user type "Serial number" in search textbox
	And press enter
	Then device with the matching "serial number" is displayed

@TestCaseID_ @UISID_8693
Scenario: CSM Activity Location Search
	Given user is on CSM ACTIVITY REPORT page
	When user type "location" in search textbox
	And press enter
	Then device with the matching "location" is displayed

@TestCaseID_ @UISID_8693
Scenario: CSM Activity Last Vital Sent Search
	Given user is on CSM ACTIVITY REPORT page
	When user type "Last Vital Sent" in search textbox
	And press enter
	Then device with the matching "last vital sent" is displayed