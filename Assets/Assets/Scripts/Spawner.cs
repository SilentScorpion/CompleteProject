using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float MaxNextSpawn;
    public float MinNextSpawn;
    public GameObject player;
    public GameObject platforms;

    void Start() {
        CreatePlatforms();
    }

    void CreatePlatforms() {
        for (int i = 0; i < 10; i++) {
            float randX = (Random.Range(-1.5f, 1.5f));
            GameObject go = Instantiate(spawnObject, new Vector3(randX, i * 1f, 0), Quaternion.identity);
            go.transform.SetParent(platforms.transform);
        }
        Invoke("CreatePlatforms", 0.5f);
    }
}
