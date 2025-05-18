using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using com.yxixia.utile.Utiles;
using UnityEngine;
using YxFramwork.Common.Adapters;
using YxFramwork.Common.PropertyAttributes;

namespace Assets.Scripts.Common.Utils
{
    public class ZyKeyboard : MonoBehaviour
    {
        /// <summary>
        /// ������ʽ
        /// </summary>
        [FlagEnum(typeof(ZYEInputImeOptions))]
        public ZYEInputImeOptions ImeOptions;
        public YxBaseInputLabelAdapter InputAdapter;

        void Awake()
        {
            if (InputAdapter == null)
            {
                InputAdapter = GetComponent<YxBaseInputLabelAdapter>();
            }
        }

        public void ShowKeyboard(Dictionary<string,object> data)
        {
            var secure = false;
            var defaultText = string.Empty;
            data.Parse("secure", ref secure);
            data.Parse("defaultText", ref defaultText);
            var keyboard = new AndroidJavaObject("com.youxia.hall.KeyboardUtile");
            keyboard.Set("Owner", name);
            keyboard.Set("ImeOptions", (int)ImeOptions);
            if (InputAdapter != null)
            {
                keyboard.Set("DefaultText", InputAdapter.Value);
            }
            keyboard.Call("Open", "",false);
        }
         
        public void OnCustomInputAction(string data)
        {
            Debug.LogError("OnCustomInputAction~~~" + data);
            //data��������̴�����������
            if (InputAdapter != null)
            {
                InputAdapter.SetValue(data);
                
                InputAdapter.Submit();
            }
        }

        public virtual void OnTextChanged(string data)
        {
        }
        public virtual void OnBeforeTextChanged(string data)
        {
        }
        public virtual void OnAfterTextChanged(string data)
        {
        }
        public virtual void OnGlobalLayout(string data)
        {
            InputAdapter.SetValue(data);
            InputAdapter.RemoveFocus();
        }


        /// <summary>
        /// ������ʽ
        /// </summary>
        [Flags]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        // ReSharper disable once InconsistentNaming
        public enum ZYEInputImeOptions
        {
            IME_NULL = 0x00000000,
            /// <summary>
            /// �༭������Action��ť����Ϊ
            /// </summary>
            IME_ACTION_UNSPECIFIED = 0x00000000,
            /// <summary>
            ///
            /// </summary>
            IME_MASK_ACTION = 0x000000ff,
            /// <summary>
            /// ������Ҳ಻���κ���ʾ 
            /// </summary>
            IME_ACTION_NONE = 0x00000001,
            /// <summary>
            /// ���½ǰ���Ϊȥ��
            /// </summary>
            IME_ACTION_GO = 0x00000002,
            /// <summary>
            /// ���½ǰ���Ϊ�Ŵ�ͼƬ������
            /// </summary>
            IME_ACTION_SEARCH = 0x00000003,
            /// <summary>
            /// ���½ǰ�������Ϊ'����' 
            /// </summary>
            IME_ACTION_SEND = 0x00000004,
            /// <summary>
            /// ���½ǰ�������Ϊ'��һ��' ������һ��
            /// </summary>
            IME_ACTION_NEXT = 0x00000005,
            /// <summary>
            /// ���½ǰ�������Ϊ'���'
            /// </summary>
            IME_ACTION_DONE = 0x00000006,
            /// <summary>
            /// 
            /// </summary>
            IME_ACTION_PREVIOUS = 0x00000007,
            /// <summary>
            /// 
            /// </summary>
            IME_FLAG_NO_FULLSCREEN = 0x2000000,
            /// <summary>
            /// 
            /// </summary>
            IME_FLAG_NAVIGATE_PREVIOUS = 0x4000000,
            /// <summary>
            /// 
            /// </summary>
            IME_FLAG_NAVIGATE_NEXT = 0x8000000,
            /// <summary>
            /// ʹ����̲�ȫ����ʾ��ֻռ��һ������Ļ ͬʱ,������Ի��ܿؼ���������½ǰ�������ʾ����, Ĭ�������Ϊ�س���
            /// </summary>
            IME_FLAG_NO_EXTRACT_UI = 0x10000000,
            /// <summary>
            /// 
            /// </summary>
            IME_FLAG_NO_ACCESSORY_ACTION = 0x20000000,
            /// <summary>
            /// 
            /// </summary>
            IME_FLAG_NO_ENTER_ACTION = 0x40000000,
            //IME_FLAG_FORCE_ASCII = 0x80000000
        }
    }
}
