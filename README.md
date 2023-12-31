# AZURE FUNCTION - Integrate with Azure Queue Storage 

**Azure Queue Storage** provides a simple cost-effective queueing solution for handling large volumes of messages. Storage Queues allow asynchronous communication between different applications. This allows to decouple components, build resilience and also scale for bursts of traffic.

**Azure Functions** provide serverless compute for Azure. It allows us to focus on the pieces of code that matter most, and Functions handle the rest. They can be used to build web APIs, respond to database changes, process streams, manage message queues, and more. With Azure Functions we write less code, have less infrastructure to maintain and in turn, we save on cost.


## AZURE QUEUE STORAGE From ASP NET Core

In this project, we will study **Azure Storage Queue**, understand the different concepts while using it from an ASP NET Core Application. We will create a Storage Account and a queue within that. We will send, read and delete messages to the queue from a ASP NET Application. We will use background jobs in asp.net core to read messages from azure queue storage.

### Queue

- create a storage account

- in the *Queues* section of the storage account, create a queue
<img src="/pictures/queue.png" title="queue storage account"  width="900">

- add packages
```
Azure.Storage.Queues
Microsoft.Extensions.Azure
```

### .NET project

- in the *Access Keys* section, grab the connection string and use it in the project
<img src="/pictures/queue2.png" title="queue storage account"  width="500">

- run the project and send messages. See it show up in the storage queue
<img src="/pictures/queue3.png" title="queue storage account"  width="900">

### Read and delete messages

In this section, we will use background jobs

- create a managed identity. Don't forget to check you identity for Azure
<img src="/pictures/identity.png" title="background jobs"  width="900">

- add a role for the user
<img src="/pictures/identity2.png" title="background jobs"  width="900">

- run the app and see the messages disappearing as long as you create them
<img src="/pictures/identity3.png" title="background jobs"  width="900">
<img src="/pictures/identity4.png" title="background jobs"  width="900">


## Azure Functions - Integrate with Azure Queue Storage 

In this project, we will write an Azure Function and understand more about how it works and the different core concepts when using them. We will integrate it with **Azure Queue Storage** and automatically listen for messages dropped to the queue. We will also use **Managed Identity** to authenticate Azure Function with Azure Queue Storage so that we don't need to set up any Secrets or connection strings in code.

### Azure Function

- create an azure function. Choose *Queue Trigger*
<img src="/pictures/af.png" title="azure function"  width="900">

- run the app and see the azure function retrieve the messages
<img src="/pictures/af2.png" title="azure function"  width="900">

- in the settings, you can provide the maximum number of times a message that resulted into an exception can be requeued
<img src="/pictures/af3.png" title="azure function"  width="900">

### Azure Function

- in the azure function project, add package
```
Microsoft.Azure.WebJobs.Extensions.Storage
```

- run the app, it should work as well as before

### Publish the app

- choose windows
<img src="/pictures/publish.png" title="publish app"  width="500">

- create a function app
<img src="/pictures/publish2.png" title="publish app"  width="500">

- create a storage account
<img src="/pictures/publish3.png" title="publish app"  width="500">

- publish and see the function app created
<img src="/pictures/publish4.png" title="publish app"  width="500">

### Manage Identity

- in the *Identity* section, turn on system assigned
<img src="/pictures/af_identity.png" title="manage identity"  width="900">

- for *alexeiqueuestorage*, add the *Storage Queue Data Contributor* role
<img src="/pictures/af_identity2.png" title="manage identity"  width="900">

- in the *Configuration* section, add the connection string key and value
<img src="/pictures/af_identity3.png" title="manage identity"  width="900">

- run you local API, and post messages. You should see the messages land in the azure function
<img src="/pictures/af_identity4.png" title="manage identity"  width="900">