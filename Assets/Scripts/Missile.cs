using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
  public   float steeringPower = 3;
  public  float SpeedMultiplier = 20f;
   public Rigidbody rigid;
    float suicideTime = 30;
    public SpriteRenderer sprite;
    public BoxCollider collider;
    bool suicided;


    // Use this for initialization
    void Start () {
        StartCoroutine(SuicideRoutine());

    }

    // Update is called once per frame
    void Update () {

        rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, 6f);
        RotateMissile();

    }

    void RotateMissile() {

        if (suicided) return;
        if (PlaneController.instance== null) return;

        Vector3 targetDir = PlaneController.instance.transform.position - transform.position;
        float step = steeringPower * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


    void FixedUpdate()
    {
        MoveMissile();

    }

    void MoveMissile()
    {
        rigid.AddForce ( transform.forward * SpeedMultiplier);
    }



    IEnumerator SuicideRoutine()
    {
        yield return new WaitForSeconds(suicideTime);
        Suicide();
    }


    void Suicide()
    {
        RemoveFromlist();
        suicided = true;
        collider.enabled = false;
        StartCoroutine(SelfDestroyRoutine());
    }

    IEnumerator SelfDestroyRoutine() {
        SpeedMultiplier = SpeedMultiplier / 1.5f;
        float selfDestroyTime = 1.5f;
        float lerper = 0;
        Color targetColor = sprite.color;
        Color originalColor = targetColor;
        targetColor.a = 0;
        while (lerper < 1) {
            lerper += Time.deltaTime / selfDestroyTime;
            sprite.color = Color.Lerp(originalColor, targetColor, lerper);
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);

    }


    void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.tag == "Player")
        {
            Explode();


        }
        if (obj.transform.tag == "Missile")
        {
            Plus10Text.instance.Show("10");
            ScoreHandler.instance.increaseScore(5);
            Explode();
        }

    }


    void Explode() {
        ExplosionSpawner.instance.SpawnExplosion(transform.position);
        DeleteItem();
    }

public void DeleteItem() {
        RemoveFromlist();
        Destroy(gameObject);
    }


    void RemoveFromlist() {
        FollowIcons.instance.RemoveElement(SpawnInPlaneRadius.ObjectTypeSpawn.missiles, gameObject);
    }


}
