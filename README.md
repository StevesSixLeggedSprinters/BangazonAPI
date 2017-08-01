# Bangazon API
This API will expose nine resources for client developers to consume for other application they want to write.
	- The Customer resource at the URI of http://localhost:5000/api/Customer
	- The Department Type resource at the URI of http://localhost:5000/api/DeptType
	- The Product resource at the URI of http://localhost:5000/api/Product
	- The Product Type resource at the URI of http://localhost:5000/api/producttype
	- The Training Program resource at the URI of http://localhost:5000/api/trainingprogram
	- The Computer resource at the URI of http://localhost:5000/api/computer
	- The Employees resource at the URI of http://localhost:5000/api/employee
	- The Order resource at the URI of http://localhost:5000/api/order
	- The Payment resource at the URI of http://localhost:5000/api/payment


### Installing Core Technologies
- SQLite
- For OSX Users `brew install sqlite`
- Postman

### For Windows Users
Visit the SQLite downloads and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

### SQL Browser
The DB browser for SQLite will let you view, query and manage your databases during the course.

### Visual Studio Code
Visual Studio Code is Microsoft's cross-platform editor that we'll be using during orientation for writing C# and building .NET applications. Make sure you add the C# extension immediately after installation completes.

### Windows
[Install .NET Core](https://www.microsoft.com/net/core#windows)
Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
Once installed open a command line app to initialize some code.
Make a directory for your app: `mkdir HelloWorld`
Move to the newly created directory. : `cd HelloWorld`
Create a new app: `dotnet new`
Build the app and restore any get any missing libraries (packages) : `dotnet restore`
Run the app: `dotnet run`
You should see the test "Hello World".
Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

### OSX
[Install .NET Core] (https://www.microsoft.com/net/core#macos)
Create and run an ASP.NET application using .NET Core
(https://docs.asp.net/en/latest/getting-started.html)
Review .NET Core Documentation
(https://docs.microsoft.com/en-us/dotnet/)

### Postman
Download Postman: https://getpostman.com

### Setting Up Your Environment Variable
Create an environment variable in your .zschrc or .bashrc file with the following syntax: 

```
Example:
	export BANGAZON_DB="/Users/KyleKellums/workspace/csharp/bangazon/BangazonAPI/bangazonapi.db".
```

Clone from github using git clone https://github.com/StevesSixLeggedSprinters/BangazonAPI.git 
cd into the directory you created.

### How to Run
After cloning the repo and setting your environment variable, restore dependencies and apply the migration.
```dotnet restore```
```dotnet ef database update```

Then run the project, which will seed the database with a few customers.

### Installing Bangazon API
As of now, the database is going to be hosted on your local computer. There are a few things you need to make sure are in place before the database can be up and running.
Fork and clone the repo on to you local machine.
Run `dotnet restore`
Run `dotnet ef migrations`
This will create all the migrations needed for Entity Framework to post items to the database based on the models in the Models/ directory
run `dotnet ef database update`
Run `dotnet run`
This will compile and run everything as well as initialize the database with some data to get started
Using the API
For now, all calls to the API will be made from (http://localhost:5000) as the domain. All calls will be made from here.
EX you can get a list of all the customers by making a get call to (http://localhost:5000/customer)

## Steps for Testing the API
Open Postman
Open SQL Browser. Use this command in the terminal: `open bangazon.db`

### Customers

**GET Customers** 
You can access a list of all customers by running a Get call to (http://localhost:5000/customer)

**GET Single Customer** 
You can get the information on a single customer by running a Get call to (http://localhost:5000/customer/{customerID}).

> Note: You need to have a customers unique ID number to get the correct information for a single customer.

**PUT** You can update the info on a specific customer by running a Put call to (http://localhost:5000/customer/{customerID}).

> You must Put the entire changed object, which will include the customerID, firstName, lastName, dateCreated, dateLastInteraction, and isActive.
	
```
	Example:
		{		
			"CustomerId":"1",
			"FirstName":"Kevin",
			"LastName":"Miller",
			"DateAccountCreated":"07/02/2017",
			"LastInteraction":"07/02/17",
			"IsActive":"1"
		}
```
**POST** You can post a new customer by running a Post call to (http://localhost:5000/customer)
```
	Example:
		{		
			"CustomerId":"1",
			"FirstName":"Kevin",
			"LastName":"Miller",
			"DateAccountCreated":"07/02/2017",
			"LastInteraction":"07/02/17",
			"IsActive":"1"
		}
```

## Product Resource

In the Product Resource, you will be able to **GET**, **POST**, **PUT**, **DELETE** product data in the database.

> NOTE In order to successfully use **GET**, you must first add a product using **POST**

**GET** 
GET will give access to the entire list of products
* Open Postman 
* Select GET
* URL: http://localhost:5000/product

**GET** 
GET will give access to a single product by ID
* Open Postman 
* Select GET
* URL: http://localhost:5000/product/{productID}

**POST** 
POST will allow you to add a product
* Open Postman 
* Select POST
* URL: http://localhost:5000/product

```
Example:
	{ 
	  "ProductTypeId": 2,
	  "DateProductAdded": "08-01-2017",
	  "CustomerId": 3,
	  "Price": 2.00,
	  "Title": "Cup",
	  "Description": "A cup to hold liquids."
	}
```

**PUT** 
PUT will allow you to update a specific product by ID
* Open Postman 
* Select PUT
* URL: http://localhost:5000/product/{productID}

> Running a PUT will require that you submit the entire object and have the ID specific to the product you want to update in the object, as well as in the URL.

```
	Example for using PUT:
		{ 
			"ProductId": 1,
			"ProductTypeId": 2,
			"DateProductAdded": "08-01-2017",
			"CustomerId": 3,
			"Price": 5.00,
			"Title": "Cup",
			"Description": "A plastic container to hold liquids."
		}
```

**DELETE** will allow you to delete a specific product by ID
* Open Postman 
* Select DELETE
* URL: http://localhost:5000/product/{productID}


### Product Types

**GET** 
You can access a list of all product types by running a Get call to http://localhost:5000/producttype.

**GET**
You can get the information on a single product type by running a Get call to http://localhost:5000/producttype/{producttypeID}.

> Note: you need to have a product types unique ID number to get the correct information.

**PUT** 
You can update the info on a specific product type by running a Put call to http://localhost:5000/producttype/{producttypeID}.	
Running a put requires that you submit the entire object.

 ```
	Example: 
		{
			"ProductTypeId" : "3",
			"CategoryName" : "Electronics"
		}
```

**DELETE** You can delete a product type by running a Delete call to http://localhost:5000/producttype{producttypeID}.

**POST** You can enter a new product type by running a Post call to http://localhost:5000/producttype
You must put a name with a post.

 ```
	Example: 
		{
			"CategoryName": "Electronics"
		}
```

## Payment Types

**GET** 
You can access a list of all payment types by running a Get call to http://localhost:5000/paymenttype

**GET** 
You can get the information on a single payment type by running a Get call to http://localhost:5000/paymenttype/{paymenttypeID}.
> Note: you need to have a payment types unique ID number to get the correct information

**PUT** You can update the info on a specific payment type by running a Put call to http://localhost:5000/paymenttype/{paymenttypeID}

Running a Put requires that you submit the entire object.

```
	Example: 
		{
			"PaymentTypeId":"1",
			"AccountNumber":"5003235",
			"CustomerId":"1",
			"PaymentTypeName":"Bitcoin"
		}
```
**DELETE** 
You can delete a payment type by running a Delete call to http://localhost:5000/paymenttype{paymenttypeID}

**POST** 
You can enter a new payment type by running a Post call to http://localhost:5000/paymenttype

```
	Example: 
		{
			"PaymentTypeId":"1",
			"AccountNumber":"5003235",
			"CustomerId":"1",
			"PaymentTypeName":"Bitcoin"
		}
```

## Order

> Note: You need the payTypeId before creating Order

**GET**
The HTTP GET method is used to read (or retrieve) a representation of a resource. You can access a list of all orders by sending a Get call to `http://localhost:5000/order`.


**GET** 
This method will retrieve an individual order. You can get the information for a single order by sending a Get call to `http://localhost:5000/order/``{OrderId}`.

**GET** one will return JSON containing the order details and an array of products added to that order.

> Note: You need an order's unique Id number to get the information

**PUT** 
This method is utilized for updating/modifying the order object. You can update the information on a specific order by sending a Put call to `http://localhost:5000/order/{OrderId}`.

This method requires the key `OrderId` to ammend the object.

```
    Example: 
		{
			"OrderId": 1,
			"PaytypeId": 1, 
			"DateOrdered": "08-01-2017", 
			"customerId": 1 
		}
```

**POST** 
This method is used to create subordinate resources. When creating a new resource you can add a new order by sending a Post call to `http://localhost:5000/order/`.
    
* You need to include `DateOdered`, `PaytypeId` and `customerId` in the body of the POST.
* Enter a new order by sending a Post call to `http://localhost:5000/order`
* The DateCreate field is auto-generated with the current date.

```
    Example: 
		{
			"DateOrdered": "07-31-17",
			"PaytypeId": 1,
			"customerId": 1
		}
```

**DELETE** 
This method is used to delete a resource identified by the objects id. You can delete an order by sending a Delete call to `http://localhost:5000/order/{OrderId}`


### Employees

**GET** 
You can access a list of all employees by running a Get call to `http://localhost:5000/employee`

**GET** 
You can get the information on a single employee by runnning a Get call to `http://localhost:5000/employee/{employeeID}`

> Note you need to have a employee unique ID number to get the correct information

**POST** You can enter a new payment type by running a Post call to `http://localhost:5000/employee`
* You must put a `name`, `jobTitle`, `dateStarted`, and `departmentID` with a Post.

```
	Example: 
		{
			"name": "Minerva McGonagall", 
			"jobTitle": "Professor", 
			"dateStarted": "12-01-1956", 
			"departmentID": 1
		}
```
> `isSupervisor` is an autogenerated field that will set every employee to 0 (this acts as a boolean as false, which means that employee is not a supervisor).

> If you hire a supervisor you can add `"isSupervisor":1` to the POST or change `"isSupervisor":1` in a put later on. 

**PUT** 
You can update the info on a specific employee by running a Put call to `http://localhost:5000/employee/{employeeID}`.

* Running a Put requires that you submit the entire object.

```
	Example: 
			{ 
				"employeeID": 1, 
				"name": "Minerva McGonagall", 
				"jobTitle": "Professor", 
				"dateStarted": "0001-01-01T00:00:00", 
				"isSupervisor": 1, "departmentID": 1
			}
```




**POST** You can enter a new payment type by running a Post call to (http://localhost:5000/employee)
```
	Example:
	  	{
			"EmpFirstName": "Krissy",
			"EmpLastName":"Caron",
			"EmpJobTitle" : "Software Developer"
		}
```

**isSupervisor** is an autogenerated field that will set every employee to 0 (not a supervisor) If you hire a supervisor you can add `"isSupervisor": 1` to the POST or change `"isSupervisor":1` in a put later on.


## Departments

**GET** You can access a list of all departments by running a Get call to http://localhost:5000/DeptType.

**GET** one. You can get the information on a single department by runnning a Get call to http://localhost:5000/deptType/{deptTypeId}.

> Note you need to have a department unique ID number to get the correct information.

**PUT** You can update the info on a specific department by running a Put call to http://localhost:5000/deptType/{deptTypeId}.

> Running a Put requires that you submit the entire object.

```
	Example: 
		{
			"DeptTypeId":"1",
			"DeptName":"IT",
			"ExpBudget":"3mil"
		}
```
**POST** You can enter a new payment type by running a Post call to http://localhost:5000/deptType
You must put a name and expenseBudget with a Post.

```
	Example: 
  		{
			"DeptTypeId":"1",
			"DeptName":"IT",
			"ExpBudget":"3mil"
  		}
```

##Computer Resource by Jackie

In the Computer Resource, you will be able to **GET** **POST** **PUT** **DELETE** computer data in the database.

> Note: In order to successfully use **GET**, you must first add a computer using **POST**

**GET** 
GET will give access to the entire list of computers
* Open Postman 
* Select GET
* URL: http://localhost:5000/computer

**GET** 
GET will give access to a single computer by ID
* Open Postman 
* Select GET
* URL: http://localhost:5000/computer/{computerID}

**POST** 
POST will allow you to add a computer
* Open Postman 
* Select POST
* URL: http://localhost:5000/computer

```
Example for using POST:
	{  
	  "PurchaseDate": "08-01-2017",
	  "DecommissionDate": "10-11-2017",
	  "EmployeeId": 2
	}
```

**PUT** 
PUT will allow you to update a specific computer by ID
* Open Postman 
* Select PUT
* URL: http://localhost:5000/computer/{computerID}
> Running a PUT will require that you submit the entire object and have the ID specific to the computer you want to update in the object, as well as in the URL.

```
Example for using PUT:
	{ 
	  "ComputerId": 1, 
	  "PurchaseDate": "08-01-2017",
	  "DecommissionDate": "10-11-2017",
	  "EmployeeId": 2
	}
```

**DELETE** 
DELETE will allow you to delete a specific computer by ID
* Open Postman 
* Select DELETE
* URL: http://localhost:5000/computer/{computerID}


### Training Programs

**GET** 
You can access a list of all training programs by running a Get call to http://localhost:5000/trainingprogram.

**GET** 
You can get the information on a single training program by runnning a Get call to http://localhost:5000/trainingprogram/{trainingprogramID}.
Note you need to have a training program unique ID number to get the correct information

**PUT** 
You can update the info on a specific training program by running a Put call to http://localhost:5000/trainingprogram/{trainingprogramID}.
Running a Put requires that you submit the entire object.

```
	Example: 
		{ 
			“trainingProgramName”:”JS OnBoarding”, 
			"trainingProgramID": 1, 
			"StartDate": "02-14-2018", 
			"EndDate": "02-15-2018", 
			"maxAttendees": 50 
		}
```

**DELETE** 
You can delete a training program by running a Delete call to http://localhost:5000/trainingprogram{trainingprogramID}.

> Note - you can only delete a training program if the current date is before the start date of a program. You cannot delete programs that have already started or that have already occurred.

**POST** 
You can enter a new training program by running a Post call to http://localhost:5000/trainingProgram
You must put a name, dateStart, dateEnd, and maxAttendees with a Post.

Example: 
```
	{ 
		"trainingProgramID": 1,
		“trainingProgramName”:”JS OnBoarding”,
		"StartDate": "02-14-2018", 
		"EndDate": "02-15-2018", 
		"maxAttendees": 50 
	}
```
