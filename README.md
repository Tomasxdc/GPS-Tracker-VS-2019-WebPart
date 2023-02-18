#GPS-Tracker-VS2019-WebPart
#GPS Tracker - Visual Studio 2019
#
#You need to download and setup MySQL database link: https://www.mysql.com/ 
#You need ASP.NET Core, database extension in your visual studio 2019
#
#How to start project
#1) open cmd on your computer and write ipconfig, check your IPv4 address (example: 192.168.0.155)
#
#2) open control panel ->system and secure -> system -> refine the system settings ->environmental variables -> you should see ASPNETCORE_URLS if you set it up ->
#  double click on it -> change IPv4 with your actual IPv4 (example: http://192.168.0.155:80;https://192.168.0.155:443
#  
#3) open gpska.sln (in visual studio 2019) -> click up on "set" -> publish a gpska item -> publish (FolderProfile.pubxml) -> open folder (in green rectangle)
#  -> double click on gpsapka (.exe) 
#  
#4) open browser -> type your IPv4 address up -> search -> You should see google map and date with lng, lat
#
#
#What i used
#1) MySQL database
#2) MVC architecture
#3) Entity framework
#4)Web API with ASP.NET Core
