GreenFinch-CodingTest Assignment
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
Sql Server 
Entity Framework 6.1
StructureMap for web api
Angular Js 1.5+ ( for UI project)
Typescript 2.1 ( for UI project)
Automapper (latest)
Moq (for testing)


Database script and test data
-----------------------------
--following entity framework code first approach
--database gets created on first execution of the application
--required data get inserted automatically.
-- also automatic migration script is available 
-- you can update your local db with the statement update-database


Execute the source code in the visual studio 2015
-------------------------------------------------

Open the solution SlnGreenFinch.CodingTest.sln from the SourceCode folder.
If you get a warning for tfs collection select no option to disconnect from the TFS.
The studio will install the missing packages automatically on build (if any package is missing)
If the project builds successfully.
Run the project check on which port the web api project run
Accordingly update BaseWebApiUrl() variable for the web api url at the path SourceCode\1.UI\CodingTest.MVC.Angular.UI\MiniSpas\Common\AppConstants.ts 


Deliverables 
--------------
1. Working source code
2. Software design document
3. UnitTesting Implementation Document
4. Video Demo  of the working application



Pending work and comments on the completed work
-----------------------------------------------

-- Angularjs test cases using jasmine are not done (due to time limitation)
-- GUI design is average but i can do better work.
-- Microsoft Unit test cases are written only to show cases the approach.
-- Added more functionalities-
	- My newsletters
        - search newsletters
        - choose newsletters
        - login in 



Authors
-------

Makrand Vichare
Full stack developer (asp.net mvc, angularjs, web api,android)
Makv1975@hotmail.com

