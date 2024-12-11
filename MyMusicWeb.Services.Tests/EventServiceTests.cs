using Moq;
using MockQueryable;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Data;
using MyMusicWebViewModels.Event;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace MyMusicWeb.Services.Tests
{
    [TestFixture]
    public class Tests
    {
        private IList<Event> eventData = new List<Event>()
        {
            new Event()
            {
                Id = Guid.Parse("C994999B-02DD-46C2-ABC4-00C4787E629F"),
                Name = "Rock Legends Reunion",
                Description = "An epic night celebrating the legends of rock with classic hits and surprise performances.",
                Date = DateTime.Parse("2025-06-15T20:00:00.0000000"),
                GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                LocationId = Guid.Parse("c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e"),
                IsActual = true,
                HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a",
                AvailableTickets = 162,
                PricePerTicket = 100,
                ImageUrl = "https://images.unsplash.com/photo-1721133073235-e4b5facb27fa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bXVzaWMlMjBldmVudHxlbnwwfHwwfHx8MA%3D%3D"
            },
            new Event()
            {
              Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
                Name = "Rock Night Thunder",
                Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
                Date = DateTime.Parse("2025-12-15T19:30:00.0000000"),
                GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                LocationId = Guid.Parse("0F3BF280-5C8F-4534-BF80-1BA60FD029E6"),
                IsActual = true,
                HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a",
                AvailableTickets = 600,
                PricePerTicket = 110,
                ImageUrl ="https://images.squarespace-cdn.com/content/v1/5f724c2854366f48cbcfa30c/b20882e2-963c-4be9-a599-09e61ad7d014/5-Star+Live+Music+Event+Production+Company+%7C+Live+Music+Event+Producers?format=1500w"
            }
        };
        EventAddViewModel viewModel = new EventAddViewModel()
        {
            Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
            Name = "Rock Legends Reunion",
            GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
            LocationId = Guid.Parse("0F3BF280-5C8F-4534-BF80-1BA60FD029E6"),
            Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
            Date = DateTime.Parse("2025-12-15T19:30:00.0000000"),
            Count = 400,
            PricePerTicket = 110,
            HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a"
        };
        private Mock<IRepository<Event, Guid>> eventRepository;

        [SetUp]
        public void Setup()
        {
            this.eventRepository = new Mock<IRepository<Event, Guid>>();
        }

        [Test]
        public async Task EventIndexNoSearchingQuery()
        {
            IQueryable<Event> eventsMockingQuriable = eventData.BuildMock();
            this.eventRepository
                .Setup(r => r.GetAllAtached())
                .Returns(eventsMockingQuriable);

            IEventService eventService = new EventService(eventRepository.Object);

            IEnumerable<EventIndexViewModel> allEventsActual = await eventService
                .IndexGetAllActualEventsAsync(new EventPaginationAndSearchViewModel());

            Assert.IsNotNull(allEventsActual);
            Assert.AreEqual(this.eventData.Count(), allEventsActual.Count());

            allEventsActual = allEventsActual
                .OrderBy(m => m.Id)
                .ToList();

            
        }
        [Test]
        [TestCase("Legends")]
        public async Task EventIndexNoSearchingQuery(string searchQuery)
        {
            int expectedEventCount = 1;
            string expectedEventId = "C994999B-02DD-46C2-ABC4-00C4787E629F";
            IQueryable<Event> eventsMockingQuriable = eventData.BuildMock();
            this.eventRepository
                .Setup(r => r.GetAllAtached())
                .Returns(eventsMockingQuriable);

            IEventService eventService = new EventService(eventRepository.Object);

            IEnumerable<EventIndexViewModel> allEventsActual = await eventService
                .IndexGetAllActualEventsAsync(new EventPaginationAndSearchViewModel()
                {
                    SearchQuery = "Legends"
                });

            Assert.IsNotNull(allEventsActual);
            Assert.AreEqual(expectedEventCount, allEventsActual.Count());
            Assert.AreEqual(expectedEventId.ToLower(), allEventsActual.First().Id.ToString().ToLower());


        }
        [Test]
        public async Task EventIndexEventDeleted()
        {
            IList<Event> eventData = new List<Event>()
            {
                new Event()
            {
                Id = Guid.Parse("C994999B-02DD-46C2-ABC4-00C4787E629F"),
                Name = "Rock Legends Reunion",
                Description = "An epic night celebrating the legends of rock with classic hits and surprise performances.",
                Date = DateTime.Parse("2025-06-15T20:00:00.0000000"),
                GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                LocationId = Guid.Parse("c28fe4c6-dad9-4cac-a1ae-c1f0e6c3883e"),
                IsActual = true,
                HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a",
                AvailableTickets = 162,
                PricePerTicket = 100,
                ImageUrl = "https://images.unsplash.com/photo-1721133073235-e4b5facb27fa?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bXVzaWMlMjBldmVudHxlbnwwfHwwfHx8MA%3D%3D"
            },
            new Event()
            {
              Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
                Name = "Rock Night Thunder",
                Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
                Date = DateTime.Parse("2025-12-15T19:30:00.0000000"),
                GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                LocationId = Guid.Parse("0F3BF280-5C8F-4534-BF80-1BA60FD029E6"),
                IsActual = false,
                HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a",
                AvailableTickets = 600,
                PricePerTicket = 110,
                ImageUrl ="https://images.squarespace-cdn.com/content/v1/5f724c2854366f48cbcfa30c/b20882e2-963c-4be9-a599-09e61ad7d014/5-Star+Live+Music+Event+Production+Company+%7C+Live+Music+Event+Producers?format=1500w"
            }
            };
            int expectedEventCount = 1;
            string expectedEventId = "C994999B-02DD-46C2-ABC4-00C4787E629F";
            IQueryable<Event> eventsMockingQuriable = eventData.BuildMock();
            this.eventRepository
                .Setup(r => r.GetAllAtached())
                .Returns(eventsMockingQuriable);

            IEventService eventService = new EventService(eventRepository.Object);

            IEnumerable<EventIndexViewModel> allEventsActual = await eventService
                .IndexGetAllActualEventsAsync(new EventPaginationAndSearchViewModel());

            Assert.IsNotNull(allEventsActual);
            Assert.AreEqual(expectedEventCount, allEventsActual.Count());
            Assert.AreEqual(expectedEventId.ToLower(), allEventsActual.First().Id.ToString().ToLower());

        }
        [Test]
        public async Task AddEvent()
        {
            

            IEventService eventService = new EventService(eventRepository.Object);



            Assert.DoesNotThrowAsync(async () =>
            {
                await eventService
                  .AddEventsAsync(viewModel);
            });
        }
        [Test]
        public async Task DeleteEventWhenNoEvents()
        {
            IEventService eventService = new EventService(eventRepository.Object);

            Assert.DoesNotThrowAsync(async () =>
            {
                await eventService
                  .DeleteFromEventsById(new EventDeleteViewModel()
                  {
                      Id = Guid.Parse("C997999B-02DD-46C2-ABC4-00C4787E629F"),
                      Name = "Rock Legends Reunion",
                  });

            });
            
        }
        [Test]
        public async Task EditEvent()
        {
            IQueryable<Event> eventsMockingQuriable = eventData.BuildMock();
            this.eventRepository
                .Setup(r => r.GetAllAtached())
                .Returns(eventsMockingQuriable);

            IEventService eventService = new EventService(eventRepository.Object);

            EventEditViewModel editViewModel = new EventEditViewModel()
            {
                Id = Guid.Parse("e9c8f1a9-0a0c-4f89-83c9-638c1e9f7e8f"),
                Name = "Rock Legends Reunion",
                GenraId = Guid.Parse("b3b75cfd-6b4e-4d6b-82fa-3b321be40e5b"),
                LocationId = Guid.Parse("0F3BF280-5C8F-4534-BF80-1BA60FD029E6"),
                Description = "Get ready to rock all night with electrifying performances and epic guitar solos!",
                Date = DateTime.Parse("2025-12-15T19:30:00.0000000"),
                Count = 400,
                PricePerTicket = 110,
                HealderId = "7682ff58-03bd-41b0-81fb-26b077c0050a"
            };
            Assert.DoesNotThrowAsync(async () =>
            {
                eventService.EditEventsById(editViewModel, eventData.First());
            });
            

        }
        [Test]
        public async Task EventDetailsNoGuid()
        {

        }
    }
    
}