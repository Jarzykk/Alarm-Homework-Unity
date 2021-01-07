using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private bool _alarmActive = false;
    private bool _decreaseAlarmVolume = true;
    private AudioSource _alarmSound;
    private float _alarmMuteTime = 1.5f;
    private float _alarmMuteTimePassed;

    void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(_alarmActive)
        {
            if(_decreaseAlarmVolume == true)
            {
                ChangeSoundVolume(_alarmSound, 1, 0);
            }
            else if(_decreaseAlarmVolume == false)
            {
                ChangeSoundVolume(_alarmSound, 0, 1);
            }

            if (_alarmSound.volume == 0)
                _decreaseAlarmVolume = false;
            else if (_alarmSound.volume == 1)
                _decreaseAlarmVolume = true;
        }

        Debug.Log(_decreaseAlarmVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _alarmActive = !_alarmActive;

        if (_alarmActive)
            _alarmSound.Play();
        else
            _alarmSound.Stop();
    }

    private void ChangeSoundVolume(AudioSource sound, float volumeAtBeggining, float volumeAtEnd)
    {
        _alarmMuteTimePassed += Time.deltaTime;
        sound.volume = Mathf.Lerp(volumeAtBeggining, volumeAtEnd, _alarmMuteTimePassed / _alarmMuteTime);

        if (_alarmMuteTimePassed >= _alarmMuteTime)
            _alarmMuteTimePassed = 0;
    }
}
