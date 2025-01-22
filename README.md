# C# Entity Framework Introduction

This repository comes setup with a

## Setup


- Remove or rename the *appsettings.Example.json* so that you have an *appsettings.json, appsettings.Development.json* file in the root of the workshop.wwwapi project which contains:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

- Note the .gitignore file in the root of the project which prevents the build directories being uploaded:
```
*/**/bin/Debug   
*/**/bin/Release   
*/**/obj/Debug   
*/**/obj/Release   
/workshop.wwwapi/appsettings.json
/workshop.wwwapi/appsettings.Development.json
```


## Dependencies Installed
- Install-Package Scalar.AspNetCore
    - provides a /scalar endpoint 
- Install-Package Swashbuckle.AspNetCore
    - provides a /swagger endpoint
- Install-Package Microsoft.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.InMemory