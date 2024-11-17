using interfaces;
using UnityEngine;

public class XpStar : MonoBehaviour, ICollectable {
    public StarData data;

    private float expireTimer;

    private void Awake() {
        //TODO scale setting
        expireTimer = data.expireTime;

        transform.localScale = new Vector3(data.size, data.size, data.size);
    }

    private void Update() {
        if(expireTimer > 0){
            expireTimer -= Time.deltaTime;
            if(expireTimer < 0) yeetSelf();
        }
    }

    public void Collected(){
        PlayerMain player = PlayerMain.Instance;

        player.gainExp(data.xp);

        yeetSelf();
    }

    private void yeetSelf(){
        StarSpawner.Instance.starCount--;
        GameObject.Destroy(gameObject);
    }
}