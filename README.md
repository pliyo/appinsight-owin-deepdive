# appinsight-owin-deepdive
Asp.Net 4.6.1 Using Owin and Application Insights

# Warming Up
Before running to Application Insights we need to remember that Owin needs: `Microsoft.AspNet.WebApi.Owin` & `Microsoft.AspNet.WebApi.OwinSelfHost`. Once you have that, you can delete the old Global.asax. Feeling better, right? 

Cool, let's get started.

# Application Insights

Owin uses MiddleWare, so we'll need to build our own middleware to speak to Application Insights, luckily, Marcin Budny has done this work for us open sourcing a really nice extension [Here]( https://github.com/marcinbudny/applicationinsights-owinextensions "owinextension-applicationinsight"). Totally recommended 
