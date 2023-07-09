Feature: SpecFlowFeature1
	In order to give test
	I want to develop a sampple framework
	And implement BDD test scenrios

@mytest


	Scenario: Scenrio 1: Open the URL and verify 	 
	Given the user enters the URL in Chrome browser 
	Then verifies the URL of the opened pge
	
	Scenario: Scenrio 2: Change the language and region and verify 	 
	Given the user enters the URL in Chrome browser 
	Then verifies the URL of the opened pge
	And changes the language and region
	And verifies the changed language and region

	Scenario: Scenrio 3: Foreign exchange solutions page and verify 	 
	Given the user enters the URL in Chrome browser 
	Then Clicks on the Find out more button for Foreign exchange solutions
	And verifies the page where it has taken the user
	
	Scenario: Scenrio 4: International Payments search and verify 	 
	Given the user enters the URL in Chrome browser 
	Then search International Payments in the search box
	And verifies the page has taken the user to results page