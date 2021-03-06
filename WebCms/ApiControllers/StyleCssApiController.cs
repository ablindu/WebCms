﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using WebCms.Models;
using WebCms.ORM.Models;

namespace WebCms.ApiControllers
{
    public class StyleCssApiController : ApiController
    {
        private WebCmsContext _context = new WebCmsContext();
        // GET: api/StyleCssApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/StyleCss/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StyleCss
        [Authorize(Roles = "Manager,Admin")]
        public int Post([FromBody]JObject jsonData)
        {
            var json = jsonData.ToObject<StyleCssDTO>();
            var cssStyle = new StyleCss();

            cssStyle.PageId = 1;
            cssStyle.Name = json.Name;
            cssStyle.Url = json.Url;

            _context.Entry(cssStyle).State = EntityState.Added;
            return _context.SaveChanges();
        }

        // PUT: api/StyleCss/5
        public void Put([FromBody]JObject jsonData)
        {
            var json = jsonData.ToObject<StyleCssDTO>();
            var cssStyle = new StyleCss();

            cssStyle.Id = 10;
            cssStyle.PageId = 1;
            cssStyle.Name = json.Name;
            cssStyle.Url = json.Url;

            _context.Entry(cssStyle).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
