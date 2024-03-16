using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public GameObject currentActive;
    public float speed = 10f;

    public GameManager _gM;
    private int childCount;
    

    void Start()
    {
        childCount = gameObject.transform.childCount;
    }

    void Update()
    {
        currentActive = CurrentActive();
        Move(speed);
    }

    public GameObject CurrentActive()
    {
        for(int i=0; i<childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.activeInHierarchy)
            {
                return child;
            }
        }

        return null;
    }

    public void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
