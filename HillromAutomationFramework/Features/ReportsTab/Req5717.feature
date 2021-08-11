@SoftwareRequirementID_5717
Feature: Software Requirement 5717
	The Customer Portal shall have a feature for generating following CSM reports:
	Usage Report
	Firmware version report
	Configuration Update report
	Firmware Status report
	Activity report

@TestCaseID_9372 @UISID_8684 @UISID_8686
Scenario: CSM Report Type Dropdown Content
	Given user is on Reports page
	And CSM Asset type is selected
	When user clicks report type dropdown
	Then Report type dropdown displays "Usage, Firmware version, CFG Update Status, Firmware status, Activity"

@TestCaseID_9373 @UISID_8684 @UISID_8686
Scenario: CSM Usage Report Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Usage Report type is selected
	When user clicks Get report button
	Then Asset Usage Report (CSM) label is displayed
	And Print button is displayed
	And Number of Devices on Each Floor label is displayed
	And pie chart with Location ID is displayed
	And Total Usage Details - Components label is displayed

@TestCaseID_9374 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CSM Usage Report Table Elements
	Given user is on CSM Usage Report page
	Then Assets are grouped by unit
	And all the devices within that unit is displayed
	And "Model" column heading is displayed
	And "Asset tag" column heading is displayed
	And "Serial number" column heading is displayed
	And "Battery cycle count" column heading is displayed
	And "SureTemp thermometer cycle count" column heading is displayed
	And "NIBP sensor cycle count" column heading is displayed
	And "SpHb cycle count" column heading is displayed

@TestCaseID_9447 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CSM Usage Report Table Elements Columns
	Given user is on CSM Usage Report page
	Then "Model" label is in column 1
	And "Asset tag" label is in column 2
	And "Serial number" label is in column 3
	And "Battery cycle count" label is in column 4
	And "SureTemp thermometer cycle count" label is in column 5
	And "NIBP sensor cycle count" label is in column 6
	And "SpHb cycle count" label is in column 7

@TestCaseID_9375 @UISID_8684 @UISID_8685 @UISID_8686
Scenario: CSM Usage Report Table Toggle
	Given user is on CSM Usage Report page
	When user clicks unit row
	Then assets for unit are hidden

@TestCaseID_9376 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CSM Firmware Version Report Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Firmware Version Report type is selected
	When user clicks Get report button
	Then Firmware Version Report (CSM) label is displayed
	And Components column heading is displayed
	And Firmware version column heading is displayed
	And Total devices column heading is displayed

@TestCaseID_9377 @UISID_8684 @UISID_8685 @UISID_8687
Scenario: CSM Firmware Version Report Table Toggle
	Given user is on CSM Firmware Version Report page
	When user clicks Total row
	Then rows below Total are hidden
	When user clicks unit row
	Then assets for unit are hidden

@TestCaseID_9378 @UISID_8684 @UISID_8687
Scenario: CSM Firmware Version Report Print
	Given user is on CSM Firmware Version Report page
	When user clicks Print button
	Then browser’s built-in print dialog is displayed

@TestCaseID_9379 @UISID_8684 @UISID_8688
Scenario: CSM Configuration Update Status Report Page Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Configuration Update Status Report type is selected
	When user clicks Get report button
	Then Configuration Update Status Report (CSM) label is displayed
	And Print button is displayed
	And Information button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9380 @UISID_8684 @UISID_8685 @UISID_8688
Scenario: CSM Configuration Update Status Report Table Elements
	Given user is on CSM Configuration Update Status Report page
	Then "Serial number" column heading is displayed
	And "Configuration" column heading is displayed
	And "Location" column heading is displayed
	And "Status" column heading is displayed
	And "Last deployed" column heading is displayed
	And "Last connected" column heading is displayed

@TestCaseID_9448 @UISID_8684 @UISID_8685 @UISID_8688
Scenario: CSM Configuration Update Status Report Table Elements Columns
	Given user is on CSM Configuration Update Status Report page
	Then "Serial number" label is in column 1
	And "Configuration" label is in column 2
	And "Location" label is in column 3
	And "Status" label is in column 4
	And "Last deployed" label is in column 5
	And "Last connected" label is in column 6

@TestCaseID_9383 @UISID_8684 @UISID_8688
Scenario: CSM Configuration Update Status Report Print
	Given user is on CSM Configuration Update Status Report page
	When user clicks Print button
	Then browser’s built-in print dialog is displayed

@TestCaseID_9383 @UISID_8684 @UISID_8692
Scenario: CSM Firmware Upgrade Status Report Page Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Firmware Status Report type is selected
	When user clicks Get report button
	Then Firmware Upgrade Status Report (CSM) label is displayed
	And Print button is displayed
	And Information button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9385 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Upgrade Status Report Page Table Elements
	Given user is on CSM Firmware Upgrade Status Report page
	Then "Serial number" column heading is displayed
	And "Firmware version" column heading is displayed
	And "Location" column heading is displayed
	And "Status" column heading is displayed
	And "Last deployed" column heading is displayed
	And "Last connected" column heading is displayed

@TestCaseID_9449 @UISID_8684 @UISID_8685 @UISID_8692
Scenario: CSM Firmware Upgrade Status Report Page Table Elements Columns
	Given user is on CSM Firmware Upgrade Status Report page
	Then "Serial number" label is in column 1
	And "Firmware version" label is in column 2
	And "Location" label is in column 3
	And "Status" label is in column 4
	And "Last deployed" label is in column 5
	And "Last connected" label is in column 6

@TestCaseID_9388 @UISID_8684 @UISID_8692
Scenario: CSM Firmware Upgrade Status Report Print
	Given user is on CSM Firmware Upgrade Status Report page
	When user clicks Print button
	Then browser’s built-in print dialog is displayed

@TestCaseID_9389 @UISID_8684 @UISID_8693
Scenario: CSM Activity Report Page Elements
	Given user is on Reports page
	And CSM Asset type is selected
	And Activity Report type is selected
	When user clicks Get report button
	Then Activity Report (CSM) label is displayed
	And Print button is displayed
	And Download button is displayed
	And Search box is displayed
	And Previous page icon is displayed
	And Next page icon is displayed
	And Page x of y indicator is displayed
	And Displaying x to y of z results indicator is displayed

@TestCaseID_9390 @UISID_8684 @UISID_8685 @UISID_8693
Scenario: CSM Activity Report Page Table Elements
	Given user is on CSM Activity Report page
	Then "Serial number" column heading is displayed
	And "Location" column heading is displayed
	And "Last vital sent" column heading is displayed

@TestCaseID_9450 @UISID_8684 @UISID_8685 @UISID_8693
Scenario: CSM Activity Report Page Table Elements Columns
	Given user is on CSM Activity Report page
	Then "Serial number" label is in column 1
	And "Location" label is in column 2
	And "Last vital sent" label is in column 3