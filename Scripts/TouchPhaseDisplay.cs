using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchPhaseDisplay : MonoBehaviour
{
    [SerializeField] private Text _phaseDisplayText;
    private Touch _theTouch;
    private float timeTouchEnded;
    private float displayTime = 0.25f;
    void Update()
    {
        if(Input.touchCount > 0) 
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase == TouchPhase.Ended)
            {
                _phaseDisplayText.text = _theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
            else if (Time.time - timeTouchEnded > displayTime)
            {
                _phaseDisplayText.text = _theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            _phaseDisplayText.text = "";
        }
    }
}