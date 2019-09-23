using MediaWeb.Domain.Podcasts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Models.Podcast
{
    public class PodcastEditViewModel
    {
        [Required]
        public string Title { get; set; }

        public int Length { get; set; }

        public ICollection<AuthorPodcast> Authors { get; set; }
    }
}
