using DirectoryService.Domain.Departments;

namespace DirectoryService.Application;

public class TestService(ITestRepositiry repositiry)
{
    private readonly ITestRepositiry _repositiry = repositiry;
    
    public async Task AddTestDepartment()
    {
        await _repositiry.Add();
    }

    public async Task<List<Department>> GetTestDepartment()
    {
        return await _repositiry.GetAll();
    }
}