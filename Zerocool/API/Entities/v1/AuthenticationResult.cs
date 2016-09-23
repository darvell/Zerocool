using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerocool.API.Entities.v1
{
    public class AuthenticationResult : IStandardRequest
    {
        /// <summary>
        /// User authentication token for authorized player.
        /// </summary>
        public string AuthenticationToken { get; set; }
        public string Autocomplete { get; set; } // TODO: Determine format
        /// <summary>
        /// Associated account email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Background music volume.
        /// </summary>
        public int GUIBgm { get; set; }
        /// <summary>
        /// Sound effects volume.
        /// </summary>
        public int GUISfx { get; set; }
        public bool HasReceivedSurvey { get; set; } // No clue
        /// <summary>
        /// Whether the current user is a gameop. Unless your name is Sean, always no.
        /// </summary>
        public bool IsAdmin { get; set; }
        public bool IsFirstLogin { get; set; }
        public DateTime LastTokenGenerationAt { get; set; }
        public string LastUsername { get; set; }
        public int MaxRetired { get; set; }
        public int MaxUsers { get; set; }
        /// <summary>
        /// Account name. Steam ID on post-release accounts.
        /// </summary>
        public string Name { get; set; }
        public int[] PostViewIds { get; set; }
        /// <summary>
        /// Product key for non-steam versions.
        /// </summary>
        public int ProductKeyId { get; set; }
        /// <summary>
        /// Whether the account has been asked to provide an associated email.
        /// This is not known to be currently in use.
        /// </summary>
        public bool QueriedForEmail { get; set; }
        public string SteamId { get; set; } // This should be an int. Naughty API.
        public int[] SubscribedBoardIds { get; set; }
        public int[] SubscribedPostIds { get; set; }

        public Exception Error { get; set; }

    }
}
