# Project Description

This is a platform that will ultimately allow new/upcoming and established electronic music producers
to sell their unlicensed / unsigned single tracks & EP's for a fixed price.

You can either sell or offer your tracks for free in which case the "buyer" would have to either follow you on social media or
comment / provide feedback / rate your release in order to get the download link for the full lossless audio file.

# Requirements

. Visual Studio 2019 (w/ Latest updates installed)
. NodeJS with npm/yarn packages installed globally
. Vue CLI & Vue CLI Service

# Installation Steps

. Select CollectiveSound.Web.Api as the default project
. Open the Nuget Package Manager Console, select the project CollectiveSound.EntityFramework and run the command "update-database"
. Run the project with F5 (it will go straight to the swagger api documentation page)
. Open up your terminal on the CollectiveSound.Web.UI folder
  . Run yarn install
  . Run yarn serve
  . Open a new browser tab and go to http://localhost:8080
  . The admin credentials are admin/123qwe
