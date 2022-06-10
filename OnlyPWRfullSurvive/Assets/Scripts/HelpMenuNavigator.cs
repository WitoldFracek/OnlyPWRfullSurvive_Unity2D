using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenuNavigator : MonoBehaviour
{
    public void OpenHelpSlideShow()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
