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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Disables an organizational control policy type in a root. A policy of a certain type
    /// can be attached to entities in a root only if that type is enabled in the root. After
    /// you perform this operation, you no longer can attach policies of the specified type
    /// to that root or to any organizational unit (OU) or account in that root. You can undo
    /// this by using the <a>EnablePolicyType</a> operation.
    /// 
    ///  
    /// <para>
    /// This is an asynchronous request that AWS performs in the background. If you disable
    /// a policy for a root, it still appears enabled for the organization if <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_org_support-all-features.html">all
    /// features</a> are enabled for the organization. AWS recommends that you first use <a>ListRoots</a>
    /// to see the status of policy types for a specified root, and then use this operation.
    /// 
    /// </para><para>
    /// This operation can be called only from the organization's master account.
    /// </para><para>
    ///  To view the status of available policy types in the organization, use <a>DescribeOrganization</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "ORGPolicyType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.Root")]
    [AWSCmdlet("Calls the AWS Organizations DisablePolicyType API operation.", Operation = new[] {"DisablePolicyType"}, SelectReturnType = typeof(Amazon.Organizations.Model.DisablePolicyTypeResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.Root or Amazon.Organizations.Model.DisablePolicyTypeResponse",
        "This cmdlet returns an Amazon.Organizations.Model.Root object.",
        "The service call response (type Amazon.Organizations.Model.DisablePolicyTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableORGPolicyTypeCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The policy type that you want to disable in this root.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Organizations.PolicyType")]
        public Amazon.Organizations.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter RootId
        /// <summary>
        /// <para>
        /// <para>The unique identifier (ID) of the root in which you want to disable a policy type.
        /// You can get the ID from the <a>ListRoots</a> operation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for a root ID string
        /// requires "r-" followed by from 4 to 32 lowercase letters or digits.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RootId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Root'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.DisablePolicyTypeResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.DisablePolicyTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Root";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyType' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RootId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-ORGPolicyType (DisablePolicyType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.DisablePolicyTypeResponse, DisableORGPolicyTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PolicyType = this.PolicyType;
            #if MODULAR
            if (this.PolicyType == null && ParameterWasBound(nameof(this.PolicyType)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RootId = this.RootId;
            #if MODULAR
            if (this.RootId == null && ParameterWasBound(nameof(this.RootId)))
            {
                WriteWarning("You are passing $null as a value for parameter RootId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.Organizations.Model.DisablePolicyTypeRequest();
            
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.RootId != null)
            {
                request.RootId = cmdletContext.RootId;
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
        
        private Amazon.Organizations.Model.DisablePolicyTypeResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.DisablePolicyTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "DisablePolicyType");
            try
            {
                #if DESKTOP
                return client.DisablePolicyType(request);
                #elif CORECLR
                return client.DisablePolicyTypeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Organizations.PolicyType PolicyType { get; set; }
            public System.String RootId { get; set; }
            public System.Func<Amazon.Organizations.Model.DisablePolicyTypeResponse, DisableORGPolicyTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Root;
        }
        
    }
}
