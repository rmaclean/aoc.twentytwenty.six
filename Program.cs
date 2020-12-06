using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var fileRecords = new List<String>();
var fileData = await File.ReadAllLinesAsync("data.txt");
var currentGroup = "";
foreach (var line in fileData)
{
    if (!string.IsNullOrWhiteSpace(line)) {
        currentGroup += line.Trim();
    } else {
        fileRecords.Add(currentGroup);
        currentGroup = "";
    }
}

fileRecords.Add(currentGroup);

var result = fileRecords
    .Select(line => line.Distinct().Count())
    .Sum();

Console.WriteLine(result);
