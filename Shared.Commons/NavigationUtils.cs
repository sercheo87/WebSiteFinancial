using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XSharper.Core;

namespace Shared.Commons
{
    public class NavigationUtils
    {
        #region "Parameters"
        enum LIST_OPERATOR_AVAILABLE
        {
            SUM = 0,
            COUNT = 1,
            BOOLEAN = 2,
            NONE = 3
        };

        //Public parameters for evaluation
        public Dictionary<string, object> Parameters { get; set; }
        public string ConditionsEvaluate { get; set; }

        //Private parametes for validation
        private string NAME_OBJECT = string.Empty;
        private string DTO_NAME_OBJECT = string.Empty;
        private string DTO_PARAMETER_OBJECT = string.Empty;
        private string VALUE_OBJECT = string.Empty;
        private string VALUE_VALIDATE_OBJECT = string.Empty;

        //Private parameters for evaluation regular expression
        // OBTIENE EL CONJUNTO DE NAMESPACE Y EL VALOR A VALIDAR
        private const string EXP_GET_CONDITION_WITH_VALUE = @"(\()+(\s|==|<=|>=|!=|.)+(\')+([.\w])+(\'\))";
        private const string EXP_GET_CONDITION_WITH_VALUE_2 = @"\[+([.\w])+\]";
        //OBTIENE EL CONJUNTO DE LAS CONDICIONALES QUE SON LIST<OBJECT>
        private const string EXP_GET_CONDITION_LIST_VALUE = @"\[\[+[(]+({SUM}|{COUNT})+[\S)]+\]\]";
        private const string EXP_CONDITIONS_LIST_VALUE = @"{SUM|COUNT}";
        private const string EXP_CONDITIONS_GET_OPERATOR = @"\{+(\S)+\}";
        // OBTIENE EL ATRIBUTO DEL OBJETO A CONSULTAR EXTERNO A LA LISTA
        private const string EXP_GET_CONDITION_LIST_OBJECT_EXTERNAL = @"\.+[a-zA-Z]+()";
        // OBTIENE EL ATRIBUTO DEL OBJETO A CONSULTAR INTERNO A LA LISTA
        private const string EXP_GET_CONDITION_LIST_OBJECT_INTERNAL = @"\.+(\w)+";
        #endregion

        #region "Constructor"
        public NavigationUtils()
        {
        }

        public NavigationUtils(Dictionary<string, object> parameters, string conditionsEvaluate)
        {
            Parameters = parameters;
            ConditionsEvaluate = conditionsEvaluate;
        }
        #endregion

