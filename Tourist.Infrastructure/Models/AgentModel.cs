using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class AgentModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }
    }
}
