using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
