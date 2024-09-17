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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Configure your function's public-access settings.
    /// 
    ///  
    /// <para>
    /// To control public access to a Lambda function, you can choose whether to allow the
    /// creation of <a href="https://docs.aws.amazon.com/lambda/latest/dg/access-control-resource-based.html">resource-based
    /// policies</a> that allow public access to that function. You can also block public
    /// access to a function, even if it has an existing resource-based policy that allows
    /// it.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMPublicAccessBlockConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.PublicAccessBlockConfig")]
    [AWSCmdlet("Calls the AWS Lambda PutPublicAccessBlockConfig API operation.", Operation = new[] {"PutPublicAccessBlockConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.PublicAccessBlockConfig or Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.PublicAccessBlockConfig object.",
        "The service call response (type Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMPublicAccessBlockConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PublicAccessBlockConfig_BlockPublicPolicy
        /// <summary>
        /// <para>
        /// <para>To block the creation of resource-based policies that would grant public access to
        /// your function, set <c>BlockPublicPolicy</c> to <c>true</c>. To allow the creation
        /// of resource-based policies that would grant public access to your function, set <c>BlockPublicPolicy</c>
        /// to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicAccessBlockConfig_BlockPublicPolicy { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the function you want to configure public-access
        /// settings for. Public-access settings are applied at the function level, so you can't
        /// apply different settings to function versions or aliases.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter PublicAccessBlockConfig_RestrictPublicResource
        /// <summary>
        /// <para>
        /// <para>To block public access to your function, even if its resource-based policy allows
        /// it, set <c>RestrictPublicResource</c> to <c>true</c>. To allow public access to a
        /// function with a resource-based policy that permits it, set <c>RestrictPublicResource</c>
        /// to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicAccessBlockConfig_RestrictPublicResource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PublicAccessBlockConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PublicAccessBlockConfig";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMPublicAccessBlockConfig (PutPublicAccessBlockConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse, WriteLMPublicAccessBlockConfigCmdlet>(Select) ??
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
            context.PublicAccessBlockConfig_BlockPublicPolicy = this.PublicAccessBlockConfig_BlockPublicPolicy;
            context.PublicAccessBlockConfig_RestrictPublicResource = this.PublicAccessBlockConfig_RestrictPublicResource;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.PutPublicAccessBlockConfigRequest();
            
            
             // populate PublicAccessBlockConfig
            var requestPublicAccessBlockConfigIsNull = true;
            request.PublicAccessBlockConfig = new Amazon.Lambda.Model.PublicAccessBlockConfig();
            System.Boolean? requestPublicAccessBlockConfig_publicAccessBlockConfig_BlockPublicPolicy = null;
            if (cmdletContext.PublicAccessBlockConfig_BlockPublicPolicy != null)
            {
                requestPublicAccessBlockConfig_publicAccessBlockConfig_BlockPublicPolicy = cmdletContext.PublicAccessBlockConfig_BlockPublicPolicy.Value;
            }
            if (requestPublicAccessBlockConfig_publicAccessBlockConfig_BlockPublicPolicy != null)
            {
                request.PublicAccessBlockConfig.BlockPublicPolicy = requestPublicAccessBlockConfig_publicAccessBlockConfig_BlockPublicPolicy.Value;
                requestPublicAccessBlockConfigIsNull = false;
            }
            System.Boolean? requestPublicAccessBlockConfig_publicAccessBlockConfig_RestrictPublicResource = null;
            if (cmdletContext.PublicAccessBlockConfig_RestrictPublicResource != null)
            {
                requestPublicAccessBlockConfig_publicAccessBlockConfig_RestrictPublicResource = cmdletContext.PublicAccessBlockConfig_RestrictPublicResource.Value;
            }
            if (requestPublicAccessBlockConfig_publicAccessBlockConfig_RestrictPublicResource != null)
            {
                request.PublicAccessBlockConfig.RestrictPublicResource = requestPublicAccessBlockConfig_publicAccessBlockConfig_RestrictPublicResource.Value;
                requestPublicAccessBlockConfigIsNull = false;
            }
             // determine if request.PublicAccessBlockConfig should be set to null
            if (requestPublicAccessBlockConfigIsNull)
            {
                request.PublicAccessBlockConfig = null;
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
        
        private Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PutPublicAccessBlockConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PutPublicAccessBlockConfig");
            try
            {
                #if DESKTOP
                return client.PutPublicAccessBlockConfig(request);
                #elif CORECLR
                return client.PutPublicAccessBlockConfigAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? PublicAccessBlockConfig_BlockPublicPolicy { get; set; }
            public System.Boolean? PublicAccessBlockConfig_RestrictPublicResource { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.Lambda.Model.PutPublicAccessBlockConfigResponse, WriteLMPublicAccessBlockConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PublicAccessBlockConfig;
        }
        
    }
}
