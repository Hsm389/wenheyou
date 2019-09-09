using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    public ParticleSystem P_douzi;
    public ParticleSystem P_douzi03;
    public ParticleSystem P_douzi02;
    public ParticleSystem P_douzi04;
    public ParticleSystem p_anjian5;
    public ParticleSystem p_anjian4;
    public ParticleSystem p_anjian2;
    public ParticleSystem p_anjian3;
    public ParticleSystem p_anjian1;
    public ParticleSystem P_tishi01;
    public ParticleSystem P_tishi02;
    public ParticleSystem P_tishi03;
    public ParticleSystem P_tishi04;
    public ParticleSystem P_tishi05;
    public ParticleSystem P_tishi06;
    public ParticleSystem P_tishi07;
    public ParticleSystem p_luzhi01;
    public ParticleSystem p_luzhi011;
    public ParticleSystem p_shui;
    public ParticleSystem p_doujiang;
    public ParticleSystem p_lushui;
    public ParticleSystem p_shui_;
    public ParticleSystem p_shui02;
    public ParticleSystem p_shui03;
    public ParticleSystem p_pzi;
    public ParticleSystem p_shui1;
    public ParticleSystem p_shui2;
    public ParticleSystem p_shui3;
    public ParticleSystem p_shui4;
    public ParticleSystem p_cdf;
    public ParticleSystem p_cdf1;
    public ParticleSystem doufuwang;
    public ParticleSystem p_wenduji;
    public ParticleSystem p_doufunao;
    public ParticleSystem p_doufu1;
    public ParticleSystem doufushi;
    public ParticleSystem p_doufu2;
    public ParticleSystem p_doufu3;
    public ParticleSystem p_chilun02;
    public ParticleSystem p_yanwu;
    public ParticleSystem p_fengshan;
    public Animation anjianer;
    public Animation anjjjjjj;
    public Animation antttt;
    public Animation anrrrr;
    public Animation ansmed;
    public bool open;
    public bool originalstate;
    private bool StateA;
    private bool StateB;
    private bool StateC;
    private bool StateD;
    private bool StateE;




    // Use this for initialization
    void Start () {
        //PS1.Stop();
      
    }
	
	// Update is called once per frame
	void Update () {

    


    }
    public void bgePlay()
    {
        ButtonOne();
        p_anjian1.Stop();
        Invoke("openCL", 5.0f);
        open = false;
       

    }
    public void bgePlay1()
    {
        ButtonT();
        p_anjian2.Stop();
        Invoke("openCL", 5.0f);
        Invoke("yanchi2", 3.0f);
        open = false;
    }
    public void bgePlay2()
    {
        p_anjian4.Stop();
        ButtonTh();
        Invoke("openCL", 5.0f);
        open = false;
    }
    public void bgePlay3()
    {
        p_anjian3.Stop();
        ButtonFh();
        Invoke("openCL", 5.0f);
        Invoke("yanchi3", 3.5f);
        open = false;
    }
    public void bgePlay4()
    {
        p_anjian5.Stop();
        ButtonFT();
        Invoke("openCL", 5.0f);
        Invoke("yanchi4", 1.2f);
        Invoke("yanchi5", 2.8f);
        open = false;
    }

    public void ButtonOne()
    {
        P_douzi.Play(); ; P_douzi02.Play(); P_douzi04.Play(); p_shui.Play(); p_shui02.Play(); P_tishi01.Play(); P_tishi02.Play();
    }
    public void openCL()
    {
        p_anjian1.Play();
        p_anjian2.Play();
        p_anjian4.Play();
        p_anjian3.Play();
        p_anjian5.Play();
        open = true;

    }
    public void ButtonT()
    {
        p_doujiang.Play(); p_wenduji.Play(); p_shui1.Play(); p_shui4.Play(); p_shui3.Play(); p_shui2.Play(); p_yanwu.Play();
         P_douzi03.Play(); P_tishi03.Play(); P_tishi04.Play();
    }
    public void yanchi2()
    {
        anjianer.Play();
    }
    public void ButtonTh()
    {
        anjjjjjj.Play(); p_lushui.Play(); P_tishi05.Play(); p_doufunao.Play();
    }
    public void ButtonFh()
    {
        antttt.Play(); P_tishi06.Play(); p_doufu1.Play(); doufuwang.Play(); 

    }
    public void yanchi3()
    {
        ansmed.Play();
    }


    public void ButtonFT()
    {
        P_tishi07.Play(); p_luzhi01.Play(); p_pzi.Play(); p_cdf.Play(); p_cdf1.Play(); p_doufu2.Play(); p_doufu3.Play(); doufushi.Play();
    }
    public void yanchi4()
    {
        anrrrr.Play();
    }
    public void yanchi5()
    {
        anrrrr.Stop();
    }
    public void invoking()
    {
        if(originalstate)
        {
            bgePlay();
        }
        else if(StateA)
        {
            bgePlay1();
        }
        else if(StateB)
        {
            bgePlay2();
        }
        else if(StateC)
        {
            bgePlay3();
        }
        else if(StateD)
        {
            bgePlay4();
        }
        else if(StateE)
        {

        }
       

       
      
    }


}
