using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutOfScreen : MonoBehaviour
{
    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
