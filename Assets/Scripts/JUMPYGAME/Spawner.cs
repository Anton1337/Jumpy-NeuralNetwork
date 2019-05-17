using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float spawnTimer = 2f;
    private bool canSpawn = true;

    private void Update()
    {
        if (canSpawn)
        {
            Instantiate(_enemy, transform.position, Quaternion.identity);
            canSpawn = false;
            StartCoroutine(ResetSpawn());
        }
    }
    IEnumerator ResetSpawn()
    {
        yield return new WaitForSeconds(spawnTimer);
        canSpawn = true;
    }
}
