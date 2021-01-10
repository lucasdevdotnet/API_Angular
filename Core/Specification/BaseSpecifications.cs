using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specification {
    public class BaseSpecifications<T> : ISpecification<T> {
        public BaseSpecifications () {

        }
        public BaseSpecifications (Expression<Func<T, bool>> criteria) {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } =
        new List<Expression<Func<T, object>>> ();

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public BaseSpecifications (int skipe, bool isPaginEnable, int take) {
            this.Skipe = skipe;
            this.IsPagingEnabled = isPaginEnable;
            this.Take = take;

        }
        public int Skipe { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public int Take { get; private set; }

        protected void AddInclude (Expression<Func<T, object>> includeExpression) {
            Includes.Add (includeExpression);
        }
        protected void AddOrderBy (Expression<Func<T, object>> orderByExpression) {
            OrderByDescending = orderByExpression;
        }
        protected void AddOrderByDescendig (Expression<Func<T, object>> orderByDescendigExpression) {
            OrderByDescending = orderByDescendigExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skipe= skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}