using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDecoy : MonoBehaviour
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


    private void Start()
    {
        

        #region weapon
        if (Player.Instance._isbasicStick == true)
        {

            for (int i = 0; i < _listWeapon.Count; ++i)
            {
                _listWeapon[i].SetActive(false);
            }
            _listWeapon[0].SetActive(true);
            Player.Instance._weapon = Player.Instance._basicStick;

        }
        else if (Player.Instance._isSward1 == true)
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
            for (int i = 0; i < _listTopDeco.Count; ++i)
            {
                _listTopDeco[i].SetActive(false);
            }
            for (int i = 0; i < _listSkin.Count; ++i)
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
            for (int i = 0; i < _listBottomDeco.Count; ++i)
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
            for (int i = 0; i < _listShoesDeco.Count; ++i)
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
   

  


  

}
