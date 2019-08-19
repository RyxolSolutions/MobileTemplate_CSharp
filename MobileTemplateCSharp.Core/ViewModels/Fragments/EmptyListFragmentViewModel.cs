using System;
using System.Collections.Generic;
using System.Linq;
using MobileTemplateCSharp.Core.Models.Cells;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MobileTemplateCSharp.Core.ViewModels.Fragments {
    public class EmptyListFragmentViewModel : ListViewModel {
        public EmptyListFragmentViewModel(
            IMvxNavigationService mvxNavigationService
        ) : base(mvxNavigationService) {
        }

        public override string Title => "Empty List";
    }
}
