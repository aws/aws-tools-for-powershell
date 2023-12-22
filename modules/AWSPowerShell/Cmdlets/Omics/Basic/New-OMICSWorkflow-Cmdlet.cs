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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Creates a workflow.
    /// </summary>
    [Cmdlet("New", "OMICSWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateWorkflowResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateWorkflow API operation.", Operation = new[] {"CreateWorkflow"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateWorkflowResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateWorkflowResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateWorkflowResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOMICSWorkflowCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accelerator
        /// <summary>
        /// <para>
        /// <para> The computational accelerator specified to run the workflow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accelerators")]
        [AWSConstantClassSource("Amazon.Omics.Accelerators")]
        public Amazon.Omics.Accelerators Accelerator { get; set; }
        #endregion
        
        #region Parameter DefinitionUri
        /// <summary>
        /// <para>
        /// <para>The URI of a definition for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefinitionUri { get; set; }
        #endregion
        
        #region Parameter DefinitionZip
        /// <summary>
        /// <para>
        /// <para>A ZIP archive for the workflow.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] DefinitionZip { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>An engine for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Omics.WorkflowEngine")]
        public Amazon.Omics.WorkflowEngine Engine { get; set; }
        #endregion
        
        #region Parameter Main
        /// <summary>
        /// <para>
        /// <para>The path of the main definition file for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Main { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParameterTemplate
        /// <summary>
        /// <para>
        /// <para>A parameter template for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ParameterTemplate { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// <para>To ensure that requests don't run multiple times, specify a unique ID for each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>A storage capacity for the workflow in gibibytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateWorkflowResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateWorkflowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSWorkflow (CreateWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateWorkflowResponse, NewOMICSWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accelerator = this.Accelerator;
            context.DefinitionUri = this.DefinitionUri;
            context.DefinitionZip = this.DefinitionZip;
            context.Description = this.Description;
            context.Engine = this.Engine;
            context.Main = this.Main;
            context.Name = this.Name;
            if (this.ParameterTemplate != null)
            {
                context.ParameterTemplate = new Dictionary<System.String, Amazon.Omics.Model.WorkflowParameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.ParameterTemplate.Keys)
                {
                    context.ParameterTemplate.Add((String)hashKey, (WorkflowParameter)(this.ParameterTemplate[hashKey]));
                }
            }
            context.RequestId = this.RequestId;
            context.StorageCapacity = this.StorageCapacity;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _DefinitionZipStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Omics.Model.CreateWorkflowRequest();
                
                if (cmdletContext.Accelerator != null)
                {
                    request.Accelerators = cmdletContext.Accelerator;
                }
                if (cmdletContext.DefinitionUri != null)
                {
                    request.DefinitionUri = cmdletContext.DefinitionUri;
                }
                if (cmdletContext.DefinitionZip != null)
                {
                    _DefinitionZipStream = new System.IO.MemoryStream(cmdletContext.DefinitionZip);
                    request.DefinitionZip = _DefinitionZipStream;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                if (cmdletContext.Engine != null)
                {
                    request.Engine = cmdletContext.Engine;
                }
                if (cmdletContext.Main != null)
                {
                    request.Main = cmdletContext.Main;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.ParameterTemplate != null)
                {
                    request.ParameterTemplate = cmdletContext.ParameterTemplate;
                }
                if (cmdletContext.RequestId != null)
                {
                    request.RequestId = cmdletContext.RequestId;
                }
                if (cmdletContext.StorageCapacity != null)
                {
                    request.StorageCapacity = cmdletContext.StorageCapacity.Value;
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
            finally
            {
                if( _DefinitionZipStream != null)
                {
                    _DefinitionZipStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Omics.Model.CreateWorkflowResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateWorkflow");
            try
            {
                #if DESKTOP
                return client.CreateWorkflow(request);
                #elif CORECLR
                return client.CreateWorkflowAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Omics.Accelerators Accelerator { get; set; }
            public System.String DefinitionUri { get; set; }
            public byte[] DefinitionZip { get; set; }
            public System.String Description { get; set; }
            public Amazon.Omics.WorkflowEngine Engine { get; set; }
            public System.String Main { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.Omics.Model.WorkflowParameter> ParameterTemplate { get; set; }
            public System.String RequestId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Omics.Model.CreateWorkflowResponse, NewOMICSWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
