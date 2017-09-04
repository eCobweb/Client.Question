using QuestionClient.Helper;
using QuestionClient.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace QuestionClient
{
    public class QuestionHelper
    {       
        public static List<Questionnaire> ReadQuestionnaires(string questionnaireFileName) {
            List<Questionnaire> qns = new List<Questionnaire>();

            
            return qns;
            
        }

        static void BuildQuestionnaire(string sheet,DataTable data, List<Questionnaire> qns)
        {
            Questionnaire qnObj = new Questionnaire();

            var q_name = Properties.Settings.Default[sheet.Replace("$","")];

            var q_id = Convert.ToInt32(sheet.Replace("$", "").Replace("Q", ""));

            List<Question> questions = new List<Question>();

            foreach (DataRow dr in data.Rows)
            {
                if (null == dr["NO"] || string.IsNullOrEmpty(dr["NO"].ToString())) {
                    continue;
                }
                Question q = new Question() {
                    NO = dr["NO"].ToString(),

                    Text = dr["Text"].ToString()
                };

                OptionJson oj = new JavaScriptSerializer().Deserialize<OptionJson>(dr["Options"].ToString());

                List<Option> options = new List<Option>();

                string[] ops = oj.Options.Split(',');

                string[] opWeights = oj.Values.Split(',');

                for (int i = 0; i < ops.Length; i++)
                {
                    Option op = new Option() {
                        Text = ops[i],
                        Weight = Convert.ToInt32(opWeights[i])
                    };

                    options.Add(op);
                }

                q.Options = options;

                questions.Add(q);
            }

            qnObj.Questions = questions;

            qnObj.QuestionnaireID = q_id;

            qnObj.Name = q_name.ToString();

            qns.Add(qnObj);
        }

        public static List<Questionnaire> ReadQuestionnairesFromXML(string questionnaireFileName)
        {
            List<Questionnaire> list = new List<Questionnaire>();
            XmlDocument xml =  XMLHelper.xmlDoc(questionnaireFileName);

            XmlNode root =  XMLHelper.GetNode(xml, "Questionnaires");

            foreach (XmlNode qnNode in root.ChildNodes)
            {
                Questionnaire qn = new Questionnaire();

                qn.QuestionnaireID = Convert.ToInt32(qnNode.Attributes["ID"].Value);

                qn.Name = qnNode.Attributes["Name"].Value;

                qn.Message = qnNode.Attributes["Message"] == null ? string.Empty : qnNode.Attributes["Message"].Value;

                qn.GroupName = qnNode.Attributes["GroupName"] == null ? string.Empty : qnNode.Attributes["GroupName"].Value;

                var isLoaded = qnNode.Attributes["Enable"].Value;                

                if (!isLoaded.Equals("1"))
                {
                    continue;
                }

                //question
                foreach (XmlNode qNode in qnNode.ChildNodes)
                {
                    Question q = new Question();

                    q.NO = qNode.Attributes["NO"].Value;

                    q.Text = qNode.Attributes["Text"].Value;

                    //options
                    foreach (XmlNode opNode in qNode.ChildNodes)
                    {
                        Option op = new Option();

                        op.Text = opNode.InnerText;

                        op.Weight = Convert.ToInt32(opNode.Attributes["Wieght"].Value);

                        q.Options.Add(op);
                    }

                    qn.Questions.Add(q);
                }

                list.Add(qn);
            }

            return list;

        }

        public static List<Assess> ReadAssessFromXML(string assessFile)
        {
            List<Assess> list = new List<Assess>();
            XmlDocument xml = XMLHelper.xmlDoc(assessFile);

            XmlNode root = XMLHelper.GetNode(xml, "Assesses");

            foreach (XmlNode qnNode in root.ChildNodes)
            {
                Assess assess = new Assess();

                assess.QuestionnaireID = Convert.ToInt32(qnNode.Attributes["QuestionnaireID"].Value);
                

                //result
                foreach (XmlNode qNode in qnNode.ChildNodes)
                {
                    AssessResult q = new AssessResult();

                    q.Name = qNode.Attributes["Name"].Value;

                    q.Code = qNode.Attributes["Code"].Value;

                    q.Text = qNode.InnerText;

                    assess.Results.Add(q);
                }

                list.Add(assess);
            }

            return list;
        }

        public static string test()
        {
            StringBuilder sb = new StringBuilder();

            List<Question> list1 = ReadQuestions_1();

            sb.Append("\r\n-----------1-------------------\r\n");

            list1.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });


            List < Question > list4 = ReadQuestions_4();

            sb.Append("\r\n-----------4-------------------\r\n");

            list4.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });

            List<Question> list6 = ReadQuestions_6();

            sb.Append("\r\n-----------6-------------------\r\n");

            list6.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });

            List<Question> list8 = ReadQuestions_8();

            sb.Append("\r\n-----------8-------------------\r\n");

            list8.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });

            List<Question> list10 = ReadQuestions_10();

            sb.Append("\r\n-----------10-------------------\r\n");

            list10.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });


            List<Question> list11 = ReadQuestions_11();

            sb.Append("\r\n-----------11-------------------\r\n");

            list11.ForEach(o => {
                sb.Append(string.Format(" <Question NO =\"{0}\" Text=\"{1}\">\r\n", o.NO, o.Text));
                o.Options.ForEach(p => {
                    sb.Append(string.Format("<Option Wieght=\"{0}\">{1}</Option>\r\n", p.Weight, p.Text));
                });
                sb.Append("</Question>\r\n");
            });


            return sb.ToString();
        }

        //简明
        static List<Question> ReadQuestions_1()
        {
            List<string> questions = new List<string>()
            { "关心身体健康",
              "焦虑",
              "焦感情交流障碍虑",
              "概念紊乱",
              "罪恶观念",
              "紧张",
              "装相和作态",
              "夸大",
              "心境抑郁",
              "敌对性",
              "猜疑",
              "幻觉",
              "动作迟缓",
              "不合作",
              "不寻常思维内容",
              "情感平淡",
              "兴奋",
              "定向障碍"
            };

            List<Question> result = new List<Question>();

            int i = 1;

            questions.ForEach(q => {
                result.Add(new Question() { NO = (i++).ToString(),
                                            Text = q,
                                            Options = new List<Option>() {
                                                                            new Option() { Text="无", Weight = 1 },
                                                                            new Option() { Text="很轻", Weight = 2 },
                                                                            new Option() { Text="轻度", Weight = 3 },
                                                                            new Option() { Text="中度", Weight = 4 },
                                                                            new Option() { Text="偏重", Weight = 5 },
                                                                            new Option() { Text="重度", Weight = 6 },
                                                                            new Option() { Text="极重", Weight = 7 },
                                                                         }
                                        });
            });

            return result;
        }


        //心理卫生
        static List<Question> ReadQuestions_2()
        {
            return null;
        }

        //自测健康
        static List<Question> ReadQuestions_3()
        {
            return null;
        }

        //酒精依赖
        static List<Question> ReadQuestions_4()
        {
            List<string> questions = new List<string>()
            {   "多久喝一次含酒精饮品？",
                "每天喝酒多少杯？",
                "过去一年中，一次饮酒超过6杯（女性）或8杯（男性）发生过多少回？",
                "发现自己一旦开始喝酒就难以停下来。近一年来，这一现象多久一次",
                "近一年来，因为饮酒而发生工作失误几次？",
                "醉酒之后，次日继续饮酒。近一年有多少回？",
                "近一年来，饮酒后感到内疚和自责，有多少回？",
                "饮酒后第二天记不得第一天醉酒时究竟发生过什么事。这样的情况一年来发生过几次？",
                "你自己或身边人是否因为你醉酒而受过伤？",
                "是否有家人、朋友、医生或其他工作人员为你的饮酒感到担心并建议你少喝酒？"
                
            };

            List<Question> result = new List<Question>();

            int i = 1;

            questions.ForEach(q =>
            {
                Question _q = new Question();


                _q.NO = (i++).ToString();
                _q.Text = q;

                switch (i - 1)
                {
                    case 1:
                        _q.Options = new List<Option>() {
                                                   new Option() { Text="从来不", Weight = 0 },
                                                   new Option() { Text="每月1次或更少", Weight = 1 },
                                                   new Option() { Text="每月2~4次", Weight = 2 },
                                                   new Option() { Text="每周2~3次", Weight = 3 },
                                                   new Option() { Text="每周4次以上", Weight = 4 }
                                                 };
                        break;

                    case 2:
                        _q.Options = new List<Option>() {
                                                   new Option() { Text="1~2杯", Weight = 0 },
                                                   new Option() { Text="3~4杯", Weight = 1 },
                                                   new Option() { Text="5~6杯", Weight = 2 },
                                                   new Option() { Text="7~9杯", Weight = 3 },
                                                   new Option() { Text="10杯以上", Weight = 4 }
                                                 };
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        _q.Options = new List<Option>() {
                                                   new Option() { Text="从未发生", Weight = 0 },
                                                   new Option() { Text="每月不到1次", Weight = 1 },
                                                   new Option() { Text="每月1次", Weight = 2 },
                                                   new Option() { Text="每周1次", Weight = 3 },
                                                   new Option() { Text="每天或几乎每天发生", Weight = 4 }
                                                 };
                        break;

                    case 9:                    
                        _q.Options = new List<Option>() {
                                                   new Option() { Text="没发生过", Weight = 0 },
                                                   new Option() { Text="发生过，但近一年没有", Weight = 2 },
                                                   new Option() { Text="近一年发生过", Weight = 4 }
                                                 };
                        break;
                    case 10:
                        _q.Options = new List<Option>() {
                                                   new Option() { Text="没发生过", Weight = 0 },
                                                   new Option() { Text="有，但近一年没有", Weight = 2 },
                                                   new Option() { Text="近一年发生过", Weight = 4 }
                                                 };
                        break;
                }

                    

                result.Add(_q);
            });

            return result;
        }


        //russell
        static List<Question> ReadQuestions_5()
        {
            return null;
        }

        //自杀
        static List<Question> ReadQuestions_6()
        {
            List<string> questions = new List<string>()
            {
               "自杀是一种疯狂的行为",
                "自杀死亡者应与自然死亡者享受同等待遇",
                "一般情况下,我不愿意和有过自杀行为的人深交",
                "在整个自杀事件中,最痛苦的是自杀者的家属",
                "对于身患绝症又极度痛苦的病人,可由医务人员在法律的支持下帮助病人结束生命",
                "在处理自杀事件过程中,应该对其家人表示同情和关心,并尽可能为他们提供帮助",
                "自杀是随人生命尊严的践踏",
                "不应为自杀死亡者开追悼会",
                "如果我的朋友自杀未遂,我会比以前更挂心他",
                "如果我的邻居家里有人自杀，我会逐渐疏远和他们的关系",
                "安乐死是对人生命尊严的践踏",
                "自杀是对家庭和社会一种不负责任的行为",
                "人们不应该对自杀死亡者评头论足",
                "我对那些反复自杀者很反感,因为他们常常将自杀作为一种控制别人的手段",
                "对于自杀,自杀者的家属在不同程度上都应负有一定的责任",
                "假如我自己身患绝症又处于极度痛苦之中,我希望医务人员能帮助我结束自己的生命",
                "个体为某种伟大的,超过人生命价值的目的而自杀是值得赞许的",
                "一般情况下,我不愿去看望自杀未遂者,即使 是亲人或好朋友也不例外",
                "自杀只是一种生命现象,无所谓道德上的好和坏",
                "自杀未遂者不值得同情",
                "对于身患绝症又极度痛苦的病人,可不再为其进行维护生命的治疗(被动安乐死)",
                "自杀是对亲人,朋友的背叛",
                "人有时为了尊严和荣誉而不得不自杀",
                "在交友时我不太介意对反时候有过自杀行为",
                "对自杀未遂者应给予更多的关心和帮助",
                "当生命已无欢乐可言时,自杀是可以理解的",
                "假如我自己身患绝症又处于嫉妒痛苦之中,我不愿再接维持生命的治疗",
                "一般情况下我不会和家中有过自杀的人结婚",
                "人应该有选择自杀的权利"
            };

            List<Question> result = new List<Question>();

            int i = 1;

            int[] reversedItem = new int[] { 1, 3, 7, 8, 10, 11, 12, 14, 15, 18, 20, 22, 28 };
            questions.ForEach(q => {
                result.Add(new Question()
                {
                    NO = (i++).ToString(),
                    Text = q,

                    Options = new List<Option>() {
                                                   new Option() { Text="完全赞同", Weight = reversedItem.Contains((i-1))? 5 : 1 },
                                                   new Option() { Text="比较赞同", Weight = reversedItem.Contains((i-1))? 4 : 2 },
                                                   new Option() { Text="中立", Weight = 3 },
                                                   new Option() { Text="比较不赞同", Weight = reversedItem.Contains((i-1))? 2 : 4 },
                                                   new Option() { Text="完全不赞同", Weight = reversedItem.Contains((i-1))? 1 : 5 }
                                                 }

                    
                });
            });

            return result;
        }


        //匹兹堡
        static List<Question> ReadQuestions_7()
        {
            return null;
        }


        //焦虑
        static List<Question> ReadQuestions_8()
        {
            List<string> questions = new List<string>()
            {   "我觉得比平常容易紧张和着急（焦虑）",
                "我无缘无故地感到害怕（害怕）",
                "我容易心里烦乱或觉得惊恐（惊恐）",
                "我觉得我可能将要发疯（发疯感）",
                "我觉得一切都很好，也不会发生什么不幸（不幸预感）",
                "我手脚发抖打颤（手足颤抖）",
                "我因为头痛，颈痛和背痛而苦恼（躯体疼痛）",
                "我感觉容易衰弱和疲乏（乏力）",
                "我觉得心平气和，并且容易安静坐着（静坐不能）",
                "我觉得心跳很快（心慌）",
                "我因为一阵阵头晕而苦恼（头昏）",
                "我有晕倒发作或觉得要晕倒似的（晕厥感）",
                "我呼气吸气都感到很容易（呼吸困维）",
                "我手脚麻木和刺痛（手足刺痛）",
                "我因为胃痛和消化不良而苦恼（胃痛或消化不良）",
                "我常常要小便（尿意频数）",
                "我的手常常是干燥温暖的（多汗）",
                "我脸红发热（面部潮红）",
                "我容易入睡并且一夜睡得很好（睡眠障碍）",
                "我做恶梦"
            };

            List<Question> result = new List<Question>();

            int i = 1;

            int[] reversedItem = new int[] { 5, 9, 13, 17, 19 };

            questions.ForEach(q => {
                result.Add(new Question()
                {
                    NO = (i++).ToString(),
                    Text = q,
                    Options = new List<Option>() {
                                                   new Option() { Text="没有或很少时间有", Weight = reversedItem.Contains((i-1))? 4 : 1 },
                                                   new Option() { Text="有时有", Weight = reversedItem.Contains((i-1))? 3 : 2 },
                                                   new Option() { Text="大部分时间有", Weight = reversedItem.Contains((i-1))? 2 : 3 },
                                                   new Option() { Text="绝大部分或全部时间都有", Weight = reversedItem.Contains((i-1))? 1 : 4 }                                                                            
                                                 }
                });
            });

            return result;
        }


        //孤独
        static List<Question> ReadQuestions_9()
        {
            return null;
        }

        //10
        static List<Question> ReadQuestions_10()
        {
            List<string> questions = new List<string>()
            { "食欲正常，饮食量按期增加。",
                "自我调节能力强，进食寒热食品，体内阴阳都能自行调和，不会出现明显不适。",
                "毛发润泽，皮肤柔嫩，面色红润有光泽，唇色红润",
                "精力充沛，活泼强健，语声清晰，哭声洪亮和顺，睡眠安静",
                "无盗汗自汗，大便每天1次，成形不干燥，小便正常",
                "舌体正常，舌淡红，苔薄白，脉滑或缓",
                "经常出现食欲不佳，进食后消化不好，口气秽臭，进食量少",
                "神疲懒言，哭声较低，身体虚胖，安静少动",
                "面色苍白或萎黄，自汗乏力，动则汗多",
                "大便溏烂，或夹不消化食物残渣，每日2－3次",
                "小便量多或正常",
                "舌色淡，舌体胖有齿痕，苔薄白，脉细",
                "平素恣食肥腻辛辣煎炒等食品，尤其进食“燥热”食品后，易出现不适",
                "唇红，面色偏红，或有低热",
                "烦躁多啼，夜卧不安，或睡中头汗出，不耐热",
                "口臭，口渴喜冷饮",
                "大便干燥，小便黄",
                "舌质红，苔黄厚或腻，脉滑数",
                "食欲不振，饮食量较少，饮食不慎则觉明显不适",
                "面色苍白或萎黄",
                "有时可见吐乳或酸馊食物残渣",
                "腹部胀满，大便不调，酸臭或便秘，或夹有食物残渣",
                "小便浑浊、量少或正常",
                "舌色淡，舌体胖有齿痕，苔白厚，脉细",
                "平素恣食肥腻辛辣煎炒等食品",
                "易出现口腔溃疡、失眠、便秘等疾病",
                "面红，心神不宁，多动不安，易兴奋，发脾气，注意力不集中",
                "挑食，纳差，口臭，大便干结，小便黄",
                "入睡难，睡觉易惊醒，夜间啼哭，踢被子、掀衣服",
                "嘴唇偏红，舌质红，苔黄干，脉滑数"

            };

            List<Question> result = new List<Question>();

            int i = 1;

            questions.ForEach(q => {
                result.Add(new Question()
                {
                    NO = (i++).ToString(),
                    Text = q,
                    Options = new List<Option>() {
                                                                            new Option() { Text=(i-1) == 9 ? "没有 (BMI＜24)": ((i-1) == 14?"一年＜2次":((i-1) == 17?"从来没有":((i-1) == 28?"根本不（腹围<80cm，相当于2.4尺)":"没有"))), Weight = 1 },
                                                                            new Option() { Text=(i-1) == 9 ? "很少 (24≤BMI＜25)": ((i-1) == 14?"一年感冒2-4次":((i-1) == 17?"一年1、2次":((i-1) == 28?"有一点(腹围80-85cm，2.4-2.55尺)":"很少"))), Weight = 2 },
                                                                            new Option() { Text=(i-1) == 9 ?"有时 (25≤BMI＜26)": ((i-1) == 14?"一年感冒5-6次":((i-1) == 17?"一年3、4次":((i-1) == 28?"有些(腹围86-90cm，2.56-2.7尺)":"有时"))), Weight = 3 },
                                                                            new Option() { Text=(i-1) == 9 ?"经常（26≤BMI＜28）": ((i-1) == 14?"一年8次以上":((i-1) == 17?"一年5、6次":((i-1) == 28?"相当(腹围91-105cm，2.71-3.15尺)":"经常"))), Weight = 4 },
                                                                            new Option() { Text=(i-1) == 9 ?"总是 (BMI≥28)": ((i-1) == 14?"几乎每月都感冒":((i-1) == 17?"每次遇到上述原因都过敏":((i-1) == 28?"非常(腹围>105cm，3.15尺)":"总是"))), Weight = 5 }
                                                                         }
                });
            });

            return result;
        }


        //11
        static List<Question> ReadQuestions_11()
        {
            List<string> questions = new List<string>()
            { "您精力充沛吗？（指精神头足，乐于做事）",
                "您容易疲乏吗？（指体力如何，是否稍微活动一下或做一点家务劳动就感到累）",
                "您容易气短，呼吸短促，接不上气吗？",
                "您说话声音低弱无力吗?（指说话没有力气）",
                "您感到闷闷不乐、情绪低沉吗?（指心情不愉快，情绪低落）",
                "您容易精神紧张、焦虑不安吗?（指遇事是否心情紧张）",
                "您因为生活状态改变而感到孤独、失落吗？",
                "您容易感到害怕或受到惊吓吗?",
                "您感到身体超重不轻松吗?(感觉身体沉重)[BMI指数=体重（kg）/身高2（m）]",
                "您眼睛干涩吗?",
                "您手脚发凉吗?（不包含周围温度低或穿的少导致的手脚发冷）",
                "您胃脘部、背部或腰膝部怕冷吗？（指上腹部、背部、腰部或膝关节等，有一处或多处怕冷）",
                "您比一般人耐受不了寒冷吗？（指比别人容易害怕冬天或是夏天的冷空调、电扇等）",
                "您容易患感冒吗?（指每年感冒的次数）",
                "您没有感冒时也会鼻塞、流鼻涕吗?",
                "您有口粘口腻，或睡眠打鼾吗？",
                "您容易过敏(对药物、食物、气味、花粉或在季节交替、气候变化时)吗?",
                "您的皮肤容易起荨麻疹吗? (包括风团、风疹块、风疙瘩)",
                "您的皮肤在不知不觉中会出现青紫瘀斑、皮下出血吗?（指皮肤在没有外伤的情况下出现青一块紫一块的情况）",
                "您的皮肤一抓就红，并出现抓痕吗?（指被指甲或钝物划过后皮肤的反应）",
                "您皮肤或口唇干吗?",
                "您有肢体麻或固定部位疼痛的感觉吗？",
                "您面部或鼻部有油腻感或者油亮发光吗?（指脸上或鼻子）",
                "您面色或目眶晦黯，或出现褐色斑块/斑点吗?",
                "您有皮肤湿疹、疮疖吗？",
                "您感到口干咽燥、总想喝水吗？",
                "您感到口苦或嘴里有异味吗?（指口苦或口臭）",
                "您腹部肥大吗?（指腹部脂肪肥厚）",
                "您吃(喝)凉的东西会感到不舒服或者怕吃(喝)凉的东西吗？（指不喜欢吃凉的食物，或吃了凉的食物后会不舒服）",
                "您有大便黏滞不爽、解不尽的感觉吗?(大便容易粘在马桶上)",
                "您容易大便干燥吗?",
                "您舌苔厚腻或有舌苔厚厚的感觉吗?（如果自我感觉不清楚可由调查员观察后填写）",
                "您舌下静脉瘀紫或增粗吗？（可由调查员辅助观察后填写）"

            };

            List<Question> result = new List<Question>();

            int i = 1;

            questions.ForEach(q => {
                result.Add(new Question()
                {
                    NO = (i++).ToString(),
                    Text = q,
                    Options = new List<Option>() {
                                                                            new Option() { Text="没有", Weight = 1 },
                                                                            new Option() { Text="很少", Weight = 2 },
                                                                            new Option() { Text="有时", Weight = 3 },
                                                                            new Option() { Text="经常", Weight = 4 },
                                                                            new Option() { Text="总是", Weight = 5 }
                                                                         }
                });
            });

            return result;
        }

        public static string GetCurrentResult()
        {
            string result = string.Empty;

            QuestionWorkflow qwf = QuestionWorkflow.Instance();

            if (null != qwf.responses)
            {
                int score = 0;

                qwf.responses.ForEach(o => {

                    score += qwf.questionnaire.Questions.FirstOrDefault(q => q.NO.Equals(o.ResponseNO)).Options[o.ResponseOption - 1].Weight;

                });

                result = resultMessage(score, qwf.questionnaire.QuestionnaireID);
            }

            return result;
        }

        static string resultMessage(int score, int questionnaireID)
        {
            string message = "";
            switch (questionnaireID)
            {
                case 1:


                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4://酒精

                    message = string.Format("得分: {0} 结果: {1}", score, score < 8 ? "低危" : (score < 16 ? "危险增加" : (score < 20 ? "高危" : "酒精依赖")));

                    break;
                case 5:
                    break;
                case 6://自杀

                    double average =  Math.Round((1.0 * score / 29), 1);

                    message = string.Format("得分: {0} 结果: {1}", average, average < 2.6 ? "对自杀的肯定、认可、理解和宽容的态度" : (average < 3.5 ? "矛盾或中立的态度" : "对自杀持反对、否定、排斥和歧视的态度"));

                    break;
                case 7:
                    break;
                case 8://焦虑

                    int myscore = (int)(score * 1.25);

                    message = string.Format("得分: {0} 结果: {1}", myscore, myscore > 49 && myscore < 60 ? "轻度焦虑" : (myscore > 59 && myscore < 70 ? "中度焦虑" : (myscore > 69  ? "重度焦虑" : "未知")));


                    break;
                case 9:
                    break;
                case 10: //儿童

                    break;

                case 11://老人
                    break;

            }

            return message;
        }


        /// <summary>
        /// 简明精神量表
        /// </summary>
        /// <param name="qn"></param>
        /// <param name="jsResult"></param>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public static string resultMessage1(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("得分：{0} (得分越高，病情越重。分值为18~126)", score);
            }


            return ret;
        }

        //心理卫生评测
        public static string resultMessage2(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            var no1 = new int[] { 1, 4, 12, 27, 40, 42, 48, 49, 52, 53, 56, 58 };
            var no2 = new int[] { 3, 9, 10, 28, 38, 45, 46, 51, 55, 65 };
            var no3 = new int[] { 6, 21, 34, 36, 37, 41, 61, 69, 73 };
            var no4 = new int[] { 5, 14, 15, 20, 22, 26, 29, 30, 31, 32, 54, 71, 79 };
            var no5 = new int[] { 2, 17, 23, 33, 39, 57, 72, 78, 80, 86 };
            var no6 = new int[] { 11, 24, 63, 67, 74, 81 };
            var no7 = new int[] { 13, 25, 47, 50, 70, 75, 82 };
            var no8 = new int[] { 8, 18, 43, 68, 76, 83 };
            var no9 = new int[] { 7, 16, 35, 62, 77, 84, 85, 87, 88, 90 };
            var no10 = new int[] { 19, 44, 59, 60, 64, 66, 89 };

            int s1, s2, s3, s4, s5, s6, s7, s8, s9, s10;
            s1 = s2 = s3 = s4 = s5 = s6 = s7 = s8 = s9 = s10 = 0;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        var intNO = Convert.ToInt32(q.NO);

                        if (no1.Contains(intNO)) s1 += op.Weight;
                        if (no2.Contains(intNO)) s2 += op.Weight;
                        if (no3.Contains(intNO)) s3 += op.Weight;
                        if (no4.Contains(intNO)) s4 += op.Weight;
                        if (no5.Contains(intNO)) s5 += op.Weight;
                        if (no6.Contains(intNO)) s6 += op.Weight;
                        if (no7.Contains(intNO)) s7 += op.Weight;
                        if (no8.Contains(intNO)) s8 += op.Weight;
                        if (no9.Contains(intNO)) s9 += op.Weight;
                        if (no10.Contains(intNO)) s10 += op.Weight;                       

                    }
                });

                ret = string.Format("躯体化: {0}, 强迫症状: {1}, 人际关系敏感: {2}, 抑郁: {3}, 焦虑: {4}, 敌对: {5}" +
                                    ", 恐怖: {6}, 偏执: {7}, 精神病性: {8}, 其他(主要反映睡眠及饮食情况): {9} ",
                                    s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);
            }


            return ret;
        }

        //自测健康评测
        public static string resultMessage3(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;  //总分
                var score1 = 0; //生理健康子量表分
                var score2 = 0; //心理健康子量表分
                var score3 = 0; //社会健康子量表分

                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        var intNO = Convert.ToInt32(o.key);

                        if (0 < intNO && intNO < 18) score1 += op.Weight;
                        if (18 < intNO && intNO < 34) score2 += op.Weight;
                        if (34 < intNO && intNO < 47) score3 += op.Weight;

                        score += intNO == 18 ? 0:(intNO == 34? 2*op.Weight: op.Weight);

                    }
                });

                ret = string.Format("生理健康得分：{0},心理健康得分：{1},社会健康得分：{2} ,总得分: {3}", score1,score2,score3,score);
            }

            return ret;
        }

        //酒精依赖疾患识别测验
        public static string resultMessage4(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("得分: {0} 结果: {1}", score, score < 8 ? "低危" : (score < 16 ? "危险增加" : (score < 20 ? "高危" : "酒精依赖")));
            }


            return ret;
        }

        //吸烟原因问卷
        public static string resultMessage5(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                var item1 = new int[] {6,19,23 };
                var item2 = new int[] {5,10,22 };
                var item3 = new int[] {3,4,16 };
                var item4 = new int[] {7,12,24 };
                var item5 = new int[] {8,13,17 };
                var item6 = new int[] {11,18,20 };
                var item7 = new int[] {2,9,15 };
                var item8 = new int[] {1,14,21 };

                int s1, s2, s3, s4, s5, s6, s7, s8;

                s1 = s2 = s3 = s4 = s5 = s6 = s7 = s8 = 0;

                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        int intNO = Convert.ToInt32(o.key);

                        if (item1.Contains(intNO)) s1 += op.Weight;
                        if (item2.Contains(intNO)) s2 += op.Weight;
                        if (item3.Contains(intNO)) s3 += op.Weight;
                        if (item4.Contains(intNO)) s4 += op.Weight;
                        if (item5.Contains(intNO)) s5 += op.Weight;
                        if (item6.Contains(intNO)) s6 += op.Weight;
                        if (item7.Contains(intNO)) s7 += op.Weight;
                        if (item8.Contains(intNO)) s8 += op.Weight;

                    }
                });

                ret = string.Format("心理意象:{0},口手活动: {1},享乐: {2},镇静: {3},刺激: {4},瘾: {5},自动: {6},辅助量表: {7}", s1, s2, s3, s4, s5, s6, s7, s8);
            }



            resultCode = "501";
            return ret;
        }

        //自杀态度问卷
        public static string resultMessage6(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                var average = Math.Round((1.0 * score / 29), 1);

                ret = string.Format("得分: {0} 结果: {1}", average, average < 2.6 ? "对自杀的肯定、认可、理解和宽容的态度" : (average < 3.5 ? "矛盾或中立的态度" : "对自杀持反对、否定、排斥和歧视的态度"));
            }

            return ret;
        }

        //匹兹堡睡眠质量指数
        public static string resultMessage7(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;


            return "评估暂缺，敬请期待..";
        }

        //焦虑自评工表
        public static string resultMessage8(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                var myscore = (int)(score * 1.25);

                ret = string.Format("得分: {0} 结果: {1}", myscore, myscore > 49 && myscore < 60 ? "轻度焦虑" : (myscore > 59 && myscore < 70 ? "中度焦虑" : (myscore > 69 ? "重度焦虑" : "未知")));
            }
           

            return ret;
        }

        //孤独量表
        public static string resultMessage9(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;            

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("得分: {0} (总分{1})", score, "80,得分越高表示孤独程度越高");
            }


            return ret;
        }



        /// <summary>
        /// 儿童体质识别
        /// </summary>
        /// <param name="qn"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static string resultMessage10(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            int scorePart1 , scorePart2 , scorePart3, scorePart4, scorePart5;

            scorePart1 = scorePart2 = scorePart3 = scorePart4 = scorePart5 = 0;

            string ret = string.Empty;

            if (null != qn)
            {
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        var intNO = Convert.ToInt32(o.key);

                        if (1 < intNO && intNO < 7)
                        {
                            scorePart1 += op.Weight;
                        }

                        if (6 < intNO && intNO < 13)
                        {
                            scorePart2 += op.Weight;
                        }

                        if (12 < intNO && intNO < 19)
                        {
                            scorePart3 += op.Weight;
                        }

                        if (18 < intNO && intNO < 25)
                        {
                            scorePart4 += op.Weight;
                        }

                        if (24 < intNO && intNO < 31)
                        {
                            scorePart5 += op.Weight;
                        }
                    }
                });
            }

            string[] resultPart1 = new string[] { "生机旺盛质", "偏颇体质" };
            string[] resultPart2 = new string[] { "是", "基本是" };

            if (scorePart1 >= 18)
            {
                if(scorePart2 < 12 && scorePart3 < 12 && scorePart4 < 12 && scorePart5 < 12)
                { 
                    ret = string.Format("{0} {1}", resultPart2[0], resultPart1[0]);

                    resultCode = string.Format("{0}{1}", qn.QuestionnaireID, "01");
                }

                else if (scorePart2 >= 12 && scorePart3 >= 12 && scorePart4 >= 12 && scorePart5 >= 12)
                {
                    ret = string.Format("{0} {1}", resultPart2[1], resultPart1[0]);

                    resultCode = string.Format("{0}{1}", qn.QuestionnaireID, "01");
                }
            }

            if (scorePart2 >= 18 && scorePart3 >= 18 && scorePart4 >= 18 && scorePart5 >= 18)
            {
                if (scorePart1 < 18 && scorePart1 >= 12)
                {
                    ret = string.Format("{0} {1}", resultPart2[1], resultPart1[1]);

                    resultCode = string.Format("{0}{1}", qn.QuestionnaireID, "02");

                }
                else if (scorePart1 < 12)
                {
                    ret = string.Format("{0} {1}", resultPart2[0], resultPart1[1]);

                    resultCode = string.Format("{0}{1}", qn.QuestionnaireID, "02");
                }
            }

            if (string.IsNullOrEmpty(ret))
            {
                ret = "无法确定基本体质";
            }
            return ret;
        }

        /// <summary>
        /// https://wenku.baidu.com/view/314671f431b765ce050814e1.html
        /// </summary>
        /// <returns></returns>
        public static string resultMessage11(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            int[] sn11 = new int[] { 2,3,4,14};
            int[] sn12 = new int[] { 11,12,13,29};
            int[] sn13 = new int[] { 10,21,26,31};
            int[] sn21 = new int[] { 9,16,28,32};
            int[] sn22 = new int[] { 23,25,27,30};
            int[] sn23 = new int[] { 19,22,24,33};
            int[] sn31 = new int[] { 5,6,7,8};
            int[] sn32 = new int[] { 15,17,18,20};
            int[] sn4 = new int[] { 1,2,4,5,13};

            int sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8, sp9;
            sp1 = sp2 = sp3 = sp4 = sp5 = sp6 = sp7 = sp8 = sp9 = 0;

            string ret = string.Empty;

            if (null != qn)
            {
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        var intNO = Convert.ToInt32(o.key);

                        if (sn11.Contains(intNO)) sp1 += op.Weight;
                        if (sn12.Contains(intNO)) sp2 += op.Weight;
                        if (sn13.Contains(intNO)) sp3 += op.Weight;
                        if (sn21.Contains(intNO)) sp4 += op.Weight;
                        if (sn22.Contains(intNO)) sp5 += op.Weight;
                        if (sn23.Contains(intNO)) sp6 += op.Weight;
                        if (sn31.Contains(intNO)) sp7 += op.Weight;
                        if (sn32.Contains(intNO)) sp8 += op.Weight;
                        if (sn4.Contains(intNO)) sp9 += op.Weight;

                    }
                });
            }

            string[] rp1 = new string[] { "气虚质", "阳虚质", "阴虚质", "痰湿质", "湿热质", "血瘀质", "气郁质", "特禀质", "平和质" };
            string[] rp2 = new string[] { "是", "倾向是","否" };

            if (sp1 + sp2 + sp3 >= 11)
            {
                ret = string.Format("{0} {1}、{2}、{3}", rp2[0], rp1[0], rp1[1], rp1[2]);

                resultCode = qn.QuestionnaireID + "01,";
                resultCode += qn.QuestionnaireID + "02,";
                resultCode += qn.QuestionnaireID + "03";
            }
            if (sp4 + sp5 + sp6 < 11 && sp4 + sp5 + sp6 > 8)
            {
                ret = string.Format("{0} {1}、{2}、{3}", rp2[1], rp1[3], rp1[4], rp1[5]);


                resultCode = qn.QuestionnaireID + "04,";
                resultCode += qn.QuestionnaireID + "05,";
                resultCode += qn.QuestionnaireID + "06";
            }

            if (sp7 + sp8 <= 8)
            {
                ret = string.Format("{0} {1}、{2}", rp2[2], rp1[6], rp1[7]);

            }

            if (sp9 >= 17 && sp1 < 8 && sp2 < 8 && sp3 < 8 && sp4 < 8 && sp5 < 8 && sp6 < 8 && sp7 < 8 && sp8 < 8)
            {
                ret = string.Format("{0} {1}", rp2[0], rp1[8]);

                resultCode = qn.QuestionnaireID + "09";
            }

            if (sp9 >= 17 && sp1 < 10 && (sp2 < 10 && sp3 < 10 && sp4 < 10 && sp5 < 10 && sp6 < 10 && sp7 < 10 && sp8 < 10) && (sp2 > 7 && sp3 > 7 && sp4 > 7 && sp5 > 7 && sp6 > 7 && sp7 > 7 && sp8 > 7))
            {
                ret = string.Format("{0} {1}", rp2[1], rp1[8]);


                resultCode = qn.QuestionnaireID + "09";
            }
            else if (string.IsNullOrEmpty(ret))
            {
                ret = string.Format("{0} {1}", rp2[2], rp1[8]);
            }

            if (string.IsNullOrEmpty(ret))
            {
                ret = "无法确定基本体质";
            }

            return ret; 
        }





        public static string resultMessage12(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            int[] sn1 = new int[] { 1,2, 3, 4, 5,6,7 };
            int[] sn2 = new int[] { sn1[6]+1, sn1[6] + 2, sn1[6] + 3, sn1[6] + 4, sn1[6] + 5, sn1[6] + 6, sn1[6] + 7, sn1[6] + 8 };
            int[] sn3 = new int[] { sn2[7]+1, sn2[7] + 2, sn2[7] + 3, sn2[7] + 4, sn2[7] + 5, sn2[7] + 6, sn2[7] + 7, sn2[7] + 8 };
            int[] sn4 = new int[] { sn3[7]+1, sn3[7] + 2, sn3[7] + 3, sn3[7] + 4, sn3[7] + 5, sn3[7] + 6, sn3[7] + 7, sn3[7] + 8 };
            int[] sn5 = new int[] { sn4[7]+1, sn4[7] + 2, sn4[7] + 3, sn4[7] + 4, sn4[7] + 5, sn4[7] + 6, sn4[7] + 7 };
            int[] sn6 = new int[] { sn5[6]+1, sn5[6] + 2, sn5[6] + 3, sn5[6] + 4, sn5[6] + 5, sn5[6] + 6, sn5[6] + 7 };
            int[] sn7 = new int[] { sn6[6]+1, sn6[6] + 2, sn6[6] + 3, sn6[6] + 4, sn6[6] + 5, sn6[6] + 6, sn6[6] + 7 };
            int[] sn8 = new int[] { sn7[6]+1, sn7[6] + 2, sn7[6] + 3, sn7[6] + 4, sn7[6] + 5, sn7[6] + 6, sn7[6] + 7 };
            int[] sn9 = new int[] { sn8[6]+1, sn8[6] + 2, sn8[6] + 3, sn8[6] + 4, sn8[6] + 5, sn8[6] + 6, sn8[6] + 7, sn8[6] + 8 };

            int sp1, sp2, sp3, sp4, sp5, sp6, sp7, sp8, sp9;
            sp1 = sp2 = sp3 = sp4 = sp5 = sp6 = sp7 = sp8 = sp9 = 0;


            if (null != qn)
            {
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        var intNO = Convert.ToInt32(o.key);

                        if (sn1.Contains(intNO)) sp1 += op.Weight;
                        if (sn2.Contains(intNO)) sp2 += op.Weight;
                        if (sn3.Contains(intNO)) sp3 += op.Weight;
                        if (sn4.Contains(intNO)) sp4 += op.Weight;
                        if (sn5.Contains(intNO)) sp5 += op.Weight;
                        if (sn6.Contains(intNO)) sp6 += op.Weight;
                        if (sn7.Contains(intNO)) sp7 += op.Weight;
                        if (sn8.Contains(intNO)) sp8 += op.Weight;
                        if (sn9.Contains(intNO)) sp9 += op.Weight;

                    }
                });
            }

            sp1 = 100 * (sp1 - sn1.Length) / (sn1.Length * 4);
            sp2 = 100 * (sp2 - sn2.Length) / (sn2.Length * 4);
            sp3 = 100 * (sp3 - sn3.Length) / (sn3.Length * 4);
            sp4 = 100 * (sp4 - sn4.Length) / (sn4.Length * 4);
            sp5 = 100 * (sp5 - sn5.Length) / (sn5.Length * 4);
            sp6 = 100 * (sp6 - sn6.Length) / (sn6.Length * 4);
            sp7 = 100 * (sp7 - sn7.Length) / (sn7.Length * 4);
            sp8 = 100 * (sp8 - sn8.Length) / (sn8.Length * 4);
            sp9 = 100 * (sp9 - sn9.Length) / (sn9.Length * 4);

            string[] rp1 = new string[] {  "阳虚质", "阴虚质","气虚质", "痰湿质", "湿热质", "血瘀质", "特禀质","气郁质", "平和质"  };
            string[] rp2 = new string[] { "是", "基本是", "倾向是", "否" };

            if (sp9 >= 60)
            {
                if (sp1 < 30 && sp2 < 30 && sp3 < 30 && sp4 < 30 && sp5 < 30 && sp6 < 30 && sp7 < 30 && sp8 < 30)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[0]);

                    resultCode = qn.QuestionnaireID + "01";
                }
                else if ((sp1 < 40 && sp2 < 40 && sp3 < 40 && sp4 < 40 && sp5 < 40 && sp6 < 40 && sp7 < 40 && sp8 < 40)
                          && (sp1 > 29 && sp2 > 29 && sp3 > 29 && sp4 > 29 && sp5 > 29 && sp6 > 29 && sp7 > 29 && sp8 > 29))
                {
                    ret = string.Format("{0} {1}", rp2[1], rp1[8]);

                    resultCode = qn.QuestionnaireID + "09";
                }

                else
                {
                    ret = string.Format("{0} {1}", rp2[3], rp1[8]);

                }

            }

            if (string.IsNullOrEmpty(ret))
            {
                if (sp1 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[0]);

                    resultCode = qn.QuestionnaireID + "01";

                }
                if (sp1 < 40 && sp1 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[0]);

                    resultCode = qn.QuestionnaireID + "01";
                }

            }

            if (string.IsNullOrEmpty(ret))
            {
                if (sp2 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[1]);

                    resultCode = qn.QuestionnaireID + "02";
                }
                if (sp2 < 40 && sp2 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[1]);

                    resultCode = qn.QuestionnaireID + "02";
                }

            }
            if (string.IsNullOrEmpty(ret))
            {
                if (sp3 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[2]);

                    resultCode = qn.QuestionnaireID + "03";
                }
                if (sp3 < 40 && sp3 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[2]);

                    resultCode = qn.QuestionnaireID + "03";
                }

            }


            if (string.IsNullOrEmpty(ret))
            {
                if (sp4 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[3]);

                    resultCode = qn.QuestionnaireID + "04";
                }
                if (sp4 < 40 && sp4 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[3]);

                    resultCode = qn.QuestionnaireID + "04";
                }

            }
            if (string.IsNullOrEmpty(ret))
            {
                if (sp5 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[4]);

                    resultCode = qn.QuestionnaireID + "05";
                }
                if (sp5 < 40 && sp5 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[4]);

                    resultCode = qn.QuestionnaireID + "05";

                }

            }

            if (string.IsNullOrEmpty(ret))
            {
                if (sp6 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[5]);

                    resultCode = qn.QuestionnaireID + "06";

                }
                if (sp6 < 40 && sp6 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[5]);

                    resultCode = qn.QuestionnaireID + "06";

                }

            }

            if (string.IsNullOrEmpty(ret))
            {
                if (sp7 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[6]);

                    resultCode = qn.QuestionnaireID + "07";

                }
                if (sp7 < 40 && sp7 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[6]);

                    resultCode = qn.QuestionnaireID + "07";

                }

            }

            if (string.IsNullOrEmpty(ret))
            {
                if (sp8 >= 40)
                {
                    ret = string.Format("{0} {1}", rp2[0], rp1[7]);

                    resultCode = qn.QuestionnaireID + "08";

                }
                if (sp8 < 40 && sp8 > 29)
                {
                    ret = string.Format("{0} {1}", rp2[2], rp1[7]);

                    resultCode = qn.QuestionnaireID + "08";

                }

            }
            if (string.IsNullOrEmpty(ret))
            {
                ret = "无法确定基本体质";
            }

            return ret;
        }

        public static string resultMessage13(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("智商: {0}，{1}", score, score > 140 ? "以上者接近极高才能（国外常把这种人称为“天才”）" :
                                                          score <= 140 && score > 120 ? "很高才能" :
                                                          score <= 120 && score > 110 ? "高才能" :
                                                          score <= 110 && score > 90 ? "正常才能" :
                                                          score <= 90 && score > 80 ? "次正常才能" :
                                                          score <= 80 && score > 70 ? "临界正常才能" :
                                                          score <= 70 && score > 60 ? "轻度智力孱弱" :
                                                          score <= 60 && score > 50 ? "深度智力孱弱" :
                                                          score <= 50 && score > 25 ? "亚白痴" : "白痴"
                                                          );
            }


            return ret;
        }

        public static string resultMessage14(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("{0}", score < 14 ? "完全正常" :
                                                          score > 16 ? "有不同程度的功能下降" :"暂无法确定"
                                                          );
            }


            return ret;
        }


        public static string resultMessage15(Questionnaire qn, JSResult jsResult, out string resultCode)
        {
            resultCode = string.Empty;

            string ret = string.Empty;

            if (null != qn)
            {
                int score = 0;
                jsResult.Options.ForEach(o => {
                    Question q = qn.Questions.FirstOrDefault<Question>(_q => { return _q.NO.Equals(o.key); });

                    if (null != q)
                    {
                        Option op = q.Options[o.value];

                        score += op.Weight;

                    }
                });

                ret = string.Format("公民素质得分：{0} (得分越高公民素质越好，总分97)", score);
            }


            return ret;
        }





        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch 
            {
                //Log exception here
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch 
            {
                //Log exception here
            }

            return objectOut;
        }

               
    }
}
