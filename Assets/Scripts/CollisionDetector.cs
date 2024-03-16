using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject _player;
    public GameObject GameOver;
    public GameObject ChangerButtons;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangerButtons.SetActive(false);
            GameOver.SetActive(true);
            gameOver = true;
        }
    }
}
