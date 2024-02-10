using Organizador_Apollo.Model;
using SQLite;

namespace Organizador_Apollo.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection Database;

        public DatabaseService()
        {
        }
        public async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var value = await Database.CreateTablesAsync<Classification, Material>();
        }
        #region Get database
        public async Task<List<Material>> GetMaterials()
        {
            await Init();
            return await Database.Table<Material>().ToListAsync();
        }
        public async Task<List<Classification>> GetClassifications()
        {
            await Init();
            return await Database.Table<Classification>().ToListAsync();
        }
        #endregion

        #region Get specific items
        public async Task<List<Material>> GetSpecificMaterials(string name, string? classification = null)
        {
            await Init();
            if (classification is not null)
                return await Database.Table<Material>().Where(Material => Material.Name == name && Material.Classification == classification).ToListAsync();
            return await Database.Table<Material>().Where(Material => Material.Name == name).ToListAsync();
        }
        public async Task<List<Classification>> GetSpecificClassification(string name)
        {
            await Init();
            return await Database.Table<Classification>().Where(classification => classification.Name == name).ToListAsync();
        }
        #endregion

        #region Save and update items
        public async Task SaveMaterialAsync(Material material)
        {
            await Init();
            if (material.Id != 0)
                await Database.UpdateAsync(material);
            else
                await Database.InsertAsync(material);
        }

        public async Task SaveClassification(Classification classification)
        {
            await Init();
            int Exists = await Database.Table<Classification>().Where(item => item.Name == classification.Name).CountAsync();
            if (Exists > 0)
                await Database.UpdateAsync(classification);
            else
                await Database.InsertAsync(classification);
        }
        #endregion

        #region Delete items
        public async Task DeleteMaterial(Material material)
        {
            await Init();
            await Database.DeleteAsync(material);
        }
        public async Task DeleteClassification(Classification classification)
        {
            await Init();
            await Database.DeleteAsync(classification);
        }
        #endregion
    }
}
