using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    // Update is called once per frame
    public void Siguiente()
    {
        SceneManager.LoadScene("Seleccionar");
    }

    public void RegistroDiscapacitado()
    {
        SceneManager.LoadScene("RegistroDiscapacitado");
    }
}