        public bool GetResultsEvaluation()
        {
            try
            {
                ReplaceValuesOfParametersTypeList();
                return ReplaceValuesOfParameters();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Replace Condition only type List
        private void ReplaceValuesOfParametersTypeList()
        {
            string _cond_original = ConditionsEvaluate.Trim();
            string _cond_parse_section_1 = string.Empty;
            string _cond_parse_section_1_with_operator = string.Empty;
            string _cond_parse_operator = string.Empty;
            object RESULT_ACUMULATE = false;
            Boolean COLLECTION_SUMMARY = false;

            //Example
            //([MyProductsList].Count>1)#AND#([MyEntity].Type == 'P')#AND#([[([MyProductsList].Type=='4')]]);
            //([MyProductsList].Count>1)#AND#([MyEntity].Type == 'P')#AND#([[({SUM}[MyProductsList].Ammount)]]>=100);

            MatchCollection matches_cond_Collection = Regex.Matches(_cond_original, EXP_GET_CONDITION_LIST_VALUE, RegexOptions.Multiline);
            foreach (Match matches_conditions in matches_cond_Collection)
            {
                //[[([MyProductsList].Type=='4')]]
                _cond_parse_section_1 = matches_conditions.ToString();

                //colocar busqueda de {SUM} solo es algun if no recursivo
                MatchCollection matches_cond_exist = Regex.Matches(_cond_parse_section_1, EXP_CONDITIONS_LIST_VALUE, RegexOptions.Multiline);
                COLLECTION_SUMMARY = (matches_cond_exist.Count > 0);

                if (COLLECTION_SUMMARY)
                {
                    //GET OPERATOR CONDITION
                    MatchCollection matches_oper_exist = Regex.Matches(_cond_parse_section_1, EXP_CONDITIONS_GET_OPERATOR, RegexOptions.Multiline);
                    _cond_parse_operator = matches_oper_exist[0].ToString().Replace("{", "").Replace("}", "");
                    LIST_OPERATOR_AVAILABLE _operator = LIST_OPERATOR_AVAILABLE.NONE;
                    switch (_cond_parse_operator)
                    {
                        case "SUM":
                            _operator = LIST_OPERATOR_AVAILABLE.SUM;
                            break;
                        case "COUNT":
                            _operator = LIST_OPERATOR_AVAILABLE.COUNT;
                            break;
                        case "BOOLEAN":
                            _operator = LIST_OPERATOR_AVAILABLE.BOOLEAN;
                            break;
                    }

                    //LIST OBJECTS SUMMARY PROPERTY
                    _cond_parse_section_1_with_operator = _cond_parse_section_1.Replace("{" + _cond_parse_operator + "}", "");
                    object myObject = Process_Operators_List_DTO(_cond_parse_section_1_with_operator, _operator);
                    _cond_original = _cond_original.Replace(_cond_parse_section_1, myObject.ToString());
                }
                else
                {
                    //LIST OBJECTS EVALUATE DATA PROPERTY
                    object myObject = Process_Operators_List_DTO(_cond_parse_section_1);
                    _cond_original = _cond_original.Replace(_cond_parse_section_1, myObject.ToString());
                }
            }

            ConditionsEvaluate = _cond_original;
        }

        private bool ReplaceValuesOfParameters()
        {
            string _cond_original = ConditionsEvaluate.Trim();
            string _cond_parse_section_1 = string.Empty;
            string _cond_parse_section_1_with_operator = string.Empty;
            var contextEval = new BasicEvaluationContext();
            string tempConditionsEvaluate = _cond_original;

            MatchCollection matches_cond_value = Regex.Matches(_cond_original, EXP_GET_CONDITION_WITH_VALUE_2, RegexOptions.Multiline);

            foreach (Match match in matches_cond_value)
            {
                if (matches_cond_value.Count == 0)
                {
                    break;
                }

                string _condition_Dto = match.ToString().Replace("[", "").Replace("]", "");
                object _object_Dto = GetItemDictionary(_condition_Dto);

                contextEval.Objects[_condition_Dto] = _object_Dto;

                string temp_cond_rplc = match.ToString();
                temp_cond_rplc = temp_cond_rplc.Replace("[", "").Replace("]", "");
                _cond_original = _cond_original.Replace(match.ToString(), temp_cond_rplc);

                matches_cond_value = Regex.Matches(_cond_original, EXP_GET_CONDITION_WITH_VALUE_2, RegexOptions.Multiline);

            }

            ConditionsEvaluate = _cond_original;
            var obj = contextEval.Eval(ConditionsEvaluate);
            if (obj.ToString() == "1")
            {
                return true;
            }
            if (obj.ToString() == "0")
            {
                return false;
            }
            return bool.Parse(obj.ToString());
        }


        #region "General Operator List DTO"
        private object GetItemDictionary(string item)
        {
            return Parameters[item];
        }

        private object VerifyDtoListObject(Object fromObject)
        {
            Type objectType = fromObject.GetType();
            if (fromObject.GetType().IsGenericType)
            {
                return fromObject;
            }
            return null;
        }

        private object Process_Operators_List_DTO(string condition, LIST_OPERATOR_AVAILABLE OPERATOR = LIST_OPERATOR_AVAILABLE.BOOLEAN)
        {
            int RESULT_COUNT = 0;
            double RESULT_DOUBLE = 0;
            bool RESULT_BOOLEAN = false;
            //Flag para realizar operaciones recursivas dentro de la lista
            bool flag_Mod_Internal = false;

            switch (OPERATOR)
            {
                case LIST_OPERATOR_AVAILABLE.SUM:
                    flag_Mod_Internal = false;
                    break;
                case LIST_OPERATOR_AVAILABLE.COUNT:
                    flag_Mod_Internal = true;
                    break;
                case LIST_OPERATOR_AVAILABLE.BOOLEAN:
                    flag_Mod_Internal = true;
                    break;
            }

            string _condition_Dto = Get_REGEX_Condition(condition);
            string _property_Dto = Get_REGEX_Property(condition, flag_Mod_Internal);
            object _object_Dto = GetItemDictionary(_condition_Dto);

            if (_object_Dto.GetType().IsGenericType)
            {
                int n = Get_Count_Items_Dto(_object_Dto);
                for (int i = 0; i < n; i++)
                {
                    object[] index = { i };
                    object myObject = Get_Object_Dto(_object_Dto, index);

                    MatchCollection matches_cond_Item;
                    object _temp_value_2;
                    var contextEval = new BasicEvaluationContext();
                    string temp_cond_rplc;

                    switch (OPERATOR)
                    {
                        case LIST_OPERATOR_AVAILABLE.COUNT:
                            matches_cond_Item = Regex.Matches(condition.Trim(), EXP_GET_CONDITION_WITH_VALUE, RegexOptions.Multiline);
                            _temp_value_2 = Get_Value_Item_Dto(myObject, _property_Dto);

                            contextEval.Objects[_condition_Dto] = myObject;

                            temp_cond_rplc = matches_cond_Item[0].ToString().Substring(0, matches_cond_Item[0].ToString().Length - 0);
                            temp_cond_rplc = temp_cond_rplc.Replace("[", "").Replace("]", "");

                            //ACUMULACION DE VALORES BOOLEANOS
                            if ((Boolean)contextEval.Eval(temp_cond_rplc))
                            {
                                RESULT_COUNT++;
                            }
                            break;

                        case LIST_OPERATOR_AVAILABLE.SUM:
                            matches_cond_Item = Regex.Matches(condition.Trim(), EXP_GET_CONDITION_WITH_VALUE, RegexOptions.Multiline);
                            if (matches_cond_Item.Count > 0)
                            {
                                contextEval.Objects[_condition_Dto] = myObject;
                                if ((Boolean)contextEval.Eval(condition.Replace("[", string.Empty).Replace("]", string.Empty)))
                                {
                                    RESULT_DOUBLE += double.Parse(Get_Value_Item_Dto(myObject, _property_Dto).ToString());
                                }
                            }
                            else
                            {
                                RESULT_DOUBLE += RESULT_DOUBLE + double.Parse(Get_Value_Item_Dto(myObject, _property_Dto).ToString());
                            }
                            break;

                        case LIST_OPERATOR_AVAILABLE.BOOLEAN:
                            matches_cond_Item = Regex.Matches(condition.Trim(), EXP_GET_CONDITION_WITH_VALUE, RegexOptions.Multiline);
                            _temp_value_2 = Get_Value_Item_Dto(myObject, _property_Dto);

                            contextEval.Objects[_condition_Dto] = myObject;

                            temp_cond_rplc = matches_cond_Item[0].ToString().Substring(0, matches_cond_Item[0].ToString().Length - 0);
                            temp_cond_rplc = temp_cond_rplc.Replace("[", "").Replace("]", "");

                            //ACUMULACION DE VALORES BOOLEANOS
                            RESULT_BOOLEAN = (Boolean)RESULT_BOOLEAN || (Boolean)contextEval.Eval(temp_cond_rplc);
                            break;
                    }
                }

                //Returns
                switch (OPERATOR)
                {
                    case LIST_OPERATOR_AVAILABLE.SUM:
                        return RESULT_DOUBLE;
                    case LIST_OPERATOR_AVAILABLE.BOOLEAN:
                        return RESULT_BOOLEAN;
                    case LIST_OPERATOR_AVAILABLE.COUNT:
                        return RESULT_COUNT;
                }
            }
            return null;
        }
        #endregion

        #region "DTO OPTIONS"
        /// <summary>
        /// Get numbers items in List Dto
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        private int Get_Count_Items_Dto(object _object)
        {
            return (int)_object.GetType().GetProperty("Count").GetValue(_object, null);
        }

        /// <summary>
        /// Get Object
        /// </summary>
        /// <param name="_object"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private object Get_Object_Dto(object _object, object[] index)
        {
            return _object.GetType().GetProperty("Item").GetValue(_object, index);
        }

        /// <summary>
        /// Get Value of a attribute in Dto
        /// </summary>
        /// <param name="_object"></param>
        /// <param name="_property"></param>
        /// <returns></returns>
        private object Get_Value_Item_Dto(object _object, string _property)
        {
            return _object.GetType().GetProperty(_property).GetValue(_object, null);
        }
        #endregion

        #region "GET ITEMS EXPRESSION REGULAR"
        /// <summary>
        ///  Get Attribute example: [MyProducts].Type
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="modInternal"></param>
        /// <returns></returns>
        private string Get_REGEX_Property(string condition, bool modInternal = true)
        {
            string sTemp = string.Empty;
            MatchCollection objCondition = Regex.Matches(condition, modInternal ? EXP_GET_CONDITION_LIST_OBJECT_INTERNAL : EXP_GET_CONDITION_LIST_OBJECT_EXTERNAL, RegexOptions.IgnorePatternWhitespace);

            if (modInternal)
            {
                sTemp = objCondition[0].ToString().Substring(1, objCondition[0].ToString().Length - 1);
            }
            else
            {
                sTemp = objCondition[0].ToString().Substring(1, objCondition[0].ToString().Length - 1);
            }
            return sTemp;
        }

        /// <summary>
        /// Get example : [MyProducts]
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        private string Get_REGEX_Condition(string condition)
        {
            string sTemp = string.Empty;
            MatchCollection objCondition = Regex.Matches(condition, EXP_GET_CONDITION_WITH_VALUE_2, RegexOptions.IgnorePatternWhitespace);
            sTemp = objCondition[0].ToString().Substring(1, objCondition[0].ToString().Length - 2);
            return sTemp;
        }
        #endregion
    }
}
