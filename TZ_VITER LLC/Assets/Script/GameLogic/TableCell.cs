using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    
    public class TableCell : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        [HideInInspector]
        public GameObject blockCellImage;

        [HideInInspector]
        public bool isBlock;

        [HideInInspector]
        public bool pointerCell;

        private void Awake()
        {
            blockCellImage = transform.GetChild(0).gameObject;
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            pointerCell = true;
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            pointerCell = false;
        }
    }
}
