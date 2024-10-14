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
using Amazon.CloudControlApi;
using Amazon.CloudControlApi.Model;

namespace Amazon.PowerShell.Cmdlets.CCA
{
    /// <summary>
    /// Updates the specified property values in the resource.
    /// 
    ///  
    /// <para>
    /// You specify your resource property updates as a list of patch operations contained
    /// in a JSON patch document that adheres to the <a href="https://datatracker.ietf.org/doc/html/rfc6902"><i>RFC 6902 - JavaScript Object Notation (JSON) Patch</i></a> standard.
    /// </para><para>
    /// For details on how Cloud Control API performs resource update operations, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations-update.html">Updating
    /// a resource</a> in the <i>Amazon Web Services Cloud Control API User Guide</i>.
    /// </para><para>
    /// After you have initiated a resource update request, you can monitor the progress of
    /// your request by calling <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/APIReference/API_GetResourceRequestStatus.html">GetResourceRequestStatus</a>
    /// using the <c>RequestToken</c> of the <c>ProgressEvent</c> returned by <c>UpdateResource</c>.
    /// </para><para>
    /// For more information about the properties of a specific resource, refer to the related
    /// topic for the resource in the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-template-resource-type-ref.html">Resource
    /// and property types reference</a> in the <i>CloudFormation Users Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CCAResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudControlApi.Model.ProgressEvent")]
    [AWSCmdlet("Calls the AWS Cloud Control API UpdateResource API operation.", Operation = new[] {"UpdateResource"}, SelectReturnType = typeof(Amazon.CloudControlApi.Model.UpdateResourceResponse))]
    [AWSCmdletOutput("Amazon.CloudControlApi.Model.ProgressEvent or Amazon.CloudControlApi.Model.UpdateResourceResponse",
        "This cmdlet returns an Amazon.CloudControlApi.Model.ProgressEvent object.",
        "The service call response (type Amazon.CloudControlApi.Model.UpdateResourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCAResourceCmdlet : AmazonCloudControlApiClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource.</para><para>You can specify the primary identifier, or any secondary identifier defined for the
        /// resource type in its resource schema. You can only specify one identifier. Primary
        /// identifiers can be specified as a string or JSON; secondary identifiers must be specified
        /// as JSON.</para><para>For compound primary identifiers (that is, one that consists of multiple resource
        /// properties strung together), to specify the primary identifier as a string, list the
        /// property values <i>in the order they are specified</i> in the primary identifier definition,
        /// separated by <c>|</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-identifier.html">Identifying
        /// resources</a> in the <i>Amazon Web Services Cloud Control API User Guide</i>.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter PatchDocument
        /// <summary>
        /// <para>
        /// <para>A JavaScript Object Notation (JSON) document listing the patch operations that represent
        /// the updates to apply to the current resource properties. For details, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations-update.html#resource-operations-update-patch">Composing
        /// the patch document</a> in the <i>Amazon Web Services Cloud Control API User Guide</i>.</para>
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
        public System.String PatchDocument { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role for
        /// Cloud Control API to use when performing this resource operation. The role specified
        /// must have the permissions required for this operation. The necessary permissions for
        /// each event handler are defined in the <c><a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-schema.html#schema-properties-handlers">handlers</a></c> section of the <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-schema.html">resource
        /// type definition schema</a>.</para><para>If you do not specify a role, Cloud Control API uses a temporary session created using
        /// your Amazon Web Services user credentials.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations.html#resource-operations-permissions">Specifying
        /// credentials</a> in the <i>Amazon Web Services Cloud Control API User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the resource type.</para>
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
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter TypeVersionId
        /// <summary>
        /// <para>
        /// <para>For private resource types, the type version to use in this resource operation. If
        /// you do not specify a resource version, CloudFormation uses the default version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeVersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier to ensure the idempotency of the resource request. As a best practice,
        /// specify this token to ensure idempotency, so that Amazon Web Services Cloud Control
        /// API can accurately distinguish between request retries and new resource requests.
        /// You might retry a resource request to ensure that it was successfully received.</para><para>A client token is valid for 36 hours once used. After that, a resource request with
        /// the same client token is treated as a new request.</para><para>If you do not specify a client token, one is generated for inclusion in the request.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations.html#resource-operations-idempotency">Ensuring
        /// resource operation requests are unique</a> in the <i>Amazon Web Services Cloud Control
        /// API User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProgressEvent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudControlApi.Model.UpdateResourceResponse).
        /// Specifying the name of a property of type Amazon.CloudControlApi.Model.UpdateResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProgressEvent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCAResource (UpdateResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudControlApi.Model.UpdateResourceResponse, UpdateCCAResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatchDocument = this.PatchDocument;
            #if MODULAR
            if (this.PatchDocument == null && ParameterWasBound(nameof(this.PatchDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter PatchDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.TypeName = this.TypeName;
            #if MODULAR
            if (this.TypeName == null && ParameterWasBound(nameof(this.TypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TypeVersionId = this.TypeVersionId;
            
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
            var request = new Amazon.CloudControlApi.Model.UpdateResourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.PatchDocument != null)
            {
                request.PatchDocument = cmdletContext.PatchDocument;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
            }
            if (cmdletContext.TypeVersionId != null)
            {
                request.TypeVersionId = cmdletContext.TypeVersionId;
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
        
        private Amazon.CloudControlApi.Model.UpdateResourceResponse CallAWSServiceOperation(IAmazonCloudControlApi client, Amazon.CloudControlApi.Model.UpdateResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Control API", "UpdateResource");
            try
            {
                #if DESKTOP
                return client.UpdateResource(request);
                #elif CORECLR
                return client.UpdateResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public System.String PatchDocument { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TypeName { get; set; }
            public System.String TypeVersionId { get; set; }
            public System.Func<Amazon.CloudControlApi.Model.UpdateResourceResponse, UpdateCCAResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProgressEvent;
        }
        
    }
}
