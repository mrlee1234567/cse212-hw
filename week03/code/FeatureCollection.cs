using System.Collections;
using System.Text.Json;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
    // on those classes so that the call to Deserialize above works properly.

    public Feat[] Features { get; set; }

}

public class Feat
{
    public Prop Properties { get; set; }
    public class Prop
    {
        public double Mag { get; set; }
        public string Place { get; set; }
    }
}

/*

eg:
{
    "type":"Feature",
    "properties":
    {
        "mag":1.18,
        "place":"4 km W of Mammoth Lakes, CA",
        "time":1789516675120,
        "updated":1789516770248,
        "tz":null,
        "url":"https://earthquake.usgs.gov/earthquakes/eventpage/nc75436297",
        "detail":"https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/nc75436297.geojson",
        "felt":null,
        "cdi":null,
        "mmi":null,
        "alert":null,
        "status":"automatic",
        "tsunami":0,
        "sig":21,
        "net":"nc",
        "code":"75436297",
        "ids":",nc75436297,",
        "sources":",nc,",
        "types":",nearby-cities,origin,phase-data,",
        "nst":10,"dmin":0.002426,"rms":0.02,"gap":119,
        "magType":"md",
        "type":"earthquake",
        "title":"M 1.2 - 4 km W of Mammoth Lakes, CA"
    },
    "geometry":
    {
        "type":"Point",
        "coordinates":[-119.029167175293,37.6404991149902,0.129999995231628]
    },
    "id":"nc75436297"
}

example of result formatting:
1km NE of Pahala, Hawaii - Mag 2.36

*/

/*

classes;


*/