@Software_Requirement_ID_5685
Feature: DownloadSoftwareAndPDF
	The Customer Portal shall allow user to download the Partner Connect, Service Monitor, DCP application, Administrator's guide, User Guide and Release Notes


@TestCaseID_6267
Scenario: download PartnerConnect software
    Given user is in login page
    When user click on PartnerConnect™
    Then PartnerConnect zip file is downloaded

@TestCaseID_6287
Scenario: download Service Monitor software
    Given user is in login page
    When user click on Service Monitor
    Then Service Monitor zip file is downloaded

@TestCaseID_6288
Scenario: download DCP software
    Given user is in login page
    When user click on DCP
    Then DCP zip file is downloaded
 
 @TestCaseID_6289
 Scenario: download access Administrator's Guide documentation
    Given user is in login page
    When user click on Administrator's Guide
    Then redirect to Administrator's Guide PDF page

@TestCaseID_6290 
Scenario: download access Instructions for Use
    Given user is in login page
    When user click on Instructions for Use
    Then redirect to Instructions for Use PDF page

@TestCaseID_6608
Scenario: download access Release Notes
    Given user is in login page
    When user click on Release Notes
    Then redirect to Release Notes PDF page