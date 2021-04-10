using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene3x3()
    {
        SceneManager.LoadScene("3x3");
    }
    public void LoadScene4x4()
    {
        SceneManager.LoadScene("4x4");
    }
    public void LoadScene5x5()
    {
        SceneManager.LoadScene("5x5");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
