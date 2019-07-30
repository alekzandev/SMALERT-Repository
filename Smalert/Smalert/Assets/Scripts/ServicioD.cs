using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServicioD : MonoBehaviour
{
    public Text coordenadaTxt;

    public InputField nombre;
    public InputField documento;
    public InputField telefono;
    public InputField email;
    public InputField edad;
    public Dropdown tipodiscapacidad;
    public InputField responsable;
    public InputField telefonoresponsable;
    public InputField direccion;

    private void Start()
    {
        // turn on location services, if available 
        Input.location.Start();
    }

    public void Envio()
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

    string url = "http://www.inteligenciafutura.com/api/AltaUsuario.php";
        WWWForm form = new WWWForm();
        form.AddField("nombre", nombre.text);
        form.AddField("documento", documento.text);
        form.AddField("telefono", telefono.text);
        form.AddField("email", email.text);
        form.AddField("edad", edad.text);
        form.AddField("tipodiscapacidad", tipodiscapacidad.value);
        form.AddField("responsable", responsable.text);
        form.AddField("telefonoresponsable", telefonoresponsable.text);
        form.AddField("direccion", direccion.text);
        form.AddField("coordenada", coordenadaTxt.text);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            if(www.text == "new")
            {
                SceneManager.LoadScene("discapacidad");
            }
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

}
