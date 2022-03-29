@Login
Feature: Login
	User can log in the website

Scenario: User can log in with valid credentials
	Given a logged out user
	When the user attempts to log in with valid credentials
	Then they log in successfully

Scenario: User cannot log in with invalid credentials
	Given a logged out user
	When the user attempts to log in with invalid credentials
	Then the user is not logged in
	And they see an error message
