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

To-dos
------
*	Implement full [Plurk APIs](http://www.plurk.com/API). 
	Currently only basic `/APP/Timeline/` and `/APP/Responses/` features implemented, so contributions are welcomed.


Author
------
You can follow @[RSChiang](http://www.plurk.com/RSChiang) on Plurk.

License
-------
rsPlurkLib is released under [MIT License](legal.md).