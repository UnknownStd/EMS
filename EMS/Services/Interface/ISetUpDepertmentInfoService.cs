using EMS.Models;

namespace EMS.Services.Interface
{
    public interface ISetUpDepertmentInfoService
    {
        public int  GetDepertmentById(int DepertmentId);
        public void SaveDepertment(SetUpDepertmentViewModel model);
        public void DeleteDepertment(int DepertmentId);
        List<SetUpDepertmentViewModel> GetDepertmentList();
        public bool UpdateDepertment(int DepertmentId, SetUpDepertmentViewModel model);

    }
}
