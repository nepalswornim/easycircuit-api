using API.DataAccess;
using API.DataAccess.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.BaseAPI;
using System.Diagnostics;


namespace API.Controllers
{

    public class ItemsController : ApiController
    {   // GET api/documentation
        /// <summary>
        /// This method returns a list of all available items.
        /// </summary>
        /// <returns></returns>

        [Route("api/allitems/")]
        public ApiResponse Get()
        {
            DataProvider dp = new DataProvider();
            ApiResponse apr = new ApiResponse();
            apr.data = dp.GetAllLadies();
            apr.code = 200;
            apr.message = "Successful";
            return apr;
        }

        [Route("api/item/{id}")]
        // GET api/values/5
        public ApiResponse Get(int id)
        {
            DataProvider dp = new DataProvider();
            Ladies ld = dp.GetLadiesById(id);

            ApiResponse apr = new ApiResponse();
            if (ld != null)
            {
                apr.data = ld;
                apr.code = 200;
                apr.message = "Successful";
            }
            else
            {
                apr.data = null;
                apr.code = 204;
                apr.message = "Data Not Found.";
            }
            return apr;
        }

        [Route("api/additem/")]
        // POST api/values
        public ApiResponse Post([FromBody] Ladies ld)
        {
            DataProvider dp = new DataProvider();
            ApiResponse apr = new ApiResponse();
            if (ModelState.IsValid)
            {
                apr.code = 201;
                apr.message = "Created Successfully";
                dp.AddNewLadies(ld);

            }
            else
            {
                apr.code = 206;
                apr.message = "Partial Content";
            }
            return apr;
        }

        [Route("api/updateitem/")]
        [HttpPut]
        // PUT api/values/5
        public ApiResponse Put( [FromBody]Ladies ladies)
        {
            ApiResponse apr = new ApiResponse();
            if (ModelState.IsValid && ladies.Id != 0)
            {
                DataProvider dp = new DataProvider();
                int i = dp.UpdateLady(ladies);
           
                if (i == 1)
                {
                    apr.code = 200;
                    apr.message = "Updated Successfully";

                }
                else if (i == -1 || i==0)
                {
                    apr.code = 204;
                    apr.message = "Data Not Found";
                }

                return apr;
            }
            else
            {
                apr.code = 206;
                apr.message = "Partial Content";
                return apr;
            }
        }

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
