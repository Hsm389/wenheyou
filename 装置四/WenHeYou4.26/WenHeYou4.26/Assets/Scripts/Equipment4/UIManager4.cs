using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
//using TouchScript;


public class UIManager4 : MonoBehaviour
{
    public Canvas ShowCanvas;
    public Button TheButton;
    public GameObject slider;
    private bool openGai;
    //public RectTransform cover;
    public Transform Mat;
    public Slider item1;
    public Slider item2;
    public Slider item3;
    public Slider item4;
    public Slider item5;
    public Animation doorAnim;
    public Animation GaiAnim;
    public Animation completeAnim1;
    public GameObject completeAnim2;
    public GameObject completeAnim3;
    public Animation BottleAnim;
    //public Scrollbar leftSlider;
    //public Scrollbar rightSlider;
    public Text value1;
    public Text value2;
    public Text value3;
    public Text value4;
    public Text value5;
    public Canvas ViceCanvas;
    private bool sliderShow;//slider当前的显示状态
    private bool canChangeState;
    //private float targetvalue;
    private float SideSliderTargetValue;
    //private Slider coverSlider;
    private Material[] initializeTexture2s;
    private Dictionary<string, string> texTure2sNames;
    private List<Text> matNames;
    public Transform color;
    private bool canShowSlider;//能否显示slider
    //private Texture2D[] shuffleTexture2s;
    public enum ButtonState//实体按键的状态，初始状态None，开始互动状态Begin，互动状态中On，结束互动状态End
    {
        Null, None, Begin, On, End
    }
    public enum CoverState
    {
        Move, keep
    }
    private ButtonState buttonCurrentState;//用来过的当前按键的状态
    private ButtonState buttonNextState;//按键的下一个状态
    private CoverState coverCurrentState;//coverslider当前的状态
    private LoadAllImage4 image4;
    private TextShow textShow;
    private Color32 targetColor;
    public GameObject shuiGang1;
    public GameObject shuiGang2;
    public GameObject pipeline;
    public GameObject grassA;
    public GameObject yanWu1;
    public GameObject yanWu2;
    public GameObject yanWu3;
    public GameObject yanWu4;
    private Dictionary<int, Color32> dicColor;

