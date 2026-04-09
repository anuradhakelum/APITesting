Feature: Configuration File

Simple test to show how to read config files

Scenario: Read confg file
	Then the hostname is "localhost"
	
Scenario: Get objects
	When the user hit the access point
	Then the response code is 200