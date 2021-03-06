# HelpScoutSharp

.NET client for Help Scout Mailbox API 2.0

https://developer.helpscout.com/mailbox-api/

![Build](https://github.com/better-reports/HelpScoutSharp/workflows/Build/badge.svg)

`Install-Package HelpScoutSharp`

### Implemented operations

Not all endpoints are fully implemented yet.

PRs are welcome!

| Endpoint                     | Operation                         | Implemented? |
| ---------------------------- | --------------------------------- | ------------ |
| Conversations / Attachments  | *                                 | No           |
| Conversation / Custom fields | *                                 | Yes          |
| Conversation / Tags          | *                                 | Yes          |
| Conversation / Threads       | Create/Update/GetThreadOriginal   | No           |
| Conversation / Threads       | List                              | Yes          |
| Conversation                 | Create/Update/Delete              | No           |
| Conversation                 | List/Get                          | Yes          |
| Customers                    | Create/Update/Overwrite           | No           |
| Customers                    | List/Get                          | Yes          |
| Mailbox                      | Get                               | No           |
| Mailbox                      | List/ListFolders/ListCustomFields | Yes          |
| Ratings                      | Get                               | Yes          |
| Reports                      | *                                 | No           |
| Tags                         | List Tags                         | Yes          |
| Teams                        | *                                 | Yes          |
| Users                        | List/Get/GetMe                    | Yes          |
| Users                        | Delete                            | No           |
| Webhooks                     | *                                 | Yes          |
| Workflows                    | *                                 | No           |

### Authenticating and calling the API

All services must be given an access token which can be fetched via the `AuthenticationService`.

Both OAuth authentication (for public apps) and internal authentication (for private apps) is supported.

###### OAuth authentication

```
var authService = new AuthenticationService();
string redirectUrl = authService.GenerateAuthorizationPromptUrl(appId, state);
// Redirect the user to redirectUrl so that they can approve the connection
...
...
// Then exchange the code on the redirected url for a token
var token = await _service.GetOAuthTokenAsync(appId, appSecret, "ENTER_CODE_HERE");
...
...
// Use the accessToken to instantiate any service
var customerService = new CustomerService(token.access_token);
var res = await customerService.ListAsync();
```
###### Internal authentication

```
var authService = new AuthenticationService();
var token = await _service.GetApplicationTokenAsync(appId, appSecret);
...
...
// Use the accessToken to instantiate any service
var customerService = new CustomerService(token.access_token);
var res = await customerService.ListAsync();
```

### Global settings

#### Custom `HttpClient`

You may set a custom `HttpClient`: 

`HelpScoutHttpClient.HttpClient = myHttpClient;`

#### Rate limit breach behaviour

By default, a `HelpScoutException` is thrown when you breach your rate limit.
See https://developer.helpscout.com/mailbox-api/overview/rate-limiting/

Alternatively, you can opt-in for HelpScoutSharp to automatically retry after waiting for the appropriate amount of time:

`HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;`

### Verifying webhooks

When receiving webhooks, you can check that the request is authentic with the `WebhookService`.

```
string secretKey = "GET FROM CONFIG";
string signature = "GET FROM HTTP header 'X-Helpscout-Signature'";
string body = "GET RAW BODY FROM REQUEST"
bool isAuthentic = WebhookService.IsAuthenticWebhook(secretKey, signature, body);
```