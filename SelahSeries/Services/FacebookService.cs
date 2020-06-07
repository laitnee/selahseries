using Newtonsoft.Json;
using SelahSeries.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SelahSeries.Services
{
    public class FacebookService
    {
        private string _accessToken;

        /// <summary>
        /// Uses default Client ID and Secret as set in the web.config.
        /// </summary>
        //public FacebookService()
        //{
        //    GetAccessToken(Config.Facebook.ClientId, Config.Facebook.ClientSecret);
        //}

        /// <summary>
        /// Requires  Client ID and Secret.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public FacebookService(string clientId, string clientSecret)
        {
            GetAccessToken(clientId, clientSecret);
        }

        /// <summary>
        /// Gets page info that has been shared to Facebook.
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public FacebookPageInfo GetPage(string pageUrl)
        {
            return ApiWebRequestHelper.GetJsonRequest<FacebookPageInfo>($"https://graph.facebook.com/{pageUrl}?access_token={_accessToken}");
        }

        /// <summary>
        /// Gets comments for a page based on its absolute URL.
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="maxComments"></param>
        public FacebookPageCommentInfo GetPageComments(string pageUrl, int maxComments)
        {
            try
            {
                // Get page information in order to retrieve page ID to pass to commenting.
                FacebookPageInfo facebookPage = GetPage(pageUrl);

                if (facebookPage.Page != null)
                {
                    return new FacebookPageCommentInfo
                    {
                        TotalComments = facebookPage.Share.CommentCount,
                        Comments = GetCommentsByPageId(facebookPage.Page.Id, maxComments).Comments
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // NOTE: Log exception here...

                return null;
            }
        }

        /// <summary>
        /// Gets comments by Facebook's Page ID.
        /// </summary>
        /// <param name="fbPageId"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public FacebookPageCommentInfo GetCommentsByPageId(string fbPageId, int max = 10)
        {
            return ApiWebRequestHelper.GetJsonRequest<FacebookPageCommentInfo>($"https://graph.facebook.com/comments?id={fbPageId}&access_token={_accessToken}&limit={max}");
        }

        /// <summary>
        /// Retrieves Access Token from Facebook App.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        private void GetAccessToken(string clientId, string clientSecret)
        {
             UriBuilder builder = new UriBuilder($"https://graph.facebook.com/oauth/access_token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials");

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Get Access Token from incoming response.
                    string data = client.DownloadString(builder.Uri);

                    var parsedQueryString = JsonConvert.DeserializeObject<Dictionary<string,string>>(data);

                    _accessToken = parsedQueryString["access_token"].Split("|")[1];
                }
            }
            catch (Exception ex)
            {
                // NOTE: Log exception here...
            }
        }
    }

}
