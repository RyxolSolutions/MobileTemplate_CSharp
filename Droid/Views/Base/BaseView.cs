using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using MvvmCross.Commands;
using MvvmCross.Droid.Support.V7.AppCompat;

using MobileTemplateCSharp.Core.ViewModels.Base;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using PopupMessage = System.ValueTuple<string, string, string, string, System.Action, System.Action>;
using Android.Util;
using Android.Runtime;
using Android.Views.Animations;
using Android.Support.V4.Content;
using MobileTemplateCSharp.Droid.Extensions;
using System.Reflection;
using System.Linq;
using MobileTemplateCSharp.Droid.Attributes;

namespace MobileTemplateCSharp.Droid.Views.Base {
    public abstract class BaseView<TViewModel> : MvxAppCompatActivity<TViewModel> where TViewModel : class, IBaseViewModel {

        #region View
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
        }

        protected override void OnStart() {
            RootLayout = (ViewGroup)Window.DecorView.RootView;

            InitToolbar();
            InitLoadingBar();
            InitPopup();

            base.OnStart();
        }

        /// <summary>
        /// Method initialize toolbar. 
        /// It works on Resource.Id.toolbar that is placed in container
        /// </summary>
        private void InitToolbar() {

            var attrs = from attr in this.GetType().GetCustomAttributes() where attr is ToolbarAttribute select attr;
            if (attrs != null && attrs.Any()) {
                ToolbarAttribute toolbarAttribute = (ToolbarAttribute)attrs.First();
                Toolbar = FindViewById<Toolbar>(toolbarAttribute.ToolbarResource);
                if (Toolbar == null) {
                    Toolbar = new Toolbar(this) {
                        
                    };
                    Toolbar.SetBackgroundColor(Resources.GetColor(Resource.Color.primary));
                    Toolbar.SetTitleTextColor(ContextCompat.GetColor(this, Resource.Color.window_background));
                    RootLayout.AddView(Toolbar, new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
                }

                SetSupportActionBar(Toolbar);
                SupportActionBar.Title = ViewModel.Title;
                if (toolbarAttribute.NeedBackButton) {
                    SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                    SupportActionBar.SetDisplayShowHomeEnabled(true);
                    Toolbar.NavigationClick += (sender, e) => OnBackPressed();
                }
            }
        }

        #endregion


        #region Popup

        private void InitPopup() {
            ViewModel.ShowPopupCommand = new MvxCommand<PopupMessage>(this.ShowPopup);
        }

        #endregion

        #region Loading Bar

        public readonly int AnimationLoadingBarApperaringDuration = 300;
        public readonly float AlphaVisible = 0.9f;
        public readonly float AlphaHidden = 0.0f;

        private void InitLoadingBar() {
            ViewModel.ShowLoadingBarCommand = new MvxCommand(this.ShowLoadingBar);
            ViewModel.HideLoadingBarCommand = new MvxCommand(this.HideLoadingBar);
        }

        public ProgressBar ProgressBar { get; set; }
        public RelativeLayout LoadingBarLayout { get; set; }
        public virtual ViewGroup RootLayout { get; set; }

        #endregion

        #region Properties

        protected Toolbar Toolbar { get; set; }
        //protected abstract bool NeedBackButton { get; }

        #endregion
    }
}
