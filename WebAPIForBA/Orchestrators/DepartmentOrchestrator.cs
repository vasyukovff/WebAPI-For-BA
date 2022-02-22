using WebAPIForBA.Dto.Department;
using WebAPIForBA.Models;
using WebAPIForBA.Orchestrators.Common;

namespace WebAPIForBA.Orchestrators
{
    public class DepartmentOrchestrator
    {
        public DataResult<DepartmentModel> Add(DepartmentCreateDto data)
        {
            try
            {
                using (PostgreDbContext db = new PostgreDbContext())
                {
                    db.Departments.Add(new DepartmentModel
                    {
                        Title = data.Title,
                    });
                    db.SaveChanges();
                }

                return new DataResult<DepartmentModel>(true);
            }
            catch (Exception ex)
            {
                return new DataResult<DepartmentModel>(false, ex.Message);
            }
        }

        public IEnumerable<DepartmentModel> GetAll(int take = 10)
        {
            if (take < 1)
                take = 1;
            else if (take > 100)
                take = 100;

            using (PostgreDbContext db = new PostgreDbContext())
            {
                return db.Departments.ToList().Take(take);
            }
        }

        public DataResult<DepartmentModel> Remove(int Id)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {
                DepartmentModel? model = db.Departments.FirstOrDefault(x => x.Id == Id);

                if (model == null)
                    return new DataResult<DepartmentModel>(false, $"Отдел с id '{Id}' не найден!");

                db.Departments.Remove(model);
                db.SaveChanges();

                return new DataResult<DepartmentModel>(true);
            }
        }

        public DataResult<DepartmentModel> Update(DepartmentUpdateDto data)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {

                var result = db.Departments.FirstOrDefault(x => x.Id == data.Id);

                if (result == null)
                    return new DataResult<DepartmentModel>(false, "Не удалось найти и изменить информацию о отделе");

                result.Title = data.Title;

                db.SaveChanges();

                return new DataResult<DepartmentModel>(true);
            }
        }
    }
}
