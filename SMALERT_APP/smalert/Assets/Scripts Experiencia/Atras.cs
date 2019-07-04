using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Atras : MonoBehaviour
{
    public void AtrasBack()
    {
        SceneManager.LoadScene("Geolocalizacion");
    }
}
