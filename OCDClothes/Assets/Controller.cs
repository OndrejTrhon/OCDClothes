    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public static bool InputEnabled = false;
    public GameObject SoundPlayer;
    public GameObject text1;
    
    public Animator animShirt;
    public Animator animScarf;
    public Animator animHat;
    public GameObject animShirtObject;
    public GameObject animScarfObject;
    public GameObject animHatObject;
    public GameObject KnockAnim;

    public GameObject SweaterCheckClean;
    public GameObject SweaterCheckCrossed;
    public GameObject ScarfCheckClean;
    public GameObject ScarfCheckCrossed;
    public GameObject HatCheckClean;
    public GameObject HatCheckCrossed;
    

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
    private int GameStateControl = 0;

    private int[] delays = new int[] {3, 4, 5, 6};
    private int indexInDelays = 0;
    private bool Intro = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowIntro1",0);
        Invoke("ShowIntro2",6);
        Invoke("ShowIntro3",11);
        Invoke("ShowGame",16);

        repeat = delays[indexInDelays];
    }

    // Update is called once per frame
    void Update()
    {
        //Main function that tracks anxiety and future level count??
       
        if(InputEnabled) {
            if (Input.GetKeyDown(KeyCode.E)) {

                if (clothingLevel < 3) {
                    InputEnabled = false;
                    // Play animation t-shirt state (set to idle upon entry in animation structure)
                    clothingLevel = clothingLevel +1;
                    if (GameStateControl == 0) {
                        SweaterCheckClean.SetActive(false);
                        SweaterCheckCrossed.SetActive(true);
                        //float time = 3f;
                        animShirt.Play("animace_start");
                    } else if (GameStateControl == 1){
                        ScarfCheckClean.SetActive(false);
                        ScarfCheckCrossed.SetActive(true);
                        animShirtObject.SetActive(false);
                        animScarfObject.SetActive(true);
                        //float time = 2.5f;
                        animScarf.Play("animace_start");

                    } else if (GameStateControl == 2){
                        HatCheckClean.SetActive(false);
                        HatCheckCrossed.SetActive(true);
                        animScarfObject.SetActive(false);
                        animHatObject.SetActive(true);
                        //float time = 3f;
                        animHat.Play("animace_start");  
                    }
                    StartCoroutine(PuttingOn()); 
                    Debug.Log("AnxietyLevel " + anxietyLevel);                   
                    Debug.Log("ClothingLevel  " + clothingLevel);
                }
            }     
        }

        if (GameStateControl == 3){
            InputEnabled = false;
            Invoke("ShowOutro1",6);
        }

        if (Input.GetKeyDown(KeyCode.F) && Intro == true) {
            CancelInvoke();
            Intro1.SetActive(false);
            Intro2.SetActive(false);
            Intro3.SetActive(false);
            ShowGame();
        }
    }
               // Debug.Log(InputEnabled);

    IEnumerator RepeatSound() {
        while (true) {
            CreateSoundPlayer();
            
            indexInDelays += 1; 
            indexInDelays = indexInDelays % delays.Length; 
            repeat = delays[indexInDelays]; 
            yield return new WaitForSeconds(repeat);
        }
    }

    void CreateSoundPlayer() {
        Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
        Instantiate(KnockAnim);
    }

    IEnumerator PuttingOn() {
        float timer = 0f;
        float time = 3f;
        while(timer < time && GameObject.FindWithTag("AnxietyUpUp") == null) {
                timer += Time.deltaTime;
                 
            if (GameObject.FindWithTag("SoundOn") != null) {
                    Instantiate(text1);
                    anxietyLevel = anxietyLevel +1; 
                                   

                    //Debug.Log(anxietyLevel);
            }
        yield return null;
        }
        GameStateControl++;
        InputEnabled = true;
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
        Intro = false;
    }

    void ShowGame() {
        Intro3.SetActive(false);
        StartCoroutine(RepeatSound());  
        InputEnabled = true;
    }
    	
    void ShowOutro1() {
    
        StopCoroutine(RepeatSound());
        
        InputEnabled = false;
        Outro1.SetActive(true);

        if (anxietyLevel == 0) {
            Outro_0pct.SetActive(true);
        }
        else if (anxietyLevel == 1) {
            Outro_25pct.SetActive(true);
        }
        else if (anxietyLevel == 2) {
            Outro_50pct.SetActive(true);
        }
        else if (anxietyLevel == 3) {
            Outro_75pct.SetActive(true);
        }
        else if (anxietyLevel == 4) {
            Outro_100pct.SetActive(true);
        }
    }

    public void ShowOutro2() {
        Outro1.SetActive(false);
        Outro2.SetActive(true);
        Outro_pct_texts.SetActive(false);            
    }
}