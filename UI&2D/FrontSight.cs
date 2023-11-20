using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///
/// <summary>

public class frontSight : MonoBehaviour
{
    public RectTransform theRrontSightHW;
    public Image image;
    public Color imageColor;
    public float X;
    public float Y;

    public float wantedWidth = 120;
    public float wantedHeight = 120;

    private void Awake()
    {
        FirstSet();
    }

    private void Update()
    {
        ToClick();
    }

    private void ToClick()
    {
        if (Input.GetMouseButton(0))
        {
            theRrontSightHW.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, wantedWidth);
            theRrontSightHW.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, wantedHeight);
            image.color= Color.red;
        }
        else
        {
            theRrontSightHW.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, X);
            theRrontSightHW.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Y);
            image.color = imageColor;
        }
    }

    private void FirstSet()
    {
        image = this.GetComponent<Image>();
        theRrontSightHW = this.GetComponent<RectTransform>();
        imageColor = this.GetComponent<Image>().color;
        X = theRrontSightHW.rect.width;
        Y = theRrontSightHW.rect.height;
    }
}
