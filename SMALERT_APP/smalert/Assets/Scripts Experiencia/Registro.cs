using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registro : MonoBehaviour
{
    public InputField nombres;
    public InputField edad;
    public InputField celular;
    public InputField nombre_responsable;
    public InputField cel_responsable;
    public InputField comentarios;
    public Dropdown tipo_discapacidad;
    public InputField ciudad;
    public InputField direccion;

    public void Guardar()
    {
        string url = "http://www.inteligenciafutura.com/App/registro.php";
        WWWForm form = new WWWForm();
        form.AddField("nombres", nombres.text);
        
        form.AddField("edad", edad.text);
        form.AddField("celular", celular.text);
        form.AddField("nombre_responsable", nombre_responsable.text);
        form.AddField("cel_responsable", cel_responsable.text);
        form.AddField("comentarios", comentarios.text);
        form.AddField("tipo_discapacidad", tipo_discapacidad.value);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            if (www.text == "Ok")
            {
                BD.instancia.GuardarRegistro(celular.text);
                SceneManager.LoadScene("Geolocalizacion");
            }
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
