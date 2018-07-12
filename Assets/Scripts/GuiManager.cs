using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour {

    public GameObject Panel;

    public static Image HeaderImage;
    public static Text HeaderText;

    public Building Building;

    public void Start()
    {
        HeaderImage = Panel.transform.FindChild("HeaderImage").GetComponent<Image>();
        HeaderText = Panel.transform.FindChild("HeaderText").GetComponent<Text>();
        Debug.Log("foo: " + HeaderText);
    }

    public static void DoFoo(Sprite img, string txt)
    {
        Debug.Log("foo: " + txt);
        HeaderImage.sprite = img;
        HeaderText.text = txt.ToUpper();
    }
}
