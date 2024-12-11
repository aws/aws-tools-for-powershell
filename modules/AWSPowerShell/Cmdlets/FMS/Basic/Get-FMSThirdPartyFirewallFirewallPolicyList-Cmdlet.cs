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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Retrieves a list of all of the third-party firewall policies that are associated with
    /// the third-party firewall administrator's account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "FMSThirdPartyFirewallFirewallPolicyList")]
    [OutputType("Amazon.FMS.Model.ThirdPartyFirewallFirewallPolicy")]
    [AWSCmdlet("Calls the Firewall Management Service ListThirdPartyFirewallFirewallPolicies API operation.", Operation = new[] {"ListThirdPartyFirewallFirewallPolicies"}, SelectReturnType = typeof(Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.ThirdPartyFirewallFirewallPolicy or Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse",
        "This cmdlet returns a collection of Amazon.FMS.Model.ThirdPartyFirewallFirewallPolicy objects.",
        "The service call response (type Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetFMSThirdPartyFirewallFirewallPolicyListCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ThirdPartyFirewall
        /// <summary>
        /// <para>
        /// <para>The name of the third-party firewall vendor.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FMS.ThirdPartyFirewall")]
        public Amazon.FMS.ThirdPartyFirewall ThirdPartyFirewall { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of third-party firewall policies that you want Firewall Manager
        /// to return. If the specified third-party firewall vendor is associated with more than
        /// <c>MaxResults</c> firewall policies, the response includes a <c>NextToken</c> element.
        /// <c>NextToken</c> contains an encrypted token that identifies the first third-party
        /// firewall policies that Firewall Manager will return if you submit another request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response included a <c>NextToken</c> element, the specified third-party
        /// firewall vendor is associated with more third-party firewall policies. To get more
        /// third-party firewall policies, submit another <c>ListThirdPartyFirewallFirewallPoliciesRequest</c>
        /// request.</para><para> For the value of <c>NextToken</c>, specify the value of <c>NextToken</c> from the
        /// previous response. If the previous response didn't include a <c>NextToken</c> element,
        /// there are no more third-party firewall policies to get. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ThirdPartyFirewallFirewallPolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ThirdPartyFirewallFirewallPolicies";
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
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse, GetFMSThirdPartyFirewallFirewallPolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (this.MaxResult == null && ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxResult which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ThirdPartyFirewall = this.ThirdPartyFirewall;
            #if MODULAR
            if (this.ThirdPartyFirewall == null && ParameterWasBound(nameof(this.ThirdPartyFirewall)))
            {
                WriteWarning("You are passing $null as a value for parameter ThirdPartyFirewall which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ThirdPartyFirewall != null)
            {
                request.ThirdPartyFirewall = cmdletContext.ThirdPartyFirewall;
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
        
        private Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "ListThirdPartyFirewallFirewallPolicies");
            try
            {
                #if DESKTOP
                return client.ListThirdPartyFirewallFirewallPolicies(request);
                #elif CORECLR
                return client.ListThirdPartyFirewallFirewallPoliciesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.FMS.ThirdPartyFirewall ThirdPartyFirewall { get; set; }
            public System.Func<Amazon.FMS.Model.ListThirdPartyFirewallFirewallPoliciesResponse, GetFMSThirdPartyFirewallFirewallPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ThirdPartyFirewallFirewallPolicies;
        }
        
    }
}
