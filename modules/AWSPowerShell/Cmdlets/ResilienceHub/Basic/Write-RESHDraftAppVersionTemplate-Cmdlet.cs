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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Adds or updates the app template for an Resilience Hub application draft version.
    /// </summary>
    [Cmdlet("Write", "RESHDraftAppVersionTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub PutDraftAppVersionTemplate API operation.", Operation = new[] {"PutDraftAppVersionTemplate"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse object containing multiple properties."
    )]
    public partial class WriteRESHDraftAppVersionTemplateCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
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
        
        #region Parameter AppTemplateBody
        /// <summary>
        /// <para>
        /// <para>A JSON string that provides information about your application structure. To learn
        /// more about the <c>appTemplateBody</c> template, see the sample template provided in
        /// the <i>Examples</i> section.</para><para>The <c>appTemplateBody</c> JSON string has the following structure:</para><ul><li><para><b><c>resources</c></b></para><para>The list of logical resources that must be included in the Resilience Hub application.</para><para>Type: Array</para><note><para>Don't add the resources that you want to exclude.</para></note><para>Each <c>resources</c> array item includes the following fields:</para><ul><li><para><i><c>logicalResourceId</c></i></para><para>Logical identifier of the resource.</para><para>Type: Object</para><para>Each <c>logicalResourceId</c> object includes the following fields:</para><ul><li><para><c>identifier</c></para><para>Identifier of the resource.</para><para>Type: String</para></li><li><para><c>logicalStackName</c></para><para>The name of the CloudFormation stack this resource belongs to.</para><para>Type: String</para></li><li><para><c>resourceGroupName</c></para><para>The name of the resource group this resource belongs to.</para><para>Type: String</para></li><li><para><c>terraformSourceName</c></para><para>The name of the Terraform S3 state file this resource belongs to.</para><para>Type: String</para></li><li><para><c>eksSourceName</c></para><para>Name of the Amazon Elastic Kubernetes Service cluster and namespace this resource
        /// belongs to.</para><note><para>This parameter accepts values in "eks-cluster/namespace" format.</para></note><para>Type: String</para></li></ul></li><li><para><i><c>type</c></i></para><para>The type of resource.</para><para>Type: string</para></li><li><para><i><c>name</c></i></para><para>The name of the resource.</para><para>Type: String</para></li><li><para><c>additionalInfo</c></para><para>Additional configuration parameters for an Resilience Hub application. If you want
        /// to implement <c>additionalInfo</c> through the Resilience Hub console rather than
        /// using an API call, see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/app-config-param.html">Configure
        /// the application configuration parameters</a>.</para><note><para>Currently, this parameter accepts a key-value mapping (in a string format) of only
        /// one failover region and one associated account.</para><para>Key: <c>"failover-regions"</c></para><para>Value: <c>"[{"region":"&lt;REGION&gt;", "accounts":[{"id":"&lt;ACCOUNT_ID&gt;"}]}]"</c></para></note></li></ul></li><li><para><b><c>appComponents</c></b></para><para>List of Application Components that this resource belongs to. If an Application Component
        /// is not part of the Resilience Hub application, it will be added.</para><para>Type: Array</para><para>Each <c>appComponents</c> array item includes the following fields:</para><ul><li><para><c>name</c></para><para>Name of the Application Component.</para><para>Type: String</para></li><li><para><c>type</c></para><para>Type of Application Component. For more information about the types of Application
        /// Component, see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/AppComponent.grouping.html">Grouping
        /// resources in an AppComponent</a>.</para><para>Type: String</para></li><li><para><c>resourceNames</c></para><para>The list of included resources that are assigned to the Application Component.</para><para>Type: Array of strings</para></li><li><para><c>additionalInfo</c></para><para>Additional configuration parameters for an Resilience Hub application. If you want
        /// to implement <c>additionalInfo</c> through the Resilience Hub console rather than
        /// using an API call, see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/app-config-param.html">Configure
        /// the application configuration parameters</a>.</para><note><para>Currently, this parameter accepts a key-value mapping (in a string format) of only
        /// one failover region and one associated account.</para><para>Key: <c>"failover-regions"</c></para><para>Value: <c>"[{"region":"&lt;REGION&gt;", "accounts":[{"id":"&lt;ACCOUNT_ID&gt;"}]}]"</c></para></note></li></ul></li><li><para><b><c>excludedResources</c></b></para><para>The list of logical resource identifiers to be excluded from the application.</para><para>Type: Array</para><note><para>Don't add the resources that you want to include.</para></note><para>Each <c>excludedResources</c> array item includes the following fields:</para><ul><li><para><i><c>logicalResourceIds</c></i></para><para>Logical identifier of the resource.</para><para>Type: Object</para><note><para>You can configure only one of the following fields:</para><ul><li><para><c>logicalStackName</c></para></li><li><para><c>resourceGroupName</c></para></li><li><para><c>terraformSourceName</c></para></li><li><para><c>eksSourceName</c></para></li></ul></note><para>Each <c>logicalResourceIds</c> object includes the following fields:</para><ul><li><para><c>identifier</c></para><para>Identifier of the resource.</para><para>Type: String</para></li><li><para><c>logicalStackName</c></para><para>The name of the CloudFormation stack this resource belongs to.</para><para>Type: String</para></li><li><para><c>resourceGroupName</c></para><para>The name of the resource group this resource belongs to.</para><para>Type: String</para></li><li><para><c>terraformSourceName</c></para><para>The name of the Terraform S3 state file this resource belongs to.</para><para>Type: String</para></li><li><para><c>eksSourceName</c></para><para>Name of the Amazon Elastic Kubernetes Service cluster and namespace this resource
        /// belongs to.</para><note><para>This parameter accepts values in "eks-cluster/namespace" format.</para></note><para>Type: String</para></li></ul></li></ul></li><li><para><b><c>version</c></b></para><para>Resilience Hub application version.</para></li><li><para><c>additionalInfo</c></para><para>Additional configuration parameters for an Resilience Hub application. If you want
        /// to implement <c>additionalInfo</c> through the Resilience Hub console rather than
        /// using an API call, see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/app-config-param.html">Configure
        /// the application configuration parameters</a>.</para><note><para>Currently, this parameter accepts a key-value mapping (in a string format) of only
        /// one failover region and one associated account.</para><para>Key: <c>"failover-regions"</c></para><para>Value: <c>"[{"region":"&lt;REGION&gt;", "accounts":[{"id":"&lt;ACCOUNT_ID&gt;"}]}]"</c></para></note></li></ul>
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
        public System.String AppTemplateBody { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-RESHDraftAppVersionTemplate (PutDraftAppVersionTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse, WriteRESHDraftAppVersionTemplateCmdlet>(Select) ??
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
            context.AppTemplateBody = this.AppTemplateBody;
            #if MODULAR
            if (this.AppTemplateBody == null && ParameterWasBound(nameof(this.AppTemplateBody)))
            {
                WriteWarning("You are passing $null as a value for parameter AppTemplateBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.AppTemplateBody != null)
            {
                request.AppTemplateBody = cmdletContext.AppTemplateBody;
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
        
        private Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "PutDraftAppVersionTemplate");
            try
            {
                #if DESKTOP
                return client.PutDraftAppVersionTemplate(request);
                #elif CORECLR
                return client.PutDraftAppVersionTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String AppTemplateBody { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.PutDraftAppVersionTemplateResponse, WriteRESHDraftAppVersionTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
