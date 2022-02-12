using SchoolManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Repositories.Repository
{
    public interface IStateRepository
    {
        /// <summary>
        /// Gets the state list.
        /// </summary>
        /// <returns>GetStateList</returns>
        List<StateModel> GetStateList();

        /// <summary>
        /// Adds the state of the update.
        /// </summary>
        /// <param name="stateModel">The state model.</param>
        /// <returns>AddUpdateState</returns>
        bool AddUpdateState(StateModel stateModel);

        /// <summary>
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>GetStateById</returns>
        StateModel GetStateById(int id);

        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DeleteState</returns>
        bool DeleteState(int id);
    }
}
