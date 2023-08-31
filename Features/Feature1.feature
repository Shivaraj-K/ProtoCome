Feature: Ecomm Aplication

@Tag
Scenario: User Buying Products
	Given The user on Ecom login page
	When The user login with valid Credential
	And Select products and Add to cart 
	| products   |
	| iphone X  |
	| Nokia   |
	Then Order successfully done
