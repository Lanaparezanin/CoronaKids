using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoban : MonoBehaviour
{
    public GameObject Boban;
    public GameObject Canvas;

    public void MoveBob()
    {
        StartCoroutine(movingBobby());
        
    }

    public IEnumerator movingBobby()
    {
        Canvas.SetActive(true);
        Boban.transform.forward = new Vector3(Boban.transform.position.x-5, Boban.transform.position.y, Boban.transform.position.z);
        yield return new WaitForSeconds(3.5f);
        Canvas.SetActive(false);
    }
    
    
    
}
