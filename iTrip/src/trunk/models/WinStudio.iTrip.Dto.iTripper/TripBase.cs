using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Repository;
using WinStudio.iTrip.Dto.iTripper.Snap;

namespace WinStudio.iTrip.Dto.iTripper
{
    public abstract class TripBase : Entity
    {
    }

    public abstract class FileBase : MongoFile
    { }



    public abstract class VotingBase : TripBase
    {
        public List<MongoDBRef> Voters { get; set; }

        public int Score { get; set; }

    }

    public abstract class TripNode : TripBase
    {
        public TripNode() { Children = new List<MongoDBRef>(); }

        public string ParentId { get; set; }

        public List<MongoDBRef> Children { get; set; }
    }

    public abstract class TripNode<T> : TripNode where T : TripNode
    {
        public Type ChildrenType { get { return typeof(T); } }

        public void AddChild(T child)
        {
            if (Children.Exists(c => c.Id == child.Id)) return;
            Children.Add(child.ToDBRef());
        }

        public bool ExistChild(string id)
        {
            return Children.Exists(c => c.Id == id);
        }
        public bool ExistChild(T child)
        {
            return ExistChild(child.Id);
        }
        public bool ExistChild(Expression<Func<T, bool>> expression)
        {
            return Children.RefExists(expression);
        }

        public T GetChild(string id)
        {
            return Children.RefPick<T>(id);
        }
        public List<T> GetChildren(Expression<Func<T, bool>> expression)
        {
            return Children.RefPick<T>(expression);
        }
        public List<T> GetChildren()
        {
            return Children.RefPick<T>();
        }

        public void RemoveChild(string id)
        {
            Children.RemoveAll(c => c.Id == id);
        }
        public void RemoveChildren()
        {
            Children.Clear();
        }
        public void RemoveChildren(Expression<Func<T, bool>> expression)
        {
            GetChildren(expression).ForEach(c => RemoveChild(c.Id));
        }
    }

    public abstract class TripLocationNode<T> : TripNode<T> where T : TripNode
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public SnapRefer Referral { get; set; }
    }

}
