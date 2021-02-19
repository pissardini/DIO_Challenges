# API.NET with MongoDB

An example of a API based on .NET using MongoDB. This code is based on [gabrielfbarros' lessons](https://github.com/gabrielfbarros/dotnet-mongo) on [Digital Innovation One](https://web.digitalinnovation.one).

## Requirements

* [MongoDB Driver for C#](https://docs.mongodb.com/drivers/csharp/)

## Using 

* This code was created using the resources from [MongoDB Atlas](https://www.mongodb.com/cloud/atlas/register). For initial tests, I recommend that you create an account, start a free cluster and get the connection string. After this, insert the connection string in the file **appsettings.json**.

* For testing, start the API (in VSCode use **dotnet run**). With a tool like Postman, access https://localhost:5001/infectado. If you call the [Post] method you can insert a profile using json: 
```
{
	"dataNascimento": "1990-03-01",
	"sexo": "M",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
```

If you want to get the list of users, you can call the [Get] method using the above endpoint.