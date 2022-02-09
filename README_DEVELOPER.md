# Developer comments from Reino Boonstra

Welcome to my version of this code base. I decided to keep the changes to a minimum, since it is a small project anyway.
The biggest change I made was adding unit tests for the controllers, services and database layer.
Tools I used for testing are Moq and FluentAssertions.
I like code to be readable as much as possible. This is also the reason I have removed obvious comments.
I did not touch the generated code, since that will be overwritten anyway by each version update.
I left the structure mostly intact. I found no need to make things more complicated.
I gave the projects more meaningful names, as they would have in a corporate environment. Therefore the namespaces got updated.
I moved hardcoded configuration to the web.config. In this case it was the connection string. The release web.config will use a different connection string value.
I upgraded the solution to .NET Framework 4.8 as my VS 2022 would otherwise have difficulties with it.
There was an issue with the order service get orders. It has a parameter 'companyId', which was not used in the method.

