using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocationService : MonoBehaviour
{
    public Text coordenadaTxt;
    public void Start()
    {
        // turn on location services, if available 
        Input.location.Start();
    }

    public void Update()
    {
        

        //Do nothing if location services are not available
        if (Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;



            coordenadaTxt.text = "Depart lat: " + lat + "lon: " + lon;

        }
        else
            coordenadaTxt.text = "gps off";
    }
}
