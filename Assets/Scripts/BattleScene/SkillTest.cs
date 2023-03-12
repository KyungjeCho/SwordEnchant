using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            BattleCameraMove MainCamera = GameObject.Find("Main Camera").GetComponent<BattleCameraMove>();
            MainCamera.ChangeTarget(this.gameObject.transform);

            // Todo : Time Pause & Enemy Stop
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")    
        {
            BattleCameraMove MainCamera = GameObject.Find("Main Camera").GetComponent<BattleCameraMove>();
            MainCamera.ChangeTarget(other.gameObject.transform);

            // Todo : Time Start & Enemy Move
        }
    }
}
