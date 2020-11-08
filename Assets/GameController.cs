using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject IntroCanvas;
    public Button StartButton;
    //public GameObject Button;
    
    
    //if beginning, put beginning canvas
    //if Bobbi interacted with person, circle around is green, Bobbi gets a point
    //if all points, Bobbi wins
    //if Bobbi too close, Bobbi gets red screen try again and moves away
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.onClick.AddListener(BeginNow);
        {
            
        }
    }


    public void BeginNow()
    {
        IntroCanvas.SetActive(false);
        //Button.SetActive(false);
    }
}
