# AvroConverter  

.NET library to convert from Apache Avro to JSON.

## Installation

```powershell
PM> Install-Package AvroConverter
```

## Example Usage

Convert a file.

```csharp
var fileInfo = new System.IO.FileInfo(path);
var json = AvroConvert.ToJson(fileInfo);
```

## License

This library is provided free of charge, under the terms of the [MIT license](https://raw.githubusercontent.com/kristofferjalen/avroconverter/master/LICENSE).