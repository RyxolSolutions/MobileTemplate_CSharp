﻿using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;

using MvvmCross.Commands;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core.ViewModels.Base;
using PopupMessage = System.ValueTuple<string, string, string, string, System.Action, System.Action>;
using MobileTemplateCSharp.Droid.Extensions;

namespace MobileTemplateCSharp.Droid.Views.Fragments.Base {
    /// <summary>
    /// Base Fragment with ViewModel implementation. Creates generic ViewModel in constructor.
    /// </summary>
    /// <typeparam name="TViewModel">Type of ViewModel for Fragment</typeparam>
    public abstract class BaseFragmentView<TViewModel> : MvxFragment<TViewModel> where TViewModel : class, IBaseViewModel {

        public BaseFragmentView(IntPtr a, JniHandleOwnership b) : base(a, b) {
            Instantiate();
        }

        public BaseFragmentView() {
            Instantiate();
        }

        public void Instantiate() {
            MvxViewModelRequest request = (MvxViewModelRequest)Activator.CreateInstance(typeof(MvxViewModelRequest<>).MakeGenericType(typeof(TViewModel)));
            this.LoadViewModelFrom(request);

            ViewModel.ShowPopupCommand = new MvxCommand<PopupMessage>(this.ShowPopup);
        }

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}