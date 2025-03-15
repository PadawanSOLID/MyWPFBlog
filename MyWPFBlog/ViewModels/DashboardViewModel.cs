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
            Distributions = [
                new(){
                    Count=55,
                    Symbol= SymbolRegular.Laptop24,
                    Type="WPF"
                },
                new(){
                 Count=23,
                 Symbol= SymbolRegular.Server24,
                 Type="Webapi"
                },
                new(){
                    Count=11,
                    Symbol= SymbolRegular.Games24,
                    Type="Unity"
                },
                new(){
                    Count=22,
                    Symbol= SymbolRegular.Vault24,
                    Type="Vue"
                },
                new(){
                    Count=31,
                    Symbol= SymbolRegular.Box24,
                    Type="React"
                },
                ];
            StatisticsSeries = [
                new PolarLineSeries<int>
                {
                    Values = Distributions.Select(n=>n.Count).ToArray(),
                    Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90)),
                    GeometrySize = 30,
                    DataLabelsSize = 20,
                    DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30)),
                    DataLabelsPosition = PolarLabelsPosition.Middle,
                 }];
            StatisticsRadialAxes = [
                 new PolarAxis
                 {
                    CustomSeparators = [10, 30, 50],
                    LabelsBackground = LvcColor.Empty,
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                 }];
            StatisticsAngleAxes =[
                 new PolarAxis
                 {
                    LabelsRotation = LiveCharts.TangentAngle,
                    LabelsBackground = LvcColor.Empty,
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    Labels = Distributions.Select(n=>n.Type).ToList(),
                }];
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
        ObservableCollection<StatisticInfo> distributions;
        [ObservableProperty]
        ISeries[] statisticsSeries;
        [ObservableProperty]
        PolarAxis[] statisticsRadialAxes;
        [ObservableProperty]
        PolarAxis[] statisticsAngleAxes;
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
