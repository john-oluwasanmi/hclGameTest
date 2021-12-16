using hcl.game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace hcl.game.Services
{
    public class SessionService : ISessionService
    {
        public Session DetermineSessionWinner(Session session)
        {
            if (session.Games.Count < 3)
            {
                session.SessionOverallWinner = null;
            }

            if (session.Games.Count > 3)
            {
                throw new InvalidOperationException("Sessions cannot be more than 3");
            }

            if (session.Games.Count == 3)
            {
                var sessionWinner = session.Games.GroupBy(r => r.GameWinnner.Id)
                                        .First(grouping => grouping.Count() > 1)
                                        .Select(r => r.GameWinnner)
                                        .First();

                session.SessionOverallWinner = sessionWinner;
            }

            return session;
        }
    }
}
