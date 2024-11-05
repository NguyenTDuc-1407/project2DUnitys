using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destrol : MonoBehaviour
{
   [SerializeField] float timeDestroyes;

    void Start()
    {
        Destroy(this.gameObject,timeDestroyes); 
    }

}
