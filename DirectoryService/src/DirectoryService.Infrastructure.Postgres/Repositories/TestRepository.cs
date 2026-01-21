using DirectoryService.Application;
using DirectoryService.Domain.Departments;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public class TestRepository : ITestRepositiry
{
    private readonly DirectoryServiceDbContext _context;

    public TestRepository(DirectoryServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<Department> Add()
    {
        var result = Department.Create(
            "test",
            "Test",
            "Test",
            5);
        
        if(result.IsFailure)
            throw new Exception(result.Error);
        _context.Departments.Add(result.Value);
        
        await _context.SaveChangesAsync();
        
        return result.Value;
    }

    public Task<List<Department>> GetAll()
    {
        var result = _context.Departments.ToList();
        return Task.FromResult(result);
    }
}