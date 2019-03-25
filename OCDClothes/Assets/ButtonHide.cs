using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHide : MonoBehaviour
{
public GameObject button;
public GameObject button2;

public void ButtonClicked() {
    button.SetActive(false);   
    button2.SetActive(false);   
}

}
