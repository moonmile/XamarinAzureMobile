using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XamarinAzureMobile.Core
{
    /// <summary>
    /// シリアライズ可能なデータモデル
    /// </summary>
    public class SampleAzureMobile : BindableBase
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { this.SetProperty(ref this._ID, value); }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { this.SetProperty(ref this._UserName, value); }
        }
        // 最高点
        private int _HighScore;
        public int HighScore
        {
            get { return _HighScore; }
            set { this.SetProperty(ref this._HighScore, value); }
        }
        // 更新日
        private DateTime _Updated;
        public DateTime Updated
        {
            get { return _Updated; }
            set { this.SetProperty(ref this._Updated, value); }
        }

        public SampleAzureMobile()
        {
            // デザイン用の初期値
            ID = "";
            UserName = "Your name";
            HighScore = 10;
            Updated = new DateTime(2014, 4, 10);
        }
        /// <summary>
        /// コピー
        /// </summary>
        /// <param name="src"></param>
        public void FromCopy( SampleAzureMobile src )
        {
            this.UserName = src.UserName;
            this.HighScore = src.HighScore;
            this.Updated = src.Updated;
        }
    }
}
