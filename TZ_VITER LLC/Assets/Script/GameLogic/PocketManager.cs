using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PocketManager : TableManager
    {
        [SerializeField] private Transform _pocketPanel;

        public bool activeCell;

        private bool _activeBlock;
        private List<Pocket> _pocket = new List<Pocket>();

        public static event OnActivBlock ActivBlock;
        public delegate void OnActivBlock(bool activ);
        private bool _checkBoks;


        static public PocketManager instance;

        private void Awake()
        {
            CreationCell();
            instance = GetComponent<PocketManager>();
        }

        private void Update()
        {
            MovingStop();
            WhereBlock();
            DeletionBlock();
            AddBlock();
        }

        public override void CreationCell()
        {
            for (int i = 0; i < _pocketPanel.childCount; i++)
            {
                var pocketPanelChild = _pocketPanel.GetChild(i).GetComponent<Pocket>();
                if (pocketPanelChild != null)
                    _pocket.Add(pocketPanelChild);
            }
        }

        public override void AddBlock()
        {

            foreach (Pocket pocket in _pocket)
            {
                if (pocket.isBlock)
                    break;
                else if (_checkBoks)
                    break;
                if (pocket.blocWasHere != true & pocket.pointerCell == true & pocket.isBlock != true & _movingBlockEnd != true)
                {
                    pocket.blockCellImage.gameObject.SetActive(true);
                    pocket.al = false;
                    pocket.blocWasHere = false;
                    activeCell = false;
                    WhereWasBlock();
                }
            }
        }

        private void DeletionBlock()
        {
            foreach (Pocket pocket in _pocket)
            {
                if (pocket.isBlock)
                {
                    if (pocket.isBlock == true & pocket.pointerCell == true & _movingBlockEnd == true)
                    {
                        pocket.blockCellImage.gameObject.SetActive(false);
                        pocket.blocWasHere = true;
                        activeCell = true;
                        _activeBlock = true;                      
                        ActivBlock(_activeBlock);
                        WhereWasBlock();               
                    }
                }
            }
        }

        private void MovingStop()
        {
            if (_activeBlock == true && _movingBlockEnd != true)
            {
                _activeBlock = false;
                ActivBlock(_activeBlock);
                StartCoroutine(RetentionReturnBlock());
            }
        }

        private void WhereWasBlock()
        {
            for (int i = 0; i < _pocket.Count; i++)
            {
                if (_pocket[i].isBlock != true && _pocket[i].blocWasHere == true)
                {
                    _pocket[i].blocWasHere = false;
                }
            }
        }
        
        private void WhereBlock()
        {
            foreach (Pocket pocket in _pocket)
            {
                if (pocket.blockCellImage.activeInHierarchy)
                {
                    pocket.isBlock = true;
                    _checkBoks = true;
                }
                else
                {
                    pocket.isBlock = false;
                    _checkBoks = false;
                }
            }
        }

        private void ReturnBlock()
        {
            foreach (Pocket pocket in _pocket)
            {
                if (pocket.isBlock)
                    break;
                if (pocket.blocWasHere == true)
                    pocket.blockCellImage.gameObject.SetActive(true);
            }
        }

        IEnumerator RetentionReturnBlock()
        {
            yield return new WaitForSeconds(0.10f);
            ReturnBlock();
        }
    }
}
