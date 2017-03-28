# appinsight-owin-deepdive
Asp.Net 4.6.2 Using Owin and Application Insights

# Warming Up
Quick recap on what Owin needs:
1. `Microsoft.AspNet.WebApi.Owin` &
2. `Microsoft.AspNet.WebApi.OwinSelfHost`.
Once you have that, you can delete the old Global.asax. Feeling better, right? 

Also, you'll need .NET 4.6.2 but I guess you have that already.
At the time of running this deep dive, Application Insights was running free in its Basic Tier.
[Detailed information about pricing](https://azure.microsoft.com/en-gb/pricing/details/application-insights/)

Cool, let's get started.

# Application Insights

Owin uses MiddleWare, so we'll need to build our own middleware to speak to Application Insights, HA! Luckily, Marcin Budny has done this work for us open sourcing a really nice extension [Here]( https://github.com/marcinbudny/applicationinsights-owinextensions "owinextension-applicationinsight"). Totally recommended. 

# Architecture of the system that we want to monitor

On this exercise we'll not cover (for the time being) how to host your Infrastructure. 
Here is how our system behaves. If you look at the code, you'll realise that it abuse from static Services that aren't being tested.
The design serves a second purpose which is run a refactor session (to be scheduled).
 
![App Insight Architecture that we are about to monitor](https://dl.dropboxusercontent.com/u/24713287/blog/researchs/appinsight-owin-deepdive/AppInsightOwinDeepDive.jpg)
