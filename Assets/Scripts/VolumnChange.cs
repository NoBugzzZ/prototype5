using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnChange : MonoBehaviour
{
    private Slider volumn;
    private AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        volumn = GetComponent<Slider>();
        volumn.onValueChanged.AddListener(ChangeVolumn);
        backgroundMusic = GameObject.Find("Background Music").GetComponent<AudioSource>();

        volumn.value = 0;
        backgroundMusic.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeVolumn(float volumn)
    {
        backgroundMusic.volume = volumn;
    }
}
