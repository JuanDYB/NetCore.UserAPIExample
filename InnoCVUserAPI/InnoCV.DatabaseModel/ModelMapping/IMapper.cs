namespace InnoCV.DatabaseModel.ModelMapping
{
    /// <summary>
    /// Interface that all model mappers should implements
    /// </summary>
    /// <typeparam name="EntityModel"></typeparam>
    /// <typeparam name="ViewModel"></typeparam>
    internal interface IMapper <EntityModel, ViewModel>
    {
        /// <summary>
        /// Method to Map View Model to Entity Model
        /// </summary>
        /// <param name="VModel">View Model</param>
        /// <returns></returns>
        EntityModel MapToEntity(ViewModel VModel);

        /// <summary>
        /// Method to Map Entity Model to View Model
        /// </summary>
        /// <param name="Entity">Entity Model</param>
        /// <returns></returns>
        ViewModel MapToView(EntityModel Entity);
    }
}