    /// <summary>
    /// 音效
    /// </summary>
    public AudioSource audioSource;
    public AudioClip door;
    public AudioClip yuanliao;
    public AudioClip complete;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        //transform.GetComponent<ChangJingActive>().SetChangJing1Show(true);
    }
    void Start()
    {
        foreach (var item in Display.displays)
        {
            item.Activate();
        }
        InitializedDicColor();
        matNames = new List<Text>();
        canShowSlider = false;
        openGai = true;
        completeAnim3.GetComponent<animEvent>().animFinshEvent += CloseDoor;
        completeAnim3.GetComponent<animEvent>().anim3Event += PlayBottle;
        texTure2sNames = new Dictionary<string, string>();
        DicInitialize();
        image4 = new LoadAllImage4();
        textShow = transform.GetComponent<TextShow>();
        textShow.FinshTextHandler += IsAllValueValid;
        initializeTexture2s = image4.Load();
        sliderShow = true;
        //targetvalue = 0;
       
        //coverSlider = cover.GetComponent<Slider>();
        canChangeState = true;
        buttonCurrentState = ButtonState.Null;
        buttonNextState = ButtonState.None;
        coverCurrentState = CoverState.keep;
        ChangeButtonState();//在start里面，切换进入None状态
        ShowSlider();
        //item1.OnValueChangedAsObservable().Select(value => (int)(value * 100)).Subscribe(value => SetTextValue(value, value1));//监听slider的value的值，并实时赋值给text
        //item2.OnValueChangedAsObservable().Select(value => (int)(value * 100)).Subscribe(value => SetTextValue(value, value2));
        //item3.OnValueChangedAsObservable().Select(value => (int)(value * 100)).Subscribe(value => SetTextValue(value, value3));
        //item4.OnValueChangedAsObservable().Select(value => (int)(value * 100)).Subscribe(value => SetTextValue(value, value4));
        //item5.OnValueChangedAsObservable().Select(value => (int)(value * 100)).Subscribe(value => SetTextValue(value, value5));
        //item1.onValueChanged.AddListener((value)=>
        //{
        //    if (value == 100) { value1.text = "MAX"; }
        //    else { value1.text = value + ""; }
        //});
        //item2.onValueChanged.AddListener((value) =>
        //{
        //    if (value == 100) { value2.text = "MAX"; }
        //    else { value2.text = value + ""; }
        //});
        //item3.onValueChanged.AddListener((value) =>
        //{
        //    if (value == 100) { value3.text = "MAX"; }
        //    else { value3.text = value + ""; }
        //});
        //item4.onValueChanged.AddListener((value) =>
        //{
        //    if (value == 100) { value4.text = "MAX"; }
        //    else { value4.text = value + ""; }
        //});
        //item5.onValueChanged.AddListener((value) =>
        //{
        //    if (value == 100) { value5.text = "MAX"; }
        //    else { value5.text = value + ""; }
        //});
        
        //item1.OnValueChangedAsObservable().Subscribe(_ => IsAllValueValid());
        //item2.OnValueChangedAsObservable().Subscribe(_ => IsAllValueValid());
        //item3.OnValueChangedAsObservable().Subscribe(_ => IsAllValueValid());
        //item4.OnValueChangedAsObservable().Subscribe(_ => IsAllValueValid());
        //item5.OnValueChangedAsObservable().Subscribe(_ => IsAllValueValid());
        Observable.EveryUpdate().First().Subscribe(_ => MatNameInitialize());
        //TouchManager.Instance.PointersPressed += OnPointPressedSetSliderShow;
        ViceCanvas.GetComponent<UIViceManager4>().eventHandle += EndEndState;
        RestLiuti();
        //transform.GetComponent<ChangJingActive>().SetChangJing1Show(true);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        //completeAnim3.GetComponent<animEvent>().animFinshEvent -= CloseDoor;
        //completeAnim3.GetComponent<animEvent>().anim3Event -= PlayBottle;
        //textShow.FinshTextHandler += IsAllValueValid;
    }
    public void OnValue1Changed()
    {
        if (item1.value == 100) { value1.text = "MAX"; }
        else { value1.text = item1.value + ""; }
    }
    public void OnValue2Changed()
    {
        if (item2.value == 100) { value2.text = "MAX"; }
        else { value2.text = item2.value + ""; }
    }
    public void OnValue3Changed()
    {
        if (item3.value == 100) { value3.text = "MAX"; }
        else { value3.text = item3.value + ""; }
    }
    public void OnValue4Changed()
    {
        if (item4.value == 100) { value4.text = "MAX"; }
        else { value4.text = item4.value + ""; }
    }
    public void OnValue5Changed()
    {
        if (item5.value == 100) { value5.text = "MAX"; }
        else { value5.text = item5.value + ""; }
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
             ();
        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    PlayCompleteAnim1();
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    RestCompleteAnim1();
        //}

    }

    public void OnPointPressedSetSliderShow(/*object sender, PointerEventArgs e*/)
    {
        if (buttonCurrentState == ButtonState.On && canShowSlider)
        {
            ShowSlider();
            canShowSlider = false;
        }
    }
    public void CloseDoor()
    {
        RestBottle();
        doorAnim["door"].speed = 1f;
        doorAnim.Play();
        StartCoroutine(GetCompleteFinsh(OnDoorColse));
    }
    public void OpenDoor()
    {
        doorAnim["door"].speed = -1;
        doorAnim["door"].time = doorAnim["door"].length;
        doorAnim.Play();
        Debug.Log("!!!!!!!!!!!!!!!!");
        BeginNoneState();
    }
    public void OpenGai()
    {
        //Debug.Log("OpenGai");
        PlayDoorSound();
        GaiAnim["Gai"].speed = 1f;
        GaiAnim.Play();
        openGai = false;
        Invoke("OnPointPressedSetSliderShow",1f);
    }
    public void CloseGai()
    {
        PlayDoorSound();
        GaiAnim["Gai"].speed = -1;
        GaiAnim["Gai"].time = GaiAnim["Gai"].length;
        GaiAnim.Play();
        openGai = true;
    }
    //控制Slider是否激活
    public void ShowSlider()
    {
        sliderShow = !sliderShow;
        slider.SetActive(sliderShow);
    }
    //按键的监听事件
    public void OnClickButton()
    {
        if (canChangeState)//确定按键输入的有效性
        {
            ChangetheChangeState(false);//是按键输入无效
            ChangeButtonState();//开始改变状态
            //UpDateCoverSliderState();
            if (openGai)
            {
                OpenGai();
            }
            else
            {
                CloseGai();
            }
          
        }

    }
    public void ChangeButtonState()
    {
        if (EndState())
        {
            SetCurrentState(buttonNextState);
            BeginState();

        }
    }
    public bool EndState()//结束状态
    {
        if (buttonCurrentState == ButtonState.Null)
        {
            return true;
        }
        else if (buttonCurrentState == ButtonState.None)
        {
            EndNoneState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.Begin)
        {
            EndBeginState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.On)
        {
            EndOnState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.End)
        {
            EndEndState();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool BeginState()//开始状态
    {
        if (buttonCurrentState == ButtonState.None)
        {
            BeginNoneState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.Begin)
        {
            BeginBeginState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.On)
        {
            BeginOnState();
            return true;
        }
        else if (buttonCurrentState == ButtonState.End)
        {
            BeginEndState();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool EndNoneState()
    {
        textShow.SetQiDong(false);

        //Debug.Log("EndNone");
        return true;
    }
    public bool EndBeginState()
    {
        //Debug.Log("EndBegin");
        BeginOnState();

        return true;
    }
    public bool EndOnState()
    {
        ShowSlider();
        //Debug.Log("EndOn");
        return true;
    }
    public void EndEndState()
    {
        //ViceCanvas.GetComponent<UIViceManager4>().eventHandle -= EndEndState;
        //StartCoroutine(Timer(RestAll));
        //Debug.Log("EndEnd");
        OpenDoor();

    }//用来重置参数
    public bool BeginNoneState()
    {

        RestAll();
        SetCurrentState(ButtonState.None);
        SetNextState(ButtonState.Begin);
        //Debug.Log("BeginNone");
       
        return true;
    }
    public bool BeginBeginState()
    {
        //Debug.Log("BeginBegin");
        SetCurrentState(ButtonState.Begin);
        SetNextState(ButtonState.On);
        EndBeginState();
        return true;
    }
    public bool BeginOnState()
    {
        //Debug.Log("BeginOn");
        RandomMatAndSetName();
        textShow.SetBeginCompund(true);
        SetCurrentState(ButtonState.On);
        SetNextState(ButtonState.End);
        //GetTargetValue();
        coverCurrentState = CoverState.Move;
        //StartCoroutine(IsKeep());
        //ShowSlider();
        canShowSlider = true;
        Invoke("BeginCompundFade",1f);
        return true;
    }
    public void BeginCompundFade()
    {
        //textShow.BeginCompundFade();
        Invoke("IsAllValueValid",3f);
    }
    public void DisposeCompundFade()
    {
        //textShow.DisposeCompundFade();
    }
    public void BeginEndState()//进入End状态，
    {
        //Debug.Log("BeginEnd");
        SetCurrentState(ButtonState.End);
        SetNextState(ButtonState.None);
        //GetTargetValue();
        coverCurrentState = CoverState.Move;
        ChangetheChangeState(false);
        textShow.SetFinshCompund(false);
        Invoke("BeginCompound", 1.5f);
        //BeginCompound();
        //EndEndState();
        //return true;
    }
    public void SetCurrentState(ButtonState newState)//设置当前状态
    {
        buttonCurrentState = newState;
    }
    public void SetNextState(ButtonState newState)//设置下一个状态
    {
        buttonNextState = newState;
    }
    public ButtonState GetCurrentState()//获得当前状态
    {
        return buttonCurrentState;
    }
    public ButtonState GetNextState()//获得下一个状态
    {
        return buttonNextState;
    }
    public void ChangetheChangeState(bool b)
    {
        canChangeState = b;
    }//用来控制按钮的输入是否有效
    //public bool ChangeCoverSliderValue()//改变coversliderValue的具体操作
    //{

    //    if (targetvalue == 0)
    //    {
    //        if (coverSlider.value > 0)
    //        {
    //            coverSlider.value -= Time.deltaTime;

    //            if (coverSlider.value <= 0f)
    //            {
    //                coverSlider.value = targetvalue;
    //                coverCurrentState = CoverState.keep;
    //                return true;
    //            }
    //        }
    //    }
    //    else if (targetvalue == 1)
    //    {
    //        if (coverSlider.value < 1)
    //        {
    //            coverSlider.value += Time.deltaTime;
    //            if (coverSlider.value >= 10f)
    //            {
    //                coverSlider.value = targetvalue;
    //                coverCurrentState = CoverState.keep;
    //                return true;
    //            }
    //        }
    //    }
    //    return false;

    //}
    //public void UpDateCoverSliderState()//一直检测coverslider的状态
    //{
    //    if (coverCurrentState == CoverState.Move)
    //    {
    //        //ChangeCoverSliderValue();
    //        StartCoroutine("SliderMove");
    //        Invoke("CloseEnumerator", 2f);
    //    }
    //}
    //public float GetTargetValue()//获得cover当前的value   获得目标value


    //{
    //    targetvalue = 1 - coverSlider.value;
    //    return targetvalue;
    //}
    public void BeginCompound()//开始合成
    {
        RedomColor();
        SetColor();
        textShow.SetDispose(true);
        DisposeCompundFade();
       /* Invoke("DisposeCompundFade",1f)*/;
        PlayCompoundAnimation();
        //Debug.Log("播放动画");
    }
    public void SetTextValue(int value,Text text)
    {
        text.text = value >= 100 ? "MAX" : value+"";
    }
    public bool OnCompound()//当合成动画播放完成是调用
    {
        textShow.SetDispose(false);
        //StartCoroutine(Timer(OnSideSliderColse));
        return true;
    }
    //public void SetTowSideSlider()//调用两边滑动框
    //{
    //    if (SideSliderTargetValue == 0)
    //    {
    //        if (leftSlider.value > 0 && rightSlider.value>0)
    //        {
    //            leftSlider.value -= Time.deltaTime;
    //            rightSlider.value -= Time.deltaTime;

    //            if (leftSlider.value <= 0f && leftSlider.value <= 0f)
    //            {
    //                leftSlider.value = SideSliderTargetValue;
    //                rightSlider.value = SideSliderTargetValue;
    //            }
    //        }
    //    }
    //    else if (SideSliderTargetValue == 1)
    //    {
    //        if (leftSlider.value <1 && rightSlider.value <1)
    //        {
    //            leftSlider.value += Time.deltaTime;
    //            rightSlider.value += Time.deltaTime;
    //            if (leftSlider.value >= 1f &&rightSlider.value>=1f)
    //            {
    //               leftSlider.value = SideSliderTargetValue;
    //                rightSlider.value = SideSliderTargetValue;
    //            }
    //        }
    //    }
    //}
    //public void RestTowSideSlider()//重置两边滑动框
    //{
    //    leftSlider.value = 0;
    //    rightSlider.value = 0;
    //}
    public void IsAllValueValid()//检测输入的五种原材料各自的值都不为0
    {
 
                //Debug.Log("item1" + item1.value);
                ChangetheChangeState(true);//恢复按键有效性
                textShow.SetBeginCompund(false);
                textShow.SetFinshCompund(true);

    }
    public void RestSliderValue()//重置slider的value
    {
        item1.value = 0f;
        item2.value = 0f;
        item3.value = 0f;
        item4.value = 0f;
        item5.value = 0f;
    }
    public bool PlayCompoundAnimation()
    {
        PlayCompleteSound();
        PlayCompleteAnim1();
        //PlayBottle();
        PlayLiuTi();
        return true;
    }
    public void RandomMatAndSetName()
    {
        MeshRenderer[] images = Mat.gameObject.GetComponentsInChildren<MeshRenderer>();
        Material[] shuffleTexture2s = image4.CutToList(initializeTexture2s, images.Length);
        for (int i = 0; i < shuffleTexture2s.Length; i++)
        {
            //images[i].sprite = Sprite.Create(shuffleTexture2s[i],new Rect(0, 0,shuffleTexture2s[i].width,shuffleTexture2s[i].height/* Mat.rect.width*0.2f,Mat.rect.height*/),new Vector2(0.5f,0.5f)/*,100.0f,0,SpriteMeshType.Tight,new Vector4(10f,10f,10f,10f)*/);
            images[i].material = shuffleTexture2s[i];
            matNames[i].text = texTure2sNames[shuffleTexture2s[i].name];
            //Debug.Log("RandomMatAndSetName");
        }

    }//随机生成五种原材料
    public void DicInitialize()
    {
        texTure2sNames.Add("bajiao", "八角");
        texTure2sNames.Add("baomihua", "爆米花");
        texTure2sNames.Add("dasuan", "大蒜");
        texTure2sNames.Add("heizhima", "黑芝麻");
        texTure2sNames.Add("jiangguo", "浆果");
        texTure2sNames.Add("kafeidou", "咖啡豆");
        texTure2sNames.Add("lajiao", "辣椒");
        texTure2sNames.Add("lingmeng", "柠檬");
        texTure2sNames.Add("liulian", "榴莲");
        texTure2sNames.Add("mutan", "木炭");
        texTure2sNames.Add("qiaokeli", "巧克力");
        texTure2sNames.Add("qiukui", "秋葵");
        texTure2sNames.Add("ruantang", "软糖");
        texTure2sNames.Add("shadinyu", "沙丁鱼");
        texTure2sNames.Add("xihongshi", "西红柿");
        texTure2sNames.Add("mogu", "蘑菇");

    }//字典初始化 key为原料的编号，value为原料的名字
    public void MatNameInitialize()
    {
        matNames.Add(item1.transform.Find("Image").transform.Find("Text").GetComponent<Text>());
        matNames.Add(item2.transform.Find("Image").transform.Find("Text").GetComponent<Text>());
        matNames.Add(item3.transform.Find("Image").transform.Find("Text").GetComponent<Text>());
        matNames.Add(item4.transform.Find("Image").transform.Find("Text").GetComponent<Text>());
        matNames.Add(item5.transform.Find("Image").transform.Find("Text").GetComponent<Text>());
    }
    public void OnDoorColse()
    {
        transform.GetComponent<ChangJingActive>().SetChangJing1Show(false);
        RestLiuti();
        RestCompleteAnim1();
        //Debug.Log("DoorClose");
        ViceCanvas.GetComponent<UIViceManager4>().PlayAnimation();
        

    }//主屏幕操作结束，开始操作副屏
    public void RestAll()
    {
        StopAllCoroutines();
        ChangetheChangeState(true);
        RestSliderValue();
        textShow.SetQiDong(true);
        textShow.SetBeginCompund(false);
        textShow.SetDispose(false);
        textShow.SetFinshCompund(false);
        canChangeState = true;
        openGai = true;
        //RestLiuti();
    }
    //IEnumerator Timer(Action callback)
    //{
    //    SideSliderTargetValue = 1 - leftSlider.value;
    //    for (int i = 0; i <60; i++)
    //    {
    //        Debug.Log(222);
    //        SetTowSideSlider();
    //        yield return null;
    //    }
    //    callback();
    //}
    IEnumerator IsKeep()
    {
        yield return new WaitForSeconds(2.0f);

    }
    //IEnumerator SliderMove()
    //{

    //    while (true)
    //    {
    //        ChangeCoverSliderValue();
    //        yield return null;
    //    }
    //}
    public void CloseEnumerator()
    {
        StopAllCoroutines();
        //StopCoroutine("SliderMove");
    }//关闭协程
    public void RestLiuti()
    {
        //Debug.Log("RestLiuTi");
        completeAnim2.GetComponent<MeshRenderer>().enabled = false;
        completeAnim3.GetComponent<MeshRenderer>().enabled = false;
    }//重置流体
    public void PlayLiuTi()
    {
        completeAnim2.GetComponent<MeshRenderer>().enabled =true;
        completeAnim2.GetComponent<Animator>().Play("shuiliudong");
        completeAnim3.GetComponent<MeshRenderer>().enabled = true;
        completeAnim3.GetComponent<Animator>().Play("chang11Animation");
    }//播放流体
    public void PlayCompleteAnim1()
    {
        completeAnim1["Take 001"].speed = 1f;
        completeAnim1.Play();
    }//播放机器动画
    public void RestCompleteAnim1()
    {
        completeAnim1["Take 001"].speed = -1f;
        completeAnim1.Play();
        //Invoke("UnPlayCompleteAnim1",0.2f);
    }//重置机器动画
    public void PlayBottle()
    {
        BottleAnim.transform.Find("BLB01").GetComponent<SkinnedMeshRenderer>().enabled = true;
        BottleAnim["Take 001"].speed = 1f;
        BottleAnim.Play();
    }
    public void RestBottle()
    {
        BottleAnim.transform.Find("BLB01").GetComponent<SkinnedMeshRenderer>().enabled = false;
        //BottleAnim["Take 001"].speed = -1f;
        //BottleAnim.Play();
    }
    public void PlayCompleteAnim3()
    {
        //completeAnim3.transform.Find("BLB01").GetComponent<SkinnedMeshRenderer>().enabled = true;
        //completeAnim3.GetComponent<Animation>()["Take 001"].speed = 1f;
        //completeAnim3.GetComponent<Animation>().Play();
    }
    public void RestCompleteAnim3()
    {
        //completeAnim3.transform.Find("BLB01").GetComponent<SkinnedMeshRenderer>().enabled = false;
        //completeAnim3.GetComponent<Animation>()["Take 001"].speed = -1f;
        //completeAnim3.GetComponent<Animation>().Play();
    }
    public void UnPlayCompleteAnim1()
    {
        completeAnim1.Stop();
    }
    public void SetColor()
    {
        color.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_SpecColor", targetColor);
        completeAnim2.GetComponent<MeshRenderer>().material.SetColor("_SpecColor",targetColor);
        shuiGang1.GetComponent<SkinnedMeshRenderer>().sharedMaterial.color = targetColor;
        shuiGang2.GetComponent<SkinnedMeshRenderer>().sharedMaterial.color = targetColor;
        pipeline.GetComponent<MeshRenderer>().sharedMaterial.color = targetColor;
        grassA.GetComponent<ParticleRenderer>().sharedMaterial.SetColor("_TintColor",(Color)targetColor*0.3f);
        ParticleSystem.MainModule yan1 = yanWu1.GetComponent<ParticleSystem>().main;
        yan1.startColor = (Color)targetColor ;
        ParticleSystem.MainModule yan2 = yanWu2.GetComponent<ParticleSystem>().main;
        yan2.startColor = (Color)targetColor;
        ParticleSystem.MainModule yan3 = yanWu3.GetComponent<ParticleSystem>().main;
        yan3.startColor = (Color)targetColor;
        ParticleSystem.MainModule yan4 = yanWu4.GetComponent<ParticleSystem>().main;
        yan4.startColor = (Color)targetColor;
       
    }
    public void RedomColor()
    {
        int i = UnityEngine.Random.Range(1,21);
        targetColor = dicColor[i];
       


    }
    public void InitializedDicColor()
    {
        dicColor = new Dictionary<int, Color32>();
        dicColor.Add(1,new Color32(1,19,19,255));
        dicColor.Add(2, new Color32(1, 19, 19, 255));
        dicColor.Add(3, new Color32(1, 19, 19, 255));
        dicColor.Add(4,new Color32(255,127,105,255));
        dicColor.Add(5, new Color32(255, 127, 105, 255));
        dicColor.Add(6, new Color32(255, 127, 105, 255));
        dicColor.Add(7, new Color32(255, 127, 105, 255));
        dicColor.Add(8,new Color32(191,0,20,255));
        dicColor.Add(9, new Color32(191, 0, 20, 255));
        dicColor.Add(10,new Color32(18,0,111,255));
        dicColor.Add(11,new Color32(126,161,255,255));
        dicColor.Add(12,new Color32(0,111,28,255));
        dicColor.Add(13, new Color32(0, 111, 28, 255));
        dicColor.Add(14, new Color32(0, 111, 28, 255));
        dicColor.Add(15,new Color32(111,0,103,255));
        dicColor.Add(16,new Color32(111,71,0,255));
        dicColor.Add(17, new Color32(111, 71, 0, 255));
        dicColor.Add(18, new Color32(111, 71, 0, 255));
        dicColor.Add(19, new Color32(111, 71, 0, 255));
        dicColor.Add(20, new Color32(111, 71, 0, 255));
    }
    IEnumerator GetCompleteFinsh(Action callback)
    {
  
       yield return new WaitForSeconds(2f);
        callback();
       
    }
    public void PlayDoorSound()
    {
        audioSource.clip = door;
        audioSource.Play();
    }
    public void PlayYuanLiaoSound()
    {
        audioSource.clip = yuanliao;
        audioSource.Play();
    }
    public void PlayCompleteSound()
    {
        audioSource.clip = complete;
        audioSource.Play();
    }
}
