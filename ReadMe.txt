CrossOver-Test Assignment
-------------------------

It is a web base application which allows users to subscribe to newsletters  and browse available newsletters.


Getting Started
---------------


These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.


Prerequisites
-------------


Install the following software/tools:


Visual Studio 2015
Asp.net MVC 5
Net Framework 4.6+
Mongo DB server 3.2
MongoDbCSharp Driver (latest)
StructureMap for web api
Angular Js 1.5+ (not 2.0) ( for UI project)
Typescript 2.1 ( for UI project)
Automapper (latest)
MongoChef Core (free) Mongo Tool
Moq (for testing)


Configure Mongodb Server
-----------------------




Import required project’s data
------------------------------




Execute the source code in the visual studio 2015
-------------------------------------------------


Exact the folder MakrandVichare_SoftwareEngineer_DotNet.zip
Open the solution SlnCrossOverAssignment from the SourceCode folder.
If you get a warning for tfs collection select no option to disconnect from the TFS.
The studio will install the missing packages automatically on build (if any package is missing)
If the project builds successfully.
Run the project check on which port the web api project run
Accordingly update BaseWebApiUrl() variable for the web api url at the path 1.UI\CrossOver.MVC.Angular.UI\MiniSpas\Common\AppConstants.ts 


Assumptions
-----------

Missing or Not clear requirement :- 

What are actions users(students) can take while maintaining the demanded books (assumed only can view the request history).
Roles to update the request is missing (e.g. librarian who can approve the or reject request)
Missing Books stock info so assumed unlimited books request.
No limit of how many books can be demanded  
If the book is already demanded, the book is not allowed to demand again.


Authors
-------

Makrand Vichare
Full stack developer (asp.net mvc, angularjs, web api,android)
Makv1975@hotmail.com

