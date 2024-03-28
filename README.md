# JourneyMentorTest

To run the project please once you clone the repo go to the main folder and execute the next command

```c
docker-compose up --build
```

This will create 4 containers:

  - mysql-journey (database)
  - flight-service (http://localhost:8088/flightservice/swagger/index.html)
  - airport-service (http://localhost:8089/airportservice/swagger/index.html)
  - orchestration-service (http://localhost:8090/orchestration/swagger/index.html)
