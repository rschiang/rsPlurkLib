rsPlurkLib
==========

Introduction
------------
rsPlurkLib is a Plurk API 2.0 library bulit on top of .NET Framework. Written in C#, rsPlurkLib is clean, elegant, and minimally assembly-dependent.

Prerequisites
-------------
* .NET Framework 3.0 is the current project target. Might work under a .NET 2.0 build, but still not tested.
* [JSON.NET](http://json.codeplex.com/) is the current JSON parser. Neither its binary nor source is included in project, so you'll need to correct the project assembly dependency on your machine.

### To build
1. Clone the repository to your project folder.
2. Reconfigure the project reference to use a proper version of JSON.NET, source or binary.
3. Fill in your application key and secret under `OAuthInstance.cs`
4. Save, build & run.

### Structure
* `OAuthInstance.cs` provides methods to acquire and exchange OAuth token, sending raw requests.
* `PlurkHelper.cs` wraps Plurk API as a single callable static class.
* `Entities` folder holds the JSON entity type Plurk will return.

Usage
-----
* Create a new instance of `PlurkHelper`.
* Acquire a token using methods under `PlurkHelper.Client`.
* Make use of methods under `PlurkHelper` class for matching API calls. 

If you aren't building an interactive client, you may directly assign a token, which significantly reduces the amount of code like this:

    PlurkHelper helper = new PlurkHelper();
    helper.Client.Token = new OAuthToken("AsDfGhIlB5Zd", "GUjneXpk91a7G32c8X6q9527", OAuthTokenType.Permanent);
    helper.AddPlurk("says", "Hello Plurk!");

More examples can be found under [Examples](https://github.com/rschiang/rsPlurkLib/tree/master/Examples) folder, with a typical OAuth authentication walkthrough available as a console implementation.

Contribute
----------
You can provide recommendations or report bugs at our [issue tracker](https://github.com/rschiang/rsPlurkLib/issues).

### To-dos
* Expand API coverage. Currently only basic `/APP/Timeline/` and `/APP/Responses/` features implemented.
* Document the entity classes under `Entities`. 

The offical Plurk API documentation can be found [here](http://www.plurk.com/API).

Author
------
You can follow @[RSChiang](http://www.plurk.com/RSChiang) on Plurk.

License
-------
rsPlurkLib is released under [MIT License](https://github.com/rschiang/rsPlurkLib/blob/master/LICENSE.md).
