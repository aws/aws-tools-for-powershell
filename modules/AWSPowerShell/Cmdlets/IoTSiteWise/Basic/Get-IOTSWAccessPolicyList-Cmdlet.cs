/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Retrieves a paginated list of access policies for an identity (an IAM Identity Center
    /// user, an IAM Identity Center group, or an IAM user) or an IoT SiteWise Monitor resource
    /// (a portal or project).<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "IOTSWAccessPolicyList")]
    [OutputType("Amazon.IoTSiteWise.Model.AccessPolicySummary")]
    [AWSCmdlet("Calls the AWS IoT SiteWise ListAccessPolicies API operation.", Operation = new[] {"ListAccessPolicies"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.AccessPolicySummary or Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse",
        "This cmdlet returns a collection of Amazon.IoTSiteWise.Model.AccessPolicySummary objects.",
        "The service call response (type Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTSWAccessPolicyListCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html">IAM
        /// ARNs</a> in the <i>IAM User Guide</i>. This parameter is required if you specify <c>IAM</c>
        /// for <c>identityType</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamArn { get; set; }
        #endregion
        
        #region Parameter IdentityId
        /// <summary>
        /// <para>
        /// <para>The ID of the identity. This parameter is required if you specify <c>USER</c> or <c>GROUP</c>
        /// for <c>identityType</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityId { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>The type of identity (IAM Identity Center user, IAM Identity Center group, or IAM
        /// user). This parameter is required if you specify <c>identityId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.IdentityType")]
        public Amazon.IoTSiteWise.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource. This parameter is required if you specify <c>resourceType</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource (portal or project). This parameter is required if you specify
        /// <c>resourceId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ResourceType")]
        public Amazon.IoTSiteWise.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for each paginated request.</para><para>Default: 50</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to be used for the next set of paginated results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPolicySummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPolicySummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse, GetIOTSWAccessPolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IamArn = this.IamArn;
            context.IdentityId = this.IdentityId;
            context.IdentityType = this.IdentityType;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IoTSiteWise.Model.ListAccessPoliciesRequest();
            
            if (cmdletContext.IamArn != null)
            {
                request.IamArn = cmdletContext.IamArn;
            }
            if (cmdletContext.IdentityId != null)
            {
                request.IdentityId = cmdletContext.IdentityId;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.ListAccessPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "ListAccessPolicies");
            try
            {
                #if DESKTOP
                return client.ListAccessPolicies(request);
                #elif CORECLR
                return client.ListAccessPoliciesAsync(request).GetAwaiter().GetResult();
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
            public System.String IamArn { get; set; }
            public System.String IdentityId { get; set; }
            public Amazon.IoTSiteWise.IdentityType IdentityType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.IoTSiteWise.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.ListAccessPoliciesResponse, GetIOTSWAccessPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPolicySummaries;
        }
        
    }
}
