using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public bool start = false;

    #region Private Variables
    private GameObject player;
    private Rigidbody player_rb;
    private Animator playerAnimator;

    [SerializeField]
    private float speed = 10f;
    #endregion

    void Awake()
    {
        player = gameObject;
        player_rb = player.GetComponent<Rigidbody>();
        playerAnimator = player.GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(WaitForAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
            Move();
    }
    
    void Move()
    {
        player_rb.transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    private IEnumerator WaitForAnimation()
    {
        
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);  //the current animation playing. (cheering anim here).
        //animation complete after this;

        start = true;
        playerAnimator.SetBool("Cheering_over", start);
    }
}
