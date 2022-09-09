# Specflow Bdd UI Test Automation Framework
RestSharp Api & Selenium Automation Test With Gherkin Syntax

# Test Approach
The tests were created as automation testing, on every test run some checks and validation are done with certain and random inputs to verify that data is displayed, clicked and edited correctly. Also tests are supported negative validation (Negative Tests).


# Project Solution
The Features folder contains our tests. Encoded with the Gherkin syntax. Background steps work before the test and ensure that the test becomes executable. The Hooks directory allows the driver to be started, closed and necessary settings before and after the tests are run. Driver's directory is the area where required global functions are written. The steps directory contains the descriptions of the steps written in the features files. The PageObject directory contains the objects in the pages and the methods that will operate on these objects. With the xunit.runner.json folder we can parallelize our tests and specify the number of browsers. Also browser switching with DefaultSettings.cs. Necessary browser selections can be made for the crossbrowser testing.


This type of solution was used for better code reusability, maintainability of the automation testing framework.


# Framework / Libraries / Tech Stack 

* C#
* NET6.0
* RestSharp For Api Call
* XUnit
* FluentAssertions
* Selenium Web Driver
* EPPlus Excel Data Read
* Specflow Living Docs For Reporting
* SqlClient For Access Db

This project is developed using C# with .NET6.0 with XUnit as the automation & api testing framework.



# Scenarios covered on the solution

**The following scenarios are cover by the automation test suite:**

* **Verify users can logIn / logOut(Login.feature).**

* **Verify different type of users can/'t logIn / (Login.feature).**

* **(Negative) Verify users can't be loged in with wrong password(Login.feature).**

* **Verify pages can be visible by users(Smokes.feature).**

* **Verify adding a product into the basket(Product.feature).**

* **Verify adding more than a product into the basket(Product.feature).**

* **(Negative) Verify non-users can not be get from api(Product.feature).**

* **Verify product can be to basket(E2E.feature).**

* **Verify product can't be added after app reset(E2E.feature).**

* **Verify product can be deleted from basket(E2E.feature).**

* **Verify product which is in basket can be ordered(E2E.feature).**

* **Verify product filter selections is worked(E2E.feature).**



# Running Test Suites


```java

dotnet test

dotnet test --logger "trx;LogFileName=./Report/mytests.trx" -xml /Report/mytests.xml

```

How to generate report ?

```java

livingdoc test-assembly "$TestAssemblyPath" --binding-assemblies "$TestAssemblyPath" --output-type HTML --output "$LivingDocDir\PLAppLivingDoc.html"

```

