using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HoursRegisteringRestService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "days")
        ]
        List<Work> GetListWork();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "day/{date}/{name}")
        ]
        List<Work> GetWork(DateTime date, string name);

        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "day")
        ]
        string PostWork(Work work); //TODO: needs parameters.

        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "day")
        ]
        String PutWork(Work work); //TODO: needs parameters.

        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "place")
        ]
        string PostPlace(Place place);

        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "place")
        ]
        List<Place> GetPlaces();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "user/{username}")
        ]
        User GetSpecificUser(string username);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "user")
        ]
        List<User> GetUsers();

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "user/{user}")
        ]
        string DeleteUser(string user);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "user?user={user}")
        ]
        string PostUser(User user);
        
    }
}
