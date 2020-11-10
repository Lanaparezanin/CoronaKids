using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject IntroCanvas;
    public GameObject WinScreen;
    public Button StartButton;

    public GameObject pt0;
    public GameObject pt1;
    public GameObject pt2;
    public GameObject pt3;
    public GameObject pt4;
    public GameObject pt5;
    public GameObject pt6;
    public GameObject pt7;
    
    
    
    //public GameObject Button;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartButton.onClick.AddListener(BeginNow);

        if (pt1.activeSelf && pt2.activeSelf && pt3.activeSelf && pt4.activeSelf && pt0.activeSelf && pt5.activeSelf &&
            pt6.activeSelf && pt7.activeSelf)
        {
            WinScreen.SetActive(true);
        }
        
    }


    public void BeginNow()
    {
        IntroCanvas.SetActive(false);
        //Button.SetActive(false);
    }
}
