using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Text timeTxt;
    float time = 0.0f;
    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString();
    }

}
