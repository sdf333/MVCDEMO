using System;
using System.Linq;
using DB.SDFAuth;
using SDF.Core;
using SDF.Core.Caching;
using SDFAuth.Data;
using SDFAuth.Services;

namespace Nop.Services.Blogs
{
    /// <summary>
    /// Blog service
    /// </summary>
    public class ApplicationService : BaseService, IApplicationService
    {
        #region Constants

        private const string APPLACATION_BY_ID_KEY = "SDF.application.id-{0}";
        private const string APPLACATION_PATTERN_KEY = "SDF.application.";

        #endregion

        #region Fields

        private readonly IRepository<application> _repository;

        #endregion

        #region Ctor

        public ApplicationService(IRepository<application> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="entity">Blog post</param>
        public virtual void Delete(application entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _repository.Delete(entity);
            CacheManager.RemoveByPattern(APPLACATION_PATTERN_KEY);
        }

        /// <summary>
        /// Gets a blog post
        /// </summary>
        /// <param name="blogPostId">Blog post identifier</param>
        /// <returns>Blog post</returns>
        public virtual application GetById(int id)
        {
            if (id == 0)
                return null;
            
            string key = string.Format(APPLACATION_BY_ID_KEY, id);
            return CacheManager.Get(key, () =>
                {
                    application pv = _repository.GetById(id);
                    return pv;
                });
        }

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
        /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog posts</returns>
        public IPagedList<application> GetAll(int id, int pageIndex, int pageSize)
        {
            IQueryable<application> query = _repository.Table;

            query = query.OrderByDescending(b => b.id);

            var blogPosts = new PagedList<application>(query, pageIndex, pageSize);
            return blogPosts;
        }


        /// <summary>
        /// Inserts an blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public virtual void Insert(application entity)
        {
            if (entity == null)
                throw new ArgumentNullException("blogPost");

            _repository.Add(entity);

            CacheManager.RemoveByPattern(APPLACATION_PATTERN_KEY);
        }

        /// <summary>
        /// Updates the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public virtual void Update(application entity)
        {
            if (entity == null)
                throw new ArgumentNullException("blogPost");

            _repository.Update(entity);

            CacheManager.RemoveByPattern(APPLACATION_PATTERN_KEY);
        }

        #endregion
    }
}