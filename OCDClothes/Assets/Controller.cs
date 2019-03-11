    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour

{
    public static bool InputEnabled = false;
    public GameObject SoundPlayer; 
    public GameObject SoundPlayer2;
    public GameObject SoundPlayer3;
    public GameObject SoundPlayer4;
    public GameObject SoundChecker;
    
       
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
    public GameObject Intro4;
    public GameObject Intro5;
    public GameObject Intro6;
    public GameObject ScoreScreen;
    public GameObject Outro1;
    public GameObject Outro2;
    public GameObject Score_0pct;
    public GameObject Score_25pct;
    public GameObject Score_50pct;
    public GameObject Score_75pct;
    public GameObject Score_100pct;
    public GameObject Score_pct_texts;

    private int repeat = 0;
    private int anxietyLevel = 0;
    private int clothingLevel = 0;
    private int GameStateControl = 0;
    private int IntroState = 0;

    private int[] delays = new int[] {3, 4, 5, 6};
    private int indexInDelays = 0;
    private bool Intro = true;

    // Start is called before the first frame update
    void Start()
    {
        ShowIntro1();

        repeat = delays[indexInDelays];
    }

    // Update is called once per frame
    void Update()
    {

        //intro fucnction used to call splashscreens
        if(Intro == true) {
            if (Input.GetKeyDown(KeyCode.F)) {

                if (IntroState == 0) {
                    ShowIntro2();
                    IntroState++;    
                } else if (IntroState == 1){
                    ShowIntro3();
                    IntroState++; 
                } else if (IntroState == 2) {
                    ShowIntro4();
                    IntroState++; 
                } else if (IntroState == 3) {
                    ShowIntro5();
                    IntroState++; 
                } else if (IntroState == 4) {
                    ShowIntro6();
                    IntroState++; 
                } else if (IntroState == 5) {
                    ShowGame();
                    IntroState++; 
                } 
                }
            }    

        
        //Main function that tracks anxiety and future level count??
       
        if(InputEnabled) {
            if (Input.GetKeyDown(KeyCode.E)) {
                InputEnabled = false;

                if (clothingLevel < 3) {
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
                    //Debug.Log("AnxietyLevel " + anxietyLevel);                   
                    //Debug.Log("ClothingLevel  " + clothingLevel);
                }
            }     
        }

        if (GameStateControl == 3){
            InputEnabled = false;
            Invoke("ShowScoreScreen",5);
        }

        if (Input.GetKeyDown(KeyCode.X) && Intro == true) {
            CancelInvoke();
            Intro1.SetActive(false);
            Intro2.SetActive(false);
            Intro3.SetActive(false);
            Intro4.SetActive(false);
            Intro5.SetActive(false);
            ShowGame();
        }
    }
               // Debug.Log(InputEnabled);

    IEnumerator RepeatSound() {
        while (true) {
            if (indexInDelays == 1) {
                 CreateSoundPlayer(SoundPlayer);
            
            } else if (indexInDelays == 2) {
                 CreateSoundPlayer(SoundPlayer2);
            
            } else if (indexInDelays == 3) {
                 CreateSoundPlayer(SoundPlayer3);
            
            } else if (indexInDelays == 4) {
                 CreateSoundPlayer(SoundPlayer4);
            }
            
            indexInDelays += 1; 
            indexInDelays = indexInDelays % delays.Length; 
            repeat = delays[indexInDelays]; 
            yield return new WaitForSeconds(repeat);
        }
    }

    void CreateSoundPlayer(GameObject SuddenSoundSource) {
        
        Instantiate(SuddenSoundSource, Vector3.zero, Quaternion.identity);
        Instantiate(SoundChecker, Vector3.zero, Quaternion.identity);
        Instantiate(KnockAnim);
    }

    IEnumerator PuttingOn() {
        Debug.Log("Putting on start");
        float timer = 0f;
        float time = 1f;

         if (GameStateControl == 0) {
                        time = 4.1f;
                        Debug.Log(time);
        } else if (GameStateControl == 1){
                        time = 3.6f;
                        Debug.Log(time);
        } else if (GameStateControl == 2){
                       time = 3.2f;
                        Debug.Log(time);
        }

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
        Debug.Log("Putting on end");
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
    }

    void ShowIntro4() {
        Intro3.SetActive(false);
        Intro4.SetActive(true);
    }

    void ShowIntro5() {
        Intro4.SetActive(false);
        Intro5.SetActive(true);
    }

    void ShowIntro6() {
        Intro5.SetActive(false);
        Intro6.SetActive(true);
    }

    void ShowGame() {
        Intro = false;
        Intro6.SetActive(false);
        StartCoroutine(RepeatSound());  
        InputEnabled = true;
    }
    	
    void ShowScoreScreen() {
    
        StopCoroutine(RepeatSound());
        
        InputEnabled = false;
        ScoreScreen.SetActive(true);

        if (anxietyLevel == 0) {
            Score_0pct.SetActive(true);
        }
        else if (anxietyLevel == 1) {
            Score_25pct.SetActive(true);
        }
        else if (anxietyLevel == 2) {
            Score_50pct.SetActive(true);
        }
        else if (anxietyLevel == 3) {
            Score_75pct.SetActive(true);
        }
        else if (anxietyLevel == 4) {
            Score_100pct.SetActive(true);
        }
    }

    public void ShowOutro1() {
        ScoreScreen.SetActive(false);
        Score_pct_texts.SetActive(false);
        Outro1.SetActive(true);
                    
    }

    public void ShowOutro2() {
        Outro1.SetActive(false);
        Outro2.SetActive(true);
                    
    }
}