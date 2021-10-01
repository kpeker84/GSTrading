﻿using GSTradingProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GSTradingProject.BLL.Patterns.Repository.IRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Listeleme 
        List<T> GetAll();
        //List<T> GetActives();
        //List<T> GetModifieds();
        //List<T> GetPassives();

        //Modifikasyon
        void Add(T item);
        void SoftDelete(T item);
        void Destroy(T item);
        void Update(T item);

        //Sorgulamalar
        List<T> Where(Expression<Func<T, bool>> exp);
        T Default(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        T Find(int id);
    }
}
