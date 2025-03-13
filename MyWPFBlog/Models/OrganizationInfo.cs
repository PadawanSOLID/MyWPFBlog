using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFBlog.Models
{
    public partial class OrganizationInfo:ObservableRecipient
    {
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        string name;
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        string description;
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        int repoCount;
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        string image;
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        int memberCount;
    }
}
