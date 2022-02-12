using SchoolManagement.Models.Model;
using System.Collections.Generic;

namespace SchoolManagement.Repositories.Repository
{
    public interface ICountryRepository
    {
        /// <summary>
        /// Gets the country list.
        /// </summary>
        /// <returns>GetCountryList</returns>
        List<CountryModel> GetCountryList();

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="countryModel">The country model.</param>
        /// <returns>AddCountry</returns>
        bool AddUpdateCountry(CountryModel countryModel);

        /// <summary>
        /// Gets the country by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>GetCountryById</returns>
        CountryModel GetCountryById(int id);

        /// <summary>
        /// Deletes the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeleteCountry</returns>
        bool DeleteCountry(int id);
    }
}
