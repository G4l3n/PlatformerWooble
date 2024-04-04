using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    [SerializeField] private Reload _reload;
    [SerializeField] private Image _frontImage;
    [SerializeField] private float _tweenDuration;


    public void UiUnload()
    {
        float targetFillAmount = Mathf.InverseLerp(0, _reload._max, _reload.Magazine);
        _frontImage.DOFillAmount(targetFillAmount, _tweenDuration / 2f).SetEase(Ease.OutQuint);
    }
    public void Uiload()
    {
        float targetFillAmount = Mathf.InverseLerp(0, _reload._max, _reload.Magazine);
        _frontImage.DOFillAmount(targetFillAmount, _tweenDuration / 2f).SetEase(Ease.OutQuint);
    }
}
