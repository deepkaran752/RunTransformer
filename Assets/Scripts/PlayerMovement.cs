using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    #region Public Vars
    public GameObject currentActive;
    public float speed = 10f;
    public GameManager _gM;
    #endregion

    #region Pvt Vars
    private int childCount;
    #endregion

    void Start()
    {
        childCount = gameObject.transform.childCount;
    }

    void Update()
    {
        currentActive = CurrentActive();
        Move(speed);
    }
    #region Created Func
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
    #endregion
}
