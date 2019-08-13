using bookapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.ApiModels
{
    public static class PublisherMappingExtentions
    {
        public static PublisherModel ToApiModel(this Publisher publisher)
        {
            return new PublisherModel
            {

                Id = publisher.Id,
                Name = publisher.Name,
                FoundedYear = publisher.FoundedYear,
                CountryOfOrigin = publisher.CountryOfOrigin,
                HeadQuartersLocation =publisher.HeadQuartersLocation

            };
        }
       

        public static Publisher ToDomainModel(this PublisherModel publisherModel)
        {
            return new Publisher
            {
                Id = publisherModel.Id,
                Name = publisherModel.Name,
                FoundedYear = publisherModel.FoundedYear,
                CountryOfOrigin = publisherModel.CountryOfOrigin,
                HeadQuartersLocation = publisherModel.HeadQuartersLocation
            };
        }

        public static IEnumerable<PublisherModel> ToApiModels(this IEnumerable<Publisher> publishers)
        {
            return publishers.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Publisher> ToDomainModel(this IEnumerable<PublisherModel> publisherModels)
        {
            return publisherModels.Select(a => a.ToDomainModel());
        }

    }
}
