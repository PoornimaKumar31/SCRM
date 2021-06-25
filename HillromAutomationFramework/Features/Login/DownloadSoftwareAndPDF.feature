@SoftwareRequirementID_5685
Feature: DownloadSoftwareAndPDF
	The Customer Portal shall allow user to download the Partner Connect, Service Monitor, DCP application, Administrator's guide, User Guide and Release Notes

@TestCaseID_8917 @UISID_8661
Scenario: Login Download PartnerConnect
    Given user is on Login page
    When user clicks PartnerConnect
    Then PartnerConnect zip file is downloaded


@TestCaseID_8918 @UISID_8661
Scenario: Login Download Service Monitor
    Given user is on Login page
    When user clicks Service Monitor
    Then Service Monitor zip file is downloaded

@TestCaseID_8919 @UISID_8661
Scenario: Login Download DCP
    Given user is on Login page
    When user clicks DCP
    Then DCP zip file is downloaded
 
 @TestCaseID_8920 @UISID_8661
 Scenario: Login Download Administrator Guide
    Given user is on Login page
    When user clicks Administrator Guide
    Then Administrator Guide PDF opens in browser

@TestCaseID_8921 @UISID_8661 
Scenario: Login Download IFU
    Given user is on Login page
    When user clicks Instructions for Use
    Then Instructions for Use PDF opens in browser

@TestCaseID_8922 @UISID_8661
Scenario: Login Download Release Notes
    Given user is on Login page
    When user clicks Release Notes
    Then Release Notes PDF opens in browser
 