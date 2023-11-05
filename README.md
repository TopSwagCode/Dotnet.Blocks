# Dotnet.Blocks

## Initial thoughts 

* Consider the global availability of the service.
  * With this requirement and the love "Blocks" has for AWS, AWS Lambda would be an good option. Also because I know "Blocks" already is a heavy user of lambda. Lambda also has an option to deploy on the "edge" / around the globe close to the users. https://aws.amazon.com/lambda/edge/
* GraphQL
  * I haven't used GraphQL before, but have read alot about it. I have also read lots of blogs about HotChocolate for AspNetCore GraphQL package, I have been thinking about trying for a while. This would a good time for me to try it out :D
* REST
  * For REST API my plans starting out is to use https://fast-endpoints.com/ which is an awesome package for building API's. It helps creating clean testable endpoints in the REPR pattern.
* Authentication
  * It is going to be something simple just to show Admin / Normal user roles to have access to different endpoints. Using bearer token authentication. I have this project: https://github.com/TopSwagCode/Dotnet.IdentityServer I built a while back showing off how to use https://duendesoftware.com/products/identityserver to built own internal OpenID Connect + OAuth server. It also contains a wide range of clients and service to service authentication requests. 

## Graph / REST thoughts

### GraphQL:
GraphQL would be ideal for the many apps that are going to show the events. They all might show the events slighty different and request different information.
Some apps might just show like a basic list of events. Others might have more detail like pricing and number of avaible tickets. Some might only a specfic event with a certain speaker etc. GraphQL would enable each app to sort, filter and select level of detail of what to show.


#### Mutations:
```
SignUpToEvent(eventId)
WithdrawFromEvent(eventId)
```

#### Query:
```
MyEvents()
UpcomingEvents(filter?)
UpcomingEventsNearMe()
Speakers, Locations, Booths, Agenda etc.
```

### REST API:
While still could be used from public facing and external clients, it would perhaps be more likely to be internal admin tools. Where you would have it setup as dashboards and admin panels. Likely all fields would be shown and editable. There would most like be basic CRUD endpoints and listing endpoints. Many times the base route eg: "/api/event" would also allow querystring parameters for filtering and sorting events. Maybe some pageination. Personally I hate pageination and firmly believe that it should "never" be used on the backend. A good search / filtering solution is way better. Eg. only fetching 100 elements and if more exists in the database, tell the user to narrow down the search. ( There are usecases where it might make sense, but default shouldn't be pageination :) ).

Here is a basic idea for the api.
```
GET      /api/event             List of events
POST     /api/event             Create event
GET      /api/event/{eventUid}  Get single event
Delete   /api/event/{eventUid}  Delete single event
PUT/POST /api/event/{eventUid}  Update single event
```

I don't have any strong feelings about POST / PUT / PATCH. Post is mainly used for creating something new and sometimes as starting a proccess. PUT normally updates the entire object while patch updates subsets of an object. I have just seen many places done things differently for different reasons. Some times we might go little outside normal REST and create specific endpoints to do a specific action eg:

```
GET      /api/event/{eventUid}/participant-list Get list of participants 
```

It's not unheard of having specific action endpoints for doing a very specfic task, that does not belong in a fully REST api. An alternative if we needed more admin endpoints to micro manage a event something like this:


```
GET      /api/event/{eventUid}/participant Get list of participants or
POST     /api/event/{eventUid}/participant Add participant to event from admin site.
GET      /api/event/{eventUid}/participant/{userUid} Get specific participant from event.
DELETE   /api/event/{eventUid}/participant/{userUid} Remove participant from event
PUT/POST /api/event/{eventUid}/participant/{userUid} Update participant information
```

There are ton of more endpoints that could be added for managing an event like:


```
GET      /api/event/{eventUid/Speakers ...... Sessions, Booths, Floor, Merchants etc.
```
