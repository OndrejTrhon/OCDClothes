using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public GameObject SoundPlayer;
    public GameObject text1;
    public int time;
    private int repeat = 0;
    public int destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatSound());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("SoundOn") != null) {
            Instantiate(text1, Vector3.zero, Quaternion.identity);
             Debug.Log("ok");
        }
       repeat = Random.Range(0, 5);
       Debug.Log(repeat);
    }

    IEnumerator RepeatSound() {
     while (true) {
        CreateSoundPlayer();
        yield return new WaitForSeconds(repeat);

    }
    }

    void CreateSoundPlayer() {
        Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
        DestroySoundPlayer();
    }

    void DestroySoundPlayer() {
        Destroy(SoundPlayer,destroyTime);
    }

}