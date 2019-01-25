using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public GameObject SoundPlayer;
    public GameObject text1;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateSoundPlayer", time);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("SoundOn") != null) {
            Instantiate(text1, Vector3.zero, Quaternion.identity);
             Debug.Log("ok");
        }
    }

    void CreateSoundPlayer()
     {
     Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
    }

}