using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class VideoPlayerScript : MonoBehaviour
{
    [InlineButton("Play")]
    public bool PlayOnEnable = true;
    [InlineButton("SetScale")]
    public Vector3 scale;
    public UnityEvent OnVideoEnd;

    private VideoPlayer player;
    private Coroutine _playing;

    [SerializeField]
    private Text current, max;
    [SerializeField]
    private Image fill;

    private void Awake()
    {
        if (player == null)
            player = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (ApplicationManage.instance != null)
            if (ApplicationManage.instance.StillTracking == false)
            {
                this.gameObject.SetActive(false);
            }

        updatePlayerTimeLine();

        transform.LookAt(Camera.main.transform, Vector3.up);
    }

    void updatePlayerTimeLine()
    {
        if (current)
            current.text = second_to_time(player.time);
        if (fill)
            fill.fillAmount = (float)(player.time / player.clip.length);
    }

    string second_to_time(double sec)
    {
        return ((int)(sec / 60)).ToString("00") + ":" + ((int)(sec % 60)).ToString("00");
    }

    void OnEnable()
    {
        if (PlayOnEnable)
            Play();

        if (fill)
            fill.fillAmount = 0f;
        if (current)
            current.text = second_to_time(player.time);
        if (max)
            max.text = second_to_time(player.clip.length);
    }

    public void Play()
    {
        if (_playing != null)
            StopCoroutine(_playing);
        _playing = StartCoroutine(play());

        transform.localScale = Vector3.zero;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", scale, "time", 0.5f));
    }

    public void SetScale()
    {
        scale = transform.localScale;
    }

    IEnumerator play()
    {
        while (player == null)
            yield return null;
        
        player.Play();

        // wait for player to start playing.
        while (player.isPlaying == false)
            yield return null;
        // wait for video to end.
        while (player.isPlaying)
            yield return null;

        yield return new WaitForSeconds(1f);

        iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f));
        OnVideoEnd.Invoke();
    }

}
