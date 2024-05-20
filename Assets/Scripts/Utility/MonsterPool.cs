using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject testMap;
    private Transform[] spawnPoint;
    // �� ���� �ֱ�, ����, �ִ� ����
    // TODO:: ���������� ���� ���� �����ϵ���
    public float spawnTime;
    public int enemiesPerSpawn;
    private int currentEnemies = 0;
    

    private void Start()
    {
        // �̸� ������ ���� ��ġ���� �޾ƿ�
        spawnPoint = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        
        // ���ÿ� �����Ǵ� ���� ��
        // TODO:: ���������� ���� ������ �� �ֵ����ϱ�
        //enemiesPerSpawn = 5;

        StartCoroutine(SpawnMonster(pools.Count));
    }
    
    // TODO :: ���� ����ó���� �ٸ� ������ ��
    // TODO :: ���� �� �ڷ�ƾ ���       
    IEnumerator SpawnMonster(int count)
    {
        while (true)
        {
            // ���� �ð����� ����
            yield return new WaitForSeconds(spawnTime);

            for (int i = 0; i < enemiesPerSpawn; i++)
            {             
                GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
                monster.transform.position = ReturnRandomPos();
                currentEnemies++;
            }
        }
    }

    // ���͸� ������ ��ġ�� �����ϱ� ���� ���� ��ġ�� �޾ƿ��� �Լ�
    // 1. �� �ݶ��̴��� �����ͼ� x, y ������ ����
    // 2. �߾���ġ�� -(����/2) ~ (����/2) ���� ���ؼ� ������ ��ġ�� �����ǵ���

    // TODO :: 3. ����� ������ �����ǵ��� ���� �����ϱ�
    // ���� ����Ʈ ����?
    public Vector2 ReturnRandomPos()
    {        
        int index = Random.Range(1, spawnPoint.Length);
        Vector2 randomPos = new Vector2(spawnPoint[index].position.x, spawnPoint[index].position.y);
        
        return randomPos;
    }
}
