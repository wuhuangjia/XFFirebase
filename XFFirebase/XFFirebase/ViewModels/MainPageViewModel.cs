using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFFirebase.Interface;

namespace XFFirebase.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public IFireBaseAnalyticsService _fbs;//宣告一個 IFireBaseAnalyticsService 的變數，這是我們在核心專案建立的介面

        private DelegateCommand _clickEventLogbtn;
        public DelegateCommand clickEventLogbtnCmd =>
            _clickEventLogbtn ?? (_clickEventLogbtn = new DelegateCommand(ExecuteclickEventLogbtnCmd));

        void ExecuteclickEventLogbtnCmd()
        {
            //在要記錄的事件內準備要紀錄的內容
            Dictionary<string, object> boundle = new Dictionary<string, object>()
            {
                //名稱可以自己決定
                {"參數1","可以自己再額外定義要記錄的值"},
                { "參數2","還可以不只定義一個"}
            };

            //呼叫 LogEvent 方法，將資料傳遞給原生平台的實作
            _fbs.LogEvent("按下測試 Firebase EveneLog 按鈕", boundle);

        }

        public MainPageViewModel(INavigationService navigationService, IFireBaseAnalyticsService fbs) 
            : base (navigationService)
        {
            Title = "Main Page";
            //使用建構式將物件注入
            _fbs = fbs;
        }
    }
}
