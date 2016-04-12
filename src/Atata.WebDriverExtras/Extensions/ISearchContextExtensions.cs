﻿using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Atata
{
    public static class ISearchContextExtensions
    {
        public static IWebElement Get<T>(this T searchContext, By by)
            where T : ISearchContext
        {
            IExtendedSearchContext contextToSearchIn = ResolveContext(searchContext);
            return contextToSearchIn.FindElement(by);
        }

        public static ReadOnlyCollection<IWebElement> GetAll<T>(this T searchContext, By by)
            where T : ISearchContext
        {
            ISearchContext contextToSearchIn = ResolveContext(searchContext);
            return contextToSearchIn.FindElements(by);
        }

        public static bool Exists<T>(this T searchContext, By by)
            where T : ISearchContext
        {
            ISearchContext contextToSearchIn = ResolveContext(searchContext);
            return contextToSearchIn.Exists(by);
        }

        public static bool Missing<T>(this T searchContext, By by)
            where T : ISearchContext
        {
            ISearchContext contextToSearchIn = ResolveContext(searchContext);
            return contextToSearchIn.Missing(by);
        }

        private static IExtendedSearchContext ResolveContext<T>(this T searchContext)
            where T : ISearchContext
        {
            if (typeof(T).IsSubclassOfRawGeneric(typeof(ExtendedSearchContext<>)))
                return (IExtendedSearchContext)searchContext;
            else
                return new ExtendedSearchContext<T>(searchContext);
        }
    }
}