using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch _touch;
    private Vector2 _touchStartPos, _touchEndPos;

    void Update()
    {
        TouchInput();
    }

    void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _touchStartPos = _touch.position;
            }
            else if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Ended)
            {
                _touchEndPos = _touch.position;
                float x = _touchEndPos.x - _touchStartPos.x;
                float y = _touchEndPos.y - _touchStartPos.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    Debug.Log("Tapped!");
                }
                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x > 0)
                    {
                        Debug.Log("Right!");
                    }
                    else
                    {
                        Debug.Log("Left!");
                    }
                }
                else if (Mathf.Abs(x) < Mathf.Abs(y))
                {
                    if (y > 0)
                    {
                        Debug.Log("Up!");
                    }
                    else
                    {
                        Debug.Log("Down!");
                    }
                }
            }
        }
    }
}
