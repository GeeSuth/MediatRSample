
using MediatR;
using Microsoft.EntityFrameworkCore;


// I make all in once file for test purpose only but is will be good in you make every class in file


// Reading
public class GetAllToDoCollectionQuery : IRequest<List<TodoItem>> {}
public class GetAllToDoCollectionHandler : IRequestHandler<GetAllToDoCollectionQuery, List<TodoItem>>
{
    private readonly ToDdoDbContext toDdoDbContext;
    public GetAllToDoCollectionHandler(ToDdoDbContext toDdoDbContext)
    {
        this.toDdoDbContext = toDdoDbContext;
    }

    public async Task<List<TodoItem>> Handle(GetAllToDoCollectionQuery request, CancellationToken cancellationToken)
    {
        return await toDdoDbContext.TodoItems.ToListAsync();
    }
}


// End Reading.


// Post
public class CreateToDoCommand : IRequest<TodoItem> 
{
    public TodoItem toDo;
    public CreateToDoCommand(TodoItem todo)
    {
        toDo = todo;
    }
}

public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, TodoItem>
{
     private readonly ToDdoDbContext toDdoDbContext;
    public CreateToDoCommandHandler(ToDdoDbContext toDdoDbContext)
    {
        this.toDdoDbContext = toDdoDbContext;
    }
    public async Task<TodoItem> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
    {
        var obj = request.toDo;

        toDdoDbContext.TodoItems.Add(obj);
        if(await toDdoDbContext.SaveChangesAsync() >= 1){
            return obj;
        }

        return null;
    }
}
// End Post