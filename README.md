# Introduction

this is the exercise done by Xanthus Wong for Quanifeed post application.

# Prerequisite

- docker installed
- vs2022 installed
- .NET6 SDK intalled

# Test Procedure

1. open Quantifeed.Excercise with vs2022
2. set configuration to "Release"
3. set docker-compose as startup project
4. start docker-compose with "Start Without Debugging (ctrl + F5)"
5. once docker-compose is started up, switch startup project to Quantifeed.Excercise.Migrator
6. start Quantifeed.Excercise.Migrator with "Start Without Debugging (ctrl + F5)"
7. enter "Y" when asked to migrate
8. (repeat step 3)
9. (repeat step 4)
10. open "Test Explorer" window in vs2022
11. navigate to "OrderAppService_Test" -> right click -> Run

# Hints

you may Open SSMS and connect to 127.0.0.1,14330 with "sa" and "P@ssw0rd" to see data stored in db