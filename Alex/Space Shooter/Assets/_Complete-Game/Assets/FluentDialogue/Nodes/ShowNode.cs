using UnityEngine;
using System.Collections;
using Fluent;
using System;

namespace Fluent
{
    public class ShowNode : FluentNode
    {
        GameObject gameObjectToShow;

        public ShowNode(GameObject gameObject) : base(gameObject)
        {
        }

        public ShowNode(GameObject gameObject, GameObject gameObjectToShow) : base(gameObject)
        {
            if (gameObjectToShow == null)
                Debug.LogWarning("You are trying to hide a null gameObject");
            this.gameObjectToShow = gameObjectToShow;
        }


        public override void Execute()
        {
            if (gameObjectToShow != null)
            {
                gameObjectToShow.SetActive(true);
                Done();
                return;
            }

            OptionsPresenter optionsPresenter = GameObject.GetComponent<OptionsPresenter>();
            if (optionsPresenter == null)
            {
                Debug.Log("You need to add an OptionsPresenter if you want to show it", GameObject);
                return;
            }
            optionsPresenter.Show();
            Done();
        }

        public override void BeforeExecute()
        {
        }

        public override string StringInEditor()
        {
            return "<b>Show</b>";
        }
    }

    public partial class FluentScript : MonoBehaviour
    {
        public FluentNode Show()
        {
            return new ShowNode(gameObject);
        }

        public FluentNode Show(GameObject gameObjectToShow)
        {
            return new ShowNode(gameObject, gameObjectToShow);
        }
    }

}
