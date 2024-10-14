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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates the content and status of IP rules. Traffic from a source is allowed when
    /// the source satisfies either the <c>IpRestrictionRule</c>, <c>VpcIdRestrictionRule</c>,
    /// or <c>VpcEndpointIdRestrictionRule</c>. To use this operation, you must provide the
    /// entire map of rules. You can use the <c>DescribeIpRestriction</c> operation to get
    /// the current rule map.
    /// </summary>
    [Cmdlet("Update", "QSIpRestriction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateIpRestriction API operation.", Operation = new[] {"UpdateIpRestriction"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateIpRestrictionResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.UpdateIpRestrictionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.UpdateIpRestrictionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQSIpRestrictionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the IP rules.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether IP rules are turned on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter IpRestrictionRuleMap
        /// <summary>
        /// <para>
        /// <para>A map that describes the updated IP rules with CIDR ranges and descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable IpRestrictionRuleMap { get; set; }
        #endregion
        
        #region Parameter VpcEndpointIdRestrictionRuleMap
        /// <summary>
        /// <para>
        /// <para>A map of allowed VPC endpoint IDs and their corresponding rule descriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable VpcEndpointIdRestrictionRuleMap { get; set; }
        #endregion
        
        #region Parameter VpcIdRestrictionRuleMap
        /// <summary>
        /// <para>
        /// <para>A map of VPC IDs and their corresponding rules. When you configure this parameter,
        /// traffic from all VPC endpoints that are present in the specified VPC is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable VpcIdRestrictionRuleMap { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AwsAccountId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateIpRestrictionResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateIpRestrictionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AwsAccountId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSIpRestriction (UpdateIpRestriction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateIpRestrictionResponse, UpdateQSIpRestrictionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enabled = this.Enabled;
            if (this.IpRestrictionRuleMap != null)
            {
                context.IpRestrictionRuleMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.IpRestrictionRuleMap.Keys)
                {
                    context.IpRestrictionRuleMap.Add((String)hashKey, (System.String)(this.IpRestrictionRuleMap[hashKey]));
                }
            }
            if (this.VpcEndpointIdRestrictionRuleMap != null)
            {
                context.VpcEndpointIdRestrictionRuleMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.VpcEndpointIdRestrictionRuleMap.Keys)
                {
                    context.VpcEndpointIdRestrictionRuleMap.Add((String)hashKey, (System.String)(this.VpcEndpointIdRestrictionRuleMap[hashKey]));
                }
            }
            if (this.VpcIdRestrictionRuleMap != null)
            {
                context.VpcIdRestrictionRuleMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.VpcIdRestrictionRuleMap.Keys)
                {
                    context.VpcIdRestrictionRuleMap.Add((String)hashKey, (System.String)(this.VpcIdRestrictionRuleMap[hashKey]));
                }
            }
            
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
            var request = new Amazon.QuickSight.Model.UpdateIpRestrictionRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.IpRestrictionRuleMap != null)
            {
                request.IpRestrictionRuleMap = cmdletContext.IpRestrictionRuleMap;
            }
            if (cmdletContext.VpcEndpointIdRestrictionRuleMap != null)
            {
                request.VpcEndpointIdRestrictionRuleMap = cmdletContext.VpcEndpointIdRestrictionRuleMap;
            }
            if (cmdletContext.VpcIdRestrictionRuleMap != null)
            {
                request.VpcIdRestrictionRuleMap = cmdletContext.VpcIdRestrictionRuleMap;
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
        
        private Amazon.QuickSight.Model.UpdateIpRestrictionResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateIpRestrictionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateIpRestriction");
            try
            {
                #if DESKTOP
                return client.UpdateIpRestriction(request);
                #elif CORECLR
                return client.UpdateIpRestrictionAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.Boolean? Enabled { get; set; }
            public Dictionary<System.String, System.String> IpRestrictionRuleMap { get; set; }
            public Dictionary<System.String, System.String> VpcEndpointIdRestrictionRuleMap { get; set; }
            public Dictionary<System.String, System.String> VpcIdRestrictionRuleMap { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateIpRestrictionResponse, UpdateQSIpRestrictionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AwsAccountId;
        }
        
    }
}
