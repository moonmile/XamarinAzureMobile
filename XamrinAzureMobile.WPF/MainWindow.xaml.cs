using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XamarinAzureMobile.Core;

/*
 * ALTER TABLE [XamarinAzureMobile].[SampleAzureMobile] ADD UserName nvarchar(max)
 * ALTER TABLE [XamarinAzureMobile].[SampleAzureMobile] ADD HighScore float
 * ALTER TABLE [XamarinAzureMobile].[SampleAzureMobile] ADD Updated datetimeoffset
 */

namespace XamrinAzureMobile.WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        SampleAzureMobile _model;
        Mobile _mobile;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// データ更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickUpdate(object sender, RoutedEventArgs e)
        {
            await _mobile.Update(_model);
            MessageBox.Show("更新しました");
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void clickRead(object sender, RoutedEventArgs e)
        {
            var m = await _mobile.Read(_model.UserName);
            _model.FromCopy(m);
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _model = new SampleAzureMobile();
            this.DataContext = _model;
            _mobile = new Mobile();

        }
    }
    /// <summary>
    /// Azure Mobile に設定するテーブル名を変更する場合
    /// </summary>
    [DataTable("SampleAzureMobile")]
    public class MyData
    {
        public string UserName { get; set; }
        public int HighScore { get; set; }
        public DateTime Updated { get; set; }
    }
}
