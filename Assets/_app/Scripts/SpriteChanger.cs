using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite pressedSprite;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ChangeButtonSprite()
    {
        if (buttonImage.sprite == normalSprite)
        {
            buttonImage.sprite = pressedSprite;
        }
        else
        {
            buttonImage.sprite = normalSprite;
        }
    }
}
