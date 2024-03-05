using Grades.Application.IRepositories;
using MediatR;

namespace Grades.Application.Features.StudentFeatures.Commands.SaveStudentCommand
{
    public class SaveStudentCommandHandler : IRequestHandler<SaveStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        public SaveStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(SaveStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
