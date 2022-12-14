@SoftwareRequirementID_5905
Feature: Software Requirement 5905
	 The customer portal shall provide user ability to search partial text from Firmware Status report table.

@TestCaseID_10022 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Search
	Given user is on Centrella Firmware Upgrade Status Report page
	Then Search textbox displays "Search by firmware, serial no. etc"

@TestCaseID_10023 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Serial Number Search
	Given user is on Centrella Firmware Upgrade Status Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_10024 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Firmware Version Search
	Given user is on Centrella Firmware Upgrade Status Report page
	When user enters "firmware version" in Search textbox
	And presses Enter
	Then devices with matching "firmware version" are displayed

@TestCaseID_10025 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Status Search
	Given user is on Centrella Firmware Upgrade Status Report page
	When user enters "status" in Search textbox
	And presses Enter
	Then devices with matching "status" are displayed

@TestCaseID_10026 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Ownership Search
	Given user is on Centrella Firmware Upgrade Status Report page
	When user enters "ownership" in Search textbox
	And presses Enter
	Then devices with matching "ownership" are displayed

@TestCaseID_10027 @UISID_8685 @UISID_8692
Scenario: Centrella Firmware Status Last Deployed Search
	Given user is on Centrella Firmware Upgrade Status Report page
	When user enters "last deployed" in Search textbox
	And presses Enter
	Then devices with matching "last deployed" are displayed

@TestCaseID_10028 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Search
	Given user is on CSM Firmware Upgrade Status Report page
	Then Search textbox displays "Search by firmware, serial no. etc"

@TestCaseID_10029 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Serial Number Search
	Given user is on CSM Firmware Upgrade Status Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_10030 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Firmware Version Search
	Given user is on CSM Firmware Upgrade Status Report page
	When user enters "firmware version" in Search textbox
	And presses Enter
	Then devices with matching "firmware version" are displayed

@TestCaseID_10031 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Status Search
	Given user is on CSM Firmware Upgrade Status Report page
	When user enters "status" in Search textbox
	And presses Enter
	Then devices with matching "status" are displayed

@TestCaseID_10032 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Ownership Search
	Given user is on CSM Firmware Upgrade Status Report page
	When user enters "ownership" in Search textbox
	And presses Enter
	Then devices with matching "ownership" are displayed

@TestCaseID_10033 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Status Last Deployed Search
	Given user is on CSM Firmware Upgrade Status Report page
	When user enters "last deployed" in Search textbox
	And presses Enter
	Then devices with matching "last deployed" are displayed

@TestCaseID_10909 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Search
	Given user is on Progressa Firmware Upgrade Status Report page
	Then Search textbox displays "Search by firmware, serial no. etc"

@TestCaseID_10910 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Serial Number Search
	Given user is on Progressa Firmware Upgrade Status Report page
	When user enters "serial number" in Search textbox
	And presses Enter
	Then device with matching "serial number" is displayed

@TestCaseID_10911 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Firmware Version Search
	Given user is on Progressa Firmware Upgrade Status Report page
	When user enters "firmware version" in Search textbox
	And presses Enter
	Then devices with matching "firmware version" are displayed

@TestCaseID_10912 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Status Search
	Given user is on Progressa Firmware Upgrade Status Report page
	When user enters "status" in Search textbox
	And presses Enter
	Then devices with matching "status" are displayed

@TestCaseID_10913 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Ownership Search
	Given user is on Progressa Firmware Upgrade Status Report page
	When user enters "ownership" in Search textbox
	And presses Enter
	Then devices with matching "ownership" are displayed

@TestCaseID_10914 @UISID_8685 @UISID_8692
Scenario: Progressa Firmware Status Last Deployed Search
	Given user is on Progressa Firmware Upgrade Status Report page
	When user enters "last deployed" in Search textbox
	And presses Enter
	Then devices with matching "last deployed" are displayed
