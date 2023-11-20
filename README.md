# PetStore

Console App that calls APIs describe at https://petstore.swagger.io/

## Table of Contents

- [Requirements](#requirements)
- [Further Steps](#further-steps)
- [ChatGPT Transcript](#chatgpt-transcript)

## Requirements

- Analyse APIs and Swagger documentation at https://petstore.swagger.io/
- Develop a console application to execute the required PetStore API(s) and return available Pets from the Pet Store
- Print a list of available Pets to the console sorted in Categories and displayed in reverse order by Name

## Further Steps

- Dependency Injection - Need to implement DI for better separation of concerns and easier testing (new the console project for .NET CORE 6 doesn't have the startup.cs. I tried searching forthe new approach but I was taking a bit of time to findout so leaving it for now)
- Logging - no logging is currently implemented. E.g. Serilog
- Error handling could be improved.
- Configuration - implemented for the base url for now. It could be expanded
- Args - currently the app is not expecting any arguments. It would be needed if this application is expanded to handle more queries.
- Security - need to be added if there is any requirement
- revisit the models - there are warnings in the model classes about nullables. need to review the API's swagger make sure the right types are specified in the classes.

## ChatGPT Transcript
[ChatGPT - PetStore ](https://chat.openai.com/share/14ef733f-0060-48d5-bdef-949bbd52cad7)
