Feature: Tax Calculator

Scenario: Calculate Net salary value
	Given the salary field is populated with 100000
	When taxes are calculated
	Then the Tax number result should be 28.1%

	
#Scenario Outline: Calculate Net salary value
#	Given the salary field is populated with <salary>
#	Given the pay per period is <frequency>
#	When taxes are calculated
#	Then the Net pay result should be <net>

#	Examples: Net values
#	| salary| frequency | net |
#	| 10000 | Month		| 2000|
#	| 500	| Day		| 300 |