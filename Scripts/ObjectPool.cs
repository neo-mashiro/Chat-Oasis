using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pre-instantiate objects into a pool before gameplay (for better performance at runtime)
public class ObjectPool : MonoBehaviour {
    public static ObjectPool SharedPool;

    private List<GameObject> _pool;
    [SerializeField] private int amount;
    [SerializeField] private GameObject prefab;

    private void Awake() {
        SharedPool = this;
    }
    
    void Start() {
        _pool = new List<GameObject>();
        for (int i = 0; i < amount; i++) {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); 
            _pool.Add(obj);
        }
    }

    public GameObject Fetch() {
        for (int i = 0; i < _pool.Count; i++) {
            if (!_pool[i].activeInHierarchy) {
                return _pool[i];
            }
        }
        return null;
    }
}
