# AZURE FUNCTION - Integrate with Azure Queue Storage 

**Azure Queue Storage** provides a simple cost-effective queueing solution for handling large volumes of messages. Storage Queues allow asynchronous communication between different applications. This allows to decouple components, build resilience and also scale for bursts of traffic.

**Azure Functions** provide serverless compute for Azure. It allows us to focus on the pieces of code that matter most, and Functions handle the rest. They can be used to build web APIs, respond to database changes, process streams, manage message queues, and more. With Azure Functions we write less code, have less infrastructure to maintain and in turn, we save on cost.


## AZURE QUEUE STORAGE From ASP NET Core

In this project, we will study **Azure Storage Queue**, understand the different concepts while using it from an ASP NET Core Application. We will create a Storage Account and a queue within that. We will send, read and delete messages to the queue from a ASP NET Application. We will use background jobs in asp.net core to read messages from azure queue storage.

### Service Bus

- create a **Service Bus**
<img src="/pictures/service_bus.png" title="service bus"  width="900">


## Azure Functions - Integrate with Azure Queue Storage 

In this project, we will write an Azure Function and understand more about how it works and the different core concepts when using them. We will integrate it with **Azure Queue Storage** and automatically listen for messages dropped to the queue. We will also use **Managed Identity** to authenticate Azure Function with Azure Queue Storage so that we don't need to set up any Secrets or connection strings in code.


### Integrate with Azure Queue Storage
