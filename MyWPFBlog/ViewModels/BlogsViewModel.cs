using CommunityToolkit.Mvvm.ComponentModel;
using MyWPFBlog.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Abstractions.Controls;

namespace MyWPFBlog.ViewModels
{
    public partial class BlogsViewModel : ObservableObject, INavigationAware
    {
        
        public BlogsViewModel()
        {
#if DEBUG
            Blogs = [
             new(){
                    Title="WPF may be dead but never late",
                    Description="Has WPF ever been popular at any time? I think the answer is no.",
                    LikeCount=9999,
                    FavoriteCount=6666,
                    CommentCount=3333
                },
                  new(){
                    Title="Typescript and Go may be the right answer",
                    Description="Do not grasp your fxxking C# any longer, hug Go and Typescript from now on!",
                    LikeCount=5,
                    FavoriteCount=1,
                    CommentCount=1
                }
             ];
#endif
        }
        [ObservableProperty]
        ObservableCollection<BlogInfo> blogs;
        [ObservableProperty]
        BlogInfo selectedBlog;

        partial void OnSelectedBlogChanged(BlogInfo value)
        {
            if (value!=null)
            {
                Title = value.Title;
                Content = value.Description;
            }
        }

        [ObservableProperty]
        string title;
        [ObservableProperty]
        string content;
        public Task OnNavigatedFromAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnNavigatedToAsync()
        {
            return Task.CompletedTask;
        }
    }
}
