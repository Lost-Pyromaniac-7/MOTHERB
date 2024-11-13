using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;
    public float power = 100f;
    public float lifeTime = 4f;
    public float time = 0f;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = this.transform.forward * power;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
