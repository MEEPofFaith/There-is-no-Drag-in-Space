using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public static StarSpawner Instance;

    public GameObject starPrefab;
    public float spawnDelay;
    public int maxStars;
    public float maxXOffset;
    public float maxYOffset;

    private float timer;
    public int starCount;
    

    private void Awake() {
        if(Instance != null) Debug.LogError("Excuse me there is supposed to only be one StarSpawner what.");
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            Vector3 randomPipeOffset = new Vector3(Random.Range(-maxXOffset, maxXOffset) , Random.Range(-maxYOffset, maxYOffset), 0);
            Instantiate(starPrefab, transform.position + randomPipeOffset, transform.rotation);
            timer = spawnDelay;
            starCount++;
        }else if(starCount < maxStars){
            timer -= Time.deltaTime;
        }
    }
}
