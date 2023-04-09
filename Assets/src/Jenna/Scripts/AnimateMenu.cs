using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateMenu : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites;
    public Image image;
    public float fps = 2;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        Play();
    }

    private void Play()
    {
        Stop();
        StartCoroutine(Animation());
    }

    private void Stop()
    {
        StopAllCoroutines();
        ShowFrame(0);
    }

    private void ShowFrame(int i)
    {
        image.sprite = sprites[i];
    }

    IEnumerator Animation()
    {
        var delay = new WaitForSeconds(1 / fps);
        int i = 0;

        while (true) {
            if (i >= sprites.Length) {
                i = 0;
            }

            ShowFrame(i);
            i++;
            yield return delay;
        }
    }
}
