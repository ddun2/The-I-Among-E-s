using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public GameObject prefab;
        public string tag;
        public int size;
        public int number;
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
                // 프리팹으로 오브젝트 생성
                GameObject obj = Instantiate(pool.prefab);

                // 생성된 오브젝트 비활성화 상태로 큐에 삽입
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {       
        // 키 값을 찾지 못하면 null 리턴
        if (!PoolDictionary.ContainsKey(tag))
        {     
            return null;
        }

        // 큐에서 꺼내고 맨 뒤로 다시 삽입
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);

        // 꺼낸 오브젝트 활성화 후 리턴
        obj.SetActive(true);
        return obj;
    }
}
