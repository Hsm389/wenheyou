using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour {
    public delegate void FinshTextShow();
    public event FinshTextShow  FinshTextHandler;
    public Text qidong;
    public Text beginCompund;
    public Text finshCompund;
    public Text dispose;
    private float fadeTimer;
    public Image jianTou;
    private Vector3 jianTouPos;
    public Transform leftTarget;
    public Transform RightTarget;
    private Vector3 jianTouLeftTargetPos;
    private Vector3 jianTouRightTargetPos;
    private void Awake()
    {
        SetQiDong(false);
        SetFinshCompund(false);
        SetBeginCompund(false);
        SetDispose(false);
    }
    void Start () {
        //jianTouPos = jianTou.transform.position;
        //jianTouLeftTargetPos = leftTarget.position;
        //jianTouRightTargetPos = RightTarget.position;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(jianTou.transform.position);
	}
    public void SetQiDong(bool b)
    {
     qidong.gameObject.SetActive(b);
    }

    public void SetBeginCompund(bool b)
    {
        beginCompund.gameObject.SetActive(b);
    }
    public void SetFinshCompund(bool b)
    {
        finshCompund.gameObject.SetActive(b);

    }

    public void SetDispose(bool b)
    {
        //dispose.CrossFadeAlpha(0f,Time.deltaTime,false);
        dispose.gameObject.SetActive(b);
    }
    public void BeginCompundFade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeBeginCompund());
    }
    public void DisposeCompundFade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeDisposeCompund());
    }
    IEnumerator FadeBeginCompund()
    {
        while (true)
        {
            fadeTimer += 1;
        //beginCompund.gameObject.GetComponent<CanvasGroup>().alpha=    Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad*fadeTimer+90));
            beginCompund.CrossFadeAlpha(Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * fadeTimer + 90)),Time.deltaTime,false);

            if (fadeTimer >= 200f && beginCompund.canvasRenderer.GetAlpha()<=0.02f)
            {
                beginCompund.CrossFadeAlpha(0f, Time.deltaTime, false);
                fadeTimer = 0f;
                FinshTextHandler();
                yield break;
            }
            yield return null;

        }
    }
    IEnumerator FadeDisposeCompund()
    {
        while (true)
        {
            fadeTimer += 1;
            //beginCompund.gameObject.GetComponent<CanvasGroup>().alpha=    Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad*fadeTimer+90));
           dispose.CrossFadeAlpha(Mathf.Abs(Mathf.Sin(Mathf.Deg2Rad * fadeTimer)), Time.deltaTime, false);

            if (fadeTimer >= 300f && dispose.canvasRenderer.GetAlpha() <= 0.02f)
            {
               dispose.CrossFadeAlpha(0f, Time.deltaTime, false);
                fadeTimer = 0f;
                yield break;
            }
            yield return null;

        }
    }
  
}
