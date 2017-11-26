using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class Leaf<T>
    {
        public T Key { get; set; }
        public Leaf<T> Left { get; set; }
        public Leaf<T> Right { get; set; }
        public Leaf<T> Parent { get; set; }

        public Leaf(T key)
        {
            if (key == null)
                Key = default(T);
            else
                Key = key;

            Left = null;
            Right = null;
            Parent = null;
        }
    }

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Leaf<T> _root;

        public Leaf<T> Root { get { return _root; } }

        public BinarySearchTree()
        {
            _root = null;
        }

        public IEnumerable<T> InOrderTraversal(Leaf<T> root)
        {
            if (root == null)
                yield break;

            if (root.Left != null)
                foreach (var leaf in InOrderTraversal(root.Left))
                    yield return leaf;

            yield return root.Key;

            if (root.Right != null)
                foreach (var leaf in InOrderTraversal(root.Right))
                    yield return leaf;
        }

        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(_root);
        }

        public IEnumerable<T> PreOrderTraversal(Leaf<T> root)
        {
            if (root == null)
                yield break;

            yield return root.Key;

            if (root.Left != null)
                foreach (var leaf in PreOrderTraversal(root.Left))
                    yield return leaf;

            if (root.Right != null)
                foreach (var leaf in PreOrderTraversal(root.Right))
                    yield return leaf;
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(_root);
        }

        public IEnumerable<T> PostOrderTraversal(Leaf<T> root)
        {
            if (root == null)
                yield break;

            if (root.Left != null)
                foreach (var leaf in PostOrderTraversal(root.Left))
                    yield return leaf;

            if (root.Right != null)
                foreach (var leaf in PostOrderTraversal(root.Right))
                    yield return leaf;

            yield return root.Key;
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(_root);
        }

        public Leaf<T> Search(Leaf<T> root, T key)
        {
            if (root == null || key.CompareTo(root.Key) == 0)
                return root;
            else if (key.CompareTo(root.Key) == -1)
                return Search(root.Left, key);
            else
                return Search(root.Right, key);
        }

        public Leaf<T> Search(T key)
        {
            return Search(_root, key);
        }

        public Leaf<T> Minimum(Leaf<T> root)
        {
            if (root == null)
                return null;

            if (root.Left == null)
                return root;

            return Minimum(root.Left);
        }

        public Leaf<T> Minimum()
        {
            return Minimum(_root);
        }

        public Leaf<T> Maximum(Leaf<T> root)
        {
            if (root == null)
                return null;

            if (root.Right == null)
                return root;

            return Maximum(root.Right);
        }

        public Leaf<T> Maximum()
        {
            return Maximum(_root);
        }

        public void Insert(T key)
        {
            if (key == null)
                return;

            var leaf = new Leaf<T>(key);

            if (_root == null)
            {
                _root = leaf;
                return;
            }

            var x = _root;

            while (x != null)
            {
                if (leaf.Key.CompareTo(x.Key) == 1)
                {
                    if (x.Right != null)
                        x = x.Right;
                    else
                    {
                        leaf.Parent = x;
                        x.Right = leaf;
                        break;
                    }
                }
                else if (leaf.Key.CompareTo(x.Key) == -1)
                {
                    if (x.Left != null)
                        x = x.Left;
                    else
                    {
                        leaf.Parent = x;
                        x.Left = leaf;
                        break;
                    }
                }
            }
        }

        public Leaf<T> Next(Leaf<T> leaf)
        {
            if (leaf == null)
                return null;

            if (leaf.Right != null)
                return Minimum(leaf.Right);

            var x = leaf.Parent;
            while (x != null && leaf == x.Right)
            {
                leaf = x;
                x = x.Parent;
            }
            return x;
        }

        public void Delete(T key)
        {
            if (key == null)
                return;

            var leaf = Search(key);

            if (leaf == null)
                return;

            if (leaf == _root)
            {
                var n = Next(_root);

                if (n == null)
                {
                    if (_root.Left == null)
                        _root = null;
                    else
                        _root = _root.Left;

                    return;
                }

                leaf.Key = n.Key;

                var pn = n.Parent;
                n = n.Right;
                if (n != null)
                    n.Parent = pn;

                return;
            }

            var p = leaf.Parent;

            if (leaf.Left == null && leaf.Right == null)
            {
                if (p.Left == leaf)
                    p.Left = null;
                if (p.Right == leaf)
                    p.Right = null;

                return;
            }
            else if (leaf.Left == null || leaf.Right == null)
            {
                if (leaf.Left == null)
                {
                    if (p.Left == leaf)
                        p.Left = leaf.Right;
                    else
                    {
                        p.Right = leaf.Right;
                        leaf.Right.Parent = p;
                    }
                }
                else
                {
                    if (p.Left == leaf)
                        p.Left = leaf.Left;
                    else
                    {
                        p.Right = leaf.Left;
                        leaf.Left.Parent = p;
                    }
                }

                return;
            }
            else
            {
                var n = Next(leaf);

                leaf.Key = n.Key;

                var pn = n.Parent;
                n = n.Right;
                if (n != null)
                    n.Parent = pn;

                return;
            }
        }
    }
}