# Intro to API's .NET, and Status Codesl HTTP Request Methods

What does API stand for?

## Application Program Interface

** API allows different applications to communicate with each other **

** Front end -> API -> Data -> API -> Front end **

## .NET is Microsoft's Development Platform

** Dotnet let's us create application from console projects to web API to frontend websites **

## What is an endpoint? / Route

An endpoint is a specified location where we send our requests to (ex: localhost5000/user/api/login)

## What is a controller?

Controllers hold our endpoints and allows applications to send requests to them

** Request -> Controller -> C# logic -> request / response is sent back **

## CRUD - Create, Read, Update, & Delete

### Read Method [HttpGet]

Retrieves data from our API / Database

### Create Method [HttpPost]

Used to *Create new data* (ex creating a new account)

### Update Method [HttpPut]

Used to *Update existing data*

### Delete Method [HttpDelete]

Used to *Delete existing data*

//------------------------------------------------------------//

## Status Codes

## 200 Status Code 
Means your request is good - Success
(Ok)

## 201 Status Code
This means creation was successful
(Used for CreateAtAction)

## 204 Status Code
Simply states the request was successful with nothing to return
(NoContent)

## 400 Status Code 
Means a bad request, something was wrong with the request
(BadRequest)

## 404 Status Code
Not Found means whatever use expected was there was NOT there
(NotFound)



//------------------------------------------------------------//

## Day Three of Lecture (Day 12): Services, Interfaces & Dependency Injection

# Controller is our Waiter - Takes orders (request methiods)

# Interface is our Menu - tells us what our kitchen has

# Services is our Kitchen - makes the food (implements our logic)

# Dependency Injection is our Manager - everything runs smoothly (connects everything)


### Services

This layer of our application is where our logic resides (we access our database from this layer only)

### Interfaces

This is a contract or a list of promises that our Services MUST implement (there is NO logic here)

### Dependency Injection

We inject our Services into the controller using our constructor
We must add our Services and Interface to our Program.cs
when we implement our Interface, it will pass on the rseponsibility to our services



