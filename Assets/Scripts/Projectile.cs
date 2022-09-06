using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int damage;

    private GameObject target;
    private Character owner;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.velocity = transform.forward * moveSpeed;

        Destroy(gameObject, lifetime);
    }

    public void Setup(Character character)
    {
        owner = character;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character hit = other.GetComponent<Character>();

        if(hit!=owner&& hit != null)
        {
            hit.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
