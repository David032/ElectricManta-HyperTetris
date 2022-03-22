using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class OptionButton : MonoBehaviour
{
    public GameObject Panel;
    bool isOut = false;
    [SerializeField]
    Transform ShownPos;
    [SerializeField]
    Transform HiddenPos;

    public void TogglePanel() 
    {
        if (isOut)
        {
            Panel.transform.DOMove(ShownPos.position, 1.5f);
            isOut = false;
        }
        else if (!isOut)
        {
            Panel.transform.DOMove(HiddenPos.position, 1.5f);
            isOut = true;
        }
    }
}
