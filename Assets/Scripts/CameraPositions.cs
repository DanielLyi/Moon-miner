using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    [SerializeField] Vector3[] positions = new Vector3[3];
    [SerializeField] GameObject camera;
    [SerializeField] GameObject[] rooms = new GameObject[3];
    [SerializeField] int currentIndex = 1;
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != currentIndex)
            {
                rooms[i].transform.Translate(0, 20000f, 0);
            }
        }
    }

    public void MoveRight()
    {
        if (currentIndex < 2)
        {
            rooms[currentIndex].transform.Translate(0, 20000f, 0);
            currentIndex++;
            rooms[currentIndex].transform.Translate(0, -20000f, 0);
            camera.transform.position = positions[currentIndex];
            rightButton.SetActive(currentIndex != 2);
            leftButton.SetActive(currentIndex != 0);
        }
    }

    public void MoveLeft()
    { 
        if(currentIndex > 0) {
            rooms[currentIndex].transform.Translate(0, 20000f, 0);
            currentIndex--;
            rooms[currentIndex].transform.Translate(0, -20000f, 0);
            camera.transform.position = positions[currentIndex];
            leftButton.SetActive(currentIndex != 0);
            rightButton.SetActive(currentIndex != 2);
        }
    }

}
