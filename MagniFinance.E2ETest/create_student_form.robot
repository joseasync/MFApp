*** Settings ***
Resource    resource.robot

*** Test Cases ***
Scenario 1
    Given User is in Crate form page
    When User fill the field "name" with "Jose"
    And User fill the field "registrationnumber" with "123"
    And User fill the field "birthday" with "10/10/1992"
    And User click in Save
    Then App should redirect to list page

Scenario 2
    Given User is in Crate form page
    When User fill the field "name" with "Tessst"
    And User fill the field "registrationnumber" with "12222"
    And User fill the field "birthday" with "10/10/1992"
    And User click in Save
    Then App should redirect to list page

Scenario 3
    Given User is in Crate form page
    When User fill the field "name" with "Joao"
    And User fill the field "registrationnumber" with "11111"
    And User fill the field "birthday" with "10/000/0010"
    And User click in Save
    App should stay in create page and show an error

Scenario 4
    Given User is in Crate form page
    When User fill the field "name" with "Alberto"
    And User fill the field "registrationnumber" with "233333"
    And User fill the field "birthday" with "10/10/1992"
    And User click in Save
    Then App should redirect to list page

Scenario 5
    Given User is in Crate form page
    When User fill the field "name" with "Joao"
    And User fill the field "registrationnumber" with "2342"
    And User fill the field "birthday" with "10/01/001"
    And User click in Save
    App should stay in create page and show an error
