using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutOfScreen : MonoBehaviour
{
    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
