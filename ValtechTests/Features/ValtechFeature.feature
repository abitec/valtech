
@Valtech
Feature: ValtechFeature
	In order to find information about Valtech
	As a potential customer
	I would like to navigate around Valtech website

Scenario: Find latest news section
	Given Customer is on Valtech website
	Then Customer can see latest news section 

Scenario: Navigate to pages
	Given Customer is on Valtech website
	When  Navigates to about services and work 
	Then Customer should be on About, Services, Work page

Scenario: Verify the total number of offices
	Given Customer is on Valtech website
	When  Navigates to contact section to count the number of offices
	Then Number of offices should be 36