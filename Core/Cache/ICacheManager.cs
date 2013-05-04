#region Copyright

//  Weapsy - http://www.weapsy.org
//  Copyright (c) 2011-2012 Luca Cammarata Briguglia
//  Licensed under the Weapsy Public License Version 1.0 (WPL-1.0)
//  A copy of this license may be found at http://www.weapsy.org/Documentation/License.txt

#endregion

using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace SDF.Core.Caching
{

	public interface ICacheManager
	{

        T Get<T>(string key);
        object Get(string key);

        void Set(string key, object data);
        void Set(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        bool IsSet(string key);        
        void Remove(string key);
        void RemoveByPattern(string pattern);        
        void Clear();

	}

}