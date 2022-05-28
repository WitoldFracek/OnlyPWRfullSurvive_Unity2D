using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameScript : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
