/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets a list of the VPCs that were created by other accounts and that can be associated
    /// with a specified hosted zone because you've submitted one or more <c>CreateVPCAssociationAuthorization</c>
    /// requests. 
    /// 
    ///  
    /// <para>
    /// The response includes a <c>VPCs</c> element with a <c>VPC</c> child element for each
    /// VPC that can be associated with the hosted zone.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53VPCAssociationAuthorizationList")]
    [OutputType("Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListVPCAssociationAuthorizations API operation.", Operation = new[] {"ListVPCAssociationAuthorizations"}, SelectReturnType = typeof(Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse",
        "This cmdlet returns an Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse object containing multiple properties."
    )]
    public partial class GetR53VPCAssociationAuthorizationListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone for which you want a list of VPCs that can be associated
        /// with the hosted zone.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Id")]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para><i>Optional</i>: An integer that specifies the maximum number of VPCs that you want
        /// Amazon Route 53 to return. If you don't specify a value for <c>MaxResults</c>, Route
        /// 53 returns up to 50 VPCs per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.String MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para><i>Optional</i>: If a response includes a <c>NextToken</c> element, there are more
        /// VPCs that can be associated with the specified hosted zone. To get the next page of
        /// results, submit another request, and include the value of <c>NextToken</c> from the
        /// response in the <c>nexttoken</c> parameter in another <c>ListVPCAssociationAuthorizations</c>
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse, GetR53VPCAssociationAuthorizationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.MaxResult = this.MaxResult;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.ListVPCAssociationAuthorizationsRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListVPCAssociationAuthorizationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListVPCAssociationAuthorizations");
            try
            {
                #if DESKTOP
                return client.ListVPCAssociationAuthorizations(request);
                #elif CORECLR
                return client.ListVPCAssociationAuthorizationsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String HostedZoneId { get; set; }
            public System.String NextToken { get; set; }
            public System.String MaxResult { get; set; }
            public System.Func<Amazon.Route53.Model.ListVPCAssociationAuthorizationsResponse, GetR53VPCAssociationAuthorizationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
