using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneData
{
    
    public int CountOfActions;
    public float[] position;

    public SceneData(GameManager gameManager)
    {
        
        CountOfActions = gameManager.CountofActions;
        position = new float[gameManager.cubes.Length*3];
        for (int i = 0; i < (gameManager.cubes.Length)*3; i+=3)
        {
            position[i] = gameManager.cubes[i/3].GetComponent<Transform>().position.x;
            position[i+1] = gameManager.cubes[i/3].GetComponent<Transform>().position.y;
            position[i+2] = gameManager.cubes[i/3].GetComponent<Transform>().position.z;
        }
    }

}
