using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public static bool InputEnabled = false;
    public GameObject SoundPlayer;
    public GameObject text1;
    public int time;
    public Animator animShirt;

    public GameObject Intro1;
    public GameObject Intro2;
    public GameObject Intro3;
    public GameObject Outro1;
    public GameObject Outro2;
    public GameObject Outro_0pct;
    public GameObject Outro_25pct;
    public GameObject Outro_50pct;
    public GameObject Outro_75pct;
    public GameObject Outro_100pct;
    public GameObject Outro_pct_texts;

    private int repeat = 0;
    private int anxietyLevel = 0;
    private int clothingLevel = 0;
    private static bool GameStateControl = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowIntro1",0);
        Invoke("ShowIntro2",4);
        Invoke("ShowIntro3",8);
        Invoke("ShowGame",12);
        

    }

    // Update is called once per frame
    void Update()
    {
        //Main function that tracks anxiety and future level count??
       
        if(InputEnabled) {

        if (Input.GetKeyDown(KeyCode.E)) {

            if (clothingLevel < 4) {
                // Play animation t-shirt state (set to idle upon entry in animation structure)
                animShirt.Play("animation_tshirt");
                StartCoroutine(PuttingOn());
                clothingLevel = clothingLevel +1;
            } else {
                Invoke("ShowOutro1",1);

            }
            
            } }

       repeat = Random.Range(0, 10);
       //Debug.Log(repeat);

    }
               // Debug.Log(InputEnabled);

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
        float time = 3f;
            while(timer < time && GameObject.FindWithTag("AnxietyUpUp") == null) {
                timer += Time.deltaTime;
                 
                 if (GameObject.FindWithTag("SoundOn") != null) {
                    Instantiate(text1);
                    anxietyLevel = anxietyLevel +1; 
                                   Debug.Log("AnxietyLevel " + anxietyLevel);
                                   
                                   Debug.Log("ClothingLevel  " + clothingLevel);

                //Debug.Log(anxietyLevel);
                }
            yield return null;
        }
    }

    void ShowIntro1() {
                    Intro1.SetActive(true);
    }
    
    void ShowIntro2() {
                    Intro1.SetActive(false);
                    Intro2.SetActive(true);
    }
    
    void ShowIntro3() {
                    Intro2.SetActive(false);
                    Intro3.SetActive(true);
    }

    void ShowGame() {
                    Intro3.SetActive(false);
                    StartCoroutine(RepeatSound());
                    GameStateControl = true;
                    InputEnabled = true;


    }
    	
    void ShowOutro1() {
                    InputEnabled = false;
                    Outro1.SetActive(true);
                    StopCoroutine(RepeatSound());
                        if (anxietyLevel == 0) {
                            Outro_0pct.SetActive(true);
                        }

                        if (anxietyLevel == 1) {
                            Outro_25pct.SetActive(true);
                        }

                        if (anxietyLevel == 2) {
                            Outro_50pct.SetActive(true);
                        }

                        if (anxietyLevel == 3) {
                            Outro_75pct.SetActive(true);
                        }

                        if (anxietyLevel == 4) {
                            Outro_100pct.SetActive(true);
                        }

                    Invoke("ShowOutro2", 6);

    }
    void ShowOutro2() {
                    Outro1.SetActive(false);
                    Outro2.SetActive(true);
                    Outro_pct_texts.SetActive(false);
                    
    }
}