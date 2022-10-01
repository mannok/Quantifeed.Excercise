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

you may open SSMS and connect to 127.0.0.1,14330 with "sa" and "P@ssw0rd" to see data stored in db

# Performance Care Efforts

- dockerized system. If user/request volumn grow later, it could be integrated with K8s/docker-swarm to ensure unlimited system/performance scalability [db will still be a bottleneck. Ultimately, we could break down whole system with db by service domain, a.k.a. microservices]
- table field indexing. Ensure records are well indexed for further query requests
- entity related entity lazy loading. Currently, related(foriegn) entity is marked "virtual". which means the related entities' properties will be query just in time when being accessed
- try to keep DI component as singleton if possible. To keep high performance, I marked "IBasketAppService" as singleton so that it will not be instantiated every time when user request. This same approach will be taken for any further registration to DI
- try to use async/await method if possible. I try to use and make function with async/await pattern if possible. async/await can avoid thread blocking and wasting computing resource

# Possible Performance Solutions

- break system and db down by service domain in order to achieve microservices
- use redis to store and take ongoing system caches
- reindex db regularly