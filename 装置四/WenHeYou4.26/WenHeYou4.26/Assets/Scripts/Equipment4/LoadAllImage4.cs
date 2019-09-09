using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadAllImage4 : MonoBehaviour
{

    //public Texture2D[] texs;
    //string fullPath = "Equipment4/image";
    public Material[] materials;
  
    // Use this for initialization
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //public Texture2D[] Load()
    //  {

    //    var textures= Resources.LoadAll(fullPath,typeof(Texture2D));
    //      int countAll = textures.Length;
    //      Debug.Log(textures.Length);
    //      texs = new Texture2D[countAll];
    //      for (int i = 0; i < countAll; i++)
    //      {
    //          texs[i] = textures[i] as Texture2D;

    //      }
    //      Shuffle(texs);
    //      return texs;
    //  }

    public Material[] Load()
    {

        var mat = Resources.LoadAll("Equipment4/Materials", typeof(Material));
        int countAll = mat.Length;
        //Debug.Log(mat.Length);
        materials = new Material[countAll];
        for (int i = 0; i < countAll; i++)
        {
            materials[i] = mat[i] as Material;

        }
        Shuffle(materials);
        return materials;
    }

    public void Shuffle(Material[] deck)
    {
        for (int n = deck.Length - 1; n > 0; n--)
        {
            int k = Random.Range(0, n + 1);
            var temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
    }
    public Material[] CutToList(Material[] old, int num)
    {
        Shuffle(old);
        Material[] newOne = new Material[num];
        for (int n = 0; n < num; n++)
        {
            newOne[n] = old[n];
        }
        return newOne;
    }
}
