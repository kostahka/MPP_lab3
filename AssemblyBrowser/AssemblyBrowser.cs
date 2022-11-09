using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public static class AssemblyBrowser
    {
        public static TreeNode BrowseFile(string path)
        {

            var assembly = Assembly.LoadFrom(path);
            var info = new TreeGenerator(assembly.GetName().Name);

            foreach (var type in assembly.GetTypes())
            {
                var namespaceName = type.Namespace ?? "No namespace";
                info.AddType(namespaceName, type.Name);

                foreach (var f in
                      type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    info.AddItemToLastAddedType(
                          namespaceName,
                          new TreeNode(f.Name + " : " + f.FieldType),
                          ItemType.Field);
                }

                foreach (var p in
                type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    info.AddItemToLastAddedType(
                                namespaceName,
                                new TreeNode(p.Name + " : " + p.PropertyType),
                                ItemType.Property);
                }


                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var methodNode = new TreeNode(method.ReturnType + " : " + method.Name);
                    var parameters = method.GetParameters();
                    foreach (var param in parameters)
                    {
                        methodNode.AddChild(new TreeNode(param.Name + " : " + param.ParameterType));
                    }
                    info.AddItemToLastAddedType(namespaceName, methodNode, ItemType.Method);
                }

                var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var ctor in ctors)
                {
                    var ctorNode = new TreeNode(ctor.Name);
                    var parameters = ctor.GetParameters();
                    foreach (var param in parameters)
                    {
                        ctorNode.AddChild(new TreeNode(param.Name + " : " + param.ParameterType));
                    }
                    info.AddItemToLastAddedType(namespaceName, ctorNode, ItemType.Ctor);
                }
            }

            return info.ToNodes();
        }
    }
}
