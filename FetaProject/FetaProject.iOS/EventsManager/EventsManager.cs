using FetaProject.Enums;
using FetaProject.iOS.LocalizationExtension;
using FetaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FetaProject.iOS.EventsManager
{
    public static class EventsManager
    {
        private const string TheaterNameSuffix = "_TheaterName";
        private const string OriginCountrySuffix = "_OriginCountry";
        private const string DescriptionSuffix = "_Description";
        private const string DateTimeSuffix = "_DateTime";

        public static IEnumerable<Event> GetEvents()
        {
            var events = new List<Event>();

            foreach (var eventName in Enum.GetNames(typeof(EventNames)))
            {
                var newEvent = new Event
                {
                    ActName = eventName.Translate(),
                    TeatreName = (eventName + TheaterNameSuffix).Translate(),
                    OriginCountry = (eventName + OriginCountrySuffix).Translate(),
                    Description = (eventName + DescriptionSuffix).Translate(),
                    TimeEvent = DateTime.ParseExact((eventName + DateTimeSuffix).Translate(), "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                };

                events.Add(newEvent);
            }

            return events;
        }

		public static Event GetEventByName(string actName)
		{
			return GetEvents().FirstOrDefault(x => x.ActName == actName);
		}
    }
}