using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEvent : MonoBehaviour {
    public GameObject bottle;
  
    public delegate void AnimFinshHandler();
    public /*static*/ event AnimFinshHandler animFinshEvent;
    public delegate void AnimHandler();
    public /*static*/ event AnimHandler anim3Event;
    // Use this for initialization
    void Start () {
        bottle.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void ShowBottle()
    {
        OnAnim3Event();
        transform.GetComponent<MeshRenderer>().enabled = false;
    }
    public void AnimFinsh()
    {
        Invoke("OnEvent",3f);
    }
    public void OnAnim3Event()
    {
       
        if (anim3Event!=null)
        {
            anim3Event();
        }
    }
    public void OnEvent()
    {
        //bottle.GetComponent<SkinnedMeshRenderer>().enabled = false;
        if (animFinshEvent != null)
        {
            animFinshEvent();
        }
    }
}
