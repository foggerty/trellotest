# TrelloTest

This is a (painfully) simple app that will allow you to add random comments to your Trello cards, that was written as a coding challenge for a job interview.  Since I'm not a web-dev, I've focused on the overall design, modularity, testability, DI etc, rather than making this look pretty or be particually useful.

It’s currently configured to be run from the IDE, and all logging is outputed to Debug (feel free to change in the nlog.config file.)

Architecturally it's a bog-standard MVC app.  Calls to Trello ae done via the *ITrelloService*.  For DI I'm using Ninject and its various extensions, for testing NUnit/Rhino Mocks, for logging NLog, and TrelloNet (Edge) is what's being used to talk to Trello.  Note that the base TrelloNet project didn't want to work, and the 'Edge' version is used instead.

Please don't ask about OAuth.  Just....  Don't.

I've tried to demonstrate best practices re:
* Dependency injection
* Breaking off external dependencies into individual services (i.e. Trello)
* Interfacing all third party code and only exposing the minimum functionality required.  This makes it easier to mock, plus makes changing the component (say, changing the logging framework) pretty trivial (i.e. only have to update a single class).
* Strongly 'typing' AppConfig to force devs to be explicit in what they expect from the config.  I've seen some nasty bugs that surfaced because code expected there to be (say) a string in app.config, but then continued on its way happily with a NULL value until something hotible happened because the rest of the code wasn't expecting a NULL.  Never assume that config will always have sensible values in it.
* Centralising exception handling for things like calling external services via lambdas, avoiding repeated try/catch blocks throughout the code.

![A bunny.  YOU decide.](./bunny.jpg)
