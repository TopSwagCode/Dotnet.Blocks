# Dotnet.Blocks

Initial thoughts 

* Consider the global availability of the service.
  * With this requirement and the love "Blocks" has for AWS, AWS Lambda would be an good option. Also because I know "Blocks" already is a heavy user of lambda. Lambda also has an option to deploy on the "edge" / around the globe close to the users. https://aws.amazon.com/lambda/edge/
* GraphQL
  * I haven't used GraphQL before, but have read alot about it. I have also read lots of blogs about HotChocolate for AspNetCore GraphQL package, I have been thinking about trying for a while. This would a good time for me to try it out :D
* REST
  * For REST API my plans starting out is to use https://fast-endpoints.com/ which is an awesome package for building API's. It helps creating clean testable endpoints in the REPR pattern.
* Authentication
  * It is going to be something simple just to show Admin / Normal user roles to have access to different endpoints. Using bearer token authentication. I have this project: https://github.com/TopSwagCode/Dotnet.IdentityServer I built a while back showing off how to use https://duendesoftware.com/products/identityserver to built own internal OpenID Connect + OAuth server. It also contains a wide range of clients and service to service authentication requests. 

This is just some first thoughts while watching "Danish Bake off" :)
