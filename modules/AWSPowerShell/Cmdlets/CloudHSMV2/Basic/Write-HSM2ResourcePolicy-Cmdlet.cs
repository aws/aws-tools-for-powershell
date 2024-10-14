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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Creates or updates an CloudHSM resource policy. A resource policy helps you to define
    /// the IAM entity (for example, an Amazon Web Services account) that can manage your
    /// CloudHSM resources. The following resources support CloudHSM resource policies: 
    /// 
    ///  <ul><li><para>
    ///  Backup - The resource policy allows you to describe the backup and restore a cluster
    /// from the backup in another Amazon Web Services account.
    /// </para></li></ul><para>
    /// In order to share a backup, it must be in a 'READY' state and you must own it.
    /// </para><important><para>
    /// While you can share a backup using the CloudHSM PutResourcePolicy operation, we recommend
    /// using Resource Access Manager (RAM) instead. Using RAM provides multiple benefits
    /// as it creates the policy for you, allows multiple resources to be shared at one time,
    /// and increases the discoverability of shared resources. If you use PutResourcePolicy
    /// and want consumers to be able to describe the backups you share with them, you must
    /// promote the backup to a standard RAM Resource Share using the RAM PromoteResourceShareCreatedFromPolicy
    /// API operation. For more information, see <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/sharing.html">
    /// Working with shared backups</a> in the CloudHSM User Guide
    /// </para></important><para><b>Cross-account use:</b> No. You cannot perform this operation on an CloudHSM resource
    /// in a different Amazon Web Services account.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "HSM2ResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudHSMV2.Model.PutResourcePolicyResponse")]
    [AWSCmdlet("Calls the AWS CloudHSM V2 PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"}, SelectReturnType = typeof(Amazon.CloudHSMV2.Model.PutResourcePolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudHSMV2.Model.PutResourcePolicyResponse",
        "This cmdlet returns an Amazon.CloudHSMV2.Model.PutResourcePolicyResponse object containing multiple properties."
    )]
    public partial class WriteHSM2ResourcePolicyCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The policy you want to associate with a resource. </para><para>For an example policy, see <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/sharing.html">
        /// Working with shared backups</a> in the CloudHSM User Guide</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the resource to which you want to attach a policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudHSMV2.Model.PutResourcePolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudHSMV2.Model.PutResourcePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-HSM2ResourcePolicy (PutResourcePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudHSMV2.Model.PutResourcePolicyResponse, WriteHSM2ResourcePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Policy = this.Policy;
            context.ResourceArn = this.ResourceArn;
            
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
            var request = new Amazon.CloudHSMV2.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.CloudHSMV2.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudHSM V2", "PutResourcePolicy");
            try
            {
                #if DESKTOP
                return client.PutResourcePolicy(request);
                #elif CORECLR
                return client.PutResourcePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Policy { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.CloudHSMV2.Model.PutResourcePolicyResponse, WriteHSM2ResourcePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
