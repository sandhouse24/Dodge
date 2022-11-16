using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;//생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;//최소 생성 주기
    public float spawnRateMax = 3f;//최대 생성 주기
    private Transform target;//발사할 대상
    private float spawnRate;
    private float timeAfterSpawn;//최근 생성 시점에서 지난 시간, 타이머 역할
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);//생성된 bullet의 정면 방향이 target을 향하도록 회전
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
