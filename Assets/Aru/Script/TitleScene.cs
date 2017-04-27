using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour
{
    private float timer = 0.5f;
    public MovieTexture movie;
    public UnityEngine.UI.Image click;
    public Fade fade;   // フェード対象

    void Start()
    {
        movie.Play();
        Cursor.visible = false;
    }

    void Update()
    {
        if (movie.isPlaying)
            return;

        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            timer = 0f;

            click.enabled = !click.enabled;
        }

        if (Input.GetButtonDown("Fire1"))
            fade.FadeOut();
    }
}
