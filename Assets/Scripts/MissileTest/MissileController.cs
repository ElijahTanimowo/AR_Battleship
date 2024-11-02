using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Speed")]
    public float speed = 100f;
    public float rotationSpeed = 1f;

    [Header("Positioning")]
    private Vector3 startPosition;

    [Header("Smoke")]
    public ParticleSystem smokeTrail;

    [Header("Explosion")]
    public ParticleSystem explosionPrefab;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Fire towards the current target
        if (target != null)
        {
            MoveToTarget(target.position);
            smokeTrail.Play();
        }
    }

    void MoveToTarget(Vector3 destination)
    {
        // move towards the target's position
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // rotate towards the target
        Vector3 direction = destination - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, direction) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (target != null && other.transform == target)
        {
            // set explosion location
            Instantiate(explosionPrefab, target.position, Quaternion.identity);

            // reset missile position and rotation
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;

            // reset target
            target = null;

            // stop playing smoke trail
            smokeTrail.Stop();
        }
    }

    public void FireAtTarget(Transform newTarget)
    {
        // set new target
        target = newTarget;
    }
}
