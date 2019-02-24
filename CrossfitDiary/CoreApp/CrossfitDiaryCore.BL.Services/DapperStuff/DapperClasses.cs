﻿using CrossfitDiaryCore.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitDiaryCore.BL.Services.DapperStuff
{
    public class DapperResults {
        public IEnumerable<CrossfitterWorkout> CrossfitterWorkouts { get; }
        public IEnumerable<RoutineSimple> RoutineSimples { get; }
        public IEnumerable<RoutineComplex> ChildRoutines { get; }
        public IEnumerable<RoutineSimple> ChildRoutineSimples { get; }

        

        public DapperResults()
        {

        }

        public DapperResults(IEnumerable<CrossfitterWorkout> crossfitterWorkouts, IEnumerable<RoutineSimple> routineSimples, IEnumerable<RoutineComplex> routineComplex, IEnumerable<RoutineSimple> childRoutineSimples)
        {
            CrossfitterWorkouts = crossfitterWorkouts;
            RoutineSimples = routineSimples;
            ChildRoutines = routineComplex;
            ChildRoutineSimples = childRoutineSimples;
        }
    }


    public class RoutineComplexRepository
    {
        string _connectionString;
        public RoutineComplexRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ExerciseMeasure> GetAllExerciseMeasures()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT *
                            FROM [ExerciseMeasure]";
                return db.Query<ExerciseMeasure>(sql);
            }
        }

        public List<int> GetIds(int offset,int count)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<int>(@"SELECT [x].[Id]
                                        FROM [CrossfitterWorkout] AS[x]
                                        ORDER BY[x].[Date] DESC, [x].[CreatedUtc]
                                                DESC
                                        OFFSET @offset ROWS FETCH NEXT @count ROWS ONLY", new { offset, count }).ToList();
            }

            
        }

        public DapperResults GetMultiQuery(List<int> ids)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT [x].*, [x.Crossfitter].*, [x.RoutineComplex].*
                    FROM [CrossfitterWorkout] AS [x]
                    INNER JOIN [AspNetUsers] AS [x.Crossfitter] ON [x].[CrossfitterId] = [x.Crossfitter].[Id]
                    INNER JOIN [RoutineComplex] AS [x.RoutineComplex] ON [x].[RoutineComplexId] = [x.RoutineComplex].[Id]
                    WHERE [x].[Id] IN @ids; 

                    SELECT [x.RoutineComplex.RoutineSimple].*, [r.Exercise].*
                    FROM [RoutineSimple] AS [x.RoutineComplex.RoutineSimple]
                    INNER JOIN [Exercise] AS [r.Exercise] ON [x.RoutineComplex.RoutineSimple].[ExerciseId] = [r.Exercise].[Id]
                    INNER JOIN (
                        SELECT DISTINCT [x.RoutineComplex0].[Id]
                        FROM [CrossfitterWorkout] AS [x0]
                        INNER JOIN [AspNetUsers] AS [x.Crossfitter0] ON [x0].[CrossfitterId] = [x.Crossfitter0].[Id]
                        INNER JOIN [RoutineComplex] AS [x.RoutineComplex0] ON [x0].[RoutineComplexId] = [x.RoutineComplex0].[Id]
                        WHERE [x0].[Id] IN @ids
                    ) AS [t] ON [x.RoutineComplex.RoutineSimple].[RoutineComplexId] = [t].[Id];

                    SELECT [x.RoutineComplex.Children].*
                    FROM [RoutineComplex] AS [x.RoutineComplex.Children]
                    INNER JOIN (
                        SELECT DISTINCT [x.RoutineComplex2].[Id]
                        FROM [CrossfitterWorkout] AS [x2]
                        INNER JOIN [AspNetUsers] AS [x.Crossfitter2] ON [x2].[CrossfitterId] = [x.Crossfitter2].[Id]
                        INNER JOIN [RoutineComplex] AS [x.RoutineComplex2] ON [x2].[RoutineComplexId] = [x.RoutineComplex2].[Id]
                        WHERE [x2].[Id] IN @ids
                    ) AS [t2] ON [x.RoutineComplex.Children].[ParentId] = [t2].[Id];       

                    SELECT [x.RoutineComplex.Children.RoutineSimple].*, [r.Exercise1].*
                    FROM [RoutineSimple] AS [x.RoutineComplex.Children.RoutineSimple]
                    INNER JOIN [Exercise] AS [r.Exercise1] ON [x.RoutineComplex.Children.RoutineSimple].[ExerciseId] = [r.Exercise1].[Id]
                    INNER JOIN (
                        SELECT DISTINCT [x.RoutineComplex.Children0].[Id], [t3].[Id] AS [Id0]
                        FROM [RoutineComplex] AS [x.RoutineComplex.Children0]
                        INNER JOIN (
                            SELECT DISTINCT [x.RoutineComplex3].[Id]
                            FROM [CrossfitterWorkout] AS [x3]
                            INNER JOIN [AspNetUsers] AS [x.Crossfitter3] ON [x3].[CrossfitterId] = [x.Crossfitter3].[Id]
                            INNER JOIN [RoutineComplex] AS [x.RoutineComplex3] ON [x3].[RoutineComplexId] = [x.RoutineComplex3].[Id]
                            WHERE [x3].[Id] IN @ids
                        ) AS [t3] ON [x.RoutineComplex.Children0].[ParentId] = [t3].[Id]
                    ) AS [t4] ON [x.RoutineComplex.Children.RoutineSimple].[RoutineComplexId] = [t4].[Id]";
                using (var multi = db.QueryMultiple(sql, new { ids }))
                {
                    IEnumerable<CrossfitterWorkout> crossfitterWorkouts = multi.Read<CrossfitterWorkout, ApplicationUser, RoutineComplex, CrossfitterWorkout>((crossfiterWorkout, user, routine) =>
                    {
                        crossfiterWorkout.RoutineComplex = routine;
                        crossfiterWorkout.Crossfitter = user;
                        return crossfiterWorkout;
                    });

                    IEnumerable<RoutineSimple> routineSimples = multi.Read<RoutineSimple, Exercise, RoutineSimple>((routineSimple, exercise) =>
                    {
                        routineSimple.Exercise = exercise;
                        return routineSimple;
                    });

                    IEnumerable<RoutineComplex> childRoutineComplex = multi.Read<RoutineComplex>();

                    IEnumerable<RoutineSimple> childRoutineSimples = multi.Read<RoutineSimple, Exercise, RoutineSimple>((routineSimple, exercise) =>
                    {
                        routineSimple.Exercise = exercise;
                        return routineSimple;
                    });
                    return new DapperResults(crossfitterWorkouts,routineSimples, childRoutineComplex, childRoutineSimples);
                }
            }
        }

    }
}
