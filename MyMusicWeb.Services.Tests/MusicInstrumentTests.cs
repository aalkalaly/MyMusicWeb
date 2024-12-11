using MockQueryable;
using Moq;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Data;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusicWebDataModels;
using MyMusicWebViewModels;

namespace MyMusicWeb.Services.Tests
{
    [TestFixture]
    public class MusicInstrumentTests
    {
        private IList<MusicInstruments> musicInstrumentData = new List<MusicInstruments>()
        {
            new MusicInstruments()
            {
                Id = Guid.Parse("C994999B-02DD-46C2-ABC4-00C4787E629F"),
                Name = "Rock Legends Reunion",
                Description = "An epic night celebrating the legends of rock with classic hits and surprise performances.",
                IsDeleted = false,
                SellerId = "c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e",
                CategoryId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                Price = 300,
                ImageUrl = "https://images.unsplash.com/photo-1721133073235-e4b5facb27fa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bXVzaWMlMjBldmVudHxlbnwwfHwwfHx8MA%3D%3D"
            },
            new MusicInstruments()
            {
              Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
                Name = "Rock Night Thunder",
                Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
                IsDeleted = false,
                SellerId = "c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e",
                CategoryId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                ImageUrl ="https://images.squarespace-cdn.com/content/v1/5f724c2854366f48cbcfa30c/b20882e2-963c-4be9-a599-09e61ad7d014/5-Star+Live+Music+Event+Production+Company+%7C+Live+Music+Event+Producers?format=1500w"
            }
        };
        MusicInstrumentsAddViewModel viewModel = new MusicInstrumentsAddViewModel()
        {
            Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
            Name = "Rock Night Thunder",
            Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
            SellerId = "c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e",
            CategoryId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
            ImageUrl = "https://images.squarespace-cdn.com/content/v1/5f724c2854366f48cbcfa30c/b20882e2-963c-4be9-a599-09e61ad7d014/5-Star+Live+Music+Event+Production+Company+%7C+Live+Music+Event+Producers?format=1500w"
        
        };
        private Mock<IRepository<MusicInstruments, Guid>> musicInstrumentRepository;

        [SetUp]
        public void Setup()
        {
            this.musicInstrumentRepository = new Mock<IRepository<MusicInstruments, Guid>>();
        }

        [Test]
        public async Task MusicInstrumentIndexNullId()
        {
            IQueryable<MusicInstruments> eventsMockingQuriable = musicInstrumentData.BuildMock();
            this.musicInstrumentRepository
                .Setup(r => r.GetAllAtached())
                .Returns(eventsMockingQuriable);

            IMusicInstrumentsService musicInstrumentService = new MusicInstrumentsService(musicInstrumentRepository.Object);

            IEnumerable<MusicalInstrumentsIndexViewModel> allEventsActual = await musicInstrumentService
                .IndexGetAllNotDeletedAsync(null);

            Assert.IsNull(allEventsActual);
           


        }


    
    [Test]
    public async Task MusicInstrumentIndexEventDeleted()
    {
        IList<MusicInstruments> musicInstrumentData = new List<MusicInstruments>()
        {
            new MusicInstruments()
            {
                Id = Guid.Parse("C994999B-02DD-46C2-ABC4-00C4787E629F"),
                Name = "Rock Legends Reunion",
                Description = "An epic night celebrating the legends of rock with classic hits and surprise performances.",
                IsDeleted = false,
                SellerId = "c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e",
                CategoryId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                Price = 300,
                ImageUrl = "https://images.unsplash.com/photo-1721133073235-e4b5facb27fa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bXVzaWMlMjBldmVudHxlbnwwfHwwfHx8MA%3D%3D"
            },
            new MusicInstruments()
            {
              Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
                Name = "Rock Night Thunder",
                Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
                IsDeleted = true,
                SellerId = "c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e",
                CategoryId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                ImageUrl ="https://images.squarespace-cdn.com/content/v1/5f724c2854366f48cbcfa30c/b20882e2-963c-4be9-a599-09e61ad7d014/5-Star+Live+Music+Event+Production+Company+%7C+Live+Music+Event+Producers?format=1500w"
            }
        };
        int expectedEventCount = 1;
        string expectedEventId = "C994999B-02DD-46C2-ABC4-00C4787E629F";

        IQueryable<MusicInstruments> eventsMockingQuriable = musicInstrumentData.BuildMock();
        this.musicInstrumentRepository
            .Setup(r => r.GetAllAtached())
            .Returns(eventsMockingQuriable);

        IMusicInstrumentsService musicInstrumentService = new MusicInstrumentsService(musicInstrumentRepository.Object);

        IEnumerable<MusicalInstrumentsIndexViewModel> allEventsActual = await musicInstrumentService
            .IndexGetAllNotDeletedAsync("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f");

        Assert.IsNotNull(allEventsActual);
        Assert.AreEqual(expectedEventCount, allEventsActual.Count());
        Assert.AreEqual(expectedEventId.ToLower(), allEventsActual.First().Id.ToString().ToLower());

    }
        
    }
}
