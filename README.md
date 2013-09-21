Monopoly sample project
===============

This is a sample ASP.NET MVC 5 app I (@pseale) wrote to explore automated web testing, singleton abuse, basic EF 6, and a few other things.

Usage
-----

Download/clone this project's source, run the app (it creates its own database in App_Data), and read the source as desired. 

To run the web tests, use any NUnit test runner and run the entire test suite. The test run will fire up an IISExpress instance and a Selenium-driven browser. Do not touch the browser.

VS2013 version note: I created this sample project with a copy of Visual Studio 2013 **Preview** (emphasis on Preview), so if you're running the RC or anything newer, **there might be some weirdness with Nuget packages**. For example, all of the MVC 5 Identity packages have changed significantly; even some of the package names have changed.


Things I am mildly to moderately ashamed of
-------------------------------------------

1. UI. I did the minimum possible on top of what the base template (and twitter bootstrap) provided. I'm not ashamed of my paint-fu, though perhaps I should be.
2. My automated web test harness is interesting, and better than anything I could find, but it still has some major problems that will show up quickly if you try to just copy/paste use it on a real project with CI. I may fix them, but I haven't yet.
3. Things I have on my to-do list: Fix selenium Firefox wrapper-aware code to be agnostic, make sure I have anti-forgery tokens everywhere, add an action filter to remove a lot of duplication in the GameController
4. As of today (2013-09-21), the test helpers are disorganized. I plan to experiment with them, but if they don't change...just know I meant to change them.
5. I'm moderately ashamed of how I put zero (0) behavior on most of my model objects, but threw all the behavior on Game (the aggregate root). I either have to spread around the behavior like a strong domain model, or completely strip Game of all behavior like an anemic domain model, for consistency.
6. My "fast tests" project sucks...I think. Maybe. Given I have comprehensive web tests, and given I was rarely at a loss for how to implement the simple behavior, I felt little need to add unit tests that covered things already covered by the web tests.
7. My git checkin history is like a stream of consciousness. When working on solo projects I use source control as a lazy way to back up my work, and reading the commits shows. I could have (still can) go back and clean up the history so that each well-labeled commit represents a single change. But I didn't.
8. At current count, there are 192 compiler warnings. In related news, I can't make and use my own extension methods.
9. Don't look at SecretAdminController.

Things you may find interesting
===============================

1. This is the only sample app I've seen with a working web test harness. This may be the first you've seen as well.
2. I'm experimenting with **simplicity** for my domain model and surrounding code. Specifically, my "model/domain" code is implemented using dumb domain objects, static Query/Command objects, and all static Service objects. I am aware of the downsides of not using dependency injection ( http://lostechies.com/chadmyers/2009/07/14/the-usual-result-of-poor-man-s-dependency-injection/ ) and am experimenting with this anyway. So far, so good.
3. If you are looking for examples for how to use Coypu (the .NET capybara-alike framework), well, here's some.
4. This is the only MVC 5 sample app I have found, so it may be the first one you've found. I've taken advantage of some MVC 5 features, though in some cases (like Identity) I have twisted it into something you won't be able to reuse.
5. I am (eventually) going to use EF 6, and (again) I haven't seen a sample app that uses it.
