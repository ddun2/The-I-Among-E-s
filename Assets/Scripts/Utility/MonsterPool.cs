using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject Enemies;
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
        
        StartCoroutine(SpawnMonster());
    }
    
    // TODO :: ���� ����ó���� �ٸ� ������ ��
    // TODO :: ���� �� �ڷ�ƾ ���       
    IEnumerator SpawnMonster()
    {
        while (true)
        {
            // ���� �ð����� ����
            yield return new WaitForSeconds(spawnTime);
            Debug.Log(currentEnemies);
            Debug.Log(pools[0].size);

            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (currentEnemies < pools[0].size)
                {
                    GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Enemy");
                    monster.transform.position = ReturnRandomPos();
                    // Ȱ��ȭ �� Enemies ������Ʈ�� �ڽ����� ����
                    monster.transform.SetParent(Enemies.transform, false);
                    currentEnemies++;
                }               
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
