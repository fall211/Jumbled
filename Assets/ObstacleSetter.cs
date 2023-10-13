using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetter : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private List<GameObject> obstacles = new List<GameObject>();

    private void Start(){
        SetObstacles(10);
    }

    private void SetObstacle(){
        Vector3 pos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        GameObject obstacle = Instantiate(obstaclePrefab, pos, Quaternion.identity);
        obstacles.Add(obstacle);
    }

    public void SetObstacles(int amount){
        ClearObstacles();
        for (int i = 0; i < amount; i++){
            SetObstacle();
        }
        // Debug.Log(obstacles.Count);
    }

    private void ClearObstacles(){
        foreach (GameObject obstacle in obstacles){
            Destroy(obstacle);
        }
        obstacles.Clear();
    }

}
