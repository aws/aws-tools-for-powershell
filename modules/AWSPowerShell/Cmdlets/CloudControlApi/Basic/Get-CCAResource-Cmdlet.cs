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
using Amazon.CloudControlApi;
using Amazon.CloudControlApi.Model;

namespace Amazon.PowerShell.Cmdlets.CCA
{
    /// <summary>
    /// Returns information about the current state of the specified resource. For details,
    /// see <a href="https://docs.aws.amazon.com/cloudcontrolapi/latest/userguide/resource-operations-read.html">Reading
    /// a resource's current state</a>.
    /// 
    ///  
    /// <para>
    /// You can use this action to return information about an existing resource in your account
    /// and Amazon Web Services Region, whether those resources were provisioned using Cloud
    /// Control API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CCAResource")]
    [OutputType("Amazon.CloudControlApi.Model.GetResourceResponse")]
    [AWSCmdlet("Calls the AWS Cloud Control API GetResource API operation.", Operation = new[] {"GetResource"}, SelectReturnType = typeof(Amazon.CloudControlApi.Model.GetResourceResponse))]
    [AWSCmdletOutput("Amazon.CloudControlApi.Model.GetResourceResponse",
        "This cmdlet returns an Amazon.CloudControlApi.Model.GetResourceResponse object containing multiple properties."
    )]
    public partial class GetCCAResourceCmdlet : AmazonCloudControlApiClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudControlApi.Model.GetResourceResponse).
        /// Specifying the name of a property of type Amazon.CloudControlApi.Model.GetResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudControlApi.Model.GetResourceResponse, GetCCAResourceCmdlet>(Select) ??
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
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudControlApi.Model.GetResourceRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.CloudControlApi.Model.GetResourceResponse CallAWSServiceOperation(IAmazonCloudControlApi client, Amazon.CloudControlApi.Model.GetResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Control API", "GetResource");
            try
            {
                #if DESKTOP
                return client.GetResource(request);
                #elif CORECLR
                return client.GetResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.String RoleArn { get; set; }
            public System.String TypeName { get; set; }
            public System.String TypeVersionId { get; set; }
            public System.Func<Amazon.CloudControlApi.Model.GetResourceResponse, GetCCAResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
