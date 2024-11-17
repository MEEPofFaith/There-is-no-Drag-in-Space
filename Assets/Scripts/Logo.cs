using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public float fadeDelay = 1;
    public float fadeTime = 3;

    private float fadeTimer;

    private void Awake() {
        fadeTimer = fadeTime + fadeDelay;
    }

    // Update is called once per frame
    void Update(){
        if(fadeTimer < fadeDelay){
            float opactiy = math.max(fadeTimer / fadeDelay, 0);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opactiy);

            if(fadeTimer < 0){
                GameObject.Destroy(gameObject);
            }
        }
        fadeTimer -= Time.deltaTime;
    }
}
