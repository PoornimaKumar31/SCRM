@SoftwareRequirementID_5902
Feature: Software Requirement 5902
	 The customer portal shall provide user ability to search text from CSM CFG Update Status report table.

@TestCaseID_9657 @UISID_8688
Scenario: CSM CFG Update Serial Number Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user type "Serial number" in search textbox
	And press enter
	Then device with the matching "serial number" is displayed

@TestCaseID_9658 @UISID_8688
Scenario: CSM CFG Update Configuration Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user type "Configuration" in search textbox
	And press enter
	Then device with the matching "Configuration" is displayed

@TestCaseID_9659 @UISID_8688
Scenario: CSM CFG Update Location Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user type "location" in search textbox
	And press enter
	Then device with the matching "location" is displayed

@TestCaseID_9660 @UISID_8688
Scenario: CSM CFG Update Status Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user type "Status" in search textbox
	And press enter
	Then device with the matching "Status" is displayed

@TestCaseID_ @UISID_8688
Scenario: CSM CFG Update Status Last deployed Search
	Given user is on CSM CONFIGURATION UPDATE STATUS page
	When user type "Last deployed" in search textbox
	And press enter
	Then device with the matching "Last deployed" is displayed

