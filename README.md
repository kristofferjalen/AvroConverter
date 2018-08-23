# AvroConverter  

.NET library to convert from Apache Avro to JSON.

## Example Usage

```csharp
var fileInfo = new System.IO.FileInfo(path);
var json = AvroConvert.ToJson(fileInfo);
```