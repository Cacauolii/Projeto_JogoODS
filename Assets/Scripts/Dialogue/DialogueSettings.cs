using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
     [Header("Settings")]
     public GameObject actor;
     public Sprite hairSprite;

     [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Setences> dialogues = new List<Setences>();
}

[System.Serializable]

public class Setences
{
public string actorName;
public Sprite profile;
public Lengueges sentence;
}

[System.Serializable]

public class Lengueges
{
public string portuguese;
public string english;
public string spanish;
}
