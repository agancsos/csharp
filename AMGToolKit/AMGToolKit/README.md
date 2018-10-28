# README
## About
* Name     : AMGToolKit
* Author   : Abel Gancsos
* Version  : v. 1.0.0

## Synopsis
This program is essentially a collection of useful scripts used for troubleshooting as well as for testing.

## Assumptions
* There is a set of scripts that should be kept in a central location.
* There is a need for these scripts.
* These scripts will be used on Windows systems.
* These scripts might also be used on non-Windows systems.
* The systems will have the .Net Framework installed prior to using the toolkit.
* The scripts can be ran on any system (no dependencies).
​
## Implementation Description
This program supports the following Windows commands/programs.  This program also supports arguments in the form of a dictionary, which can be supplied with the key/value pair in the form of -<key> <value> on the command-line.  At a very high level, this program reads in the name of the command that would normally be ran then creates a concrete instance of the AMGTool class using a Factory Method design pattern. This AMGTool abstract class is simply a Task or Command class that has an Invoke method to perform the actual operations and a GetName as a florish. Each operation, which was previously in a separate script form, has been simplified and refactored in this C# toolkit for scalability and for mantainability.

### Supported Operating Systems
* Windows 10
* Windows 7
* Server 2012
* Server 2012 R2
* Server 2016
* Server 2019
* Ubuntu 16.0

___________________________________________________________________________________________________________________________________________
| Name                             | Description                                                         | Arguments                      |
-------------------------------------------------------------------------------------------------------------------------------------------
| Gacutil                          | Used to GAC an assembly without Visual Studio                       | (-u|-i) <path_to_assembly>     |
| DBProviders                      | Used to list drivers available in DBPoviders                        | -key <name>                    |
| Timezones                        | List the timezones known on the current system                      | -key <name>                    |
| GetDST                           | Gets the DST based on a provided date                               | -m <numeric_month> -d <day>    |
| MSIExtractor                     | Read the contents from an MSI database                              | -path <full_msi_path> -property|
| UninstallOracle                  | Fully uninstall an Oracle database instance                         | -base <oracle_base_path>       |
___________________________________________________________________________________________________________________________________________

## Flags
* -tool    : Name of the tool from the above list
* -version : Display the version information for this program
* -list    : List the available tools

## Prerequisites
* .Net Framework 4.6.1 or above
* .Net Framework development envrionment
​
## Build
### Windows
1. Import the project solution
2. Build the solution with F5 or buildenv

### Non-Windows
1. Install and configure .Net Framework build environment https://www.microsoft.com/net/download
2. Copy the project solution
3. Build the solution with buildenv
​