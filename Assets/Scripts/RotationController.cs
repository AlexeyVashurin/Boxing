using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField]private Transform enemy;
    private Vector3 newDir;

    void Update()
    {
        newDir = Vector3.RotateTowards(transform.forward, (enemy.transform.position-transform.position),90,0); 
        transform.rotation = Quaternion.LookRotation(newDir * Time.deltaTime);
    }
}
