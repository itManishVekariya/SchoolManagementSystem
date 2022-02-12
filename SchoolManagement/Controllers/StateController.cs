using SchoolManagement.Models.Model;
using SchoolManagement.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    /// <summary>
    /// StateController
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StateController : Controller
    {
        /// <summary>
        /// The i state
        /// </summary>
        private readonly IStateRepository _iState;

        /// <summary>
        /// The i country
        /// </summary>
        private readonly ICountryRepository _iCountry;


        /// <summary>
        /// Initializes a new instance of the <see cref="StateController"/> class.
        /// </summary>
        /// <param name="iState">State of the i.</param>
        /// <param name="iCountry">The i country.</param>
        public StateController(IStateRepository iState, ICountryRepository iCountry)
        {
            _iState = iState;
            _iCountry = iCountry;
        }

        /// <summary>
        /// States the list.
        /// </summary>
        /// <returns>StateList</returns>
        public ActionResult StateList()
        {
            try
            {
                List<StateModel> stateList = new List<StateModel>();
                stateList = this._iState.GetStateList();

                return View(stateList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AddState</returns>
        [HttpGet]
        public ActionResult AddState(int id = 0)
        {
            try
            {
                StateModel stateModel = new StateModel();
                if (id > 0)
                {
                    stateModel = this._iState.GetStateById(id);
                }
                else
                {
                    List<CountryModel> countryList = new List<CountryModel>();
                    countryList = this._iCountry.GetCountryList();

                    List<SelectListItem> ObjList = new List<SelectListItem>();

                    foreach (CountryModel country in countryList)
                    {
                        ObjList.Add(new SelectListItem { Text = country.Name, Value = country.CountryId.ToString() });
                    }
                    ViewBag.Countries = ObjList;
                }

                return View(stateModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds the state.
        /// </summary>
        /// <param name="stateModel">The state model.</param>
        /// <returns>AddState</returns>
        [HttpPost]
        public ActionResult AddState(StateModel stateModel)
        {
            try
            {
                bool isAdded = this._iState.AddUpdateState(stateModel);
                if (isAdded)
                {
                    return RedirectToAction("StateList");
                }

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeleteState</returns>
        public ActionResult DeleteState(int id)
        {
            try
            {
                bool isDeleted = this._iState.DeleteState(id);
                if (isDeleted)
                {
                    return RedirectToAction("StateList");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View();
        }
    }
}