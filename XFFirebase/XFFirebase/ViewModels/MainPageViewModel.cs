using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XFFirebase.Interface;

namespace XFFirebase.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public IFireBaseAnalyticsService _fbs;//宣告一個 IFireBaseAnalyticsService 的變數，這是我們建立在 PCL 專案中的介面

        private DelegateCommand _clickEventLogbtnCommand;
        public DelegateCommand clickEventLogbtnCommand =>
            clickEventLogbtnCommand ?? (_clickEventLogbtnCommand = new DelegateCommand(clickEventLogbtn));

        private void clickEventLogbtn()
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

        public MainPageViewModel(IFireBaseAnalyticsService fbs)
        {
            //使用建構式將物件注入
            _fbs = fbs;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
