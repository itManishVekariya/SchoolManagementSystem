using SchoolManagement.Models.Context;
using SchoolManagement.Models.Model;
using System;

namespace SchoolManagement.Helpers.Helpers
{
    /// <summary>
    /// StateHelper
    /// </summary>
    public static class StateHelper
    {
        /// <summary>
        /// Binds the state list.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>
        /// BindStateList
        /// </returns>
        public static StateModel BindStateList(State state)
        {
            try
            {
                StateModel stateModel = new StateModel();
                stateModel.StateId = state.StateId;
                stateModel.Name = state.Name;
                stateModel.CountryFK = state.CountryFK;
                stateModel.CreatedAt = state.CreatedAt;
                stateModel.CreatedBy = state.CreatedBy;
                stateModel.UpdatedAt = state.UpdatedAt;
                stateModel.UpdatedBy = state.UpdatedBy;
                stateModel.DeletedAt = state.DeletedAt;
                stateModel.DeletedBy = state.DeletedBy;
                stateModel.IsDeleted = state.IsDeleted;
                stateModel.CountryName = state.Country != null && !string.IsNullOrEmpty(state.Country.Name) ? (state.Country.Name) : string.Empty;

                return stateModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Binds the state.
        /// </summary>
        /// <param name="stateModel">The state model.</param>
        /// <returns>
        /// BindState
        /// </returns>
        public static State BindState(StateModel stateModel)
        {
            try
            {
                State state = new State();
                state.StateId = stateModel.StateId;
                state.Name = stateModel.Name;
                state.CountryFK = stateModel.CountryFK;
                state.CreatedAt = stateModel.CreatedAt;
                state.CreatedBy = stateModel.CreatedBy;
                state.UpdatedAt = stateModel.UpdatedAt;
                state.UpdatedBy = stateModel.UpdatedBy;
                state.DeletedAt = stateModel.DeletedAt;
                state.DeletedBy = stateModel.DeletedBy;
                state.IsDeleted = stateModel.IsDeleted;

                return state;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
