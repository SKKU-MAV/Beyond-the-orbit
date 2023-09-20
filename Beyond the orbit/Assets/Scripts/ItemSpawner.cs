using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] items;        // ������ ������ �迭
    [SerializeField] Transform[] spawnPositions = new Transform[3];     // ������ ���� ��ġ
    [SerializeField] float minSpawnT;       // �ּ� ���� �ð�
    [SerializeField] float maxSpawnT;       // �ִ� ���� �ð�
    float timeBetSpawn;     // ������ ���� ��Ÿ��
    float lastSpawnTime;    // ���������� �������� ������ �ð�
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0;      // �ʱ�ȭ
        timeBetSpawn = Random.Range(minSpawnT, maxSpawnT);      // ������ ���� ��Ÿ�� ���ϱ�
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
