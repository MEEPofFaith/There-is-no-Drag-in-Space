using interfaces;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public static PlayerMain Instance;

    public float accel; //Units/sec/sec??
    public float rotAccel; //Deg/sec/sec??
    public float maxSpeed = -1f;
    public float drag;
    public float sizeMod; //Does nothing. Only used as a tracker.

    public float xp;
    public float xpMult = 1f;
    public float levelUpXp;

    private Rigidbody2D self;
    private Animator animator;

    private void Awake(){
        if(Instance != null) Debug.LogError("Excuse me there is supposed to only be one PlayerMain what.");
        Instance = this;

        self = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject collidedObject = collision.gameObject;
        if(collidedObject.tag == "Collectable"){
            collidedObject.GetComponent<ICollectable>().Collected();
        }
    }

    public void gainExp(float amount){
        UpgradesManager upgrades = UpgradesManager.Instance;

        xp += amount * xpMult;
        while(xp >= levelUpXp){
            xp -= levelUpXp;
            levelUpXp *= 1.1f;
            upgrades.queueUpgrade();
        }
        upgrades.display();
    }

    private void Update() {
        //Controls
        animator.SetBool("firing", false);
        if(!UpgradesManager.Instance.isOpen()){
            if(Input.GetKey(KeyCode.W)){
                float angle = math.radians(self.rotation);
                float scl = accel * Time.deltaTime;
                self.velocity += new Vector2(math.cos(angle) * scl, math.sin(angle) * scl);
                animator.SetBool("firing", true);
            }
            if(Input.GetKey(KeyCode.A)){
                self.angularVelocity += rotAccel * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D)){
                self.angularVelocity -= rotAccel * Time.deltaTime;
            }

            if(maxSpeed > 0){
                self.velocity = Vector2.ClampMagnitude(self.velocity, maxSpeed);
            }
        }

    }

    void FixedUpdate(){
        //I don't like Unity's drag
        if(drag > 0){
            float mul = 1f - drag * Time.deltaTime;
            self.angularVelocity *= mul;
            self.velocity *= mul;
        }

        //Screen looping
        Vector3 newPos = transform.position;
        if(transform.position.x > 9.5){
            newPos.Set(-9.5f, newPos.y, newPos.z);
        }
        if(transform.position.x < -9.5){
            newPos.Set(9.5f, newPos.y, newPos.z);
        }
        if(transform.position.y > 5.5){
            newPos.Set(newPos.x, -5.5f, newPos.z);
        }
        if(transform.position.y < -5.5){
            newPos.Set(newPos.x, 5.5f, newPos.z);
        }
        transform.position = newPos;
    }

    public Rigidbody2D getBody(){
        return self;
    }
}