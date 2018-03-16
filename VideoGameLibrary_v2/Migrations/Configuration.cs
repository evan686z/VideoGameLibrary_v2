namespace VideoGameLibrary_v2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoGameLibrary_v2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VideoGameLibrary_v2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.VideoGames.AddOrUpdate(v => v.Name,
                new Models.VideoGame()
                {
                    Name = "Metal Gear Solid V: The Phantom Pain",
                    ReleaseDate = "September 1, 2015",
                    ReleaseYear = "2015",
                    Developer = "Kojima Productions",
                    Publisher = "Konami",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "The Legend of Zelda: Breath of the Wild",
                    ReleaseDate = "March 3, 2017",
                    ReleaseYear = "2017",
                    Developer = "Nintendo",
                    Publisher = "Nintendo",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Super Mario Odyssey",
                    ReleaseDate = "October 27, 2017",
                    ReleaseYear = "2017",
                    Developer = "Nintendo",
                    Publisher = "Nintendo",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Horizon Zero Dawn",
                    ReleaseDate = "February 28, 2017",
                    ReleaseYear = "2017",
                    Developer = "Guerrilla Games",
                    Publisher = "Sony Interactive Entertainment",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Monster Hunter: World",
                    ReleaseDate = "January 26, 2018",
                    ReleaseYear = "2018",
                    Developer = "Capcom",
                    Publisher = "Capcom",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Nier: Automata",
                    ReleaseDate = "February 23, 2017",
                    ReleaseYear = "2017",
                    Developer = "PlatinumGames",
                    Publisher = "Square Enix",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Overwatch",
                    ReleaseDate = "May 24, 2016",
                    ReleaseYear = "2016",
                    Developer = "Blizzard Entertainment",
                    Publisher = "Blizzard Entertainment",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Nioh",
                    ReleaseDate = "February 7, 2017",
                    ReleaseYear = "2017",
                    Developer = "Team Ninja",
                    Publisher = "Koei Tecmo",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "The Witcher 3: Wild Hunt",
                    ReleaseDate = "May 19, 2015",
                    ReleaseYear = "2015",
                    Developer = "CD Projekt RED",
                    Publisher = "CD Projekt",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Portal",
                    ReleaseDate = "October 9, 2007",
                    ReleaseYear = "2007",
                    Developer = "Valve Corporation",
                    Publisher = "Valve Corporation",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Human: Fall Flat",
                    ReleaseDate = "July 22, 2016",
                    ReleaseYear = "2016",
                    Developer = "No Brakes Games",
                    Publisher = "Curve Digital",
                    YouTubeEmbedLink = ""
                },
                new Models.VideoGame()
                {
                    Name = "Resident Evil 7: Biohazard",
                    ReleaseDate = "January 24, 2017",
                    ReleaseYear = "2017",
                    Developer = "Capcom",
                    Publisher = "Capcom",
                    YouTubeEmbedLink = "https://www.youtube.com/embed/W1OUs3HwIuo"
                },
                new Models.VideoGame()
                {
                    Name = "Cuphead",
                    ReleaseDate = "September 29, 2017",
                    ReleaseYear = "2017",
                    Developer = "StudioMDHR",
                    Publisher = "StudioMDHR",
                    YouTubeEmbedLink = "https://www.youtube.com/embed/D-1n15aIgsE"
                },
                new Models.VideoGame()
                {
                    Name = "Dark Souls III",
                    ReleaseDate = "March 24, 2016",
                    ReleaseYear = "2016",
                    Developer = "FromSoftware",
                    Publisher = "Bandai Namco Entertainment",
                    YouTubeEmbedLink = "https://www.youtube.com/embed/grJ_6d-y9cU"
                },
                new Models.VideoGame()
                {
                    Name = "Gunpoint",
                    ReleaseDate = "June 3, 2013",
                    ReleaseYear = "2013",
                    Developer = "Tom Francis",
                    Publisher = "Suspicious Developments",
                    YouTubeEmbedLink = "https://www.youtube.com/embed/q9d5ht7mQUU"
                },
                new Models.VideoGame()
                {
                    Name = "Grand Theft Auto 5",
                    ReleaseDate = "September 17, 2013",
                    ReleaseYear = "2013",
                    Developer = "Rockstar North",
                    Publisher = "Rockstar Games",
                    YouTubeEmbedLink = "https://www.youtube.com/embed/QkkoHAzjnUs"
                }
                );
        }
    }
}
