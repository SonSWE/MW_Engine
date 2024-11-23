using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace DapperLib.LinQToSql.Core
{
    public class ExpressionUtil : ExpressionVisitor
    {
        #region propertys
        private StringBuilder _build = new StringBuilder();
        private Dictionary<string, object> _param { get; set; } = new();
        private string _paramName = "Name";
        private string _operatorMethod { get; set; } = string.Empty;
        private string _operator { get; set; } = string.Empty;
        private bool _singleTable { get; set; }
        #endregion

        #region override
        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null && node.Expression.NodeType == ExpressionType.Parameter)
            {
                SetName(node);
            }
            else
            {
                SetValue(node);
            }
            return node;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(Operator))
            {
                _build.Append("(");
                if (node.Arguments.Count == 1)
                {
                    Visit(node.Arguments[0]);
                    _build.AppendFormat(" {0} ", Operator.GetOperator(node.Method.Name));
                }
                else if (node.Arguments.Count == 2)
                {
                    Visit(node.Arguments[0]);
                    _operator = Operator.GetOperator(node.Method.Name);
                    _operatorMethod = node.Method.Name;
                    _build.AppendFormat(" {0} ", _operator);
                    Visit(node.Arguments[1]);
                }
                else
                {
                    _operator = Operator.GetOperator(node.Method.Name);
                    Visit(node.Arguments[0]);
                    _build.AppendFormat(" {0} ", _operator);
                    Visit(node.Arguments[1]);
                    _build.AppendFormat(" {0} ", Operator.GetOperator(ExpressionType.AndAlso));
                    Visit(node.Arguments[2]);
                }
                _build.Append(")");
            }
            else if (node.Method.GetCustomAttributes(typeof(FunctionAttribute), true).Length > 0)
            {
                _build.AppendFormat("{0}(", node.Method.Name.ToUpper());
                var parameters = node.Method.GetParameters();
                for (int i = 0; i < node.Arguments.Count; i++)
                {
                    if (parameters[i].GetCustomAttributes(typeof(ParameterAttribute), true).Length > 0)
                    {
                        _build.Append((node.Arguments[i] as ConstantExpression)?.Value);
                        continue;
                    }
                    Visit(node.Arguments[i]);
                    if (i + 1 != node.Arguments.Count)
                    {
                        _build.Append(",");
                    }
                }
                _build.Append(")");
            }
            else
            {
                SetValue(node);
            }
            return node;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            _build.Append("(");
            Visit(node.Left);
            if (node.Right is ConstantExpression && (node.NodeType == ExpressionType.Equal || node.NodeType == ExpressionType.NotEqual) && (node.Right as ConstantExpression)?.Value == null)
            {
                _operator = node.NodeType == ExpressionType.Equal ? Operator.GetOperator(nameof(Operator.IsNull)) : Operator.GetOperator(nameof(Operator.IsNotNull));
                _build.AppendFormat(" {0}", _operator);
            }
            else
            {
                _operator = Operator.GetOperator(node.NodeType);
                _build.AppendFormat(" {0} ", _operator);
                Visit(node.Right);
            }
            _build.Append(")");
            return node;
        }
        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            SetValue(node);
            return node;
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Not)
            {
                _build.AppendFormat("{0}", Operator.GetOperator(ExpressionType.Not));
            }
            Visit(node.Operand);
            return node;
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value == null)
            {
                _build.AppendFormat("NULL");
            }
            else if (_operator == "LIKE" || _operator == "NOT LIKE")
            {
                if (_operatorMethod == nameof(Operator.LikeLeft) || _operatorMethod == nameof(Operator.NotLikeLeft))
                {
                    _build.AppendFormat("'%{0}'", node.Value);
                }
                else if (_operatorMethod == nameof(Operator.NotLikeRight) || _operatorMethod == nameof(Operator.LikeRight))
                {
                    _build.AppendFormat("'{0}%'", node.Value);
                }
                else
                {
                    _build.AppendFormat("'%{0}%'", node.Value);
                }
            }
            else if (node.Value is string)
            {
                _build.AppendFormat("'{0}'", node.Value);
            }
            else
            {
                _build.AppendFormat("{0}", node.Value);
            }
            return node;
        }
        #endregion

        #region private
        public void SetName(MemberExpression expression)
        {
            var name = expression.Member.Name;
            var type = expression.Expression?.Type;
            if (type == null) return;
            var columnName = EntityUtil.GetColumn(type, f => f.CSharpName == name)?.ColumnName ?? name;
            if (!_singleTable)
            {
                var tableName = EntityUtil.GetTable(type).TableName;
                columnName = string.Format("{0}.{1}", tableName, columnName);
            }
            _build.Append(columnName);
            _paramName = name;
        }
        public void SetValue(Expression expression)
        {
            var value = GetValue(expression);
            if(value == null) return;
            if (_operator == "LIKE" || _operator == "NOT LIKE")
            {
                if (_operatorMethod == nameof(Operator.LikeLeft) || _operatorMethod == nameof(Operator.NotLikeLeft))
                {
                    value = string.Format("%{0}", value);
                }
                else if (_operatorMethod == nameof(Operator.NotLikeRight) || _operatorMethod == nameof(Operator.LikeRight))
                {
                    value = string.Format("{0}%", value);
                }
                else
                {
                    value = string.Format("%{0}%", value);
                }

            }
            var key = $"{ConfigDapper.PREFIXPARM}{_paramName}{_param.Count}";
            _param.Add(key, value);
            _build.Append(key);
        }
        #endregion

        #region public
        public static string BuildExpression(Expression expression, Dictionary<string, object> param, bool singleTable = true)
        {
            var visitor = new ExpressionUtil
            {
                _param = param,
                _singleTable = singleTable,
            };
            visitor.Visit(expression);
            return visitor._build.ToString();
        }
        public static Dictionary<string, string> BuildColumns(Expression expression, Dictionary<string, object> param, bool singleTable = true)
        {
            var columns = new Dictionary<string, string>();
            if (expression is LambdaExpression)
            {
                expression = ((LambdaExpression)expression).Body;
            }
            if (expression is MemberInitExpression)
            {
                var initExpression = (MemberInitExpression) expression;
                for (int i = 0; i < initExpression.Bindings.Count; i++)
                {
                    var column = string.Empty;
                    Expression argument = ((MemberAssignment) initExpression.Bindings[i]).Expression;
                    if (argument is UnaryExpression)
                    {
                        argument = ((UnaryExpression) argument).Operand;
                    }
                    if (argument is MethodCallExpression && ((MethodCallExpression) argument).Method.DeclaringType == typeof(Convert))
                    {
                        column = GetValue(((MethodCallExpression) argument).Arguments[0])?.ToString();
                    }
                    else if (argument is ConstantExpression || argument is MemberExpression && ((MemberExpression) argument).Expression is ConstantExpression)
                    {
                        column = GetValue(argument)?.ToString();
                    }
                    else
                    {
                        column = BuildExpression(argument, param, singleTable);
                    }
                    var name = initExpression.Bindings[i].Member.Name;
                    if(column != null)
                    columns.Add(name, column);
                }
            }
            else if (expression is NewExpression)
            {
                var newExpression = (NewExpression) expression;
                if (newExpression != null)
                {
                    for (int i = 0; i < newExpression!.Arguments.Count; i++)
                    {
                        var columnName = string.Empty;
                        var argument = newExpression.Arguments[i];
                        if (argument is MethodCallExpression && ((MethodCallExpression)argument)!.Method.DeclaringType == typeof(Convert))
                        {
                            columnName = GetValue(((MethodCallExpression)argument)!.Arguments[0])?.ToString();
                        }
                        else if (argument is ConstantExpression || argument is MemberExpression && ((MemberExpression)argument)!.Expression is ConstantExpression)
                        {
                            columnName = GetValue(argument)?.ToString();
                        }
                        else
                        {
                            columnName = BuildExpression(argument, param, singleTable);
                        }
                        var name = newExpression?.Members?[i].Name;
                        if (name != null && columnName != null)
                        {
                            columns.Add(name, columnName);
                        }
                    }
                }
            }

            else if (expression is MemberExpression)
            {
                var memberExpression = (MemberExpression) expression;
                var name = memberExpression.Member.Name;
                var type = memberExpression.Expression?.Type;
                if (type == null) return new();
                var columnName = EntityUtil.GetColumn(type, f => f.CSharpName == name)?.ColumnName ?? name;
                if (!singleTable)
                {
                    var tableName = EntityUtil.GetTable(type).TableName;
                    columnName = string.Format("{0}.{1}", tableName, columnName);
                }
                columns.Add(name, columnName);
            }
            else if(expression.NodeType == ExpressionType.Parameter) 
            {
                foreach(var item in  EntityUtil.GetTable(expression.Type).Columns)
                {
                    columns[item.CSharpName] =   $"{EntityUtil.GetTable(expression.Type).TableName}.{item.ColumnName}";
                }
            }
            else {
                var name = string.Format("COLUMN0");
                var columnName = BuildExpression(expression, param, singleTable);
                columns.Add(name, columnName);
            }
            return columns;
        }
        public static Dictionary<string, string> BuildColumn(Expression expression, Dictionary<string, object> param, bool singleTable = true)
        {
            if (expression is LambdaExpression)
            {
                expression = ((LambdaExpression) expression).Body;
            }
            var column = new Dictionary<string, string>();
            if (expression is MemberExpression)
            {
                var memberExpression = (MemberExpression) expression;
                var name = memberExpression.Member.Name;
                var type = memberExpression.Expression?.Type;
                if (type == null) return new();
                var columnName = EntityUtil.GetColumn(type, f => f.CSharpName == name)?.ColumnName ?? name;
                if (!singleTable)
                {
                    var tableName = EntityUtil.GetTable(type).TableName;
                    columnName = string.Format("{0}.{1}", tableName, columnName);
                    if(name != null)
                    {
                        column.Add(name, columnName);
                    }
                }
                return column;
            }
            else
            {
                var name = string.Format("COLUMN0");
                var build = BuildExpression(expression, param, singleTable);
                column.Add(name, build);
                return column;
            }
        }
        public static object? GetValue(Expression expression)
        {
            var memberNames = new Stack<string>();
            var tempExpression = expression;
            if (tempExpression is MemberExpression)
            {
                var memberExpression = tempExpression as MemberExpression;

                if (memberExpression != null && memberExpression.Type == typeof(DateTime) && memberExpression.Member.Name == nameof(DateTime.Now))
                {
                    
                    return DateTime.Now;
                }
                if (memberExpression != null && memberExpression.Type == typeof(DateTime) && memberExpression.Member.Name == nameof(DateTime.Date))
                {

                    return DateTime.Now.Date;
                }
                if (memberExpression == null || memberExpression.Expression == null) return new();
                memberNames.Push(memberExpression.Member.Name);
                
                tempExpression = memberExpression.Expression;
            }
            if (tempExpression is MethodCallExpression methodCallExpression)
            {
                // Xử lý nếu biểu thức là một hàm gọi (Method Call)
                var methodName = methodCallExpression.Method.Name;

                // Lấy đối tượng phương thức đang gọi (ví dụ: DateTime.Now)
                object targetObject = DateTime.Now; // Giả định DateTime.Now làm điểm bắt đầu

                // Lấy các đối số của phương thức
                var arguments = methodCallExpression.Arguments.Select(arg =>
                {
                    if (arg is ConstantExpression constantArg)
                    {
                        return constantArg.Value;
                    }
                    // Có thể mở rộng xử lý các kiểu tham số khác ở đây (ví dụ: các tham số phức tạp hơn)
                    return null;
                }).ToArray();

                // Tìm và thực thi phương thức bằng cách sử dụng Reflection
                MethodInfo method = tempExpression.Type.GetMethod(methodName, arguments.Select(arg => arg?.GetType()).ToArray());

                if (method != null)
                {
                    // Gọi phương thức trên đối tượng targetObject
                    targetObject = method.Invoke(targetObject, arguments);
                    return targetObject;
                }

                tempExpression = methodCallExpression.Object;
            }
            if (tempExpression is ConstantExpression)
            {
                var value = ((ConstantExpression) tempExpression).Value;
                foreach (var item in memberNames)
                {
                    if (value == null) continue;

                    if (value.GetType().GetField(item) != null)
                    {
                        value = value.GetType().GetField(item)?.GetValue(value);
                    }
                    else if (value.GetType().GetProperty(item) != null)
                    {
                        value = value.GetType().GetProperty(item)?.GetValue(value);
                    }
                    else
                    {
                        return value;
                    }
                }
                return value;
            }
            else
            {
                return Expression.Lambda(expression).Compile().DynamicInvoke();
            }
        }
        #endregion
    }
}
