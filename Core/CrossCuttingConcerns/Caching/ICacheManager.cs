using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        T Get<T>(string key); //bir objeyi cachede listeleme;
        object Get(string key);
        void Add(string key, object value, int duration);//bir objeyi cache ekleme;
        bool IsAdd(string key);//cachede varsa getir yoksa veri tabanında getir;
        void Remove(string key);//cacden uçur
        void RemoveByPatern(string pattern);//filitreleme yaparak cacheden silme;
    }
}