# Overview
This library is meant to act as an SDK for the EasyRedir API (located [here](https://www.easyredir.com/docs/api/)). I've fully mapped all endpoints as methods in the library, making them easier to use and easier to read.

# Getting Started
Here we'll discuss how to add a reference to the library in your own code, and explain the basic usage of the library.

## Referencing The Library
The library is not currently hosted in NuGet, so for now, you'll need to reference it like a typical DLL flat file. 

1. Download the fully compiled DLL file [here](https://github.com/jmknight2/EasyRedirSDK/releases/tag/v1.0).
2. Open your solution in Visual Studio.
3. Right-click on your project in the solution explorer and choose either "Add Reference" or "Add Project Reference" depending on your version of Visual Studio.
4. Click the "Browse" buton on the bottom right, and select the DLL you downloaded in step 1.

## Basic Usage
Now that you've referenced the library, you can begin using the SDK. We'll start by defining an `EasyRedirClient()` object. This is the workhorse of the SDK and what you'll spend the most time interacting with. 

We initialize our EasyRedirClient object below by passing an API Key as the first argument, and an API Secret as the second argument.
```C#
var easyRedirClient = new EasyRedirClient("{API KEY}", "{API SECRET}");
```

Next, let's try getting a couple redirect rules from our EasyRedir account, and printing their target URLs to the console.
Note that we pass 2 to the method, which is our limit value. The maximum limit is 100. 
```C#
var ruleResponse = await easyRedirClient.GetEasyRedirRule(2);

foreach (var rule in ruleResponse.Data) {
  Console.WriteLine(rule.Attributes.TargetURL);
}
```
When you execute the above code, you should see two target URLs printed in the console.

## Pagination
The EasyRedir API fully supports pagination, and as such, so does this library. Continuing our example from above, let's get the next two rules from EasyRedir's API.
Each paginated response from the API will include a `Next` property inside the `Meta` object. This property is the page token which we will use to query another two rules from the API.
```C#
var nextResponse = easyRedirClient.GetEasyRedirRules(ruleResponse.Meta.Next);

foreach (var rule in nextResponse.Data) {
  Console.WriteLine(rule.Attributes.TargetURL);
}
```

Additionally, the `Meta` object also contains a `HasMore` property. You can utilize this property to see if there is another page of results. We could then modify the above code like so:
```C#
if (ruleResponse.Meta.HasMore) {
  var nextResponse = easyRedirClient.GetEasyRedirRules(ruleResponse.Meta.Next);

  foreach (var rule in nextResponse.Data) {
    Console.WriteLine(rule.Attributes.TargetURL);
  }
}
```

## Creating Redirects
Below is a simple example of how we can easily create new redirect rules.
```C#
var createResponse = await easyRedirClient.CreateEasyRedirRule( new EasyRedirRuleAttributes { 
    TargetUrl = new Uri("https://google.com"),
    SourceUrls = new string[] { 
        "google.example1.com",
        "google.example2.com"
    },
    ForwardParams = false,
    ForwardPath = false,
    ResponseType = EasyRedirResponseType.MovedPermanently
});
```

## Error Handling
Any errors thrown from the API will be thrown in code as a custom exception object: `EasyRedirException`. This exception object contains several properties that can tell you more about why your call failed. The `Errors` property specifically gives you a detailed list of every error in your code, and how to correct those errors. In the exapmle below we attmept to create a redirect rule that already exists. By parsing the error details in the exception object, we can determine the root cause of the error.
```C#
try {
    var createResponse = await easyRedirClient.CreateEasyRedirRule(new EasyRedirRuleAttributes {
        TargetUrl = new Uri("https://google.com"),
        SourceUrls = new string[] {
            "google.example1.com",
            "google.example2.com"
        },
        ForwardParams = false,
        ForwardPath = false,
        ResponseType = EasyRedirResponseType.MovedPermanently
    });
} catch (EasyRedirException exc) {
    Console.WriteLine("------------ Generic Error ------------");
    Console.WriteLine(String.Format("Error Type: ", exc.ErrorType));
    Console.WriteLine(String.Format("Error Message: ", exc.ErrorMessage));

    foreach (var errorObj in exc.Errors) {
        Console.WriteLine("------------ Specific Errors ------------");
        Console.WriteLine(String.Format("Error Code: ", errorObj.Code));
        Console.WriteLine(String.Format("Error Message: ", errorObj.Message));
        Console.WriteLine(String.Format("Resource: ", errorObj.Resource));
        Console.WriteLine(String.Format("Param: ", errorObj.Param));
    }
}
```
