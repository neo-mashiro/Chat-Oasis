using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]  // make instances of this class editable from within the inspector
public class Item {
    public int amount;
    public GameObject prefab;
}

// pre-instantiate objects into a pool before gameplay (for better performance at runtime)
public class ObjectPool : MonoBehaviour {
    public static ObjectPool SharedPool;

    [SerializeField] private List<Item> items;
    private List<GameObject> _pool;

    private void Awake() {
        SharedPool = this;
    }
    
    private void Start() {
        _pool = new List<GameObject>();
        foreach (var item in items) {
            for (var i = 0; i < item.amount; i++) {
                var obj = Instantiate(item.prefab);
                obj.SetActive(false);
                _pool.Add(obj);
            }
        }
    }

    public GameObject Fetch(string objectTag) {
        return _pool.FirstOrDefault(x => !x.activeInHierarchy && x.CompareTag(objectTag));
    }
}
