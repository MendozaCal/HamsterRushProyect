using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PositionManager : MonoBehaviour
{
    public float[] car_position;
    public GameObject player;
    public float playerPosition;
    public GameObject[] NPC;
    public int currentPos;
    public int currentPoint;
    public TextMesh posText;
    // Update is called once per frame
    void Update()
    {
        //PositionCalc();
        posText.text = currentPos.ToString() + " / " + car_position.Length;
    }
    /*public void PositionCalc()
    {
        car_position[0] = player.GetComponent<PlayerController>().playerDistance;
        car_position[1] = NPC[0].GetComponent<NPCroute>().NPCDistance;
        car_position[2] = NPC[1].GetComponent<NPCroute>().NPCDistance;
        car_position[3] = NPC[2].GetComponent<NPCroute>().NPCDistance;
    
        playerPosition = player.GetComponent<PlayerController>().playerDistance;

        Array.Sort(car_position);

        int x = Array.IndexOf(car_position, playerPosition);

        switch (x)
        {
            case 0:
                currentPos = 1; 
                break;
            case 1:
                currentPos = 2;
                break;
            case 2:
                currentPos = 3;
                break;
            case 3:
                currentPos = 4;
                break;
        }
    }*/
}
