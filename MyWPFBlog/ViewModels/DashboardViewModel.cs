using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using MyWPFBlog.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Controls;
using LiveChartsCore.Drawing;

namespace MyWPFBlog.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {
        public DashboardViewModel()
        {
#if DEBUG
            UserName = "PadawanSolid";
            Bio = "Good at WPF";
            FollowerCount = 6;
            FollowingCount = 3;
            Achievements = [
                new()
                {
                    Name="Pull Shark",
                    Description="Opened pull requests that have been merged.",
                    Datetime=new DateTime(2024,2,17),
                    Image="/Asserts/Achievements/pull-shark.png",
                    Color="#FF2958C8"
                },
                new()
                {
                    Name="Yolo",
                    Description="You want it? You merge it.",
                    Datetime=new DateTime(2024,2,17),
                    Image="/Asserts/Achievements/yolo.png",
                    Color="#FFFCBC9D"
                },

                ];
            Organizations = [
                new ()
                {
                    Name="NimbleSense",
                    Description="Friends from all over the country trying to make C# great again!",
                    MemberCount=13,
                    RepoCount=4,
                    Image="/Asserts/Achievements/nimblesense.jpg",
                }
                ];
            PinnedBlogs = [
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
            Statistics = [
                new()
                {
                    Type="Blogs",
                    Symbol=SymbolRegular.Document24,
                    Count=111
                },
                 new()
                {
                    Type="Likes",
                    Symbol=SymbolRegular.ThumbLike24,
                    Count=9876
                },
                 new()
                {
                    Type="Favorites",
                    Symbol=SymbolRegular.Star24,
                    Count=1100
                },
                 new()
                {
                    Type="Comments",
                    Symbol=SymbolRegular.Comment24,
                    Count=8888
                },
                ];
#endif
        }
        [ObservableProperty]
        string userName;
        [ObservableProperty]
        string bio;
        [ObservableProperty]
        int? followerCount;

        [ObservableProperty]
        int? followingCount;

        [ObservableProperty]
        ObservableCollection<AchievementInfo> achievements;

        [ObservableProperty]
        ObservableCollection<OrganizationInfo> organizations;

        [ObservableProperty]
        ObservableCollection<BlogInfo> pinnedBlogs;

        [ObservableProperty]
        StatisticInfo[] statistics;
        [ObservableProperty]
        ISeries[] statisticsSeries =
        {
            new PolarLineSeries<int>
            {
                Values = [51,23,11,22,31],
                 Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90)),
                 GeometrySize=30,
                 DataLabelsSize=20,
                 DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30)),
                 DataLabelsPosition = PolarLabelsPosition.Middle,
            }
        };
        [ObservableProperty]
        PolarAxis[] statisticsRadialAxes =
        {
            new PolarAxis
            {
                CustomSeparators=[10,30,50],
                LabelsBackground=LvcColor.Empty,
                  LabelsPaint=new  SolidColorPaint(SKColors.White),
            }
        };
        [ObservableProperty]
        PolarAxis[] statisticsAngleAxes =
        {
            new PolarAxis
            {
                LabelsRotation = LiveCharts.TangentAngle,
                LabelsBackground=LvcColor.Empty,
                LabelsPaint=new  SolidColorPaint(SKColors.White),
                Labels=[
                    "WPF",
                    "Webapi",
                    "Unity",
                    "Vue",
                    "React"
                    ],
            }
        };
        [ObservableProperty]
        ISeries[] activitySeries =
       [
            new ScatterSeries<double>(){
                Values=Enumerable.Range(0,120).Select(n=>Random.Shared.NextDouble()*10).ToList(),
                
            },
            ];

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
