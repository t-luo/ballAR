using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootBall : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    [SerializeField]
    SpawnableManager spm;

    [SerializeField]
    Transform ballSpawnpoint;

    [SerializeField]
    Transform camTrans;

    [SerializeField]
    float force = 10f;

    GameObject spawnedBall;
    Rigidbody ballRbody;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0 || !spm.placed)
            return;

        if (spawnedBall == null)
        {
            spawnedBall = Instantiate(ballPrefab);
            ballRbody = spawnedBall.GetComponent<Rigidbody>();
            
        }
        
        // Vector2 touchPos = Input.GetTouch(0).position;
        spawnedBall.transform.position = ballSpawnpoint.position;
        ballRbody.velocity = Vector3.zero;
        Vector3 dir = ballSpawnpoint.forward + new Vector3(0, 1, 0);
        dir = dir.normalized * force;
        ballRbody.AddForce(dir);
    }
}
