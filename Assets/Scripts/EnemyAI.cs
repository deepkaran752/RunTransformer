using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Public Vars
    public int childCount;
    public int childI = 0;
    public GameObject currentAI;
    public GameObject targetAI;
    public float speed = 5.0f;
    public string currentObject = "";
    #endregion

    #region PvtVars
    [SerializeField]
    private GameManager _gM;

    [SerializeField]
    private PlayerMovement _pM;

    private GameObject enemyAI;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject != null)
        {
            enemyAI = this.gameObject;
        }
        currentAI = gameObject.transform.GetChild(0).gameObject;
        currentObject = currentAI.name;
        targetAI = null;
    }
    // Update is called once per frame
    void Update()
    {
        currentAI = CurrentAI();
        transform.Translate(speed * Time.deltaTime * Vector3.forward);    
    }
    #region Public Function
    public GameObject CurrentAI()
    {
        childCount = gameObject.transform.childCount;
        for (int i= 0; i<childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child.activeInHierarchy)
            {
                childI = i;
                return child;
            }
        }
        return null;
     }
    #endregion
}
