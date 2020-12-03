using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FuzzySharp.SimilarityRatio.Scorer;

namespace FuzzySharp.SimilarityRatio
{
    public static class ScorerCache
    {
        private static readonly Dictionary<Type, IRatioScorer> s_scorerCache = new Dictionary<Type, IRatioScorer>();
        public static IRatioScorer Get<T>() where T : IRatioScorer, new()
        {
            if (s_scorerCache.TryGetValue(typeof(T), out var t))
            {
                return t;
            }
           
            s_scorerCache.Add(typeof(T), new T());
            
            if (s_scorerCache.TryGetValue(typeof(T), out t))
            {
                return t;
            }

            return null;
        }
    }
}
