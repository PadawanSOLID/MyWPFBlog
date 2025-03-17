using CommunityToolkit.Mvvm.Messaging.Messages;
using MyModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFBlog.Messages
{
    public class WriterDTOMessage : ValueChangedMessage<string>
    {
        public WriterDTOMessage(string value) : base(value)
        {
        }
    }
}
