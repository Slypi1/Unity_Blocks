using UnityEngine;

namespace GameLogic
{
    public class BlockControl : MonoBehaviour
    {
        [SerializeField] private GameObject _block;
        private bool _blockIsMoving;

        void OnEnable()
        {
            PocketManager.ActivBlock += Activ;
            InputPlayer.NewPossition += Moving;
        }

        void OnDisable()
        {
            PocketManager.ActivBlock -= Activ;
            InputPlayer.NewPossition += Moving;
        }

        private void Activ(bool activ)
        {
            _block.gameObject.SetActive(activ);
            _blockIsMoving = activ;
        }

        private void Moving(Vector3 newPosition)
        {
            if (_blockIsMoving)
                _block.transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
