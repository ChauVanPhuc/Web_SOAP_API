using System.ServiceModel;
using Web_SOAP_API.Model;

namespace Web_SOAP_API.Service
{
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        void AddBlog(string Title, string Content);

        [OperationContract]
        Blog GetBlog(int id);

        [OperationContract]
        List<Blog> GetAllBlogs();

        [OperationContract]
        void UpdateBlog(int id, string Title, string Content);

        [OperationContract]
        void DeleteBlog(int id);
    }
}
