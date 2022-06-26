using System.Collections;
using System.Collections.Generic;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext Context;
        public AlunoRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Aluno aluno)
        {
            Context.Add(aluno);
        }

        public void Delete(int alunoId)
        {
           var aluno =  GetByIdAsync(alunoId);
           Context.Remove(aluno);
        }
        public async Task<Aluno> GetByIdAsync(int alunoId)
        {
            return await Context.DbSetAluno.
            SingleOrDefaultAsync(i =>i.Id == alunoId);
                       
        }

        public void Update(Aluno aluno)
        {
            Context.Entry(aluno).State = EntityState.Modified;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            return await Context.DbSetAluno.ToListAsync();
        }

        

       
    }
}