Feature: DynamicControlsTest

@DynamicControlsTest
@UI
Scenario: Open Dynamic Controls, click enable button and use input
	Given I have opened the Dynamic Control page 
	And I click the enable button
	Then the input box is enabled
	When I set 'random text' in the input box
	Then 'random text' is displayed