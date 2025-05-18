using UnityEngine;
using YxFramwork.Common.Adapters;
using YxFramwork.Common.Utils;
using YxFramwork.Framework;
using YxFramwork.Framework.Core;
using YxFramwork.Tool;

namespace Assets.Scripts.Common.components
{
    /// <inheritdoc />
    /// <summary>
    /// key��value����ͼ
    /// </summary>
    public class YxKeyValueView : YxView
    {
        [Tooltip("key��Label")]
        public YxBaseLabelAdapter KeyLable;
        [Tooltip("value��Label")]
        public YxBaseLabelAdapter ValueLable;
        [Tooltip("value��ͼ��")]
        public YxBaseTextureAdapter Icon;
        [Tooltip("value��ͼ��")]
        public YxBaseWidgetAdapter Widget;
        [Tooltip("�ָ��ʾ")]
        public char SpliteFlag = ':';

        protected override void OnAwake()
        {
            base.OnAwake();
            if (Widget == null)
            {
                Widget = ValueLable;
            }
        }

        protected override void OnFreshView()
        {
            var data = GetData<YxKeyValueData>();
            if (data == null) { return;}
            SetKeyLabel(data.Key);
            SetValueLabel(data.Value);
            SetIcon(data.IconUrl);
        }

        /// <summary>
        /// ����key
        /// </summary>
        protected virtual void SetKeyLabel(string key)
        {
            if (KeyLable == null) return;
            string.Format("{0}{1}", key, SpliteFlag);
            KeyLable.Text(key);
        }

        /// <summary>
        /// ����value
        /// </summary>
        protected virtual void SetValueLabel(string value)
        {
            if (ValueLable == null) return;
            ValueLable.Text(value);
        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        protected virtual void SetIcon(string iconUrl)
        {
            YxAdapterUtile.SetTexture(Icon, iconUrl);
        }

        public int GetHeight()
        {
            if (Widget == null)
            {
                if (ValueLable == null) return 0;

                return ValueLable.Height;
            }
            return Widget.Height;
        }
    }

    public class YxKeyValueData
    {
        public string Key;
        public string Value;
        public string IconUrl;
    }
}
