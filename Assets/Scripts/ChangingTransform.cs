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
    private string currentOBJName = "Player";
    #endregion
    // Start is called before the first frame update
    #region UnitydefinedFunctions
    void Start()
    {
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
                // Initialize the transition coroutine array
                transitionCoroutines = new Coroutine[enemyAIs.Length];

                for (int i = 0; i < enemyAIs.Length; i++)
                {
                    // Perform transition for each EnemyAI object
                    transitionCoroutines[i] = StartCoroutine(PerformTransition(enemyAIs[i]));
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

        if (targetChild != null)
        {
            currentOBJName = targetChild.name;
            _gM.GetSpeedForEnemy(currentOBJName);
        }

        // Wait for a brief delay
        yield return new WaitForSeconds(1.0f);

        // Deactivate active child
        if (activeChild != null)
        {
            activeChild.SetActive(false);
        }

        // Activate target child
        if (targetChild != null)
        {
            targetChild.SetActive(true);
        }
    }
    #endregion
}
