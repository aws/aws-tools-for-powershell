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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a <i>context</i>. A context is a lineage tracking entity that represents a
    /// logical grouping of other tracking or experiment entities. Some examples are an endpoint
    /// and a model package. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/lineage-tracking.html">Amazon
    /// SageMaker ML Lineage Tracking</a>.
    /// </summary>
    [Cmdlet("New", "SMContext", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateContext API operation.", Operation = new[] {"CreateContext"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateContextResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateContextResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateContextResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMContextCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContextName
        /// <summary>
        /// <para>
        /// <para>The name of the context. Must be unique to your account in an Amazon Web Services
        /// Region.</para>
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
        public System.String ContextName { get; set; }
        #endregion
        
        #region Parameter ContextType
        /// <summary>
        /// <para>
        /// <para>The context type.</para>
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
        public System.String ContextType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Property
        /// <summary>
        /// <para>
        /// <para>A list of properties to add to the context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Properties")]
        public System.Collections.Hashtable Property { get; set; }
        #endregion
        
        #region Parameter Source_SourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceId { get; set; }
        #endregion
        
        #region Parameter Source_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceType { get; set; }
        #endregion
        
        #region Parameter Source_SourceUri
        /// <summary>
        /// <para>
        /// <para>The URI of the source.</para>
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
        public System.String Source_SourceUri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContextArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateContextResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateContextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContextArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContextName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContextName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContextName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContextName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMContext (CreateContext)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateContextResponse, NewSMContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContextName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContextName = this.ContextName;
            #if MODULAR
            if (this.ContextName == null && ParameterWasBound(nameof(this.ContextName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContextType = this.ContextType;
            #if MODULAR
            if (this.ContextType == null && ParameterWasBound(nameof(this.ContextType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContextType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.Property != null)
            {
                context.Property = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Property.Keys)
                {
                    context.Property.Add((String)hashKey, (System.String)(this.Property[hashKey]));
                }
            }
            context.Source_SourceId = this.Source_SourceId;
            context.Source_SourceType = this.Source_SourceType;
            context.Source_SourceUri = this.Source_SourceUri;
            #if MODULAR
            if (this.Source_SourceUri == null && ParameterWasBound(nameof(this.Source_SourceUri)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_SourceUri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateContextRequest();
            
            if (cmdletContext.ContextName != null)
            {
                request.ContextName = cmdletContext.ContextName;
            }
            if (cmdletContext.ContextType != null)
            {
                request.ContextType = cmdletContext.ContextType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Property != null)
            {
                request.Properties = cmdletContext.Property;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.SageMaker.Model.ContextSource();
            System.String requestSource_source_SourceId = null;
            if (cmdletContext.Source_SourceId != null)
            {
                requestSource_source_SourceId = cmdletContext.Source_SourceId;
            }
            if (requestSource_source_SourceId != null)
            {
                request.Source.SourceId = requestSource_source_SourceId;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_SourceType = null;
            if (cmdletContext.Source_SourceType != null)
            {
                requestSource_source_SourceType = cmdletContext.Source_SourceType;
            }
            if (requestSource_source_SourceType != null)
            {
                request.Source.SourceType = requestSource_source_SourceType;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_SourceUri = null;
            if (cmdletContext.Source_SourceUri != null)
            {
                requestSource_source_SourceUri = cmdletContext.Source_SourceUri;
            }
            if (requestSource_source_SourceUri != null)
            {
                request.Source.SourceUri = requestSource_source_SourceUri;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateContextResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateContext");
            try
            {
                #if DESKTOP
                return client.CreateContext(request);
                #elif CORECLR
                return client.CreateContextAsync(request).GetAwaiter().GetResult();
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
            public System.String ContextName { get; set; }
            public System.String ContextType { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> Property { get; set; }
            public System.String Source_SourceId { get; set; }
            public System.String Source_SourceType { get; set; }
            public System.String Source_SourceUri { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateContextResponse, NewSMContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContextArn;
        }
        
    }
}
