using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> Buttons;
    [Header("Animations")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;


    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var b in Buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        //foreach (var b in Buttons)
        for(int i = 0; i < Buttons.Count; i ++)
        {
            var b = Buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }    

}
