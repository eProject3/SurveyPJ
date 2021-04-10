namespace Survey.Migrations
{
    using Survey.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [AllSurveys]");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('AllSurveys', RESEED, 0)");
            string CreateDate = "22-03-2021 07:50:00:AM";
            string UpdateDate = "22-06-2022 07:50:00:AM";

            context.Surveys.AddOrUpdate(x => x.SurveyId,
                   new AllSurvey()
                   {
                       SurveyId = 1,
                       Title = "Water Use and Conservation Survey",
                       Description = "In this theme, students will think about the way they use water on a daily basis and the impact of those habits on the environment. They will investigate the source of water they use in their community and consider different ways in which it is used.  They will think critically about using bottled water, and explore methods of conserving water as a useful resource both inside and outside.  ",
                       Status = SurveyStatus.DONE,
                       CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                       UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                   },
                    new AllSurvey()
                    {
                        SurveyId = 2,
                        Title = "Litter - Environment Survey",
                        Description = "In this theme, students will explore the impact that different kinds of household waste have on the environment and investigate solutions for reduction and disposal. They will explore and assess ways of disposing of unwanted electronic devices and discuss what to do with old batteries. They will investigate solutions to manage wastewater and think critically about solutions to reduce plastic bag waste.",
                        Status = SurveyStatus.HAPPENNING,
                        CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                        UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                    },
                     new AllSurvey()
                     {
                         SurveyId = 3,
                         Title = "Forest Fires - Environment Survey",
                         Description = "The goal of this survey is to understand student attitudes toward the causes and containment methods that may be used to minimize the damage from  fires while understanding the level of wildfire awareness, personal impact, and willingness to help fire prevention or firefighting measures.",
                         Status = SurveyStatus.HAPPENNING,
                         CreateDate = DateTime.ParseExact(CreateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),
                         UpdateDate = DateTime.ParseExact(UpdateDate, "dd-MM-yyyy hh:mm:ss:tt", CultureInfo.InvariantCulture),

                     }

                );
            context.Questions.AddOrUpdate(x => x.Id,
                   //Survey 1
                   new Question()
                   {
                       Id = 1,
                       SurveyId = 1,
                       Title = "Question 1",
                       Description = "How many individuals live in your place?",
                       Type = 1,
                   },
                 new Question()
                 {
                     Id = 2,
                     SurveyId = 1,
                     Title = "Question 2",
                     Description = "what is your current living situation?",
                     Type = 3,
                 },

                 new Question()
                 {
                     Id = 3,
                     SurveyId = 1,
                     Title = "Question 3",
                     Description = "Do you pay the water bill?",
                     Type = 0,
                 },
                 new Question()
                 {
                     Id = 4,
                     SurveyId = 1,
                     Title = "Question 4",
                     Description = "Do you have a well or any source of culinary (drinking) water other than city water?",
                     Type = 0,
                 },
                  new Question()
                  {
                      Id = 5,
                      SurveyId = 1,
                      Title = "Question 5",
                      Description = "Compared to the average person, do you think you use:",
                      Type = 1,
                  },
                   new Question()
                   {
                       Id = 6,
                       SurveyId = 1,
                       Title = "Question 6",
                       Description = "Approximately how much do you pay each month, on average, for water?",
                       Type = 1,
                   },
                    new Question()
                    {
                        Id = 7,
                        SurveyId = 1,
                        Title = "Question 7",
                        Description = "Do you know about how much you pay for water on a monthly basis in the summer? ",
                        Type = 1,
                    },
                     new Question()
                     {
                         Id = 8,
                         SurveyId = 1,
                         Title = "Question 8",
                         Description = "do you check your water meter regularly to see how much water you have used?",
                         Type = 0,
                     },
                      new Question()
                      {
                          Id = 9,
                          SurveyId = 1,
                          Title = "Question 9",
                          Description = "what is the main use of water in your living situation? ",
                          Type = 1,
                      },
                       new Question()
                       {
                           Id = 10,
                           SurveyId = 1,
                           Title = "Question 10",
                           Description = "do you currently have any water saving solutions already in your home? ",
                           Type = 0,
                       },
                        new Question()
                        {
                            Id = 11,
                            SurveyId = 1,
                            Title = "Question 11",
                            Description = "would you buy a small product for your household which could reduce your water waste?",
                            Type = 0,
                        },
                         new Question()
                         {
                             Id = 12,
                             SurveyId = 1,
                             Title = "Question 12",
                             Description = "what would the product be best used for? (related to question 11) ",
                             Type = 1,
                         },
                         //Survey 2
                         new Question()
                         {
                             Id = 13,
                             SurveyId = 2,
                             Title = "Question 1",
                             Description = "How old are you?",
                             Type = 1,
                         },
                         new Question()
                         {
                             Id = 14,
                             SurveyId = 2,
                             Title = "Question 2",
                             Description = "Which of these items would you call litter?",
                             Type = 2,
                         },
                         new Question()
                         {
                             Id = 15,
                             SurveyId = 2,
                             Title = "Question 3",
                             Description = "What is your gender?",
                             Type = 1,
                         },
                          new Question()
                          {
                              Id = 16,
                              SurveyId = 2,
                              Title = "Question 4",
                              Description = "How would you describe your school grounds?",
                              Type = 1,
                          },

                          new Question()
                          {
                              Id = 17,
                              SurveyId = 2,
                              Title = "Question 5",
                              Description = "How often do you drop litter?",
                              Type = 1,
                          },
                           new Question()
                           {
                               Id = 18,
                               SurveyId = 2,
                               Title = "Question 6",
                               Description = "If you answered 'Never' to question 5, why don't you drop litter? (Choose one or more)",
                               Type = 2,
                           },
                           new Question()
                           {
                               Id = 19,
                               SurveyId = 2,
                               Title = "Question 7",
                               Description = "If you answered 'Sometimes' or 'Often' to question 6, why do you drop litter? (Choose one or more)",
                               Type = 4,
                           },
                           new Question()
                           {
                               Id = 20,
                               SurveyId = 2,
                               Title = "Question 8",
                               Description = "Having students pick up litter at school stops them from dropping litter themselves. Do you agree or disagree with this statement?",
                               Type = 3,
                           },
                            new Question()
                            {
                                Id = 21,
                                SurveyId = 2,
                                Title = "Question 9",
                                Description = "Who do you think should pick up litter at your school? (Choose one or more)",
                                Type = 3,
                            },
                              //Survey 3
                              new Question()
                              {
                                  Id = 22,
                                  SurveyId = 3,
                                  Title = "Question 1",
                                  Description = "On a scale of 1-5, how knowledgeable are you on the causes of wildfires? - (1 - Not Knowledgeable, 5 - Expert)",
                                  Type = 1,
                              },
                                new Question()
                                {
                                    Id = 23,
                                    SurveyId = 3,
                                    Title = "Question 2",
                                    Description = "In the past year, how much risk of danger have wildfires placed on you, your home, or your place of business?",
                                    Type = 1,

                                },
                                new Question()
                                {
                                    Id = 24,
                                    SurveyId = 3,
                                    Title = "Question 3",
                                    Description = " Who has the responsibility to prevent wildfires? Check all that apply.",
                                    Type = 2,


                                },
                                 new Question()
                                 {
                                     Id = 25,
                                     SurveyId = 3,
                                     Title = "Question 4",
                                     Description = "How do you think the fire season has changed along the West Coast or in the Rocky Mountains over the past decade? Check all that apply. ",
                                     Type = 2,


                                 },

                                     new Question()
                                     {
                                         Id = 26,
                                         SurveyId = 3,
                                         Title = "Question 5",
                                         Description = "What do you think are the greatest factors contributing to wildfire outbreaks? Check all that apply. ",
                                         Type = 2,


                                     },
                                      new Question()
                                      {
                                          Id = 27,
                                          SurveyId = 3,
                                          Title = "Question 6",
                                          Description = "Which of the following changes do you think would help fight wildfires? Check all that apply.  ",
                                          Type = 2,


                                      },
                                       new Question()
                                       {
                                           Id = 28,
                                           SurveyId = 3,
                                           Title = "Question 7",
                                           Description = "Have there been any recent education programs in your county or state for  teaching fire prevention or firefighting methods?  ",
                                           Type = 0,


                                       },
                                         new Question()
                                         {
                                             Id = 29,
                                             SurveyId = 3,
                                             Title = "Question 8",
                                             Description = "Have you personally seen a wildfire? Select all that applies.",
                                             Type = 2,


                                         },
                                           new Question()
                                           {
                                               Id = 30,
                                               SurveyId = 3,
                                               Title = "Question 9",
                                               Description = "Are you currently prepared to evacuate a wildfire?",
                                               Type = 1,


                                           },
                                              new Question()
                                              {
                                                  Id = 31,
                                                  SurveyId = 3,
                                                  Title = "Question 10",
                                                  Description = "Do you or a family member live in a state that has been affected by wildfire smoke that has caused the air quality index to meet or exceed unhealthy conditions this year?",
                                                  Type = 0,


                                              }


                );
            context.Question_answers.AddOrUpdate(x => x.QuestionAnswerId,
                //Survey 1
                new QuestionAnswer()
                {
                    QuestionId = 1,
                    QuestionAnswerId = 1,
                    Answer = "1",
                },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 2,
                      Answer = "2",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 3,
                      Answer = "3",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 4,
                      Answer = "4",
                  },
                  new QuestionAnswer()
                  {
                      QuestionId = 1,
                      QuestionAnswerId = 5,
                      Answer = "more than that",
                  },
                    new QuestionAnswer()
                    {
                        QuestionId = 2,
                        QuestionAnswerId = 6,
                        Answer = "House",
                    },
                      new QuestionAnswer()
                      {
                          QuestionId = 2,
                          QuestionAnswerId = 7,
                          Answer = "Student Living",
                      },
                        new QuestionAnswer()
                        {
                            QuestionId = 2,
                            QuestionAnswerId = 8,
                            Answer = "flat",
                        },
                        new QuestionAnswer()
                        {
                            QuestionId = 2,
                            QuestionAnswerId = 8,
                            Answer = "other",
                        },
                             new QuestionAnswer()
                             {
                                 QuestionId = 3,
                                 QuestionAnswerId = 8,
                                 Answer = "Yes",
                             },
                              new QuestionAnswer()
                              {
                                  QuestionId = 3,
                                  QuestionAnswerId = 9,
                                  Answer = "No",
                              },
                                    new QuestionAnswer()
                                    {
                                        QuestionId = 4,
                                        QuestionAnswerId = 10,
                                        Answer = "Yes",
                                    },
                              new QuestionAnswer()
                              {
                                  QuestionId = 4,
                                  QuestionAnswerId = 11,
                                  Answer = "No",
                              },
                                new QuestionAnswer()
                                {
                                    QuestionId = 5,
                                    QuestionAnswerId = 12,
                                    Answer = "More water than average",
                                },
                              new QuestionAnswer()
                              {
                                  QuestionId = 5,
                                  QuestionAnswerId = 13,
                                  Answer = "About average",
                              },
                                new QuestionAnswer()
                                {
                                    QuestionId = 5,
                                    QuestionAnswerId = 14,
                                    Answer = "Less water than average",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 6,
                                     QuestionAnswerId = 15,
                                     Answer = "Don't Know",
                                 },
                                new QuestionAnswer()
                                {
                                    QuestionId = 6,
                                    QuestionAnswerId = 16,
                                    Answer = "$0-$30",
                                },
                                new QuestionAnswer()
                                {
                                    QuestionId = 6,
                                    QuestionAnswerId = 16,
                                    Answer = "$30-$50",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 6,
                                     QuestionAnswerId = 16,
                                     Answer = "$50-$100",
                                 },
                                   new QuestionAnswer()
                                   {
                                       QuestionId = 6,
                                       QuestionAnswerId = 16,
                                       Answer = "More than $100",
                                   },
                                      new QuestionAnswer()
                                      {
                                          QuestionId = 6,
                                          QuestionAnswerId = 16,
                                          Answer = "$0-$30",
                                      },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 7,
                                           QuestionAnswerId = 17,
                                           Answer = "Don't Know",
                                       },
                                new QuestionAnswer()
                                {
                                    QuestionId = 7,
                                    QuestionAnswerId = 18,
                                    Answer = "$30-$50",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 7,
                                     QuestionAnswerId = 19,
                                     Answer = "$50-$100",
                                 },
                                   new QuestionAnswer()
                                   {
                                       QuestionId = 7,
                                       QuestionAnswerId = 20,
                                       Answer = "More than $100",
                                   },


                              new QuestionAnswer()
                              {
                                  QuestionId = 8,
                                  QuestionAnswerId = 21,
                                  Answer = "Yes",
                              },
                                new QuestionAnswer()
                                {
                                    QuestionId = 8,
                                    QuestionAnswerId = 22,
                                    Answer = "No",
                                },
                                  new QuestionAnswer()
                                  {
                                      QuestionId = 9,
                                      QuestionAnswerId = 23,
                                      Answer = "cooking",
                                  },
                                new QuestionAnswer()
                                {
                                    QuestionId = 9,
                                    QuestionAnswerId = 24,
                                    Answer = "bathing",
                                },
                                 new QuestionAnswer()
                                 {
                                     QuestionId = 9,
                                     QuestionAnswerId = 25,
                                     Answer = "washing (washing machine, dishwasher)",
                                 },
                                  new QuestionAnswer()
                                  {
                                      QuestionId = 9,
                                      QuestionAnswerId = 26,
                                      Answer = "drinking",
                                  },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 9,
                                         QuestionAnswerId = 26,
                                         Answer = "Other (please specify)",
                                     },
                                      new QuestionAnswer()
                                      {
                                          QuestionId = 10,
                                          QuestionAnswerId = 27,
                                          Answer = "Yes",
                                      },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 10,
                                         QuestionAnswerId = 28,
                                         Answer = "No",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 11,
                                           QuestionAnswerId = 29,
                                           Answer = "Yes",
                                       },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 11,
                                         QuestionAnswerId = 30,
                                         Answer = "No",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 31,
                                           Answer = "cooking",
                                       },
                                     new QuestionAnswer()
                                     {
                                         QuestionId = 12,
                                         QuestionAnswerId = 32,
                                         Answer = "washing (showering, brushing teeth etc)",
                                     },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 33,
                                           Answer = "cleaning (dishes, clothes etc)",

                                       },
                                       new QuestionAnswer()
                                       {
                                           QuestionId = 12,
                                           QuestionAnswerId = 34,
                                           Answer = "Other",

                                       },
                                        //Survey 2 
                                        new QuestionAnswer()
                                        {
                                            QuestionId = 13,
                                            QuestionAnswerId = 35,
                                            Answer = "15+",

                                        },
                                         new QuestionAnswer()
                                         {
                                             QuestionId = 13,
                                             QuestionAnswerId = 36,
                                             Answer = "16+",

                                         },
                                          new QuestionAnswer()
                                          {
                                              QuestionId = 13,
                                              QuestionAnswerId = 37,
                                              Answer = "17+",

                                          },
                                           new QuestionAnswer()
                                           {
                                               QuestionId = 13,
                                               QuestionAnswerId = 38,
                                               Answer = "18+",

                                           },
                                            new QuestionAnswer()
                                            {
                                                QuestionId = 14,
                                                QuestionAnswerId = 39,
                                                Answer = "Lunch Wrappers",

                                            },
                                              new QuestionAnswer()
                                              {
                                                  QuestionId = 14,
                                                  QuestionAnswerId = 40,
                                                  Answer = "Cigarette Ends",

                                              },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 14,
                                                    QuestionAnswerId = 41,
                                                    Answer = "Food Scraps",

                                                },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 14,
                                                    QuestionAnswerId = 41,
                                                    Answer = "Fallen Leaves and Twigs",

                                                },
                                                 new QuestionAnswer()
                                                 {
                                                     QuestionId = 14,
                                                     QuestionAnswerId = 41,
                                                     Answer = "Drink Bottles and Cans",

                                                 },
                                                   new QuestionAnswer()
                                                   {
                                                       QuestionId = 14,
                                                       QuestionAnswerId = 42,
                                                       Answer = "An Old Car in a Field",

                                                   },
                                                     new QuestionAnswer()
                                                     {
                                                         QuestionId = 15,
                                                         QuestionAnswerId = 43,
                                                         Answer = "Female",

                                                     },
                                                       new QuestionAnswer()
                                                       {
                                                           QuestionId = 15,
                                                           QuestionAnswerId = 44,
                                                           Answer = "Male",

                                                       },
                                                        new QuestionAnswer()
                                                        {
                                                            QuestionId = 16,
                                                            QuestionAnswerId = 44,
                                                            Answer = " Heavily littered",

                                                        },
                                                         new QuestionAnswer()
                                                         {
                                                             QuestionId = 16,
                                                             QuestionAnswerId = 45,
                                                             Answer = "Slightly littered",

                                                         },
                                                          new QuestionAnswer()
                                                          {
                                                              QuestionId = 16,
                                                              QuestionAnswerId = 46,
                                                              Answer = "Not littered",

                                                          },
                                                           new QuestionAnswer()
                                                           {
                                                               QuestionId = 17,
                                                               QuestionAnswerId = 47,
                                                               Answer = "Often (go to question 7)",

                                                           },
                                                            new QuestionAnswer()
                                                            {
                                                                QuestionId = 17,
                                                                QuestionAnswerId = 48,
                                                                Answer = "Sometimes(go to question 7)",

                                                            },
                                                             new QuestionAnswer()
                                                             {
                                                                 QuestionId = 17,
                                                                 QuestionAnswerId = 49,
                                                                 Answer = "Never(go to question 6)",

                                                             },
                                                               new QuestionAnswer()
                                                               {
                                                                   QuestionId = 18,
                                                                   QuestionAnswerId = 50,
                                                                   Answer = "I think that litter spoils the appearance of a place.",

                                                               },
                                                               new QuestionAnswer()
                                                               {
                                                                   QuestionId = 18,
                                                                   QuestionAnswerId = 51,
                                                                   Answer = "I am afraid of being caught and punished.",

                                                               },
                                                                new QuestionAnswer()
                                                                {
                                                                    QuestionId = 18,
                                                                    QuestionAnswerId = 52,
                                                                    Answer = "I know it's wrong.",

                                                                },
                                                                  new QuestionAnswer()
                                                                  {
                                                                      QuestionId = 18,
                                                                      QuestionAnswerId = 53,
                                                                      Answer = "I know that animals can be hurt or killed by litter.",

                                                                  },
                                                                   new QuestionAnswer()
                                                                   {
                                                                       QuestionId = 18,
                                                                       QuestionAnswerId = 54,
                                                                       Answer = "I am worried that people will be hurt by litter.",

                                                                   },
                                                                    new QuestionAnswer()
                                                                    {
                                                                        QuestionId = 18,
                                                                        QuestionAnswerId = 55,
                                                                        Answer = "I am worried that it will be washed into rivers, streams, and the ocean.",

                                                                    },
                                                                       new QuestionAnswer()
                                                                       {
                                                                           QuestionId = 19,
                                                                           QuestionAnswerId = 56,
                                                                           Answer = "Essey",

                                                                       },
                                                                       
                                                                                       new QuestionAnswer()
                                                                                       {
                                                                                           QuestionId = 20,
                                                                                           QuestionAnswerId = 64,
                                                                                           Answer = "Agree",

                                                                                       },
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 20,
                                                                                              QuestionAnswerId = 1000,
                                                                                              Answer = "Disagree",

                                                                                          },
                                                                                           new QuestionAnswer()
                                                                                           {
                                                                                               QuestionId = 20,
                                                                                               QuestionAnswerId = 65,
                                                                                               Answer = "Other",

                                                                                           },
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 21,
                                                                                              QuestionAnswerId = 66,
                                                                                              Answer = "Students caught dropping litter ",

                                                                                          },
                                                                                          new QuestionAnswer()
                                                                                          {
                                                                                              QuestionId = 21,
                                                                                              QuestionAnswerId = 67,
                                                                                              Answer = "All students",

                                                                                          },
                                                                                           new QuestionAnswer()
                                                                                           {
                                                                                               QuestionId = 21,
                                                                                               QuestionAnswerId = 68,
                                                                                               Answer = "Teachers",

                                                                                           },
                                                                                            new QuestionAnswer()
                                                                                            {
                                                                                                QuestionId = 21,
                                                                                                QuestionAnswerId = 69,
                                                                                                Answer = "Custodians",

                                                                                            },
                                                                                             new QuestionAnswer()
                                                                                             {
                                                                                                 QuestionId = 21,
                                                                                                 QuestionAnswerId = 70,
                                                                                                 Answer = "Other",

                                                                                             },
                                                                                              //Survey 3     
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 70,
                                                                                                  Answer = "1",

                                                                                              },
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 71,
                                                                                                  Answer = "2",

                                                                                              },
                                                                                              new QuestionAnswer()
                                                                                              {
                                                                                                  QuestionId = 22,
                                                                                                  QuestionAnswerId = 72,
                                                                                                  Answer = "3",

                                                                                              },
                                                                                                new QuestionAnswer()
                                                                                                {
                                                                                                    QuestionId = 22,
                                                                                                    QuestionAnswerId = 73,
                                                                                                    Answer = "4",

                                                                                                },
                                                                                                  new QuestionAnswer()
                                                                                                  {
                                                                                                      QuestionId = 22,
                                                                                                      QuestionAnswerId = 74,
                                                                                                      Answer = "5",

                                                                                                  },
                                                                                                    new QuestionAnswer()
                                                                                                    {
                                                                                                        QuestionId = 23,
                                                                                                        QuestionAnswerId = 75,
                                                                                                        Answer = "No Risk",

                                                                                                    },
                                                                                                      new QuestionAnswer()
                                                                                                      {
                                                                                                          QuestionId = 23,
                                                                                                          QuestionAnswerId = 76,
                                                                                                          Answer = "Slight Risk",

                                                                                                      },
                                                                                                       new QuestionAnswer()
                                                                                                       {
                                                                                                           QuestionId = 23,
                                                                                                           QuestionAnswerId = 77,
                                                                                                           Answer = "Moderate Risk",

                                                                                                       },
                                                                                                        new QuestionAnswer()
                                                                                                        {
                                                                                                            QuestionId = 23,
                                                                                                            QuestionAnswerId = 78,
                                                                                                            Answer = "Great Risk",

                                                                                                        },
                                                                                                         new QuestionAnswer()
                                                                                                         {
                                                                                                             QuestionId = 23,
                                                                                                             QuestionAnswerId = 79,
                                                                                                             Answer = "Extreme Risk",

                                                                                                         },
                                                                                                         new QuestionAnswer()
                                                                                                         {
                                                                                                             QuestionId = 24,
                                                                                                             QuestionAnswerId = 80,
                                                                                                             Answer = "The Forest Service",

                                                                                                         },
                                                                                                          new QuestionAnswer()
                                                                                                          {
                                                                                                              QuestionId = 24,
                                                                                                              QuestionAnswerId = 81,
                                                                                                              Answer = "The National Government",

                                                                                                          },
                                                                                                           new QuestionAnswer()
                                                                                                           {
                                                                                                               QuestionId = 24,
                                                                                                               QuestionAnswerId = 82,
                                                                                                               Answer = "The Forest Service",

                                                                                                           },
                                                                                                            new QuestionAnswer()
                                                                                                            {
                                                                                                                QuestionId = 24,
                                                                                                                QuestionAnswerId = 83,
                                                                                                                Answer = "The State Government ",

                                                                                                            },
                                                                                                             new QuestionAnswer()
                                                                                                             {
                                                                                                                 QuestionId = 24,
                                                                                                                 QuestionAnswerId = 84,
                                                                                                                 Answer = "The Public",

                                                                                                             },
                                                                                                              new QuestionAnswer()
                                                                                                              {
                                                                                                                  QuestionId = 24,
                                                                                                                  QuestionAnswerId = 85,
                                                                                                                  Answer = "Private Property Owners",

                                                                                                              },
                                                                                                                 new QuestionAnswer()
                                                                                                                 {
                                                                                                                     QuestionId = 24,
                                                                                                                     QuestionAnswerId = 85,
                                                                                                                     Answer = "Local Fire Departments",

                                                                                                                 },
                                                                                                                  new QuestionAnswer()
                                                                                                                  {
                                                                                                                      QuestionId = 24,
                                                                                                                      QuestionAnswerId = 86,
                                                                                                                      Answer = "State Conservation Department",

                                                                                                                  },
                                                                                                                       new QuestionAnswer()
                                                                                                                       {
                                                                                                                           QuestionId = 25,
                                                                                                                           QuestionAnswerId = 87,
                                                                                                                           Answer = "Longer Fire Season",


                                                                                                                       },
                                                                                                                            new QuestionAnswer()
                                                                                                                            {
                                                                                                                                QuestionId = 25,
                                                                                                                                QuestionAnswerId = 88,
                                                                                                                                Answer = "Greater Number of Wildfires",


                                                                                                                            },
                                                                                                                                 new QuestionAnswer()
                                                                                                                                 {
                                                                                                                                     QuestionId = 25,
                                                                                                                                     QuestionAnswerId = 89,
                                                                                                                                     Answer = "Bigger or More Dangerous Fires",


                                                                                                                                 },
                                                                                                                                  new QuestionAnswer()
                                                                                                                                  {
                                                                                                                                      QuestionId = 25,
                                                                                                                                      QuestionAnswerId = 90,
                                                                                                                                      Answer = "Greater Property Damage",


                                                                                                                                  },
                                                                                                                                   new QuestionAnswer()
                                                                                                                                   {
                                                                                                                                       QuestionId = 25,
                                                                                                                                       QuestionAnswerId = 91,
                                                                                                                                       Answer = "More Media Coverage of Fire Season",


                                                                                                                                   },
                                                                                                                                    new QuestionAnswer()
                                                                                                                                    {
                                                                                                                                        QuestionId = 25,
                                                                                                                                        QuestionAnswerId = 92,
                                                                                                                                        Answer = "No Change In Fire Season",


                                                                                                                                    },
                                                                                                                                     new QuestionAnswer()
                                                                                                                                     {
                                                                                                                                         QuestionId = 25,
                                                                                                                                         QuestionAnswerId = 93,
                                                                                                                                         Answer = "Don't Know/Not Sure",


                                                                                                                                     },

                                                                                                                                         new QuestionAnswer()
                                                                                                                                         {
                                                                                                                                             QuestionId = 26,
                                                                                                                                             QuestionAnswerId = 94,
                                                                                                                                             Answer = "Climate Change",
                                                                                                                                         },
                                                                                                                                           new QuestionAnswer()
                                                                                                                                           {
                                                                                                                                               QuestionId = 26,
                                                                                                                                               QuestionAnswerId = 95,
                                                                                                                                               Answer = "Poor Forest Management",
                                                                                                                                           },

                                                                                                                                             new QuestionAnswer()
                                                                                                                                             {
                                                                                                                                                 QuestionId = 26,
                                                                                                                                                 QuestionAnswerId = 96,
                                                                                                                                                 Answer = "Urban Expansion",
                                                                                                                                             },
                                                                                                                                              new QuestionAnswer()
                                                                                                                                              {
                                                                                                                                                  QuestionId = 26,
                                                                                                                                                  QuestionAnswerId = 97,
                                                                                                                                                  Answer = "Drought",
                                                                                                                                              },
                                                                                                                                               new QuestionAnswer()
                                                                                                                                               {
                                                                                                                                                   QuestionId = 26,
                                                                                                                                                   QuestionAnswerId = 98,
                                                                                                                                                   Answer = "High Winds",
                                                                                                                                               },
                                                                                                                                               new QuestionAnswer()
                                                                                                                                               {
                                                                                                                                                   QuestionId = 27,
                                                                                                                                                   QuestionAnswerId = 98,
                                                                                                                                                   Answer = "Increasing Funding to Local Firefighters",
                                                                                                                                               },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 99,
                                                                                                                                                     Answer = "Constructing More Dams and Reservoirs to Build A Ready Supply of Water",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 100,
                                                                                                                                                     Answer = "Taxing Carbon Polluters and Creating Carbon Offsets to Reduce Global Warming",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 101,
                                                                                                                                                     Answer = "Redesigning City Infrastructure to Slow the Spread of Wildfires in Urban Areas",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 102,
                                                                                                                                                     Answer = "Controlled Burning and Removal of Dead Brush and Trees",
                                                                                                                                                 },
                                                                                                                                                 new QuestionAnswer()
                                                                                                                                                 {
                                                                                                                                                     QuestionId = 27,
                                                                                                                                                     QuestionAnswerId = 103,
                                                                                                                                                     Answer = "Greater Efforts at Public Education on Fire Safety and Wildfire Prevention",
                                                                                                                                                 },
                                                                                                                                                   new QuestionAnswer()
                                                                                                                                                   {
                                                                                                                                                       QuestionId = 28,
                                                                                                                                                       QuestionAnswerId = 104,
                                                                                                                                                       Answer = "Yes",
                                                                                                                                                   },
                                                                                                                                                     new QuestionAnswer()
                                                                                                                                                     {
                                                                                                                                                         QuestionId = 28,
                                                                                                                                                         QuestionAnswerId = 105,
                                                                                                                                                         Answer = "No",
                                                                                                                                                     },

                                                                                                                                                       new QuestionAnswer()
                                                                                                                                                       {
                                                                                                                                                           QuestionId = 29,
                                                                                                                                                           QuestionAnswerId = 106,
                                                                                                                                                           Answer = "I have seen a wildfire on the news or through media. ",
                                                                                                                                                       },

                                                                                                                                                         new QuestionAnswer()
                                                                                                                                                         {
                                                                                                                                                             QuestionId = 29,
                                                                                                                                                             QuestionAnswerId = 107,
                                                                                                                                                             Answer = "I have seen a red, orange, or yellow glow in the sky from a close wildfire. ",
                                                                                                                                                         },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 108,
                                                                                                                                                               Answer = "I have seen wildfire flames in person.",
                                                                                                                                                           },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 109,
                                                                                                                                                               Answer = "I have not seen a wildfire. ",
                                                                                                                                                           },

                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 29,
                                                                                                                                                               QuestionAnswerId = 110,
                                                                                                                                                               Answer = "Don't Know/Unsure",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 111,
                                                                                                                                                               Answer = "I am prepared to evacuate.",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 112,
                                                                                                                                                               Answer = "I am somewhat prepared to evacuate.",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 30,
                                                                                                                                                               QuestionAnswerId = 113,
                                                                                                                                                               Answer = "I am not prepared to evacuate.",
                                                                                                                                                           },


                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 31,
                                                                                                                                                               QuestionAnswerId = 114,
                                                                                                                                                               Answer = "Yes",
                                                                                                                                                           },
                                                                                                                                                           new QuestionAnswer()
                                                                                                                                                           {
                                                                                                                                                               QuestionId = 31,
                                                                                                                                                               QuestionAnswerId = 115,
                                                                                                                                                               Answer = "No",
                                                                                                                                                           }
                                                                                             );
        }
    }
}