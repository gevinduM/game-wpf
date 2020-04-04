using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TrueOrFalse
{
    public class Persistence
    {
        public string FilePath { get; set; }
        public List<Statement> Statements { get; private set; } = new List<Statement>();

        public Persistence() { }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void Add(Statement q)
        {
            Statements.Add(q);
        }

        public void Remove(int index)
        {
            Statements.RemoveAt(index);
        }

        public Statement this[int index] => Statements[index];

        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Statement>));
            Stream fStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, Statements);
            fStream.Close();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Statement>));
            Stream fStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            Statements = (List<Statement>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        public int Count => Statements.Count;

        public void Change(int index, Statement statement)
        {
            Statements[index] = statement;
        }

        public bool Exists(int index)
        {
            return Count > index;
        }
    }
}