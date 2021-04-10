using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public Vector3 endPosition;
    public bool Shacked;
    

    public void Shake()
    {
        var startPosition = gameObject.GetComponent<Transform>().localPosition;
            gameObject.GetComponent<Transform>().localPosition =
                Vector3.Lerp(startPosition, endPosition, Time.deltaTime * 1f);
            if (Mathf.Abs(endPosition.x - gameObject.transform.localPosition.x)<0.01f && Mathf.Abs(endPosition.z - gameObject.transform.localPosition.z)<0.01f)
            {
                Shacked = true;
                Debug.Log("shaked");
            }
    }

   

   
    
    // Start is called before the first frame update
    void Start()
    {
        Shacked = false;
        Debug.Log(endPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Shacked == false)
        {
            Shake();
        }
    }

    private void OnMouseDown()
    {
        if (Shacked)
        {
            Debug.Log("Clicked");
            ;
            FindFreeSpot();
        }
    }

    private void FindFreeSpot()
    {
        foreach (var spot in _gameManager.GetComponent<GameManager>().spots)
        {
            if (spot.GetComponent<SpotManager>().occupied == false)
            {
                float distance =
                    Vector3.Distance(this.gameObject.transform.position, spot.gameObject.transform.position);
                if (distance <= 1.7f)
                {
                    this.gameObject.transform.position = spot.transform.position;
                    _gameManager.CountofActions++;
                    _gameManager.VictoryCheck();
                }
            }
        }
    }

    
}
