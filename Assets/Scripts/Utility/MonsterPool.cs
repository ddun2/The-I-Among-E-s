using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject testMap;
    private Transform[] spawnPoint;
    // 적 생성 주기, 숫자, 최대 숫자
    // TODO:: 스테이지에 따라 변경 가능하도록
    public float spawnTime;
    public int enemiesPerSpawn;
    private int currentEnemies = 0;
    

    private void Start()
    {
        // 미리 지정한 스폰 위치들을 받아옴
        spawnPoint = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        // 동시에 생성되는 적의 수
        // TODO:: 스테이지에 따라 변경할 수 있도록하기
        //enemiesPerSpawn = 5;

        StartCoroutine(SpawnMonster(pools.Count));
    }
    
    // TODO :: 실제 스폰처리는 다른 곳에서 함
    // TODO :: 스폰 시 코루틴 사용       
    IEnumerator SpawnMonster(int count)
    {
        while (true)
        {
            // 일정 시간마다 스폰
            yield return new WaitForSeconds(spawnTime);

            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                //Debug.Log(GameManager.Instance.ObjectPool.pools.);
                if(currentEnemies < pools.Count)
                {
                    GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
                    monster.transform.position = ReturnRandomPos();
                    currentEnemies++;
                }                
            }
        }
    }

    // 몬스터를 랜덤한 위치에 생성하기 위해 랜덤 위치를 받아오는 함수
    // 1. 맵 콜라이더를 가져와서 x, y 범위를 저장
    // 2. 중앙위치에 -(범위/2) ~ (범위/2) 값을 더해서 랜덤한 위치에 생성되도록

    // TODO :: 3. 사방의 문에서 생성되도록 범위 지정하기
    // 스폰 포인트 지정?
    public Vector2 ReturnRandomPos()
    {
        int index = Random.Range(0, spawnPoint.Length);
        Vector2 randomPos = new Vector2(spawnPoint[index].position.x, spawnPoint[index].position.y);
        
        return randomPos;
    }
}
