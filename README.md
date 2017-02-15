# TrelloTest

This is a (painfully) simple app that will allow you to add random comments to yout Trello cards.
Its currently confugured to be run from the IDE, and all logging is outputed to Debug (feel free to change in the nlog.config file.)

Error handling is minimal, largely because I just don't know web-dev.

Architectualy it's a bog-standard MVC app.  Calls to Trello ae done via the *ITrelloService*.  For DI I'm using Ninject and its various extensions, for tetsuing NUnit/Rhino Mocks, for logging NLog, and TrelloNet (Edge) is what's being used to takl to Trello.  Note that the base TrelloNet project didn't want to work, and the 'Edge' version is used instead.

Please don't ask about OAuth.

I've ried to demonstrate best practices re:
* Dependency injection
* Breaking off external dependencies into indivuidal services (i.e. Trello)
* Interfacing all third party code and only exposing the minimum functionality required.  This makes it easier to mock, plus makes changing the component (say, changing the logging framework) pretty trivial (i.e. only have to update a single class).
* Strongly 'typing' AppConfig to force devs to be explicit in what they expect from the config.
* Centralising excetion handling for things like calling external services via lambdas, avoiding repeated try/catch blocks throughout the code.

![A bunny.  YOU decide.](./bunny.jpg)