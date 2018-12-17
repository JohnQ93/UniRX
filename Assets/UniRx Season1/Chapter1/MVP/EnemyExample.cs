using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace UniRxLearning
{
    //Control
    public class EnemyExample : MonoBehaviour
    {
        EnemyModel mEnemy = new EnemyModel(200);
        public Button mButton;
        public Text mText;
        // Use this for initialization
        void Start()
        {
            mButton.OnClickAsObservable()
                   .Subscribe(_ =>
                   {
                       Debug.Log("clicked");
                       mEnemy.HP.Value -= 99;
                   });

            mEnemy.HP.SubscribeToText(mText);

            mEnemy.IsDead.Where(isDead => isDead)
                         .Select(isDead => !isDead)
                         .SubscribeToInteractable(mButton);
        }

    }
    //Model
    public class EnemyModel
    {
        public ReactiveProperty<long> HP;
        public IReadOnlyReactiveProperty<bool> IsDead;

        public EnemyModel(long initialHp)
        {
            HP = new ReactiveProperty<long>(initialHp);
            IsDead = HP.Select(x => x <= 0).ToReactiveProperty();
        }
    }
}

