using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodDisplay : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _deltaText;

    public void Set(int count)
    {
        _text.text = count.ToString();
        PlayDeltaAnimation(0);
        gameObject.SetActive(true);
    }

    public void Clear()
    {
        gameObject.SetActive(false);
    }

    public void PlayDeltaAnimation(int delta)
    {
        if (delta == 0)
        {
            _deltaText.enabled = false;
            return;
        }

        _deltaText.text = delta.ToString();
        _deltaText.enabled = true;
        _deltaText.CrossFadeAlpha(1, 0, false);

        if (delta > 0)
        {
            _deltaText.text = "+" + delta;
            _deltaText.color = Color.black;
        }
        else
        {
            _deltaText.text = "-" + delta;
            _deltaText.color = Color.red;
        }
        _deltaText.CrossFadeAlpha(0, 3, false);
    }
}
