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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Applies a policy to a container image. We recommend that you call the RAM API CreateResourceShare
    /// (https://docs.aws.amazon.com//ram/latest/APIReference/API_CreateResourceShare.html)
    /// to share resources. If you call the Image Builder API <c>PutContainerImagePolicy</c>,
    /// you must also call the RAM API PromoteResourceShareCreatedFromPolicy (https://docs.aws.amazon.com//ram/latest/APIReference/API_PromoteResourceShareCreatedFromPolicy.html)
    /// in order for the resource to be visible to all principals with whom the resource is
    /// shared.
    /// </summary>
    [Cmdlet("Write", "EC2IBContainerRecipePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder PutContainerRecipePolicy API operation.", Operation = new[] {"PutContainerRecipePolicy"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteEC2IBContainerRecipePolicyCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerRecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the container recipe that this policy should be
        /// applied to.</para>
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
        public System.String ContainerRecipeArn { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The policy to apply to the container recipe.</para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerRecipeArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerRecipeArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContainerRecipeArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContainerRecipeArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContainerRecipeArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContainerRecipeArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EC2IBContainerRecipePolicy (PutContainerRecipePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse, WriteEC2IBContainerRecipePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContainerRecipeArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContainerRecipeArn = this.ContainerRecipeArn;
            #if MODULAR
            if (this.ContainerRecipeArn == null && ParameterWasBound(nameof(this.ContainerRecipeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerRecipeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Imagebuilder.Model.PutContainerRecipePolicyRequest();
            
            if (cmdletContext.ContainerRecipeArn != null)
            {
                request.ContainerRecipeArn = cmdletContext.ContainerRecipeArn;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
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
        
        private Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.PutContainerRecipePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "PutContainerRecipePolicy");
            try
            {
                #if DESKTOP
                return client.PutContainerRecipePolicy(request);
                #elif CORECLR
                return client.PutContainerRecipePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerRecipeArn { get; set; }
            public System.String Policy { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.PutContainerRecipePolicyResponse, WriteEC2IBContainerRecipePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerRecipeArn;
        }
        
    }
}
