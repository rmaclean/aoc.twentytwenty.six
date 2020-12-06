using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var groups = new List<List<String>>();
var fileData = await File.ReadAllLinesAsync("data.txt");
var currentGroup = new List<String>();
foreach (var line in fileData)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        currentGroup.Add(line.Trim());
    }
    else
    {
        groups.Add(currentGroup);
        currentGroup = new List<String>();
    }
}

groups.Add(currentGroup);

var result = groups.Select(group => {
    var everyoneAnsweredYesTo = group[0];
    for (var index = 1; index < group.Count; index++)
    {
        var person = group[index];
        var intesection = person.Intersect(everyoneAnsweredYesTo).ToArray();
        if (intesection.Length > 0) 
        {
            everyoneAnsweredYesTo = new string(intesection);
        } else {
            everyoneAnsweredYesTo = "";
            break;
        }
    }

    return everyoneAnsweredYesTo.Length;
}).Sum();

Console.WriteLine(result);