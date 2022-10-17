using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class TableManager : MonoBehaviour
    {
        [SerializeField] private Transform _tablePanel;
        private List<TableCell> _cell = new List<TableCell>();

        [HideInInspector]
        public bool _movingBlockEnd;

        private bool _isVictory;

        public static event OnisVictory Victory;
        public delegate void OnisVictory(bool isVictory);

        private void Awake()
        {
            CreationCell();
        }

        private void OnEnable()
        {
            InputPlayer.Moving += MotionCheck;
        }
        private void OnDisable()
        {
            InputPlayer.Moving -= MotionCheck;
        }
        private void Update()
        {
            AddBlock();
            IsVictory();
        }

        public virtual void CreationCell()
        {
            for (int i = 0; i < _tablePanel.childCount; i++)
            {
                var tablePanelChild = _tablePanel.GetChild(i).GetComponent<TableCell>();
                if (tablePanelChild != null)
                    _cell.Add(tablePanelChild);
            }
        }

        public virtual void AddBlock()
        {
            foreach (TableCell cell in _cell)
            {
                if (PocketManager.instance.activeCell)
                {
                    if (cell.pointerCell == true && _movingBlockEnd != true && cell.isBlock != true)
                    {
                        cell.blockCellImage.gameObject.SetActive(true);
                        cell.isBlock = true;
                    }
                }
            }
        }

        private void MotionCheck(bool movingBlock)
        {
            _movingBlockEnd = movingBlock;
        }

        private void IsVictory()
        {
            if (_cell[4].isBlock)
            {
                DisappearanceOfBloks();
                _isVictory = true;
                Victory(_isVictory);
            }


            for (int i = 0; i < _cell.Count; i++)
            {
                if (_cell[i].isBlock & _cell[4].isBlock != true)
                {
                    _isVictory = false;
                    Victory(_isVictory);
                }
            }

        }
        private void DisappearanceOfBloks()
        {
            _cell[3].blockCellImage.gameObject.SetActive(false);
            _cell[4].blockCellImage.gameObject.SetActive(false);
            _cell[5].blockCellImage.gameObject.SetActive(false);
        }
    }
}
