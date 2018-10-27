using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "objectdataValue", menuName="ObjectData")]
public class objectdataValue : ScriptableObject
{
    public string objectName;
    public string tag;
    public float value;
    public Sprite objectSprite;
}

