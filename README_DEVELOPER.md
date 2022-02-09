# Developer comments from Reino Boonstra

Welcome to my version of this code base. I decided to keep the changes to a minimum, since it is a small project anyway.
The biggest change I made was adding unit tests for the controllers, services and database layer.

## Testing tools

Tools I used for testing are Moq and FluentAssertions.
Moq allows for mocking objects for testing.
FluentAssertions gives readable assertions in your test, such as userName.Should().Be("Reino Boonstra");

## Inversion of control

To be able to test the code I needed some dependency injection, so I introduced AutoFac Inversion of Control library

## Code comments

I like code to be readable as much as possible. Code that can describe itself and doesn't need comments or documentation to be understandable.
This is also the reason I have removed obvious comments.

## Generated code

I did not touch the generated code, since that will be overwritten anyway by each version update.

## Complexity

I left the structure mostly intact. I found no need to make things more complicated.

## Namespace

I gave the projects more meaningful names, as they would have in a corporate environment. Therefore the namespaces got updated.

## Hardcoded configuration

I moved hardcoded configuration to the web.config. In this case it was the connection string. The release web.config will use a different connection string value.

## Framework upgrade

I upgraded the solution to .NET Framework 4.8 as my VS 2022 would otherwise have difficulties with it.

## Issue with order service 'getOrders' method

There was an issue with the order service get orders. It has a parameter 'companyId', which was not used in the method.
I added this to the WHERE clause of the query, so it is now fixed.

## Run this code

In order to run this code, the connection string in the web.config needs to be changed to the path that is applicable for the location this code has been downloaded.
Also check the README.md file for the database setup instructions.