using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarcarNumero : MonoBehaviour
{
    public GameObject ventanaEmergente;
    public void llamarOpciones()
    {
        ventanaEmergente.SetActive(true);
    }

    public void ocultarOpciones()
    {
        ventanaEmergente.SetActive(false);
    }

    public void Marcar()
    {
        Application.OpenURL("tel://3005399011");
    }

    public void MarcarEmergencias()
    {
        Application.OpenURL("tel://123");
    }

    public void verAyudas()
    {
        SceneManager.LoadScene("tutoriales");
    }

}
