using UnityEngine;
using UnityEngine.UI;
namespace Utils.Slider
{
    public class CustomSlider : MonoBehaviour
    {
        [SerializeField] protected Color backgroundColor;
        [SerializeField] protected Color fillColor;
        [SerializeField] protected Image background;
        [SerializeField] protected Image fill;
        [SerializeField] protected bool overrideColors = false;

    }
}