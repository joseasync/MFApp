*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${SERVER}       localhost:44384
${BROWSER}       googlechrome
${ADD_STUDENT_FORM_URL}        https://${SERVER}/student/form

*** Keywords ***
User is in Crate form page
    Open Browser        ${ADD_STUDENT_FORM_URL}         ${BROWSER}
    Maximize Browser Window
    Create Form should be ready

Create Form should be ready
    Element Should Contain      tag:h1     Student

User fill the field "${field_name}" with "${field_value}"
    input text      ${field_name}       ${field_value}

User click in Save
    Click Button        Save

App should redirect to list page
    ${message} =    Handle Alert
    Should Be Equal    ${message}    Success!
    [Teardown]      Close Browser

App should stay in create page and show an error
    ${message} =    Handle Alert
    Should Be Equal    ${message}    Error saving data.
    [Teardown]      Close Browser
