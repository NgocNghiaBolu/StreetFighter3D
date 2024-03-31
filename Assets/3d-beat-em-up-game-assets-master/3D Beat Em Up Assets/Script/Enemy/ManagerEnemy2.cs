using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEnemy2 : MonoBehaviour
{
    public static ManagerEnemy2 instance;
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
        SpawnEnemy2();
    }

    public void SpawnEnemy2()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemiesSpawned++;
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        Debug.Log(enemiesDestroyed);

        if (enemiesDestroyed >= 4)
        {
            StartCoroutine(LoadWinScene(3f, "Win"));
        }
        else
        {
            SpawnEnemy2();
        }

    }

    IEnumerator LoadWinScene(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
