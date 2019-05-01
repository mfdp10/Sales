[assembly: Xamarin.Forms.ExportRenderer(
    typeof(Sales.Views.LoginTwitterPage),
    typeof(Sales.Droid.Implementations.LoginTwitterPageRenderer))]
namespace Sales.Droid.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Android.App;
    using Common.Models;
    using Newtonsoft.Json;
    using Sales.Services;
    using Xamarin.Auth;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    public class LoginTwitterPageRenderer : PageRenderer
    {
        //public LoginTwitterPageRenderer()
        //    : base(null)
        //{
        //    // Default constructor needed for Xamarin Forms bug?
        //    throw new Exception("This constructor should not actually ever be used");
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;

            var twitterConsumerKey = Xamarin.Forms.Application.Current.Resources["TwitterConsumerKey"].ToString();
            var twitterConsumerSecret = Xamarin.Forms.Application.Current.Resources["TwitterConsumerSecret"].ToString();
            var twitterRequestTokenURL = Xamarin.Forms.Application.Current.Resources["TwitterRequestTokenURL"].ToString();
            var twitterAuthorizeURL = Xamarin.Forms.Application.Current.Resources["TwitterAuthorizeURL"].ToString();
            var twitterAccessTokenURL = Xamarin.Forms.Application.Current.Resources["TwitterAccessTokenURL"].ToString();
            var twitterCallBakURL = Xamarin.Forms.Application.Current.Resources["TwitterCallBackURL"].ToString();

            var auth = new OAuth1Authenticator(
                consumerKey: twitterConsumerKey,
                consumerSecret: twitterConsumerSecret,
                requestTokenUrl: new Uri(twitterRequestTokenURL),
                authorizeUrl: new Uri(twitterAuthorizeURL),
                accessTokenUrl: new Uri(twitterAccessTokenURL),
                callbackUrl: new Uri(twitterCallBakURL));

            auth.AllowCancel = true;

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    TwitterResponse profile = await GetTwitterProfileAsync(eventArgs.Account);
                    var token = await GetTwiProfileAsync(eventArgs.Account);
                    await App.NavigateToProfile(profile, token);
                }
                else
                {
                    App.HideLoginView();
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }

        private async Task<TwitterResponse> GetTwitterProfileAsync(Account account)
        {
            var TwitterProfileInfoURL = Xamarin.Forms.Application.Current.Resources["TwitterProfileInfoURL"].ToString();
            var requestUrl = new OAuth1Request("GET", new Uri(TwitterProfileInfoURL), null, account);
            var response = await requestUrl.GetResponseAsync();
            //var json = response.GetResponseText();
            var twitterResponse = JsonConvert.DeserializeObject<TwitterResponse>(response.GetResponseText());

            var url = Xamarin.Forms.Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Xamarin.Forms.Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Xamarin.Forms.Application.Current.Resources["UrlUsersController"].ToString();
            var apiService = new ApiService();

            var token = await apiService.LoginTwitter(
                url,
                prefix,
                $"{controller}/LoginTwitter",
                twitterResponse);

            //return token;

            return JsonConvert.DeserializeObject<TwitterResponse>(response.GetResponseText());
            
        }


        private async Task<TokenResponse> GetTwiProfileAsync(Account account)
        {
            var TwitterProfileInfoURL = Xamarin.Forms.Application.Current.Resources["TwitterProfileInfoURL"].ToString();
            var requestUrl = new OAuth1Request("GET", new Uri(TwitterProfileInfoURL), null, account);
            var response = await requestUrl.GetResponseAsync();
            //var json = response.GetResponseText();
            var twitterResponse = JsonConvert.DeserializeObject<TwitterResponse>(response.GetResponseText());

            var url = Xamarin.Forms.Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Xamarin.Forms.Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Xamarin.Forms.Application.Current.Resources["UrlUsersController"].ToString();
            var apiService = new ApiService();

            var token = await apiService.LoginTwitter(
                url,
                prefix,
                $"{controller}/LoginTwitter",
                twitterResponse);

            return token;

            //return JsonConvert.DeserializeObject<TwitterResponse>(response.GetResponseText());

        }

    }
}