using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [System.Serializable]
    public struct pool
    {
        public string tag;
        public GameObject prefabs;
        public int size;
    }

    public pool bulletPool = new pool();
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public Transform parent;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        Queue<GameObject> objectPool = new Queue<GameObject> ();
        for (int i = 0; i < bulletPool.size; i++)
        {
            GameObject obj = Instantiate(bulletPool.prefabs, parent);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(bulletPool.tag, objectPool);
    }

    public GameObject SpawnObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}
