using DirectoryService.Domain.Departments;

namespace DirectoryService.Application;

public interface ITestRepositiry
{
    Task<Department> Add();
        
    Task<List<Department>> GetAll();
}