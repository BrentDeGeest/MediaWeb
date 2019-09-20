using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Domain.Podcasts
{
    public class AuthorPodcast
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
    }
}
