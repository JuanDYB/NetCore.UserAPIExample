using InnoCV.DatabaseModel.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoCV.DatabaseModel.Database.Configuration
{
    /// <summary>
    /// Configuration class to User Entity
    /// </summary>
    internal class T_USER_Configuration : IEntityTypeConfiguration<T_USER>
    {
        public void Configure(EntityTypeBuilder<T_USER> entity)
        {
            entity.HasIndex(U => U.OID).IsUnique(true);
        }
    }
}
