# API Serverless

A simple API Serverless using NodeJS, MongoDB and Azure Functions. This is a basic implementation based on the lessons of [Igor Halfeld](https://github.com/IgorHalfeld/digital-innovation-one-demo) available on [Digital Innovation One](https://digitalinnovation.one/ "Digital Innovation One"). 

### Using

* This content uses Azure Functions and it is built for use in [Azure Serverless](https://azure.microsoft.com/en-us/solutions/serverless/). In this way it is recommended that you use Visual Studio Code for debugging and [Azure Functions Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions).
* Download this repository and unzip it.
* Enter the unzipped folder and type **func host start** to start the API. The endpoints are:
  * CreateProduct: [POST] http://localhost:7071/api/products
  * DeleteProduct: [DELETE] http://localhost:7071/api/products/{id}
  * GetProductbyId: [GET] http://localhost:7071/api/products/{id}
  * GetProducts: [GET] http://localhost:7071/api/products
  * UpdateProduct: [PUT] http://localhost:7071/api/UpdateProduct


