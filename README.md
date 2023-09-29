## Tedu AspnetCore Microservices:


## Prepare environment

* Install dotnet core version in file `global.json`
* IDE: Visual Studio 2022+, Rider, Visual Studio Code
* Docker Desktop

## How to run the project

Run command for build project
```Powershell
dotnet build
```
Go to folder contain file `docker-compose`

1. Using docker-compose
```Powershell
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans
```

## Application URLs - LOCAL Environment (Docker Container):


## Docker Application URLs - LOCAL Environment (Docker Container):
- Portainer: http://localhost:9000 - username: admin ; pass: "{your-password}"
- Kibana: http://localhost:5601 - username: elastic ; pass: admin
- RabbitMQ: http://localhost:15672 - username: guest ; pass: guest

2. Using Visual Studio 2022
- Open aspnetcore-microservices.sln - `aspnetcore-microservices.sln`
- Run Compound to start multi projects
---
## Application URLs - DEVELOPMENT Environment:

---
## Application URLs - PRODUCTION Environment:

---
## Packages References

## Install Environment

- https://dotnet.microsoft.com/download/dotnet/6.0
- https://visualstudio.microsoft.com/

## References URLS
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
- https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-6.0
- https://github.com/ThreeMammals/Ocelot
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/httpclient-message-handlers
- https://github.com/dotnet-architecture/eShopOnContainers

## Docker Commands: (cd into folder contain file `docker-compose.yml`, `docker-compose.override.yml`)

- Up & running:
```Powershell
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remove-orphans --build
```
- Stop & Removing:
```Powershell
docker-compose down
```

## Useful commands:

- ASPNETCORE_ENVIRONMENT=Production dotnet ef database update
- dotnet watch run --environment "Development"
- dotnet restore
- dotnet build

---
---
## Microservices architecture principles
### 1. A microservices has a single concern
- Should do one thing and one thing only = Single object responsibility
- Easier to maintain and scale

### 2. A microservice is a discrete
- Must clear boudaries separating it from its environment
- Must be well-encapsulated
- Development: Isolated from all other microservices
- Production: It becomes part of a larger application after deployment

### 3. A microservices is transportable
- Can be moved from one runtime environment to another
- Easier to use in an automated or declarative deployment process

### 4. A microservice carries its own data
- Should have its own data storage that is isolated from all other microservices
- Shared with other microservices by a public interface
- The common problem is data redundancy

### 5. A microservice is ephemeral
- It can be created, destroyed, and replenished on demand
- The standard operating expectation is that microservices come and go all the time, sometimes due to system failure and sometimes due to scaling demands

## Microservice communication
### 1. Synchronous protocol
- HTTP/HTTPS
- The client sends a request and waits for a response from the service
- Thread is blocked
- The client code can only continue its task when it receives the HTTP server response.

### 2. Asynchronous protocol
- AMQP (a protocol supported by many OS and cloud environments)
- Asynchronous messages
- The client send message and doesn't wait for a response
- RabbitMQ or Kafka is a message queue

