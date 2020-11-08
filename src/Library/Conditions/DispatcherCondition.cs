using System;

namespace Bankbot
{
    public class DispatcherCondition : ICondition<IMessage>
    {
        public bool IsSatisfied(IMessage request)
        {
            Data data = Data.Empty;
            return AllChats.Instance.ChatsDictionary.TryGetValue(request.id,out data)
                && AllCommands.Instance.CommandsList.Contains((String) data.DataDictionary["LastCommand"])
                && (String) data.DataDictionary["LastCommand"] != String.Empty
            ;
        }
    }
}