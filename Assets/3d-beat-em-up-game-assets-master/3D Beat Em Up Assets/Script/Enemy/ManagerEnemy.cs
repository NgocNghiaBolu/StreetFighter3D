using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEnemy : MonoBehaviour
{
    public static ManagerEnemy instance;
    [SerializeField]
    private GameObject enemyPrefab;
    private int enemiesSpawned = 0;
    private int enemiesDestroyed = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemiesSpawned++;
    }

    public void EnemyDestroyed1()
    {
        enemiesDestroyed++;
        Debug.Log(enemiesDestroyed);

        if (enemiesDestroyed >= 1)
        {
            StartCoroutine(LoadWinScene(2f, "Win"));
        }
        else
        {

            SpawnEnemy();
        }

    }

    IEnumerator LoadWinScene(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

