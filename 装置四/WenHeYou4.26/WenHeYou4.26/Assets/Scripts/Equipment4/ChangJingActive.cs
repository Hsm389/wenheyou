using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangJingActive : MonoBehaviour {

    public GameObject ChangJing1OBJ1;
    public GameObject ChangJing1OBJ2;
    public GameObject ChangJing1OBJ3;
    public GameObject ChangJing1OBJ4;
    public GameObject ChangJing1OBJ5;
    public GameObject ChangJing1OBJ6;
    public GameObject ChangJing1OBJ7;
    public GameObject ChangJing1OBJ8;
    public GameObject ChangJing1OBJ9;
    public GameObject ChangJing1OBJ10;
    public GameObject ChangJing1OBJ11;


    public GameObject ChangJing2OBJ1;
    public GameObject ChangJing2OBJ2;
    public GameObject ChangJing2OBJ3;
    public GameObject ChangJing2OBJ4;
    public GameObject ChangJing2OBJ5;
    public GameObject ChangJing2OBJ6;
    public GameObject ChangJing2OBJ7;
    public GameObject ChangJing2OBJ8;
    public GameObject ChangJing2OBJ9;
    public GameObject ChangJing2OBJ10;
    public GameObject ChangJing2OBJ11;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) { SetChangJing1Show(true); }
        if (Input.GetKeyDown(KeyCode.D)) { SetChangJing1Show(false); }
    }
    public void SetChangJing1Show(bool b)
    {
        //ChangJing1OBJ1.SetActive(b);
        //ChangJing1OBJ2.SetActive(b);

        //ChangJing2OBJ1.SetActive(!b);
    }  
}
