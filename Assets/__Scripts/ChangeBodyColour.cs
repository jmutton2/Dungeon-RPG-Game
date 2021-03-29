using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBodyColour : MonoBehaviour
{
    
    // go of hero
    public GameObject panel;
    public SpriteRenderer heroBody;
    public Color red, blue, yellow, green;
    public int bodyColour = 1;

    void Start(){
        panel.SetActive(true);
    }

    // Update for body colour when user clicks the body colour
    void Update()
    {
        if(bodyColour == 1){
            heroBody.color = red; 
        }
        else if(bodyColour == 2){
            heroBody.color = blue;
        }
        else if(bodyColour == 3){
            heroBody.color = yellow;
        }
        else if(bodyColour == 4){
            heroBody.color = green;
        }
    }

    // user clicks red colour
    public void ChangeBCRed(){
        bodyColour = 1;
    }

    // user clicks blue colour
    public void ChangeBCBlue(){
        bodyColour = 2;
    }

    // user clicks yellow colour
    public void ChangeBCYellow(){
        bodyColour = 3;
    }

    // user clicks green colour
    public void ChangeBCGreen(){
        bodyColour = 4;
    }
}
