namespace Sales.Droid
{
    using Android.App;
    using Android.OS;

    [Activity(
        Theme ="@style/Theme.Splash",//indica el tema que usa la actividad
        MainLauncher =true, //set it as boot activity
        NoHistory =true)] //doesn't place it in back stack
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);
            this.StartActivity(typeof(MainActivity));

            // Create your application here
        }
    }
}