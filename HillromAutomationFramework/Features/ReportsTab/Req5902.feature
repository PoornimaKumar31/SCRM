@SoftwareRequirementID_5902
Feature: Software Requirement 5902
	 The customer portal shall provide user ability to search text from CSM CFG Update Status report table.

@TestCaseID_9657 @UISID_8688
Scenario: CSM CFG Update Serial Number Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_9658 @UISID_8688
Scenario: CSM CFG Update Configuration Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user enters "configuration" in Search textbox
	And presses Enter
	Then device with matching "configuration" is displayed

@TestCaseID_9659 @UISID_8688
Scenario: CSM CFG Update Location Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user enters "location" in Search textbox
	And presses Enter
	Then device with matching "location" is displayed

@TestCaseID_9660 @UISID_8688
Scenario: CSM CFG Update Status Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user enters "status" in Search textbox
	And presses Enter
	Then device with matching "status" is displayed

@TestCaseID_9661 @UISID_8688
Scenario: CSM CFG Update Status Last deployed Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user enters "last deployed" in Search textbox
	And presses Enter
	Then device with matching "last deployed" is displayed

