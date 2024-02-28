using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace RandomGame
{
    static class UnitTests
    {
        public static void Perform()
        {
            if (!Directory.Exists("unit-test-files"))
                Directory.CreateDirectory("unit-test-files");
            //EventUnitTest();
        }
        
        public static void EventUnitTest()
        {
            EventToJsonFile(GetEventSample(), "unit-test-files/sample-event.json");
            Event.FromJsonFile("unit-test-files/sample-event.json");
        }
        static void EventToJsonFile(Event thisEvent,string fileName)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.Converters.Add(new JsonStringEnumConverter());
            string jsonString = JsonSerializer.Serialize(thisEvent, options);
            File.WriteAllText(fileName, jsonString);
        }
        static Event GetEventSample()
        {
            return new Event
            {
                Type = EventType.Display,
                Interval = EventInterval.Daily,
                Id = "event.1",
                Name = "Testing Event",
                Description = "Description",
                Selections = new List<Selection> { { new Selection { Text = "I am the Selection" } } },
                Conditions = new List<Condition> { { new Condition() } },
                Effects = new List<Effect> { { new Effect { Type = EffectType.DisplayMessage, Message = "a" } } },
            };
        }
    }
}
