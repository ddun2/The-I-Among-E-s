using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject testMap;
    private Transform[] spawnPoint;
    private int numberOfEnemiesPerSpawn;

    private void Start()
    {
        // �̸� ������ ���� ��ġ���� �޾ƿ�
        spawnPoint = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        // ���ÿ� �����Ǵ� ���� ��
        // TODO:: ���������� ���� ������ �� �ֵ����ϱ�
        numberOfEnemiesPerSpawn = 5;

        StartCoroutine(SpawnMonster(pools.Count));
    }
    
    // TODO :: ���� ����ó���� �ٸ� ������ ��
    // TODO :: ���� �� �ڷ�ƾ ���       
    IEnumerator SpawnMonster(int count)
    {
        while (true)
        {
            for (int i = 0; i < numberOfEnemiesPerSpawn; i++)
            {
                GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
                monster.transform.position = ReturnRandomPos();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    // ���͸� ������ ��ġ�� �����ϱ� ���� ���� ��ġ�� �޾ƿ��� �Լ�
    // 1. �� �ݶ��̴��� �����ͼ� x, y ������ ����
    // 2. �߾���ġ�� -(����/2) ~ (����/2) ���� ���ؼ� ������ ��ġ�� �����ǵ���

    // TODO :: 3. ����� ������ �����ǵ��� ���� �����ϱ�
    // ���� ����Ʈ ����?
    public Vector2 ReturnRandomPos()
    {
        int index = Random.Range(0, spawnPoint.Length);
        Vector2 randomPos = new Vector2(spawnPoint[index].position.x, spawnPoint[index].position.y);
        
        return randomPos;
    }
}
