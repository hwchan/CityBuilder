using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    private Image _image;
    private Text _text;

    public void PopUp(string text, int fadeTime = 3)
    {
        gameObject.SetActive(true);

        if (_image == null || _text == null)
        {
            _image = GetComponent<Image>();
            _text = transform.Find("Text").GetComponent<Text>();
        }

        _text.text = text;
        StartCoroutine(PopUpCoroutine(fadeTime));
    }

    private IEnumerator PopUpCoroutine(int fadeTime)
    {
        _image.CrossFadeAlpha(1, 1, false);
        _text.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(fadeTime);
        _image.CrossFadeAlpha(0, 1, false);
        _text.CrossFadeAlpha(0, 1, false);
    }
}
