using SchoolManagement.Helpers.Helpers;
using SchoolManagement.Models.Context;
using SchoolManagement.Models.Model;
using SchoolManagement.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement.Repositories.Services
{
    public class CountryServices : ICountryRepository
    {
        /// <summary>
        /// Gets the country list.
        /// </summary>
        /// <returns>
        /// GetCountryList
        /// </returns>
        public List<CountryModel> GetCountryList()
        {
            List<CountryModel> countryList = new List<CountryModel>();
            try
            {
                using (SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var countries = (from u in context.Countries
                                     where u.IsDeleted == false
                                     select u).ToList();

                    foreach(Country country in countries)
                    {
                        CountryModel countryModel = new CountryModel();
                        countryModel = CountryHelper.BindCountryList(country);
                        countryList.Add(countryModel);
                    }

                    return countryList;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="countryModel">The country model.</param>
        /// <returns>AddCountry</returns>
        public bool AddUpdateCountry(CountryModel countryModel)
        {
            try
            {
                if(countryModel.CountryId > 0)
                {
                    countryModel.UpdatedAt = DateTime.Now;
                }
                else
                {
                    countryModel.CreatedAt = DateTime.Now;
                }

                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var country = (from u in context.Countries
                                      where u.CountryId == countryModel.CountryId
                                      select u).FirstOrDefault();
                    if(country != null)
                    {
                        country.CountryId = countryModel.CountryId;
                        country.Name = countryModel.Name;
                        country.CreatedAt = countryModel.CreatedAt;
                        country.CreatedBy = countryModel.CreatedBy;
                        country.UpdatedAt = countryModel.UpdatedAt;
                        country.UpdatedBy = countryModel.UpdatedBy;
                        country.DeletedAt = countryModel.DeletedAt;
                        country.DeletedBy = countryModel.DeletedBy;
                        country.IsDeleted = countryModel.IsDeleted;
                    }
                    else
                    {
                        country = context.Countries.Create();
                        country = CountryHelper.BindCountry(countryModel);
                        context.Countries.Add(country);
                    }

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        /// <summary>
        /// Gets the country by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>GetCountryById</returns>
        public CountryModel GetCountryById(int id)
        {
            CountryModel countryModel = new CountryModel();
            try
            {
                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var editCountry = (from u in context.Countries
                                       where u.CountryId == id
                                       select u).FirstOrDefault();
                    if (editCountry != null)
                    {
                        countryModel = CountryHelper.BindCountryList(editCountry);
                    }
                }
                return countryModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Deletes the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeleteCountry</returns>
        public bool DeleteCountry(int id)
        {
            try
            {
                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var deleteCountry = (from u in context.Countries
                                         where u.CountryId == id
                                         select u).FirstOrDefault();
                    if(deleteCountry != null)
                    {
                        deleteCountry.IsDeleted = true;
                        deleteCountry.DeletedAt = DateTime.Now;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
