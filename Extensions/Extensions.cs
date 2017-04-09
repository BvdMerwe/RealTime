using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using RealTime.Data;
using RealTime.Models;

namespace RealTime.Extensions
{
    public static class DatabaseExtensions
    {
        public static bool AllMigrationsApplied(this ApplicationDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                    .GetAppliedMigrations()
                    .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                    .Migrations
                    .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.QuestionTypes.Any())
                {
                    // var clothing = context.Categories.Add(new Category { DisplayName = "Clothing" }).Entity;

                    context.QuestionTypes.AddRange(
                        new QuestionType { Type = "Multiple Choice" },
                        new QuestionType { Type = "Text" }
                    );

                    context.SaveChanges();
                }

                if (!context.Setlists.Any())
                {
                    //Q1
                    var A1_1 = new Answer{ AnswerContent = "Dom Perignon", Correct = true };
                    var A1_2 = new Answer{ AnswerContent = "J.C. Le Roux", Correct = false };
                    var A1_3 = new Answer{ AnswerContent = "Phillipe Phillipe", Correct = false };
                    var A1_4 = new Answer{ AnswerContent = "Pierre Jouet", Correct = false };
                    var A1 = new List<Answer>(){ A1_1,A1_2,A1_3,A1_4 };
                    context.Answers.AddRange(A1);
                    var Q1 = new Question{ DateCreated = DateTime.Now,  QuestionContent = "Who was the legendary Benedictine monk who invented champagne?", Answers = A1 };
                    context.Questions.Add(Q1);
                    //Q2
                    var A2_1 = new Answer{ AnswerContent = "Symbol", Correct = false };
                    var A2_2 = new Answer{ AnswerContent = "Scribe", Correct = false };
                    var A2_3 = new Answer{ AnswerContent = "Dictionary", Correct = true };
                    var A2_4 = new Answer{ AnswerContent = "Signature", Correct = false };
                    var A2 = new List<Answer>(){ A2_1,A2_2,A2_3,A2_4 };
                    context.Answers.AddRange(A2);
                    var Q2 = new Question{ DateCreated = DateTime.Now,  QuestionContent = "What is another word for lexicon?", Answers = A2 };
                    context.Questions.Add(Q2);
                    
                    context.Setlists.Add(
                        new Setlist{ 
                            DateCreated = DateTime.Now, 
                            Name = "Hello Setlist", 
                            Theme = "Test Theme", 
                            Questions = new List<Question>{ Q1, Q2 } 
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}