using SchoolManagement.Models.Context;
using SchoolManagement.Models.Model;
using System;

namespace SchoolManagement.Helpers.Helpers
{
    public static class CountryHelper
    {
        /// <summary>
        /// Binds the country list.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>BindCountryList</returns>
        public static CountryModel BindCountryList(Country country)
        {
            try
            {
                CountryModel countryModel = new CountryModel();
                countryModel.CountryId = country.CountryId;
                countryModel.Name = country.Name;
                countryModel.CreatedAt = country.CreatedAt;
                countryModel.CreatedBy = country.CreatedBy;
                countryModel.UpdatedAt = Convert.ToDateTime(country.UpdatedAt);
                countryModel.UpdatedBy = Convert.ToInt64(country.UpdatedBy);
                countryModel.DeletedAt = Convert.ToDateTime(country.DeletedAt);
                countryModel.DeletedBy = Convert.ToInt64(country.DeletedBy);
                countryModel.IsDeleted = country.IsDeleted;

                return countryModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Binds the country.
        /// </summary>
        /// <param name="countryModel">The country model.</param>
        /// <returns>BindCountry</returns>
        public static Country BindCountry(CountryModel countryModel)
        {
            try
            {
                Country country = new Country();
                country.CountryId = countryModel.CountryId;
                country.Name = countryModel.Name;
                country.CreatedAt = countryModel.CreatedAt;
                country.CreatedBy = countryModel.CreatedBy;
                country.UpdatedAt = countryModel.UpdatedAt;
                country.UpdatedBy = countryModel.UpdatedBy;
                country.DeletedAt = countryModel.DeletedAt;
                country.DeletedBy = countryModel.DeletedBy;
                country.IsDeleted = countryModel.IsDeleted;

                return country;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
