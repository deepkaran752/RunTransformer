using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //FOR PLAYER
    #region pVT vARIABLES
    [SerializeField]
    private PlayerMovement ps;
    [SerializeField]
    private CollisionDetector cS;

    [SerializeField]
    private GameObject player;
    private Transform playerPos;
    private TMP_Text buttonText;
    private GameObject targetObject;

    #endregion

    //FOR ENEMY
    #region Pvt Vars
    [SerializeField]
    private EnemyAI[] _aI;
    #endregion
    void Start()
    {
        ps = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            playerPos = player.GetComponent<Transform>();
        }
        targetObject = player.transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform;
        if (targetObject != null)
        {
            GetSpeed(targetObject.name);
        }

        if (cS.gameOver)
        {
            ps.speed = 0f;
            foreach(EnemyAI ai in _aI)
            {
                ai.speed = 0.0f;
            }
        }
    }
    #region Public Funcs for Player
    public void OnButtonClick(Button button)
    {
        buttonText = button.GetComponentInChildren<TMP_Text>();
        Transformation(buttonText.text,ps.CurrentActive());

    }

    public void Transformation(string text, GameObject _currentActive)
    {
        if (_currentActive != null && _currentActive.activeSelf && _currentActive.name != text)
        {
            buttonText.text = _currentActive.name;
            _currentActive.SetActive(false);

#pragma warning disable UNT0008 // Null propagation on Unity objects
            targetObject = player.transform.Find(text)?.gameObject;
#pragma warning restore UNT0008 // Null propagation on Unity objects
            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Target object not found: " + text);
            }
        }
    }
    public void GetSpeed(string playerType)  //bydefault player is Player!
    {
        switch (playerType)
        {
            case "Car":
                ps.speed = 20.0f;
                break;
            case "Plane":
                ps.speed = 40.0f;
                break;
            case "IceCream":
                ps.speed = 5.0f;
                break;
            case "Player":
                ps.speed = 10.0f;
                break;
            default:
                Debug.LogError("Invalid player type: " + playerType);
                break;
        }
    }
    #endregion

    #region Public Funcs for Enemy
    public void GetSpeedForEnemy(string enemyType)
    {
        foreach (EnemyAI ai in _aI)
        {
            switch (enemyType)
            {
                case "Car":
                    ai.speed = 20.0f;
                    break;
                case "Plane":
                    ai.speed = 40.0f;
                    break;
                case "IceCream":
                    ai.speed = 5.0f;
                    break;
                case "Player":
                    ai.speed = 10.0f;
                    break;
                default:
                    Debug.LogError("Invalid player type: " + enemyType);
                    break;
            }
        }
    }
    #endregion
}
