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
        private const string RegionOnlySet = "RegionOnly";

        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the sendpoint that will be used when calling service operations. Note that
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFull.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFull.BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFull.AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFull.FederatedSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AWSCredentialsArgumentsFull.AWSCredentialsSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = RegionOnlySet)]
        public object Region { get; set; }

        public AWSCommonArgumentsFull(SessionState sessionState) : base(sessionState)
        {
        }
    }
}
