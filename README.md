# AnnouncementsAPI
The easiest way to run is to use Docker:

With Docker running, from the solution folder (top level) run

    docker build -f AnnouncementsAPI/Dockerfile . -t announcementsapi

Then 

    docker run -p 8080:80 announcementsapi

Swagger can be accessed from the browser at

    localhost:8080/swagger
