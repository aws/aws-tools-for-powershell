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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Creates an ID namespace object which will help customers provide metadata explaining
    /// their dataset and how to use it. Each ID namespace must have a unique name. To modify
    /// an existing ID namespace, use the UpdateIdNamespace API.
    /// </summary>
    [Cmdlet("New", "ERESIdNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.CreateIdNamespaceResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution CreateIdNamespace API operation.", Operation = new[] {"CreateIdNamespace"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.CreateIdNamespaceResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.CreateIdNamespaceResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.CreateIdNamespaceResponse object containing multiple properties."
    )]
    public partial class NewERESIdNamespaceCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the ID namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdMappingWorkflowProperty
        /// <summary>
        /// <para>
        /// <para>Determines the properties of <c>IdMappingWorflow</c> where this <c>IdNamespace</c>
        /// can be used as a <c>Source</c> or a <c>Target</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdMappingWorkflowProperties")]
        public Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties[] IdMappingWorkflowProperty { get; set; }
        #endregion
        
        #region Parameter IdNamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the ID namespace.</para>
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
        public System.String IdNamespaceName { get; set; }
        #endregion
        
        #region Parameter InputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>InputSource</c> objects, which have the fields <c>InputSourceARN</c>
        /// and <c>SchemaName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EntityResolution.Model.IdNamespaceInputSource[] InputSourceConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. Entity Resolution assumes this role
        /// to access the resources defined in this <c>IdNamespace</c> on your behalf as part
        /// of the workflow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of ID namespace. There are two types: <c>SOURCE</c> and <c>TARGET</c>. </para><para>The <c>SOURCE</c> contains configurations for <c>sourceId</c> data that will be processed
        /// in an ID mapping workflow. </para><para>The <c>TARGET</c> contains a configuration of <c>targetId</c> to which all <c>sourceIds</c>
        /// will resolve to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EntityResolution.IdNamespaceType")]
        public Amazon.EntityResolution.IdNamespaceType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.CreateIdNamespaceResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.CreateIdNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdNamespaceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdNamespaceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdNamespaceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdNamespaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ERESIdNamespace (CreateIdNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.CreateIdNamespaceResponse, NewERESIdNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdNamespaceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.IdMappingWorkflowProperty != null)
            {
                context.IdMappingWorkflowProperty = new List<Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties>(this.IdMappingWorkflowProperty);
            }
            context.IdNamespaceName = this.IdNamespaceName;
            #if MODULAR
            if (this.IdNamespaceName == null && ParameterWasBound(nameof(this.IdNamespaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter IdNamespaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputSourceConfig != null)
            {
                context.InputSourceConfig = new List<Amazon.EntityResolution.Model.IdNamespaceInputSource>(this.InputSourceConfig);
            }
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EntityResolution.Model.CreateIdNamespaceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IdMappingWorkflowProperty != null)
            {
                request.IdMappingWorkflowProperties = cmdletContext.IdMappingWorkflowProperty;
            }
            if (cmdletContext.IdNamespaceName != null)
            {
                request.IdNamespaceName = cmdletContext.IdNamespaceName;
            }
            if (cmdletContext.InputSourceConfig != null)
            {
                request.InputSourceConfig = cmdletContext.InputSourceConfig;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.EntityResolution.Model.CreateIdNamespaceResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.CreateIdNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "CreateIdNamespace");
            try
            {
                #if DESKTOP
                return client.CreateIdNamespace(request);
                #elif CORECLR
                return client.CreateIdNamespaceAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.EntityResolution.Model.IdNamespaceIdMappingWorkflowProperties> IdMappingWorkflowProperty { get; set; }
            public System.String IdNamespaceName { get; set; }
            public List<Amazon.EntityResolution.Model.IdNamespaceInputSource> InputSourceConfig { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.EntityResolution.IdNamespaceType Type { get; set; }
            public System.Func<Amazon.EntityResolution.Model.CreateIdNamespaceResponse, NewERESIdNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
