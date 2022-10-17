using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    public class ScrollbarManager : MonoBehaviour, IPointerExitHandler
    {
        [SerializeField] private GameObject _soundPanel;

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            StartCoroutine(RetentionExitPanel());
        }

        private void ExitPanel()
        {
            _soundPanel.gameObject.SetActive(false);
        }

        IEnumerator RetentionExitPanel()
        {
            yield return new WaitForSeconds(5.2f);
            ExitPanel();
        }
    }
}
