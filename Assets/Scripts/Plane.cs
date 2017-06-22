using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {
    public static Plane instance;

    public float InvulnerabilityBonusTime = 5;
    public SpriteRenderer invulnerabilityCircle;
    bool isInvulnerable = false;
    void Awake() {
        instance = this;
    }
    void Start() {
    }


    public void OnTriggerEnter(Collider obj) {
        if (obj.tag == "Missile") {
            HitByMissile();
        }


    }


    void Update() {
        invulnerabilityCircle.enabled = isInvulnerable;
    }

    public void TriggerInvulnerability() {
        StartCoroutine(InvulnerabilityTimer());

    }

    IEnumerator InvulnerabilityTimer() {
         isInvulnerable = true;
     
        yield return new WaitForSeconds(InvulnerabilityBonusTime);
         isInvulnerable = false;


    }


    void HitByMissile() {
        if (isInvulnerable) return;

        Explode();

    }

    void Explode() {
        ExplosionSpawner.instance.SpawnExplosion(transform.position);
        GameManager.instance.GameOver(1f);
        Destroy(gameObject);
    }






}
