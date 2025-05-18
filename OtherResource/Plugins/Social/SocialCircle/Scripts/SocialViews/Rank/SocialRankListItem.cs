using System.Collections.Generic;
using Assets.Scripts.Common.Utils;
using Assets.Scripts.Common.YxPlugins.Social.SocialViews.@base;
using UnityEngine;
using YxFramwork.Common.Adapters;

namespace Assets.Scripts.Common.YxPlugins.Social.SocialViews.Rank
{
    /// <summary>
    /// �ȶ�����item
    /// </summary>
    public class SocialRankListItem : BaseSocialSelectWrapItem
    {
        [Tooltip("���������ı�")]
        public YxBaseLabelAdapter RankNumLabel;
        [Tooltip("��������ͼƬ")]
        public YxBaseSpriteAdapter RankNumSprite;
        [Tooltip("��Ӧ��������ʾ��Ƭ��ʽ������")]
        public int RankImageLenth = 3;
        [Tooltip("����ͼƬ��ʽ")]
        public string RankFormat = "Rank_{0}";
        [Tooltip("��ʾͼƬ�¼�")]
        public List<EventDelegate> ShowImageAction=new List<EventDelegate>();
        /// <summary>
        /// �Ƿ���ʾ����ͼƬ
        /// </summary>
        public bool ShowRankImage
        {
            private set;
            get;
        }

        protected override void DealFreshData()
        {
            base.DealFreshData();
            ShowRankImage = IdCode < RankImageLenth;
            if (ShowRankImage)
            {
                RankNumSprite.TrySetComponentValue(string.Format(RankFormat, IdCode + 1));
            }
            else
            {
                RankNumLabel.TrySetComponentValue(IdCode + 1);
            }

            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ShowImageAction.WaitExcuteCalls());
            }
        }

    }
}
