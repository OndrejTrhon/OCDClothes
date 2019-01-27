using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public GameObject SoundPlayer;
    public GameObject text1;
    public int time;
    public Animator animShirt;

    private int repeat = 0;
    private int anxietyLevel = 0;
    private int clothingLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatSound());
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("SoundOn") != null) {
            Instantiate(text1);
            anxietyLevel = anxietyLevel +1;
            clothingLevel = clothingLevel +1;
             Debug.Log(anxietyLevel);
        }

         if (Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("SoundOn") == null) {
            clothingLevel = clothingLevel +1;
             Debug.Log(clothingLevel);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (null != animShirt)
            {
                // play Bounce but start at a quarter of the way though
                animShirt.Play("animation_tshirt");
            }
        }

       repeat = Random.Range(0, 5);
       //Debug.Log(repeat);
    }

    IEnumerator RepeatSound() {
     while (true) {
        CreateSoundPlayer();
        yield return new WaitForSeconds(repeat);

    }
    }

    void CreateSoundPlayer() {
        Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
    }

}