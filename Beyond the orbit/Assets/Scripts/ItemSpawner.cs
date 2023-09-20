using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;        // 생성할 아이템 배열
    [SerializeField] Transform[] spawnPositions = new Transform[3];     // 아이템 생성 위치
    [SerializeField] float minSpawnT;       // 최소 생성 시간
    [SerializeField] float maxSpawnT;       // 최대 생성 시간
    float timeBetSpawn;     // 아이템 생성 쿨타임
    float lastSpawnTime;    // 마지막으로 아이템을 생성한 시간
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0;      // 초기화
        timeBetSpawn = Random.Range(minSpawnT, maxSpawnT);      // 아이템 생성 쿨타임 정하기
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(minSpawnT, maxSpawnT);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        Vector3 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        spawnPos += Vector3.up * 0.5f;

        GameObject item = Instantiate(items[Random.Range(0, items.Length)], spawnPos, Quaternion.identity);
        Destroy(item, 5f);
    }
}
