# CallerAPI
CallerAPI is a library for .NET Framework applications.It was created to request web APIs that deserialize the JSON or XML result from a web service to a model class.

## Installation
Please install the last version:
```
PM> Install-Package CallerAPI -Version 2.0.1
```

## Usage
The CallerAPI contains five public functions for use by users.The each functions take like parameter a action delegate method with typename paramater a [Params class model](https://github.com/EddyEduard/CallerAPI/blob/master/CallerAPI/Params.cs).The each functions return a Result class model which contains the data or errors resulting from request. 
\
\
This function return the data and errors resulting from web service as string.
```csharp
public async Task<Result<string, string, HttpStatusCode>> RequestTextAsync(Action<Params> action);
```
These two functions deserialize the data resulting to a *TValue* model class or another object and the errors resulting as string.
```csharp
public async Task<Result<TValue, string, HttpStatusCode>> RequestJSONAsync<TValue>(Action<Params> action);
public async Task<Result<TValue, string, HttpStatusCode>> RequestXMLAsync<TValue>(Action<Params> action);
```
These two functions deserialize the data resulting to a *TValue* model class or another object and the errors resulting to a *TError* model class or another object.
```csharp
public async Task<Result<TValue, TError, HttpStatusCode>> RequestJSONAsync<TValue, TError>(Action<Params> action);
public async Task<Result<TValue, TError, HttpStatusCode>> RequestXMLAsync<TValue, TError>(Action<Params> action);
```
To send data to web service using the methods: POST, PUT, PATCH ... we need to encode the data in bytes.The basic ways to encode the data to bytes for the main content type are:

### 1.Content-Type: *application/json*
```csharp
UTF8Encoding encoding = new UTF8Encoding();
byte[] content = encoding.GetBytes("JSON content...");
```
### 2.Content-Type: *application/xml*
```csharp
UTF8Encoding encoding = new UTF8Encoding();
byte[] content = encoding.GetBytes("XML content...");
```
### 3.Content-Type: *application/x-www-form-urlencoded*
```csharp
var data = new FormUrlEncodedContent(new[]
{
     new KeyValuePair<string, string>("key", "value")
});
byte[] content = await data.ReadAsByteArrayAsync();
```
### 4.Content-Type: *multipart/form-data*
```csharp
var data = new MultipartFormDataContent();
data.Add(new ByteArrayContent("File bytes..."), "file");
byte[] content = data.ReadAsByteArrayAsync();
```

## License
Distributed under the MIT License. See [MIT](https://github.com/EddyEduard/CallerAPI/blob/master/LICENSE) for more information.

## Contact
Eduard-Nicolae - [eduard_nicolae@yahoo.com](mailTo:eduard_nicolae@yahoo.com)
\
Project link - [https://github.com/EddyEduard/CallerAPI](https://github.com/EddyEduard/CallerAPI.git)
