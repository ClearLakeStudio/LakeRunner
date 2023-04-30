/*
 * Filename: AnimateMenu.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Attach to UI elements to animate background images.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Attach sprite frames to the Sprite array.
 * Cycles through sprite array according the set fps.
 *
 * Member Variables:
 * sprites -- public Sprite array to add animation sprites.
 * fps -- public float to set the frames per second.
 * image -- private Image comopnent of the UI element.
 */
public class AnimateMenu : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites;
    public float fps = 2;

    private Image image;

    void Start()
    {
        Play();
    }

    /*
     * Gets the Image component of the UI element, then starts the Animation coroutine.
     */
    public void Play()
    {
        image = GetComponent<Image>();
        Stop();
        StartCoroutine(Animation());
    }

    /*
     * Stops the Animation coroutine and displays the first frame.
     */
    private void Stop()
    {
        StopAllCoroutines();
        ShowFrame(0);
    }

    /*
     * Shows the ith frame of the sprite animation.
     *
     * Parameterrs:
     * i -- int index to the sprite array
     */
    private void ShowFrame(int i)
    {
        image.sprite = sprites[i];
    }

    /*
     * Iterates through the Sprite array and shows each frame.
     * After each frame, delays according to the fps.
     *
     * Returns:
     * delay -- WaitForSeconds based on the frames per second.
     */
    private IEnumerator Animation()
    {
        var delay = new WaitForSeconds(1 / fps);

        while (true) {
            for (int i = 0; i < sprites.Length; i++) {
                ShowFrame(i);
                yield return delay;
            }
        }
    }
}
