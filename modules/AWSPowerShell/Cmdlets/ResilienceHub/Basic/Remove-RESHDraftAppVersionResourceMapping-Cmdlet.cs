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
    /// Removes resource mappings from a draft application version.
    /// </summary>
    [Cmdlet("Remove", "RESHDraftAppVersionResourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub RemoveDraftAppVersionResourceMappings API operation.", Operation = new[] {"RemoveDraftAppVersionResourceMappings"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRESHDraftAppVersionResourceMappingCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<code>partition</code>:resiliencehub:<code>region</code>:<code>account</code>:app/<code>app-id</code>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>AWS General Reference</i> guide.</para>
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
        
        #region Parameter AppRegistryAppName
        /// <summary>
        /// <para>
        /// <para>The names of the registered applications you want to remove from the resource mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppRegistryAppNames")]
        public System.String[] AppRegistryAppName { get; set; }
        #endregion
        
        #region Parameter EksSourceName
        /// <summary>
        /// <para>
        /// <para>The names of the Amazon Elastic Kubernetes Service clusters and namespaces you want
        /// to remove from the resource mappings.</para><note><para>This parameter accepts values in "eks-cluster/namespace" format.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EksSourceNames")]
        public System.String[] EksSourceName { get; set; }
        #endregion
        
        #region Parameter LogicalStackName
        /// <summary>
        /// <para>
        /// <para>The names of the CloudFormation stacks you want to remove from the resource mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalStackNames")]
        public System.String[] LogicalStackName { get; set; }
        #endregion
        
        #region Parameter ResourceGroupName
        /// <summary>
        /// <para>
        /// <para>The names of the resource groups you want to remove from the resource mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceGroupNames")]
        public System.String[] ResourceGroupName { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The names of the resources you want to remove from the resource mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceNames")]
        public System.String[] ResourceName { get; set; }
        #endregion
        
        #region Parameter TerraformSourceName
        /// <summary>
        /// <para>
        /// <para>The names of the Terraform sources you want to remove from the resource mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TerraformSourceNames")]
        public System.String[] TerraformSourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RESHDraftAppVersionResourceMapping (RemoveDraftAppVersionResourceMappings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse, RemoveRESHDraftAppVersionResourceMappingCmdlet>(Select) ??
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
            if (this.AppRegistryAppName != null)
            {
                context.AppRegistryAppName = new List<System.String>(this.AppRegistryAppName);
            }
            if (this.EksSourceName != null)
            {
                context.EksSourceName = new List<System.String>(this.EksSourceName);
            }
            if (this.LogicalStackName != null)
            {
                context.LogicalStackName = new List<System.String>(this.LogicalStackName);
            }
            if (this.ResourceGroupName != null)
            {
                context.ResourceGroupName = new List<System.String>(this.ResourceGroupName);
            }
            if (this.ResourceName != null)
            {
                context.ResourceName = new List<System.String>(this.ResourceName);
            }
            if (this.TerraformSourceName != null)
            {
                context.TerraformSourceName = new List<System.String>(this.TerraformSourceName);
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
            var request = new Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.AppRegistryAppName != null)
            {
                request.AppRegistryAppNames = cmdletContext.AppRegistryAppName;
            }
            if (cmdletContext.EksSourceName != null)
            {
                request.EksSourceNames = cmdletContext.EksSourceName;
            }
            if (cmdletContext.LogicalStackName != null)
            {
                request.LogicalStackNames = cmdletContext.LogicalStackName;
            }
            if (cmdletContext.ResourceGroupName != null)
            {
                request.ResourceGroupNames = cmdletContext.ResourceGroupName;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceNames = cmdletContext.ResourceName;
            }
            if (cmdletContext.TerraformSourceName != null)
            {
                request.TerraformSourceNames = cmdletContext.TerraformSourceName;
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
        
        private Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "RemoveDraftAppVersionResourceMappings");
            try
            {
                #if DESKTOP
                return client.RemoveDraftAppVersionResourceMappings(request);
                #elif CORECLR
                return client.RemoveDraftAppVersionResourceMappingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AppRegistryAppName { get; set; }
            public List<System.String> EksSourceName { get; set; }
            public List<System.String> LogicalStackName { get; set; }
            public List<System.String> ResourceGroupName { get; set; }
            public List<System.String> ResourceName { get; set; }
            public List<System.String> TerraformSourceName { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.RemoveDraftAppVersionResourceMappingsResponse, RemoveRESHDraftAppVersionResourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
