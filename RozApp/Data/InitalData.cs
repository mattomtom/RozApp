using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Realms;
using RozApp.Models;
using System.Linq;

namespace RozApp.Data
{
    public class InitalData
    {
        Realm realmDb;

        public InitalData()
        {
            ////Text .txt load
            //var assembly = typeof(MenuPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("RozApp.MateuszText.txt");
            //string text = "";
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    text = reader.ReadToEnd();
            //}

            //Debug.WriteLine(text);


            try
            {
                realmDb = Realm.GetInstance();
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Get instance error in RelmaDB. Exc: " + exc);
            }


            #region How to load an XML file embedded resource
            var assembly = typeof(InitalData).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("RozApp.MateuszXML.xml");

            List<UserModelXML> usersList;
            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<UserModelXML>));
                usersList = (List<UserModelXML>)serializer.Deserialize(reader);
            }
            #endregion

            List<UserModel> helpList = new List<UserModel>();

            int i = 0;
            foreach (var item in usersList)
            {
                var user = usersList.ElementAt(i);
                var helpUser = new UserModel();
                helpUser.FirstName = item.FirstName;
                helpUser.LastName = item.LastName;
                helpUser.Segment = item.Segment;
                helpUser.Year = item.Year;
                helpList.Add(helpUser);
                i++;
            }
            Debug.WriteLine(i);

            try
            {
                using (var trans = realmDb.BeginWrite())
                {
                    Debug.WriteLine("Kasujemy");
                    realmDb.RemoveAll<UserModel>();
                    trans.Commit();
                }
                realmDb.Write(() =>
                {
                    foreach (var item in helpList)
                    {
                        realmDb.Add(item);
                    }
                });
            }
            catch (Exception exc)
            {
                Debug.WriteLine("DB error. Exc: " + exc);
            }



        }
    }
}
