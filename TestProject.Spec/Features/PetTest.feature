Feature: PetTest

Background:
  Given I have a created the following pet:
    | id     | name           | status |
    | 123456 | Mister Pickles | asleep |

@PetTest
Scenario: Check pet name
  Then pet name is 'Mister Pickles' for pet '123456'

@PetTest
Scenario: Update pet name
  When I change the pet name to 'Not Mister Pickles' for pet '123456'
  Then pet name is 'Not Mister Pickles' for pet '123456'