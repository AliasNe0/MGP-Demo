using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float destructElevation = -10f;
    private void FixedUpdate()
    {
        if (transform.position.y < destructElevation)
        {
            Destroy(gameObject);
        }
    }
}
