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
        //Main function that tracks anxiety and future level count??
       

        //For future level counting?
         if (Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("SoundOn") == null) {
            clothingLevel = clothingLevel +1;
             Debug.Log(clothingLevel);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (null != animShirt)
            {
                // Play animation t-shirt state (set to idle upon entry in animation structure)
                animShirt.Play("animation_tshirt");
                StartCoroutine(PuttingOn());
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

    IEnumerator PuttingOn() {
        float timer = 0f;
        float time = 5f;
            while(timer < time && GameObject.FindWithTag("AnxietyUpUp") == null) {
                timer += Time.deltaTime;
                 
                 if (GameObject.FindWithTag("SoundOn") != null) {
                    Instantiate(text1);
                    anxietyLevel = anxietyLevel +1;
                    clothingLevel = clothingLevel +1;
                Debug.Log(anxietyLevel);
                }
            yield return null;
        }
    }
}