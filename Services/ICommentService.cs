using tg_server.models;

namespace tg_server.Services
{
    public interface ICommentService
    {
        List<comment> Get();
        comment Get(String id);
        comment Create(comment comment);
        void Delete(string id);



    }
}
