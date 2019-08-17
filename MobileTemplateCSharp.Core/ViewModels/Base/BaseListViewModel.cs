using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MobileTemplateCSharp.Core.Localization;

namespace MobileTemplateCSharp.Core.ViewModels.Base {
    public interface IBaseListViewModel : IBaseViewModel {
        IMvxCommand ShowEmplyListCommand { get; set; }
        IMvxCommand HideEmplyListCommand { get; set; }
        IMvxCommand RefreshListCommand { get; set; }

        string EmptyListTitle { get; }
    }

    public abstract class BaseListViewModel : BaseViewModel, IBaseListViewModel {
        public IMvxCommand ShowEmplyListCommand { get; set; }
        public IMvxCommand HideEmplyListCommand { get; set; }
        public IMvxCommand RefreshListCommand { get; set; }

        public virtual string EmptyListTitle { get => AppResources.NoGridItems; }
    }

    public abstract class BaseListViewModel<TParameter> : BaseListViewModel, IMvxViewModel<TParameter> {
        /// <summary>
        /// Use method to work with parameter you got from previuos ViewModel
        /// </summary>
        /// <param name="parameter">parameter you got from previuos ViewModel</param>
        public abstract void Prepare(TParameter parameter);
    }

    public abstract class BaseListViewModelResult<TResult> : BaseListViewModel, IMvxViewModelResult<TResult> {
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

    public abstract class BaseListViewModel<TParameter, TResult> : BaseListViewModelResult<TResult>, IMvxViewModel<TParameter, TResult> {
        /// <summary>
        /// Use method to work with parameter you got from previuos ViewModel
        /// </summary>
        /// <param name="parameter">parameter you got from previuos ViewModel</param>
        public abstract void Prepare(TParameter parameter);
    }
}
