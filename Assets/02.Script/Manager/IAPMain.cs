using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.Events;

public class IAPMain : MonoBehaviour
{

    public IAPButton _btnRemoveAd;



    private void Start()
    {
        this._btnRemoveAd.onPurchaseComplete.AddListener(new UnityAction<Product>((product) =>
        {
            Debug.LogFormat("���� ����" , product.transactionID);
        }));
        this._btnRemoveAd.onPurchaseFailed.AddListener(new UnityAction<Product, PurchaseFailureReason>((product, reason) =>
        {
            Debug.LogFormat("���� ����: ", product.transactionID, reason);
        }));
        

    }

}
