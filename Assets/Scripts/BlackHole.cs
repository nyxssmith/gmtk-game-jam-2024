using UnityEngine;
using System.Collections.Generic;
public class BlackHole : MonoBehaviour

{   public List<GameObject> spawnables = new List<GameObject>();
    
    // spawn a random object from this list ever N seconds
    public float spawnInterval = 30.0f;

    // TODO resize the objects as time goes on

    private float spawnTimer = 0.0f;

    void Update()
    {

        if (spawnTimer<=spawnInterval){
            spawnTimer+=Time.deltaTime;
        }else{
            SpawnObject();
            spawnTimer=0.0f;
        }
    }

    private void SpawnObject(){
        // pick a random object and spawn it
        int prefabIndex = Random.Range(0,spawnables.Count);
        // get prefab
        GameObject prefab = spawnables[prefabIndex];
        // summon
        Instantiate(prefab, this.transform.position, Quaternion.identity);
    }
    
}