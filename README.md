# appinsight-owin-deepdive
Asp.Net 4.6.1 Using Owin and Application Insights

# Warming Up
Before running to Application Insights we need to remember that Owin needs: `Microsoft.AspNet.WebApi.Owin` & `Microsoft.AspNet.WebApi.OwinSelfHost`. Once you have that, you can delete the old Global.asax. Feeling better, right? 

Also, you'll need .NET 4.6.2 but I guess you have that already.

Cool, let's get started.

# Application Insights

Owin uses MiddleWare, so we'll need to build our own middleware to speak to Application Insights, luckily, Marcin Budny has done this work for us open sourcing a really nice extension [Here]( https://github.com/marcinbudny/applicationinsights-owinextensions "owinextension-applicationinsight"). Totally recommended 

# Architecture of the system that we want to monitor

On this exercise we'll not cover (for the time being) how to host your Infrastructure. 
 
![App Insight Architecture that we are about to monitor](https://dl.dropboxusercontent.com/u/24713287/blog/researchs/appinsight-owin-deepdive/AppInsightOwinDeepDive.jpg)
