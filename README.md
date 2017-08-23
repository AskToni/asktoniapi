# asktoniapi
Life changing food recommendations

## Build setup

``` bash

# Note:
Need to request user-secrets from repo owners to connect to databases

# Check to see if Secret Manager is working
dotnet user-secrets -h

# Add user secrets
dotnet user-secrets set MySecret ValueOfMySecret

# Build code
dotnet build

# Run WebAPI
dotnet run

# Navigate to Swagger Endpoint
localhost:xxxx/swagger/

```

## Endpoint

Our live endpoint can be accessed here:<br/>
[http://asktoniapi.azurewebsites.net/swagger](http://asktoniapi.azurewebsites.net/swagger)
