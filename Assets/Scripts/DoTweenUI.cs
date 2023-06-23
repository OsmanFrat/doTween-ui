using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenUI : MonoBehaviour
{
    public float revealDuration = 1f;
    public RectTransform complete;
    public RectTransform coin;
    public RectTransform[] scaleTransforms;
    public RectTransform[] downYTransforms;
    public Text scoreText;
    public Vector3 originalScale;
    private GamePanelsScript gamePanelsScript;
    
    private void Start() 
    {
        originalScale = transform.localScale;
    }

    //Every time this object is activated, the functions inside it run again.
    void OnEnable()
    {
        lvlCompletePanel();
    }



    public void lvlCompletePanel()
    {
        
        // gamePanelsScript.isGameActive = false;
        foreach(RectTransform scaleTransform in scaleTransforms)
        {
            scaleTransform.DOScale(Vector3.zero, revealDuration).From();
        }

        complete.DOAnchorPosY(730f, revealDuration).From();

        coin.DOAnchorPosX(-160, revealDuration*2f).From();
        coin.DOAnchorPosY(-320, revealDuration).From();

        foreach (RectTransform downYTransform in downYTransforms)
        {
            downYTransform.DOAnchorPosY(-730f, revealDuration).From();
        }


        scoreText.text = "";
        //scoreText.DOText("464500", revealDuration/2f) added animation to score text and revealDuration part when it's ready.
        //.SetDelay(revealDuration); when animation will be active(i guess xd)

        scoreText.DOText("464500", revealDuration/2f).SetDelay(revealDuration);
        
    }

    public void OnClickTween(RectTransform rectTransform)
    {
        rectTransform.DOScale(rectTransform.localScale*1.25f, revealDuration/6f).SetLoops(2, LoopType.Yoyo);
        //                    1.25 times magnification when button is pressed  and  do this 2 times
        rectTransform.DOScale(originalScale, revealDuration);
    }

}
//730