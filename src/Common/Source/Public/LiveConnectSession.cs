namespace Microsoft.Live
{
    using System;
    using System.Collections.Generic;

    public class LiveConnectSession
    {
        private readonly static TimeSpan ExpirationTimeBufferInSec = new TimeSpan(0, 0, 60);

        #region Constructors

        public LiveConnectSession(LiveAuthClient authClient)
        {
            this.AuthClient = authClient;
        }

        public LiveConnectSession()
        {
        }

        #endregion

        #region Properties

        public string AccessToken { get; set; }

        public string AuthenticationToken { get; set; }

#if !WINDOWS_STORE
        public DateTimeOffset Expires { get; set; }

        public string RefreshToken { get; set; }

        public IEnumerable<string> Scopes { get; internal set; }

        internal bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(this.AccessToken) &&
                    this.Expires > DateTimeOffset.UtcNow.Add(ExpirationTimeBufferInSec));
            }
        }
#endif
        internal LiveAuthClient AuthClient { get; set; }

        #endregion
    }
}
