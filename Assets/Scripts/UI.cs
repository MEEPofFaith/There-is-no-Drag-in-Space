using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject progress;
    public TMP_Text lvText;
    public TMP_Text playerInfoText;

    public float len = 4.5f;

    // Update is called once per frame
    void Update(){
        PlayerMain player = PlayerMain.Instance;

        float lerp = player.xp / player.levelUpXp;
        float prog = -len + lerp * 2 * len;

        endPoint.transform.position = new Vector3(prog, endPoint.transform.position.y, endPoint.transform.position.z);

        SpriteRenderer barRender = progress.GetComponent<SpriteRenderer>();
        barRender.size = new Vector2(prog + len, barRender.size.y);
        progress.transform.position = new Vector3(-len + lerp * len, progress.transform.position.y, progress.transform.position.z);

        lvText.SetText("Lv: " + UpgradesManager.Instance.level);

        Rigidbody2D body = player.GetComponent<Rigidbody2D>();
        playerInfoText.SetText(
            "Speed: " + body.velocity.magnitude.ToString("F2") + " units/sec"
            + "\nAngle: " + mod(body.rotation, 360f).ToString("F2") + " deg"
            + "\nAngular Velocity: " + body.angularVelocity.ToString("F2") + " deg/sec"
        );
    }

    float mod(float f, float n){
        return ((f % n) + n) % n;
    }
}
