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

        StartCoroutine(CoStart());


        #region weapon
        if (Player.Instance._isStick == true)
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
            _listTop[0].SetActive(true);

        }
        else if (Player.Instance._isMasicianTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            _listTop[1].SetActive(true);
        }
        else if (Player.Instance._isDurumagiTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
            }
            _listTop[2].SetActive(true);
        }
        else if (Player.Instance._isNormalTop == true)
        {
            for (int i = 0; i < _listTop.Count; ++i)
            {
                _listTop[i].SetActive(false);
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
            _listBottom[0].SetActive(true);

        }
        else if (Player.Instance._isMasicianBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            _listBottom[1].SetActive(true);
        }
        else if (Player.Instance._durumagiBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
            }
            _listBottom[2].SetActive(true);
        }
        else if (Player.Instance._trunkBottom == true)
        {
            for (int i = 0; i < _listBottom.Count; ++i)
            {
                _listBottom[i].SetActive(false);
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
            _listShoes[0].SetActive(true);

        }
        else if (Player.Instance._isSandal == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            _listShoes[1].SetActive(true);
        }
        else if (Player.Instance._isOldShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            _listShoes[2].SetActive(true);
        }
        else if (Player.Instance._isnormalShoes == true)
        {
            for (int i = 0; i < _listShoes.Count; ++i)
            {
                _listShoes[i].SetActive(false);
            }
            _listShoes[3].SetActive(true);
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




        if (Player.Instance._playerTitle == Player.PlayerTitle.Priest && Player.Instance._skill1 >= 3 && Player.Instance._hp >= Player.Instance._maxHp)
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

    public void AttackOff()
    {
        Player.Instance.AttackOff();
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
