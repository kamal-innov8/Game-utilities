using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Challenge : MonoBehaviour, IPointerClickHandler
{
    public string Description;

    public abstract void OnPointerClick(PointerEventData eventData);

    public abstract event ChallengeDelegate Complete;
}