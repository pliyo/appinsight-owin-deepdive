# Application Insights Deep Dive using Owin & posting messages to Slack.

# Warming Up
Quick recap on what Owin needs:
1. `Microsoft.AspNet.WebApi.Owin` &
2. `Microsoft.AspNet.WebApi.OwinSelfHost`.
Once you have that, you can delete the old Global.asax. Feeling better, right? 

Also, you'll need [.NET 4.6.2](https://www.microsoft.com/en-us/download/details.aspx?id=53344) but I guess you have that already.
At the time of running this deep dive, Application Insights was running free in its Basic Tier.
[Detailed information about pricing](https://azure.microsoft.com/en-gb/pricing/details/application-insights/)

Cool, let's get started.

# Application Insights

Application Insights is the fastest way I know to get telemetry information out of your applications. It supports multiple languages and is hosted in Azure. Using it is as easy as installing `Microsoft.ApplicationInsights.Web` deploying your Application Insights component in Azure, grabbing your `Instrumentation Key` and adding it to your Api. If you are wondering, yes, it could also help you monitoring Windows Services or other kind of applications. They'll just need access to the internet to send that data through.

It could serve you as a handy tool if you don't have any monitoring in place, or if you want to extends the functionalities of your open source stack (Low Data Retition Policy in ELK? Lack of DevOps support to your metric cluster? Serve yourself, there you go).

In this exercise we'll use it with Owin as it's not as straight forward.
Owin uses MiddleWare, so we'll need to build our own middleware to speak to Application Insights, HA! Luckily, Marcin Budny has done this work for us open sourcing a really nice extension [Here]( https://github.com/marcinbudny/applicationinsights-owinextensions "owinextension-applicationinsight"). Totally recommended. 

# Architecture of the system that we want to monitor

On this exercise we'll not cover (for the time being) how to host your Infrastructure. 
Here is how our system behaves. If you look at the code, you'll realise that it abuse from static Services that aren't being tested.
The design serves a second purpose which is run a refactor session (to be scheduled).
 
![App Insight Architecture that we are about to monitor](https://dl.dropboxusercontent.com/u/24713287/blog/researchs/appinsight-owin-deepdive/AppInsightOwinDeepDive.jpg)
