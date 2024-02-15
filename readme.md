# ServedByHeader

IIS module that adds a ServedBy response header to identify the node that served the request.

## Features
- No code changes required.

## Getting Started

Add a environment variable named "NodeName" and give it an appropriate value.  
*Note: Use the command prompt to do this so you don't need to reboot the server, eg:*  

    SET NodeName=node1 

Add the ServedByHeader.dll file to the bin directory of your ASP.NET web application or web service. 
Add config (see below). 

Test. 

Smile. 

## Add Config

Register the module with IIS via your web.config file:

    <!-- Required -->
    <system.webServer>
        <modules>
            <add name="ServedByHeader" type="COGWare.ServedByHeader" />            
        </modules>        
    </system.webServer>

## Logging

Exceptions are handled gracefully and logged to the Windows Event Log.


## Feedback

I welcome comments, suggestions, feature requests and honest criticism :)  

 
- [Github Repo](https://github.com/thurstonford?tab=repositories)  
- Email: lance@cogware.co.za