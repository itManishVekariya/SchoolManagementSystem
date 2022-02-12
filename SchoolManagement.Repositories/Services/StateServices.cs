using SchoolManagement.Helpers.Helpers;
using SchoolManagement.Models.Context;
using SchoolManagement.Models.Model;
using SchoolManagement.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories.Services
{
    public class StateServices : IStateRepository
    {
        /// <summary>
        /// Gets the state list.
        /// </summary>
        /// <returns>
        /// GetStateList
        /// </returns>
        public List<StateModel> GetStateList()
        {
            List<StateModel> stateList = new List<StateModel>();
            try
            {
                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var states = (from u in context.States
                                  where u.IsDeleted == false
                                  select u).ToList();
                    if(states != null && states.Count > 0)
                    {
                        foreach(State state in states)
                        {
                            StateModel stateModel = new StateModel();

                            state.Country = (from c in context.Countries
                                             where c.CountryId == state.CountryFK
                                             select c).FirstOrDefault();

                            stateModel = StateHelper.BindStateList(state);

                            stateList.Add(stateModel);
                        }
                    }
                    return stateList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Adds the state of the update.
        /// </summary>
        /// <param name="stateModel">The state model.</param>
        /// <returns>
        /// AddUpdateState
        /// </returns>
        public bool AddUpdateState(StateModel stateModel)
        {
            try
            {
                if(stateModel.StateId > 0)
                {
                    stateModel.UpdatedAt = DateTime.Now;
                }
                else
                {
                    stateModel.CreatedAt = DateTime.Now;
                }

                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var states = (from u in context.States
                                  where u.StateId == stateModel.StateId
                                  select u).FirstOrDefault();
                    if(states != null)
                    {
                        states.StateId = stateModel.StateId;
                        states.Name = stateModel.Name;
                        states.CountryFK = stateModel.CountryFK;
                        states.CreatedAt = stateModel.CreatedAt;
                        states.CreatedBy = stateModel.CreatedBy;
                        states.UpdatedAt = stateModel.UpdatedAt;
                        states.UpdatedBy = stateModel.UpdatedBy;
                        states.DeletedAt = stateModel.DeletedAt;
                        states.DeletedBy = stateModel.DeletedBy;
                        states.IsDeleted = stateModel.IsDeleted;
                    }
                    else
                    {
                        states = context.States.Create();
                        states = StateHelper.BindState(stateModel);
                        context.States.Add(states);
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
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// GetStateById
        /// </returns>
        public StateModel GetStateById(int id)
        {
            StateModel stateModel = new StateModel();
            try
            {
                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var editState = (from u in context.States
                                     where u.StateId == id
                                     select u).FirstOrDefault();
                    if(editState != null)
                    {
                        stateModel = StateHelper.BindStateList(editState);
                    }

                    return stateModel;
                }
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
        /// <returns>
        /// DeleteState
        /// </returns>
        public bool DeleteState(int id)
        {
            try
            {
                using(SchoolMgmtEntities context = new SchoolMgmtEntities())
                {
                    var deleteState = (from u in context.States
                                       where u.StateId == id
                                       select u).FirstOrDefault();
                    if(deleteState != null)
                    {
                        deleteState.IsDeleted = true;
                        deleteState.DeletedAt = DateTime.Now;
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
