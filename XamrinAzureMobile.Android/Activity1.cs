using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamarinAzureMobile.Core;


namespace XamrinAzureMobile.Android
{
    [Activity(Label = "XamrinAzureMobile.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        SampleAzureMobile _model;
        Mobile _mobile;
        EditText textUserName, textHighScore, textUpdated;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            FindViewById<Button>(Resource.Id.buttonUpdate).Click += clicUpdate;
            FindViewById<Button>(Resource.Id.buttonRead).Click += clicRead;
            textUserName = FindViewById<EditText>(Resource.Id.textUserName);
            textHighScore = FindViewById<EditText>(Resource.Id.textHighScore);
            textUpdated = FindViewById<EditText>(Resource.Id.textUpdated);

            _model = new SampleAzureMobile();
            _mobile = new Mobile();
        }

        /// <summary>
        /// データ更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void clicUpdate(object sender, EventArgs e)
        {
            _model.UserName = textUserName.Text;
            _model.HighScore = int.Parse(textHighScore.Text);
            _model.Updated = DateTime.Parse(textUpdated.Text);
            await _mobile.Update(_model);
            var dlg = new AlertDialog.Builder(this);
            dlg.SetMessage("更新しました");
            dlg.Show();
        }
        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void clicRead(object sender, EventArgs e)
        {
            _model.UserName = textUserName.Text;
            var m = await _mobile.Read(_model.UserName);
            _model.FromCopy(m);
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textUpdated.Text = _model.Updated.ToString();
        }
    }
}

