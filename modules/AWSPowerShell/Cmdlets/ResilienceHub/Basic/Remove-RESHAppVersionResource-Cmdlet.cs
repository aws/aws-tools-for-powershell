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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Deletes a resource from the Resilience Hub application.
    /// 
    ///  <note><ul><li><para>
    /// You can only delete a manually added resource. To exclude non-manually added resources,
    /// use the <c>UpdateAppVersionResource</c> API.
    /// </para></li><li><para>
    /// This action has no effect outside Resilience Hub.
    /// </para></li><li><para>
    /// This API updates the Resilience Hub application draft version. To use this resource
    /// for running resiliency assessments, you must publish the Resilience Hub application
    /// using the <c>PublishAppVersion</c> API.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Remove", "RESHAppVersionResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub DeleteAppVersionResource API operation.", Operation = new[] {"DeleteAppVersionResource"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRESHAppVersionResourceCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<c>partition</c>:resiliencehub:<c>region</c>:<c>account</c>:app/<c>app-id</c>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
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
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services account that owns the physical resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter AwsRegion
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services region that owns the physical resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsRegion { get; set; }
        #endregion
        
        #region Parameter LogicalResourceId_EksSourceName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Elastic Kubernetes Service cluster and namespace this resource
        /// belongs to.</para><note><para>This parameter accepts values in "eks-cluster/namespace" format.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId_EksSourceName { get; set; }
        #endregion
        
        #region Parameter LogicalResourceId_Identifier
        /// <summary>
        /// <para>
        /// <para>Identifier of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId_Identifier { get; set; }
        #endregion
        
        #region Parameter LogicalResourceId_LogicalStackName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudFormation stack this resource belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId_LogicalStackName { get; set; }
        #endregion
        
        #region Parameter PhysicalResourceId
        /// <summary>
        /// <para>
        /// <para>Physical identifier of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PhysicalResourceId { get; set; }
        #endregion
        
        #region Parameter LogicalResourceId_ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resource group that this resource belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId_ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>Name of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter LogicalResourceId_TerraformSourceName
        /// <summary>
        /// <para>
        /// <para> The name of the Terraform S3 state file this resource belongs to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogicalResourceId_TerraformSourceName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Used for an idempotency token. A client token is a unique, case-sensitive string of
        /// up to 64 ASCII characters. You should not reuse the same client token for other API
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RESHAppVersionResource (DeleteAppVersionResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse, RemoveRESHAppVersionResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppArn = this.AppArn;
            #if MODULAR
            if (this.AppArn == null && ParameterWasBound(nameof(this.AppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            context.AwsRegion = this.AwsRegion;
            context.ClientToken = this.ClientToken;
            context.LogicalResourceId_EksSourceName = this.LogicalResourceId_EksSourceName;
            context.LogicalResourceId_Identifier = this.LogicalResourceId_Identifier;
            context.LogicalResourceId_LogicalStackName = this.LogicalResourceId_LogicalStackName;
            context.LogicalResourceId_ResourceGroupName = this.LogicalResourceId_ResourceGroupName;
            context.LogicalResourceId_TerraformSourceName = this.LogicalResourceId_TerraformSourceName;
            context.PhysicalResourceId = this.PhysicalResourceId;
            context.ResourceName = this.ResourceName;
            
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
            var request = new Amazon.ResilienceHub.Model.DeleteAppVersionResourceRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.AwsRegion != null)
            {
                request.AwsRegion = cmdletContext.AwsRegion;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate LogicalResourceId
            var requestLogicalResourceIdIsNull = true;
            request.LogicalResourceId = new Amazon.ResilienceHub.Model.LogicalResourceId();
            System.String requestLogicalResourceId_logicalResourceId_EksSourceName = null;
            if (cmdletContext.LogicalResourceId_EksSourceName != null)
            {
                requestLogicalResourceId_logicalResourceId_EksSourceName = cmdletContext.LogicalResourceId_EksSourceName;
            }
            if (requestLogicalResourceId_logicalResourceId_EksSourceName != null)
            {
                request.LogicalResourceId.EksSourceName = requestLogicalResourceId_logicalResourceId_EksSourceName;
                requestLogicalResourceIdIsNull = false;
            }
            System.String requestLogicalResourceId_logicalResourceId_Identifier = null;
            if (cmdletContext.LogicalResourceId_Identifier != null)
            {
                requestLogicalResourceId_logicalResourceId_Identifier = cmdletContext.LogicalResourceId_Identifier;
            }
            if (requestLogicalResourceId_logicalResourceId_Identifier != null)
            {
                request.LogicalResourceId.Identifier = requestLogicalResourceId_logicalResourceId_Identifier;
                requestLogicalResourceIdIsNull = false;
            }
            System.String requestLogicalResourceId_logicalResourceId_LogicalStackName = null;
            if (cmdletContext.LogicalResourceId_LogicalStackName != null)
            {
                requestLogicalResourceId_logicalResourceId_LogicalStackName = cmdletContext.LogicalResourceId_LogicalStackName;
            }
            if (requestLogicalResourceId_logicalResourceId_LogicalStackName != null)
            {
                request.LogicalResourceId.LogicalStackName = requestLogicalResourceId_logicalResourceId_LogicalStackName;
                requestLogicalResourceIdIsNull = false;
            }
            System.String requestLogicalResourceId_logicalResourceId_ResourceGroupName = null;
            if (cmdletContext.LogicalResourceId_ResourceGroupName != null)
            {
                requestLogicalResourceId_logicalResourceId_ResourceGroupName = cmdletContext.LogicalResourceId_ResourceGroupName;
            }
            if (requestLogicalResourceId_logicalResourceId_ResourceGroupName != null)
            {
                request.LogicalResourceId.ResourceGroupName = requestLogicalResourceId_logicalResourceId_ResourceGroupName;
                requestLogicalResourceIdIsNull = false;
            }
            System.String requestLogicalResourceId_logicalResourceId_TerraformSourceName = null;
            if (cmdletContext.LogicalResourceId_TerraformSourceName != null)
            {
                requestLogicalResourceId_logicalResourceId_TerraformSourceName = cmdletContext.LogicalResourceId_TerraformSourceName;
            }
            if (requestLogicalResourceId_logicalResourceId_TerraformSourceName != null)
            {
                request.LogicalResourceId.TerraformSourceName = requestLogicalResourceId_logicalResourceId_TerraformSourceName;
                requestLogicalResourceIdIsNull = false;
            }
             // determine if request.LogicalResourceId should be set to null
            if (requestLogicalResourceIdIsNull)
            {
                request.LogicalResourceId = null;
            }
            if (cmdletContext.PhysicalResourceId != null)
            {
                request.PhysicalResourceId = cmdletContext.PhysicalResourceId;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.DeleteAppVersionResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "DeleteAppVersionResource");
            try
            {
                #if DESKTOP
                return client.DeleteAppVersionResource(request);
                #elif CORECLR
                return client.DeleteAppVersionResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String AwsRegion { get; set; }
            public System.String ClientToken { get; set; }
            public System.String LogicalResourceId_EksSourceName { get; set; }
            public System.String LogicalResourceId_Identifier { get; set; }
            public System.String LogicalResourceId_LogicalStackName { get; set; }
            public System.String LogicalResourceId_ResourceGroupName { get; set; }
            public System.String LogicalResourceId_TerraformSourceName { get; set; }
            public System.String PhysicalResourceId { get; set; }
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.DeleteAppVersionResourceResponse, RemoveRESHAppVersionResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
