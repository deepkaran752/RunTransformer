using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingTransform : MonoBehaviour
{
    #region Pvt Vars
    [SerializeField]
    private EnemyAI[] enemyAIs;

    [SerializeField]
    private GameManager _gM;

    private Coroutine[] transitionCoroutines;
    #endregion
    #region Public vars
    public string currentOBJName = "";
    #endregion
    // Start is called before the first frame update
    #region UnitydefinedFunctions
    void Start()
    {
        currentOBJName = "Player";
        _gM.GetSpeedForEnemy(currentOBJName);
    }

    // Update is called once per frame
    void Update()
    {
        _gM.GetSpeedForEnemy(currentOBJName);
    }
    #endregion
    #region Private Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            if (other.CompareTag("AI"))
            {
                // Initialize the transition coroutine array
                transitionCoroutines = new Coroutine[enemyAIs.Length];

                for (int i = 0; i < enemyAIs.Length; i++)
                {
                    // Perform transition for each EnemyAI object
                    transitionCoroutines[i] = StartCoroutine(PerformTransition(enemyAIs[i]));
                }
            }
        }

    }

    private IEnumerator PerformTransition(EnemyAI enemyAI)
    {
        GameObject activeChild = null;
        GameObject targetChild = null;

        //active and target
        for (int i = 0; i < enemyAI.transform.childCount; i++)
        {
            Transform child = enemyAI.transform.GetChild(i);
            GameObject childObject = child.gameObject;
            if (childObject.activeSelf)
            {
                activeChild = childObject;
            }
            else
            {
                targetChild = childObject;
            }
        }

        if (activeChild != null && targetChild != null)
        {
            yield return new WaitForSeconds(1.0f);

            // Deactivate
            activeChild.SetActive(false);

            // Activate
            currentOBJName = targetChild.name;
            targetChild.SetActive(true);
        }
    }
    #endregion
}
