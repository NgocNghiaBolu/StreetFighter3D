using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class HealthyScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;
    public bool is_Player;

    private HealthUI health_UI;

    private ManagerEnemy managerEnemy1;
    private ManagerEnemy2 managerEnemy2;


    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        if (is_Player) 
        { 
            health_UI = GetComponent<HealthUI>();
        }
    }

    void Start()
    {
        managerEnemy1 = ManagerEnemy.instance;
        managerEnemy2 = ManagerEnemy2.instance;

    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;
        health -= damage;

        //display Health UI
        if (is_Player) 
        { 
            health_UI.DisplayHealth(health);
        }

        if (health <= 0f) 
        {
            animationScript.Death();
            characterDied = true;

            // if is player deactivate enemy script
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;

                StartCoroutine(LoadNextSceneAfterDelay(3f, "Loss"));
            }

            else
            {
               // managerEnemy1.EnemyDestroyed1();
                managerEnemy2.EnemyDestroyed();
            }

            return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if (knockDown)
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        animationScript.KnockDown();
                    }
                }
                else
                {
                    if (Random.Range(0, 3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }
         
        }
    }

    IEnumerator LoadNextSceneAfterDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
