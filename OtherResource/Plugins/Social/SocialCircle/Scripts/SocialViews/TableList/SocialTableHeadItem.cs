using System.Collections.Generic;
using Assets.Scripts.Common.Utils;
using Assets.Scripts.Hall.View.RecordWindows;
using Assets.Scripts.Common.YxPlugins.Social.SocialViews.@base;
using UnityEngine;

namespace Assets.Scripts.Common.YxPlugins.Social.SocialViews.TableList
{
    /// <summary>
    /// ����Ȧ����ͷ��Item
    /// </summary>
    public class SocialTableHeadItem : BaseSocialHeadItem
    {
        [Tooltip("ͷ��ˢ���¼�")]
        public List<EventDelegate> HeadFreshAction = new List<EventDelegate>();
        /// <summary>
        /// �Ƿ���ʾͷ����Ϣ
        /// </summary>
        public bool NeedShowHead { set; get; }

        protected override void RefreshItem(Dictionary<string, object> dic)
        {
            if (gameObject.activeInHierarchy)
            {
                string nickName;
                dic.TryGetValueWitheKey(out nickName, HeadData.KeyName);
                NeedShowHead = !string.IsNullOrEmpty(nickName);
                StartCoroutine(HeadFreshAction.WaitExcuteCalls());
                if (ShowHead)
                {
                    base.RefreshItem(new SocialHeadData(dic));
                }
            }
        }
    }
}
