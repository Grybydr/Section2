using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainModel;
using MySqlDatabase;

namespace SovaApp.Controllers
{
    public class HistoryController : ApiController
    {
        private MySqlRepository _repository = new MySqlRepository();

        public IHttpActionResult Get()
        {
            var data = _repository.GetAllHistory();
            return Ok(data);
        }

    }
}
