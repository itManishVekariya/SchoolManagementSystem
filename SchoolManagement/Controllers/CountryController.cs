using SchoolManagement.Models.Model;
using SchoolManagement.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    /// <summary>
    /// CountryController
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class CountryController : Controller
    {
        /// <summary>
        /// The i country
        /// </summary>
        private readonly ICountryRepository _iCountry;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryController"/> class.
        /// </summary>
        /// <param name="iCountry">The i country.</param>
        public CountryController(ICountryRepository iCountry)
        {
            _iCountry = iCountry;
        }

        public ActionResult Index()
        {
            try
            {
                List<CountryModel> countryList = new List<CountryModel>();
                
                countryList = this._iCountry.GetCountryList();

                return View(countryList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AddCountry</returns>
        [HttpGet]
        public ActionResult AddCountry(int id = 0)
        {
            try
            {
                CountryModel country = new CountryModel();

                if (id > 0)
                {
                    country = this._iCountry.GetCountryById(id);
                }

                return View(country);
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
        [HttpPost]
        public ActionResult AddCountry(CountryModel countryModel)
        {
            try
            {
                bool isAdded = this._iCountry.AddUpdateCountry(countryModel);
                if (isAdded)
                {
                    return RedirectToAction("CountryList");
                }
                return View();
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
        public ActionResult DeleteCountry(int id)
        {
            try
            {
                bool isDeleted = this._iCountry.DeleteCountry(id);
                if (isDeleted)
                {
                    return RedirectToAction("CountryList");
                }

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}