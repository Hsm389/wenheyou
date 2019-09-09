using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIViceManager4 : MonoBehaviour {

    public GameObject MainCanvas;
    public CanvasGroup plane;
    public Scrollbar grade;
    public Text index1;
    public Text index2;
    public Text index3;
    public Text index4;
    public delegate void  finshHandle();
    public event finshHandle eventHandle;
    //第二场景
    public Animation door;
    public Transform yanWu1;//烟雾
    public Transform yanWu2;
    public Transform yanWu3;
    public Transform yanWu4;
    public EllipsoidParticleEmitter qiPao;//气泡
    public Animation shuiGang;//水缸
    public Animation shuiGang2;
    public Animator bottle;//瓶子的动画
    public Animation shangSheng;//bottle上升动画
    public Animation shangSheng2;
    public Animator pipeline;//管道动画
    public Animator waterPipe1;//三根横着水管动画
    public Animator waterPipe2;
    public Animator waterPipe3;
    public Animator waterPipe4;//竖着的水管动画
    private int num;
    float UpTimer;
    enum CardState
    {
        Show,Vanish
    }
    private CardState cardState;
    private void Awake()
    {
       
        RestPipeline();
        RestBottle();
        cardState = CardState.Vanish;
    }
    void Start () {
        Initialized();
        door["door"].time = door["door"].length;
        door.Play();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void SetGarde()
    {
        StopAllCoroutines();
        cardState = CardState.Show;
        StartCoroutine(SetCard(()=> { }));
        Invoke("CloseDoor", 5f);
    }//设置分数
    public void GetGrade()
    {
        index1.text =UnityEngine.Random.Range(10, 100) + "";
        index2.text =UnityEngine.Random.Range(10, 100) + "";
        index3.text =UnityEngine.Random.Range(10, 100) + "";
        index4.text = (((int.Parse(index1.text) + int.Parse(index2.text) + int.Parse(index3.text)) / 3)).ToString();
        index1.text += "%";
        index2.text += "%";
        index3.text += "%";
    }//获得分数
    public void ClearGarde()
    {
     
    }//重置分数
    public void PlayAnimation()
    {
        StopAllCoroutines();
        OpenDoor();
        Invoke("PlayBottleUp",2f);
        //PlayBottleUp();
      
    }//开始播放动画

    public void OnEventFinsh()
    {
        if (eventHandle!=null)
        {
            eventHandle();
        }
    }//当完成所有事件后调用
    public void PlayQiPao()
    {
        StopAllCoroutines();
        //Debug.Log("PlayQiPao");
        qiPao.emit = true;
        Invoke("PlayYanWu",3f);
    }//播放气泡
    public void UnPlayQiPao()
    {
        qiPao.emit =false;
    }//关闭气泡
    public void PlayYanWu()
    {
        //Debug.Log(" PlayYanWu");
        int i = int.Parse(index4.text);

        if (i<=25)
        {
            //yanWu1.GetComponent<ParticleSystem>().Stop();
            yanWu1.GetComponent<ParticleSystem>().Play();
        }
        else if (i>25 && i<=50)
        {
            //yanWu1.GetComponent<ParticleSystem>().Stop();
            yanWu2.GetComponent<ParticleSystem>().Play();
        }
        else if (i > 50 && i <=75)
        {
            //yanWu1.GetComponent<ParticleSystem>().Stop();
            yanWu3.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            //yanWu1.GetComponent<ParticleSystem>().Stop();
            yanWu4.GetComponent<ParticleSystem>().Play();
        }
        Invoke("SetGarde",3f);
       
    }//播放烟雾
    public void PlayPipeline()
    {
        StopAllCoroutines();
        //Debug.Log("PlayPipeline");
        pipeline.gameObject.GetComponent<MeshRenderer>().enabled = true;
        pipeline.Play("New Animation");
        PlayShuiGang();
        PlayWaterPipe4();
        
        Invoke("SetBoottle",1f);
    }//播放水阀动画
    public void RestPipeline()
    {
        pipeline.gameObject.GetComponent<MeshRenderer>().enabled = false;
    
    }//重置水阀动画
    public void PlayBoottle()
    {
        //Debug.Log("PlayBoottle");
        bottle.gameObject.GetComponent<MeshRenderer>().enabled = true;
        bottle.Play("shui5 Animation");
    }//播放bottle动画
    public void RestBottle()
    {
        //Debug.Log("RestBottle");
        bottle.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }//重置bottle动画
    public void SetBoottle()
    {
        shangSheng2.transform.Find("BLB01111").GetComponent<SkinnedMeshRenderer>().enabled = false;
    }
    public void PlayWaterPipeline()
    {

        
        
    }
    public void RestWaterPipeline()
    {
    
    }
    public void PlayShuiGang()
    {
        StopAllCoroutines();
        //Debug.Log("PlayShuiGang");
        shuiGang.Play();
        shuiGang2.Play();
        StartCoroutine(WhenShuiGangFinsh());
        shuiGang.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
        shuiGang2.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = true;
    }//播放水缸动画
    public void RestShuiGang()
    {
        shuiGang.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        shuiGang2.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }//重置水缸动画
    public void PlayBottleUp()
    {
       
        //Debug.Log(" PlayBottleUp");
        GetGrade();
        shangSheng2.transform.Find("BLB01111").GetComponent<SkinnedMeshRenderer>().enabled = true;
        shangSheng["Take 001"].speed = 1;
        shangSheng2["Take 001"].speed = 1;
        shangSheng.Play();
        shangSheng2.Play();
        PlayWaterPipe123();
        StartCoroutine(WhenBottleUPFinsh());
    }//播放bottle上升动画
    public void RestBottleUp()
    {
        shangSheng["Take 001"].speed=-1;
        //shangSheng2["Take 001"].speed=-1;
        shangSheng.Play();
        //shangSheng2.Play();
    }//重置bottle上升动画
    public void PlayWaterPipe4()
    {
        waterPipe4.Play("shui2Animation");
    }//播放竖着的水管动画
    public void RestWaterPipe4() { }//重置竖着的水管动画
    public void PlayWaterPipe123()
    {
        waterPipe1.speed = 1f;
        waterPipe2.speed = 1f;
        waterPipe3.speed = 1f;
        waterPipe1.Play("New11 Animation");
        waterPipe2.Play("New11 Animation");
        waterPipe3.Play("New11 Animation");
    }//播放竖着的水管动画
    public void RestWaterPipe123()
    {
        waterPipe1.Play("New11 Animation");
        waterPipe2.Play("New11 Animation");
        waterPipe3.Play("New11 Animation");
        Invoke("RestCallBack", 0.5f);
    }//重置竖着的水管动画
    public void RestAll()
    {
      
        //MainCanvas.GetComponent<ChangJingActive>().SetChangJing1Show(true);
        OnEventFinsh();
        UnPlayQiPao();
       
        RestShuiGang();
        RestPipeline();
        RestWaterPipe123();
        RestBottleUp();
        num += 1;
        //Debug.Log(num);
        if (num>=3)
        {
            Invoke("RestScene", 2f);
        }
       
    }
    public void RestScene()
    {
        SceneManager.LoadScene("Equipment4");
    }
    public void Initialized()
    {
        waterPipe1.Play("New11 Animation");
        waterPipe2.Play("New11 Animation");
        waterPipe3.Play("New11 Animation");
        Invoke("InitializedCallBack", 0.5f);
    }
    public void InitializedCallBack()
    {
        waterPipe1.speed = 0;
        waterPipe2.speed = 0;
        waterPipe3.speed = 0;
    }
    public void RestCallBack()
    {
        waterPipe1.speed = 0;
        waterPipe2.speed = 0;
        waterPipe3.speed = 0;
        //Invoke("OpenDoor", 2f);
    
    }
    public void OpenDoor()
    {
        //Debug.Log("OpenDoor");
        door["door"].speed = -1f;
        door["door"].time = door["door"].length;
        door.Play();
    }
    public void CloseDoor()
    {
        StopAllCoroutines();
        cardState = CardState.Vanish;
        StartCoroutine(SetCard(()=> 
        {
            door["door"].speed = 1f;
            ClearGarde();
            door.Play();
            Invoke("RestAll", 2f);
        }));
        
    }
    IEnumerator WhenShuiGangFinsh()
    {
        
        while (true)
        {
            yield return null;
            if (shuiGang.isPlaying && shuiGang["Take 001"].normalizedTime>=0.99f)
            {
                //Debug.Log("WhenShuiGangFinsh");
                RestBottle();
                RestPipeline();
                PlayQiPao();
               
            }
           
        }
        
    }//当水缸满时调用
    IEnumerator WhenBottleUPFinsh()
    {
        while (true)
        {
            yield return null;
            if (shangSheng.isPlaying && shangSheng["Take 001"].normalizedTime >= 0.185f)
            {
                //Debug.Log(" WhenBottleUPFinsh");
                PlayBoottle();
                PlayPipeline();
               
            }

        }
    }//当bottle上升完调用
    IEnumerator SetCard(Action callback)
    {
        while (true)
        {
            if (cardState==CardState.Show) {
                UpTimer += 1f;
                plane.alpha =Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * UpTimer));
                grade.value = plane.alpha;
                if (plane.alpha>=0.99f)
                {
                    UpTimer = 90f;
                    plane.alpha = 1f;
                    grade.value = plane.alpha;
                    callback();
                    yield break;
                }
                yield return null;
            }
            if (cardState == CardState.Vanish)
            {
                UpTimer += 1f;
                plane.alpha = Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * UpTimer));
                grade.value = plane.alpha;
                if (plane.alpha<=0.02f)
                {
                    UpTimer = 0f;
                    plane.alpha = 0f;
                    grade.value = plane.alpha;
                    callback();
                    yield break;
                }
                yield return null;
            }
        }
    }
}
