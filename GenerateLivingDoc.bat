REM This command will install the LivingDoc Tool
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

REM This command will update the tool
dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

REM Command to generate the report
livingdoc test-assembly %CD%\HillromAutomationFramework\bin\Debug\netcoreapp3.1\HillromAutomationFramework.dll -t %CD%\HillromAutomationFramework\bin\Debug\netcoreapp3.1\TestExecution.json --output %CD%\HillromAutomationFramework\bin\Debug\netcoreapp3.1\TestResults\LivingDocReport.html

REM Opening the livingdoc
start "" "./HillromAutomationFramework/bin/Debug/netcoreapp3.1/TestResults/LivingDocReport.html"

pause

