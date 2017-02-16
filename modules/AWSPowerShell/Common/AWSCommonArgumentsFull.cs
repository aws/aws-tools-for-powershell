using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.PowerShell.Common
{
    internal class AWSCommonArgumentsFull : AWSCredentialsArgumentsFull, IAWSCommonArgumentsFull
    {
        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the sendpoint that will be used when calling service operations. Note that 
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = "Basic")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = "Session")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = "AssumeRole")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = "Federated")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = "Credentials")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "RegionOnly")]
        public object Region { get; set; }

        public AWSCommonArgumentsFull(SessionState sessionState) : base(sessionState)
        {
        }
    }
}
