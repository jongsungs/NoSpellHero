using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    
    public List<GameObject> _listWeapon = new List<GameObject>();
    public List<GameObject> _listHelmet = new List<GameObject>();
    public List<GameObject> _listHair = new List<GameObject>();
    public List<GameObject> _listTop = new List<GameObject>();
    public List<GameObject> _listBottom = new List<GameObject>();
    public List<GameObject> _listShoes = new List<GameObject>();
    public List<GameObject> _listTopDeco = new List<GameObject>();
    public List<GameObject> _listBottomDeco = new List<GameObject>();
    public List<GameObject> _listShoesDeco = new List<GameObject>();
    public List<GameObject> _listSkin = new List<GameObject>();

    public List<GameObject> _listLubuEffect = new List<GameObject>();
    public GameObject _warlockEffect;
    public GameObject _pristHiddenEffect;
    public GameObject _gamblerRich;
    public GameObject _gamblerPoor;
    public GameObject _jeusEffect;
    public GameObject _madManEffect;
    public GameObject _helenEffect;
    public GameObject _repairManEffect;
    public GameObject _dosaEffect;
    public GameObject _salamanderEffect;
    public MoreMountains.Feedbacks.MMFloatingTextSpawner _floatingTextSpawner;
    public MoreMountains.Feedbacks.MMF_Player _mmfPlayer;

    public bool _onhit;
    private void Start()
    {
        for(int i = 0; i < _listLubuEffect.Count; ++i)
        {
            _listLubuEffect[i].SetActive(false);
        }
        _warlockEffect.SetActive(false);        //
        _pristHiddenEffect.SetActive(false);
        _gamblerRich.SetActive(false);          //
        _gamblerPoor.SetActive(false);          //
        _jeusEffect.SetActive(false);           //
        _madManEffect.SetActive(false);         //
        _helenEffect.SetActive(false);          //
        _repairManEffect.SetActive(false);      //
        _dosaEffect.SetActive(false);           //
        _salamanderEffect.SetActive(false);

        StartCoroutine(CoStart());


        #region weapon
        if (Player.Instance._isbasicStick == true)
        {

            for(int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[0].SetActive(true);
            Player.Instance._weapon = Player.Instance._basicStick;

        }
        else if(Player.Instance._isSward1 == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[1].SetActive(true);
            Player.Instance._weapon = Player.Instance._Sward1;
        }
        else if (Player.Instance._isSward2 == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[2].SetActive(true);
            Player.Instance._weapon = Player.Instance._Sward2;
        }
        else if (Player.Instance._isBroom == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[3].SetActive(true);
            Player.Instance._weapon = Player.Instance._Broom;
        }
        else if (Player.Instance._isClub == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[4].SetActive(true);
            Player.Instance._weapon = Player.Instance._Club;
        }
        else if (Player.Instance._isShortSward == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[5].SetActive(true);
            Player.Instance._weapon = Player.Instance._ShortSward;
        }
        else if (Player.Instance._isHanger == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[6].SetActive(true);
            Player.Instance._weapon = Player.Instance._Hanger;
        }
        else if (Player.Instance._isMace == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[7].SetActive(true);
            Player.Instance._weapon = Player.Instance._Mace;
        }
        else if (Player.Instance._isShield == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[8].SetActive(true);
            Player.Instance._weapon = Player.Instance._Shield;
        }
        else if (Player.Instance._isSpear == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[9].SetActive(true);
            Player.Instance._weapon = Player.Instance._Spear;
        }
        else if (Player.Instance._isUmbrella == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[10].SetActive(true);
            Player.Instance._weapon = Player.Instance._Umbrella;
        }
        else if (Player.Instance._isWaldo == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[11].SetActive(true);
            Player.Instance._weapon = Player.Instance._Waldo;
        }
        else if (Player.Instance._isStick == true)
        {
            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[12].SetActive(true);
            Player.Instance._weapon = Player.Instance._Stick;
        }
        #endregion

        #region Helmet
        if (Player.Instance._isKightHelmet == true)
        {

            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[0].SetActive(true);

        }
        else if (Player.Instance._isMasicianHat == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[1].SetActive(true);
        }
        else if (Player.Instance._isGat == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[2].SetActive(true);
        }
        else if (Player.Instance._isEmptyHelmet == true)
        {
            for (int i = 0; i < _listHelmet.Count; ++i)
            {
                _listHelmet[i].SetActive(false);
            }
            _listHelmet[3].SetActive(true);
        }
        #endregion

        #region Hair
        if (Player.Instance._isSkinHead == true)
        {

            for (int i = 0; i < _listHair.Count; ++i)
            {
                _listHair[i].SetActive(false);
            }
            _listHair[0].SetActive(true);

        }
        else if (Player.Instance._isnormalHair == true)
        {
            for (int i = 0; i < _listHair.Count; ++i)
            {
                _listHair[i].SetActive(false);
            }
            _listHair[1].SetActive(true);
        }
        #endregion

        #region Top
        if (Player.Instance._isKnightTop == true)
        {

            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for(int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for(int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }

            _listTop[0].SetActive(true);
            _listTopDeco[0].SetActive(true);
            _listSkin[0].SetActive(true);
        }
        else if (Player.Instance._isMasicianTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }

            _listTopDeco[1].SetActive(true);
            _listTop[1].SetActive(true);

        }
        else if (Player.Instance._isDurumagiTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }
            _listSkin[1].SetActive(true);
            _listTopDeco[2].SetActive(true);
            _listTop[2].SetActive(true);
        }
        else if (Player.Instance._isNormalTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
            {
                _listSkin[i].SetActive(false);
            }
            _listTop[3].SetActive(true);
        }
        #endregion


        #region Bottom
        if (Player.Instance._isKnightBottom == true)
        {

            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for(int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[0].SetActive(true);
            _listBottomDeco[0].SetActive(true);
        }
        else if (Player.Instance._isMasicianBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[1].SetActive(true);
            _listBottomDeco[1].SetActive(true);
        }
        else if (Player.Instance._isdurumagiBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[2].SetActive(true);
            _listBottomDeco[2].SetActive(true);
        }
        else if (Player.Instance._isTrunkBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            for (int i = 0; i < _listBottomDeco.Count; ++i)
            {
                _listBottomDeco[i].SetActive(false);
            }
            _listBottom[3].SetActive(true);
        }

        #endregion

        #region Shoes
        if (Player.Instance._isKnightShoes == true)
        {

            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for(int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoesDeco[0].SetActive(true);
            _listShoesDeco[1].SetActive(true);
            _listShoes[0].SetActive(true);
            _listShoes[1].SetActive(true);

        }
        else if (Player.Instance._isSandal == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[2].SetActive(true);
            _listShoes[3].SetActive(true);
        }
        else if (Player.Instance._isOldShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[4].SetActive(true);
            _listShoes[5].SetActive(true);
        }
        else if (Player.Instance._isnormalShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            for (int i = 0; i < _listShoesDeco.Count; ++i)
            {
                _listShoesDeco[i].SetActive(false);
            }

            _listShoes[6].SetActive(true);
            _listShoes[7].SetActive(true);
        }
        #endregion

    }
    private void Update()
    {
        if(Player.Instance._playerTitle == Player.PlayerTitle.Gambler &&
           ( Player.Instance._atk >= Player.Instance._basicAtk + (Player.Instance._basicAtk * 0.1f)|| Player.Instance._matk >= Player.Instance._basicMatk + (Player.Instance._basicMatk * 0.1f) || Player.Instance._hp >= Player.Instance._basicHp + (Player.Instance._basicHp * 0.1f) || Player.Instance._atkSpeed >= Player.Instance._basicAtkSpeed + (Player.Instance._basicAtkSpeed * 0.1f) ||
            Player.Instance._def >= Player.Instance._basicDef + (Player.Instance._basicDef * 0.1f) || Player.Instance._speed >= Player.Instance._basicSpeed + (Player.Instance._basicSpeed * 0.1f) || Player.Instance._critical >= Player.Instance._basicCritical + (Player.Instance._basicCritical * 0.1f) || Player.Instance._handicraft >= Player.Instance._basicHandicraft + (Player.Instance._basicHandicraft * 0.1f) ||
            Player.Instance._charm >= Player.Instance._basicCharm + (Player.Instance._basicCharm * 0.1f)))
        {
            _gamblerRich.SetActive(true);
            _gamblerPoor.SetActive(false);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Gambler &&
            (Player.Instance._atk <= Player.Instance._basicAtk - (Player.Instance._basicAtk * 0.1f) || Player.Instance._matk <= Player.Instance._basicMatk - (Player.Instance._basicMatk * 0.1f) || Player.Instance._hp <= Player.Instance._basicHp - (Player.Instance._basicHp * 0.1f) || Player.Instance._atkSpeed <= Player.Instance._basicAtkSpeed - (Player.Instance._basicAtkSpeed * 0.1f) ||
            Player.Instance._def <= Player.Instance._basicDef - (Player.Instance._basicDef * 0.1f) || Player.Instance._speed <= Player.Instance._basicSpeed - (Player.Instance._basicSpeed * 0.1f) || Player.Instance._critical <= Player.Instance._basicCritical - (Player.Instance._basicCritical * 0.1f) || Player.Instance._handicraft <= Player.Instance._basicHandicraft - (Player.Instance._basicHandicraft * 0.1f) ||
            Player.Instance._charm <= Player.Instance._basicCharm - (Player.Instance._basicCharm * 0.1f)))
        {
            _gamblerPoor.SetActive(true);
            _gamblerRich.SetActive(false);
        }
        else if(Player.Instance._playerTitle == Player.PlayerTitle.LuBu && Player.Instance._skill3 >=3)
        {
            _listLubuEffect[2].SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu && Player.Instance._skill3 >= 2)
        {
            _listLubuEffect[1].SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Salamander && Player.Instance._skill2 >= 3)
        {
            _salamanderEffect.SetActive(true);
        }





        if (Player.Instance._playerTitle == Player.PlayerTitle.Priest && Player.Instance._skill1 >= 3 && Player.Instance._ingameHp >= Player.Instance._maxHp)
        {
            _pristHiddenEffect.SetActive(true);
        }
        else
        {
            _pristHiddenEffect.SetActive(false);
        }

        
    }

    public void AttackOn()
    {
        Player.Instance.AttackOn();
    }
    public void Attack2nd()
    {
        Player.Instance.Attack2nd();
    }
    public void AttackOff()
    {
        Player.Instance.AttackOff();
    }
    public void Step()
    {
        GamePlay.Instance._footStepPool.Get();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bone"))
        {
            var damage = other.GetComponent<SkillBase>()._skillDamage - (Player.Instance._def * 3f);
            if (damage <= 0)
            {
                damage = 0f;
            }
            damage = Mathf.Round(damage);
            Player.Instance._ingameHp -= damage;
            GamePlay.Instance._playerHp.UpdateBar(Player.Instance._ingameHp, 0, Player.Instance._maxHp);
            _mmfPlayer.PlayFeedbacks(transform.position, damage);

            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            other.GetComponent<SkillBase>().SkillRelease();
            Player.Instance._hitCount++;
        }
        else if (other.CompareTag("Rock"))
        {
            var damage = other.GetComponent<SkillBase>()._skillDamage - (Player.Instance._def * 3f);
            if (damage <= 0)
            {
                damage = 0f;
            }
            damage = Mathf.Round(damage);
            Player.Instance._ingameHp -= damage;
            GamePlay.Instance._playerHp.UpdateBar(Player.Instance._ingameHp, 0, Player.Instance._maxHp);
            _mmfPlayer.PlayFeedbacks(transform.position, damage);

            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            other.GetComponent<SkillBase>().SkillRelease();
            Player.Instance._hitCount++;
        }
        else if (other.CompareTag("DemonKingMeteor"))
        {
            var damage = other.GetComponent<SkillBase>()._skillDamage;
            if (damage <= 0)
            {
                damage = 0f;
            }
            damage = Mathf.Round(damage);
            Player.Instance._ingameHp -= damage;
            GamePlay.Instance._playerHp.UpdateBar(Player.Instance._ingameHp, 0, Player.Instance._maxHp);
            _mmfPlayer.PlayFeedbacks(transform.position, damage);

            SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
            Player.Instance._hitCount++;
        }
        else if (other.CompareTag("Weapon") && other.transform.root.GetComponent<Monster>() != null && other.transform.root.gameObject.layer == 6)
        {
            if( other.GetComponent<Weapon>()._isOnce == true)
            {

                other.GetComponent<Weapon>()._isOnce = false;
                var damage = other.GetComponent<Weapon>()._damage - (Player.Instance._def * 3f);
                if (damage <= 0)
                {
                    damage = 0f;
                }
                damage = Mathf.Round(damage);
                Player.Instance._ingameHp -= damage;
                GamePlay.Instance._playerHp.UpdateBar(Player.Instance._ingameHp, 0, Player.Instance._maxHp);
                _mmfPlayer.PlayFeedbacks(transform.position, damage);
                SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
                Player.Instance._hitCount++;
            }

        }
       

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("FireBress"))
        {
            if(_onhit == false)
            {

                _onhit = true;
                var damage = other.GetComponent<SkillBase>()._skillDamage - (Player.Instance._def * 3f);
                if (damage <= 0)
                {
                    damage = 0f;
                }
                damage = Mathf.Round(damage);
                Player.Instance._ingameHp -= damage;
                GamePlay.Instance._playerHp.UpdateBar(Player.Instance._ingameHp, 0, Player.Instance._maxHp);
                _mmfPlayer.PlayFeedbacks(transform.position, damage);
                SoundManager.Instance.EffectPlay(SoundManager.Instance._playerHit);
                Player.Instance._hitCount++;
                StartCoroutine(CoHit());
            }


        }
    }

    public IEnumerator CoHit()
    {
        yield return new WaitForSeconds(0.5f);
        _onhit = false;
    }
    public IEnumerator CoStart()
    {
        yield return new WaitForSeconds(3f);

        if (Player.Instance._playerTitle == Player.PlayerTitle.MadMan)
        {
            _madManEffect.SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Warlock)
        {
            _warlockEffect.SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Dosa)
        {
            _dosaEffect.SetActive(true);
        }
        else if(Player.Instance._playerTitle == Player.PlayerTitle.Repairman)
        {
            _repairManEffect.SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Helen)
        {
            _helenEffect.SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.Zeus)
        {
            _jeusEffect.SetActive(true);
        }
        else if (Player.Instance._playerTitle == Player.PlayerTitle.LuBu)
        {
            _listLubuEffect[0].SetActive(true);
        }

    }

}
