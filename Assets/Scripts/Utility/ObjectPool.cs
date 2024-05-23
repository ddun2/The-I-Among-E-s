using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    protected int createdEnemies = 0;

    [System.Serializable]

    public class Pool
    {
        public GameObject prefab;
        public string tag;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    public void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {            
            Queue<GameObject> queue = new Queue<GameObject>();

            for(int i=0; i<pool.size; i++)
            {
                // ���������� ������Ʈ ����
                GameObject obj = Instantiate(pool.prefab);
                // ���� ������ ���� �� �Ǻ��� ���� ����
                if(obj.tag == "Enemy")
                    createdEnemies++;
                // ������ ������Ʈ ��Ȱ��ȭ ���·� ť�� ����
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {       
        // Ű ���� ã�� ���ϸ� null ����
        if (!PoolDictionary.ContainsKey(tag))
        {     
            return null;
        }

        // ť���� ������ �� �ڷ� �ٽ� ����
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        // ���� ������Ʈ Ȱ��ȭ �� ����
        obj.SetActive(true);
        return obj;
    }
}
