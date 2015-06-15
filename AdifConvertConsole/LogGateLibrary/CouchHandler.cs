using Adiflib;
using MyCouch;
using MyCouch.Requests;
using MyCouch.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Shows.Infrastructure
{
    public class CouchDbHandler
    {
        public const string LogGateUrl = "http://wa1gon:kb1etc@localhost:5984/loggate";
        static public SortedList<string, Qso> GetQsos()
        {
            Qso qso;

            var retContext = new SortedList<string, Qso>();
            using (var client = new MyCouchClient(LogGateUrl))
            {

                var jspecQuery = new QueryViewRequest("Docs", "Doctype")
                    .Configure(query => query
                    .Reduce(false).Key("Qso").Descending(true).IncludeDocs(true));

                ViewQueryResponse<string> result = client.Views.QueryAsync<string>(jspecQuery).Result;


                foreach (var row in result.Rows)
                {
                    if (row == null)
                    {
                        continue;
                    }
                    qso = JsonConvert.DeserializeObject<Qso>(row.IncludedDoc);
                    retContext.Add(qso.GetCallSign(), qso);

                }
                return retContext;
            }
        }

        static public bool SaveQSO(Qso qso)
        {
            using (var client = new MyCouchClient(LogGateUrl))
            {
                //var dbClip = GetQso(qso._id);
                //if (dbClip != null && qso != null)
                //{
                //    if (dbClip._rev != qso._rev)
                //    {
                //        qso.Merge(dbClip);
                //    }
                //}

                if (string.IsNullOrWhiteSpace(qso._id))
                {
                    qso._id = Guid.NewGuid().ToString();
                }

                var put = client.Entities.PutAsync<Qso>(qso).Result;
                qso._rev = put.Content._rev;
                if (put.Error == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //static public List<MasterClass> GetMasterClasses()
        //{
        //    MasterClass mClass;

        //    var retContext = new List<MasterClass>();
        //    using (var client = new MyCouchClient(ShowsUrl))
        //    {

        //        var masterClassQuery = new QueryViewRequest("Docs", "Doctype").
        //            Configure(query => query
        //            .Reduce(false).Key("MasterClass").Descending(true).IncludeDocs(true));

        //        ViewQueryResponse<string> result = client.Views.QueryAsync<string>(masterClassQuery).Result;


        //        foreach (var row in result.Rows)
        //        {
        //            if (row == null)
        //            {
        //                continue;
        //            }
        //            mClass = JsonConvert.DeserializeObject<MasterClass>(row.IncludedDoc);
        //            retContext.Add(mClass);

        //        }
        //        return retContext;
        //    }
        //}
        //static public RoamingContext Next100(int currentCursor)
        //{
        //    bool rep = Replicate();

        //    Clip clip;
        //    RoamingContext retContext = new RoamingContext();
        //    using (var client = new MyCouchClient(ShowsUrl))
        //    {

        //        var clipquery = new QueryViewRequest("dates", "sorted").
        //            Configure(query => query
        //            .Reduce(false).Limit(100).Skip(currentCursor).Descending(true).IncludeDocs(true));

        //        ViewQueryResponse<string> result = client.Views.QueryAsync<string>(clipquery).Result;


        //        foreach (var row in result.Rows)
        //        {
        //            if (row == null)
        //            {
        //                continue;
        //            }
        //            clip = JsonConvert.DeserializeObject<Clip>(row.IncludedDoc);
        //            retContext.Clips.Add(clip);

        //        }

        //        Console.WriteLine(result);
        //        return retContext;

        //    }
        //}

        private async Task<ViewQueryResponse<string>> Query(MyCouchClient client, QueryViewRequest clipquery)
        {
            ViewQueryResponse<string> result = await client.Views.QueryAsync<string>(clipquery);
            return result;
        }

        //static public bool SaveJudgesSpec(JudgesSpecs jspec)
        //{
        //    using (var client = new MyCouchClient(ShowsUrl))
        //    {
        //        var dbClip = GetJudgesSpec(jspec._id);
        //        if (dbClip != null && jspec != null)
        //        {
        //            if (dbClip._rev != jspec._rev)
        //            {
        //                jspec.Merge(dbClip);
        //            }
        //        }
        //        var put = client.Entities.PutAsync<JudgesSpecs>(jspec).Result;
        //        jspec._rev = put.Content._rev;
        //        if (put.Error == null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //static public bool SaveMasterClass(MasterClass mClass)
        //{
        //    using (var client = new MyCouchClient(ShowsUrl))
        //    {
        //        var dbClip = GetJudgesSpec(mClass._id);
        //        if (dbClip != null && mClass != null)
        //        {
        //            if (dbClip._rev != mClass._rev)
        //            {
        //                mClass.Merge(dbClip);
        //            }
        //        }
        //        var put = client.Entities.PutAsync<MasterClass>(mClass).Result;
        //        mClass._rev = put.Content._rev;
        //        if (put.Error == null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //static public bool SaveAssocation(Association mClass)
        //{
        //    using (var client = new MyCouchClient(ShowsUrl))
        //    {
        //        var dbClip = GetAssociation(mClass._id);
        //        if (dbClip != null && mClass != null)
        //        {
        //            if (dbClip._rev != mClass._rev)
        //            {
        //                mClass.Merge(dbClip);
        //            }
        //        }
        //        var put = client.Entities.PutAsync<Association>(mClass).Result;
        //        mClass._rev = put.Content._rev;
        //        if (put.Error == null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //static public List<JudgesSpecs> GetAllJudgesSpec()
        //{


        //    List<JudgesSpecs> jspecList = new List<JudgesSpecs>();
        //    using (var client = new MyCouchClient("http://localhost:5984/shows"))
        //    {

        //        var jspecquery = new QueryViewRequest("TypeSearch", "SearchForType").
        //            Configure(query => query.Key("JudgesSpecs")
        //            .Reduce(false).IncludeDocs(true));

        //        ViewQueryResponse<string> result = client.Views.QueryAsync<string>(jspecquery).Result;

        //        JudgesSpecs jspec;

        //        foreach (var row in result.Rows)
        //        {
        //            if (row == null)
        //            {
        //                continue;
        //            }
        //            jspec = JsonConvert.DeserializeObject<JudgesSpecs>(row.IncludedDoc);
        //            jspecList.Add(jspec);

        //        }

        //        Console.WriteLine(result);
        //        return jspecList;

        //    }
        //}
        //static public List<Association> GetAllAssoc()
        //{


        //    List<Association> assoList = new List<Association>();
        //    using (var client = new MyCouchClient("http://localhost:5984/shows"))
        //    {

        //        var jspecquery = new QueryViewRequest("TypeSearch", "SearchForType").
        //            Configure(query => query.Key("Association")
        //            .Reduce(false).IncludeDocs(true));

        //        ViewQueryResponse<string> result = client.Views.QueryAsync<string>(jspecquery).Result;

        //        Association assoc;

        //        foreach (var row in result.Rows)
        //        {
        //            if (row == null)
        //            {
        //                continue;
        //            }
        //            assoc = JsonConvert.DeserializeObject<Association>(row.IncludedDoc);
        //            assoList.Add(assoc);

        //        }

        //        Console.WriteLine(result);
        //        return assoList;

        //    }
        //}
        //static public dynamic GetJudgesSpec(string jspecId)
        //{
        //    using (var client = new MyCouchStore(ShowsUrl))
        //    {
        //        dynamic clip = client.GetByIdAsync<JudgesSpecs>(jspecId).Result;
        //        return clip;
        //    }
        //}
        //static public dynamic GetAssociation(string assoId)
        //{
        //    using (var client = new MyCouchStore(ShowsUrl))
        //    {
        //        dynamic asso = client.GetByIdAsync<Association>(assoId).Result;
        //        return asso;
        //    }
        //}
        //static public bool Replicate()
        //{
        //    using (var client = new MyCouchServerClient("http://wa1gon:kb1etc@localhost:5984"))
        //    {
        //        var id = Guid.NewGuid().ToString("n");
        //        var localToRemote = client.Replicator.ReplicateAsync(id, "talkjunky", "https://talkjunky:kb1etc73@db.talkjunky.com/talkjunky").Result;

        //        id = Guid.NewGuid().ToString("n");
        //        var remoteToLocal = client.Replicator.ReplicateAsync(id, "https://talkjunky:kb1etc73@db.talkjunky.com/talkjunky", "talkjunky").Result;
        //        Task.WaitAll();
        //    }
        //    return true;
        //}

    }
}


