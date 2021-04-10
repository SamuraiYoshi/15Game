using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    
    public  GameObject[] spots;
    [SerializeField] public GameObject[] cubes;
    private bool Victory;
    [SerializeField] private GameObject VictoryText;
    public int CountofActions;
    [SerializeField] public GameObject CountofActionsText;

    public List<GameObject> tempSpots = new List<GameObject>();


    public void SaveScene()
    {
        bool isAllShacked = true;
        foreach (var cube in cubes)
        {
            if (cube.GetComponent<CubeManager>().Shacked == false)
                isAllShacked = false;

        }

        if (isAllShacked)
        {
            SaveSystem.SaveScene(this);
            SceneManager.LoadScene("MainMenu");
        }

    }
    
    public void LoadScene()
    {
        bool isAllShacked = true;
        foreach (var cube in cubes)
        {
            if (cube.GetComponent<CubeManager>().Shacked == false)
                isAllShacked = false;

        }

        if (isAllShacked)
        {
            SceneData data = SaveSystem.LoadScene();
            CountofActions = data.CountOfActions;
            for (int i = 0; i < data.position.Length; i += 3)
            {
                Vector3 position;
                position.x = data.position[i];
                position.y = data.position[i + 1];
                position.z = data.position[i + 2];

                cubes[i / 3].GetComponent<Transform>().position = position;
            }
        }
    }
    public void VictoryCheck()
    {
        Victory = true;
        for (int i= 0 ; i< spots.Length-2; i++)
        {
            if (spots[i].GetComponent<SpotManager>().trueOccupied == false)
                Victory = false;
        }
        if (Victory)
            VictoryText.SetActive(true);
        if(Victory==false)
            VictoryText.SetActive(false);
    }

    public void SetEndpositionOnStart()
    {
        for( int i =0; i<spots.Length-1; i++)
            tempSpots.Add(spots[i]);
        foreach (var cube in cubes)
        {
            int i = Random.Range(0, tempSpots.Count - 1);
            cube.GetComponent<CubeManager>().endPosition = tempSpots[i].GetComponent<Transform>().localPosition;
            tempSpots.Remove(tempSpots[i]);
        }
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        CountofActions = 0;
        Victory = false;
        SetEndpositionOnStart();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CountofActionsText.GetComponent<Text>().text = "Count of Actions: " + Convert.ToString(CountofActions);
        
    }
    

}

