using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class CreateUser : AbstractHandler<Chats>
    {
        public CreateUser(CreateUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.State)
            {
                case State.CreateUsername:      //Crear Usuario con el user

                    request.State = State.CreatePassword;
                    request.Temp.Add(request.Message.Text);
                    request.Channel.SendMessage(request.Id, "Ingrese una contraseña");
                    break;

                case State.CreatePassword:      //Crear Usuario con la contraseña

                    request.State = State.Idle;
                    Session.Instance.AddUser(request.Temp[0].ToString(), request.Message.Text);
                    request.Channel.SendMessage(request.Id, "Usuario Creado\nUsername:\t" + request.Temp[0] + "\nPassword:\t" + new String('*', (request.Message.Text).Length));
                    request.CleanTemp();
                    request.Channel.SendMessage(request.Id, "Elija una de las siguientes opciones:\n\t1-Login\n\t2-CreateUser");
                    break;
            }
        }
    }
}