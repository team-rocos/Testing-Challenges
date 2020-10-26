Feature: Unsuccessful sign up

Background: 
	Given I am on sign up page

Scenario: Empty fields shows error
	When I leave all fields empty
	Then I get textboxes error messages

Scenario: Invalid Email format shows error
	When I input an invalid Email
	Then I get an Email error message "Please enter a valid email address."

Scenario: Invalid Account Name format shows error
	When I input an invalid Account Name
	Then I get an Account Name error message "Are you sure you’ve entered your name correctly?"

Scenario: Invalid Password format shows error
	When I input an invalid password format
	Then I get a Password error message "Please choose a stronger password. Use 8 or more characters with a mix of letters, numbers & symbols"

Scenario: Invalid Invitation Code
	When I input all valid customer details but an invalid Invitation Code
	Then I get a banner error message "Invitation Code not valid" 