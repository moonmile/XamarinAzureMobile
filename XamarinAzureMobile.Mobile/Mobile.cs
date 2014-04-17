using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinAzureMobile.Core;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;


namespace XamarinAzureMobile.Core
{
    public class Mobile
    {
        MobileServiceClient MobileService;
        public Mobile ()
        {
            MobileService = new MobileServiceClient(
                "https://xamarinazuremobile.azure-mobile.net/",
                "mIVABPFTMECWfYeiYlglJtRCXWKpBf44");
        }
        
        /// <summary>
        /// データ更新
        /// </summary>
        /// <param name="data"></param>
        public async Task Update( SampleAzureMobile model )
        {
            model.ID = null;
            model.Updated = DateTime.Now;
            var t = MobileService.GetTable<SampleAzureMobile>();
            await t.InsertAsync(model);
        }
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<SampleAzureMobile> Read(string username)
        {
            var q = from t in MobileService.GetTable<SampleAzureMobile>()
                    where t.UserName == username
                    orderby t.HighScore descending
                    select t;
            var lst = await q.ToListAsync();
            return lst.FirstOrDefault<SampleAzureMobile>();
        }
    }
}
