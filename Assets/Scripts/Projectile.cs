using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int behavior = 0; //0 = wait //1 = fire // 2 == teleport
    float startTime;
    public Rigidbody rb;
    public GameObject target;
    FiringSolution fs;
    public float muzzleV = 100.0f;
    Vector3? vel;
    Vector3 currentPos;
    Vector3 targetPos;
    Vector3 gravity;
    Vector3 pos0;
    // Start is called before the first frame update
    void Start()
    {
        pos0 = rb.transform.position;
        startTime = Time.time;
        fs = new FiringSolution();
        Debug.Log("success");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FiringSolution fs = new FiringSolution();
            Debug.Log("success");
            vel = fs.calculateFiringSolution(rb.transform.position, target.transform.position, muzzleV, Physics.gravity);
            if (vel.HasValue)
            {
                rb.AddForce(vel.Value.normalized * muzzleV, ForceMode.VelocityChange);
                Debug.Log("success");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // reset
            rb.isKinematic = true;
            transform.position = pos0;
            rb.isKinematic = false;
        }
    }
}

