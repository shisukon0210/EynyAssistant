using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Eynyassistant.Model
{
    public class Post:INotifyPropertyChanged
    {
        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if(ImageUrl != value)
                {
                    imageUrl = value;
                    OnPropertyChange(nameof(imageUrl));
                }
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if(Title != value)
                {
                    title = value;
                    OnPropertyChange(nameof(title));
                }
            }
        }
        
        private string url;

        public string Url
        {
            get { return url; }
            set
            {
                if(url != value)
                {
                    url = value;
                    OnPropertyChange(nameof(url));
                }
            }
        }

        private DateTime postTime;

        public DateTime PostTime
        {
            get { return postTime; }
            set
            {
                if(postTime != value)
                {
                    postTime = value;
                    OnPropertyChange(nameof(postTime));
                }
            }
        }

        private DateTime replyTime;

        public DateTime ReplyTime
        {
            get { return replyTime; }
            set
            {
                if(replyTime != value)
                {
                    replyTime = value;
                    OnPropertyChange(nameof(replyTime));
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
