using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionAnimation : MonoBehaviour
{
    [SerializeField] private Image _image = default;
    // [SerializeField] private Text _text = default;

    public static TransitionAnimation CreateImage(string imagePath, Vector3 pos, Vector3 from, Vector3 to, float fadeTime)
    {
        var sprite = Resources.Load<Sprite>(imagePath);
        return CreateImage(sprite, pos, from, to, fadeTime);
    }

    public static TransitionAnimation CreateImage(Sprite image, Vector3 pos, Vector3 from, Vector3 to, float fadeTime)
    {
        var go = Instantiate(Globals.Expiry, pos, Quaternion.identity);
        var ta = go.GetComponent<TransitionAnimation>();
        go.transform.SetParent(Globals.TransitionAnimationPanel.transform, true);
        ta.InitializeImage(image, from, to, fadeTime);
        return ta;
    }

    private void InitializeImage(Sprite sprite, Vector3 from, Vector3 to, float fadeTime)
    {
        _image.sprite = sprite;
        _image.gameObject.SetActive(true);
        StartCoroutine(FadeOut(fadeTime, _image));
        StartCoroutine(Enlarge(fadeTime, from, to));
        Destroy(gameObject, fadeTime + 1.2f);
    }

    private IEnumerator FadeOut(float time, params Graphic[] objects)
    {
        foreach (var g in objects)
            g.CrossFadeAlpha(1, .35f, false);

        yield return new WaitForSeconds(Mathf.Max(time - 1.1f, 0));

        foreach (var g in objects)
            g.CrossFadeAlpha(0, .75f, false);
    }

    private IEnumerator Enlarge(float time, Vector3 from, Vector3 to)
    {
        float elapsed = 0;

        while (transform.localScale != to)
        {
            transform.localScale = Vector3.Lerp(from, to, elapsed / time);
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
