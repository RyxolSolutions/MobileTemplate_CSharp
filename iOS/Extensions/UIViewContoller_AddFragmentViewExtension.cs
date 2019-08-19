using System;

using UIKit;

using MvvmCross;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;

namespace MobileTemplateCSharp.iOS.Extensions {
    public static class UIViewContoller_AddFragmentViewExtension {

        /// <summary>
        /// Not type safe version of AddFragmentViewModel&lt;TFragmentViewModel&gt;.
        /// Use AddFragmentViewModel&lt;TFragmentViewModel&gt;.
        /// </summary>
        /// <param name="TFragmentViewModel">IMvxViewModel which is wanted to be added.</param>
        /// <param name="containerViewHolder">Container: a placeholder to fragment.</param>
        public static void AddFragmentViewModel(this MvxViewController thisController, Type TFragmentViewModel, UIView containerViewHolder) {
            var viewModel = Mvx.IoCProvider.GetType().GetMethod("IoCConstruct", new Type[] { }).MakeGenericMethod(TFragmentViewModel).Invoke(Mvx.IoCProvider, null) as IMvxViewModel;
            UIViewController controller = thisController.CreateViewControllerFor(viewModel) as UIViewController;

            thisController.AddFragmentView(controller, containerViewHolder);
        }

        /// <summary>
        /// Type safe adding View of MvvMCross to Container.
        /// </summary>
        /// <typeparam name="TFragmentViewModel">IMvxViewModel which is wanted to be added.</typeparam>
        /// <param name="containerViewHolder">Container: a placeholder to fragment.</param>
        public static void AddFragmentViewModel<TFragmentViewModel>(this MvxViewController thisController, UIView containerViewHolder) where TFragmentViewModel : class, IMvxViewModel {
            thisController.AddFragmentViewModel(typeof(TFragmentViewModel), containerViewHolder);
        }


        /// <summary>
        /// Adding FragmentController to the container in UIViewController
        /// </summary>
        /// <param name="fragmentController">Fragment to add.</param>
        /// <param name="containerViewHolder">Container: a placeholder to fragment.</param>
        public static void AddFragmentView(this UIViewController thisController, UIViewController fragmentController, UIView containerViewHolder) {
            thisController.AddChildViewController(fragmentController);
            fragmentController.View.TranslatesAutoresizingMaskIntoConstraints = false;
            containerViewHolder.AddSubview(fragmentController.View);

            NSLayoutConstraint.ActivateConstraints(new[] {
                fragmentController.View.LeadingAnchor.ConstraintEqualTo(containerViewHolder.LeadingAnchor, 0),
                fragmentController.View.TrailingAnchor.ConstraintEqualTo(containerViewHolder.TrailingAnchor, 0),
                fragmentController.View.TopAnchor.ConstraintEqualTo(containerViewHolder.TopAnchor, 0),
                fragmentController.View.HeightAnchor.ConstraintEqualTo(containerViewHolder.HeightAnchor)
            });

            fragmentController.DidMoveToParentViewController(thisController);
        }
    }
}
