using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance { get; private set; }
    public enum Sound : int
    {
        BGM,
        Effect
    }


    public AudioMixer _soundMixer;


    public List<AudioSource> _audiosource = new List<AudioSource>();

    public AudioClip _attck;
    public AudioClip _blizard;
    public AudioClip _buff;
    public AudioClip _chainlightning;
    public AudioClip _debuff;
    public AudioClip _playerdie;
    public AudioClip _dungeon;
    public AudioClip _fasniftion;
    public AudioClip _fireball;
    public AudioClip _firballex;
    public AudioClip _gameplaySettingPopUp;
    public AudioClip _gameplaySettingPopUpClose;
    public AudioClip _heal;
    public AudioClip _playerHit;
    public AudioClip _iceball;
    public AudioClip _meteorex;
    public AudioClip _monsterdie;
    public AudioClip _monsterhit;
    public AudioClip _nope;
    public AudioClip _pop;
    public AudioClip _pop2;
    public AudioClip _spawn;
    public AudioClip _startgame;
    public AudioClip _step;
    public AudioClip _thunder;
    public AudioClip _meteor;
    public AudioClip _decline;
    public AudioClip _blackHole;
    public AudioClip _result;
    public AudioClip _monsterAttack;
    public AudioClip _lobbyBgm;
    public AudioClip _gamePlayBgm;


    private void Awake()
    {
        Instance = this;
    }

    public void SetEffectVolume(float slider)
    {
        Player.Instance._effectSound = slider;
        _soundMixer.SetFloat("Effect", Mathf.Log10(Player.Instance._effectSound) * 20);
        Player.Instance.Save();
    }

    public void SetBGMVolume(float slider)
    {
        Player.Instance._bgmSound = slider;
        _soundMixer.SetFloat("BGM", Mathf.Log10(Player.Instance._bgmSound) * 20);
        Player.Instance.Save();
    }


    public void EffectPlay(AudioClip clip)
    {
        _audiosource[1].PlayOneShot(clip);
        
    }
    public void BGMPlay(AudioClip clip)
    {
        if (_audiosource[0].isPlaying)
            _audiosource[0].Stop();
        _audiosource[0].clip = clip;
        _audiosource[0].Play();
    }
}

