using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace MobileTemplateCSharp.Core.ViewModels.Base {
    public interface IBaseViewModel : IMvxViewModel {
        /// <summary>
        /// Command for showing LoadingBar. Implementation depends on platform.
        /// </summary>
        /// <value>The show loading bar command.</value>
        /// <see cref="HideLoadingBarCommand"/>
        IMvxCommand ShowLoadingBarCommand { get; set; }

        /// <summary>
        /// Command for hiding LoadingBar. Implementation depends on platform.
        /// </summary>
        /// <value>The hide loading bar command.</value>
        /// <seealso cref="ShowLoadingBarCommand"/>
        IMvxCommand HideLoadingBarCommand { get; set; }


        /// <summary>
        /// Command for showing popups. Implementation depends on platform.
        /// </summary>
        /// <value>The show popup command.</value>
        /// <remarks>if some of button is not needed, make the text  of this buton null.</remarks>
        IMvxCommand<
        (string title,
            string message,
            string positiveButtonText,
            string negativeButtonText,
            Action positiveClick,
            Action negativeClick
        )> ShowPopupCommand { get; set; }

        /// <summary>
        /// Set the title of the page here by overriding the property.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; }
    }

    public abstract class BaseViewModel : MvxViewModel, IBaseViewModel {

        public IMvxCommand HideLoadingBarCommand { get; set; }
        public IMvxCommand ShowLoadingBarCommand { get; set; }
        public IMvxCommand<
        (string title,
            string message,
            string positiveButtonText,
            string negativeButtonText,
            Action positiveClick,
            Action negativeClick
        )> ShowPopupCommand { get; set; }

        public abstract string Title { get; }
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter> {
        /// <summary>
        /// Use method to work with parameter you got from previuos ViewModel
        /// </summary>
        /// <param name="parameter">parameter you got from previuos ViewModel</param>
        public abstract void Prepare(TParameter parameter);
    }

    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult> {
        /// <summary>
        /// Closing task. Return you parameter here.
        /// </summary>
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true) {
            if (viewFinishing && CloseCompletionSource != null && !CloseCompletionSource.Task.IsCompleted && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource?.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }

    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult> {
        /// <summary>
        /// Use method to work with parameter you got from previuos ViewModel
        /// </summary>
        /// <param name="parameter">parameter you got from previuos ViewModel</param>
        public abstract void Prepare(TParameter parameter);
    }
}
