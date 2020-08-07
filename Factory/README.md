# _Sneuss' Factory_

#### _Manage machines and engineers in your factory database, August 7, 2020_

#### By _**Ben White**_

## Description

_This application allows a user to add engineers and machines to a factory database, as well as, view details, and edit and delete engineers and machines_

## Setup/Installation Requirements

Software Requirements:

1. This program utilizes .NET version 2.2, and requires this framework to be pre-installed:
    * Please go to https://dotnet.microsoft.com/download/dotnet-core/2.2 and install the SDK version 2.2 or
      greater patch version, but do not upgrade to a higher minor version number.

2. Clone this repository onto your computer: https://github.com/...

3. In your preferred terminal window, navigate into Factory.Solution/Factory using cd (i.e. cd
   desktop/Factory.Solution/Factory) and open the project with your preferred code editor.

4. Run the following terminal command: $ dotnet restore

5. In order for this program to work you will need to create an appsettings.json file, after you do that enter this code in it:

  ```{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=Ben_White;uid=root;pwd={ _password_ };"
    }
  }
  ```
  * Replacing password with your server password


6. To initiate this application, run the command: $ dotnet run


## User Stories
* As the factory manager, I need to be able to see a list of all engineers, and I need to be able to see a list of all machines.

* As the factory manager, I need to be able to select a engineer, see their details, and see a list of all machines that engineer is licensed to repair. I also need to be able to select a machine, see its details, and see a list of all engineers licensed to repair it.

* As the factory manager, I need to add new engineers to our system when they are hired. I also need to add new machines to our system when they are installed.

* As the factory manager, I should be able to add new machines even if no engineers are employed. I should also be able to add new engineers even if no machines are installed

* As the factory manager, I need to be able to add or remove machines that a specific engineer is licensed to repair. I also need to be able to modify this relationship from the other side, and add or remove engineers from a specific machine.

* I should be able to navigate to a splash page that lists all engineers and machines. Users should be able to click on an individual engineer or machine to see all the engineers/machines that belong to it.

## Known Bugs

_No bugs known at this time_

## Support and contact details

_Ben White: bwhite2140@outlook.com_

## Technologies Used

_Git, C#, Dotnet, SQL, Entity_

### License

*MIT License*

Copyright (c) 2020 **_Ben White_**