# AvroConverter  

.NET library to convert from Azure Event Hubs Archive Apache Avro files to JSON files.

Azure Event Hubs Archive enables you to automatically deliver the streaming data in your Event Hubs to a Blob storage account. Once configured, Event Hubs Archive creates files in the Azure Storage account and container. You can explore these Avro files with the following procedure.

1. [Enable](https://azure.microsoft.com/en-us/documentation/articles/event-hubs-archive-overview/#setting-up-event-hubs-archive) Event Hubs Archive.
2. Use [Microsoft Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/) to connect to the storage account and download the Blob container.

## Installation

```powershell
PM> Install-Package AvroConverter
```

## Example Usage

Convert a file.

```csharp
var path = @"C:\avro\30\01\45\59.avro";
var fileInfo = new System.IO.FileInfo(path);
var json = AvroConvert.ToJson(fileInfo);
```

## License

This library is provided free of charge, under the terms of the [MIT license](https://raw.githubusercontent.com/kristofferjalen/avroconverter/master/LICENSE).