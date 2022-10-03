using pmstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Streaming
                if (!context.Streamings.Any())
                {
                    context.Streamings.AddRange(new List<Streaming>()
                    {
                        new Streaming()
                        {
                            Name = "Streaming Service 1",
                            Logo = "img/yu2.jpg",
                            Description = "Youtube"
                        },
                        new Streaming()
                        {
                            Name = "Streaming Service 2",
                            Logo = "img/sp.png",
                            Description = "Spotify"
                        },
                        new Streaming()
                        {
                            Name = "Streaming Service 3",
                            Logo = "img/sc2.jpg",
                            Description = "Soundcloud"
                        },
                        new Streaming()
                        {
                            Name = "Streaming Service 4",
                            Logo = "img/am.png",
                            Description = "Amazon Music"
                        },
                        new Streaming()
                        {
                            Name = "Streaming Service 5",
                            Logo = "img/De.png",
                            Description = "Deezer"
                        },
                    });
                    context.SaveChanges();
                }
                //Artists
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName = "Yoseph Tiruwork",
                            Bio = "Producer & Singer-songwriter",
                            ProfilePictureURL = "https://drive.google.com/drive/u/0/folders/15LDcuMoDMSAW7lwZTPvdRzkGOEr39owF"

                        },
                        new Artist()
                        {
                            FullName = "New Artist 2",
                            Bio = "Bio 2",
                            ProfilePictureURL = "https://drive.google.com/drive/u/0/folders/15LDcuMoDMSAW7lwZTPvdRzkGOEr39owF"
                        },
                        new Artist()
                        {
                            FullName = "New Artist 3",
                            Bio = "Bio 3",
                            ProfilePictureURL = "https://drive.google.com/drive/u/0/folders/15LDcuMoDMSAW7lwZTPvdRzkGOEr39owF"
                        },
                        new Artist()
                        {
                            FullName = "New Artist 4",
                            Bio = "Bio 4",
                            ProfilePictureURL = "https://drive.google.com/drive/u/0/folders/15LDcuMoDMSAW7lwZTPvdRzkGOEr39owF"
                        },
                        new Artist()
                        {
                            FullName = "New Artist",
                            Bio = "Bio 5",
                            ProfilePictureURL = "https://drive.google.com/drive/u/0/folders/15LDcuMoDMSAW7lwZTPvdRzkGOEr39owF"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Yoseph Tiruwork",
                            Bio = "Producer & Singer-songwriter",
                            ProfilePictureURL = "img/YT_MCR.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "Bio 2",
                            ProfilePictureURL = "img/YT_MCR.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "Bio 3",
                            ProfilePictureURL = "img/YT_MCR.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "Bio 4",
                            ProfilePictureURL = "img/YT_MCR.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "Bio 5",
                            ProfilePictureURL = "img/YT_MCR.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Albums
                if (!context.Albums.Any())
                {
                    context.Albums.AddRange(new List<Album>()
                    {
                        new Album()
                        {
                            Name = "Lemagnet Matate",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now,
                            StreamingId = 1,
                            ProducerId = 3,
                            Genre = Genre.Alternative
                        },
                        new Album()
                        {
                            Name = "Keleku Ayalfem",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now,
                            StreamingId = 1,
                            ProducerId = 1,
                            Genre = Genre.Bati
                        },
                        new Album()
                        {
                            Name = "Trust Him",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now,
                            StreamingId = 1,
                            ProducerId = 4,
                            Genre = Genre.Jazz
                        },
                        new Album()
                        {
                            Name = "Change is Coming",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            StreamingId = 1,
                            ProducerId = 2,
                            Genre = Genre.Indie
                        },
                        new Album()
                        {
                            Name = "Melkam",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            StreamingId = 1,
                            ProducerId = 3,
                            Genre = Genre.World
                        },
                        new Album()
                        {
                            Name = "Tebek",
                            Description = "Tebek",
                            Price = 9.99,
                            ImageURL = "img/YT_LM.jpg",
                            ReleaseDate = DateTime.Now.AddDays(3),
                            StreamingId = 1,
                            ProducerId = 5,
                            Genre = Genre.Tizita
                        }
                    });
                    context.SaveChanges();
                }
                //Artist & Albums
                if (!context.Artists_Albums.Any())
                {
                    context.Artists_Albums.AddRange(new List<Artist_Album>()
                    {
                        new Artist_Album()
                        {
                            ArtistId = 1,
                            AlbumId = 1
                        },
                        new Artist_Album()
                        {
                            ArtistId = 3,
                            AlbumId = 1
                        },

                         new Artist_Album()
                        {
                            ArtistId = 1,
                            AlbumId = 2
                        },
                         new Artist_Album()
                        {
                            ArtistId = 4,
                            AlbumId = 2
                        },

                        new Artist_Album()
                        {
                            ArtistId = 1,
                            AlbumId = 3
                        },
                        new Artist_Album()
                        {
                            ArtistId = 2,
                            AlbumId = 3
                        },
                        new Artist_Album()
                        {
                            ArtistId = 5,
                            AlbumId = 3
                        },


                        new Artist_Album()
                        {
                            ArtistId = 2,
                            AlbumId = 4
                        },
                        new Artist_Album()
                        {
                            ArtistId = 3,
                            AlbumId = 4
                        },
                        new Artist_Album()
                        {
                            ArtistId = 4,
                            AlbumId = 4
                        },


                        new Artist_Album()
                        {
                            ArtistId = 2,
                            AlbumId = 5
                        },
                        new Artist_Album()
                        {
                            ArtistId = 3,
                            AlbumId = 5
                        },
                        new Artist_Album()
                        {
                            ArtistId = 4,
                            AlbumId = 5
                        },
                        new Artist_Album()
                        {
                            ArtistId = 5,
                            AlbumId = 5
                        },


                        new Artist_Album()
                        {
                            ArtistId = 3,
                            AlbumId = 6
                        },
                        new Artist_Album()
                        {
                            ArtistId = 4,
                            AlbumId = 6
                        },
                        new Artist_Album()
                        {
                            ArtistId = 5,
                            AlbumId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }
    }
}
