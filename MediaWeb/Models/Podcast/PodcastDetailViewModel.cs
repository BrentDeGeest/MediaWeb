using MediaWeb.Domain.Podcasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Podcast
{
    public class PodcastDetailViewModel
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorPodcast> Authors { get; set; }
    }
}
