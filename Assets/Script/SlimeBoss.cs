using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeBoss : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private int bossHealth = 100;
    [SerializeField]
    private int bossResistance = 5;
    [SerializeField]
    private float spawnEnemyDelay = 5f;
    [SerializeField]
    private float suckingForce = 10;
    [SerializeField]
    private float suckingDelay = 3f;
    [Space]
    [SerializeField]
    private SpawnPoint[] spawnPoints;

    [Header("References")]
    [SerializeField]
    private GameObject slimePrefab;

    private BossPhase currentBossPhase = BossPhase.Peaceful;

    private int currentBossHealth;

    private float currentEnemyDelay;

    private float currentSuckingDelay;

    private Player _player;

    [Serializable]
    public class SpawnPoint
    {
        [HideInInspector]
        public GameObject occupied;
        public Transform transform;
    }

    public enum BossPhase
    {
        Peaceful,
        Angry,
        Dead
    }

    private IEnumerator Start()
    {
        _player = FindObjectOfType<Player>();

        currentBossHealth = bossHealth;

        while (true)
        {
            switch (currentBossPhase)
            {
                case BossPhase.Peaceful:
                    //IDLE
                    break;
                case BossPhase.Angry:
                    SpawnEnemies();
                    Suck();
                    break;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("mage"))
        {
            Destroy(other.gameObject);
            ReceivedDamage();
        }
    }

    private void ReceivedDamage()
    {
        currentBossHealth -= bossResistance;

        currentBossHealth = Mathf.Clamp(currentBossHealth, 0, bossHealth);

        if (currentBossHealth <= 0)
        {
            BossDeath();
            return;
        }

        if (currentBossHealth <= bossHealth * 1f &&
            currentBossHealth >= bossHealth * 0.75f)
        {
            currentBossPhase = BossPhase.Peaceful;
        }
        else if (currentBossHealth <= bossHealth * 0.75f &&
                 currentBossHealth >= bossHealth * 0.25f)
        {
            currentBossPhase = BossPhase.Angry;
        }
    }

    private void BossDeath()
    {
        currentBossPhase = BossPhase.Dead;

        for (var i = 0; i < spawnPoints.Length; i++)
        {
            Destroy(spawnPoints[i].occupied);
        }

        //FAZ ALGO QUANDO O BOSS MORRER
        SceneManager.LoadScene("Agradecimentos");
    }

    private void SpawnEnemies()
    {
        currentEnemyDelay += Time.deltaTime;

        if (currentEnemyDelay >= spawnEnemyDelay)
        {
            currentEnemyDelay = 0;

            SpawnPoint freeSpawnPoint = null;

            foreach (var spawnPoint in spawnPoints)
            {
                if (spawnPoint.occupied == null)
                {
                    freeSpawnPoint = spawnPoint;
                    break;
                }
            }

            if (freeSpawnPoint == null)
            {
                return;
            }

            freeSpawnPoint.occupied = Instantiate(slimePrefab, freeSpawnPoint.transform.position, Quaternion.identity, null);
        }
    }

    private void Suck()
    {
        currentSuckingDelay += Time.deltaTime;

        if (currentSuckingDelay >= suckingDelay)
        {
            currentSuckingDelay = 0f;

            var direction = transform.position - _player.transform.position;

            _player.rigidbody.AddForce(direction * suckingForce * Time.deltaTime, ForceMode2D.Impulse);

            StartCoroutine(BossShrink()); //SUBSTITUIR POR ANIMAÇÃO
        }
    }

    private IEnumerator BossShrink()
    {
        var startScale = transform.localScale;
        transform.localScale -= transform.localScale * 0.75f;

        yield return new WaitForSeconds(0.5f);

        transform.localScale = startScale;
    }
}