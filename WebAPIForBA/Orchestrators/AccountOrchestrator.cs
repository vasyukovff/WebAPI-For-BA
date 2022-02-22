using Microsoft.EntityFrameworkCore;
using WebAPIForBA.Dto.Account;
using WebAPIForBA.Models;
using WebAPIForBA.Orchestrators.Common;

namespace WebAPIForBA.Orchestrators
{
    public class AccountOrchestrator
    {
        public DataResult<AccountModel> Add(AccountCreateDto data)
        {
            try
            {

                using (PostgreDbContext db = new PostgreDbContext())
                {
                    db.Accounts.Add(new AccountModel
                    {
                        Email = data.Email,
                        Name = data.Name
                    });
                    db.SaveChanges();
                }

                return new DataResult<AccountModel>(true);
            }
            catch (Exception ex)
            {
                return new DataResult<AccountModel>(false, ex.Message);
            }
        }

        public IEnumerable<AccountModel> GetAll(int take = 10)
        {
            if (take < 1)
                take = 1;
            else if (take > 100)
                take = 100;

            using (PostgreDbContext db = new PostgreDbContext())
            {
                return db.Accounts.ToList().Take(take);
            }
        }

        public DataResult<AccountModel> Remove(int Id)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {
                AccountModel? model = db.Accounts.FirstOrDefault(x => x.Id == Id);

                if (model == null)
                    return new DataResult<AccountModel>(false, $"Аккаунт с id '{Id}' не найден!");

                db.Accounts.Remove(model);
                db.SaveChanges();

                return new DataResult<AccountModel>(true);
            }
        }

        public DataResult<AccountModel> Update(AccountUpdateDto data)
        {
            using (PostgreDbContext db = new PostgreDbContext())
            {

                var result = db.Accounts.FirstOrDefault(x => x.Id == data.Id);

                if (result == null)
                    return new DataResult<AccountModel>(false, "Не удалось найти и изменить информацию о аккаунте");

                result.Name = data.Name;
                result.Email = data.Email;

                db.SaveChanges();

                return new DataResult<AccountModel>(true);
            }
        }
    }
}
