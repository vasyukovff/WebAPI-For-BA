using Microsoft.EntityFrameworkCore;
using WebAPIForBA.Dto.Profile;
using WebAPIForBA.Models;
using WebAPIForBA.Orchestrators.Common;

namespace WebAPIForBA.Orchestrators
{
    public class ProfileOrchestrator
    {
        public DataResult<ProfileModel> Add(ProfileDto data)
        {
            try
            {

                using (PostgreDbContext db = new PostgreDbContext())
                {
                    var validResult = ValidateProfileDto(data);

                    if (validResult.IsSuccess == false)
                        return validResult;

                    db.Profiles.Add(new ProfileModel
                    {
                        AccountId = data.AccountId,
                        DepartmentId = data.DepartmentId,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                    });
                    db.SaveChanges();
                }

                return new DataResult<ProfileModel>(true);
            }
            catch (Exception ex)
            {
                return new DataResult<ProfileModel>(false, ex.Message);
            }
        }

        public DataResult<ProfileModel> Get(int accountId)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {
                var result = db.Profiles.Include(x => x.Account).Include(x => x.Department).FirstOrDefault(x => x.AccountId == accountId);

                if (result != null)
                    return new DataResult<ProfileModel>(true, result);

                return new DataResult<ProfileModel>(false, $"Не удалось найти профиль для аккаунта с id {accountId}");
            }
        }

        public DataResult<ProfileModel> Update(ProfileDto data)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {

                var validResult = ValidateProfileDto(data);

                if (validResult.IsSuccess == false)
                    return validResult;

                var result = db.Profiles.FirstOrDefault(x => x.AccountId == data.AccountId);

                if (result == null)
                    return new DataResult<ProfileModel>(false, $"Не удалось найти профиль для аккаунта с id {data.AccountId}");

                result.DepartmentId = data.DepartmentId;
                result.FirstName = data.FirstName;
                result.LastName = data.LastName;

                db.SaveChanges();

                return new DataResult<ProfileModel>(true);
            }
        }

        private DataResult<ProfileModel> ValidateProfileDto(ProfileDto dto)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {

                var result = db.Accounts.FirstOrDefault(x => x.Id == dto.AccountId);

                if (result == null)
                    return new DataResult<ProfileModel>(false, $"Не удалось найти аккаунт с id {dto.AccountId}");

                DepartmentModel department = db.Departments.FirstOrDefault(x => x.Id == dto.DepartmentId);

                if (department == null)
                    return new DataResult<ProfileModel>(false, $"Не удалось найти отдел с id {dto.DepartmentId}");
            }

            return new DataResult<ProfileModel>(true);
        }
    }
}
