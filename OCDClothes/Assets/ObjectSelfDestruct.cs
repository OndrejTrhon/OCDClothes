using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelfDestruct : MonoBehaviour
{
    public float SelfDestructTime;
    // Start is called before the first frame update
    void Start()
    {
        SelfDestruct();
            }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelfDestruct () 
    {
        Destroy(gameObject, SelfDestructTime);

    }
}
