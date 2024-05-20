using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : ObjectPool
{
    [SerializeField] GameObject testMap;
    BoxCollider2D mapCollider;

    private void Start()
    {
        mapCollider = testMap.GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnMonster(9));
        Vector2 pos = testMap.transform.position;
        Debug.Log(pos);
    }
    
    // TODO :: ���� ����ó���� �ٸ� ������ ��
    // TODO :: ���� �� �ڷ�ƾ ���       
    IEnumerator SpawnMonster(int count)
    {
        // TODO :: �ݺ� Ƚ�� ���ϱ�
        //         ������ ���� or ���� n���� óġ �� ����?
        for (int i = 0; i < count; i++)
        {
            GameObject monster = GameManager.Instance.ObjectPool.SpawnFromPool("Test");
            monster.transform.position = ReturnRandomPos();

            yield return new WaitForSeconds(1f);
        }
    }

    // ���͸� ������ ��ġ�� �����ϱ� ���� ���� ��ġ�� �޾ƿ��� �Լ�
    // 1. �� �ݶ��̴��� �����ͼ� x, y ������ ����
    // 2. �߾���ġ�� -(����/2) ~ (����/2) ���� ���ؼ� ������ ��ġ�� �����ǵ���

    // TODO :: 3. ����� ������ �����ǵ��� ���� �����ϱ�
    public Vector2 ReturnRandomPos()
    {
        Vector2 pos = testMap.transform.position;
        float x = mapCollider.bounds.size.x;
        float y = mapCollider.bounds.size.y;

        x = Random.Range((x / 2) * -1, x / 2);
        y = Random.Range((y / 2) * -1, y / 2);

        Vector2 randomPos = new Vector2(x, y);

        return pos + randomPos;
    }
}
