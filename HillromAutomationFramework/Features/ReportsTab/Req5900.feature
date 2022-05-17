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

@TestCaseID_10916 @UISID_8693
Scenario: CVSM Activity Search
	Given user is on CVSM Activity Report page
	Then Search Textbox displays "Search by Serial No. etc"

@TestCaseID_10927 @UISID_8693
Scenario: CVSM Activity Serial Number Search
	Given user is on CVSM Activity Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_10919 @UISID_8693
Scenario: CVSM Activity Location Search
	Given user is on CVSM Activity Report page
	When user enters "ownership unit" in Search textbox
	And presses Enter
	Then device with matching "ownership unit" is displayed

@TestCaseID_10920 @UISID_8693
Scenario: Centrella Activity Search
	Given user is on Centrella Activity Report page
    Then Search Textbox displays "Search by Serial No. etc"

@TestCaseID_10921 @UISID_8693
Scenario: Centrella Activity Serial Number Search
	Given user is on Centrella Activity Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_10923 @UISID_8693
Scenario: Progressa Activity Search
	Given user is on Progressa Activity Report page
    Then Search Textbox displays "Search by Serial No. etc"

@TestCaseID_10924 @UISID_8693
Scenario: Progressa Activity Serial Number Search
	Given user is on Progressa Activity Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed