using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{

    public void Ingresar()
    {
        SceneManager.LoadScene("Geolocalizacion"); 
    }

    public void Registrar()
    {
        SceneManager.LoadScene("RegistroFull");
    }
}
