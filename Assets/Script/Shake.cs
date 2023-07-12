using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shake : MonoBehaviour
{
   
    void Start()
    {
        this.gameObject.transform.DOShakePosition(3, 50, 50, 100, true, true).SetLoops(-1, LoopType.Restart);
    }

}
