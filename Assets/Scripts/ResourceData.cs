using UnityEngine;

[CreateAssetMenu(fileName="Resource", menuName="ScriptableObjects/Resource")]
public class ResourceData : ScriptableObject
{
    public string key;
    public int coinModifier;
    public int foodModifier;
    public Sprite sprite;
}
