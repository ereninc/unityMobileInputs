using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchDirectionsDisplay : MonoBehaviour
{
    [SerializeField] private Text _directionDisplayText;
    private Touch _theTouch;
    private Vector2 _touchStartPos, _touchEndPos;
    private string _direction;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase == TouchPhase.Began)
            {
                _touchStartPos = _theTouch.position;
            }
            else if (_theTouch.phase == TouchPhase.Moved || _theTouch.phase == TouchPhase.Ended)
            {
                _touchEndPos = _theTouch.position;
                float x = _touchEndPos.x - _touchStartPos.x;
                float y = _touchEndPos.y - _touchStartPos.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0) //mutlak deger
                {
                    _direction = "Tapped";
                }
                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    _direction = x > 0 ? "Right" : "Left";
                }
                else if (Mathf.Abs(y) > Mathf.Abs(x))
                {
                    _direction = y > 0 ? "Up" : "Down";
                }
            }
        }
        _directionDisplayText.text = _direction;
    }
}